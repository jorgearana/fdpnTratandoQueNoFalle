using FDPN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InscripcionNatacion.ViewModels.OtraInscripcion
{
    public class ListadoDeportistasParaSeleccionarlos
    {
        public OtroAtleta OtroAtleta { get; set; }
        public bool YaEstaInscrito { get; set; }
        public bool TieneMulta { get; set; }
    }
}