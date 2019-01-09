using FDPN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FDPN.ViewModels.Resultados
{
    public class RendimientoDeUnaPruebaViewModel
    {
        public Athlete atleta { get; set; }
        public List<RESULTS>  ResultadosCorta{ get; set; }
        public List<RESULTS> ResultadosLarga { get; set; }
        public Pruebas prueba { get; set; }
        public Inscripciones Inscripciones { get; set; }

    }
}