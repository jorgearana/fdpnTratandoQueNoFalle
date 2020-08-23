using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class Afiliacion
    {
        public int AfiliacionId { get; set; }
        public int UsuarioId { get; set; }
        public DateTime FechaAfiliacion { get; set; }
        public int VoucherId { get; set; }
        public int ClubId { get; set; }
        public int ProcesadoId { get; set; }
        public int? InscripcionId { get; set; }

        public virtual Club Club { get; set; }
        public virtual Inscripciones Inscripcion { get; set; }
        public virtual Procesado Procesado { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Vouchers Voucher { get; set; }
    }
}
