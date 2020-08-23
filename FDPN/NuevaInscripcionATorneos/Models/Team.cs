using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class Team
    {
        public Team()
        {
            Results = new HashSet<Results>();
        }

        public int Team1 { get; set; }
        public int TeamId { get; set; }
        public string Tcode { get; set; }
        public string Tname { get; set; }

        public virtual ICollection<Results> Results { get; set; }
    }
}
