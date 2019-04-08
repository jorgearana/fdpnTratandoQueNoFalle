using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InscripcionNatacion.ViewModels.Inscrito
{
    public class SesionViewModel
    {
        public int Sesion { get; set; }
        public int Maximopermitido { get; set; }
        public int Inscritos { get; set; }
        public int Pendiente { get; set; }


    }
}