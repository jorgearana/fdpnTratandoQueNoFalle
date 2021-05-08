using FDPN.Models;
using InscripcionNatacion.ViewModels.Entrenador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace InscripcionNatacion.Controllers
{
    public class EntrenadorController : BASEController
    {
        // GET: Entrenador
        public ActionResult Index(int MeetId)
        {
            DateTime hoy = DateTime.Now;
            Usuario usuario = Session["Usuario"] as Usuario;
            EscogerEntrenadorViewModel VM = new EscogerEntrenadorViewModel
            {
                torneo = db.Torneo.Where(x => x.Meetid == MeetId).FirstOrDefault(),
                entrenadores = db.Entrenadores.Where(x => x.Clubid == usuario.ClubId && x.EstadoId ==3).ToList(),
            };
            return View(VM);
        }

        public ActionResult EntrenadoresInscritos(int MeetId)
        {
            Usuario usuario = Session["Usuario"] as Usuario;
            EntrenadoresInscritosViewModel VM = new EntrenadoresInscritosViewModel
            {
                entrenadores = db.EntrenadorInscrito.Where(x => x.Entrenadores.Club.Iniciales == usuario.Club.Iniciales).ToList(),
                torneo = db.Torneo.Find(MeetId),
            };
            return PartialView("EntrenadoresInscritos", VM);
        }

        public JsonResult InscribirEntrenador(int EntrenadorId, int MeetId)
        {

            Usuario usuario = Session["Usuario"] as Usuario;
            Equipos equipo = db.Equipos.Where(x => x.Team_abbr == usuario.Club.Iniciales).FirstOrDefault();
            if (equipo == null)
            {
                Equipos ultimoequipo = db.Equipos.OrderByDescending(x => x.TeamId).FirstOrDefault();
                if (ultimoequipo == null)
                {
                    ultimoequipo = new Equipos
                    {
                        TeamId = 0,
                    };
                }
                equipo = new Equipos
                {
                    TeamId = ultimoequipo.TeamId + 1,
                    Team_abbr = usuario.Club.Iniciales,
                    Team_name = usuario.Club.NombreUsuario,
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
                
                db.Equipos.Add(equipo);
                db.SaveChanges();

            }
            EntrenadorInscrito EntrenadorInscrito = db.EntrenadorInscrito.Where(x => x.EntrenadorId == EntrenadorId).FirstOrDefault();
            if (EntrenadorInscrito == null)
            {
                EntrenadorInscrito = new EntrenadorInscrito
                {
                    EntrenadorId = EntrenadorId,
                    MeetId = MeetId,
                };
                
                db.EntrenadorInscrito.Add(EntrenadorInscrito);
                db.SaveChanges();
            }
            EntrenadoresInscritosViewModel VM = new EntrenadoresInscritosViewModel
            {
                entrenadores = db.EntrenadorInscrito.Where(x => x.Entrenadores.Club.Iniciales == usuario.Club.Iniciales).ToList(),
                torneo = db.Torneo.Find(MeetId),
        };

            string respuesta = "OK";
            return Json(respuesta, JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult ListarEntrenadores(int MeetId)
        {
            Usuario usuario = Session["Usuario"] as Usuario;
            EntrenadoresInscritosViewModel VM = new EntrenadoresInscritosViewModel
            {
                entrenadores = db.EntrenadorInscrito.Where(x => x.Entrenadores.Club.Iniciales == usuario.Club.Iniciales).ToList(),
                torneo = db.Torneo.Find(MeetId),
            };
            return PartialView("EntrenadoresInscritos", VM);

        }

        public JsonResult RetirarEntrenador(int EntrenadorId, int MeetId)
        {
            Usuario usuario = Session["Usuario"] as Usuario;
            EntrenadorInscrito EntrenadorInscrito = db.EntrenadorInscrito.Where(x => x.EntrenadorId == EntrenadorId).FirstOrDefault();
            db.EntrenadorInscrito.Remove(EntrenadorInscrito);
            db.SaveChanges();
            EntrenadoresInscritosViewModel VM = new EntrenadoresInscritosViewModel
            {
                entrenadores = db.EntrenadorInscrito.Where(x => x.Entrenadores.Club.Iniciales == usuario.Club.Iniciales).ToList(),
                torneo = db.Torneo.Find(MeetId),
            };
            return Json("OK", JsonRequestBehavior.AllowGet);
        }



        public PartialViewResult FormularioDelegados()
        {
            Delegados delegado = new Delegados();
            
            return PartialView(delegado);
        }
        public PartialViewResult ListadoDeDelegados(int MeetId)
        {
            Usuario usuario = Session["Usuario"] as Usuario;
            List<Delegados> delegados = db.Delegados.Where(x => x.UsuarioId == usuario.UsuarioID && x.MeetId == MeetId).ToList();
            ViewBag.Meetid = MeetId;
            return PartialView(delegados);
        }

        public JsonResult IngresarNuevoDelegado(int Meetid , string Nombre, string Apellido)
        {
            Usuario usuario = Session["Usuario"] as Usuario;
            Delegados delegado = new Delegados
            {
                Nombre = Nombre,
                Apellido = Apellido,
                MeetId = Meetid,
                UsuarioId = usuario.UsuarioID,
            };
            db.Delegados.Add(delegado);
            db.SaveChanges();
            ViewBag.Meetid = Meetid;
            return Json("OK", JsonRequestBehavior.AllowGet);
        }

        public JsonResult RetirarDelegado(int Meetid, int delegadoid)
        {
            Delegados delegado = db.Delegados.Where(x => x.DelegadoId == delegadoid && x.MeetId == Meetid).FirstOrDefault();
            db.Delegados.Remove(delegado);
            db.SaveChanges();
            return Json("OK", JsonRequestBehavior.AllowGet);
        }
    }
}