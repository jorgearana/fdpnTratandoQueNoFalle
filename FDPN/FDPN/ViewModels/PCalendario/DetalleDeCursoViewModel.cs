using FDPN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FDPN.ViewModels.PCalendario
{
    public class DetalleDeCursoViewModel
    {

        public Models.PCalendario calendario { get; set; }
        public PProfesor Profesor { get; set; }
        public List<PHorarios> Horarios { get; set; }
        public List<PTemas> Temas { get; set; }
    }
}