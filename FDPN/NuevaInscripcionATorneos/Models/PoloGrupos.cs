using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class PoloGrupos
    {
        public PoloGrupos()
        {
            PoloPartidos = new HashSet<PoloPartidos>();
            PoloPosicion = new HashSet<PoloPosicion>();
        }

        public int GrupoId { get; set; }
        public string Nombre { get; set; }
        public int Sexoid { get; set; }
        public int? TorneoId { get; set; }

        public virtual ICollection<PoloPartidos> PoloPartidos { get; set; }
        public virtual ICollection<PoloPosicion> PoloPosicion { get; set; }
    }
}
