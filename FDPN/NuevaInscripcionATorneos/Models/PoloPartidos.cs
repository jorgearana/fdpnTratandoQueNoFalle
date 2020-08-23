using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class PoloPartidos
    {
        public PoloPartidos()
        {
            PoloResultados = new HashSet<PoloResultados>();
        }

        public int PartidoId { get; set; }
        public int FechaId { get; set; }
        public int GrupoId { get; set; }
        public double Hora { get; set; }
        public string Sexo { get; set; }
        public int RondaId { get; set; }
        public int Equipo1 { get; set; }
        public int Equipo2 { get; set; }
        public int? TorneoId { get; set; }

        public virtual PoloFechas Fecha { get; set; }
        public virtual PoloGrupos Grupo { get; set; }
        public virtual PoloRondas Ronda { get; set; }
        public virtual PoloTorneo Torneo { get; set; }
        public virtual ICollection<PoloResultados> PoloResultados { get; set; }
    }
}
