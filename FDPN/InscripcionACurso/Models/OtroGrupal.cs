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
    
    public partial class OtroGrupal
    {
        public int GrupalId { get; set; }
        public int EventoId { get; set; }
        public int CantidadParticipantes { get; set; }
        public bool Mixto { get; set; }
    
        public virtual OtroEventos OtroEventos { get; set; }
    }
}
