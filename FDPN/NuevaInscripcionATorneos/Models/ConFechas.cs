using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class ConFechas
    {
        public DateTime Inicio { get; set; }
        public DateTime Final { get; set; }
        public string Eventos { get; set; }
        public string Ciudad { get; set; }
        public string Pais { get; set; }
        public string Modalidad { get; set; }
        public string F7 { get; set; }
        public string Organiza { get; set; }
        public string Nota { get; set; }
        public int CalendarioId { get; set; }
    }
}
