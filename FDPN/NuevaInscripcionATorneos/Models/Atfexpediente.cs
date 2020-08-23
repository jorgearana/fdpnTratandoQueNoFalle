using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class Atfexpediente
    {
        public Atfexpediente()
        {
            Atfdeportista = new HashSet<Atfdeportista>();
        }

        public int ExpedienteId { get; set; }
        public int EventoId { get; set; }
        public bool Bases { get; set; }
        public bool Formato { get; set; }

        public virtual Calendario Evento { get; set; }
        public virtual ICollection<Atfdeportista> Atfdeportista { get; set; }
    }
}
