using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class HistorialTraspasos
    {
        public int HistorialId { get; set; }
        public int UsuarioId { get; set; }
        public int ClubId { get; set; }
        public string Dni { get; set; }
        public int VieneDe { get; set; }
        public DateTime FechaTraspaso { get; set; }
        public int? InscripcionId { get; set; }

        public virtual Club Club { get; set; }
        public virtual Inscripciones Inscripcion { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
