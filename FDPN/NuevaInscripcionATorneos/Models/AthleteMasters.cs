using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class AthleteMasters
    {
        public AthleteMasters()
        {
            Resultsmasters = new HashSet<Resultsmasters>();
        }

        public int Athlete { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public string Sex { get; set; }
        public DateTime? Birth { get; set; }
        public short Age { get; set; }
        public string IdNo { get; set; }
        public int AthleteId { get; set; }

        public virtual ICollection<Resultsmasters> Resultsmasters { get; set; }
    }
}
