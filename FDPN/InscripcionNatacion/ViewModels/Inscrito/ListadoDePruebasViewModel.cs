
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InscripcionNatacion.ViewModels.Inscrito
{
    public class ListadoDePruebasViewModel
    {
        public FDPN.Models.Afiliado afiliado { get; set; }
        public int sesiones { get; set; }
        public int pruebaxsesion { get; set; }
        public int pruebasxnadador { get; set; }

    }
}