//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FDPN.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Afiliacion
    {
        public int AfiliacionID { get; set; }
        public int UsuarioId { get; set; }
        public System.DateTime FechaAfiliacion { get; set; }
        public int VoucherId { get; set; }
        public int ClubId { get; set; }
        public int ProcesadoId { get; set; }
        public Nullable<int> InscripcionId { get; set; }
    
        public virtual Club Club { get; set; }
        public virtual Inscripciones Inscripciones { get; set; }
        public virtual Procesado Procesado { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Vouchers Vouchers { get; set; }
    }
}
