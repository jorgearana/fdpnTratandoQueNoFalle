
using NuevaInscripcionATorneos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NuevaInscripcionATorneos.Data.Modelos
{
    public class ListarNadadoresParaSeleccionarlos
    {
        Inscripciones afiliado { get; set; }
        public bool YaEstaInscrito { get; set; }
        public bool TieneMulta { get; set; }
        public bool TieneResultado { get; set; }
    }
}
