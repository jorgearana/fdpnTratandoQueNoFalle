
using FDPN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InscripcionNatacion.Helpers;
using InscripcionNatacion.ViewModels.Home;
using InscripcionNatacion.ViewModels.OtraInscripcion;
using System.Web.Script.Serialization;
using InscripcionNatacion.ViewModels.OtraInscripcion.Polo;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Web.Helpers;

namespace InscripcionNatacion.Controllers
{
    public class OtroTorneoController : BASEController
    {
        Repository repository = new Repository();
        ConvertirAPeru convertidor = new Helpers.ConvertirAPeru();
        int AnnoMaximo;
        int AnnoMinimo;

        // GET: OtroTorneo
        //************************Esto es para ver si se graba en todas las pcs
        public ActionResult Index(int disciplina)
        {
            DateTime hoy = convertidor.ToPeru(DateTime.UtcNow);
            List<OtroTorneo> Torneos = db.OtroTorneo.Where(x => x.DisciplinaId == disciplina).ToList();
            List<OtroTorneoViewModel> VM = new List<OtroTorneoViewModel>();
            foreach (var torneo in Torneos)
            {
                DateTime dt = torneo.FechaCierre;
                dt = dt.AddDays(1);
                DateTime dtNow = convertidor.ToPeru(DateTime.UtcNow);
                TimeSpan result = dt.Subtract(dtNow);
                int seconds = Convert.ToInt32(result.TotalSeconds);
                OtroTorneoViewModel torneoviewmodel = new OtroTorneoViewModel
                {
                    torneo = torneo,
                    diferencia = seconds,
                    FechaFin = dt,
                    Tieneinscritos = false,
                };
                VM.Add(torneoviewmodel);
            }

            return PartialView(VM);
        }

        

        public ActionResult HacerIncscripciones(int TorneoId)
        {
            OtroSetupTorneo setup = db.OtroSetupTorneo.Where(x => x.TorneoId == TorneoId).FirstOrDefault();
            switch(setup.OtroTorneo.DisciplinaId)
            {
                case 2:
                    return RedirectToAction("IndexPolo", new { setupid = setup.SetupId });
                case 3:
                    return RedirectToAction("Indexsincro", new { setupid = setup.SetupId });
                case 4:
                    return RedirectToAction("Indexclavados", new { setupid = setup.SetupId });



            }
            return View(setup);
        }

        public ActionResult ListarNadadores(int TorneoId)
        {
            if (!repository.validarUsuario())
            {
                return RedirectToAction("Login", "home");
            }
            OtroSetupTorneo setup = db.OtroSetupTorneo.Where(x => x.TorneoId == TorneoId).FirstOrDefault();
            List<ListadoDeportistasParaSeleccionarlos> VM = new List<ListadoDeportistasParaSeleccionarlos>();
            List<OtroEventos> ListadoDeEventos = db.OtroEventos.Where(x => x.TorneoId == TorneoId).ToList();
            int EdadMaxima = ListadoDeEventos.Max(x => x.EdadMaxima);
            int EdadMinima = ListadoDeEventos.Min(x => x.EdadMinima);
            int annoActual = DateTime.Now.Year;
            if (setup.OtroTorneo.EdadADiciembre)
            {
                annoActual -= 1;
            }
            AnnoMaximo = annoActual - EdadMinima;
            AnnoMinimo = annoActual - EdadMaxima;

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

            List<Inscripciones> ListadoDeNadadores = GetNadadores(setup);
            VM = GetInscripciones(setup, ListadoDeNadadores);
            ViewBag.setup = db.OtroSetupTorneo.Where(x => x.TorneoId == setup.TorneoId).FirstOrDefault();

            return PartialView(VM);
        }

        public async Task<JsonResult> Getdeportista(int id)
        {
            var deportista = await db.Inscripciones
                .Where(x=>x.InscripcionId == id)
                .Select(i => new { i.Afiliado.Nombre, i.Afiliado.Apellido_Paterno, i.Afiliado.DNI, i.InscripcionId })
                .FirstOrDefaultAsync();
            var jsonData = Json(deportista, JsonRequestBehavior.AllowGet);
            return jsonData;
        }
        public List<Inscripciones> GetNadadores(OtroSetupTorneo setup)
        {
            Usuario usuario = Session["Usuario"] as Usuario;
            var listado = db
              .Inscripciones.Where(x => x.ClubID == usuario.Club.ClubID && x.Afiliado.Fecha_de_nacimiento.Year >= AnnoMinimo
              && x.Afiliado.Fecha_de_nacimiento.Year <= AnnoMaximo && x.DisciplinaId == setup.OtroTorneo.DisciplinaId)
              .AsQueryable();
            if (!setup.PermiteNoAfiliados)
            {
                listado = listado.Where(x => x.EstadoID == 3);
            }
            List<Inscripciones> listadoNadadores = new List<Inscripciones>();
            listadoNadadores = listado
            .OrderBy(x => x.Afiliado.Fecha_de_nacimiento)
            .ToList();
            return listadoNadadores;
        }

        public List<OtroEventos> GetEventosGrupales(int setupid)
        {
            OtroSetupTorneo setup = db.OtroSetupTorneo.Find(setupid);
            return db.OtroEventos.Where(x => x.TorneoId == setup.TorneoId).ToList();
        }

        public List<ListadoDeportistasParaSeleccionarlos> GetInscripciones(OtroSetupTorneo setup, List<Inscripciones> ListadoDeNadadores)
        {
            List<ListadoDeportistasParaSeleccionarlos> VM = new List<ListadoDeportistasParaSeleccionarlos>();
            List<OtroEntradas> EntradasDeEsteTorneo = db.OtroEntradas.Where(x => x.TorneoId == setup.TorneoId).ToList();
            List<OtroAtleta> atletasDeEsteTorneo = db.OtroAtleta.Where(x => x.TorneoId == setup.TorneoId).ToList(); //Los que ya están inscritos 
            foreach (Inscripciones Inscripcion in ListadoDeNadadores)
            {
                ListadoDeportistasParaSeleccionarlos listarnadadorparainscribir = new ListadoDeportistasParaSeleccionarlos
                {
                    OtroAtleta = new OtroAtleta
                    {
                        InscripcionId = Inscripcion.InscripcionId,
                        TorneoId = setup.TorneoId,
                        Inscripciones = Inscripcion,
                    },
                    YaEstaInscrito = false,
                    TieneMulta = db.Multas.Any(x => x.InscripcionId == Inscripcion.InscripcionId && x.Subsanada == false),
                };
                if (atletasDeEsteTorneo.Any(x => x.Inscripciones.DNI == Inscripcion.DNI))
                {
                    OtroAtleta atleta = atletasDeEsteTorneo.Where(x => x.Inscripciones.DNI == Inscripcion.DNI).FirstOrDefault();
                    listarnadadorparainscribir.YaEstaInscrito = true;
                }

                VM.Add(listarnadadorparainscribir);
            }
            return VM;
        }


        public ActionResult ListarPruebasParaelDeportista(int TorneoId, int InscripcionId)
        {
            int annoActual = DateTime.Now.Year - 1; /*Para calcular la edad al año pasado*/

            //Iniciando las variables a usar más adelante
            Usuario usuario = Session["Usuario"] as Usuario;
            OtroSetupTorneo setup = db.OtroSetupTorneo.Where(x => x.TorneoId == TorneoId).FirstOrDefault();
            OtroEquipo equipo = db.OtroEquipo.FirstOrDefault(x => x.Team_abbr == usuario.Club.Iniciales);
            if (equipo == null)
            {
                Club club = db.Club.Where(x => x.ClubID == usuario.ClubId).FirstOrDefault();
                equipo = GrabarClub(club, TorneoId);
            }
            List<OtroEntradas> EntradasDelEquipo = db.OtroEntradas.Where(x => x.TorneoId == TorneoId && x.OtroAtleta.TeamId == equipo.TeamId).ToList();
            Inscripciones afiliado = db.Inscripciones.Where(x => x.InscripcionId == InscripcionId).FirstOrDefault();
            int edad = DateTime.Now.Year - afiliado.Afiliado.Fecha_de_nacimiento.Year;
            if (setup.OtroTorneo.EdadADiciembre) { edad -= 1; }
            List<OtroEventos> Eventos = db.OtroEventos.Where(x => x.EdadMaxima >= edad && x.EdadMinima <= edad && (x.EventSex == afiliado.Afiliado.Sexo
            || x.EventSex == "X") && x.TorneoId == TorneoId).ToList();


            List<EventoInscritoViewModel> VM = new List<EventoInscritoViewModel>();
            foreach (var evento in Eventos)
            {
                EventoInscritoViewModel eventoinscrito = new EventoInscritoViewModel
                {
                    evento = evento,
                    Yainscrito = db.OtroEntradas.Any(x => x.AtletaId == InscripcionId && x.EventoId == evento.EventoId),
                    clase = "",
                };

                if (eventoinscrito.Yainscrito)
                {
                    OtroEntradas entrada = db.OtroEntradas.Where(x => x.AtletaId == InscripcionId && x.EventoId == evento.EventoId).FirstOrDefault();
                    if (setup.OtroTorneo.Disciplina.TipoDisciplina == "Polo acuático")
                    {
                        eventoinscrito.marca = entrada.Gorro.ToString();
                    }
                    else if (setup.OtroTorneo.Disciplina.TipoDisciplina == "Natación artística")
                    {
                        eventoinscrito.marca = entrada.Suplente.ToString();
                    }
                    eventoinscrito.clase = "selected";
                }
                VM.Add(eventoinscrito);
            }

            ViewBag.setup = setup;
            return PartialView(VM);
        }

        public OtroEquipo GrabarClub(Club club, int MeetId)
        {
            //Afiliacion afiliacion = af.Afiliacion.Where(x => x.DNI == afiliado.DNI).OrderByDescending(x => x.AfiliacionID).FirstOrDefault();   

            OtroEquipo ultimoequipo = db.OtroEquipo.OrderByDescending(x => x.TeamId).FirstOrDefault();
            OtroEquipo equipo = new OtroEquipo
            {
                Team_name = club.NombreClub,
                Team_abbr = club.Iniciales,
                TorneoId = MeetId
            };
            if (equipo.Team_name.Length > 30)
            {
                equipo.Team_name = equipo.Team_name.Substring(0, 30);

            }


            db.OtroEquipo.Add(equipo);
            db.SaveChanges();
            return equipo;
        }
        [HttpGet]
        public ActionResult InscribirResponsable(int MeetId)
        {
            Usuario usuario = Session["Usuario"] as Usuario;
            ViewBag.usuario = usuario;
            InscripcionResponsable responsable = new InscripcionResponsable();
            return View(responsable);
        }

        [HttpPost]
        public ActionResult InscribirResponsable(InscripcionResponsable responsable)
        {
            Usuario usuario = Session["Usuario"] as Usuario;
            Club club = db.Club.FirstOrDefault(x => x.ClubID == usuario.ClubId);
            GrabarClub(club, responsable.Equipos.MeetId);

            if (TryUpdateModel(responsable))
            {
                Equipos equipo = db.Equipos.FirstOrDefault(x => x.Team_short == club.NombreUsuario);
                responsable.TeamId = equipo.TeamId;
                db.InscripcionResponsable.Add(responsable);
                db.SaveChanges();
                return RedirectToAction("ListarNadadores", new { Meetid = responsable.Equipos.MeetId });
            }
            return View(responsable.Equipos.MeetId);
        }

        //********************  INSCRIPCION DE POLO ACUATICO ***************************
        public ActionResult IndexPolo(int setupid)
        {
            List<OtroEventos> eventos = GetEventosGrupales(setupid);
            IndexPoloViewModel VM = new IndexPoloViewModel
            {
                Eventopolo = new List<EventoPolo>(),
        };
            foreach(var evento in eventos)
            {
                EventoPolo epolo = new EventoPolo
                {
                    EventNombre = evento.EventNombre + " " + evento.EventSex + " Edad: " + evento.EdadMinima + " - " + evento.EdadMaxima,
                    EventoId = evento.EventoId,
                };
                VM.Eventopolo.Add(epolo);
            }
           

            return View(VM);
        }

        public async Task<PartialViewResult> ListadoPolistas(int otroeventoid)
        {
            OtroEventos evento = db.OtroEventos.Find(otroeventoid);
            Usuario usuario = Session["Usuario"] as Usuario;
            int annoActual = DateTime.Now.Year;
           
            AnnoMaximo = annoActual - evento.EdadMinima;
            AnnoMinimo = annoActual - evento.EdadMaxima;


            // disciplinaid de polo es 2
            var listado = db
              .Inscripciones.Where(x => x.ClubID == usuario.Club.ClubID && x.Afiliado.Fecha_de_nacimiento.Year >= AnnoMinimo
              && x.Afiliado.Fecha_de_nacimiento.Year <= AnnoMaximo && x.Afiliado.Sexo == evento.EventSex && x.DisciplinaId == 2)
              .AsQueryable();

            List<Inscripciones> polistas = await listado.OrderBy(x => x.Afiliado.Apellido_Paterno).ThenBy(x => x.Afiliado.Nombre).ToListAsync();
            return PartialView(polistas);
        }
        public async Task<PartialViewResult> YaInscritosPolo(int otroeventoid)
        {
            List<OtroEntradas> entradas =await db.OtroEntradas.Where(x => x.EventoId == otroeventoid).OrderBy(x => x.Gorro).ToListAsync();
            List<OtroEntradas> VM = new List<OtroEntradas>();
            for (int i = 1; i<12; i++)
            {
                if(entradas.Any(x=>x.Gorro == i ))
                {
                    OtroEntradas modelo =  entradas.Where(x => x.Gorro == i).FirstOrDefault();
                    VM.Add(modelo);
                }
                else
                {
                    OtroEntradas modelo = new OtroEntradas
                    {
                        Gorro = i,
                        AtletaId = 0,
                    };
                    VM.Add(modelo);
                }
            }
            return PartialView(VM);
        }

        
        public async Task 
            GrabarOtraEntrada(int inscripcionid, int otroeventoid, int gorroid, int disciplinaid, bool suplente )
        {
            Usuario usuario = Session["Usuario"] as Usuario;
            OtroEventos evento = db.OtroEventos.FindAsync(otroeventoid).Result;
            OtroEquipo equipo;
            OtroAtleta atleta;
            OtroEntradas entrada;

            if (!db.OtroEquipo.AnyAsync(x=>x.Team_abbr == usuario.Club.Iniciales && x.TorneoId == evento.TorneoId).Result)
            {
                 equipo = new OtroEquipo
                {
                    TorneoId = evento.TorneoId,
                    Team_name = usuario.Club.NombreClub,
                    Team_abbr = usuario.Club.Iniciales,
                };
                db.OtroEquipo.Add(equipo);
              await  db.SaveChangesAsync();
            }
            else
            {
                equipo = db.OtroEquipo.Where(x => x.Team_abbr == usuario.Club.Iniciales && x.TorneoId == evento.TorneoId).FirstOrDefaultAsync().Result;
            }
            
            if(!db.OtroAtleta.AnyAsync(x=>x.InscripcionId==inscripcionid && x.TorneoId == evento.TorneoId).Result)
            {
                atleta = new OtroAtleta
                {
                    InscripcionId = inscripcionid,
                    TorneoId = evento.TorneoId,
                    TeamId = equipo.TeamId,
                };
                db.OtroAtleta.Add(atleta);
               await db.SaveChangesAsync();
            }
            else
            {
                atleta = db.OtroAtleta.Where(x => x.InscripcionId == inscripcionid && x.TorneoId == evento.TorneoId).FirstOrDefaultAsync().Result;
            }

            //Buscamos si ya hay alguien ingresado con ese gorro
            if(db.OtroEntradas.AnyAsync(x=>x.EventoId ==otroeventoid && x.Gorro == gorroid).Result)
            {
                await RetirarOtroGorro(otroeventoid, gorroid);
            }
            //Buscamos si este deportista está con otro gorro
            if (db.OtroEntradas.AnyAsync(x => x.EventoId == otroeventoid && x.AtletaId == atleta.AtletaId).Result)
            {
                await RetirarOtraEntrada(otroeventoid, atleta.AtletaId.ToString());
            }


            if (db.OtroEntradas.AnyAsync(x=>x.AtletaId == atleta.AtletaId && x.EventoId == evento.EventoId) .Result)
            {
                entrada = db.OtroEntradas.Where(x => x.AtletaId == atleta.AtletaId && x.EventoId == evento.EventoId)
                   .FirstOrDefaultAsync().Result;
                db.OtroEntradas.Remove(entrada);
                await db.SaveChangesAsync();
                
            }
            else
            {
                entrada = new OtroEntradas
                {
                    AtletaId = atleta.AtletaId,
                    EventoId = otroeventoid,
                    Gorro = gorroid,
                    TorneoId = evento.TorneoId,
                    Suplente = suplente,

                };
                db.OtroEntradas.Add(entrada);
                await db.SaveChangesAsync();
            }

        }
       
        public async Task RetirarOtraEntrada(int eventoid, string DataId)
        {
            int id = 0;
            if (DataId.Contains("retirar"))
            {
                int inicio = DataId.IndexOf("retirar");
                id = int.Parse(DataId.Substring(0, inicio));
            }
            else
            {
                id = int.Parse(DataId);
            }
           
            OtroEntradas entrada = await db.OtroEntradas.Where(x => x.EventoId == eventoid && x.AtletaId == id).FirstOrDefaultAsync();
            db.OtroEntradas.Remove(entrada);
            await db.SaveChangesAsync();
        }

        public async Task RetirarOtroGorro(int eventoid, int id)
        {
            OtroEntradas entrada = await db.OtroEntradas.Where(x => x.EventoId == eventoid && x.Gorro == id).FirstOrDefaultAsync();
            db.OtroEntradas.Remove(entrada);
            await db.SaveChangesAsync();
        }
        public int IngresarDeportista(int id, int TorneoId, int TeamId, bool YaestaInscrito)
        {
            if (!YaestaInscrito)
            {
                Inscripciones inscripcion = db.Inscripciones.Find(id);
                OtroAtleta atleta = new OtroAtleta
                {
                    InscripcionId = inscripcion.InscripcionId,
                    TeamId = TeamId,
                    TorneoId = TorneoId,
                };
                db.OtroAtleta.Add(atleta);
                db.SaveChanges();
                return atleta.AtletaId;
            }
            OtroAtleta atleta2 = db.OtroAtleta.FirstOrDefault(x => x.InscripcionId == id);
            return atleta2.AtletaId;


        }

        public void BorrarInscripcionesAntiguas(int deportistaid, int torneoid)
        {
            //Borra las inscripciones antiguas
            List<OtroEntradas> entradas = db.OtroEntradas.Where(x => x.AtletaId == deportistaid && x.TorneoId == torneoid).ToList();
            foreach (OtroEntradas entrada in entradas)
            {
                db.OtroEntradas.Remove(entrada);
            }
            db.SaveChanges();
        }
    }
}