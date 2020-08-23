using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class HistorialdeAfiliaciones
    {
        public int AfiliacionId { get; set; }
        public int InscripcionId { get; set; }
        public DateTime Fecha { get; set; }

        public virtual Inscripciones Inscripcion { get; set; }
    }
}
