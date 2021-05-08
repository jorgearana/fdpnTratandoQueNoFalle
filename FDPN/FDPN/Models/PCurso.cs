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
    
    public partial class PCurso
    {
        public PCurso()
        {
            this.PCalendario = new HashSet<PCalendario>();
            this.PCurso1 = new HashSet<PCurso>();
            this.PHorarios = new HashSet<PHorarios>();
            this.PObjetivos = new HashSet<PObjetivos>();
            this.PTemas = new HashSet<PTemas>();
        }
    
        public int CursoId { get; set; }
        public string Nombre { get; set; }
        public int ProfesorId { get; set; }
        public Nullable<int> RequisitoCursoId { get; set; }
        public int Mesesduracion { get; set; }
        public int Diasduracion { get; set; }
        public int DisciplinaId { get; set; }
        public string Banner { get; set; }
    
        public virtual Disciplina Disciplina { get; set; }
        public virtual ICollection<PCalendario> PCalendario { get; set; }
        public virtual ICollection<PCurso> PCurso1 { get; set; }
        public virtual PCurso PCurso2 { get; set; }
        public virtual PProfesor PProfesor { get; set; }
        public virtual ICollection<PHorarios> PHorarios { get; set; }
        public virtual ICollection<PObjetivos> PObjetivos { get; set; }
        public virtual ICollection<PTemas> PTemas { get; set; }
    }
}
