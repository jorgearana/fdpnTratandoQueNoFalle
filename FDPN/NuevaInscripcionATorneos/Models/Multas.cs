using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class Multas
    {
        public int MultaId { get; set; }
        public int Eventos1 { get; set; }
        public int Eventos2 { get; set; }
        public int Eventos3 { get; set; }
        public int Eventos4 { get; set; }
        public int Eventos5 { get; set; }
        public DateTime? FechaPago { get; set; }
        public string Boleta { get; set; }
        public double? Monto { get; set; }
        public string DcsoMedico { get; set; }
        public int? UsuarioId { get; set; }
        public bool? Subsanada { get; set; }
        public string Torneo { get; set; }
        public DateTime FechaTorneo { get; set; }
        public int? InscripcionId { get; set; }

        public virtual Inscripciones Inscripcion { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
