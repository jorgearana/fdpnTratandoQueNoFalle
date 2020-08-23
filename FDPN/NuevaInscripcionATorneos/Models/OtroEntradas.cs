using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class OtroEntradas
    {
        public int EntradaId { get; set; }
        public int EventoId { get; set; }
        public int AtletaId { get; set; }
        public int Gorro { get; set; }
        public bool Suplente { get; set; }
        public int TorneoId { get; set; }

        public virtual OtroAtleta Atleta { get; set; }
        public virtual OtroEventos Evento { get; set; }
        public virtual OtroTorneo Torneo { get; set; }
    }
}
