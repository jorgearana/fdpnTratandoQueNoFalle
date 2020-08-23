using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class Sheet1
    {
        public DateTime Inicio { get; set; }
        public DateTime Fin { get; set; }
        public string Evento { get; set; }
        public string Sede { get; set; }
        public string Carácter { get; set; }
        public string Observación { get; set; }
        public string Organizador { get; set; }
        public int Disciplina { get; set; }
        public bool Internacional { get; set; }
    }
}
