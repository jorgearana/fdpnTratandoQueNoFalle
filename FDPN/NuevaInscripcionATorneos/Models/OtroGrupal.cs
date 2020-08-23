using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class OtroGrupal
    {
        public int GrupalId { get; set; }
        public int EventoId { get; set; }
        public int CantidadParticipantes { get; set; }
        public bool Mixto { get; set; }

        public virtual OtroEventos Evento { get; set; }
    }
}
