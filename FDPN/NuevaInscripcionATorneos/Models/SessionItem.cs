using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class SessionItem
    {
        public int? SessOrder { get; set; }
        public int? SessPtr { get; set; }
        public int? EventPtr { get; set; }
        public string SessRnd { get; set; }
        public string ReptType { get; set; }
        public int? DelaySeconds { get; set; }
        public bool AltWith { get; set; }
        public short? TimedFinalheats { get; set; }
        public int? EventToAlternateWith { get; set; }
        public string DelayDesc { get; set; }
        public short? AltHeatsStartCount { get; set; }
        public int SessitemId { get; set; }
        public int Meetid { get; set; }

        public virtual Torneo Meet { get; set; }
    }
}
