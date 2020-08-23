using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class PoloRondas
    {
        public PoloRondas()
        {
            PoloPartidos = new HashSet<PoloPartidos>();
        }

        public int RondaId { get; set; }
        public string Nombre { get; set; }
        public int? TorneoId { get; set; }

        public virtual PoloTorneo Torneo { get; set; }
        public virtual ICollection<PoloPartidos> PoloPartidos { get; set; }
    }
}
