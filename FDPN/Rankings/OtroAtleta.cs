//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Rankings
{
    using System;
    using System.Collections.Generic;
    
    public partial class OtroAtleta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OtroAtleta()
        {
            this.OtroEntradas = new HashSet<OtroEntradas>();
        }
    
        public int AtletaId { get; set; }
        public int TorneoId { get; set; }
        public int InscripcionId { get; set; }
        public int TeamId { get; set; }
    
        public virtual Inscripciones Inscripciones { get; set; }
        public virtual OtroEquipo OtroEquipo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OtroEntradas> OtroEntradas { get; set; }
    }
}