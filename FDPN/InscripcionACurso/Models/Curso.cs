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
    
    public partial class Curso
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Curso()
        {
            this.CursoInscripcion = new HashSet<CursoInscripcion>();
        }
    
        public int CursoId { get; set; }
        public string Nombre { get; set; }
        public string Ciudad { get; set; }
        public string Direccion { get; set; }
        public System.DateTime Inicio { get; set; }
        public System.DateTime Fin { get; set; }
        public Nullable<int> DisciplinaId { get; set; }
        public Nullable<System.TimeSpan> Hora { get; set; }
        public int CantidadMaxima { get; set; }
        public bool ParaAfiliados { get; set; }
        public string Enlace { get; set; }
        public string PassWord { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CursoInscripcion> CursoInscripcion { get; set; }
    }
}
