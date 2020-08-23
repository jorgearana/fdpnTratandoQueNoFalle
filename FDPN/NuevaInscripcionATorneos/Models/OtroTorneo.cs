using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class OtroTorneo
    {
        public OtroTorneo()
        {
            OtroEntradas = new HashSet<OtroEntradas>();
            OtroEquipo = new HashSet<OtroEquipo>();
            OtroEventos = new HashSet<OtroEventos>();
            OtroSetupTorneo = new HashSet<OtroSetupTorneo>();
        }

        public int TorneoId { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaCierre { get; set; }
        public bool PorLigas { get; set; }
        public bool EdadAdiciembre { get; set; }
        public int? DisciplinaId { get; set; }

        public virtual Disciplina Disciplina { get; set; }
        public virtual ICollection<OtroEntradas> OtroEntradas { get; set; }
        public virtual ICollection<OtroEquipo> OtroEquipo { get; set; }
        public virtual ICollection<OtroEventos> OtroEventos { get; set; }
        public virtual ICollection<OtroSetupTorneo> OtroSetupTorneo { get; set; }
    }
}
