using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class Athlete
    {
        public Athlete()
        {
            Results = new HashSet<Results>();
        }

        public int Athlete1 { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public string Sex { get; set; }
        public DateTime? Birth { get; set; }
        public short Age { get; set; }
        public string IdNo { get; set; }
        public int AthleteId { get; set; }

        public virtual ICollection<Results> Results { get; set; }
    }
}
