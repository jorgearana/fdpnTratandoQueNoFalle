using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class Meetmasters
    {
        public Meetmasters()
        {
            Resultsmasters = new HashSet<Resultsmasters>();
        }

        public int Meet { get; set; }
        public string Mname { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Course { get; set; }
        public int MeetId { get; set; }

        public virtual ICollection<Resultsmasters> Resultsmasters { get; set; }
    }
}
