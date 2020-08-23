using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class Vivo
    {
        public int VivoId { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public string Directorio { get; set; }
    }
}
