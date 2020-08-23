using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class SetupTorneo
    {
        public int SetupId { get; set; }
        public int TipoId { get; set; }
        public int PruebasXsesion { get; set; }
        public int PruebasXtorneo { get; set; }
        public int Meetid { get; set; }
        public bool PorLigas { get; set; }
        public int PruebasXequipo { get; set; }
        public int SinMarca { get; set; }
        public bool PermiteNoAfiliados { get; set; }
        public bool PermiteSinMarca { get; set; }
        public bool UsaMarcaMaxima { get; set; }
        public bool Debutantes { get; set; }
        public bool Masters { get; set; }
        public DateTime FechaMarcas { get; set; }

        public virtual Torneo Meet { get; set; }
        public virtual TipoTorneo Tipo { get; set; }
    }
}
