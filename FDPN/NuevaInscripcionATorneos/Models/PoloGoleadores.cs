using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class PoloGoleadores
    {
        public int GoleadorId { get; set; }
        public int JugadorId { get; set; }
        public int Goles { get; set; }
        public int? TorneoId { get; set; }

        public virtual PoloJugadores Jugador { get; set; }
        public virtual PoloTorneo Torneo { get; set; }
    }
}
