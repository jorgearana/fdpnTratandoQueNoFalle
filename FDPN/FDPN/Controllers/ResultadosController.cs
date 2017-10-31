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

namespace FDPN.Controllers
{
    public class ResultadosController : Controller
    {
        DB_9B1F4C_MVCcompetenciasEntities1 db = new DB_9B1F4C_MVCcompetenciasEntities1();
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

            switch (sortOrder)
            {
                case "name_desc":
                    nadadores = nadadores.OrderByDescending(s => s.Last);
                    break;

                default:
                    nadadores = nadadores.OrderBy(s => s.Last);
                    break;
            }
            int pageSize = 20;
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
            VM.afiliado = BuscarAfiliado(VM.nadador.ID_NO);

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

            List<RESULTS> resultadosDelNadador = db.RESULTS.Where(x => x.AthleteId == id && x.NT != 2 && x.NT != 5 && x.I_R == "i" && x.SCORE != "").ToList();
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

            VM.UltimasParticipaciones = resultadosDelNadador.OrderByDescending(x => x.MeetId).DistinctBy(x => x.MeetId).Take(20).ToList();
            VM.MejoresResultados = resultadosDelNadador.OrderBy(x => x.PLACE).ToList();
            return View(VM);

        }

        public ActionResult Calendarios(string disciplina)
        {
            if (disciplina == null)
            {
                disciplina = "";
            }
            DateTime fechainicial = DateTime.Now.AddDays(-15);
            var query = db.Calendario.Where(x => x.Inicio > fechainicial).OrderBy(x => x.Inicio).AsQueryable();
            CalendarioViewModel VM = new CalendarioViewModel
            {
                disciplina = "Todas"
            };

            if (disciplina != "" && disciplina != "Todas")
            {
                query = query.Where(x => x.Disciplina == disciplina);
                VM.disciplina = disciplina;
            }

            VM.calendario = query.ToList();
            VM.disciplinas = new List<string>
            {
                "Natación", "Master natación", "Aguas abiertas", "Polo Acuático", "Clavados", "Sincro"
            };
            return View(VM);

        }

        public ActionResult Rankings(string sexo, int? edadminima, int? edadmaxima, string periodo, string piscina, int? distancia, string estilo)
        {

            int anno = DateTime.Now.Year - 1;
            int annominimo = anno - edadmaxima ?? 0;
            int annomaximo = anno - edadminima ?? 0;


            RankingViewModel VM = new RankingViewModel
            {
                Minima = edadminima ?? 0,
                Maxima = edadmaxima ?? 109
            };

            var resultado = db.RESULTS
                .Where(x => x.NT == 0 && x.SCORE != "" && x.PLACE != 0 && x.ATHLETE != 0 && x.AthleteId != null && x.PLACE != 0 && x.AGE >= VM.Minima && x.AGE <= VM.Maxima)

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
            if (periodo != null)
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

            VM.resultados = resultadoEnlista.Take(50).ToList();


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
            var Query = db.RESULTS.Where(x => x.AGE >= minima && x.AGE <= maxima && x.Athlete1 != null && x.PLACE!=0).AsQueryable();

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
            List<RESULTS> resultados = Query.OrderByDescending(x => x.PFina).Take(200).ToList();
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
            VM.afiliado = BuscarAfiliado(VM.atleta.ID_NO);
            return View(VM);
        }

        public ActionResult RendimientoDelNadadorEnUnaPrueba(int athleteid, int pruebaid)
        {
            List<RESULTS> resultados = db.RESULTS.Where(x => x.AthleteId == athleteid && x.PruebaId == pruebaid && x.PLACE != 0).OrderByDescending(x => x.MEET1.Start).ToList();
            RendimientoDeUnaPruebaViewModel VM = new RendimientoDeUnaPruebaViewModel
            {
                atleta = db.Athlete.Find(athleteid),
                prueba = db.Pruebas.Find(pruebaid),
                ResultadosLarga = resultados.Where(x => x.COURSE == "L").ToList(),
                ResultadosCorta = resultados.Where(x => x.COURSE == "S").ToList(),
            };
            VM.afiliado = BuscarAfiliado(VM.atleta.ID_NO);
            return View(VM);
        }

        public ActionResult ResultadosDeUnTorneo(int meetid)
        {
            List<RESULTS> resultados = db.RESULTS.Where(x => x.MeetId == meetid && x.PLACE != 0 && x.ATHLETE != 0).OrderBy(x => x.MTEV).ToList();

            ResultadoDeUnTorneoViewModel VM = new ResultadoDeUnTorneoViewModel
            {
                EquiposParticipantes = resultados.Select(x => x.TEAM1)
                .DistinctBy(x => x.TeamId)
                .OrderBy(x => x.TName).ToList(),

                resultado = resultados
                .DistinctBy(m => m.MTEV)
                .ToList(),
                pruebas = new Dictionary<string, DiccionarioPruebas>(),

            };
            for (int i = 0; i < VM.resultado.Count(); i++)
            {
                //Con esto trato que las edades de las pruebas se puedan separar para ser usadas en el diccionario
                string edades = VM.resultado[i].LO_HI.ToString();
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

                DiccionarioPruebas dic = new DiccionarioPruebas
                {
                    MeetEvent = VM.resultado[i].MTEV,
                    NombrePrueba = VM.resultado[i].DISTANCE.ToString() + " " + VM.resultado[i].STROKE + " " + edadbaja + " a " + edadalta + " años - " + VM.resultado[i].Athlete1.Sex,
                };


                VM.pruebas.Add(dic.MeetEvent, dic);
            }


            return View(VM);
        }

        public ActionResult Resultados(string sortOrder, string currentFilter, string searchString, int? page)
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

            VM.resultado = resultados.Where(x => x.TeamId == VM.clubid).OrderBy(x => x.MTEV).ThenBy(x => x.PLACE).ToList();
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
            List<RESULTS> resultados = db.RESULTS.Where(x => x.MeetId == modelo.meetid && x.PLACE != 0 && x.MTEV == modelo.pruebaid)

                .OrderBy(x => x.SCORE).ToList();

            RESULTS resultado = resultados[0];


            ResultadosDeUnaPruebaViewModel VM = new ResultadosDeUnaPruebaViewModel
            {
                Resultadosfinales = resultados,
                prueba = db.Pruebas.Where(x => x.distancia.ToString() == resultado.DISTANCE && x.estilo == resultado.STROKE).FirstOrDefault(),
                torneo = db.MEET.Where(x => x.MeetId == modelo.meetid).FirstOrDefault(),
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

        public Afiliado BuscarAfiliado(string DNI)
        {
            Afiliado afiliado = af.Afiliado.Where(x => x.DNI == DNI).FirstOrDefault();
            if (afiliado == null)
            {
                afiliado = new Afiliado
                {
                    Club = af.Club.Find(4128),
                    RutaFoto = "Sinfoto",
                    DNI = "",
                };
            }
            return afiliado;
        }


    }
}