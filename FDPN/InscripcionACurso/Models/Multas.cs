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
    
    public partial class Multas
    {
        public int MultaId { get; set; }
        public int Eventos1 { get; set; }
        public int Eventos2 { get; set; }
        public int Eventos3 { get; set; }
        public int Eventos4 { get; set; }
        public int Eventos5 { get; set; }
        public Nullable<System.DateTime> FechaPago { get; set; }
        public string Boleta { get; set; }
        public Nullable<double> Monto { get; set; }
        public string DcsoMedico { get; set; }
        public Nullable<int> UsuarioId { get; set; }
        public Nullable<bool> Subsanada { get; set; }
        public string Torneo { get; set; }
        public System.DateTime FechaTorneo { get; set; }
        public Nullable<int> InscripcionId { get; set; }
    
        public virtual Inscripciones Inscripciones { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
