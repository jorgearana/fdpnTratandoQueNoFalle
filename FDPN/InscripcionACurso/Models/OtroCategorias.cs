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
    
    public partial class OtroCategorias
    {
        public int CategoriaId { get; set; }
        public int DisciplinaId { get; set; }
        public string Nombre { get; set; }
        public int EdadMaxima { get; set; }
        public int EdadMinima { get; set; }
    
        public virtual Disciplina Disciplina { get; set; }
    }
}
