using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class Basetimes
    {
        public double? Year { get; set; }
        public string Course { get; set; }
        public string Gender { get; set; }
        public double? RelayCount { get; set; }
        public double? Distance { get; set; }
        public string Stroke { get; set; }
        public string Basetime { get; set; }
        public double? Segundos { get; set; }
        public int TiempoId { get; set; }
    }
}
