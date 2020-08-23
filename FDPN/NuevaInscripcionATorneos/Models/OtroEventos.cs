using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class OtroEventos
    {
        public OtroEventos()
        {
            OtroEntradas = new HashSet<OtroEntradas>();
            OtroGrupal = new HashSet<OtroGrupal>();
        }

        public int EventoId { get; set; }
        public string EventSex { get; set; }
        public string EventNombre { get; set; }
        public int EventSerie { get; set; }
        public int TorneoId { get; set; }
        public int EdadMaxima { get; set; }
        public int EdadMinima { get; set; }
        public bool Grupal { get; set; }
        public int CantidadParticipanes { get; set; }
        public int NumeroSaltos { get; set; }

        public virtual OtroTorneo Torneo { get; set; }
        public virtual ICollection<OtroEntradas> OtroEntradas { get; set; }
        public virtual ICollection<OtroGrupal> OtroGrupal { get; set; }
    }
}
