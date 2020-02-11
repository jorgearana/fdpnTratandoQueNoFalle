using FDPN.Models;
using InscripcionNatacion.Helpers;

using InscripcionNatacion.ViewModels.Home;
using InscripcionNatacion.ViewModels.Inscrito;
using InscripcionNatacion.ViewModels.Torneo;
using MoreLinq;
using MoreLinq.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace InscripcionNatacion.Controllers
{
    public class InscritoController : BASEController
    {

        Repository repository = new Repository();
        int AnnoMaximo;
        int AnnoMinimo;
        int AnnoVinculados;

        public ActionResult ListarNadadores(int Meetid)
        {
            if (!repository.validarUsuario())
            {
                return RedirectToAction("Login", "home");
            }
            Usuario usuario = Session["Usuario"] as Usuario;
            Equipos equipo = db.Equipos.FirstOrDefault(x => x.Team_abbr == usuario.Club.Iniciales);
            if (equipo == null)
            {
                return RedirectToAction("InscribirResponsable", new { MeetId = Meetid });
            }
            InscripcionResponsable responsable = db.InscripcionResponsable.FirstOrDefault(x => x.TeamId == equipo.TeamId);
            if (responsable == null)
            {
                return RedirectToAction("InscribirResponsable", new { MeetId = Meetid });
            }
            SetupTorneo setup = db.SetupTorneo.FirstOrDefault(x => x.Meetid == Meetid);
            if (setup.Debutantes)
            {
                return RedirectToAction("ListarNadadoresParaSemillero", new { MeetId = Meetid });
            }

            List<ListarNadadoresParaSeleccionarlos> VM = new List<ListarNadadoresParaSeleccionarlos>();
            List<Eventos> ListadoDeEventos = db.Eventos.Where(x => x.MeetId == Meetid).ToList();
            int EdadMaxima = ListadoDeEventos.Max(x => x.High_Age) ?? 109;
            int EdadMinima = ListadoDeEventos.Min(x => x.Low_age) ?? 0;
            int annoActual = DateTime.Now.Year - 1;
            AnnoMaximo = annoActual - EdadMinima;
            AnnoMinimo = annoActual - EdadMaxima;
            AnnoVinculados = annoActual - 11 - 1;



            
            Club club = Session["Club"] as Club;


            if (setup.PorLigas && club.AsociacionId != null)
            {
                ErrorViewModel modeloError = new ErrorViewModel
                {
                    Principal = "No tiene permiso para inscribir en este torneo",
                    Medio = "Este evento se realiza por asociaciones o ligas",
                    Pie = "Por favor ingrese con el usuario y contraseña de una asociación o liga",
                };
                return RedirectToAction("Home/paginadeerroromensaje", new { modeloError });
            }

            List<Inscripciones> ListadoDeNadadores = GetNadadores(setup, EdadMaxima, EdadMinima);
            VM = GetInscripciones(setup, ListadoDeNadadores);
            ViewBag.setup = db.SetupTorneo.Where(x => x.Meetid == Meetid).FirstOrDefault();

            return View(VM);
        }


        public ActionResult ListarNadadoresParaSemillero(int Meetid)
        {
            Torneo torneo = db.Torneo.Find(Meetid);
            Usuario usuario = Session["usuario"] as Usuario;
            Club club = db.Club.Where(x => x.ClubID == usuario.ClubId).FirstOrDefault();

            List<Eventos> ListadoDeEventos = db.Eventos.Where(x => x.MeetId == Meetid).ToList();
            int EdadMaxima = ListadoDeEventos.Max(x => x.High_Age) ?? 109;
            int EdadMinima = ListadoDeEventos.Min(x => x.Low_age) ?? 0;
            int annoActual = DateTime.Now.Year - 1;
            int AnnoMaximo = annoActual - EdadMinima;
            int AnnoMinimo = annoActual - EdadMaxima;


            List<ListarNadadoresParaSeleccionarlos> VM = new List<ListarNadadoresParaSeleccionarlos>();


            List<Inscripciones> listadoNadadores = db
                .Inscripciones.Where(x => x.ClubID == club.ClubID &&
                x.Afiliado.Fecha_de_nacimiento.Year >= AnnoMinimo &&
                x.Afiliado.Fecha_de_nacimiento.Year <= AnnoMaximo && x.DisciplinaId == 1)
                .OrderBy(x => x.Afiliado.Fecha_de_nacimiento)
                .ToList();

            List<Entradas> EntradasDeEsteTorneo = db.Entradas.Where(x => x.MeetId == Meetid).ToList();
            List<atletas> atletasDeEsteTorneo = db.atletas.Where(x => x.Meetid == Meetid).ToList();
            foreach (Inscripciones afiliado in listadoNadadores)
            {
                ListarNadadoresParaSeleccionarlos listarnadadorparaafiliar = new ListarNadadoresParaSeleccionarlos
                {
                    afiliado = afiliado,
                    YaEstaInscrito = false,
                    TieneResultado = db.RESULTS.Any(x => x.Athlete1.ID_NO == afiliado.DNI && x.NT == 0),
                    TieneMulta = db.Multas.Any(x => x.InscripcionId == afiliado.InscripcionId && x.Subsanada == false),
                };



                if (atletasDeEsteTorneo.Any(x => x.Reg_no == afiliado.DNI))
                {
                    atletas atleta = atletasDeEsteTorneo.Where(x => x.Reg_no == afiliado.DNI).FirstOrDefault();
                    listarnadadorparaafiliar.YaEstaInscrito = true;
                    //if (EntradasDeEsteTorneo.Any(x => x.Ath_no == atleta.Ath_no && x.MeetId == Meetid))
                    //{
                    //    listarnadadorparaafiliar.YaEstaInscrito = true;
                    //}

                }

                VM.Add(listarnadadorparaafiliar);
            }
            ViewBag.Meet = db.Torneo.Where(x => x.Meetid == Meetid).Select(x => x.Meet_name1).FirstOrDefault();
            ViewBag.torneo = torneo;

            ViewBag.setup = db.SetupTorneo.Where(x => x.Meetid == Meetid).FirstOrDefault();


            return View(VM);
        }

        public ActionResult ListarNadadoresParaFdnp(int Meetid)
        {
            if (!repository.validarUsuario())
            {
                return RedirectToAction("Login", "home");
            }
            List<ListarNadadoresParaSeleccionarlos> VM = new List<ListarNadadoresParaSeleccionarlos>();
            List<atletas> entradasDelTorneo = db.atletas.Where(x => x.Meetid == Meetid).ToList();

            foreach (var atleta in entradasDelTorneo)
            {

                //Aquí agregar una columna en la tabla atletas para unir con la tabla equipos.
                ListarNadadoresParaSeleccionarlos modelo = new ListarNadadoresParaSeleccionarlos
                {
                    afiliado = db.Inscripciones.Where(x => x.DNI == atleta.Reg_no).FirstOrDefault(),
                    YaEstaInscrito = true,
                };
                VM.Add(modelo);
            }
            ViewBag.setup = db.SetupTorneo.Where(x => x.Meetid == Meetid).FirstOrDefault();

            return View(VM);
        }

        public List<Inscripciones> GetNadadores(SetupTorneo setup, int EdadMaxima, int EdadMinima)
        {
            int annoActual = DateTime.Now.Year - 1;
            AnnoMaximo = annoActual - EdadMinima;
            AnnoMinimo = annoActual - EdadMaxima;
            AnnoVinculados = annoActual - 11 + 1;
            IQueryable<Inscripciones> listado;
            Usuario usuario = Session["Usuario"] as Usuario;

            if (EdadMinima >= 11)
            {
                listado = db
                        .Inscripciones.Where(x => x.ClubID == usuario.Club.ClubID && x.Afiliado.Fecha_de_nacimiento.Year >= AnnoMinimo && x.Afiliado.Fecha_de_nacimiento.Year <= AnnoMaximo)
                        .AsQueryable();
                if (!setup.PermiteNoAfiliados)
                {
                    listado = listado.Where(x => x.EstadoID == 3);
                }
            }
            else
            {
                listado = db
                        .Inscripciones.Where(x => x.ClubID == usuario.Club.ClubID && x.Afiliado.Fecha_de_nacimiento.Year >= AnnoMinimo && x.Afiliado.Fecha_de_nacimiento.Year <= AnnoVinculados)
                        .AsQueryable();
                if (!setup.PermiteNoAfiliados)
                {
                    listado = listado.Where(x => x.EstadoID == 3);
                }

                listado = listado.Union(db
                   .Inscripciones.Where(x => x.ClubID == usuario.Club.ClubID && x.Afiliado.Fecha_de_nacimiento.Year >= AnnoVinculados && x.Afiliado.Fecha_de_nacimiento.Year <= AnnoMaximo
                   ).AsQueryable());

            }

            //listado = listado.Where(x => x.DNI == "70491205");

            List<Inscripciones> listadoNadadores = new List<Inscripciones>();
            listadoNadadores = listado
            .OrderBy(x => x.Afiliado.Fecha_de_nacimiento)
            .ToList();
            return listadoNadadores;
        }
        public List<ListarNadadoresParaSeleccionarlos> GetInscripciones(SetupTorneo torneo, List<Inscripciones> ListadoDeNadadores)
        {
            List<ListarNadadoresParaSeleccionarlos> VM = new List<ListarNadadoresParaSeleccionarlos>();
            List<Entradas> EntradasDeEsteTorneo = db.Entradas.Where(x => x.MeetId == torneo.Meetid).ToList();
            List<atletas> atletasDeEsteTorneo = db.atletas.Where(x => x.Meetid == torneo.Meetid).ToList();
            foreach (Inscripciones afiliado in ListadoDeNadadores)
            {
                ListarNadadoresParaSeleccionarlos listarnadadorparaafiliar = new ListarNadadoresParaSeleccionarlos
                {
                    afiliado = afiliado,
                    YaEstaInscrito = false,
                    TieneMulta = db.Multas.Any(x => x.InscripcionId == afiliado.InscripcionId && x.Subsanada == false),
                };
                if (atletasDeEsteTorneo.Any(x => x.Reg_no == afiliado.DNI))
                {
                    atletas atleta = atletasDeEsteTorneo.Where(x => x.Reg_no == afiliado.DNI).FirstOrDefault();
                    listarnadadorparaafiliar.YaEstaInscrito = true;
                }
                if (torneo.Debutantes)
                {
                    if (db.RESULTS.Any(x => x.Athlete1.ID_NO == afiliado.DNI))
                    {
                        listarnadadorparaafiliar.TieneResultado = true;
                    }
                }
                VM.Add(listarnadadorparaafiliar);
            }
            return VM;
        }


        public InscritoViewModel ObenerElMejorTiempo(InscritoViewModel NadadorAInscribir, RESULTS resultadoenlarga, RESULTS resultadoencorta, string curso, SetupTorneo setup)
        {
            // Ver si cumple la marca mínima, primero la de la competencia, usando LSY y SLY
            RESULTS resultado = new RESULTS();
            float segundoslarga = 0;
            float segundoscorta = 0;
            int pruebaid = resultadoenlarga.PruebaId ?? resultadoencorta.PruebaId ?? 0;


            if (resultadoenlarga != null)
            {
                segundoslarga = ConvertirASegundos(resultadoenlarga.SCORE ?? "00:00.00");
            }
            if (resultadoenlarga != null)
            {
                segundoscorta = ConvertirASegundos(resultadoencorta.SCORE ?? "00:00.00");
            }

            return NadadorAInscribir;
        }


        public ActionResult RetirarDelTorneo(int MeetId, int afiliadoId)
        {
            //Afiliado afiliado = af.Afiliado.Where(x => x.DeportistaId == afiliadoId).FirstOrDefault();
            Inscripciones inscripciones = db.Inscripciones.Find(afiliadoId);
            atletas atleta = db.atletas.Where(x => x.Reg_no == inscripciones.DNI && x.Meetid == MeetId).FirstOrDefault();
            List<Entradas> entradasDelDeportista = db.Entradas.Where(x => x.Ath_no == atleta.Ath_no && x.MeetId == MeetId).ToList();
            Equipos equipo = db.Equipos.Where(x => x.Team_no == atleta.Team_no && x.MeetId == MeetId).FirstOrDefault();

            foreach (Entradas entrada in entradasDelDeportista)
            {
                db.Entradas.Remove(entrada);
            }

            db.atletas.Remove(atleta);
            db.SaveChanges();
            // para ver si quedaron atletas de este club
            List<atletas> listado = db.atletas.Where(x => x.Team_no == equipo.Team_no).ToList();
            if (listado == null || listado.Count() == 0)
            {
                db.Equipos.Remove(equipo);
                db.SaveChanges();
            }

            return RedirectToAction("ListarNadadores", new { MeetId = MeetId });



        }


        public ActionResult ListarPruebasParaElNadador(int MeetId, int afiliadoId)
        {
            int annoActual = DateTime.Now.Year - 1; /*Para calcular la edad al año pasado*/

            //Iniciando las variables a usar más adelante
            SetupTorneo setup = db.SetupTorneo.Where(x => x.Meetid == MeetId).FirstOrDefault();
            List<SessionItem> ListadoDeSessionItem = db.SessionItem.Where(x => x.Meetid == MeetId).ToList();
            List<int> PruebasYaInscritas = new List<int>();
            RESULTS resultado = new RESULTS();

            DateTime fecha = setup.Torneo.entry_deadline ?? DateTime.Now;
            DateTime haceunanno = setup.Torneo.EntryEligibility_date ?? fecha.AddYears(-1).AddDays(-15);

            List<MarcasMinimas> MarcasMinimasDelTorneo = new List<MarcasMinimas>();
            if (!setup.Debutantes)
            {
                MarcasMinimasDelTorneo = db.MarcasMinimas.Where(x => x.MeetId == MeetId).ToList();
            }
            string stroke = "Free";
            //Hallo el tipo de piscina en el que se nadará

            int NumeroSesiones = setup.Torneo.Sesion.OrderByDescending(x => x.SessionId).Select(x => x.Sess_day).FirstOrDefault() ?? 1;
            int pruebasXtorneo = setup.pruebasXtorneo;
            int pruebasConMarca = 0;

            //Inicio de variable del modelo
            ListadoInscritoViewModel VM = new ListadoInscritoViewModel
            {
                afiliado = db.Inscripciones.Where(x => x.InscripcionId == afiliadoId).FirstOrDefault(),
                listaDeEventos = new List<ViewModels.Inscrito.InscritoViewModel>(),
                Sesiones = new List<SesionViewModel>(),
                PruebasTotales = pruebasXtorneo,
                Piscina = "",
                PruebasInscritasSinMarca = 0,
                SinMarca = 1,
                MeetId = MeetId,

            };

            if (!db.Athlete.Any(x => x.ID_NO == VM.afiliado.DNI))
            {
                ViewBag.Meetid = setup.Meetid;
                return View("NotieneDNI", VM.afiliado);
            }


            //Todos los resultados del nadador en un año
            List<RESULTS> resultados = db.RESULTS
                       .Where(x => x.Athlete1.ID_NO == VM.afiliado.DNI && x.MEET1.Start > haceunanno && x.SCORE != "" && x.NT == 0)
                       .ToList();


            List<RESULTS> CienEspalda = db.RESULTS
                .Where(x => x.Athlete1.ID_NO == VM.afiliado.DNI && x.MEET1.Start > haceunanno && x.NT == 0
                && x.DISTANCE == "100" && x.STROKE == "Back").ToList();

            if (setup.Torneo.Meet_course == 1)
            {
                VM.Piscina = "L";
            }
            else
            {
                VM.Piscina = "S";
            }

            //1 .- buscar al afiliado en la bd de inscripciones, sirve para saber si ya está inscrito
            atletas atleta = db.atletas.Where(x => x.Reg_no == VM.afiliado.DNI && x.Meetid == MeetId).FirstOrDefault(); // en la BD de inscripciones
            if (atleta != null)
            {
                VM.YaestaInscrito = db.Entradas.Any(x => x.MeetId == MeetId && x.Ath_no == atleta.Ath_no);
            }
            else
            {
                VM.YaestaInscrito = false;
            }


            //2 .- Buscar los eventos que podría nadar el afiliado
            int edad = annoActual - VM.afiliado.Afiliado.Fecha_de_nacimiento.Year;
            List<Eventos> eventosDelNadador = db.Eventos
            .Where(x => x.MeetId == MeetId && x.Low_age <= edad && x.High_Age >= edad && x.Event_gender == VM.afiliado.Afiliado.Sexo && x.Ind_rel == "i")
            .OrderBy(x => x.Event_no).ToList();

            foreach (Eventos evento in eventosDelNadador)
            {
                InscritoViewModel NadadorAInscribir = new InscritoViewModel
                {
                    evento = evento,
                    sesion = ListadoDeSessionItem.Where(x => x.Event_ptr == evento.Event_ptr).Select(x => x.Sess_ptr).FirstOrDefault() ?? 0,
                    MMCorta = 0,
                    MMLarga = 0,
                };

                if (!setup.Debutantes && setup.SinMarca!=1)
                {
                    NadadorAInscribir = ConseguirMarcaDelEvento(NadadorAInscribir, setup, MarcasMinimasDelTorneo, evento, edad);
                }
                             

                if (atleta != null)
                {
                    NadadorAInscribir.entradayainscrita = db.Entradas.Any(x => x.MeetId == MeetId && x.Ath_no == atleta.Ath_no);
                }


                //Para poder hacer la búsqueda en resultados y mostrar el nombre de la prueba en la web
                switch (evento.Event_stroke)
                {
                    case "A":
                        NadadorAInscribir.estilo = "Libre";
                        stroke = "Free";
                        break;
                    case "B":
                        NadadorAInscribir.estilo = "Espalda";
                        stroke = "Back";
                        break;
                    case "C":
                        NadadorAInscribir.estilo = "Pecho";
                        stroke = "Breast";
                        break;
                    case "D":
                        NadadorAInscribir.estilo = "Mariposa";
                        stroke = "Fly";
                        break;
                    case "E":
                        NadadorAInscribir.estilo = "Combinado";
                        stroke = "IM";
                        break;
                }

                // Para buscar las marcas de este evento
                string distancia = evento.Event_dist.ToString();

                NadadorAInscribir.MMCortaString = ConvertirAMinutos(NadadorAInscribir.MMCorta);
                NadadorAInscribir.MMLargaString = ConvertirAMinutos(NadadorAInscribir.MMLarga);

                RESULTS resultadoenlarga = resultados
                       .Where(x => x.DISTANCE == distancia && x.STROKE == stroke && x.COURSE == "L")
                       .OrderBy(x => x.SCORE).FirstOrDefault();
                RESULTS resultadoencorta = resultados
                       .Where(x => x.DISTANCE == distancia && x.STROKE == stroke && x.COURSE == "S")
                       .OrderBy(x => x.SCORE).FirstOrDefault();


                // Ver si cumple la marca mínima, primero la de la competencia, usando LSY y SLY
                string CursoPiscina = setup.Torneo.course_order;
                NadadorAInscribir = BuscarMejorTiempoDelEvento(NadadorAInscribir, setup, resultadoenlarga, resultadoencorta, evento);
                //NadadorAInscribir = GetMejortiempoDeLaPrueba(NadadorAInscribir, resultadoenlarga, resultadoencorta, CursoPiscina, setup);
                if (NadadorAInscribir.Cumple)
                {
                    pruebasConMarca += 1;
                }
                VM.listaDeEventos.Add(NadadorAInscribir);
            }

            //7 .- ahora veo las sesiones y datos para mostrarlos al final de la página
            List<Sesion> sesiones = db.Sesion.Where(x => x.MeetId == MeetId).ToList();
            for (int i = 0; i < sesiones.Count(); i++)
            {
                SesionViewModel sesionVM = new SesionViewModel
                {
                    Maximopermitido = sesiones[i].Sess_entrymaxind ?? 0,
                    Sesion = i + 1,
                    Inscritos = 0,
                    Pendiente = sesiones[i].Sess_entrymaxind ?? 0,
                };
                VM.Sesiones.Add(sesionVM);
            }


            //8 .- ver las pruebas inscritas de este deportista,  busco si está inscrito,
            // luego veo por cada evento si la prueba ya está inscrita y la sumo 1 a la inscripción de la sesión

            if (VM.YaestaInscrito)
            {
                PruebasYaInscritas = db.Entradas.Where(x => x.MeetId == MeetId && x.Ath_no == atleta.Ath_no).Select(x => x.Event_ptr ?? 0).ToList();
                if (PruebasYaInscritas.Count() > 0)
                {
                    foreach (var numeroDeEvento in VM.listaDeEventos)
                    {
                        if (PruebasYaInscritas.Any(x => x == numeroDeEvento.evento.Event_ptr))
                        {
                            numeroDeEvento.entradayainscrita = true;
                            int estasesion = numeroDeEvento.sesion;
                            SesionViewModel sesionVM = VM.Sesiones.Where(x => x.Sesion == estasesion).FirstOrDefault();
                            sesionVM.Inscritos += 1;
                            sesionVM.Pendiente -= 1;

                            if(!numeroDeEvento.Cumple)
                            {
                                VM.PruebasInscritasSinMarca += 1;
                            }                     
                            VM.PruebasInscritas += 1;

                        }
                        else
                        {
                            numeroDeEvento.entradayainscrita = false;
                        }
                    }
                }
            }

            //9.- aquí veo si tiene marca en esta prueba
            // Antes se permitía nadar una prueba sin marca, pero en caso que tuvieras una prueba con marca te permitían nadar 2 sin marca.
            // Ahora es más simple, si no tienes marcas no nadas.


            if (!setup.PermiteSinMarca)
            {
                if (pruebasConMarca > 0)
                {
                    VM.SinMarca = setup.SinMarca;
                }
                else
                {
                    VM.SinMarca = 0;
                }

            }

            ViewBag.setup = setup;
            return View(VM);
        }


        public ActionResult ListarPruebasParaElNadadorSemillero(int MeetId, int afiliadoId)
        {
            int annoActual = DateTime.Now.Year - 1; /*Para calcular la edad al año pasado*/

            SetupTorneo setup = db.SetupTorneo.Where(x => x.Torneo.Meetid == MeetId).FirstOrDefault();
            RESULTS resultado = new RESULTS();

            DateTime fecha = setup.Torneo.entry_deadline ?? DateTime.Now;
            DateTime haceunanno = setup.Torneo.EntryEligibility_date ?? DateTime.Now.AddMonths(-12).AddDays(-15);

            List<MarcasMinimas> MarcasMinimasDelTorneo = db.MarcasMinimas.Where(x => x.MeetId == MeetId).ToList();
            List<SessionItem> ListadoDeSessionItem = db.SessionItem.Where(x => x.Meetid == MeetId).ToList();

            List<int> PruebasYaInscritas = new List<int>();

            string stroke = "Free";
            //Hallo el tipo de piscina en el que se nadará

            int NumeroSesiones = setup.Torneo.Sesion.OrderByDescending(x => x.SessionId).Select(x => x.Sess_day).FirstOrDefault() ?? 1;

            int pruebasXtorneo = setup.pruebasXtorneo; //2 * NumeroSesiones;
            //if (pruebasXtorneo > 6)
            //{
            //    pruebasXtorneo = 6;
            //}
            int pruebasConMarca = 0;



            //Inicio de variable del modelo
            ListadoInscritoViewModel VM = new ListadoInscritoViewModel
            {
                afiliado = db.Inscripciones.Where(x => x.InscripcionId == afiliadoId).FirstOrDefault(),
                listaDeEventos = new List<ViewModels.Inscrito.InscritoViewModel>(),
                Sesiones = new List<SesionViewModel>(),
                PruebasTotales = pruebasXtorneo,
                Piscina = "",
                PruebasInscritasSinMarca = 0,
                SinMarca = 0,
                MeetId = MeetId,
            };



            if (setup.Torneo.Meet_course == 1)
            {
                VM.Piscina = "L";
            }
            else
            {
                VM.Piscina = "S";
            }


            //1 .- buscar al afiliado en la bd de inscripciones
            atletas atleta = db.atletas.Where(x => x.Reg_no == VM.afiliado.DNI).FirstOrDefault(); // en la BD de inscripciones
            if (atleta != null)
            {
                VM.YaestaInscrito = db.Entradas.Any(x => x.MeetId == MeetId && x.Ath_no == atleta.Ath_no);
            }
            else
            {
                VM.YaestaInscrito = false;

            }


            //2 .- Buscar los eventos que podría nadar el afiliado
            int edad = annoActual - VM.afiliado.Afiliado.Fecha_de_nacimiento.Year;
            List<Eventos> eventosDelNadador = db.Eventos.Where(x => x.MeetId == MeetId && x.Low_age <= edad && x.High_Age >= edad && x.Event_gender == VM.afiliado.Afiliado.Sexo && x.Ind_rel == "i").OrderBy(x => x.Event_no).ToList();

            foreach (Eventos evento in eventosDelNadador)
            {
                InscritoViewModel NadadorAInscribir = new InscritoViewModel
                {
                    evento = evento,
                    sesion = ListadoDeSessionItem.Where(x => x.Event_ptr == evento.Event_ptr).Select(x => x.Sess_ptr).FirstOrDefault() ?? 0,

                };

                if (atleta != null)
                {
                    NadadorAInscribir.entradayainscrita = db.Entradas.Any(x => x.MeetId == MeetId && x.Ath_no == atleta.Ath_no);
                }


                //Para poder hacer la búsqueda en resultados y mostrar el nombre de la prueba en la web
                switch (evento.Event_stroke)
                {
                    case "A":
                        NadadorAInscribir.estilo = "Libre";
                        stroke = "Free";
                        break;
                    case "B":
                        NadadorAInscribir.estilo = "Espalda";
                        stroke = "Back";
                        break;
                    case "C":
                        NadadorAInscribir.estilo = "Pecho";
                        stroke = "Breast";
                        break;
                    case "D":
                        NadadorAInscribir.estilo = "Mariposa";
                        stroke = "Fly";
                        break;
                    case "E":
                        NadadorAInscribir.estilo = "Combinado";
                        stroke = "IM";
                        break;
                }

                NadadorAInscribir.MMCortaString = ConvertirAMinutos(0);
                NadadorAInscribir.MMLargaString = ConvertirAMinutos(0);


                NadadorAInscribir.tiempo = "0:00.00";
                NadadorAInscribir.segundos = 0;
                NadadorAInscribir.torneo = "Sin torneo";
                NadadorAInscribir.PiscinaDelTiempo = "";
                NadadorAInscribir.Cumple = true;
                VM.listaDeEventos.Add(NadadorAInscribir);
            }

            //7 .- ahora veo las sesiones y datos para mostrarlos al final de la página
            List<Sesion> sesiones = db.Sesion.Where(x => x.MeetId == MeetId).ToList();
            for (int i = 0; i < sesiones.Count(); i++)
            {
                SesionViewModel sesionVM = new SesionViewModel
                {
                    Maximopermitido = sesiones[i].Sess_entrymaxind ?? 0,
                    Sesion = i + 1,
                    Inscritos = 0,
                    Pendiente = sesiones[i].Sess_entrymaxind ?? 0,
                };
                VM.Sesiones.Add(sesionVM);
            }


            //8 .- ver las pruebas inscritas de este deportista,  busco si está inscrito,
            // luego veo por cada evento si la prueba ya está inscrita y la sumo 1 a la inscripción de la sesión

            if (VM.YaestaInscrito)
            {
                PruebasYaInscritas = db.Entradas.Where(x => x.MeetId == MeetId && x.Ath_no == atleta.Ath_no).Select(x => x.Event_ptr ?? 0).ToList();
                if (PruebasYaInscritas.Count() > 0)
                {
                    foreach (var numeroDeEvento in VM.listaDeEventos)
                    {
                        if (PruebasYaInscritas.Any(x => x == numeroDeEvento.evento.Event_ptr))
                        {
                            numeroDeEvento.entradayainscrita = true;
                            int estasesion = numeroDeEvento.sesion;
                            SesionViewModel sesionVM = VM.Sesiones.Where(x => x.Sesion == estasesion).FirstOrDefault();
                            sesionVM.Inscritos += 1;
                            sesionVM.Pendiente -= 1;

                            if (numeroDeEvento.segundos == 0 && (numeroDeEvento.MMCorta > 0 || numeroDeEvento.MMLarga > 0))
                            {
                                VM.PruebasInscritasSinMarca += 1;
                            }
                            else if (!(numeroDeEvento.segundos < numeroDeEvento.MMCorta || numeroDeEvento.segundos < numeroDeEvento.MMLarga))
                            {
                                VM.PruebasInscritasSinMarca += 1;
                            }
                            VM.PruebasInscritas += 1;

                        }
                        else
                        {
                            numeroDeEvento.entradayainscrita = false;
                        }
                    }
                }
            }

            //9.- aquí veo si tiene marca en esta prueba
            // Antes se permitía nadar una prueba sin marca, pero en caso que tuvieras una prueba con marca te permitían nadar 2 sin marca.
            // Ahora es más simple, si no tienes marcas no nadas.


            if (pruebasConMarca > 0)
            {
                VM.SinMarca = 0;
            }
            else
            {
                VM.SinMarca = 0;
            }
            ViewBag.setup = setup;
            return View(VM);



        }


        public InscritoViewModel BuscarMejorTiempoDelEvento(InscritoViewModel NadadorAInscribir, SetupTorneo setup, RESULTS resultadoenlarga, RESULTS resultadoencorta, Eventos evento)
        {
            string CursoPiscina = setup.Torneo.course_order.Substring(0,1);
            string CumpleEnCurso = "";
            float RLarga = 0;
            float RCorta = 0;
            double factor = 0;
            
            if(resultadoenlarga!= null)
            {
                factor = resultadoenlarga.Pruebas.FactorF ??0;
            }
            else if (resultadoencorta != null)
            {
                factor = resultadoencorta.Pruebas.FactorM ?? 0;

            }
            

            // 1.- convertir los tiempos a segundos
            if (resultadoenlarga != null && resultadoenlarga.SCORE != null)
            {
                RLarga = ConvertirASegundos(resultadoenlarga.SCORE);
            }
            if (resultadoencorta != null && resultadoencorta.SCORE != null)
            {
                RCorta = ConvertirASegundos(resultadoencorta.SCORE);
            }

            // 2.- ver si cumple la marca dependiendo si busca marca mínima o marca máxima
            if (setup.UsaMarcaMaxima)
            {
                CumpleEnCurso = VerSiCumpleMarcaMaxima(NadadorAInscribir, setup, RLarga, RCorta, factor);
            }
            else if (!setup.UsaMarcaMaxima && setup.SinMarca == 0) //revisar que es sin marca Creo que esto es para ver si el torneo no tiene marca mínima ni máxima
            {
                CumpleEnCurso = VerSiCumpleMarcaMinima(NadadorAInscribir, setup, RLarga, RCorta, factor);
            }
            else if(setup.SinMarca !=0)  
            {

                CumpleEnCurso = VerSiCumpleSinMarca(NadadorAInscribir, setup, RLarga, RCorta, factor);
            }

            // 3.- Luego buscar el torneo donde hizo la marca
            if (CumpleEnCurso == "L")
            {
                NadadorAInscribir.torneo = resultadoenlarga.MEET1.MName;
                NadadorAInscribir.tiempo = resultadoenlarga.SCORE;
                NadadorAInscribir.segundos = ConvertirASegundos(NadadorAInscribir.tiempo);
                NadadorAInscribir.Cumple = true;
                NadadorAInscribir.PiscinaDelTiempo = "L";
            }
            else if (CumpleEnCurso == "S")
            {
                NadadorAInscribir.torneo = resultadoencorta.MEET1.MName;
                NadadorAInscribir.tiempo = resultadoencorta.SCORE;
                NadadorAInscribir.segundos = ConvertirASegundos(NadadorAInscribir.tiempo);
                NadadorAInscribir.Cumple = true;
                NadadorAInscribir.PiscinaDelTiempo = "S";
            }
            else
            {
                if(NadadorAInscribir.MejorCursoDePiscina =="L")
                {
                    NadadorAInscribir.torneo = resultadoenlarga.MEET1.MName;
                    NadadorAInscribir.tiempo = resultadoenlarga.SCORE;
                    NadadorAInscribir.segundos = ConvertirASegundos(NadadorAInscribir.tiempo);
                    NadadorAInscribir.Cumple = false;
                    NadadorAInscribir.PiscinaDelTiempo = "L";
                }
                else if (NadadorAInscribir.MejorCursoDePiscina == "S")
                {
                    NadadorAInscribir.torneo = resultadoencorta.MEET1.MName;
                    NadadorAInscribir.tiempo = resultadoencorta.SCORE;
                    NadadorAInscribir.segundos = ConvertirASegundos(NadadorAInscribir.tiempo);
                    NadadorAInscribir.Cumple = false;
                    NadadorAInscribir.PiscinaDelTiempo = "S";
                }
                else
                {
                    NadadorAInscribir.torneo = "Sin torneo";
                    NadadorAInscribir.tiempo = "0:00.00";
                    NadadorAInscribir.segundos = 0;
                    NadadorAInscribir.Cumple = false;
                }
              
                if(setup.SinMarca != 0)
                {
                    NadadorAInscribir.Cumple = true;
                }
            }
            return NadadorAInscribir;
        }


        public InscritoViewModel ConseguirMarcaDelEvento(InscritoViewModel NadadorAInscribir, SetupTorneo setup, List<MarcasMinimas> MarcasMinimasDelTorneo, Eventos evento, int edad)
        {
            float MML = 0;
            float MMC = 0;

            List<MarcasMinimas> Marcas = MarcasMinimasDelTorneo.
                Where(x => x.tag_dist == evento.Event_dist && x.tag_stroke == evento.Event_stroke && x.tag_course == "L" && x.low_age <= edad && x.high_Age >= edad && x.tag_gender == evento.Event_gender && x.MeetId == evento.MeetId)
               .OrderByDescending(x => x.tag_ptr)
               .ToList();

            if (Marcas.Count() > 0)
            {
                NadadorAInscribir.MMLarga = SeleccionarLaMejorMM(Marcas, edad);
            }
            else
            {
                NadadorAInscribir.MMLarga = Marcas[0].tag_time ?? 0;
            }
            Marcas = MarcasMinimasDelTorneo.
                Where(x => x.tag_dist == evento.Event_dist && x.tag_stroke == evento.Event_stroke && x.tag_course == "S" && x.low_age <= edad && x.high_Age >= edad && x.tag_gender == evento.Event_gender && x.MeetId == evento.MeetId)
               .OrderByDescending(x => x.tag_ptr)
               .ToList();

            if (Marcas.Count() > 0)
            {
                NadadorAInscribir.MMCorta = SeleccionarLaMejorMM(Marcas, edad);
            }
            return NadadorAInscribir;

        }


      


        public string VerSiCumpleMarcaMinima(InscritoViewModel NadadorAInscribir, SetupTorneo setup, float RLarga, float RCorta, double factor)
        {
            string CursoPiscina = setup.Torneo.course_order.Substring(0,1);
            bool cumplelarga = false;
            bool cumplecorta = false;


            if (RLarga < NadadorAInscribir.MMLarga && RLarga > 0)
            {
                cumplelarga = true;
            }
            if (RCorta < NadadorAInscribir.MMCorta && RCorta > 0)
            {
                cumplecorta = true;
            }

            if (CursoPiscina == "L")
            {
                RCorta = ConvertirLaMarcaEntrePiscinas(RCorta, factor, "S");
            }
            else
            {
                RLarga = ConvertirLaMarcaEntrePiscinas(RLarga, factor, CursoPiscina);
            }


            if (cumplelarga && cumplecorta) //Si se cumplen en corta y larga
            {
               

                if (RLarga < RCorta)
                {
                    return "L";
                }
                else
                {
                    return "S";
                }
            }
            else
            {
                if (cumplelarga) //Si solo cumple en larga
                {
                    return "L";
                }
                else if (cumplecorta) // si solo cumple en corta
                {
                    return "S";
                }

                if ((RLarga < RCorta && RLarga >0) || (RLarga > 0 && RCorta == 0)) // si no cumple ninguna de las dos al menos trataré de colocar el mejor curso donde buscaré su tiempo
                {
                    NadadorAInscribir.MejorCursoDePiscina = "L";
                }
                else if((RCorta < RLarga && RCorta > 0) || (RCorta>0 && RLarga ==0))
                {
                    NadadorAInscribir.MejorCursoDePiscina = "S";
                }
                return "";
            }

        }
        public string VerSiCumpleMarcaMaxima(InscritoViewModel NadadorAInscribir, SetupTorneo setup, float RLarga, float RCorta, double factor)
        {
            string CursoPiscina = setup.Torneo.course_order;
            bool cumplelarga = false;
            bool cumplecorta = false;

            if (RLarga > NadadorAInscribir.MMLarga)
            {
                cumplelarga = true;
            }
            if (RCorta > NadadorAInscribir.MMLarga)
            {
                cumplecorta = true;
            }
            if (cumplelarga && cumplecorta)
            {
                if (CursoPiscina == "L")
                {
                    RCorta = ConvertirLaMarcaEntrePiscinas(RCorta, factor, CursoPiscina);
                }
                else
                {
                    RLarga = ConvertirLaMarcaEntrePiscinas(RLarga, factor, CursoPiscina);
                }
                if (RLarga < RCorta)
                {
                    return "L";
                }
                else
                {
                    return "S";
                }
            }
            else
            {
                if (cumplelarga)
                {
                    return "L";
                }
                else if(cumplecorta)
                {
                    return "S";
                }

                if (RLarga < RCorta) // si no cumple ninguna de las dos al menos trataré de colocar el mejor curso donde buscaré su tiempo
                {
                    NadadorAInscribir.MejorCursoDePiscina = "L";
                }
                else if (RCorta < RLarga)
                {
                    NadadorAInscribir.MejorCursoDePiscina = "S";
                }
                return "";
            }

        }

        public string VerSiCumpleSinMarca(InscritoViewModel NadadorAInscribir, SetupTorneo setup, float RLarga, float RCorta, double factor)
        {
            string CursoPiscina = setup.Torneo.course_order.Substring(0,1);

           
                if (CursoPiscina == "L")
                {
                    RCorta = ConvertirLaMarcaEntrePiscinas(RCorta, factor, CursoPiscina);
                }
                else
                {
                    RLarga = ConvertirLaMarcaEntrePiscinas(RLarga, factor, CursoPiscina);
                }
                if ((RLarga < RCorta && RLarga>0) || (RLarga > 0 && RCorta == 0))
            {
                    return "L";
                }
                else if ((RLarga > RCorta && RCorta >0)||(RCorta>0 && RLarga==0))
            {
                    return "S";
                }

            return "";
        }

        public string VerSiEsDebutante(InscritoViewModel NadadorAInscribir, SetupTorneo setup, float RLarga, float RCorta)
        {

            return " ";
        }

        public float SeleccionarLaMejorMM(List<MarcasMinimas> Marcas, int edad)
        {
            int contador = 0;
            Dictionary<int, int> diferencia = new Dictionary<int, int>();
            foreach (var item in Marcas)
            {
                diferencia.Add(contador, (item.high_Age ?? 0) + (item.low_age ?? 0));
                contador += 1;

            }
            int menordiferencia = diferencia.Min(x => x.Value);
            int posicion = diferencia.FirstOrDefault(x => x.Value == menordiferencia).Key;
            float mejorMM = Marcas[posicion].tag_time ?? 0;
            return mejorMM;
        }



        public ActionResult ListarPruebasParaElNadadorDivision2(int MeetId, int afiliadoId)
        {
            int annoActual = DateTime.Now.Year - 1; /*Para calcular la edad al año pasado*/

            SetupTorneo setup = db.SetupTorneo.Where(x => x.Torneo.Meetid == MeetId).FirstOrDefault();
            RESULTS resultado = new RESULTS();

            DateTime fecha = setup.Torneo.entry_deadline ?? DateTime.Now;
            DateTime haceunanno = setup.Torneo.EntryEligibility_date ?? DateTime.Now.AddMonths(-12).AddDays(-15);

            List<MarcasMinimas> MarcasMinimasDelTorneo = db.MarcasMinimas.Where(x => x.MeetId == MeetId).ToList();
            List<SessionItem> ListadoDeSessionItem = db.SessionItem.Where(x => x.Meetid == MeetId).ToList();

            List<int> PruebasYaInscritas = new List<int>();

            string stroke = "Free";
            //Hallo el tipo de piscina en el que se nadará

            int NumeroSesiones = setup.Torneo.Sesion.OrderByDescending(x => x.SessionId).Select(x => x.Sess_day).FirstOrDefault() ?? 1;

            int pruebasXtorneo = setup.pruebasXtorneo; //2 * NumeroSesiones;
            //if (pruebasXtorneo > 6)
            //{
            //    pruebasXtorneo = 6;
            //}
            int pruebasConMarca = 0;



            //Inicio de variable del modelo
            ListadoInscritoViewModel VM = new ListadoInscritoViewModel
            {
                afiliado = db.Inscripciones.Where(x => x.InscripcionId == afiliadoId).FirstOrDefault(),
                listaDeEventos = new List<ViewModels.Inscrito.InscritoViewModel>(),
                Sesiones = new List<SesionViewModel>(),
                PruebasTotales = pruebasXtorneo,
                Piscina = "",
                PruebasInscritasSinMarca = 0,
                SinMarca = 0,
                MeetId = MeetId,

            };
            //Todos los resultados del nadador en un año
            List<RESULTS> resultados = db.RESULTS
                       .Where(x => x.Athlete1.ID_NO == VM.afiliado.DNI && x.MEET1.Start > haceunanno && x.SCORE != "" && x.NT == 0)
                       .ToList();

            if (setup.Torneo.Meet_course == 1)
            {
                VM.Piscina = "L";
            }
            else
            {
                VM.Piscina = "S";
            }


            //1 .- buscar al afiliado en la bd de inscripciones
            atletas atleta = db.atletas.Where(x => x.Reg_no == VM.afiliado.DNI).FirstOrDefault(); // en la BD de inscripciones
            if (atleta != null)
            {
                VM.YaestaInscrito = db.Entradas.Any(x => x.MeetId == MeetId && x.Ath_no == atleta.Ath_no);
            }
            else
            {
                VM.YaestaInscrito = false;

            }


            //2 .- Buscar los eventos que podría nadar el afiliado
            int edad = annoActual - VM.afiliado.Afiliado.Fecha_de_nacimiento.Year;
            List<Eventos> eventosDelNadador = db.Eventos.Where(x => x.MeetId == MeetId && x.Low_age <= edad && x.High_Age >= edad && x.Event_gender == VM.afiliado.Afiliado.Sexo && x.Ind_rel == "i").OrderBy(x => x.Event_no).ToList();

            foreach (Eventos evento in eventosDelNadador)
            {
                InscritoViewModel NadadorAInscribir = new InscritoViewModel
                {
                    evento = evento,
                    sesion = ListadoDeSessionItem.Where(x => x.Event_ptr == evento.Event_ptr).Select(x => x.Sess_ptr).FirstOrDefault() ?? 0,

                    MMCorta = MarcasMinimasDelTorneo.
                    Where(x => x.tag_dist == evento.Event_dist && x.tag_stroke == evento.Event_stroke && x.tag_course == "S" && x.low_age <= edad && x.high_Age >= edad && x.tag_gender == evento.Event_gender)
                    .OrderByDescending(x => x.tag_ptr)
                    .Select(x => x.tag_time).FirstOrDefault() ?? 0,

                    MMLarga = MarcasMinimasDelTorneo
                    .Where(x => x.tag_dist == evento.Event_dist && x.tag_stroke == evento.Event_stroke && x.tag_course == "L" && x.low_age <= edad && x.high_Age >= edad && x.tag_gender == evento.Event_gender)
                    .OrderByDescending(x => x.tag_ptr)
                    .Select(x => x.tag_time).FirstOrDefault() ?? 0,

                };

                if (atleta != null)
                {
                    NadadorAInscribir.entradayainscrita = db.Entradas.Any(x => x.MeetId == MeetId && x.Ath_no == atleta.Ath_no);
                }


                //Para poder hacer la búsqueda en resultados y mostrar el nombre de la prueba en la web
                switch (evento.Event_stroke)
                {
                    case "A":
                        NadadorAInscribir.estilo = "Libre";
                        stroke = "Free";
                        break;
                    case "B":
                        NadadorAInscribir.estilo = "Espalda";
                        stroke = "Back";
                        break;
                    case "C":
                        NadadorAInscribir.estilo = "Pecho";
                        stroke = "Breast";
                        break;
                    case "D":
                        NadadorAInscribir.estilo = "Mariposa";
                        stroke = "Fly";
                        break;
                    case "E":
                        NadadorAInscribir.estilo = "Combinado";
                        stroke = "IM";
                        break;
                }

                // Para buscar las marcas de este evento
                string distancia = evento.Event_dist.ToString();

                NadadorAInscribir.MMCortaString = ConvertirAMinutos(NadadorAInscribir.MMCorta);
                NadadorAInscribir.MMLargaString = ConvertirAMinutos(NadadorAInscribir.MMLarga);

                RESULTS resultadoenlarga = resultados
                       .Where(x => x.DISTANCE == distancia && x.STROKE == stroke && x.COURSE == "L")
                       .OrderBy(x => x.SCORE).FirstOrDefault();
                RESULTS resultadoencorta = resultados
                       .Where(x => x.DISTANCE == distancia && x.STROKE == stroke && x.COURSE == "S")
                       .OrderBy(x => x.SCORE).FirstOrDefault();

                // Ver si cumple la marca mínima, primero la de la competencia, usando LSY y SLY
                string CursoPiscina = setup.Torneo.course_order;
                for (int i = 0; i < 2; i++)
                {
                    float MM = 0;
                    string CursoABuscar = CursoPiscina.Substring(i, 1);
                    if (CursoABuscar == "L")
                    {
                        resultado = resultadoenlarga;
                        MM = NadadorAInscribir.MMLarga;
                    }
                    else
                    {
                        resultado = resultadoencorta;
                        MM = NadadorAInscribir.MMCorta;
                    }

                    if (resultado == null)
                    {
                        NadadorAInscribir.Cumple = true;
                    }
                    else
                    {
                        NadadorAInscribir.Cumple = VerSiCumpleConLaMarcaMaxima(NadadorAInscribir, resultadoenlarga, resultadoencorta);
                    }

                    if (!NadadorAInscribir.Cumple)
                    {
                        NadadorAInscribir.tiempo = resultado.SCORE;
                        NadadorAInscribir.segundos = ConvertirASegundos(NadadorAInscribir.tiempo);
                        NadadorAInscribir.torneo = resultado.MEET1.MName;
                        if (resultado.MEET1.MName.Length > 20)
                        {
                            NadadorAInscribir.torneo = resultado.MEET1.MName.Substring(0, 20);
                        }
                        NadadorAInscribir.PiscinaDelTiempo = resultado.COURSE;
                        pruebasConMarca += 1;
                        break;
                    }
                }
                if (NadadorAInscribir.Cumple)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        resultado = null;
                        string CursoABuscar = CursoPiscina.Substring(i, 1);
                        if (CursoABuscar == "L" && resultadoenlarga != null)
                        {
                            resultado = resultadoenlarga;
                            break;
                        }
                        if (CursoABuscar == "S" && resultadoencorta != null)
                        {
                            resultado = resultadoencorta;
                            break;
                        }
                    }
                }

                if (NadadorAInscribir.Cumple)
                {
                    if (resultadoenlarga == null && resultadoencorta == null)
                    {
                        NadadorAInscribir.tiempo = "0.00";
                        NadadorAInscribir.segundos = 0;
                        NadadorAInscribir.torneo = "Sin torneo";
                        NadadorAInscribir.PiscinaDelTiempo = "";
                    }
                    else
                    {
                        NadadorAInscribir.tiempo = resultado.SCORE;
                        NadadorAInscribir.segundos = ConvertirASegundos(NadadorAInscribir.tiempo);
                        NadadorAInscribir.torneo = resultado.MEET1.MName;
                        if (resultado.MEET1.MName.Length > 20)
                        {
                            NadadorAInscribir.torneo = resultado.MEET1.MName.Substring(0, 20);
                        }
                        NadadorAInscribir.PiscinaDelTiempo = resultado.COURSE;
                        NadadorAInscribir.Cumple = true;
                    }

                }

                if (NadadorAInscribir.MMCorta == 0 && NadadorAInscribir.MMLarga == 0)
                {
                    NadadorAInscribir.Cumple = true;
                }
                VM.listaDeEventos.Add(NadadorAInscribir);
            }

            //7 .- ahora veo las sesiones y datos para mostrarlos al final de la página
            List<Sesion> sesiones = db.Sesion.Where(x => x.MeetId == MeetId).ToList();
            for (int i = 0; i < sesiones.Count(); i++)
            {
                SesionViewModel sesionVM = new SesionViewModel
                {
                    Maximopermitido = sesiones[i].Sess_entrymaxind ?? 0,
                    Sesion = i + 1,
                    Inscritos = 0,
                    Pendiente = sesiones[i].Sess_entrymaxind ?? 0,
                };
                VM.Sesiones.Add(sesionVM);
            }


            //8 .- ver las pruebas inscritas de este deportista,  busco si está inscrito,
            // luego veo por cada evento si la prueba ya está inscrita y la sumo 1 a la inscripción de la sesión

            if (VM.YaestaInscrito)
            {
                PruebasYaInscritas = db.Entradas.Where(x => x.MeetId == MeetId && x.Ath_no == atleta.Ath_no).Select(x => x.Event_ptr ?? 0).ToList();
                if (PruebasYaInscritas.Count() > 0)
                {
                    foreach (var numeroDeEvento in VM.listaDeEventos)
                    {
                        if (PruebasYaInscritas.Any(x => x == numeroDeEvento.evento.Event_ptr))
                        {
                            numeroDeEvento.entradayainscrita = true;
                            int estasesion = numeroDeEvento.sesion;
                            SesionViewModel sesionVM = VM.Sesiones.Where(x => x.Sesion == estasesion).FirstOrDefault();
                            sesionVM.Inscritos += 1;
                            sesionVM.Pendiente -= 1;

                            if (numeroDeEvento.segundos == 0 && (numeroDeEvento.MMCorta > 0 || numeroDeEvento.MMLarga > 0))
                            {
                                VM.PruebasInscritasSinMarca += 1;
                            }
                            else if (!(numeroDeEvento.segundos < numeroDeEvento.MMCorta || numeroDeEvento.segundos < numeroDeEvento.MMLarga))
                            {
                                VM.PruebasInscritasSinMarca += 1;
                            }
                            VM.PruebasInscritas += 1;

                        }
                        else
                        {
                            numeroDeEvento.entradayainscrita = false;
                        }
                    }
                }
            }

            //9.- aquí veo si tiene marca en esta prueba
            // Antes se permitía nadar una prueba sin marca, pero en caso que tuvieras una prueba con marca te permitían nadar 2 sin marca.
            // Ahora es más simple, si no tienes marcas no nadas.


            if (pruebasConMarca > 0)
            {
                VM.SinMarca = 0;
            }
            else
            {
                VM.SinMarca = 0;
            }
            ViewBag.setup = setup;
            return View(VM);
        }




        public ActionResult ListarPruebasParaRetirar(int MeetId, int afiliadoId)
        {
            int annoActual = DateTime.Now.Year - 1; /*Para calcular la edad al año pasado*/
            Torneo torneo = db.Torneo.Find(MeetId);
            RESULTS resultado = new RESULTS();

            DateTime fecha = torneo.entry_deadline ?? DateTime.Now;
            DateTime haceunanno = fecha.AddDays(-15).AddYears(-1);

            List<MarcasMinimas> MarcasMinimasDelTorneo = db.MarcasMinimas.Where(x => x.MeetId == MeetId).ToList();
            List<SessionItem> ListadoDeSessionItem = db.SessionItem.Where(x => x.Meetid == MeetId).ToList();

            List<int> PruebasYaInscritas = new List<int>();

            string stroke = "Free";
            //Hallo el tipo de piscina en el que se nadará

            int NumeroSesiones = torneo.Sesion.OrderByDescending(x => x.SessionId).Select(x => x.Sess_day).FirstOrDefault() ?? 1;

            int pruebasXtorneo = 2 * NumeroSesiones;
            if (pruebasXtorneo > 6)
            {
                pruebasXtorneo = 6;
            }
            int pruebasConMarca = 0;



            //Inicio de variable del modelo
            ListadoInscritoViewModel VM = new ListadoInscritoViewModel
            {
                afiliado = db.Inscripciones.Where(x => x.InscripcionId == afiliadoId).FirstOrDefault(),
                listaDeEventos = new List<ViewModels.Inscrito.InscritoViewModel>(),
                Sesiones = new List<SesionViewModel>(),
                PruebasTotales = pruebasXtorneo,
                Piscina = "",
                PruebasInscritasSinMarca = 0,
                SinMarca = 0,
                MeetId = MeetId,

            };
            //Todos los resultados del nadador en un año
            List<RESULTS> resultados = db.RESULTS
                       .Where(x => x.Athlete1.ID_NO == VM.afiliado.DNI && x.MEET1.Start > haceunanno && x.SCORE != "")
                       .ToList();

            if (torneo.Meet_course == 1)
            {
                VM.Piscina = "L";
            }
            else
            {
                VM.Piscina = "S";
            }


            //1 .- buscar al afiliado en la bd de inscripciones
            atletas atleta = db.atletas.Where(x => x.Reg_no == VM.afiliado.DNI).FirstOrDefault(); // en la BD de inscripciones
            if (atleta != null)
            {
                VM.YaestaInscrito = db.Entradas.Any(x => x.MeetId == MeetId && x.Ath_no == atleta.Ath_no);
            }
            else
            {
                VM.YaestaInscrito = false;

            }
            //2.- Buscar los eventos en que se ha inscrito el afiliado

            List<Entradas> eventosInscritos = db.Entradas.Where(x => x.MeetId == MeetId && x.Ath_no == atleta.Ath_no).ToList();

            //2 .- Buscar los eventos que podría nadar el afiliado
            int edad = annoActual - VM.afiliado.Afiliado.Fecha_de_nacimiento.Year;
            List<Eventos> eventosDelNadador = db.Eventos.Where(x => x.MeetId == MeetId && x.Low_age <= edad && x.High_Age >= edad && x.Event_gender == VM.afiliado.Afiliado.Sexo && x.Ind_rel == "i").ToList();

            foreach (Eventos evento in eventosDelNadador)
            {
                InscritoViewModel NadadorAInscribir = new InscritoViewModel
                {
                    evento = evento,
                    sesion = ListadoDeSessionItem.Where(x => x.Event_ptr == evento.Event_ptr).Select(x => x.Sess_ptr).FirstOrDefault() ?? 0,

                    MMCorta = MarcasMinimasDelTorneo.
                    Where(x => x.tag_dist == evento.Event_dist && x.tag_stroke == evento.Event_stroke && x.tag_course == "S" && x.low_age <= edad && x.high_Age >= edad && x.tag_gender == evento.Event_gender)
                    .OrderByDescending(x => x.tag_ptr)
                    .Select(x => x.tag_time).FirstOrDefault() ?? 0,

                    MMLarga = MarcasMinimasDelTorneo
                    .Where(x => x.tag_dist == evento.Event_dist && x.tag_stroke == evento.Event_stroke && x.tag_course == "L" && x.low_age <= edad && x.high_Age >= edad && x.tag_gender == evento.Event_gender)
                    .OrderByDescending(x => x.tag_ptr)
                    .Select(x => x.tag_time).FirstOrDefault() ?? 0,

                };

                if (atleta != null)
                {
                    NadadorAInscribir.entradayainscrita = db.Entradas.Any(x => x.MeetId == MeetId && x.Ath_no == atleta.Ath_no);
                }


                //Para poder hacer la búsqueda en resultados y mostrar el nombre de la prueba en la web
                switch (evento.Event_stroke)
                {
                    case "A":
                        NadadorAInscribir.estilo = "Libre";
                        stroke = "Free";
                        break;
                    case "B":
                        NadadorAInscribir.estilo = "Espalda";
                        stroke = "Back";
                        break;
                    case "C":
                        NadadorAInscribir.estilo = "Pecho";
                        stroke = "Breast";
                        break;
                    case "D":
                        NadadorAInscribir.estilo = "Mariposa";
                        stroke = "Fly";
                        break;
                    case "E":
                        NadadorAInscribir.estilo = "Combinado";
                        stroke = "IM";
                        break;
                }

                // Para buscar las marcas de este evento
                string distancia = evento.Event_dist.ToString();

                NadadorAInscribir.MMCortaString = ConvertirAMinutos(NadadorAInscribir.MMCorta);
                NadadorAInscribir.MMLargaString = ConvertirAMinutos(NadadorAInscribir.MMLarga);

                RESULTS resultadoenlarga = resultados
                       .Where(x => x.DISTANCE == distancia && x.STROKE == stroke && x.COURSE == "L")
                       .OrderBy(x => x.SCORE).FirstOrDefault();
                RESULTS resultadoencorta = resultados
                       .Where(x => x.DISTANCE == distancia && x.STROKE == stroke && x.COURSE == "S")
                       .OrderBy(x => x.SCORE).FirstOrDefault();

                // Ver si cumple la marca mínima, primero la de la competencia, usando LSY y SLY
                string CursoPiscina = torneo.course_order;
                for (int i = 0; i < 2; i++)
                {
                    float MM = 0;
                    string CursoABuscar = CursoPiscina.Substring(i, 1);
                    if (CursoABuscar == "L")
                    {
                        resultado = resultadoenlarga;
                        MM = NadadorAInscribir.MMLarga;
                    }
                    else
                    {
                        resultado = resultadoencorta;
                        MM = NadadorAInscribir.MMCorta;
                    }

                    if (resultado != null)
                    {
                        NadadorAInscribir.Cumple = VerSiCumpleConLaMarca(CursoABuscar, resultado, MM);
                    }

                    if (NadadorAInscribir.Cumple)
                    {
                        NadadorAInscribir.tiempo = resultado.SCORE;
                        NadadorAInscribir.segundos = ConvertirASegundos(NadadorAInscribir.tiempo);
                        NadadorAInscribir.torneo = resultado.MEET1.MName;
                        if (resultado.MEET1.MName.Length > 20)
                        {
                            NadadorAInscribir.torneo = resultado.MEET1.MName.Substring(0, 20);
                        }
                        NadadorAInscribir.PiscinaDelTiempo = resultado.COURSE;
                        pruebasConMarca += 1;
                        break;
                    }
                }
                if (!NadadorAInscribir.Cumple)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        resultado = null;
                        string CursoABuscar = CursoPiscina.Substring(i, 1);
                        if (CursoABuscar == "L" && resultadoenlarga != null)
                        {
                            resultado = resultadoenlarga;
                            break;
                        }
                        if (CursoABuscar == "S" && resultadoencorta != null)
                        {
                            resultado = resultadoencorta;
                            break;
                        }
                    }
                }

                if (!NadadorAInscribir.Cumple)
                {
                    if (resultadoenlarga == null && resultadoencorta == null)
                    {
                        NadadorAInscribir.tiempo = "0.00";
                        NadadorAInscribir.segundos = 0;
                        NadadorAInscribir.torneo = "Sin torneo";
                        NadadorAInscribir.PiscinaDelTiempo = "";
                    }
                    else
                    {

                        NadadorAInscribir.tiempo = resultado.SCORE;
                        NadadorAInscribir.segundos = ConvertirASegundos(NadadorAInscribir.tiempo);
                        NadadorAInscribir.torneo = resultado.MEET1.MName;
                        if (resultado.MEET1.MName.Length > 20)
                        {
                            NadadorAInscribir.torneo = resultado.MEET1.MName.Substring(0, 20);
                        }
                        NadadorAInscribir.PiscinaDelTiempo = resultado.COURSE;
                        NadadorAInscribir.Cumple = false;

                    }

                }

                if (NadadorAInscribir.MMCorta == 0 && NadadorAInscribir.MMLarga == 0)
                {
                    NadadorAInscribir.Cumple = true;
                }
                VM.listaDeEventos.Add(NadadorAInscribir);
            }

            //7 .- ahora veo las sesiones y datos para mostrarlos al final de la página
            List<Sesion> sesiones = db.Sesion.Where(x => x.MeetId == MeetId).ToList();
            for (int i = 0; i < sesiones.Count(); i++)
            {
                SesionViewModel sesionVM = new SesionViewModel
                {
                    Maximopermitido = sesiones[i].Sess_entrymaxind ?? 0,
                    Sesion = i + 1,
                    Inscritos = 0,
                    Pendiente = sesiones[i].Sess_entrymaxind ?? 0,
                };
                VM.Sesiones.Add(sesionVM);
            }


            //8 .- ver las pruebas inscritas de este deportista,  busco si está inscrito,
            // luego veo por cada evento si la prueba ya está inscrita y la sumo 1 a la inscripción de la sesión

            if (VM.YaestaInscrito)
            {
                PruebasYaInscritas = db.Entradas.Where(x => x.MeetId == MeetId && x.Ath_no == atleta.Ath_no).Select(x => x.Event_ptr ?? 0).ToList();
                if (PruebasYaInscritas.Count() > 0)
                {
                    foreach (var numeroDeEvento in VM.listaDeEventos)
                    {
                        if (PruebasYaInscritas.Any(x => x == numeroDeEvento.evento.Event_ptr))
                        {
                            numeroDeEvento.entradayainscrita = true;
                            int estasesion = numeroDeEvento.sesion;
                            SesionViewModel sesionVM = VM.Sesiones.Where(x => x.Sesion == estasesion).FirstOrDefault();
                            sesionVM.Inscritos += 1;
                            sesionVM.Pendiente -= 1;

                            if (numeroDeEvento.segundos == 0 && (numeroDeEvento.MMCorta > 0 || numeroDeEvento.MMLarga > 0))
                            {
                                VM.PruebasInscritasSinMarca += 1;
                            }
                            else if (!(numeroDeEvento.segundos < numeroDeEvento.MMCorta || numeroDeEvento.segundos < numeroDeEvento.MMLarga))
                            {
                                VM.PruebasInscritasSinMarca += 1;
                            }
                            VM.PruebasInscritas += 1;

                        }
                        else
                        {
                            numeroDeEvento.entradayainscrita = false;
                        }
                    }
                }
            }

            //9.- aquí veo si tiene marca en esta prueba
            // Antes se permitía nadar una prueba sin marca, pero en caso que tuvieras una prueba con marca te permitían nadar 2 sin marca.
            // Ahora es más simple, si no tienes marcas no nadas.


            if (pruebasConMarca > 0)
            {
                VM.SinMarca = 0;
            }
            else
            {
                VM.SinMarca = 0;
            }
            ViewBag.pruebasXsesion = 4;
            ViewBag.pruebasXtorneo = 16;
            ViewBag.torneo = torneo.Meet_name1;
            return View(VM);



        }

        public InscritoViewModel GetMejortiempoDeLaPrueba(InscritoViewModel NadadorAInscribir, RESULTS resultadoenlarga, RESULTS resultadoencorta, string curso, SetupTorneo setup)
        {
            // Ver si cumple la marca mínima, primero la de la competencia, usando LSY y SLY
            RESULTS resultado = new RESULTS();
            string CursoPiscina = setup.Torneo.course_order;
            string CursoABuscar = "L";

            for (int i = 0; i < 2; i++)
            {
                float MM = 0;
                CursoABuscar = CursoPiscina.Substring(i, 1);
                if (CursoABuscar == "L")
                {
                    resultado = resultadoenlarga;
                    MM = NadadorAInscribir.MMLarga;
                }
                else
                {
                    resultado = resultadoencorta;
                    MM = NadadorAInscribir.MMCorta;
                }

                // aquí vemos si cumple dependiendo del tipo de torneo
                //Si es un torneo con marcas mínimas debe de tener marcas mejores, si es con marcas máximas no debe de tener mejores marca
                //si es un torneo tipo semillero o copa no debe de tener marcas minimas.

                if (setup.PermiteSinMarca)
                {
                    NadadorAInscribir.Cumple = true;
                }
                else if (setup.UsaMarcaMaxima)
                {
                    NadadorAInscribir.Cumple = VerSiCumpleConLaMarcaMaxima(NadadorAInscribir, resultadoenlarga, resultadoencorta);
                }

                else
                {
                    NadadorAInscribir.Cumple = VerSiCumpleConLaMarca(CursoABuscar, resultado, MM);
                }

                if (NadadorAInscribir.Cumple)
                { break; }

            }



            if ((!NadadorAInscribir.Cumple || setup.PermiteSinMarca) && (!setup.UsaMarcaMaxima))
            {
                for (int i = 0; i < 2; i++)
                {
                    resultado = null;
                    CursoABuscar = CursoPiscina.Substring(i, 1);
                    if (CursoABuscar == "L" && resultadoenlarga != null)
                    {
                        resultado = resultadoenlarga;
                        break;
                    }
                    if (CursoABuscar == "S" && resultadoencorta != null)
                    {
                        resultado = resultadoencorta;
                        break;
                    }
                }
            }
            if ((!NadadorAInscribir.Cumple || setup.PermiteSinMarca) && (setup.UsaMarcaMaxima))
            {
                for (int i = 0; i < 2; i++)
                {
                    resultado = null;
                    CursoABuscar = CursoPiscina.Substring(i, 1);
                    if (CursoABuscar == "L" && resultadoenlarga != null && NadadorAInscribir.PiscinaDelTiempo == "L")
                    {
                        resultado = resultadoenlarga;
                        break;
                    }
                    if (CursoABuscar == "S" && resultadoencorta != null && NadadorAInscribir.PiscinaDelTiempo == "C")
                    {
                        resultado = resultadoencorta;
                        break;
                    }
                }
            }


            if (!NadadorAInscribir.Cumple)
            {
                if (resultadoenlarga == null && resultadoencorta == null)
                {
                    NadadorAInscribir.tiempo = "0.00";
                    NadadorAInscribir.segundos = 0;
                    NadadorAInscribir.torneo = "Sin torneo";
                    NadadorAInscribir.PiscinaDelTiempo = "";
                }
                else
                {

                    NadadorAInscribir.tiempo = resultado.SCORE;
                    NadadorAInscribir.segundos = ConvertirASegundos(NadadorAInscribir.tiempo);
                    NadadorAInscribir.torneo = resultado.MEET1.MName;
                    if (resultado.MEET1.MName.Length > 20)
                    {
                        NadadorAInscribir.torneo = resultado.MEET1.MName.Substring(0, 20);
                    }
                    NadadorAInscribir.PiscinaDelTiempo = resultado.COURSE;
                    NadadorAInscribir.Cumple = false;

                }

            }
            if (resultado == null)
            {
                resultado = new RESULTS
                {
                    SCORE = "0.00",
                    COURSE = "-",
                    MEET1 = new MEET
                    {
                        MName = "Sin participación",
                    },
                };
            }
            if (setup.SinMarca == 1)
            {
                NadadorAInscribir = BuscarTiempoDeTorneoSinMarca(NadadorAInscribir, resultadoenlarga, resultadoencorta, CursoABuscar);
                if (NadadorAInscribir.torneo.Length > 20)
                {
                    NadadorAInscribir.torneo = NadadorAInscribir.torneo.Substring(0, 20);
                }
            }
            else
            {
                NadadorAInscribir.tiempo = resultado.SCORE;
                NadadorAInscribir.segundos = ConvertirASegundos(NadadorAInscribir.tiempo);
                NadadorAInscribir.torneo = resultado.MEET1.MName;
                if (resultado.MEET1.MName.Length > 20)
                {
                    NadadorAInscribir.torneo = resultado.MEET1.MName.Substring(0, 20);
                }
                NadadorAInscribir.PiscinaDelTiempo = resultado.COURSE;
            }


            return NadadorAInscribir;
        }

        [HttpGet]
        public JsonResult GrabarPruebasParaElNadador(string listado, string MeetString, string InscripcionId, string Piscina, string YaestaInscritoString)
        {
            Usuario usuario = Session["Usuario"] as Usuario;
            if (usuario == null)
            {
                return Json("La sesión se ha cerrado, no se puede grabar los cambios, por favor vaya a Login e ingrese sus credenciales", JsonRequestBehavior.AllowGet);
            }
            int MeetId = Int32.Parse(MeetString);
            SetupTorneo setup = db.SetupTorneo.FirstOrDefault(x => x.Meetid == MeetId);

            Boolean YaestaInscrito = YaestaInscritoString.ToUpper() == "TRUE";
            int id = Int32.Parse(InscripcionId);
            //Por cada inscripcion en el nuevo listado busco al atleta en la tabla atletas, en otras palabras, para saber si ya está inscrito
            Inscripciones afiliado = db.Inscripciones.FirstOrDefault(x => x.InscripcionId == id);
            atletas atleta = db.atletas.Where(x => x.Reg_no == afiliado.DNI && x.Meetid == MeetId).FirstOrDefault();
            List<Pruebas> pruebas = db.Pruebas.ToList();
            List<Eventos> eventos = db.Eventos.Where(x => x.MeetId == MeetId).ToList();
            List<List<string>> InscripcionesEnTorneo;
            JavaScriptSerializer jss = new JavaScriptSerializer();
            InscripcionesEnTorneo = jss.Deserialize<List<List<string>>>(listado);

            try
            {
                int ath_No = IngresarDeportista(id, MeetId, YaestaInscritoString);


                List<Entradas> EntradasActuales = db.Entradas.Where(x => x.Ath_no == ath_No).ToList();
                foreach (Entradas entrada in EntradasActuales)
                {
                    db.Entradas.Remove(entrada);
                    db.SaveChanges();
                }

                foreach (var inscrito in InscripcionesEnTorneo)
                {
                    string course = inscrito[2];
                    if (course.Length < 1)
                    {
                        course = Piscina;
                    }

                    Entradas entrada = new Entradas
                    {
                        Event_ptr = eventos.Where(x => x.Event_no == int.Parse(inscrito[0])).Select(x => x.Event_ptr).FirstOrDefault(),
                        Ath_no = ath_No,
                        ActSeed_course = course,
                        ActualSeed_time = ConvertirASegundos(inscrito[1]),
                        ConvSeed_course = Piscina,

                        Scr_stat = false,
                        Alt_stat = false,
                        Bonus_event = false,
                        Div_no = 0,
                        Seed_place = 0,
                        MeetId = MeetId,
                    };
                    if (Piscina == course)
                    {
                        entrada.ConvSeed_time = ConvertirASegundos(inscrito[1]);
                    }
                    else
                    {
                        Eventos evento = eventos.Where(x => x.Event_ptr == entrada.Event_ptr).FirstOrDefault();
                        Pruebas prueba = pruebas.Where(x => x.EstiloMeet == evento.Event_stroke && x.distancia == evento.Event_dist).FirstOrDefault();
                        entrada.ConvSeed_time = ConvertirLaMarcaEntrePiscinas(ConvertirASegundos(inscrito[1]), prueba.FactorF, course);
                    }

                    db.Entradas.Add(entrada);
                }

                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Json("Hubo un error, por favor comuníquese con el administrador de la página", JsonRequestBehavior.AllowGet);
            }
            return Json("Se grabaron las inscripciones, puede regresar al listado", JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult BorrarInscripciones(int InscripcionId, int meetid)
        {
            Inscripciones inscripcion = db.Inscripciones.Where(x => x.InscripcionId == InscripcionId).FirstOrDefault();
            atletas atleta = db.atletas.Where(x => x.Reg_no == inscripcion.DNI && x.Meetid == meetid).FirstOrDefault();
            if (atleta == null)
            {
                return Json("No se realizó ninguna acción, Presione regresar al listado", JsonRequestBehavior.AllowGet);
            }
            List<Entradas> entradas = db.Entradas.Where(x => x.Ath_no == atleta.Ath_no && x.MeetId == meetid).ToList();
            foreach (Entradas entrada in entradas)
            {
                db.Entradas.Remove(entrada);
                db.SaveChanges();

            }
            db.atletas.Remove(atleta);
            db.SaveChanges();
            return Json("Se retiró de la prueba al deportista, Presione regresar al listado", JsonRequestBehavior.AllowGet);
        }

        public string ConvertirAMinutos(float segundos)
        {
            string tiempo = "";
            int num = (int)segundos;
            int hor = (num / 3600);
            int min = ((num - hor * 3600) / 60);
            int seg = num - (hor * 3600 + min * 60);
            double cent = Math.Round((segundos - num) * 100);

            if (hor > 0)
            {
                tiempo = hor.ToString();
            }
            string centesimas = ((int)cent).ToString("00");
            tiempo += min.ToString("00") + ":" + seg.ToString("00") + "." + centesimas;
            return tiempo;
        }

        public float ConvertirASegundos(string tiempo)
        {
            if (tiempo != null)
            {
                tiempo = tiempo.Trim();
                int posiciondospuntos = tiempo.IndexOf(":");
                int posicionpuntdo = tiempo.IndexOf(".");
                int minutos = 0;
                int segundos = 0;

                //Revisar esto cuando se haga inscripciones con tiempos de más de una hora
                //if (tiempo.Length > 8)
                //{
                //    int horas = tiempo.Substring()
                //}

                string dato;
                if (posiciondospuntos >= 0)
                {
                    dato = tiempo.Substring(0, posiciondospuntos);
                    minutos = Int32.Parse(dato);
                    dato = tiempo.Substring(posiciondospuntos + 1, 2); // medio extraño pero funciona
                    segundos = Int32.Parse(dato);
                }
                else if (posiciondospuntos == 0)
                {
                    dato = tiempo.Substring(0, posicionpuntdo);
                    segundos = Int32.Parse(dato);
                }
                else
                {
                    dato = tiempo.Substring(0, posicionpuntdo);
                    segundos = Int32.Parse(dato);
                }

                int largodecadena = tiempo.Length;
                if (largodecadena - (posicionpuntdo + 1) > 1)
                {
                    dato = tiempo.Substring(posicionpuntdo + 1, 2);
                }
                else
                {
                    dato = tiempo.Substring(posicionpuntdo + 1, 1) + "0";
                }




                int centesimas = Int32.Parse(dato);
                float segundosfloat = (minutos * 6000 + segundos * 100 + centesimas); //Como los datos son int no pueden dividirse entre 100
                float a = segundosfloat / 100;
                return (a);
            }
            else
            {
                return 0;
            }

        }

        public JsonResult JsonConvertirASegundos(string tiempo)
        {
            float segundos = ConvertirASegundos(tiempo);
            return Json(segundos, JsonRequestBehavior.AllowGet);
        }

        public Boolean VerSiCumpleConLaMarca(string curso, RESULTS resultado, float MM)
        {
            if (MM == 0)
            {
                return true;
            }
            if (resultado == null)
            {
                return false;
            }
            float Tiempo = ConvertirASegundos(resultado.SCORE);
            if (Tiempo < MM)
            {
                return true;
            }
            return false;
        }

        public Boolean VerSiCumpleConLaMarcaMaxima(InscritoViewModel NadadorAInscribir, RESULTS resultadoenlarga, RESULTS resultadoencorta)
        {
            string ScoreL = "0:00.00";
            string ScoreC = "0:00.00";
            bool respuesta = true;

            if (resultadoenlarga != null) { ScoreL = resultadoenlarga.SCORE; }
            if (resultadoencorta != null) { ScoreC = resultadoencorta.SCORE; }

            float TiempoC, TiempoL;
            TiempoL = ConvertirASegundos(ScoreL);
            TiempoC = ConvertirASegundos(ScoreC);
            NadadorAInscribir.PiscinaDelTiempo = "";


            if (TiempoC < NadadorAInscribir.MMCorta && TiempoC > 0)
            {
                respuesta = false;
                NadadorAInscribir.PiscinaDelTiempo = "C";
            }
            if (TiempoL < NadadorAInscribir.MMLarga && TiempoL > 0)
            {
                respuesta = false;
                NadadorAInscribir.PiscinaDelTiempo = "L";
            }

            if (TiempoC == 0 && TiempoL == 0)
            {
                respuesta = true;
            }


            return respuesta;

        }

        public InscritoViewModel BuscarTiempoDeTorneoSinMarca(InscritoViewModel NadadorAInscribir, RESULTS resultadoenlarga, RESULTS resultadoencorta, string curso)
        {
            float larga = 0;
            float corta = 0;
            if (resultadoenlarga != null)
            {
                larga = ConvertirASegundos(resultadoenlarga.SCORE ?? "0");
                if (curso == "L")
                {
                    NadadorAInscribir.segundos = larga;
                    NadadorAInscribir.tiempo = resultadoenlarga.SCORE;
                    NadadorAInscribir.torneo = resultadoenlarga.MEET1.MName;
                    NadadorAInscribir.PiscinaDelTiempo = "L";
                }
            }
            if (resultadoencorta != null)
            {
                corta = ConvertirASegundos(resultadoencorta.SCORE ?? "0");
                if (curso == "S")
                {
                    NadadorAInscribir.segundos = corta;
                    NadadorAInscribir.tiempo = resultadoencorta.SCORE;
                    NadadorAInscribir.torneo = resultadoencorta.MEET1.MName;
                    NadadorAInscribir.PiscinaDelTiempo = "S";
                }
            }
            if (larga == 0 && corta > 0)
            {
                NadadorAInscribir.segundos = corta;
                NadadorAInscribir.tiempo = resultadoencorta.SCORE;
                NadadorAInscribir.torneo = resultadoencorta.MEET1.MName;
                NadadorAInscribir.PiscinaDelTiempo = "S";


            }
            if (corta == 0 && larga > 0)
            {

                NadadorAInscribir.segundos = larga;
                NadadorAInscribir.tiempo = resultadoenlarga.SCORE;
                NadadorAInscribir.torneo = resultadoenlarga.MEET1.MName;
                NadadorAInscribir.PiscinaDelTiempo = "L";

            }
            if (corta > 0 && larga > 0)
            {
                if (curso == "L")
                {
                    NadadorAInscribir.segundos = larga;
                    NadadorAInscribir.tiempo = resultadoenlarga.SCORE;
                    NadadorAInscribir.torneo = resultadoenlarga.MEET1.MName;
                    NadadorAInscribir.PiscinaDelTiempo = "L";
                }
                else
                {
                    NadadorAInscribir.segundos = corta;
                    NadadorAInscribir.tiempo = resultadoencorta.SCORE;
                    NadadorAInscribir.torneo = resultadoencorta.MEET1.MName;
                    NadadorAInscribir.PiscinaDelTiempo = "S";
                }
            }
            if (resultadoenlarga == null && resultadoencorta == null)
            {
                NadadorAInscribir.tiempo = "00:00.00";
                NadadorAInscribir.segundos = 0;
                NadadorAInscribir.torneo = "Sin Marca aún";
                NadadorAInscribir.PiscinaDelTiempo = "";
            }
            return NadadorAInscribir;
        }

        public InscritoViewModel AgregarTorneo(InscritoViewModel NadadorAInscribir, string piscina, RESULTS resultado1, RESULTS resultado2)
        {
            return NadadorAInscribir;
        }

        public float ConvertirLaMarcaEntrePiscinas(float Segundo, double? FactorNullable, string curso)
        {
            float factor = (float)(FactorNullable ?? 0);
            int agregar = 1;
            float convertido = 0;
            if (curso == "L")
            {
                agregar = -1;
            }
            if (Segundo > 0)
            {
                convertido = Segundo + factor * agregar;
            }
            return convertido;
        }

        public int IngresarDeportista(int id, int MeetId, string YaestaInscritoString)
        {
            Inscripciones afiliado = db.Inscripciones.FirstOrDefault(x => x.InscripcionId == id);
            atletas atleta = db.atletas.Where(x => x.Reg_no == afiliado.DNI && x.Meetid == MeetId).FirstOrDefault();
            Boolean YaestaInscrito = YaestaInscritoString.ToUpper() == "TRUE";
            if (!YaestaInscrito)
            {
                Equipos equipo = db.Equipos.Where(x => x.Team_abbr == afiliado.Club.Iniciales && x.MeetId == MeetId).FirstOrDefault();
                if (equipo == null)
                {
                    Club club = db.Club.FirstOrDefault(x => x.ClubID == afiliado.Club.ClubID);
                    GrabarClub(club, MeetId);
                }

                int annoActual = DateTime.Now.Year;
                short edad = Convert.ToInt16(annoActual - afiliado.Afiliado.Fecha_de_nacimiento.Year - 1);
                if (atleta == null)
                {
                    atletas ultimocompetidor = db.atletas.OrderByDescending(x => x.Comp_no).FirstOrDefault();
                    try
                    {
                        atleta = new atletas();


                        atleta.Ath_no = 0;
                        if (afiliado.Afiliado.Apellido_Paterno.Length > 20)
                        {
                            atleta.Last_name = afiliado.Afiliado.Apellido_Paterno.Substring(0, 20);
                        }
                        else
                        {
                            atleta.Last_name = afiliado.Afiliado.Apellido_Paterno;
                        }

                        if (afiliado.Afiliado.Nombre.Length > 20)
                        {
                            atleta.First_name = afiliado.Afiliado.Nombre.Substring(0, 20);
                        }
                        else
                        {
                            atleta.First_name = afiliado.Afiliado.Nombre;
                        }

                        atleta.Ath_Sex = afiliado.Afiliado.Sexo;
                        atleta.Birth_date = afiliado.Afiliado.Fecha_de_nacimiento;
                        atleta.Team_no = equipo.Team_no;
                        atleta.Ath_age = edad;
                        atleta.Reg_no = afiliado.DNI;

                        atleta.Disab_SBcode = 0;
                        atleta.Disab_SMcode = 0;
                        atleta.Disab_Scode = 0;
                        atleta.Masters_RegVerified = false;
                        atleta.Meetid = MeetId;
                        atleta.TeamId = equipo.TeamId;

                        if (ultimocompetidor == null)
                        {
                            atleta.Ath_no = 1;
                            atleta.Comp_no = 1;
                        }
                        else
                        {
                            atleta.Ath_no = ultimocompetidor.Ath_no + 1;
                            atleta.Comp_no = ultimocompetidor.Comp_no + 1;
                        }
                        db.atletas.Add(atleta);
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        string mensaje = ex.Message;
                    }
                }
            }
            else
            {
                ActualizarNadador(afiliado, atleta);
            }
            return atleta.Ath_no;

        }

        public void ActualizarNadador(Inscripciones inscripcion, atletas atleta)
        {
            atleta.Ath_Sex = inscripcion.Afiliado.Sexo;
            atleta.First_name = inscripcion.Afiliado.Nombre;
            atleta.Last_name = inscripcion.Afiliado.Apellido_Paterno;
            atleta.Birth_date = inscripcion.Afiliado.Fecha_de_nacimiento;

            if (atleta.First_name.Length > 20)
            {
                atleta.First_name = atleta.First_name.Substring(0, 20);
            }


            if (atleta.Last_name.Length > 20)
            {
                atleta.Last_name = atleta.Last_name.Substring(0, 20);
            }

            db.SaveChanges();
        }

        public ActionResult ListadosPorPrueba(int MeetId)
        {
            List<Eventos> eventos = db.Eventos.Where(x => x.MeetId == MeetId).ToList();
            string estilo = "";
            UnEventoViewModel VM = new UnEventoViewModel
            {
                UnosEventos = new List<UnEvento>(),
                EventoId = 0,
            };
            foreach (var evento in eventos)
            {
                switch (evento.Event_stroke)
                {
                    case "A":
                        estilo = "Libre";
                        break;
                    case "B":
                        estilo = "Espalda";
                        break;
                    case "C":
                        estilo = "Pecho ";
                        break;
                    case "D":
                        estilo = "Mariposa";
                        break;
                    case "E":
                        estilo = "Combinado ";
                        break;
                }
                UnEvento modelo = new UnEvento
                {
                    id = evento.EventId,
                    Nombre = evento.Event_dist + " " + estilo + " " + evento.Event_gender + " " + evento.Low_age + "-" + evento.High_Age,
                };
                VM.UnosEventos.Add(modelo);
            }
            return View(VM);
        }

        public ActionResult DatosDelEvento(int EventId)
        {
            Eventos evento = db.Eventos.Find(EventId);
            List<MarcasMinimas> MMDelTorneo = db.MarcasMinimas.Where(x => x.MeetId == evento.MeetId && x.tag_dist == evento.Event_dist
            && x.tag_stroke == evento.Event_stroke && x.tag_gender == evento.Event_gender && x.MeetId == evento.MeetId).ToList();
            string estilo = "";
            DatosEventoViewModel VM = new DatosEventoViewModel
            {
                Evento = evento,
                Marcas = new List<ListadoDeMarcasMinimasViewModel>(),

            };

            foreach (var item in MMDelTorneo)
            {
                ListadoDeMarcasMinimasViewModel modelo = new ListadoDeMarcasMinimasViewModel
                {
                    EdadMinima = item.low_age ?? 0,
                    EdadMaxima = item.high_Age ?? 109,
                    Curso = item.tag_course,
                    MM = ConvertirAMinutos(item.tag_time ?? 0),

                };
                VM.Marcas.Add(modelo);
            }

            // EventosViewModel eventoVM = new EventosViewModel
            //{
            //    Evento = evento,
            //    MMCorta = MMDelTorneo
            //        .Where(x => x.tag_dist == evento.Event_dist
            //        && x.tag_stroke == evento.Event_stroke
            //        && x.MeetId == evento.MeetId
            //        && x.tag_course == "S"
            //        && x.low_age <= evento.Low_age
            //        && x.tag_gender == evento.Event_gender)
            //         .Select(x => x.tag_time).FirstOrDefault() ?? 0,

            //    MMlarga = MMDelTorneo
            //        .Where(x => x.tag_dist == evento.Event_dist
            //       && x.tag_stroke == evento.Event_stroke
            //       && x.MeetId == evento.MeetId
            //       && x.tag_course == "L"
            //       && x.low_age <= evento.Low_age
            //        && x.tag_gender == evento.Event_gender)
            //        .Select(x => x.tag_time).FirstOrDefault() ?? 0,


            //};
            //switch(evento.Event_stroke)
            //    {
            //        case "A":
            //            estilo = "Libre";
            //    break;
            //        case "B":
            //            estilo = "Espalda";
            //    break;
            //        case "C":
            //            estilo = "Pecho ";
            //    break;
            //        case "D":
            //            estilo = "Mariposa";
            //    break;
            //        case "E":
            //            estilo = "Combinado ";
            //    break;
            //}
            //eventoVM.MMlargastring = ConvertirAMinutos(eventoVM.MMlarga);
            //eventoVM.MMCortastring = ConvertirAMinutos(eventoVM.MMCorta);
            //eventoVM.Nombre = estilo;
            return PartialView(VM);
        }

        public ActionResult InscritosAlEvento(int EventId)
        {
            int anno = DateTime.Now.Year;
            Eventos evento = db.Eventos.Find(EventId);
            List<Equipos> Equipos = db.Equipos.Where(x => x.MeetId == evento.MeetId).ToList();
            List<Entradas> entradas = db.Entradas.Where(x => x.MeetId == evento.MeetId && x.Event_ptr == evento.Event_ptr).OrderBy(x => x.ConvSeed_time).ToList();
            List<atletas> atletas = db.atletas.Where(x => x.Meetid == evento.MeetId).ToList();
            List<NadadorPruebaViewModel> VM = new List<NadadorPruebaViewModel>();
            foreach (Entradas entrada in entradas)
            {
                NadadorPruebaViewModel modelo = new NadadorPruebaViewModel
                {
                    entrada = entrada,
                    atleta = atletas.Where(x => x.Ath_no == entrada.Ath_no).FirstOrDefault(),
                };
                modelo.equipo = Equipos.Where(x => x.Team_no == modelo.atleta.Team_no).FirstOrDefault();
                modelo.tiempo = ConvertirAMinutos(modelo.entrada.ConvSeed_time ?? 0);
                modelo.edad = anno - (modelo.atleta.Birth_date.Value.Year) - 1;
                VM.Add(modelo);
            }

            return PartialView(VM);
        }


        public JsonResult SoloParaPostas(int afiliadoId, int MeetId)
        {
            string resultado = "Ya estaba inscrito anteriormente";

            Inscripciones inscripciones = db.Inscripciones.Find(afiliadoId);
            atletas atleta = db.atletas.Where(x => x.Reg_no == inscripciones.DNI && x.Meetid == MeetId).FirstOrDefault();
            if (atleta == null)
            {
                IngresarDeportista(afiliadoId, MeetId, "false");
                resultado = "Se agregpo para postas";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public void GrabarClub(Club club, int MeetId)
        {
            //Afiliacion afiliacion = af.Afiliacion.Where(x => x.DNI == afiliado.DNI).OrderByDescending(x => x.AfiliacionID).FirstOrDefault();   

            Equipos ultimoequipo = db.Equipos.OrderByDescending(x => x.Team_no).FirstOrDefault();
            Equipos equipo = new Equipos
            {
                Team_name = club.NombreClub,
                Team_short = club.NombreUsuario,
                Team_abbr = club.Iniciales,
                Team_div = 0,
                Team_region = 0,
                Team_cntry = "PER",
                Team_NoPoints = false,
                Team_Selected = false,
                NoTeam_surcharge = false,
                NoFacility_surcharge = false,
                NoAthlete_surcharge = false,
                NoRelayOnly_surcharge = false,
                MeetId = MeetId
            };
            if (equipo.Team_name.Length > 30)
            {
                equipo.Team_name = equipo.Team_name.Substring(0, 30);

            }
            if (equipo.Team_short.Length > 15)
            {
                equipo.Team_short = equipo.Team_short.Substring(0, 15);

            }

            if (ultimoequipo == null)
            {
                equipo.Team_no = 1;
            }
            else
            {
                equipo.Team_no = ultimoequipo.Team_no + 1;
            }

            db.Equipos.Add(equipo);
            db.SaveChanges();

        }
        [HttpGet]
        public ActionResult InscribirResponsable(int MeetId)
        {
            Usuario usuario = Session["Usuario"] as Usuario;
            ViewBag.usuario = usuario;
            ViewBag.MeetId = MeetId;

            InscripcionResponsableViewModel VM = new InscripcionResponsableViewModel
            {
                InscripcionResponsable = new InscripcionResponsable(),
                MeetId = MeetId,
            };
            return View(VM);
        }

        [HttpPost]
        public ActionResult InscribirResponsable(InscripcionResponsableViewModel VM)
        {
            Usuario usuario = Session["Usuario"] as Usuario;
            Club club = db.Club.FirstOrDefault(x => x.ClubID == usuario.ClubId);
            GrabarClub(club, VM.MeetId);

            if (TryUpdateModel(VM.InscripcionResponsable))
            {
                Equipos equipo = db.Equipos.FirstOrDefault(x => x.Team_abbr == club.Iniciales);
                VM.InscripcionResponsable.TeamId = equipo.TeamId;
                db.InscripcionResponsable.Add(VM.InscripcionResponsable);
                db.SaveChanges();
                SetupTorneo setup = db.SetupTorneo.Where(x => x.Meetid == VM.MeetId).FirstOrDefault();
                if (setup.Masters)
                {
                    return RedirectToAction("ListarMasters", "masters", new { setup });

                }
                else
                {
                    return RedirectToAction("ListarNadadores", new { Meetid = VM.MeetId });
                }

            }
            return View(VM.MeetId);
        }



        //Esto es para borrar posteriormente

        public ActionResult ListarNadadoresAfiliados(int Meetid)
        {
            Torneo torneo = db.Torneo.Find(Meetid);
            Usuario usuario = Session["usuario"] as Usuario;
            Club club = db.Club.Where(x => x.ClubID == usuario.ClubId).FirstOrDefault();

            List<Eventos> ListadoDeEventos = db.Eventos.Where(x => x.MeetId == Meetid).ToList();
            int EdadMaxima = ListadoDeEventos.Max(x => x.High_Age) ?? 109;
            int EdadMinima = ListadoDeEventos.Min(x => x.Low_age) ?? 0;
            int annoActual = DateTime.Now.Year - 1;
            int AnnoMaximo = annoActual - EdadMinima;
            int AnnoMinimo = annoActual - EdadMaxima;


            List<ListarNadadoresParaSeleccionarlos> VM = new List<ListarNadadoresParaSeleccionarlos>();


            List<Inscripciones> listadoNadadores = db
                .Inscripciones.Where(x => x.ClubID == club.ClubID && x.EstadoID == 3 && x.Afiliado.Fecha_de_nacimiento.Year >= AnnoMinimo && x.Afiliado.Fecha_de_nacimiento.Year <= AnnoMaximo)
                .OrderBy(x => x.Afiliado.Fecha_de_nacimiento)
                .ToList();

            List<Entradas> EntradasDeEsteTorneo = db.Entradas.Where(x => x.MeetId == Meetid).ToList();
            List<atletas> atletasDeEsteTorneo = db.atletas.Where(x => x.Meetid == Meetid).ToList();
            foreach (Inscripciones afiliado in listadoNadadores)
            {
                ListarNadadoresParaSeleccionarlos listarnadadorparaafiliar = new ListarNadadoresParaSeleccionarlos
                {
                    afiliado = afiliado,
                    YaEstaInscrito = false,
                    TieneMulta = db.Multas.Any(x => x.InscripcionId == afiliado.InscripcionId && x.Subsanada == false),
                };
                if (atletasDeEsteTorneo.Any(x => x.Reg_no == afiliado.DNI))
                {
                    atletas atleta = atletasDeEsteTorneo.Where(x => x.Reg_no == afiliado.DNI).FirstOrDefault();
                    listarnadadorparaafiliar.YaEstaInscrito = true;
                    //if (EntradasDeEsteTorneo.Any(x => x.Ath_no == atleta.Ath_no && x.MeetId == Meetid))
                    //{
                    //    listarnadadorparaafiliar.YaEstaInscrito = true;
                    //}

                }
                VM.Add(listarnadadorparaafiliar);
            }
            ViewBag.setup = db.SetupTorneo.Where(x => x.Meetid == Meetid).FirstOrDefault();

            return View(VM);
        }

        public ActionResult ListarNadadoresNoAfiliadosConTiempo(int Meetid)
        {
            Torneo torneo = db.Torneo.Find(Meetid);
            Usuario usuario = Session["usuario"] as Usuario;
            Club club = db.Club.Where(x => x.ClubID == usuario.ClubId).FirstOrDefault();

            List<Eventos> ListadoDeEventos = db.Eventos.Where(x => x.MeetId == Meetid).ToList();
            int EdadMaxima = ListadoDeEventos.Max(x => x.High_Age) ?? 109;
            int EdadMinima = ListadoDeEventos.Min(x => x.Low_age) ?? 0;
            int annoActual = DateTime.Now.Year - 1;
            int AnnoMaximo = annoActual - EdadMinima;
            int AnnoMinimo = annoActual - EdadMaxima;


            List<ListarNadadoresParaSeleccionarlos> VM = new List<ListarNadadoresParaSeleccionarlos>();


            List<Inscripciones> listadoNadadores = db
                .Inscripciones.Where(x => x.ClubID == club.ClubID && x.Afiliado.Fecha_de_nacimiento.Year >= AnnoMinimo && x.Afiliado.Fecha_de_nacimiento.Year <= AnnoMaximo)
                .OrderBy(x => x.Afiliado.Fecha_de_nacimiento)
                .ToList();

            List<Entradas> EntradasDeEsteTorneo = db.Entradas.Where(x => x.MeetId == Meetid).ToList();
            List<atletas> atletasDeEsteTorneo = db.atletas.Where(x => x.Meetid == Meetid).ToList();
            foreach (Inscripciones afiliado in listadoNadadores)
            {
                ListarNadadoresParaSeleccionarlos listarnadadorparaafiliar = new ListarNadadoresParaSeleccionarlos
                {
                    afiliado = afiliado,
                    YaEstaInscrito = false,
                    TieneMulta = db.Multas.Any(x => x.InscripcionId == afiliado.InscripcionId && x.Subsanada == false),
                };
                if (atletasDeEsteTorneo.Any(x => x.Reg_no == afiliado.DNI))
                {
                    atletas atleta = atletasDeEsteTorneo.Where(x => x.Reg_no == afiliado.DNI).FirstOrDefault();
                    listarnadadorparaafiliar.YaEstaInscrito = true;
                    //if (EntradasDeEsteTorneo.Any(x => x.Ath_no == atleta.Ath_no && x.MeetId == Meetid))
                    //{
                    //    listarnadadorparaafiliar.YaEstaInscrito = true;
                    //}

                }
                VM.Add(listarnadadorparaafiliar);
            }
            ViewBag.setup = db.SetupTorneo.Where(x => x.Meetid == Meetid).FirstOrDefault();

            return View("ListarNadadoresNoAfiliados", VM);
        }

    }
}