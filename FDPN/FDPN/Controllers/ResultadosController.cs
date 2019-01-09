using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FDPN.Models;
using FDPN.ViewModels.Resultados;
using PagedList;
using System.Globalization;
using MoreLinq;
using System.Text.RegularExpressions;

namespace FDPN.Controllers
{
    public class ResultadosController : Controller
    {
          DB_9B1F4C_MVCcompetenciasEntities db = new   DB_9B1F4C_MVCcompetenciasEntities();
        DB_9B1F4C_afiliacionesEntities1 af = new DB_9B1F4C_afiliacionesEntities1();
        // GET: Resultados

        public ActionResult Nadadores(string sortOrder, string currentFilter, string searchString, string letra, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.Letra = letra ?? "A";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            NadadoresOrdenadosViewModel VM = new NadadoresOrdenadosViewModel
            {
                alphabet = Enumerable.Range(65, 26).Select(i => ((char)i).ToString()).ToList(),
            };


            VM.alphabet.Insert(14, "Ñ");


            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            var nadadores = db.Athlete.AsQueryable();


            if (!String.IsNullOrEmpty(searchString))
            {
                nadadores = nadadores.Where(s => s.Last.Contains(searchString)
                                       || s.First.Contains(searchString));
            }
            else
            {
                if (letra == null)
                {
                    letra = "A";
                }
                nadadores = nadadores.Where(x => x.Last.Substring(0, 1) == letra);
            }

            //switch (sortOrder)
            //{
            //    case "name_desc":
            //        nadadores = nadadores.OrderByDescending(s => s.Last);
            //        break;

            //    default:
            //        nadadores = nadadores.OrderBy(s => s.Last);
            //        break;
            //}

            nadadores = nadadores.OrderBy(s => s.First);

            int pageSize = 50;
            int pageNumber = (page ?? 1);



            VM.nadadores = nadadores.ToPagedList(pageNumber, pageSize);


            return View(VM);
        }

        public ActionResult Nadador(int id)
        {
            DetalleNadadorViewModel VM = new DetalleNadadorViewModel
            {
                nadador = db.Athlete.Where(x => x.AthleteId == id).FirstOrDefault(),
                Mejorestiempos = new Dictionary<Pruebas, ListaTiempos>(),
                MejorPorAnnoLarga = new Dictionary<Pruebas, PorAnnoLarga>(),
                MejorPorAnnoCorta = new Dictionary<Pruebas, PorAnnoCorta>(),
                Annos = new List<int>(),
                MejoresResultados = new List<RESULTS>(),
                searchString = "",
                ContadorDePuestos = new Dictionary<int, Puestos>(),
            };
            VM.Inscripciones = BuscarAfiliado(VM.nadador.ID_NO);

            List<Pruebas> pruebas = db.Pruebas.Where(x => x.PruebaId < 18).ToList();
            DateTime hoy = DateTime.Now;
            DateTime haceunanno = hoy.AddYears(-1).AddDays(-15);

            DateTime Primeroenero = new DateTime(hoy.Year, 1, 1);
            DateTime hacedosannos = Primeroenero.AddYears(-1);
            DateTime hacetresannos = Primeroenero.AddYears(-2);
            DateTime haceuatronnos = Primeroenero.AddYears(-3);
            DateTime hacecincoannos = Primeroenero.AddYears(-4);

            VM.Annos.Add(Primeroenero.Year);
            VM.Annos.Add(hacedosannos.Year);
            VM.Annos.Add(hacetresannos.Year);
            VM.Annos.Add(haceuatronnos.Year);
            VM.Annos.Add(hacecincoannos.Year);

            List<RESULTS> resultadosDelNadador = db.RESULTS.Where(x => x.AthleteId == id && x.NT != 2 && x.NT != 5  && x.SCORE != "" && x.TEAM !=0 &&( x.I_R == "l" || x.PLACE!= 0)).ToList();
            int totalderesultados = resultadosDelNadador.Count();
            RESULTS resultadovacio = new RESULTS
            {
                SCORE = "-",

            };

            foreach (Pruebas prueba in pruebas)
            {
                ListaTiempos listatiempos = new ListaTiempos();
                PorAnnoLarga porannolarga = new PorAnnoLarga();
                PorAnnoCorta porannocorta = new PorAnnoCorta();

                listatiempos.Mejortiempolarga = resultadosDelNadador
                        .Where(x => x.PruebaId == prueba.PruebaId && x.COURSE == "L")
                        .OrderBy(x => x.SCORE)
                        .FirstOrDefault() ?? resultadovacio;
                listatiempos.Mejortiempocorta = resultadosDelNadador
                          .Where(x => x.PruebaId == prueba.PruebaId && x.COURSE == "S")
                          .OrderBy(x => x.SCORE)
                        .FirstOrDefault() ?? resultadovacio;
                listatiempos.Ultimoannolarga = resultadosDelNadador
                        .Where(x => x.PruebaId == prueba.PruebaId && x.COURSE == "L" && x.MEET1.Start > haceunanno)
                        .OrderBy(x => x.SCORE)
                        .FirstOrDefault() ?? resultadovacio;
                listatiempos.Ultimoannocorta = resultadosDelNadador
                        .Where(x => x.PruebaId == prueba.PruebaId && x.COURSE == "S" && x.MEET1.Start > haceunanno)
                       .OrderBy(x => x.SCORE)
                        .FirstOrDefault() ?? resultadovacio;
                porannocorta.uno = resultadosDelNadador
                     .Where(x => x.PruebaId == prueba.PruebaId && x.COURSE == "S" && x.MEET1.Start > Primeroenero)
                       .OrderBy(x => x.SCORE)
                        .FirstOrDefault() ?? resultadovacio;
                porannocorta.dos = resultadosDelNadador
                    .Where(x => x.PruebaId == prueba.PruebaId && x.COURSE == "S" && x.MEET1.Start > hacedosannos && x.MEET1.Start < Primeroenero)
                      .OrderBy(x => x.SCORE)
                        .FirstOrDefault() ?? resultadovacio;
                porannocorta.tres = resultadosDelNadador
                    .Where(x => x.PruebaId == prueba.PruebaId && x.COURSE == "S" && x.MEET1.Start > hacetresannos && x.MEET1.Start < hacedosannos)
                      .OrderBy(x => x.SCORE)
                        .FirstOrDefault() ?? resultadovacio;
                porannocorta.cuatro = resultadosDelNadador
                    .Where(x => x.PruebaId == prueba.PruebaId && x.COURSE == "S" && x.MEET1.Start > haceuatronnos && x.MEET1.Start < hacetresannos)
                      .OrderBy(x => x.SCORE)
                        .FirstOrDefault() ?? resultadovacio;
                porannocorta.cinco = resultadosDelNadador
                    .Where(x => x.PruebaId == prueba.PruebaId && x.COURSE == "S" && x.MEET1.Start > hacecincoannos && x.MEET1.Start < haceuatronnos)
                      .OrderBy(x => x.SCORE)
                        .FirstOrDefault() ?? resultadovacio;
                porannolarga.uno = resultadosDelNadador
                    .Where(x => x.PruebaId == prueba.PruebaId && x.COURSE == "L" && x.MEET1.Start > Primeroenero)
                      .OrderBy(x => x.SCORE)
                        .FirstOrDefault() ?? resultadovacio;
                porannolarga.dos = resultadosDelNadador
                    .Where(x => x.PruebaId == prueba.PruebaId && x.COURSE == "L" && x.MEET1.Start > hacedosannos && x.MEET1.Start < Primeroenero)
                      .OrderBy(x => x.SCORE)
                        .FirstOrDefault() ?? resultadovacio;
                porannolarga.tres = resultadosDelNadador
                    .Where(x => x.PruebaId == prueba.PruebaId && x.COURSE == "L" && x.MEET1.Start > hacetresannos && x.MEET1.Start < hacedosannos)
                      .OrderBy(x => x.SCORE)
                        .FirstOrDefault() ?? resultadovacio;
                porannolarga.cuatro = resultadosDelNadador
                    .Where(x => x.PruebaId == prueba.PruebaId && x.COURSE == "L" && x.MEET1.Start > haceuatronnos && x.MEET1.Start < hacetresannos)
                      .OrderBy(x => x.SCORE)
                        .FirstOrDefault() ?? resultadovacio;
                porannolarga.cinco = resultadosDelNadador
                    .Where(x => x.PruebaId == prueba.PruebaId && x.COURSE == "L" && x.MEET1.Start > hacecincoannos && x.MEET1.Start < haceuatronnos)
                      .OrderBy(x => x.SCORE)
                        .FirstOrDefault() ?? resultadovacio;

                VM.Mejorestiempos.Add(prueba, listatiempos);
                VM.MejorPorAnnoLarga.Add(prueba, porannolarga);
                VM.MejorPorAnnoCorta.Add(prueba, porannocorta);

            }


            for (int puesto = 1; puesto < 100; puesto++)
            {
                Puestos puestos = new Puestos
                {
                    cantidad = resultadosDelNadador.Where(x => x.PLACE == puesto).Count(),
                };
                puestos.porcentaje = ((double)puestos.cantidad / totalderesultados) * 100;
                VM.ContadorDePuestos.Add(puesto, puestos);
                if (VM.ContadorDePuestos.Count() > 10)
                {
                    break;
                }
            }

            VM.UltimasParticipaciones = resultadosDelNadador.OrderByDescending(x => x.MEET1.Start).DistinctBy(x => x.MeetId).Take(20).ToList();
            VM.MejoresResultados = resultadosDelNadador.OrderBy(x => x.PLACE).ToList();
            return View(VM);

        }

        public ActionResult Calendarios(int? disciplina)
        {
            var Query = db.Calendario.AsQueryable();
            Disciplina disciplinaseleccionada = db.Disciplina.Where(x => x.TipoDisciplina == "Todas").FirstOrDefault();
            int valor = disciplina ?? 0;
            if (valor != 0 && valor != 7)
            {
                Query = Query.Where(x => x.DisciplinaId == valor);
                disciplinaseleccionada = db.Disciplina.Where(x => x.DisciplinaId == disciplina).FirstOrDefault();
            }


            CalendarioViewModel VM = new CalendarioViewModel
            {
                disciplina = disciplinaseleccionada.TipoDisciplina,
                disciplinas = db.Disciplina.ToList(),
                calendario = Query.OrderBy(x=>x.Inicio).ToList(),
            };
            
            return View(VM);

        }

        public ActionResult Rankings(string sexo, int? edadminima, int? edadmaxima, string periodo, string piscina, int? distancia, string estilo)
        {

            int anno = DateTime.Now.Year - 1;
            int annominimo = anno -( edadmaxima ?? 109);
            int annomaximo = anno -( edadminima ?? 0);
            DateTime inicio = new DateTime(annominimo, 1, 1);
            DateTime fin = new DateTime(annomaximo, 12, 31);


            RankingViewModel VM = new RankingViewModel
            {
                Minima = edadminima ?? 0,
                Maxima = edadmaxima ?? 109
            };

            var resultado = db.RESULTS
                .Where(x => x.NT == 0 && x.SCORE != ""  &&  x.AthleteId != null && x.NT==0 && x.Athlete1.Birth >= inicio && x.Athlete1.Birth <= fin)

                .AsQueryable();


            VM.sex = "M";
            if (sexo != null)
            {
                VM.sex = sexo;
            }
            resultado = resultado.Where(x => x.Athlete1.Sex == VM.sex);


            VM.piscina = "L";
            if (piscina != null)
            {
                VM.piscina = piscina;
            }
            resultado = resultado.Where(x => x.COURSE == VM.piscina);


            string distance = (distancia ?? 100).ToString();
            string stroke = "Free";
            switch (estilo)
            {

                case "Libre":
                    stroke = "Free";
                    break;
                case "Espalda":
                    stroke = "Back";
                    break;
                case "Mariposa":
                    stroke = "Fly";
                    break;
                case "Pecho":
                    stroke = "Breast";
                    break;
                case "Combinado":
                    stroke = "IM";
                    break;
            }
            resultado = resultado.Where(x => x.STROKE == stroke && x.DISTANCE == distance);

            DateTime hoy = DateTime.Now;
            if (periodo == "Últimos 12 meses")
            {
                hoy = hoy.AddYears(-1).AddDays(-7);
                resultado = resultado.Where(x => x.MEET1.Start > hoy);
            }
            if (periodo != "" && periodo!= null)
            {
                if (periodo.Substring(0, 3) == "Año")
                {
                    string annno = periodo.Substring(4, 4);
                    int ano = Int32.Parse(annno);
                    resultado = resultado.Where(x => x.MEET1.Start.Year == ano);
                }
            }

            //Aquí convierto en lista la Query
            resultado = resultado.OrderBy(x => x.SCORE);
            List<RESULTS> resultadoEnlista = resultado
                .DistinctBy(x => x.AthleteId).ToList();

            VM.resultados = resultadoEnlista.Take(100).ToList();


            VM.distancia = Int32.Parse(distance);
            VM.estilo = stroke;
            VM.piscina = "Larga";
            if (piscina == "S")
            {
                VM.piscina = "Corta";
            }


            return View(VM);
        }


        public ActionResult RankingsFINA()
        {
            DateTime haceunanno = DateTime.Now.AddYears(-1).AddDays(-15);
            RankingFInaViewModel VM = new RankingFInaViewModel
            {
                edadesminimas = new List<int> { 0, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18 },
                edadesmaximas = new List<int> { 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 109 },
                torneos = db.MEET.Where(x => x.Start > haceunanno).OrderByDescending(x=>x.Start).ToList(),
                periodo = new Dictionary<int, string> { { 1, "12 meses" }, { 2, "6 meses" }, { 3, "Elegir torneos" } },
                resultados = new List<RESULTS>(),
            };
            return View(VM);
        }


        public ActionResult CalcularRankignFina( int[] torneosid, int periodoid, int? edadminima, int? edadmaxima )
        {
            DateTime haceunanno = DateTime.Now.AddYears(-1).AddDays(-15);
            

            int minima = edadminima ?? 0;
            int maxima = edadmaxima ?? 109;
            var Query = db.RESULTS.Where(x => x.AGE >= minima && x.AGE <= maxima && x.ATHLETE != 0 && x.PLACE!=0).AsQueryable();

            switch (periodoid)
            {
                case 1:
                    Query = Query.Where(x => x.MEET1.Start > haceunanno);

                    break;
                case 2:
                    haceunanno.AddMonths(6);
                    Query = Query.Where(x => x.MEET1.Start > haceunanno);

                    break;
                case 3:
                    Query = Query.Where(x => torneosid.Contains(x.MeetId ?? 0));
                    break;
            }
            List<RESULTS> provisional = Query.ToList();
            List<RESULTS> resultados = provisional.OrderByDescending(x => x.PFina).Take(100).ToList();


            return PartialView(resultados);

        }

        public ActionResult ResultadoDelNadadorEnUnTorneo(int meetid, int athleteid)
        {
            resultadodelnadadorenuntorneoViewModel VM = new resultadodelnadadorenuntorneoViewModel
            {
                torneo = db.MEET.Find(meetid),
                atleta = db.Athlete.Find(athleteid),
                resultados = db.RESULTS.Where(x => x.NT != 2 && x.NT != 5 && x.SCORE != "" & x.AthleteId == athleteid && x.MeetId == meetid)
                .OrderBy(x => x.PLACE).ToList()
            };
            VM.Inscripciones = BuscarAfiliado(VM.atleta.ID_NO);
            return View(VM);
        }

        public ActionResult RendimientoDelNadadorEnUnaPrueba(int athleteid, int pruebaid)
        {
            List<RESULTS> resultados = db.RESULTS.Where(x => x.AthleteId == athleteid && x.PruebaId == pruebaid && (x.PLACE != 0 || x.I_R=="L")).OrderByDescending(x => x.MEET1.Start).ToList();
            RendimientoDeUnaPruebaViewModel VM = new RendimientoDeUnaPruebaViewModel
            {
                atleta = db.Athlete.Find(athleteid),
                prueba = db.Pruebas.Find(pruebaid),
                ResultadosLarga = resultados.Where(x => x.COURSE == "L").ToList(),
                ResultadosCorta = resultados.Where(x => x.COURSE == "S").ToList(),
            };
            VM.Inscripciones = BuscarAfiliado(VM.atleta.ID_NO);
            return View(VM);
        }

        public ActionResult ResultadosDeUnTorneo(int meetid)
        {
            List<RESULTS> resultados = db.RESULTS.Where(x => x.MeetId == meetid && x.PLACE != 0 && x.ATHLETE != 0 && x.TEAM != 0).ToList();
            SortedDictionary<float, DiccionarioPruebas> pruebasdesordenadas = new SortedDictionary<float, DiccionarioPruebas>();
            ResultadoDeUnTorneoViewModel VM = new ResultadoDeUnTorneoViewModel
            {
                EquiposParticipantes = resultados.Select(x => x.TEAM1)
                .DistinctBy(x => x.TeamId)
                .OrderBy(x => x.TName).ToList(),

                resultadoFinales = resultados
                .DistinctBy(m => m.MTEV)
                .ToList(),
                pruebas = new Dictionary<float, DiccionarioPruebas>(),

            };
            for (int i = 0; i < VM.resultadoFinales.Count(); i++)
            {
                //Con esto trato que las edades de las pruebas se puedan separar para ser usadas en el diccionario
                string edades = VM.resultadoFinales[i].LO_HI.ToString();
                string edadbaja = "00";
                string edadalta = "99";

                switch (edades.Length)
                {
                    //case 2:
                    //    edadbaja ="0";
                    //    edadalta = edades;
                    //    break;
                    case 3:
                        edadbaja = "0" + edades.Substring(0, 1);
                        edadalta = edades.Substring(1, 2);
                        break;
                    case 4:
                        edadbaja = edades.Substring(0, 2);
                        edadalta = edades.Substring(2, 2);
                        break;
                }

                string evento = VM.resultadoFinales[i].MTEV.Replace(" ", "");
                string chars = "";
                float numero = 0;
                float num = 0F;

                int index = evento.IndexOfAny(new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' });
                
                if (index>0)
                {
                    string numeros = evento.Substring(0, index);

                     num = float.Parse(numeros);
                    chars = evento.Substring(numeros.Length);
                   
                   
                }
                else
                {
                    num = float.Parse(evento);
                }
                switch (chars)
                {
                    case "A":
                        numero = 0.1F;
                        break;
                    case "B":
                        numero = 0.2F;
                        break;
                    case "C":
                        numero = 0.3F;
                        break;
                    case "D":
                        numero = 0.4F;
                        break;
                    case "E":
                        numero = 0.5F;
                        break;
                    case "F":
                        numero = 0.6F;
                        break;
                    case "G":
                        numero = 0.7F;
                        break;
                    case "H":
                        numero = 0.8F;
                        break;
                    case "I":
                        numero = 0.9F;
                        break;
                }
                num = num + numero;
                DiccionarioPruebas dic = new DiccionarioPruebas
                {
                    MeetEvent = num,
                    NombrePrueba = VM.resultadoFinales[i].DISTANCE.ToString() + " " + VM.resultadoFinales[i].STROKE + " " + edadbaja + " a " + edadalta + " años - " + VM.resultadoFinales[i].Athlete1.Sex,
                };


                pruebasdesordenadas.Add(dic.MeetEvent, dic);
            }
            foreach(var item in pruebasdesordenadas)
            {
                VM.pruebas.Add(item.Key, item.Value);
            }
           
            return View(VM);
        }

        public ActionResult Resultados(int? page, string sortOrder, string currentFilter, string searchString)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = sortOrder == "name" ? "name_desc" : "name";
            ViewBag.DateSortParm = String.IsNullOrEmpty(sortOrder) ? "date_desc" : "";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            var torneos = db.MEET.AsQueryable();

            if (!String.IsNullOrEmpty(searchString))
            {
                torneos = torneos.Where(s => s.MName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    torneos = torneos.OrderByDescending(s => s.MName);
                    break;
                case "name":
                    torneos = torneos.OrderBy(s => s.MName);
                    break;
                case "date":
                    torneos = torneos.OrderBy(s => s.Start);
                    break;
                default:
                    torneos = torneos.OrderByDescending(s => s.Start);
                    break;
            }
            int pageSize = 25;
            int pageNumber = (page ?? 1);
            return View(torneos.ToPagedList(pageNumber, pageSize));
        }

        [HttpPost]
        public ActionResult ResultadoPorClubes(ResultadoDeUnTorneoViewModel VM)
        {
            List<RESULTS> resultados = db.RESULTS.Where(x => x.MeetId == VM.meetid && x.PLACE != 0).ToList();

            VM.resultadoFinales = resultados.Where(x => x.TeamId == VM.clubid && x.NT==0 && x.F_P =="F" && x.Athlete1 != null).OrderBy(x => x.MTEV).ThenBy(x => x.PLACE).ToList();
            VM.resultadoPreliminares = resultados.Where(x => x.TeamId == VM.clubid && x.NT == 0 && x.F_P == "P" && x.Athlete1 != null).OrderBy(x => x.MTEV).ThenBy(x => x.PLACE).ToList();
            VM.EquiposParticipantes = resultados.Select(x => x.TEAM1)
                .DistinctBy(x => x.TeamId)
                .OrderBy(x => x.TName).ToList();
            VM.torneo = db.MEET.Find(VM.meetid);
            VM.club = db.TEAM.Find(VM.clubid);
            return View(VM);
        }

        [HttpPost]
        public ActionResult ResultadoPorPruebas(ResultadoDeUnTorneoViewModel modelo)
        {

            MEET meet = db.MEET.Where(x => x.MeetId == modelo.meetid).FirstOrDefault();
            List<RESULTS> resultados = db.RESULTS.Where(x => x.MeetId == modelo.meetid && x.ATHLETE != 0 && x.PLACE != 0).ToList();

            int index = modelo.pruebaid.IndexOf(",");
            if (index<0)
            {
                index = modelo.pruebaid.IndexOf(".");
            }
            string evento = modelo.pruebaid;
            if (index>0)
            {
                string entero = modelo.pruebaid.Substring(0, index);
                string fraccion = modelo.pruebaid.Substring(index+1);
                string caracter = "";

                switch (fraccion)
                {
                    case "1":
                        caracter = "A";
                        break;
                    case "2":
                        caracter = "B";
                        break;
                    case "3":
                        caracter = "C";
                        break;
                    case "4":
                        caracter = "D";
                        break;
                    case "5":
                        caracter = "E";
                        break;
                    case "6":
                        caracter = "F";
                        break;
                    case "7":
                        caracter = "G";
                        break;
                    case "8":
                        caracter = "H";
                        break;
                    case "9":
                        caracter = "I";
                        break;
                }
                evento = entero + caracter;
            }
           
            
            
            List<RESULTS >resultadosDelEvento = resultados.Where(x =>   x.MTEV.Trim() == evento)
                                .OrderBy(x => x.PLACE).ToList();
            RESULTS resultado = resultadosDelEvento[0];

            ResultadosDeUnaPruebaViewModel VM = new ResultadosDeUnaPruebaViewModel
            {
                Resultadosfinales = resultadosDelEvento.Where(x=>x.F_P=="F").ToList(),
                Resultadospreliminares= resultadosDelEvento.Where(x => x.F_P == "P").ToList(),
                prueba = db.Pruebas.Where(x => x.distancia.ToString() == resultado.DISTANCE && x.estilo == resultado.STROKE).FirstOrDefault(),
                torneo = meet,
            };
            string edades;

            if (resultado != null)
            {
                edades = resultado.LO_HI.ToString() ?? "";
            }
            else edades = "";
            VM.minima = "0";
            VM.maxima = "99";

            switch (edades.Length)
            {
                case 3:
                    VM.minima = "0" + edades.Substring(0, 1);
                    VM.maxima = edades.Substring(1, 2);
                    break;
                case 4:
                    VM.minima = edades.Substring(0, 2);
                    VM.maxima = edades.Substring(2, 2);
                    break;
            }


            return View(VM);
        }

        public Inscripciones BuscarAfiliado(string DNI)
        {
            Inscripciones Inscripciones = af.Inscripciones.Where(x => x.DNI == DNI).FirstOrDefault();
            if (Inscripciones == null)
            {
                Inscripciones = new Inscripciones
                {
                    Club = af.Club.Find(4128),
                    RutaFoto = "Sinfoto",
                    DNI = "",
                };
            }
            return Inscripciones;
        }




    }
}