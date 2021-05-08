using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FDPN.Models;
using FDPN.ViewModels.Administrador;
using System.IO;
using FDPN.Helpers;
using System.Web.Hosting;
using FDPN.Views.Administrador;

namespace FDPN.Controllers
{
    public class BASEController : Controller
    {
        
        public DB_9B1F4C_FDPNEntities db = new DB_9B1F4C_FDPNEntities();
       // public DB_9B1F4C_FDPNContext db = new DB_9B1F4C_FDPNContext();
        public ConvertirAPeru convertidor = new ConvertirAPeru();


       
    }
}