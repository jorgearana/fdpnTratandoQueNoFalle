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
    
    public partial class RESULTS
    {
        public int MEET { get; set; }
        public int ATHLETE { get; set; }
        public string I_R { get; set; }
        public int TEAM { get; set; }
        public string SCORE { get; set; }
        public string F_P { get; set; }
        public string EX { get; set; }
        public byte NT { get; set; }
        public short AGE { get; set; }
        public string DISTANCE { get; set; }
        public string STROKE { get; set; }
        public string MTEV { get; set; }
        public short LO_HI { get; set; }
        public short POINTS { get; set; }
        public short PLACE { get; set; }
        public string COURSE { get; set; }
        public string DIVISION { get; set; }
        public Nullable<int> PFina { get; set; }
        public Nullable<int> AthleteId { get; set; }
        public Nullable<int> MeetId { get; set; }
        public Nullable<int> TeamId { get; set; }
        public Nullable<int> PruebaId { get; set; }
        public int ResultId { get; set; }
        public Nullable<double> Tiempobase { get; set; }
    
        public virtual Athlete Athlete1 { get; set; }
        public virtual MEET MEET1 { get; set; }
        public virtual Pruebas Pruebas { get; set; }
        public virtual TEAM TEAM1 { get; set; }
    }
}
