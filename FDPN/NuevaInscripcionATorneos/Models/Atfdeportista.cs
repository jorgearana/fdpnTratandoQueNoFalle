using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class Atfdeportista
    {
        public int DeportistaId { get; set; }
        public bool CopiaDni { get; set; }
        public bool? CopiaDniapoderado { get; set; }
        public bool AvalMedico { get; set; }
        public bool CompromisoRetorno { get; set; }
        public int Expedienteid { get; set; }

        public virtual Atfexpediente Expediente { get; set; }
    }
}
