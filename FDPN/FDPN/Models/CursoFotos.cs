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
    
    public partial class CursoFotos
    {
        public CursoFotos()
        {
            this.CursoAlumno = new HashSet<CursoAlumno>();
        }
    
        public int FotoId { get; set; }
        public string Foto { get; set; }
    
        public virtual ICollection<CursoAlumno> CursoAlumno { get; set; }
    }
}
