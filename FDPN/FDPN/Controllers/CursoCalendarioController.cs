using AutoMapper;
using FDPN.Models;
using FDPN.ViewModels.CursoCalendario;
using FDPN.ViewModels.Pcalendario;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FDPN.Controllers
{
    public class 
        CursoCalendarioController : BASEController
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

        [HttpGet]
        public ActionResult CreateAlumno()
        {
            DTOAlumno Dto= new DTOAlumno();
            return View(Dto);
        }

        [HttpPost]
        public ActionResult CreateAlumno(DTOAlumno Dto)
        {
            if (ModelState.IsValid)
            {
                //CursoAlumno cursoAlumno = Mapper.Map<DTOAlumno, CursoAlumno>(Dto);
                //db.CursoAlumno.Add(cursoAlumno);
                //db.SaveChanges();
                //return RedirectToAction("Index");
            }
            return View(Dto);
        }

        public async Task<ActionResult> BuscarPorDNi(string DNI)
        {
            //CursoAlumno alumno =await db.CursoAlumno.Where(x => x.DNI == DNI).FirstOrDefaultAsync ();
            //DTOAlumno dto = Mapper.Map<CursoAlumno, DTOAlumno>(alumno);
            //return View(dto);
            return View();
        }

        //public ActionResult InscribirAlumno(int DTOID, int cursoid)
        //{
        //    CursoAlumno cursoAlumno = db.CursoAlumno.Where(x => x.AlumnoId == DTOID).FirstOrDefault();

        //}
    }
}