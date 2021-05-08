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
    
    public partial class Noticias
    {
        public Noticias()
        {
            this.Alertas = new HashSet<Alertas>();
            this.Fotos = new HashSet<Fotos>();
        }
    
        public int NoticiaId { get; set; }
        public string Titulo { get; set; }
        public string Corta { get; set; }
        public string Larga { get; set; }
        public System.DateTime Fecha { get; set; }
        public int DisciplinaId { get; set; }
        public int UsuarioId { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public int CategoriaId { get; set; }
        public string Palabrasclaves { get; set; }
        public Nullable<bool> Visible { get; set; }
        public string Youtube { get; set; }
    
        public virtual ICollection<Alertas> Alertas { get; set; }
        public virtual CategoriaNoticia CategoriaNoticia { get; set; }
        public virtual Disciplina Disciplina { get; set; }
        public virtual ICollection<Fotos> Fotos { get; set; }
    }
}
