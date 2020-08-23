using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class PoloPosicion
    {
        public int PosicionId { get; set; }
        public int Pj { get; set; }
        public int Pg { get; set; }
        public int Pe { get; set; }
        public int Pp { get; set; }
        public int Gf { get; set; }
        public int Gc { get; set; }
        public int Dg { get; set; }
        public int Puntos { get; set; }
        public int EquipoId { get; set; }
        public int GrupoId { get; set; }
        public int? TorneoId { get; set; }

        public virtual PoloEquipos Equipo { get; set; }
        public virtual PoloGrupos Grupo { get; set; }
        public virtual PoloTorneo Torneo { get; set; }
    }
}
