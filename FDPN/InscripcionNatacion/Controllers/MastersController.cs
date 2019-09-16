using FDPN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InscripcionNatacion.ViewModels.Masters;
using InscripcionNatacion.Helpers;
using InscripcionNatacion.ViewModels.Inscrito;

namespace InscripcionNatacion.Controllers
{
    public class MastersController : BASEController
    {
        InscritoController inscrito = new InscritoController();
        int AnnoMinimo;
        Repository repository = new Repository();

        public ActionResult Index()
        {
            return View();
        }

       public ActionResult ListarMasters(int meetid)
        {
            SetupTorneo setup = db.SetupTorneo.FirstOrDefault(x => x.Meetid == meetid);

            ViewBag.MeetName = setup.Torneo.Meetid;
            return View();

        }
        public ActionResult GetNadadores(SetupTorneo setup)
        {
            int annoactual = DateTime.Now.Year;
            AnnoMinimo = annoactual - 25;

            if (!repository.validarUsuario())
            {
                return RedirectToAction("Login", "home");
            }
            Usuario usuario = Session["Usuario"] as Usuario;
            Equipos equipo = db.Equipos.FirstOrDefault(x => x.Team_abbr == usuario.Club.Iniciales);
            if (equipo == null && equipo.Team_abbr != "UNAT")
            {
                return RedirectToAction("InscribirResponsable", "inscrito", new { MeetId = setup.Meetid });
            }
            InscripcionResponsable responsable = db.InscripcionResponsable.FirstOrDefault(x => x.TeamId == equipo.TeamId);
            

          
            var listado = db.Inscripciones.Where(x =>  x.Afiliado.Fecha_de_nacimiento.Year >= AnnoMinimo ).AsQueryable();
            if (!setup.PermiteNoAfiliados)
            {
                listado = listado.Where(x => x.EstadoID == 3);
            }
            List<Inscripciones> listadoNadadores = new List<Inscripciones>();
            listadoNadadores = listado.OrderBy(x => x.Afiliado.Apellido_Paterno).ToList();

            List<NadadorMasterViewModel> VM = new List<NadadorMasterViewModel>();

            foreach(Inscripciones inscripcion in listadoNadadores )
            {
                NadadorMasterViewModel modelo = new NadadorMasterViewModel
                {
                    DNI = inscripcion.DNI,
                    Nombre = inscripcion.Afiliado.Nombre,
                    Apellido_Paterno = inscripcion.Afiliado.Apellido_Paterno,
                    Sexo = inscripcion.Afiliado.Sexo,
                    Fecha_de_nacimiento = inscripcion.Afiliado.Fecha_de_nacimiento,
                    InscripcionId = inscripcion.InscripcionId,
                    TieneMulta = false,
                    YaEstaInscrito = false,
                    TieneResultado = false,

                };
                if(db.Inscripciones.Any(x=>x.DNI == inscripcion.DNI))
                {
                    modelo.YaEstaInscrito = true;
                }
                if(db.Multas.Any(x=>x.InscripcionId == inscripcion.InscripcionId))
                {
                    modelo.TieneMulta = true;
                }
            }
            ViewBag.meetid = db.SetupTorneo.Where(x => x.Meetid == setup.Meetid).Select(x=>x.Meetid).FirstOrDefault();
            return PartialView(VM);
        }

        public ActionResult ListarPruebasParaElNadador(int MeetId, int inscripcionid)
        {
            int annoActual = DateTime.Now.Year - 1; /*Para calcular la edad al año pasado*/

            //Iniciando las variables a usar más adelante
            SetupTorneo setup = db.SetupTorneo.Where(x => x.Meetid == MeetId).FirstOrDefault();
            List<SessionItem> ListadoDeSessionItem = db.SessionItem.Where(x => x.Meetid == MeetId).ToList();
            List<int> PruebasYaInscritas = new List<int>();
            RESULTSMasters resultado = new RESULTSMasters();

            DateTime fecha = setup.Torneo.entry_deadline ?? DateTime.Now;
            DateTime haceunanno = setup.FechaMarcas;
            string stroke = "Free";
            //Hallo el tipo de piscina en el que se nadará

            int NumeroSesiones = setup.Torneo.Sesion.OrderByDescending(x => x.SessionId).Select(x => x.Sess_day).FirstOrDefault() ?? 1;
            int pruebasXtorneo = setup.pruebasXtorneo;
            int pruebasConMarca = 0;

            //Inicio de variable del modelo
            ListadoInscritoViewModel VM = new ListadoInscritoViewModel
            {
                afiliado = db.Inscripciones.Where(x => x.InscripcionId == inscripcionid).FirstOrDefault(),
                listaDeEventos = new List<ViewModels.Inscrito.InscritoViewModel>(),
                Sesiones = new List<SesionViewModel>(),
                PruebasTotales = pruebasXtorneo,
                Piscina = "",
                PruebasInscritasSinMarca = 0,
                SinMarca = 1,
                MeetId = MeetId,

            };

            List<RESULTSMasters> resultados = db.RESULTSMasters
                      .Where(x => x.AthleteMasters.ID_NO == VM.afiliado.DNI && x.MEETMasters.Start > haceunanno && x.SCORE != "" && x.NT == 0)
                      .ToList();

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
            List<Eventos> eventosDelNadador = db.Eventos.Where(x => x.MeetId == MeetId && x.Low_age <= edad && x.High_Age >= edad && x.Event_gender == VM.afiliado.Afiliado.Sexo && x.Ind_rel == "i").ToList();


            foreach (Eventos evento in eventosDelNadador)
            {
                InscritoViewModel NadadorAInscribir = new InscritoViewModel
                {
                    evento = evento,
                    sesion = ListadoDeSessionItem.Where(x => x.Event_ptr == evento.Event_ptr).Select(x => x.Sess_ptr).FirstOrDefault() ?? 0,
                    MMCorta = 0,
                    MMLarga = 0,
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

               

                RESULTSMasters resultadoenlarga = resultados
                       .Where(x => x.DISTANCE == distancia && x.STROKE == stroke && x.COURSE == "L")
                       .OrderBy(x => x.SCORE).FirstOrDefault();
                RESULTSMasters resultadoencorta = resultados
                       .Where(x => x.DISTANCE == distancia && x.STROKE == stroke && x.COURSE == "S")
                       .OrderBy(x => x.SCORE).FirstOrDefault();



                // Ver si cumple la marca mínima, primero la de la competencia, usando LSY y SLY
                string CursoPiscina = setup.Torneo.course_order;
                NadadorAInscribir = GetMejortiempoDeLaPrueba(NadadorAInscribir, resultadoenlarga, resultadoencorta, CursoPiscina, setup);

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


            if (!setup.PermiteSinMarca)
            {
                VM.SinMarca = setup.SinMarca;
            }
            else
            {
                VM.SinMarca = 1;
            }
            ViewBag.setup = setup;
            return PartialView(VM);
        }


        public InscritoViewModel GetMejortiempoDeLaPrueba(InscritoViewModel NadadorAInscribir, RESULTSMasters resultadoenlarga, RESULTSMasters resultadoencorta, string curso, SetupTorneo setup)
        {
            // Ver si cumple la marca mínima, primero la de la competencia, usando LSY y SLY
            RESULTSMasters resultado = new RESULTSMasters();
            string CursoPiscina = setup.Torneo.course_order;


            for (int i = 0; i < 2; i++)
            {
               
                string CursoABuscar = CursoPiscina.Substring(i, 1);
                if (CursoABuscar == "L")
                {
                    resultado = resultadoenlarga;
                   
                }
                else
                {
                    resultado = resultadoencorta;
                    
                }
                if(resultado != null)
                {
                    NadadorAInscribir.Cumple = true;
                    break;
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
                    NadadorAInscribir.segundos = inscrito. ConvertirASegundos(NadadorAInscribir.tiempo);
                    NadadorAInscribir.torneo = resultado.MEETMasters.MName;
                    if (resultado.MEETMasters.MName.Length > 20)
                    {
                        NadadorAInscribir.torneo = resultado.MEETMasters.MName.Substring(0, 20);
                    }
                    NadadorAInscribir.PiscinaDelTiempo = resultado.COURSE;
                    NadadorAInscribir.Cumple = false;

                }

            }
            if (resultado == null)
            {
                resultado = new RESULTSMasters
                {
                    SCORE = "0.00",
                    COURSE = "-",
                    MEETMasters = new MEETMasters
                    {
                        MName = "Sin participación",
                    },
                };
            }
            NadadorAInscribir.tiempo = resultado.SCORE;
            NadadorAInscribir.segundos = inscrito. ConvertirASegundos(NadadorAInscribir.tiempo);
            NadadorAInscribir.torneo = resultado.MEETMasters.MName;
            if (resultado.MEETMasters.MName.Length > 20)
            {
                NadadorAInscribir.torneo = resultado.MEETMasters.MName.Substring(0, 20);
            }
            NadadorAInscribir.PiscinaDelTiempo = resultado.COURSE;
            return NadadorAInscribir;
        }


    }
}
