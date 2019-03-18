using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using FDPN.Models;
using FDPN.ViewModels.Calendario;
using FDPN.ViewModels.Resultados;
using Rotativa;
using System;
using FDPN.Helpers;

namespace FDPN.Controllers
{
    public class CalendariosController : BASEController
    {
       
        // GET: Calendarios
        public ActionResult Index()
        {
            if (!ValidarTecnico())
            {
                return View("NoAutorizado");
            }
            List<Calendario> calendarios = db.Calendario.ToList();          
            return View(calendarios);
        }

       
        // GET: Calendarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calendario calendario = db.Calendario.Find(id);
            if (calendario == null)
            {
                return HttpNotFound();
            }
            return View(calendario);
        }

        // GET: Calendarios/Create
        public ActionResult Create()
        {
            if (!ValidarTecnico())
            {
                return View("NoAutorizado");
            }
            NuevoCalendarioViewModel VM = new NuevoCalendarioViewModel
            {
                disciplinas = db.Disciplina.ToList(),
                calendario = new Calendario(),
            };
            return View(VM);
        }

        // POST: Calendarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NuevoCalendarioViewModel VM)
        {
            if (ModelState.IsValid)
            {
                db.Calendario.Add(VM.calendario);
                db.SaveChanges();
                InsertarAlertaCalendario();
                return RedirectToAction("Index");
            }
            
            return View(VM.calendario);
        }

        // GET: Calendarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (!ValidarTecnico())
            {
                return View("NoAutorizado");
            }
            if (id != null)
            {
                NuevoCalendarioViewModel VM = new NuevoCalendarioViewModel
                {
                    disciplinas = db.Disciplina.ToList(),
                    calendario = db.Calendario.Find(id),
                };
                return View(VM);
            }
            
                return HttpNotFound();
            
        }

        // POST: Calendarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NuevoCalendarioViewModel VM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(VM.calendario).State = EntityState.Modified;
                db.SaveChanges();
                InsertarAlertaCalendario();
                return RedirectToAction("Index");
            }
            
            return View(VM.calendario);
        }

        // GET: Calendarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (!ValidarTecnico())
            {
                return View("NoAutorizado");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calendario calendario = db.Calendario.Find(id);
            if (calendario == null)
            {
                return HttpNotFound();
            }
            return View(calendario);
        }

        // POST: Calendarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Calendario calendario = db.Calendario.Find(id);
            db.Calendario.Remove(calendario);
            db.SaveChanges();
            InsertarAlertaCalendario();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult VersionImprimible(int disciplina)
        {
            var Query = db.Calendario.AsQueryable();
            Disciplina disciplinaseleccionada = db.Disciplina.Where(x => x.TipoDisciplina == "Todas").FirstOrDefault();
           
          if (disciplina != 0 && disciplina != 7) // osea no es valor vacio ni valor = "todas"
            {
                Query = Query.Where(x => x.DisciplinaId == disciplina);
                disciplinaseleccionada = db.Disciplina.Where(x => x.DisciplinaId == disciplina).FirstOrDefault();
            }


            CalendarioViewModel VM = new CalendarioViewModel
            {
                disciplina = disciplinaseleccionada.TipoDisciplina,
                disciplinas = db.Disciplina.ToList(),
                calendario = Query.OrderBy(x => x.Inicio).ToList(),
                
            };
            Alertas alerta = db.Alertas.Find(1);
            ViewBag.modificacion = alerta.Fecha;
            return PartialView(Query.OrderBy(x => x.Inicio).ToList());
        }

        public ActionResult PrintCalendario(int? disciplina)
        {
            int valor = disciplina ?? 0;
            var report = new  ActionAsPdf("VersionImprimible", new { disciplina = valor })
            {
                FileName = "CalendarioFDPN.pdf",
                PageOrientation = Rotativa.Options.Orientation.Landscape,
                PageSize = Rotativa.Options.Size.A4,
                CustomSwitches = "--disable-smart-shrinking",
                PageMargins = new Rotativa.Options.Margins(20, 10, 10, 20),
            };
            return report;
        }

        public bool ValidarTecnico()
        {
            if (System.Web.HttpContext.Current.Session["Rol"] != null)
            {

                FDPN.Models.Rol rol = (System.Web.HttpContext.Current.Session["Rol"] as FDPN.Models.Rol);

                return (rol.RolId ==1 || rol.RolId ==4);
            }
            return false;
        }

        public void InsertarAlertaCalendario()
        {
            ConvertirAPeru convertidor = new Helpers.ConvertirAPeru();
            DateTime today = convertidor.ToPeru(DateTime.UtcNow);
            Alertas alertaantigua = db.Alertas.Where(x => x.Alerta.Contains("Calendario modificado")).FirstOrDefault();
            
            if (alertaantigua == null)
            {
                Alertas alerta = new Alertas
                {
                    Alerta = "Calendario modificado el día : " + today,
                    Fecha = today,
                };
                db.Alertas.Add(alerta);
            }
            else
            {
               
                alertaantigua.Fecha = today;
                alertaantigua.Alerta = "Calendario modificado el día : " + today;
            }
            
            
            db.SaveChanges();
        }

        
    }
}
