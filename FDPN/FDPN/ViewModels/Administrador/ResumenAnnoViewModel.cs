using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FDPN.ViewModels.Administrador
{
    public class ResumenAnnoViewModel
    {
        public int Nadadores{ get; set; }
        public int Participaciones { get; set; }
        public Models.TEAM club { get; set; }

    }
}