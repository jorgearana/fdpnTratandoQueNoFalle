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
    
    public partial class Inscripciones
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Inscripciones()
        {
            this.Afiliacion = new HashSet<Afiliacion>();
            this.HistorialdeAfiliaciones = new HashSet<HistorialdeAfiliaciones>();
            this.HistorialTraspasos = new HashSet<HistorialTraspasos>();
            this.Multas = new HashSet<Multas>();
            this.TatoInformeAsistencias = new HashSet<TatoInformeAsistencias>();
            this.TatoInformeEntrenador = new HashSet<TatoInformeEntrenador>();
            this.TatoSeleccionado = new HashSet<TatoSeleccionado>();
            this.Traspasos = new HashSet<Traspasos>();
            this.TraspasosEnEspera = new HashSet<TraspasosEnEspera>();
        }
    
        public int InscripcionId { get; set; }
        public string DNI { get; set; }
        public int ClubID { get; set; }
        public int TipoAfiliadoID { get; set; }
        public int EstadoID { get; set; }
        public int AntiguoId { get; set; }
        public string RutaFotoAntigua { get; set; }
        public Nullable<int> Borrado { get; set; }
        public string FotoDNI { get; set; }
        public int DisciplinaId { get; set; }
        public string RutaFoto { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Afiliacion> Afiliacion { get; set; }
        public virtual Afiliado Afiliado { get; set; }
        public virtual Antiguo Antiguo { get; set; }
        public virtual Club Club { get; set; }
        public virtual Disciplina Disciplina { get; set; }
        public virtual Estado Estado { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HistorialdeAfiliaciones> HistorialdeAfiliaciones { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HistorialTraspasos> HistorialTraspasos { get; set; }
        public virtual TipoAfiliado TipoAfiliado { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Multas> Multas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TatoInformeAsistencias> TatoInformeAsistencias { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TatoInformeEntrenador> TatoInformeEntrenador { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TatoSeleccionado> TatoSeleccionado { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Traspasos> Traspasos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TraspasosEnEspera> TraspasosEnEspera { get; set; }
    }
}
