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
    
    public partial class Sesion
    {
        public Nullable<short> Sess_no { get; set; }
        public string Sess_ltr { get; set; }
        public int Sess_ptr { get; set; }
        public Nullable<short> Sess_day { get; set; }
        public Nullable<int> Sess_starttime { get; set; }
        public Nullable<short> Sess_entrymax { get; set; }
        public string Sess_name { get; set; }
        public Nullable<short> Sess_interval { get; set; }
        public string Sess_course { get; set; }
        public Nullable<short> Sess_entrymaxind { get; set; }
        public Nullable<short> Sess_entrymaxrel { get; set; }
        public Nullable<short> Sess_backinterval { get; set; }
        public Nullable<short> Sess_divinginterval { get; set; }
        public Nullable<short> Sess_chaseinterval { get; set; }
        public int MeetId { get; set; }
        public int SessionId { get; set; }
    
        public virtual Torneo Torneo { get; set; }
    }
}
