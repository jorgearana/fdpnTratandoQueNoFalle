using FDPN.Models;
using FDPN.ViewModels.PCalendario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FDPN.Controllers
{
    public class CalendarioController : BASEController
    {
        // GET: Cursos
        public ActionResult Index()
        {
            DateTime semanaatras = convertidor.ToPeru(DateTime.UtcNow.AddDays(-7));
            List<PCalendario> calendario = db.PCalendario.Where(x => x.FechaInicio > semanaatras).OrderBy(x=>x.FechaInicio).ToList();
            return View(calendario);
        }

        public ActionResult DetalleCurso(int calendarioid)
        {
          
            DetalleDeCursoViewModel VM = new DetalleDeCursoViewModel
            {
                calendario = db.PCalendario.Find(calendarioid),
            };
            VM.Horarios = db.PHorarios.Where(x => x.CursoId == VM.calendario.CursoId).ToList();
            VM.Temas = db.PTemas.Where(x => x.CursoId == VM.calendario.CursoId).ToList();
            return View(VM);
        }
    }
}