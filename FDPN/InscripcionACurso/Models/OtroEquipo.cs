//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InscripcionACurso.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class OtroEquipo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OtroEquipo()
        {
            this.OtroAtleta = new HashSet<OtroAtleta>();
            this.OtroResponsable = new HashSet<OtroResponsable>();
        }
    
        public int TeamId { get; set; }
        public int TorneoId { get; set; }
        public string Team_name { get; set; }
        public string Team_abbr { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OtroAtleta> OtroAtleta { get; set; }
        public virtual OtroTorneo OtroTorneo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OtroResponsable> OtroResponsable { get; set; }
    }
}
