﻿using FDPN.Models;
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

        public ActionResult ListarNadadores(int Meetid)
        {

            if (!repository.validarUsuario())
            {
                return RedirectToAction("Login", "home");
            }
            SetupTorneo setup = db.SetupTorneo.FirstOrDefault(x=>x.Meetid == Meetid);
            Club club = Session["Club"] as Club;
            if(setup.PorLigas && club.AsociacionId!=null )
            {
                ErrorViewModel VM = new ErrorViewModel
                {
                    Principal = "No tiene permiso para inscribir en este torneo",
                    Medio = "Este evento se realiza por asociaciones o ligas",
                    Pie = "Por favor ingrese con el usuario y contraseña de una asociación o liga",
                };
                return RedirectToAction("Home/paginadeerroromensaje", new { VM = VM });
            }
            switch(setup.TipoTorneo.TipoId)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                    return RedirectToAction("ListarNadadoresAfiliados", new { Meetid });
                case 5:
                    return RedirectToAction("ListarNadadoresNoAfiliados", new { Meetid });
            }
            return View();
        }

       


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

        public ActionResult ListarNadadoresNoAfiliados(int Meetid)
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
                x.Afiliado.Fecha_de_nacimiento.Year <= AnnoMaximo  && x.DisciplinaId ==1)
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


            return View( VM);
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
            
            SetupTorneo setup = db.SetupTorneo.Where(x => x.Meetid == MeetId).FirstOrDefault();
            RESULTS resultado = new RESULTS();

            DateTime fecha = setup.Torneo.entry_deadline ?? DateTime.Now;
            DateTime haceunanno = fecha.AddDays(-15).AddYears(-1);

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
                afiliado = db.Inscripciones.Where(x => x.InscripcionId == afiliadoId ).FirstOrDefault(),
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
                       .Where(x => x.Athlete1.ID_NO == VM.afiliado.DNI && x.MEET1.Start > haceunanno && x.SCORE != "" && x.NT==0)
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
                if(!NadadorAInscribir.Cumple)
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

                if(!NadadorAInscribir.Cumple)
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
                VM.SinMarca =0;
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
            DateTime haceunanno = fecha.AddDays(-15).AddYears(-1);

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
            List<Eventos> eventosDelNadador = db.Eventos.Where(x => x.MeetId == MeetId && x.Low_age <= edad && x.High_Age >= edad && x.Event_gender == VM.afiliado.Afiliado.Sexo && x.Ind_rel == "i").ToList();

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


        public ActionResult ListarPruebasParaElNadadorDivision2(int MeetId, int afiliadoId)
        {
            int annoActual = DateTime.Now.Year - 1; /*Para calcular la edad al año pasado*/

            SetupTorneo setup = db.SetupTorneo.Where(x => x.Torneo.Meetid == MeetId).FirstOrDefault();
            RESULTS resultado = new RESULTS();

            DateTime fecha = setup.Torneo.entry_deadline ?? DateTime.Now;
            DateTime haceunanno = fecha.AddDays(-15).AddYears(-1);

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
                        NadadorAInscribir.Cumple = VerSiCumpleConLaMarcaMaxima(CursoABuscar, resultado, MM);
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
            return View( VM);
        }



        public ActionResult ListarPruebasParaElNadadorDIVISION2OLD(int MeetId, int afiliadoId)
        {
            Torneo torneo = db.Torneo.Find(MeetId);
            int annoActual = DateTime.Now.Year - 1; /*Para calcular la edad al año pasado*/
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
                    .OrderByDescending(x => x.tag_ptr)
                    .Select(x => x.tag_time).FirstOrDefault() ?? 0,

                    MMLarga = MarcasMinimasDelTorneo
                    .Where(x => x.tag_dist == evento.Event_dist && x.tag_stroke == evento.Event_stroke && x.tag_course == "L" && x.low_age <= edad && x.high_Age >= edad && x.tag_gender == evento.Event_gender)
                    .OrderByDescending(x => x.tag_ptr)
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



                // Ver si cumple tener menos que la marca máxima, primero la de la competencia, usando LSY y SLY
                string CursoPiscina = torneo.course_order;
                for (int i = 0; i < 2; i++)
                {
                    float MM = 0;

                    string CursoABuscar = CursoPiscina.Substring(i, 1);

                    if (CursoABuscar == "L")
                    { MM = NadadorAInscribir.MMLarga; }
                    else
                    { MM = NadadorAInscribir.MMCorta; }


                    // se busca el mejor resultado en este evento en piscina larga y en corta desde hace un año 
                    RESULTS resultado = resultados
                       .Where(x => x.DISTANCE == distancia && x.STROKE == stroke && x.COURSE == CursoABuscar)
                       .OrderBy(x => x.SCORE)
                       .FirstOrDefault();
                    if (resultado != null)
                    {

                        NadadorAInscribir.Cumple = VerSiCumpleConLaMarcaMaxima(CursoABuscar, resultado, MM);
                    }
                    else
                    {
                        NadadorAInscribir.Cumple = true;
                        NadadorAInscribir.tiempo = "0.00";
                        NadadorAInscribir.segundos = 0;
                        NadadorAInscribir.torneo = "Sin torneo";
                        NadadorAInscribir.PiscinaDelTiempo = "";
                    }
                    if (!NadadorAInscribir.Cumple && resultado != null)
                    {
                        NadadorAInscribir.tiempo = resultado.SCORE;
                        NadadorAInscribir.segundos = ConvertirASegundos(NadadorAInscribir.tiempo);
                        NadadorAInscribir.torneo = resultado.MEET1.MName.Substring(0, 20);
                        NadadorAInscribir.PiscinaDelTiempo = resultado.COURSE;
                        //pruebasConMarca += 1;
                        break;
                    }
                    else
                    {
                        NadadorAInscribir.tiempo = "0.00";
                        NadadorAInscribir.segundos = 0;
                        NadadorAInscribir.torneo = "Sin torneo";
                        NadadorAInscribir.PiscinaDelTiempo = " ";
                    }
                    // Si no hay marcas mínimas entonces todos pueden cumplir con la MM

                }
                //ESto no debería de ocurrir en un DIV 2
                //if (NadadorAInscribir.MMCorta ==0 &&  NadadorAInscribir.MMLarga == 0)
                //{
                //    NadadorAInscribir.Cumple = true;
                //}
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


        [HttpGet]
        public JsonResult GrabarPruebasParaElNadador(string listado, string MeetString, string InscripcionId, string Piscina, string YaestaInscritoString)
        {

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
               int ath_No=  IngresarDeportista(id, MeetId, YaestaInscritoString);
                //Si no está inscrito, procedo a inscribirlo, para ello primero veo si ya se inscribió su club
                //if (!YaestaInscrito)
                //{

                //    Equipos equipo = db.Equipos.Where(x => x.Team_abbr == afiliado.Club.Iniciales && x.MeetId == MeetId).FirstOrDefault();

                //    if (equipo == null)
                //    {
                //        Equipos ultimoequipo = db.Equipos.OrderByDescending(x => x.Team_no).FirstOrDefault();
                //        equipo = new Equipos
                //        {
                //            Team_name = afiliado.Club.NombreClub,
                //            Team_abbr = afiliado.Club.Iniciales,
                //            Team_div = 0,
                //            Team_region = 0,
                //            Team_cntry = "PER",
                //            Team_NoPoints = false,
                //            Team_Selected = false,
                //            NoTeam_surcharge = false,
                //            NoFacility_surcharge = false,
                //            NoAthlete_surcharge = false,
                //            NoRelayOnly_surcharge = false,
                //            MeetId = MeetId
                //        };
                //        if (equipo.Team_name.Length > 30)
                //        {
                //            equipo.Team_name = equipo.Team_name.Substring(0, 30);

                //        }
                //        if (ultimoequipo == null)
                //        {
                //            equipo.Team_no = 1;
                //        }
                //        else
                //        {
                //            equipo.Team_no = ultimoequipo.Team_no + 1;
                //        }

                //        db.Equipos.Add(equipo);
                //        db.SaveChanges();
                //    }

                //    int annoActual = DateTime.Now.Year;
                //    short edad = Convert.ToInt16(annoActual - afiliado.Afiliado.Fecha_de_nacimiento.Year - 1);
                //    if (atleta == null)
                //    {
                //        atletas ultimocompetidor = db.atletas.OrderByDescending(x => x.Comp_no).FirstOrDefault();
                //        try
                //        {
                //            atleta = new atletas();


                //            atleta.Ath_no = 0;
                //            if (afiliado.Afiliado.Apellido_Paterno.Length > 20)
                //            {
                //                atleta.Last_name = afiliado.Afiliado.Apellido_Paterno.Substring(0, 20);
                //            }
                //            else
                //            {
                //                atleta.Last_name = afiliado.Afiliado.Apellido_Paterno;
                //            }

                //            if (afiliado.Afiliado.Nombre.Length > 20)
                //            {
                //                atleta.First_name = afiliado.Afiliado.Nombre.Substring(0, 20);
                //            }
                //            else
                //            {
                //                atleta.First_name = afiliado.Afiliado.Nombre;
                //            }

                //            atleta.Ath_Sex = afiliado.Afiliado.Sexo;
                //            atleta.Birth_date = afiliado.Afiliado.Fecha_de_nacimiento;
                //            atleta.Team_no = equipo.Team_no;
                //            atleta.Ath_age = edad;
                //            atleta.Reg_no = afiliado.DNI;

                //            atleta.Disab_SBcode = 0;
                //            atleta.Disab_SMcode = 0;
                //            atleta.Disab_Scode = 0;
                //            atleta.Masters_RegVerified = false;
                //            atleta.Meetid = MeetId;
                //            atleta.TeamId = equipo.TeamId;

                //            if (ultimocompetidor == null)
                //            {
                //                atleta.Ath_no = 1;
                //                atleta.Comp_no = 1;
                //            }
                //            else
                //            {
                //                atleta.Ath_no = ultimocompetidor.Ath_no + 1;
                //                atleta.Comp_no = ultimocompetidor.Comp_no + 1;
                //            }
                //            db.atletas.Add(atleta);
                //            db.SaveChanges();
                //        }
                //        catch (Exception ex)
                //        {
                //            string mensaje = ex.Message;
                //        }
                //    }
                //}
                //else
                //{
                //    ActualizarNadador(afiliado, atleta);
                //}


                List<Entradas> EntradasActuales = db.Entradas.Where(x => x.Ath_no == ath_No).ToList();
                foreach (Entradas entrada in EntradasActuales)
                {
                    db.Entradas.Remove(entrada);
                    db.SaveChanges();
                }

                foreach (var inscrito in InscripcionesEnTorneo)
                {
                    string course = inscrito[6];
                    if (course.Length < 1)
                    {
                        course = Piscina;
                    }

                    Entradas entrada = new Entradas
                    {
                        Event_ptr = int.Parse(inscrito[1]),
                        Ath_no = ath_No,
                        ActSeed_course = course,
                        ActualSeed_time = ConvertirASegundos(inscrito[5]),
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
                        entrada.ConvSeed_time = ConvertirASegundos(inscrito[5]);
                    }
                    else
                    {
                        Eventos evento = eventos.Where(x => x.Event_ptr == entrada.Event_ptr).FirstOrDefault();
                        Pruebas prueba = pruebas.Where(x => x.EstiloMeet == evento.Event_stroke && x.distancia == evento.Event_dist).FirstOrDefault();
                        entrada.ConvSeed_time = ConvertirMarca(ConvertirASegundos(inscrito[5]), prueba.FactorF, course);
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
            if(atleta == null)
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
            tiempo += min.ToString("00") + ":" + seg.ToString("00") + "." + ((int)cent).ToString("00");
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
                else if(posiciondospuntos ==0)
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

            float Tiempo = ConvertirASegundos(resultado.SCORE);
            if (Tiempo < MM)
            {
                return true;
            }
            return false;
        }

        public Boolean VerSiCumpleConLaMarcaMaxima(string curso, RESULTS resultado, float MM)
        {
            if (MM == 0)
            {
                return true;
            }

            float Tiempo = ConvertirASegundos(resultado.SCORE);
            if (Tiempo > MM)
            {
                return true;
            }
            return false;
        }



        public InscritoViewModel AgregarTorneo(InscritoViewModel NadadorAInscribir, string piscina, RESULTS resultado1, RESULTS resultado2)
        {
            return NadadorAInscribir;
        }

        public float ConvertirMarca(float Segundo, double? FactorNullable, string curso)
        {
            float factor = (float)(FactorNullable ?? 0);
            int agregar = 1;
            if (curso == "L")
            {
                agregar = -1;
            }
            float convertido = Segundo + factor * agregar;
            return convertido;
        }

        public int IngresarDeportista(int id, int MeetId, string YaestaInscritoString)
        {
            Inscripciones afiliado = db.Inscripciones.FirstOrDefault(x => x.InscripcionId == id);
            atletas atleta = db.atletas.Where(x => x.Reg_no == afiliado.DNI && x.Meetid == MeetId).FirstOrDefault();
            Boolean YaestaInscrito = YaestaInscritoString.ToUpper() == "TRUE";
            if (!YaestaInscrito)
            {

                //Afiliacion afiliacion = af.Afiliacion.Where(x => x.DNI == afiliado.DNI).OrderByDescending(x => x.AfiliacionID).FirstOrDefault();
                Equipos equipo = db.Equipos.Where(x => x.Team_abbr == afiliado.Club.Iniciales && x.MeetId == MeetId).FirstOrDefault();

                if (equipo == null)
                {
                    Equipos ultimoequipo = db.Equipos.OrderByDescending(x => x.Team_no).FirstOrDefault();
                    equipo = new Equipos
                    {
                        Team_name = afiliado.Club.NombreClub,
                        Team_abbr = afiliado.Club.Iniciales,
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
            UnEventoViewModel VM = new UnEventoViewModel {
                UnosEventos= new List<UnEvento>(),
                EventoId =0,
            };
            foreach(var evento in eventos)
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
            && x.tag_stroke == evento.Event_stroke && x.tag_gender == evento.Event_gender).ToList();
            string estilo = "";
            DatosEventoViewModel VM = new DatosEventoViewModel
            {
                Evento = evento,
                Marcas= new List<ListadoDeMarcasMinimasViewModel>(),
                
            };

            foreach(var item in MMDelTorneo)
            {
                ListadoDeMarcasMinimasViewModel modelo = new ListadoDeMarcasMinimasViewModel
                {
                    EdadMinima = item.low_age?? 0,
                    EdadMaxima = item.high_Age?? 109,
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
            List<Entradas> entradas = db.Entradas.Where(x => x.MeetId == evento.MeetId && x.Event_ptr == evento.Event_ptr).OrderBy(x=>x.ConvSeed_time).ToList();
            List<atletas> atletas = db.atletas.Where(x => x.Meetid == evento.MeetId ).ToList();
            List<NadadorPruebaViewModel> VM = new List<NadadorPruebaViewModel>();
            foreach(Entradas entrada in entradas)
            {
                NadadorPruebaViewModel modelo = new NadadorPruebaViewModel
                {
                    entrada = entrada,
                    atleta = atletas.Where(x => x.Ath_no == entrada.Ath_no).FirstOrDefault(),
                };
                modelo.equipo = Equipos.Where(x => x.Team_no == modelo.atleta.Team_no).FirstOrDefault();
                modelo.tiempo = ConvertirAMinutos(modelo.entrada.ConvSeed_time??0);
                modelo.edad = anno - (modelo.atleta.Birth_date.Value.Year) -1;
                VM.Add(modelo);
            }

            return PartialView(VM);
        }

        
        public JsonResult SoloParaPostas(int afiliadoId, int MeetId)
        {
            string resultado = "Ya estaba inscrito anteriormente";
            
            Inscripciones inscripciones = db.Inscripciones.Find(afiliadoId);
            atletas atleta = db.atletas.Where(x => x.Reg_no == inscripciones.DNI && x.Meetid == MeetId) .FirstOrDefault();
            if(atleta == null)
            {
                IngresarDeportista(afiliadoId, MeetId, "false");
                resultado = "Se agregpo para postas";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
    }
}