using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class Sesion
    {
        public short? SessNo { get; set; }
        public string SessLtr { get; set; }
        public int SessPtr { get; set; }
        public short? SessDay { get; set; }
        public int? SessStarttime { get; set; }
        public short? SessEntrymax { get; set; }
        public string SessName { get; set; }
        public short? SessInterval { get; set; }
        public string SessCourse { get; set; }
        public short? SessEntrymaxind { get; set; }
        public short? SessEntrymaxrel { get; set; }
        public short? SessBackinterval { get; set; }
        public short? SessDivinginterval { get; set; }
        public short? SessChaseinterval { get; set; }
        public int MeetId { get; set; }
        public int SessionId { get; set; }

        public virtual Torneo Meet { get; set; }
    }
}
