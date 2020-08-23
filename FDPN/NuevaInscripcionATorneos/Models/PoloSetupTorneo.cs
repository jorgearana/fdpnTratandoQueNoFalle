using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class PoloSetupTorneo
    {
        public int SetupId { get; set; }
        public int TorneoId { get; set; }
        public bool PermiteNoAfiliados { get; set; }
        public bool PermiteSubirEdad { get; set; }
        public bool PermiteMixtos { get; set; }
        public bool PorLigas { get; set; }

        public virtual PoloTorneo Torneo { get; set; }
    }
}
