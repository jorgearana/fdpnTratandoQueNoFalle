using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class MultiEdad
    {
        public int? EventPtr { get; set; }
        public short? LowAge { get; set; }
        public short? HighAge { get; set; }
        public string HeatsInfinal { get; set; }
        public short? NumHeatsinfinal { get; set; }
        public int MeetId { get; set; }
        public int MultiAgeId { get; set; }

        public virtual Torneo Meet { get; set; }
    }
}
