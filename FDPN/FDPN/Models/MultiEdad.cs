//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FDPN.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class MultiEdad
    {
        public Nullable<int> event_ptr { get; set; }
        public Nullable<short> low_age { get; set; }
        public Nullable<short> high_age { get; set; }
        public string Heats_infinal { get; set; }
        public Nullable<short> Num_Heatsinfinal { get; set; }
        public int MeetId { get; set; }
        public int MultiAge { get; set; }
        public int EventId { get; set; }
    
        public virtual Eventos Eventos { get; set; }
    }
}
