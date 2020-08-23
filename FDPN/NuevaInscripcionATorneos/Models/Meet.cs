using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class Meet
    {
        public Meet()
        {
            Results = new HashSet<Results>();
        }

        public int Meet1 { get; set; }
        public string Mname { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Course { get; set; }
        public int MeetId { get; set; }

        public virtual ICollection<Results> Results { get; set; }
    }
}
