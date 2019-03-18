using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FDPN.Controllers
{
    public class LoginController : BASEController
    {
        // GET: Login
        public ActionResult callback()
        {
            return View();
        }
    }
}