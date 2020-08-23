using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class Teammasters
    {
        public Teammasters()
        {
            Resultsmasters = new HashSet<Resultsmasters>();
        }

        public int Team { get; set; }
        public int TeamId { get; set; }
        public string Tcode { get; set; }
        public string Tname { get; set; }

        public virtual ICollection<Resultsmasters> Resultsmasters { get; set; }
    }
}
