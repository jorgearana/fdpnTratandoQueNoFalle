using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class PoloResultados
    {
        public int ResultadoId { get; set; }
        public int A1 { get; set; }
        public int A2 { get; set; }
        public int A3 { get; set; }
        public int A4 { get; set; }
        public int T1 { get; set; }
        public int T2 { get; set; }
        public int B1 { get; set; }
        public int B2 { get; set; }
        public int B3 { get; set; }
        public int B4 { get; set; }
        public int PartidaId { get; set; }
        public int? TorneoId { get; set; }

        public virtual PoloPartidos Partida { get; set; }
        public virtual PoloTorneo Torneo { get; set; }
    }
}
