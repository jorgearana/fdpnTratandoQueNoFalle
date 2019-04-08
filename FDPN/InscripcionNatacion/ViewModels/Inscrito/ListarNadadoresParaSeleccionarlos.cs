using FDPN.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InscripcionNatacion.ViewModels.Inscrito
{
    public class ListarNadadoresParaSeleccionarlos
    {
        public Inscripciones afiliado{ get; set; }
        public bool YaEstaInscrito { get; set; }
        public bool TieneMulta { get; set; }
        public bool TieneResultado { get; set; }
    }
}