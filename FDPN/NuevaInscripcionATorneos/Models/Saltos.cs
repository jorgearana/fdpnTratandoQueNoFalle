using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class Saltos
    {
        public double? Codigo { get; set; }
        public string Nombre { get; set; }
        public double? A { get; set; }
        public double? B { get; set; }
        public double? C { get; set; }
        public double? D { get; set; }
        public double? Altura { get; set; }
        public string Tipo { get; set; }
        public int SaltoId { get; set; }
    }
}
