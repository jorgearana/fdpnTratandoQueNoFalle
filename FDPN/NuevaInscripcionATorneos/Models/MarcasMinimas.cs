using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class MarcasMinimas
    {
        public int? TagPtr { get; set; }
        public string TagGender { get; set; }
        public string TagIndrel { get; set; }
        public int? TagDist { get; set; }
        public string TagStroke { get; set; }
        public short? LowAge { get; set; }
        public short? HighAge { get; set; }
        public float? TagTime { get; set; }
        public string TagCourse { get; set; }
        public string DivAbbr { get; set; }
        public int TimeStdId { get; set; }
        public int MeetId { get; set; }

        public virtual Torneo Meet { get; set; }
    }
}
