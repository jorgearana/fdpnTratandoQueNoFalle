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
    
    public partial class Antiguo
    {
        public Antiguo()
        {
            this.Entrenadores = new HashSet<Entrenadores>();
            this.Inscripciones = new HashSet<Inscripciones>();
        }
    
        public int AntiguoId { get; set; }
        public string Detalle { get; set; }
    
        public virtual ICollection<Entrenadores> Entrenadores { get; set; }
        public virtual ICollection<Inscripciones> Inscripciones { get; set; }
    }
}
