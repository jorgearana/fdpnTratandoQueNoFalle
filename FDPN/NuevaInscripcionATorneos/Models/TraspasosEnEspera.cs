using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class TraspasosEnEspera
    {
        public int EEsperaId { get; set; }
        public string Dni { get; set; }
        public int ClubSolicitante { get; set; }
        public DateTime? Fecha { get; set; }
        public bool Liberado { get; set; }
        public int? IsncripcionId { get; set; }

        public virtual Club ClubSolicitanteNavigation { get; set; }
        public virtual Inscripciones Isncripcion { get; set; }
    }
}
