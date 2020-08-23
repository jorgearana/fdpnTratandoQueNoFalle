using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class TagNames
    {
        public int TagPtr { get; set; }
        public string TagName { get; set; }
        public bool ForScoring { get; set; }
        public bool ForEntryqual { get; set; }
        public bool ForTimestd { get; set; }
        public string TagDesc { get; set; }
        public int TagId { get; set; }
        public int MeetId { get; set; }
    }
}
