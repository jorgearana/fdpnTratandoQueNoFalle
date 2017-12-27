using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FDPN.ViewModels.Home
{
    public class AlertasViewModel
    {
     public  List< Models.Alertas> alertas { get; set; }
        public int cantidad { get; set; }
    }
}