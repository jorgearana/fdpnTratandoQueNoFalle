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
    
    public partial class PCurso
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PCurso()
        {
            this.PCalendario = new HashSet<PCalendario>();
            this.PCurso1 = new HashSet<PCurso>();
            this.PHorarios = new HashSet<PHorarios>();
            this.PTemas = new HashSet<PTemas>();
        }
    
        public int CursoId { get; set; }
        public string Nombre { get; set; }
        public string Objetivos { get; set; }
        public int Requisito { get; set; }
        public int Mesesduracion { get; set; }
        public int Diasduracion { get; set; }
        public int DisciplinaId { get; set; }
    
        public virtual Disciplina Disciplina { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PCalendario> PCalendario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PCurso> PCurso1 { get; set; }
        public virtual PCurso PCurso2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHorarios> PHorarios { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PTemas> PTemas { get; set; }
    }
}
