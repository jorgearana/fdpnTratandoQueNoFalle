using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class Antiguo
    {
        public Antiguo()
        {
            Entrenadores = new HashSet<Entrenadores>();
            Inscripciones = new HashSet<Inscripciones>();
        }

        public int AntiguoId { get; set; }
        public string Detalle { get; set; }

        public virtual ICollection<Entrenadores> Entrenadores { get; set; }
        public virtual ICollection<Inscripciones> Inscripciones { get; set; }
    }
}
