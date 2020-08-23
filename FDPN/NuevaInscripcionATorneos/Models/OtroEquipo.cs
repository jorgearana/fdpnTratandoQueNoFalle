using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class OtroEquipo
    {
        public OtroEquipo()
        {
            OtroAtleta = new HashSet<OtroAtleta>();
            OtroResponsable = new HashSet<OtroResponsable>();
        }

        public int TeamId { get; set; }
        public int TorneoId { get; set; }
        public string TeamName { get; set; }
        public string TeamAbbr { get; set; }

        public virtual OtroTorneo Torneo { get; set; }
        public virtual ICollection<OtroAtleta> OtroAtleta { get; set; }
        public virtual ICollection<OtroResponsable> OtroResponsable { get; set; }
    }
}
