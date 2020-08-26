using FDPN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FDPN.Controllers
{
    public class NosotrosController : BASEController
    {
        // GET: Nosotros
        public ActionResult fdpn()
        {
            return View();
        }
        public ActionResult directorio()
        {
            return View();
        }
        public ActionResult estatuto()
        {
            return View();
        }
        public ActionResult ipd()
        {
            return View();
        }
        public ActionResult fina()
        {
            return View();
        }
        public ActionResult uana()
        {
            return View();
        }
        public ActionResult consanat()
        {
            return View();
        }
       
        public ActionResult reglamentos()
        {
            return View();
        }
        public ActionResult ListadoClubesAfiliados()
        {
           
            List<Club> clubes = db.Club.Where(x => x.Activo == 3).OrderBy(x => x.NombreClub).ToList();
            

            return View(clubes);
        }

    }
}