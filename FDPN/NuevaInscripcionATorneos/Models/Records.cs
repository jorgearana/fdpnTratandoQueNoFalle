using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class Records
    {
        public int? TagPtr { get; set; }
        public string TagGender { get; set; }
        public string TagIndrel { get; set; }
        public int? TagDist { get; set; }
        public string TagStroke { get; set; }
        public short? LowAge { get; set; }
        public short? HighAge { get; set; }
        public short? RecordMonth { get; set; }
        public short? RecordDay { get; set; }
        public short? RecordYear { get; set; }
        public string RecordHolder { get; set; }
        public string RecordHolderteam { get; set; }
        public string RelayNames { get; set; }
        public float? RecordTime { get; set; }
        public string RecordCourse { get; set; }
        public string DivAbbr { get; set; }
        public string RecordTeamabbr { get; set; }
        public string RecordTeamlsc { get; set; }
        public int RecordId { get; set; }
    }
}
