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
    
    public partial class PHorarios
    {
        public int HorarioId { get; set; }
        public System.DateTime Dia { get; set; }
        public double HoraInicio { get; set; }
        public int CursoId { get; set; }
        public double HoraFin { get; set; }
    
        public virtual PCurso PCurso { get; set; }
    }
}