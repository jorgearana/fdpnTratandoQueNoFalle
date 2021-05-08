using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FDPN.Models;

namespace FDPN.ViewModels.Administrador
{
    public class ResumenAnnoViewModel
    {
        public int Nadadores{ get; set; }
        public int Participaciones { get; set; }
        public Team club { get; set; }

    }
}