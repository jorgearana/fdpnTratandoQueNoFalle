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
    
    public partial class PProfesor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PProfesor()
        {
            this.PCalendario = new HashSet<PCalendario>();
        }
    
        public int ProfesorId { get; set; }
        public string Nombre { get; set; }
        public string Nacionalidad { get; set; }
        public string DetalleRapido { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PCalendario> PCalendario { get; set; }
    }
}
