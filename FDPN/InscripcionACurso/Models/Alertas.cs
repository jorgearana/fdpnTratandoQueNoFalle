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
    
    public partial class Alertas
    {
        public int AlertaId { get; set; }
        public System.DateTime Fecha { get; set; }
        public string Alerta { get; set; }
        public Nullable<int> NoticiaId { get; set; }
    
        public virtual Noticias Noticias { get; set; }
    }
}
