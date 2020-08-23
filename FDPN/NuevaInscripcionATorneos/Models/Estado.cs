using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class Estado
    {
        public Estado()
        {
            Entrenadores = new HashSet<Entrenadores>();
            Inscripciones = new HashSet<Inscripciones>();
        }

        public int EstadoId { get; set; }
        public string Detalle { get; set; }

        public virtual ICollection<Entrenadores> Entrenadores { get; set; }
        public virtual ICollection<Inscripciones> Inscripciones { get; set; }
    }
}
