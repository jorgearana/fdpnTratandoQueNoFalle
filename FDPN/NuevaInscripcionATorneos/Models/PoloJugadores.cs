using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class PoloJugadores
    {
        public PoloJugadores()
        {
            PoloGoleadores = new HashSet<PoloGoleadores>();
        }

        public int JugadorId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int EquipoId { get; set; }
        public string Sexo { get; set; }
        public int Edad { get; set; }
        public int? TorneoId { get; set; }

        public virtual PoloEquipos Equipo { get; set; }
        public virtual PoloTorneo Torneo { get; set; }
        public virtual ICollection<PoloGoleadores> PoloGoleadores { get; set; }
    }
}
