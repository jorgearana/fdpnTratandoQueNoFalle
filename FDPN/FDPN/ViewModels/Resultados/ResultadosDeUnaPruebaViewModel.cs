using FDPN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FDPN.ViewModels.Resultados
{
    public class ResultadosDeUnaPruebaViewModel
    {
        public List<RESULTS> Resultadosfinales{ get; set; }
        public List<RESULTS> Resultadospreliminares { get; set; }
        public Meet torneo { get; set; }
        public Pruebas prueba { get; set; }
        public string minima { get; set; }
        public string maxima { get; set; }
    }
}