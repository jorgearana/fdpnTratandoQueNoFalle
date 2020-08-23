using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class PoloEquipos
    {
        public PoloEquipos()
        {
            PoloJugadores = new HashSet<PoloJugadores>();
            PoloPosicion = new HashSet<PoloPosicion>();
            PoloPosicionFinal = new HashSet<PoloPosicionFinal>();
        }

        public int EquipoId { get; set; }
        public string Nombre { get; set; }
        public string Sexo { get; set; }
        public int? TorneoId { get; set; }

        public virtual ICollection<PoloJugadores> PoloJugadores { get; set; }
        public virtual ICollection<PoloPosicion> PoloPosicion { get; set; }
        public virtual ICollection<PoloPosicionFinal> PoloPosicionFinal { get; set; }
    }
}
