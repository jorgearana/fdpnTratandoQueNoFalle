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
    
    public partial class AthleteMasters
    {
        public AthleteMasters()
        {
            this.RESULTSMasters = new HashSet<RESULTSMasters>();
        }
    
        public int Athlete { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public string Sex { get; set; }
        public Nullable<System.DateTime> Birth { get; set; }
        public short Age { get; set; }
        public string ID_NO { get; set; }
        public int AthleteId { get; set; }
    
        public virtual ICollection<RESULTSMasters> RESULTSMasters { get; set; }
    }
}
