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
    
    public partial class Club
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Club()
        {
            this.Afiliacion = new HashSet<Afiliacion>();
            this.Directivos = new HashSet<Directivos>();
            this.Entrenadores = new HashSet<Entrenadores>();
            this.HistorialEntrenador = new HashSet<HistorialEntrenador>();
            this.HistorialTraspasos = new HashSet<HistorialTraspasos>();
            this.Inscripciones = new HashSet<Inscripciones>();
            this.Traspasos = new HashSet<Traspasos>();
            this.TraspasosEnEspera = new HashSet<TraspasosEnEspera>();
            this.Usuario = new HashSet<Usuario>();
            this.Vouchers = new HashSet<Vouchers>();
        }
    
        public int ClubID { get; set; }
        public string NombreClub { get; set; }
        public string Iniciales { get; set; }
        public string NombreUsuario { get; set; }
        public int Activo { get; set; }
        public Nullable<int> AsociacionId { get; set; }
        public Nullable<System.DateTime> FechaPagoAfiliacion { get; set; }
        public Nullable<System.DateTime> FinVigenciaPoderes { get; set; }
        public Nullable<System.DateTime> FinVigenciaRenade { get; set; }
        public string Resolucion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Afiliacion> Afiliacion { get; set; }
        public virtual Asociaciones Asociaciones { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Directivos> Directivos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Entrenadores> Entrenadores { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HistorialEntrenador> HistorialEntrenador { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HistorialTraspasos> HistorialTraspasos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Inscripciones> Inscripciones { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Traspasos> Traspasos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TraspasosEnEspera> TraspasosEnEspera { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Usuario> Usuario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vouchers> Vouchers { get; set; }
    }
}
