using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class OtroAtleta
    {
        public OtroAtleta()
        {
            OtroEntradas = new HashSet<OtroEntradas>();
        }

        public int AtletaId { get; set; }
        public int TorneoId { get; set; }
        public int InscripcionId { get; set; }
        public int TeamId { get; set; }

        public virtual Inscripciones Inscripcion { get; set; }
        public virtual OtroEquipo Team { get; set; }
        public virtual ICollection<OtroEntradas> OtroEntradas { get; set; }
    }
}
