using FDPN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FDPN.Controllers
{
    public class BorrarController : BASEController
    {
        // GET: Borrar
        public ActionResult Index()
        {
            List<CursoProfesor> profesores = db.CursoProfesor.ToList();
            return View(profesores);
        }
    }
}