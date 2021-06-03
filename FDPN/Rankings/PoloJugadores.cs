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
    
    public partial class PoloJugadores
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PoloJugadores()
        {
            this.PoloGoleadores = new HashSet<PoloGoleadores>();
        }
    
        public int JugadorId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int EquipoId { get; set; }
        public string Sexo { get; set; }
        public int Edad { get; set; }
        public Nullable<int> TorneoId { get; set; }
    
        public virtual PoloEquipos PoloEquipos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PoloGoleadores> PoloGoleadores { get; set; }
        public virtual PoloTorneo PoloTorneo { get; set; }
    }
}