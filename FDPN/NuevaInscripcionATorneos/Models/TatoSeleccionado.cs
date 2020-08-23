using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class TatoSeleccionado
    {
        public int SeleccionadoId { get; set; }
        public int InscripcionId { get; set; }
        public bool Activo { get; set; }

        public virtual Inscripciones Inscripcion { get; set; }
    }
}
