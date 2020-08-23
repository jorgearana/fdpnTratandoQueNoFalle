using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class CambiosDni
    {
        public int CambioId { get; set; }
        public string Dni { get; set; }
        public DateTime Fecha { get; set; }
        public string Dniantiguo { get; set; }
    }
}
