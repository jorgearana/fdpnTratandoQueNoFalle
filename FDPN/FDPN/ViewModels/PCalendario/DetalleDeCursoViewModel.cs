using FDPN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FDPN.ViewModels.Pcalendario
{
    public class DetalleDeCursoViewModel
    {

        public PCalendario calendario { get; set; }
        public List<PHorarios> Horarios { get; set; }
        public List<PTemas> Temas { get; set; }
    }
}