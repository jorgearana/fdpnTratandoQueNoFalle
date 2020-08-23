using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class PoloFechas
    {
        public PoloFechas()
        {
            PoloPartidos = new HashSet<PoloPartidos>();
        }

        public int FechaId { get; set; }
        public DateTime Dia { get; set; }
        public int? TorneoId { get; set; }

        public virtual PoloTorneo Torneo { get; set; }
        public virtual ICollection<PoloPartidos> PoloPartidos { get; set; }
    }
}
