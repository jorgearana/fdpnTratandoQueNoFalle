using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class PoloPosicionFinal
    {
        public int PosicionId { get; set; }
        public int EquipoId { get; set; }
        public int Posicion { get; set; }
        public int? TorneoId { get; set; }

        public virtual PoloEquipos Equipo { get; set; }
        public virtual PoloTorneo Torneo { get; set; }
    }
}
