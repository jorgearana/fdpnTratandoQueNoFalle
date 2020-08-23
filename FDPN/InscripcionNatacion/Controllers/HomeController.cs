
using InscripcionNatacion.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System;
using System.Web;
using System.IO;
using InscripcionNatacion.ViewModels.Home;
using FDPN.Models;

namespace InscripcionNatacion.Controllers
{
    public class HomeController : BASEController
    {
       
        
        ConvertirAPeru convertidor = new Helpers.ConvertirAPeru();
        Repository repository = new Repository();
       

        public ActionResult index(string returnUrl)
        {
            Apagado apagado = db.Apagado.FirstOrDefault();
            if (apagado.Apagado1)
            {
                return RedirectToAction("Actualizandodatos");
            }
            else
            {
                if (repository.validarUsuario())
                {
                    return RedirectToAction("torneos");
                }
                else
                {
                    return RedirectToAction("Login");
                }
            }
        }

        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            Apagado apagado = db.Apagado.FirstOrDefault();
            if (apagado.Apagado1)
            {
                return RedirectToAction("Actualizandodatos");
            }
            else
            {
                ViewBag.ReturnUrl = returnUrl;
                Club club = Session["Club"] as Club;
                Usuario usuario = Session["Usuario"] as Usuario;
                return View();
            }
        }
          
        [HttpPost]
        public ActionResult Login(ViewModels.Home.LoginViewModel VM)
        {
            Session.Clear();
            Usuario usuario = db.Usuario.Where(x => x.Usuario1 == VM.Nombre  && x.Password == VM.Password ).FirstOrDefault();
          
            if (usuario != null)
            {
                Rol  rol = db.Rol.Where(x => x.RolId == usuario.RolId).FirstOrDefault();
                Session["Usuario"] = usuario;
                Session["Rol"] = rol;
                //return RedirectToAction("Modal");
                return RedirectToAction("torneos", "home");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Modal()
        {
            return View();
        }
        

        public ActionResult Torneos()
        {
            if (!repository.validarUsuario()) return RedirectToAction("login", "home");
            Usuario usuario = Session["Usuario"] as Usuario;  
            List<TorneoViewModel> VM = new List<TorneoViewModel>();

            List<SetupTorneo> setups = db.SetupTorneo. Where(x=>!x.Masters).OrderByDescending(x => x.Torneo.entry_deadline).Take(8).ToList();
            foreach (SetupTorneo setup in setups)
            {
                DateTime dt = setup.Torneo.entry_deadline ?? convertidor.ToPeru(DateTime.UtcNow);
                    dt = dt.AddDays(1);
                DateTime dtNow = convertidor.ToPeru(DateTime.UtcNow);
                TimeSpan result = dt.Subtract(dtNow);
                int seconds = Convert.ToInt32(result.TotalSeconds);
                TorneoViewModel torneoviewmodel = new TorneoViewModel
                {
                    torneo = setup,
                    diferencia = seconds,
                    FechaFin = dt,
                    Tieneinscritos = false,
                    Start = setup.Torneo.Meet_start ?? dtNow,
                    Masters = setup.Masters,
                };
                torneoviewmodel.Tieneinscritos = db.Equipos.Any(x => x.MeetId == torneoviewmodel.torneo.Meetid && x.Team_abbr == usuario.Club.Iniciales);
                VM.Add(torneoviewmodel);
            }
            return View(VM);
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("login");
        }        

        public ActionResult Actualizandodatos()
        {
            return View();
        }

        public ActionResult PaginaDeErrorOMensaje(ErrorViewModel VM)
        {
            return View(VM);
        }

        public bool ValidarLog ()
        {
            Usuario usuario = Session["Usuario"] as Usuario;

            if (usuario== null)
            {
                return false;
            }
            return true;
        }
    }
}