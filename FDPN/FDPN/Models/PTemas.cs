//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FDPN.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PTemas
    {
        public int TemaId { get; set; }
        public bool Teorico { get; set; }
        public bool Practivo { get; set; }
        public string Detalle { get; set; }
        public Nullable<int> CursoId { get; set; }
    
        public virtual PCurso PCurso { get; set; }
    }
}
