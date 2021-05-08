
using InscripcionATorneos.Helpers;
using Microsoft.EntityFrameworkCore;
using NuevaInscripcionATorneos.Data.Modelos;
using NuevaInscripcionATorneos.Helpers;
using NuevaInscripcionATorneos.Models;
using NuevaInscripcionATorneos.SessionState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace NuevaInscripcionATorneos.Data
{
    public class ServicePrincipal
    { 

       
        private readonly DB_9B1F4C_comentariosContext db;
        public ServicePrincipal(DB_9B1F4C_comentariosContext context)
        {
            db = context;
        }

        public async Task<List<Club>> clubes()
        {
            return await db.Club.ToListAsync();
        }
        public async Task<Usuario> GetLogin(string nombre, string pass)
        {
            Usuario usuario = new Usuario();
            try
            {
                usuario = await db.Usuario.Where(x => x.Usuario1 == nombre && x.Password == pass).Include(x=>x.Club).FirstOrDefaultAsync();

            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
            }
            return usuario;
        }


        public async Task<List<TorneoViewModel>> Torneos(UsuarioState usuariostate)
        {
            List<TorneoViewModel> VM = new List<TorneoViewModel>();
            DateTime hoy = ConvertirAPeru.ToPeru(DateTime.Now);

            List<SetupTorneo> setups = await db.SetupTorneo.Where(x => x.Meet.EntryDeadline> hoy).Include(x=>x.Meet).OrderByDescending(x => x.Meet.EntryDeadline).Take(8).ToListAsync();
            foreach (var setup in setups)
            {
                DateTime dt = setup.Meet.EntryDeadline ?? ConvertirAPeru.ToPeru(DateTime.UtcNow);
                dt = dt.AddDays(1);
                DateTime dtNow = ConvertirAPeru.ToPeru(DateTime.UtcNow);
                TimeSpan result = dt.Subtract(dtNow);
                int seconds = Convert.ToInt32(result.TotalSeconds);
                TorneoViewModel torneoviewmodel = new TorneoViewModel
                {
                    torneo = setup,
                    diferencia = seconds,
                    FechaFin = dt,
                    Tieneinscritos = false,
                    Start = setup.Meet.MeetStart ?? dtNow,
                    Masters = setup.Masters,
                };
                torneoviewmodel.Tieneinscritos = db.Equipos.Any(x => x.MeetId == torneoviewmodel.torneo.Meetid && x.TeamAbbr == usuariostate.Iniciales);
                VM.Add(torneoviewmodel);
            }
            return VM;
        }

        public async Task<List<NadadorParaInscribir>> GetNadadoresParaInscribirlo(string filtro)
        {

            var query = db.Inscripciones.AsQueryable();
            query = query.Where(x => x.DniNavigation.ApellidoPaterno.Contains(filtro) || x.DniNavigation.ApellidoMaterno.Contains(filtro) || x.DniNavigation.Dni.Contains(filtro));

           var ListadoNadadores = await query.Include(x => x.DniNavigation).ToListAsync();

            List<NadadorParaInscribir> listado = new List<NadadorParaInscribir>();
            foreach(var nadador in ListadoNadadores)
            {
               
                NadadorParaInscribir nadadorParaInscribir = new NadadorParaInscribir(nadador.Dni, nadador.DniNavigation.Nombre, nadador.DniNavigation.ApellidoPaterno,
                    nadador.DniNavigation.ApellidoMaterno, nadador.DniNavigation.FechaDeNacimiento, nadador.DniNavigation.Sexo, nadador.InscripcionId, nadador.EstadoId);
                listado.Add(nadadorParaInscribir);
            }
            return listado;
        }


        public async Task<List<Atletas>> GetYaInscritos(UsuarioState usuariostate, int Meetid)
        {
            
            Equipos equipo = await db.Equipos.Where(x => x.TeamAbbr == usuariostate.Iniciales).FirstOrDefaultAsync();
            List<Atletas> atletasDeEsteTorneo = new List<Atletas>();
            if (equipo != null)
            {
               atletasDeEsteTorneo = await db.Atletas.Where(x => x.Meetid == Meetid && x.TeamNo == equipo.TeamNo).ToListAsync();
            }
                     
            return atletasDeEsteTorneo;
        }

        
        public async Task< SetupTorneo> GetSetupTorneo(int MeetId)
        {
           
            SetupTorneo setup = await db.SetupTorneo.Where(x => x.Meetid == MeetId).Include(x=>x.Meet).FirstOrDefaultAsync();

           
            return setup;
        }
        public async Task<ListadoInscritoViewModel> ListarPruebasParaElNadador(int MeetId, int afiliadoId, SetupTorneo setup)
        {
            ListadoInscritoViewModel VM = new ListadoInscritoViewModel();
       

                
            int annoActual = DateTime.Now.Year - 1; /*Para calcular la edad al año pasado*/

              
            List<SessionItem> ListadoDeSessionItem =await  db.SessionItem.Where(x => x.Meetid == MeetId).ToListAsync();
            List<int> PruebasYaInscritas = new List<int>();
            Results resultado = new Results();

            DateTime fecha = setup.Meet.EntryDeadline ?? DateTime.Now;
            DateTime haceunanno = setup.Meet.EntryEligibilityDate ?? fecha.AddYears(-1).AddDays(-15);

            List<MarcasMinimas> MarcasMinimasDelMeet = new List<MarcasMinimas>();
            
                MarcasMinimasDelMeet = await db.MarcasMinimas.Where(x => x.MeetId == MeetId).ToListAsync();
            
            string stroke = "Free";
            //Hallo el tipo de piscina en el que se nadará

            int NumeroSesiones = setup.Meet.Sesion.OrderByDescending(x => x.SessionId).Select(x => x.SessDay).FirstOrDefault() ?? 1;
            int PruebasXtorneo = setup.PruebasXtorneo;
            int pruebasConMarca = 0;

            //Inicio de variable del modelo
            VM = new ListadoInscritoViewModel
            {
                afiliado =await db.Inscripciones.Where(x => x.InscripcionId == afiliadoId).FirstOrDefaultAsync(),
                listaDeEventos = new List<InscritoViewModel>(),
                Sesiones = new List<SesionViewModel>(),
                PruebasTotales = PruebasXtorneo,
                Piscina = "",
                PruebasInscritasSinMarca = 0,
                SinMarca = 1,
                MeetId = MeetId,
            };
            


            //Todos los resultados del nadador en un año
            List<Results> resultados =await  db.Results
                       .Where(x => x.AthleteNavigation.IdNo == VM.afiliado.Dni && x.MeetNavigation.Start > haceunanno && x.Score != "" && x.Nt == 0)
                       .Include(x=>x.MeetNavigation)
                       .ToListAsync();




            if (setup.Meet.MeetCourse == 1)
            {
                VM.Piscina = "L";
            }
            else
            {
                VM.Piscina = "S";
            }

            //1 .- buscar al afiliado en la bd de inscripciones, sirve para saber si ya está inscrito
            Atletas atleta =await  db.Atletas.Where(x => x.RegNo == VM.afiliado.Dni && x.Meetid == MeetId).FirstOrDefaultAsync(); // en la BD de inscripciones
            if (atleta != null)
            {
                VM.YaestaInscrito = db.Entradas.Any(x => x.MeetId == MeetId && x.AthNo == atleta.AthNo);
            }
            else
            {
                VM.YaestaInscrito = false;
            }


            //2 .- Buscar los eventos que podría nadar el afiliado
            int edad = annoActual - VM.afiliado.DniNavigation.FechaDeNacimiento.Year;
            List<Eventos> eventosDelNadador =await  db.Eventos
            .Where(x => x.MeetId == MeetId && x.LowAge <= edad && x.HighAge >= edad && x.EventGender == VM.afiliado.DniNavigation.Sexo && x.IndRel == "i")
            .OrderBy(x => x.EventNo).ToListAsync();

            foreach (Eventos evento in eventosDelNadador)
            {
                InscritoViewModel NadadorAInscribir = new InscritoViewModel
                {
                    evento = evento,
                    sesion = ListadoDeSessionItem.Where(x => x.EventPtr == evento.EventPtr).Select(x => x.SessPtr).FirstOrDefault() ?? 0,
                    MMCorta = 0,
                    MMLarga = 0,
                    Clase="",
                };

                if (!setup.Debutantes && setup.SinMarca != 1)
                {
                    NadadorAInscribir = ConseguirMarcaDelEvento(NadadorAInscribir, setup, MarcasMinimasDelMeet, evento, edad);
                }


                if (atleta != null)
                {
                    NadadorAInscribir.entradayainscrita = db.Entradas.Any(x => x.MeetId == MeetId && x.AthNo == atleta.AthNo);
                   
                }


                //Para poder hacer la búsqueda en resultados y mostrar el nombre de la prueba en la web
                switch (evento.EventStroke)
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
                string distancia = evento.EventDist.ToString();

                NadadorAInscribir.MMCortaString = ConvertirAPeru.ConvertirDeSegundosATiempo(NadadorAInscribir.MMCorta);
                NadadorAInscribir.MMLargaString = ConvertirAPeru.ConvertirDeSegundosATiempo(NadadorAInscribir.MMLarga);

                Results resultadoenlarga = resultados
                       .Where(x => x.Distance == distancia && x.Stroke == stroke && x.Course == "L")
                       .OrderBy(x => x.Score).FirstOrDefault();
                Results resultadoencorta = resultados
                       .Where(x => x.Distance == distancia && x.Stroke == stroke && x.Course == "S")
                       .OrderBy(x => x.Score).FirstOrDefault();


                // Ver si cumple la marca mínima, primero la de la competencia, usando LSY y SLY
                string CursoPiscina = setup.Meet.CourseOrder;
                NadadorAInscribir = BuscarMejorTiempoDelEvento(NadadorAInscribir, setup, resultadoenlarga, resultadoencorta, evento);
                //NadadorAInscribir = GetMejortiempoDeLaPrueba(NadadorAInscribir, resultadoenlarga, resultadoencorta, CursoPiscina, setup);
                if (NadadorAInscribir.Cumple)
                {
                    pruebasConMarca += 1;
                }
                VM.listaDeEventos.Add(NadadorAInscribir);
            }

            //7 .- ahora veo las sesiones y datos para mostrarlos al final de la página
            List<Sesion> sesiones = await db.Sesion.Where(x => x.MeetId == MeetId).ToListAsync();
            for (int i = 0; i < sesiones.Count(); i++)
            {
                SesionViewModel sesionVM = new SesionViewModel
                {
                    Maximopermitido = sesiones[i].SessEntrymaxind ?? 0,
                    Sesion = i + 1,
                    Inscritos = 0,
                    Pendiente = sesiones[i].SessEntrymaxind ?? 0,
                };
                VM.Sesiones.Add(sesionVM);
            }


            //8 .- ver las pruebas inscritas de este deportista,  busco si está inscrito,
            // luego veo por cada evento si la prueba ya está inscrita y la sumo 1 a la inscripción de la sesión

            if (VM.YaestaInscrito)
            {
                PruebasYaInscritas =await   db.Entradas.Where(x => x.MeetId == MeetId && x.AthNo == atleta.AthNo).Select(x => x.EventPtr ?? 0).ToListAsync();
                if (PruebasYaInscritas.Count() > 0)
                {
                    foreach (var numeroDeEvento in VM.listaDeEventos)
                    {
                        if (PruebasYaInscritas.Any(x => x == numeroDeEvento.evento.EventPtr))
                        {
                            numeroDeEvento.entradayainscrita = true;
                            numeroDeEvento.Clase = "selected";
                            int estasesion = numeroDeEvento.sesion;
                            SesionViewModel sesionVM = VM.Sesiones.Where(x => x.Sesion == estasesion).FirstOrDefault();
                            sesionVM.Inscritos += 1;
                            sesionVM.Pendiente -= 1;

                            if (!numeroDeEvento.Cumple)
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

          
            return VM;
        }

        public  InscritoViewModel ConseguirMarcaDelEvento(InscritoViewModel NadadorAInscribir, SetupTorneo setup, List<MarcasMinimas> MarcasMinimasDelTorneo, Eventos evento, int edad)
        {

            List<MarcasMinimas> Marcas = MarcasMinimasDelTorneo.
                Where(x => x.TagDist == evento.EventDist && x.TagStroke == evento.EventStroke && x.TagCourse == "L" && x.LowAge <= edad && x.HighAge >= edad && x.TagGender == evento.EventGender && x.MeetId == evento.MeetId)
               .OrderByDescending(x => x.TagPtr)
               .ToList();

            if (Marcas.Count() > 0)
            {
                NadadorAInscribir.MMLarga = SeleccionarLaMejorMM(Marcas);
            }
            else
            {
                if (Marcas.Count > 0)
                {
                    NadadorAInscribir.MMLarga = Marcas[0].TagTime ?? 0;
                }
                else
                {
                    NadadorAInscribir.MMLarga = 0;
                }
            }
            Marcas = MarcasMinimasDelTorneo.
                Where(x => x.TagDist == evento.EventDist && x.TagStroke == evento.EventStroke && x.TagCourse == "S" && x.LowAge <= edad && x.HighAge >= edad && x.TagGender == evento.EventGender && x.MeetId == evento.MeetId)
               .OrderByDescending(x => x.TagPtr)
               .ToList();

            if (Marcas.Count() > 0)
            {
                NadadorAInscribir.MMCorta = SeleccionarLaMejorMM(Marcas);
            }
            return NadadorAInscribir;

        }

        public float SeleccionarLaMejorMM(List<MarcasMinimas> Marcas)
        {
            int contador = 0;
            Dictionary<int, int> diferencia = new Dictionary<int, int>();
            foreach (var item in Marcas)
            {
                diferencia.Add(contador, (item.HighAge ?? 0) + (item.LowAge ?? 0));
                contador += 1;

            }
            int menordiferencia = diferencia.Min(x => x.Value);
            int posicion = diferencia.FirstOrDefault(x => x.Value == menordiferencia).Key;
            float mejorMM = Marcas[posicion].TagTime ?? 0;
            return mejorMM;
        }


        public InscritoViewModel BuscarMejorTiempoDelEvento(InscritoViewModel NadadorAInscribir, SetupTorneo setup, Results resultadoenlarga, Results resultadoencorta, Eventos evento)
        {
            string CursoPiscina = setup.Meet.CourseOrder.Substring(0, 1);
            string CumpleEnCurso = "";
            float RLarga = 0;
            float RCorta = 0;
            double factor = 0;

            if (resultadoenlarga != null)
            {
                factor = resultadoenlarga.Prueba.FactorF ?? 0;
            }
            else if (resultadoencorta != null)
            {
                factor = resultadoencorta.Prueba.FactorM ?? 0;

            }


            // 1.- convertir los tiempos a segundos
            if (resultadoenlarga != null && resultadoenlarga.Score != null)
            {
                RLarga = ConvertirAPeru.ConvertirDeTiempoASegundos(resultadoenlarga.Score);
            }
            if (resultadoencorta != null && resultadoencorta.Score != null)
            {
                RCorta = ConvertirAPeru.ConvertirDeTiempoASegundos(resultadoencorta.Score);
            }

            // 2.- ver si cumple la marca dependiendo si busca marca mínima o marca máxima
            if (setup.UsaMarcaMaxima)
            {
                CumpleEnCurso = VerSiCumpleMarcaMaxima(NadadorAInscribir, setup, RLarga, RCorta, factor);
            }
            else if (!setup.PermiteSinMarca) //revisar que es sin marca Creo que esto es para ver si el torneo no tiene marca mínima ni máxima
            {
                CumpleEnCurso = VerSiCumpleMarcaMinima(NadadorAInscribir, setup, RLarga, RCorta, factor);
            }
            else if (setup.PermiteSinMarca)
            {

                CumpleEnCurso = VerSiCumpleSinMarca(NadadorAInscribir, setup, RLarga, RCorta, factor);
            }

            // 3.- Luego buscar el torneo donde hizo la marca
            if (CumpleEnCurso == "L")
            {
                NadadorAInscribir.torneo = resultadoenlarga.MeetNavigation.Mname;
                NadadorAInscribir.tiempo = resultadoenlarga.Score;
                NadadorAInscribir.segundos = ConvertirAPeru.ConvertirDeTiempoASegundos(NadadorAInscribir.tiempo);
                NadadorAInscribir.Cumple = true;
                NadadorAInscribir.PiscinaDelTiempo = "L";
            }
            else if (CumpleEnCurso == "S")
            {
                NadadorAInscribir.torneo = resultadoencorta.MeetNavigation.Mname;
                NadadorAInscribir.tiempo = resultadoencorta.Score;
                NadadorAInscribir.segundos = ConvertirAPeru.ConvertirDeTiempoASegundos(NadadorAInscribir.tiempo);
                NadadorAInscribir.Cumple = true;
                NadadorAInscribir.PiscinaDelTiempo = "S";
            }
            else
            {
                if (NadadorAInscribir.MejorCursoDePiscina == "L")
                {
                    NadadorAInscribir.torneo = resultadoenlarga.MeetNavigation.Mname;
                    NadadorAInscribir.tiempo = resultadoenlarga.Score;
                    NadadorAInscribir.segundos = ConvertirAPeru.ConvertirDeTiempoASegundos(NadadorAInscribir.tiempo);
                    NadadorAInscribir.Cumple = false;
                    NadadorAInscribir.PiscinaDelTiempo = "L";
                }
                else if (NadadorAInscribir.MejorCursoDePiscina == "S")
                {
                    NadadorAInscribir.torneo = resultadoencorta.MeetNavigation.Mname;
                    NadadorAInscribir.tiempo = resultadoencorta.Score;
                    NadadorAInscribir.segundos = ConvertirAPeru.ConvertirDeTiempoASegundos(NadadorAInscribir.tiempo);
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

                if (setup.PermiteSinMarca)
                {
                    NadadorAInscribir.Cumple = true;
                }
            }
            return NadadorAInscribir;
        }

        public InscritoViewModel BuscarMejorTiempoDelEventoMaster(InscritoViewModel NadadorAInscribir, SetupTorneo setup, Resultsmasters resultadoenlarga, Resultsmasters resultadoencorta, Eventos evento)
        {
            string CursoPiscina = setup.Meet.CourseOrder.Substring(0, 1);
          

            for(int i = 0; i<3; i++)
            {
                string Curso = setup.Meet.CourseOrder.Substring(i, 1);
                if (Curso == "L" )
                {
                    if (resultadoenlarga != null)
                    {
                        NadadorAInscribir.torneo = resultadoenlarga.MeetNavigation.Mname;
                        NadadorAInscribir.tiempo = resultadoenlarga.Score;
                        NadadorAInscribir.segundos = ConvertirAPeru.ConvertirDeTiempoASegundos(NadadorAInscribir.tiempo);
                        NadadorAInscribir.Cumple = true;
                        NadadorAInscribir.PiscinaDelTiempo = "L";
                        break;
                    }
                    else if(resultadoencorta != null)
                    {
                        NadadorAInscribir.torneo = resultadoencorta.MeetNavigation.Mname;
                        NadadorAInscribir.tiempo = resultadoencorta.Score;
                        NadadorAInscribir.segundos = ConvertirAPeru.ConvertirDeTiempoASegundos(NadadorAInscribir.tiempo);
                        NadadorAInscribir.Cumple = true;
                        NadadorAInscribir.PiscinaDelTiempo = "S";
                        break;
                    }
                }
                else if (Curso =="S" )
                {
                    if (resultadoencorta != null)
                    {
                        NadadorAInscribir.torneo = resultadoencorta.MeetNavigation.Mname;
                        NadadorAInscribir.tiempo = resultadoencorta.Score;
                        NadadorAInscribir.segundos = ConvertirAPeru.ConvertirDeTiempoASegundos(NadadorAInscribir.tiempo);
                        NadadorAInscribir.Cumple = true;
                        NadadorAInscribir.PiscinaDelTiempo = "S";
                        break;
                    }
                    else if (resultadoenlarga != null)
                    {
                        NadadorAInscribir.torneo = resultadoenlarga.MeetNavigation.Mname;
                        NadadorAInscribir.tiempo = resultadoenlarga.Score;
                        NadadorAInscribir.segundos = ConvertirAPeru.ConvertirDeTiempoASegundos(NadadorAInscribir.tiempo);
                        NadadorAInscribir.Cumple = true;
                        NadadorAInscribir.PiscinaDelTiempo = "L";
                        break;
                    }
                   
                }
                else
                {
                    NadadorAInscribir.torneo = "Sin torneo";
                    NadadorAInscribir.tiempo = "0:00.00";
                    NadadorAInscribir.segundos = 0;
                    NadadorAInscribir.Cumple = true;
                }
            }

         
           
            return NadadorAInscribir;
        }

        public string VerSiCumpleSinMarca(InscritoViewModel NadadorAInscribir, SetupTorneo setup, float RLarga, float RCorta, double factor)
        {
            string CursoPiscina = setup.Meet.CourseOrder.Substring(0, 1);


            if (CursoPiscina == "L")
            {
                RCorta = ConvertirLaMarcaEntrePiscinas(RCorta, factor, CursoPiscina);
            }
            else
            {
                RLarga = ConvertirLaMarcaEntrePiscinas(RLarga, factor, CursoPiscina);
            }
            if ((RLarga < RCorta && RLarga > 0) || (RLarga > 0 && RCorta == 0))
            {
                return "L";
            }
            else if ((RLarga > RCorta && RCorta > 0) || (RCorta > 0 && RLarga == 0))
            {
                return "S";
            }

            return "";
        }

        public string VerSiCumpleMarcaMinima(InscritoViewModel NadadorAInscribir, SetupTorneo setup, float RLarga, float RCorta, double factor)
        {
            string CursoPiscina = setup.Meet.CourseOrder.Substring(0, 1);
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

                if ((RLarga < RCorta && RLarga > 0) || (RLarga > 0 && RCorta == 0)) // si no cumple ninguna de las dos al menos trataré de colocar el mejor curso donde buscaré su tiempo
                {
                    NadadorAInscribir.MejorCursoDePiscina = "L";
                }
                else if ((RCorta < RLarga && RCorta > 0) || (RCorta > 0 && RLarga == 0))
                {
                    NadadorAInscribir.MejorCursoDePiscina = "S";
                }
                return "";
            }

        }
        public string VerSiCumpleMarcaMaxima(InscritoViewModel NadadorAInscribir, SetupTorneo setup, float RLarga, float RCorta, double factor)
        {
            string CursoPiscina = setup.Meet.CourseOrder;
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
                else if (cumplecorta)
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

        public async Task GrabarPruebasParaElNadador(List<InscritoViewModel> listado, int MeetId, int InscripcionId,  bool YaestaInscrito, string iniciales, bool masters)
        {
           //Usuario usuario = Session["Usuario"] as Usuario;
           
  
            SetupTorneo setup =await db.SetupTorneo.Include(x=>x.Meet).FirstOrDefaultAsync(x => x.Meetid == MeetId);
            string Piscina = setup.Meet.CourseOrder.Substring(0, 1);
            //Por cada inscripcion en el nuevo listado busco al atleta en la tabla atletas, en otras palabras, para saber si ya está inscrito
            Inscripciones afiliado = await db.Inscripciones.Where(x => x.InscripcionId == InscripcionId).Include(x => x.DniNavigation).FirstOrDefaultAsync(); 
            Atletas atleta =await db.Atletas.Where(x => x.RegNo == afiliado.Dni && x.Meetid == MeetId).FirstOrDefaultAsync();
            List<Pruebas> pruebas =await db.Pruebas.ToListAsync();
            List<Eventos> eventos =await db.Eventos.Where(x => x.MeetId == MeetId).ToListAsync();
           
            try
            {
                int ath_No =await IngresarDeportista(InscripcionId, MeetId, YaestaInscrito, iniciales, masters);


                List<Entradas> EntradasActuales =await db.Entradas.Where(x => x.AthNo == ath_No).ToListAsync();
                foreach (Entradas entrada in EntradasActuales)
                {
                    db.Entradas.Remove(entrada);                   
                }
              await  db.SaveChangesAsync();
                foreach (var inscrito in listado)
                {
                    string course = inscrito.PiscinaDelTiempo;
                    if (course == null)
                    {
                        course = Piscina;
                    }

                    Entradas entrada = new Entradas
                    {
                        EventPtr = inscrito.evento.EventNo ?? 0,
                        AthNo = ath_No,
                        ActSeedCourse = course,
                        ActualSeedTime =ConvertirAPeru.ConvertirDeTiempoASegundos( inscrito.tiempo) ,
                        ConvSeedCourse = Piscina,

                        ScrStat = false,
                        AltStat = false,
                        BonusEvent = false,
                        DivNo = 0,
                        SeedPlace = 0,
                        MeetId = MeetId,
                    };
                    if (Piscina == course)
                    {
                        entrada.ConvSeedTime = entrada.ActualSeedTime;
                    }
                    else
                    {
                        Eventos evento = eventos.Where(x => x.EventPtr == entrada.EventPtr).FirstOrDefault();
                        Pruebas prueba = pruebas.Where(x => x.EstiloMeet == evento.EventStroke && x.Distancia == evento.EventDist).FirstOrDefault();
                        entrada.ConvSeedTime = ConvertirLaMarcaEntrePiscinas(entrada.ActualSeedTime??0, prueba.FactorF, course);
                    }

                    db.Entradas.Add(entrada);
                }

               await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                string error = "";
            }
         
        }


        public async Task<int> IngresarDeportista(int id, int MeetId, bool YaestaInscrito, string iniciales, bool masters)
        {
            Inscripciones afiliado =await db.Inscripciones
                .Include(x=>x.DniNavigation)
                .Include(x=>x.Club)
                .FirstOrDefaultAsync(x => x.InscripcionId == id);
            Atletas atleta =await db.Atletas.Where(x => x.RegNo == afiliado.Dni && x.Meetid == MeetId).FirstOrDefaultAsync();
            if (!YaestaInscrito)
            {
                Equipos equipo = new Equipos();
                Club club = new Club();
                if (masters)
                {
                    equipo =await db.Equipos.Where(x => x.TeamAbbr == iniciales && x.MeetId == MeetId).FirstOrDefaultAsync();
                    club =await db.Club.FirstOrDefaultAsync(x => x.Iniciales == iniciales);
                }
                else
                {
                    equipo =await db.Equipos.Where(x => x.TeamAbbr == afiliado.Club.Iniciales && x.MeetId == MeetId).FirstOrDefaultAsync();
                    club =await db.Club.FirstOrDefaultAsync(x => x.ClubId == afiliado.Club.ClubId);
                }
                
                if (equipo == null)
                {
                    
                  await  GrabarClub(club, MeetId);
                }

                int annoActual = DateTime.Now.Year;

                short edad = Convert.ToInt16(annoActual - afiliado.DniNavigation.FechaDeNacimiento.Year - 1);
                if (masters)
                {
                    edad++;
                }
                if (atleta == null)
                {
                    Atletas ultimocompetidor = await db.Atletas.OrderByDescending(x => x.CompNo).FirstOrDefaultAsync();
                    try
                    {
                        atleta = new Atletas();


                        atleta.AthNo = 0;
                        if (afiliado.DniNavigation.ApellidoPaterno.Length > 20)
                        {
                            atleta.LastName = afiliado.DniNavigation.ApellidoPaterno.Substring(0, 20);
                        }
                        else
                        {
                            atleta.LastName = afiliado.DniNavigation.ApellidoPaterno;
                        }

                        if (afiliado.DniNavigation.Nombre.Length > 20)
                        {
                            atleta.FirstName = afiliado.DniNavigation.Nombre.Substring(0, 20);
                        }
                        else
                        {
                            atleta.FirstName = afiliado.DniNavigation.Nombre;
                        }

                        atleta.AthSex = afiliado.DniNavigation.Sexo;
                        atleta.BirthDate = afiliado.DniNavigation.FechaDeNacimiento;
                        atleta.TeamNo = equipo.TeamNo;
                        atleta.AthAge = edad;
                        atleta.RegNo = afiliado.Dni;

                        atleta.DisabSbcode = 0;
                        atleta.DisabSmcode = 0;
                        atleta.DisabScode = 0;
                        atleta.MastersRegVerified = false;
                        atleta.Meetid = MeetId;
                        atleta.TeamId = equipo.TeamId;

                        if (ultimocompetidor == null)
                        {
                            atleta.AthNo = 1;
                            atleta.CompNo = 1;
                        }
                        else
                        {
                            atleta.AthNo = ultimocompetidor.AthNo + 1;
                            atleta.CompNo = ultimocompetidor.CompNo + 1;
                        }
                        db.Atletas.Add(atleta);
                     await   db.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        string mensaje = ex.Message;
                    }
                }
            }
            else
            {
              await  ActualizarNadador(afiliado, atleta);
            }
            return atleta.AthNo;

        }

    
        public async Task ActualizarNadador(Inscripciones inscripcion, Atletas atleta)
        {
            atleta.AthSex = inscripcion.DniNavigation.Sexo;
            atleta.FirstName = inscripcion.DniNavigation.Nombre;
            atleta.LastName = inscripcion.DniNavigation.ApellidoPaterno;
            atleta.BirthDate = inscripcion.DniNavigation.FechaDeNacimiento;

            if (atleta.FirstName.Length > 20)
            {
                atleta.FirstName = atleta.FirstName.Substring(0, 20);
            }


            if (atleta.LastName.Length > 20)
            {
                atleta.LastName = atleta.LastName.Substring(0, 20);
            }

          await  db.SaveChangesAsync();
        }

        public async Task GrabarClub(Club club, int MeetId)
        {
            //Afiliacion afiliacion = af.Afiliacion.Where(x => x.DNI == afiliado.DNI).OrderByDescending(x => x.AfiliacionID).FirstOrDefault();   

            Equipos ultimoequipo =await db.Equipos.OrderByDescending(x => x.TeamNo).FirstOrDefaultAsync();
            Equipos equipo = new Equipos
            {
                TeamName = club.NombreClub,
                TeamShort = club.NombreUsuario,
                TeamAbbr = club.Iniciales,
                TeamDiv = 0,
                TeamRegion = 0,
                TeamCntry = "PER",
                TeamNoPoints = false,
                TeamSelected = false,
                NoTeamSurcharge = false,
                NoFacilitySurcharge = false,
                NoAthleteSurcharge = false,
                NoRelayOnlySurcharge = false,
                MeetId = MeetId
            };
            if (equipo.TeamName.Length > 30)
            {
                equipo.TeamName = equipo.TeamName.Substring(0, 30);

            }
            if (equipo.TeamShort.Length > 15)
            {
                equipo.TeamShort = equipo.TeamShort.Substring(0, 15);

            }

            if (ultimoequipo == null)
            {
                equipo.TeamNo = 1;
            }
            else
            {
                equipo.TeamNo = ultimoequipo.TeamNo + 1;
            }

            db.Equipos.Add(equipo);
       await     db.SaveChangesAsync();

        }


        public async Task<ListadoInscritoViewModel> ListarPruebasParaElNadadorMaster(int MeetId, int afiliadoId,  SetupTorneo setup)
        {

            //Iniciando las variables a usar más adelante
            List<SessionItem> ListadoDeSessionItem =await db.SessionItem.Where(x => x.Meetid == MeetId).ToListAsync();
            List<int> PruebasYaInscritas = new List<int>();
            Resultsmasters resultado = new Resultsmasters();

            DateTime fecha = setup.Meet.EntryDeadline ?? DateTime.Now;
            DateTime haceunanno = setup.FechaMarcas.AddYears(-1);                              //  **********************************  IMPORTANTE, QUITAR EL AÑO QUE LE AGREGUÉ PARA HACER LAS PRUEBAS ***********************

            string stroke = "Free";
            //Hallo el tipo de piscina en el que se nadará

            int NumeroSesiones = setup.Meet.Sesion.OrderByDescending(x => x.SessionId).Select(x => x.SessDay).FirstOrDefault() ?? 1;
            int pruebasXtorneo = setup.PruebasXtorneo;

            //Inicio de variable del modelo
            ListadoInscritoViewModel VM = new ListadoInscritoViewModel
            {
                afiliado = db.Inscripciones.Where(x => x.InscripcionId == afiliadoId).FirstOrDefault(),
                listaDeEventos = new List<InscritoViewModel>(),
                Sesiones = new List<SesionViewModel>(),
                PruebasTotales = pruebasXtorneo,
                Piscina = "",
                PruebasInscritasSinMarca = 0,
                SinMarca = 0,
                MeetId = MeetId,
                
            };
           
            //Todos los resultados del nadador en un año
            List<Resultsmasters> resultados =await db.Resultsmasters
                       .Where(x => x.AthleteNavigation.IdNo == VM.afiliado.Dni && x.MeetNavigation.Start > haceunanno && x.Score != "" && x.Nt == 0)
                       .Include(x => x.MeetNavigation)
                       .ToListAsync();

            if (setup.Meet.MeetCourse == 1)
            {
                VM.Piscina = "L";
            }
            else
            {
                VM.Piscina = "S";
            }

            //1 .- buscar al afiliado en la bd de inscripciones, sirve para saber si ya está inscrito
            Atletas atleta =await db.Atletas.Where(x => x.RegNo == VM.afiliado.Dni && x.Meetid == MeetId).FirstOrDefaultAsync(); // en la BD de inscripciones
            if (atleta != null)
            {
                VM.YaestaInscrito =await db.Entradas.AnyAsync(x => x.MeetId == MeetId && x.AthNo == atleta.AthNo);
            }
            else
            {
                VM.YaestaInscrito = false;
            }

            List<Eventos> eventosDelNadador =await db.Eventos
            .Where(x => x.MeetId == MeetId && x.EventGender == VM.afiliado.DniNavigation.Sexo && x.IndRel == "i")
            .OrderBy(x => x.EventNo).ToListAsync();

            foreach (Eventos evento in eventosDelNadador)
            {
                InscritoViewModel NadadorAInscribir = new InscritoViewModel
                {
                    evento = evento,
                    sesion = ListadoDeSessionItem.Where(x => x.EventPtr == evento.EventPtr).Select(x => x.SessPtr).FirstOrDefault() ?? 0,
                    MMCorta = 0,
                    MMLarga = 0,
                    Clase = "",
                };

                if (atleta != null)
                {
                    NadadorAInscribir.entradayainscrita =await db.Entradas.AnyAsync(x => x.MeetId == MeetId && x.AthNo == atleta.AthNo);
                }

                //Para poder hacer la búsqueda en resultados y mostrar el nombre de la prueba en la web
                switch (evento.EventStroke)
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
                string distancia = evento.EventDist.ToString();

                Resultsmasters resultadoenlarga = resultados
                       .Where(x => x.Distance == distancia && x.Stroke == stroke && x.Course == "L")
                       .OrderBy(x => x.Score).FirstOrDefault();
                Resultsmasters resultadoencorta = resultados
                       .Where(x => x.Distance == distancia && x.Stroke == stroke && x.Course == "S")
                       .OrderBy(x => x.Score).FirstOrDefault();

                // Ver si cumple la marca mínima, primero la de la competencia, usando LSY y SLY
                string CursoPiscina = setup.Meet.CourseOrder;
                

                NadadorAInscribir = BuscarMejorTiempoDelEventoMaster(NadadorAInscribir, setup, resultadoenlarga, resultadoencorta, evento);            
                VM.listaDeEventos.Add(NadadorAInscribir);
            }

            //7 .- ahora veo las sesiones y datos para mostrarlos al final de la página
            List<Sesion> sesiones =await db.Sesion.Where(x => x.MeetId == MeetId).ToListAsync();
            for (int i = 0; i < sesiones.Count(); i++)
            {
                SesionViewModel sesionVM = new SesionViewModel
                {
                    Maximopermitido = sesiones[i].SessEntrymaxind ?? 0,
                    Sesion = i + 1,
                    Inscritos = 0,
                    Pendiente = sesiones[i].SessEntrymaxind ?? 0,
                };
                VM.Sesiones.Add(sesionVM);
            }


            //8 .- ver las pruebas inscritas de este deportista,  busco si está inscrito,
            // luego veo por cada evento si la prueba ya está inscrita y la sumo 1 a la inscripción de la sesión

            if (VM.YaestaInscrito)
            {
                PruebasYaInscritas =await db.Entradas.Where(x => x.MeetId == MeetId && x.AthNo == atleta.AthNo).Select(x => x.EventPtr ?? 0).ToListAsync();
                if (PruebasYaInscritas.Count() > 0)
                {
                    foreach (var numeroDeEvento in VM.listaDeEventos)
                    {
                        if (PruebasYaInscritas.Any(x => x == numeroDeEvento.evento.EventPtr))
                        {
                            numeroDeEvento.entradayainscrita = true;
                            int estasesion = numeroDeEvento.sesion;
                            SesionViewModel sesionVM = VM.Sesiones.Where(x => x.Sesion == estasesion).FirstOrDefault();
                            sesionVM.Inscritos += 1;
                            sesionVM.Pendiente -= 1;
                            VM.PruebasInscritas += 1;
                        }
                        else
                        {
                            numeroDeEvento.entradayainscrita = false;
                        }
                    }
                }
            }
            
            return VM;
        }


    }



}
