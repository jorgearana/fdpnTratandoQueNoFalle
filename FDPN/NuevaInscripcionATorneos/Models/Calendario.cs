using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class Calendario
    {
        public Calendario()
        {
            Atfexpediente = new HashSet<Atfexpediente>();
        }

        public DateTime Inicio { get; set; }
        public DateTime Fin { get; set; }
        public string Evento { get; set; }
        public string Sede { get; set; }
        public string Carácter { get; set; }
        public string Observación { get; set; }
        public string Organizador { get; set; }
        public int EventoId { get; set; }
        public int DisciplinaId { get; set; }
        public bool Internacional { get; set; }

        public virtual Disciplina Disciplina { get; set; }
        public virtual ICollection<Atfexpediente> Atfexpediente { get; set; }
    }
}
