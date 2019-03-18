using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FDPN.Models;
using FDPN.ViewModels.Home;
using FDPN.ViewModels.Masters;
using FDPN.ViewModels.Resultados;
using MoreLinq;
using PagedList;

namespace FDPN.Controllers
{
    public class MastersController : BASEController
    {
          public ActionResult index()
        {
            return View();
        }
        public PartialViewResult _mastersdestacado()
        {
            DateTime iniciomes = (new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)).AddMonths(-2);
            Random rnd = new Random();
            //int meet = torneodestacado[i].Meet;
            string sexo = "M";
            List<TorneoDestacadoMasters> destacados = db.TorneoDestacadoMasters.OrderByDescending(x => x.Meet).Take(5).ToList();
            int i = rnd.Next(1, destacados.Count);
            int Meettorneo = destacados[i].Meet;
            MEETMasters torneoAMostrar = db.MEETMasters.Where(x => x.Meet == Meettorneo).FirstOrDefault();

            i = rnd.Next(1, 3);
            if (i == 2)
            {
                sexo = "F";
            }
            
            int edadminima = db.RESULTSMasters.Where(x => x.MEET == Meettorneo).OrderBy(x => x.AGE).Select(x=>x.AGE).FirstOrDefault();
            int edadmaxima = db.RESULTSMasters.Where(x => x.MEET == Meettorneo).OrderByDescending(x => x.AGE).Select(x => x.AGE).FirstOrDefault();
            int maximoCase = (edadmaxima - 24) / 5;
            int categoria = rnd.Next(0, maximoCase);
            switch (categoria)
            {
                case 0:
                    edadminima = 24;
                    edadmaxima = 29;
                    break;
                case 1:
                    edadminima = 30;
                    edadmaxima = 34;
                    break;
                case 2:
                    edadminima = 35;
                    edadmaxima = 39;
                    break;
                case 3:
                    edadminima = 40;
                    edadmaxima = 44;
                    break;
                case 4:
                    edadminima = 45;
                    edadmaxima = 49;
                    break;
                case 5:
                    edadminima = 50;
                    edadmaxima = 54;
                    break;
                case 6:
                    edadminima = 55;
                    edadmaxima = 59;
                    break;
                case 7:
                    edadminima = 60;
                    edadmaxima = 64;
                    break;
                case 8:
                    edadminima = 65;
                    edadmaxima = 69;
                    break;
                case 9:
                    edadminima = 70;
                    edadmaxima = 74;
                    break;
                case 10:
                    edadminima = 75;
                    edadmaxima = 79;
                    break;
                case 11:
                    edadminima = 80;
                    edadmaxima = 84;
                    break;
                case 12:
                    edadminima = 85;
                    edadmaxima = 109;
                    break;
            }
            
            RESULTSMasters resultadomejor = db.RESULTSMasters.Where(x => x.AthleteMasters.Sex == sexo && x.COURSE != "Y" && x.AthleteMasters.Age >= edadminima && x.AthleteMasters.Age <= edadmaxima && x.MEET == torneoAMostrar.Meet).OrderByDescending(x => x.PFina).FirstOrDefault();


            if (resultadomejor == null || resultadomejor.PFina <100)
            {
                iniciomes = iniciomes.AddMonths(-1);
                resultadomejor = db.RESULTSMasters.Where(x => x.AthleteMasters.Sex == sexo && x.MEETMasters.Start > iniciomes && x.COURSE != "Y" && x.AthleteMasters.Age >= edadminima && x.AthleteMasters.Age <= edadmaxima).OrderByDescending(x => x.PFina).FirstOrDefault();
            }




            string dni = resultadomejor.AthleteMasters.ID_NO ?? "";
            NadadorMastersDestacadoViewModels VM = new NadadorMastersDestacadoViewModels
            {
                // resultados = tiempos.Where(x => x.AthleteId == athleteID).OrderBy(x => x.PLACE).ThenByDescending(x => x.PFina).ToList(),
                //afiliado = af.Afiliado.Where(x => x.DNI == dni).FirstOrDefault(),
                resultados = resultadomejor,
                Inscripciones = db.Inscripciones.Where(x => x.DNI == dni).FirstOrDefault(),
            };

            if (VM.Inscripciones == null)
            {
                VM.Inscripciones = new Inscripciones
                {
                    RutaFoto = "sinfoto",
                };
                VM.Inscripciones.Afiliado.Nombre = resultadomejor.AthleteMasters.First;
                VM.Inscripciones.Afiliado.Apellido_Paterno = resultadomejor.AthleteMasters.Last;
            }

            return PartialView("_mastersdestacado", VM);
        }


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

            NadadoresMastersOrdenadosViewModel VM = new NadadoresMastersOrdenadosViewModel
            {
                alphabet = Enumerable.Range(65, 26).Select(i => ((char)i).ToString()).ToList(),
            };


            VM.alphabet.Insert(14, "Ñ");


            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            var nadadores = db.AthleteMasters.AsQueryable();


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

            nadadores = nadadores.OrderBy(s => s.First);

            int pageSize = 50;
            int pageNumber = (page ?? 1);



            VM.nadadores = nadadores.ToPagedList(pageNumber, pageSize);


            return View(VM);
        }

        public PartialViewResult _Nadadores(string sortOrder, string currentFilter, string searchString)
        {
            int tomar = 20;

            if (searchString != null)
            {
                tomar = 100;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            var nadadores = db.AthleteMasters.AsQueryable();

            nadadores = nadadores.OrderBy(s => s.First);

            List<string> letras = Enumerable.Range(65, 26).Select(b => ((char)b).ToString()).ToList();
            Random rnd = new Random();
            int i = rnd.Next(0, 26);
            string letraescogida = letras[i];

            NadadoresMastersOrdenadosSOLOLISTAViewModel VM = new NadadoresMastersOrdenadosSOLOLISTAViewModel
            {                
                nadadores =nadadores.Where(x=>x.Last.StartsWith(letraescogida )).Take(tomar).ToList()
            };
            return PartialView(VM);
        }

        public ActionResult Nadador(int id)
        {
            DetalleNadadorMastersViewModel VM = new DetalleNadadorMastersViewModel
            {
                nadador = db.AthleteMasters.Where(x => x.AthleteId == id).FirstOrDefault(),
                Mejorestiempos = new Dictionary<Pruebas, ViewModels.Masters.ListaTiempos>(),
                MejorPorAnnoLarga = new Dictionary<Pruebas, ViewModels.Masters.PorAnnoLarga>(),
                MejorPorAnnoCorta = new Dictionary<Pruebas, ViewModels.Masters.PorAnnoCorta>(),
                Annos = new List<int>(),
                MejoresResultados = new List<RESULTSMasters>(),
                searchString = "",
                ContadorDePuestos = new Dictionary<int, ViewModels.Masters.Puestos>(),
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

            List<RESULTSMasters> resultadosDelNadador = db.RESULTSMasters.Where(x => x.AthleteId == id && x.NT != 2 && x.NT != 5 && x.I_R == "i" && x.SCORE != "" && x.TEAM != 0).ToList();
            int totalderesultados = resultadosDelNadador.Count();
            RESULTSMasters resultadovacio = new RESULTSMasters
            {
                SCORE = "-",

            };

            foreach (Pruebas prueba in pruebas)
            {
                ViewModels.Masters.ListaTiempos listatiempos = new ViewModels.Masters.ListaTiempos();
                ViewModels.Masters.PorAnnoLarga porannolarga = new ViewModels.Masters.PorAnnoLarga();
                ViewModels.Masters.PorAnnoCorta porannocorta = new ViewModels.Masters.PorAnnoCorta();

                listatiempos.Mejortiempolarga = resultadosDelNadador
                        .Where(x => x.PruebaId == prueba.PruebaId && x.COURSE == "L")
                        .OrderBy(x => x.SCORE)
                        .FirstOrDefault() ?? resultadovacio;
                listatiempos.Mejortiempocorta = resultadosDelNadador
                          .Where(x => x.PruebaId == prueba.PruebaId && x.COURSE == "S")
                          .OrderBy(x => x.SCORE)
                        .FirstOrDefault() ?? resultadovacio;
                listatiempos.Ultimoannolarga = resultadosDelNadador
                        .Where(x => x.PruebaId == prueba.PruebaId && x.COURSE == "L" && x.MEETMasters.Start > haceunanno)
                        .OrderBy(x => x.SCORE)
                        .FirstOrDefault() ?? resultadovacio;
                listatiempos.Ultimoannocorta = resultadosDelNadador
                        .Where(x => x.PruebaId == prueba.PruebaId && x.COURSE == "S" && x.MEETMasters.Start > haceunanno)
                       .OrderBy(x => x.SCORE)
                        .FirstOrDefault() ?? resultadovacio;
                porannocorta.uno = resultadosDelNadador
                     .Where(x => x.PruebaId == prueba.PruebaId && x.COURSE == "S" && x.MEETMasters.Start > Primeroenero)
                       .OrderBy(x => x.SCORE)
                        .FirstOrDefault() ?? resultadovacio;
                porannocorta.dos = resultadosDelNadador
                    .Where(x => x.PruebaId == prueba.PruebaId && x.COURSE == "S" && x.MEETMasters.Start > hacedosannos && x.MEETMasters.Start < Primeroenero)
                      .OrderBy(x => x.SCORE)
                        .FirstOrDefault() ?? resultadovacio;
                porannocorta.tres = resultadosDelNadador
                    .Where(x => x.PruebaId == prueba.PruebaId && x.COURSE == "S" && x.MEETMasters.Start > hacetresannos && x.MEETMasters.Start < hacedosannos)
                      .OrderBy(x => x.SCORE)
                        .FirstOrDefault() ?? resultadovacio;
                porannocorta.cuatro = resultadosDelNadador
                    .Where(x => x.PruebaId == prueba.PruebaId && x.COURSE == "S" && x.MEETMasters.Start > haceuatronnos && x.MEETMasters.Start < hacetresannos)
                      .OrderBy(x => x.SCORE)
                        .FirstOrDefault() ?? resultadovacio;
                porannocorta.cinco = resultadosDelNadador
                    .Where(x => x.PruebaId == prueba.PruebaId && x.COURSE == "S" && x.MEETMasters.Start > hacecincoannos && x.MEETMasters.Start < haceuatronnos)
                      .OrderBy(x => x.SCORE)
                        .FirstOrDefault() ?? resultadovacio;
                porannolarga.uno = resultadosDelNadador
                    .Where(x => x.PruebaId == prueba.PruebaId && x.COURSE == "L" && x.MEETMasters.Start > Primeroenero)
                      .OrderBy(x => x.SCORE)
                        .FirstOrDefault() ?? resultadovacio;
                porannolarga.dos = resultadosDelNadador
                    .Where(x => x.PruebaId == prueba.PruebaId && x.COURSE == "L" && x.MEETMasters.Start > hacedosannos && x.MEETMasters.Start < Primeroenero)
                      .OrderBy(x => x.SCORE)
                        .FirstOrDefault() ?? resultadovacio;
                porannolarga.tres = resultadosDelNadador
                    .Where(x => x.PruebaId == prueba.PruebaId && x.COURSE == "L" && x.MEETMasters.Start > hacetresannos && x.MEETMasters.Start < hacedosannos)
                      .OrderBy(x => x.SCORE)
                        .FirstOrDefault() ?? resultadovacio;
                porannolarga.cuatro = resultadosDelNadador
                    .Where(x => x.PruebaId == prueba.PruebaId && x.COURSE == "L" && x.MEETMasters.Start > haceuatronnos && x.MEETMasters.Start < hacetresannos)
                      .OrderBy(x => x.SCORE)
                        .FirstOrDefault() ?? resultadovacio;
                porannolarga.cinco = resultadosDelNadador
                    .Where(x => x.PruebaId == prueba.PruebaId && x.COURSE == "L" && x.MEETMasters.Start > hacecincoannos && x.MEETMasters.Start < haceuatronnos)
                      .OrderBy(x => x.SCORE)
                        .FirstOrDefault() ?? resultadovacio;

                VM.Mejorestiempos.Add(prueba, listatiempos);
                VM.MejorPorAnnoLarga.Add(prueba, porannolarga);
                VM.MejorPorAnnoCorta.Add(prueba, porannocorta);

            }


            for (int puesto = 1; puesto < 100; puesto++)
            {
                ViewModels.Masters.Puestos puestos = new ViewModels.Masters.Puestos
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

            VM.UltimasParticipaciones = resultadosDelNadador.OrderByDescending(x => x.MEETMasters.Start).DistinctBy(x => x.MeetId).Take(20).ToList();
            VM.MejoresResultados = resultadosDelNadador.OrderBy(x => x.PLACE).ToList();
            return View(VM);

        }

        public PartialViewResult _indexranking()
        {
            string sexo;
            string piscina;
            Random rnd = new Random();
            int prueba = 0;
            int i = 0;

            
            int edadminima = 0; 
            int edadmaxima = db.RESULTSMasters.OrderByDescending(x => x.AGE).Select(x => x.AGE).FirstOrDefault();
            int maximoCase =  (edadmaxima - 24) / 5;

            //List<RESULTSMasters> todosLosResultados =.ToList();
            List<RESULTSMasters> MenosResultados = new List<RESULTSMasters>();
            do
            {
                 sexo = "F";
                 piscina = "L";
               
                 prueba = rnd.Next(1, 17);
                 i = rnd.Next(0, 2);

                if (i == 1)
                {
                    sexo = "M";
                }
                i = rnd.Next(0, 2);
                if (i == 1)
                {
                    piscina = "S";
                }

                MenosResultados = db.RESULTSMasters
                        .Where(x => x.PruebaId == prueba && x.NT == 0 && x.SCORE != "" && x.ATHLETE != 0 && x.AthleteMasters.Sex == sexo && x.COURSE == piscina && x.PLACE != 0)
                        .OrderBy(x => x.SCORE)
                        .ToList();

            }
            while (MenosResultados.Count() < 1);


            TopRankingMastersViewModel VM = new TopRankingMastersViewModel();
            
                do
                { int categoria = rnd.Next(0, maximoCase);

                    switch (categoria)
                    {
                        case 0:
                            edadminima = 24;
                            edadmaxima = 29;
                            break;
                        case 1:
                            edadminima = 30;
                            edadmaxima = 34;
                            break;
                        case 2:
                            edadminima = 35;
                            edadmaxima = 39;
                            break;
                        case 3:
                            edadminima = 40;
                            edadmaxima = 44;
                            break;
                        case 4:
                            edadminima = 45;
                            edadmaxima = 49;
                            break;
                        case 5:
                            edadminima = 50;
                            edadmaxima = 54;
                            break;
                        case 6:
                            edadminima = 55;
                            edadmaxima = 59;
                            break;
                        case 7:
                            edadminima = 60;
                            edadmaxima = 64;
                            break;
                        case 8:
                            edadminima = 65;
                            edadmaxima = 69;
                            break;
                        case 9:
                            edadminima = 70;
                            edadmaxima = 74;
                            break;
                        case 10:
                            edadminima = 75;
                            edadmaxima = 79;
                            break;
                        case 11:
                            edadminima = 80;
                            edadmaxima = 84;
                            break;
                        case 12:
                            edadminima = 85;
                            edadmaxima = 109;
                            break;



                    }


                    VM.resultado = MenosResultados
                    .Where(x =>  x.AGE <= edadmaxima && x.AGE >= edadminima)
                    .OrderBy(x => x.SCORE)
                    .DistinctBy(x => x.AthleteId)
                    .Take(10).ToList();
                    VM.maxima = edadmaxima;
                    VM.minima = edadminima;
                } while (VM.resultado.Count() < 1);
           
            return PartialView("_indexranking", VM);
        }

        public PartialViewResult _RelacionDeTorneos(string searchString)
        {
            var query = db.MEETMasters.OrderByDescending(x => x.Start).AsQueryable();
            if (!String.IsNullOrEmpty(searchString))
            {
                query = query.Where(s => s.MName.Contains(searchString));
            }
            
            return PartialView(query.Take(20).ToList());
        }

        public PartialViewResult _Records(string searchString)
        {
            var query = db.Fotos.Where(x => x.Noticias.CategoriaNoticia.TipoNoticia == "Record" && x.Noticias.DisciplinaId == 6).OrderBy(x => x.Noticias.Titulo).AsQueryable();

            if (searchString != null)
            {
                query = query.Where(x => x.Noticias.Titulo.Contains(searchString));
            }

            List<Fotos> listado = query.ToList();

            return PartialView(listado);
        }

        public ActionResult ResultadosDeUnTorneo(int meetid)
        {
            List<RESULTSMasters > resultados = db.RESULTSMasters.Where(x => x.MeetId == meetid && x.PLACE != 0 && x.ATHLETE != 0 && x.TEAM != 0).ToList();
            SortedDictionary<float, ViewModels.Masters.DiccionarioPruebas> pruebasdesordenadas = new SortedDictionary<float, ViewModels.Masters.DiccionarioPruebas>();
            ResultadoDeUnTorneoMastersViewModel VM = new ResultadoDeUnTorneoMastersViewModel
            {
                EquiposParticipantes = resultados.Select(x => x.TEAMMasters)
                .DistinctBy(x => x.TeamId)
                .OrderBy(x => x.TName).ToList(),

                resultadoFinales = resultados
                .DistinctBy(m => m.MTEV)
                .ToList(),
                pruebas = new Dictionary<float, ViewModels.Masters.DiccionarioPruebas>(),

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

                if (index > 0)
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
                ViewModels.Masters.DiccionarioPruebas dic = new ViewModels.Masters.DiccionarioPruebas
                {
                    MeetEvent = num,
                    NombrePrueba = VM.resultadoFinales[i].DISTANCE.ToString() + " " + VM.resultadoFinales[i].STROKE + " " + edadbaja + " a " + edadalta + " años - " + VM.resultadoFinales[i].AthleteMasters.Sex,
                };


                pruebasdesordenadas.Add(dic.MeetEvent, dic);
            }
            foreach (var item in pruebasdesordenadas)
            {
                VM.pruebas.Add(item.Key, item.Value);
            }

            return View(VM);
        }


        public ActionResult RendimientoDelNadadorEnUnaPrueba(int athleteid, int pruebaid)
        {
            List<RESULTSMasters> resultados = db.RESULTSMasters.Where(x => x.AthleteId == athleteid && x.PruebaId == pruebaid && x.PLACE != 0).OrderByDescending(x => x.MEETMasters.Start).ToList();
            RendimientoDeUnaPruebaMastersViewModel VM = new RendimientoDeUnaPruebaMastersViewModel
            {
                atleta = db.AthleteMasters.Find(athleteid),
                prueba = db.Pruebas.Find(pruebaid),
                ResultadosLarga = resultados.Where(x => x.COURSE == "L").ToList(),
                ResultadosCorta = resultados.Where(x => x.COURSE == "S").ToList(),
            };
            VM.Inscripciones = BuscarAfiliado(VM.atleta.ID_NO);
            return View(VM);
        }


        public ActionResult ResultadoDelNadadorEnUnTorneo(int meetid, int athleteid)
        {
            resultadodelnadadorMastersenuntorneoViewModel VM = new resultadodelnadadorMastersenuntorneoViewModel
            {
                torneo = db.MEETMasters.Find(meetid),
                atleta = db.AthleteMasters.Find(athleteid),
                resultados = db.RESULTSMasters.Where(x => x.AthleteId == athleteid && x.MeetId== meetid   && (x.I_R == "L" || x.PLACE != 0))
                .OrderBy(x => x.PLACE).ToList()
            };
            VM.Inscripciones = BuscarAfiliado(VM.atleta.ID_NO);
            return View(VM);
        }


        [HttpPost]
        public ActionResult ResultadoPorClubes(ResultadoDeUnTorneoMastersViewModel VM)
        {
            List<RESULTSMasters> resultados = db.RESULTSMasters.Where(x => x.MeetId == VM.meetid && x.PLACE != 0).ToList();

            VM.resultadoFinales = resultados.Where(x => x.TeamId == VM.clubid && x.NT == 0 && x.F_P == "F" && x.AthleteMasters != null).OrderBy(x => x.MTEV).ThenBy(x => x.PLACE).ToList();
            VM.resultadoPreliminares = resultados.Where(x => x.TeamId == VM.clubid && x.NT == 0 && x.F_P == "P" && x.AthleteMasters != null).OrderBy(x => x.MTEV).ThenBy(x => x.PLACE).ToList();
            VM.EquiposParticipantes = resultados.Select(x => x.TEAMMasters)
                .DistinctBy(x => x.TeamId)
                .OrderBy(x => x.TName).ToList();
            VM.torneo = db.MEETMasters.Find(VM.meetid);
            VM.club = db.TEAMMasters.Find(VM.clubid);
            return View(VM);
        }

        [HttpPost]
        public ActionResult ResultadoPorPruebas(ResultadoDeUnTorneoMastersViewModel modelo)
        {

            MEETMasters meet = db.MEETMasters.Where(x => x.MeetId == modelo.meetid).FirstOrDefault();


            int index = modelo.pruebaid.IndexOf(",");
            string evento = modelo.pruebaid;
            if (index > 0)
            {
                string entero = modelo.pruebaid.Substring(0, index);
                string fraccion = modelo.pruebaid.Substring(index + 1);
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

            List<RESULTSMasters> resultados = db.RESULTSMasters.Where(x => x.MeetId == modelo.meetid && x.ATHLETE != 0 && x.PLACE != 0 && x.MTEV.Trim() == evento)
                                .OrderBy(x => x.SCORE).ToList();
            RESULTSMasters resultado = resultados[0];


            ResultadosDeUnaPruebaMastersViewModel VM = new ResultadosDeUnaPruebaMastersViewModel
            {
                Resultados = new Dictionary<CategoriasMasters, List<RESULTSMasters>>(),
                prueba = db.Pruebas.Where(x => x.distancia.ToString() == resultado.DISTANCE && x.estilo == resultado.STROKE).FirstOrDefault(),
                torneo = db.MEETMasters.Where(x => x.MeetId == modelo.meetid).FirstOrDefault(),
            };

            List<CategoriasMasters> categorasMasters = db.CategoriasMasters.ToList();
            foreach(CategoriasMasters categoria in categorasMasters )
            {
                List<RESULTSMasters> resultadosDeEstaCategoria = resultados.Where(x => x.AGE <= categoria.EdadMaxima && x.AGE >= categoria.EdadMinima).ToList();
                if(resultadosDeEstaCategoria.Count()>0)
                {
                    VM.Resultados.Add(categoria, resultadosDeEstaCategoria);
                }
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
            var torneos = db.MEETMasters.AsQueryable();

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


        public Inscripciones BuscarAfiliado(string DNI)
        {
            Inscripciones Inscripciones = db.Inscripciones.Where(x => x.DNI == DNI).FirstOrDefault();
            if (Inscripciones == null)
            {
                Inscripciones = new Inscripciones
                {
                    Club = db.Club.Find(4128),
                    RutaFoto = "Sinfoto",
                    DNI = "",
                };
            }
            return Inscripciones;
        }

        public PartialViewResult _previewnoticias ()
        {
            List<previewNoticiasViewModel> VM = new List<previewNoticiasViewModel>();
            List<Noticias> noticias = db.Noticias.Where(x => x.CategoriaId == 1 && x.Disciplina.TipoDisciplina == "masters").OrderByDescending(x => x.Fecha).ThenByDescending(x => x.NoticiaId).Take(9).ToList();
            foreach (Noticias noticia in noticias)
            {
                previewNoticiasViewModel preview = new previewNoticiasViewModel
                {
                    noticia = noticia,
                    fotos = db.Fotos.Where(x => x.NoticiaId == noticia.NoticiaId).ToList(),
                };
                VM.Add(preview);
            }
            return PartialView("_PreviewNoticias", VM);
        }

        public PartialViewResult _BasesMasters(string searchString)
        {
            var query = db.Fotos.Where(x => x.Noticias.CategoriaNoticia.TipoNoticia == "Base" && x.Noticias.DisciplinaId == 6).OrderBy(x => x.Noticias.Fecha).AsQueryable();

            if (searchString != null)
            {
                query = query.Where(x => x.Noticias.Titulo.Contains(searchString));
            }

            List<Fotos> listado = query.Take(10).ToList();

            return PartialView(listado);
        }

       

    }
}