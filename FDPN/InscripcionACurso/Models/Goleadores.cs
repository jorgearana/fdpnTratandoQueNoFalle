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
    
    public partial class Goleadores
    {
        public int GoleadorId { get; set; }
        public int JugadorId { get; set; }
        public int Goles { get; set; }
    
        public virtual Jugadores Jugadores { get; set; }
    }
}
