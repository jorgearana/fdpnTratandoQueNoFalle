using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class HistorialEntrenador
    {
        public int HistoriaId { get; set; }
        public int EntrenadorId { get; set; }
        public int ClubId { get; set; }
        public DateTime Fecha { get; set; }

        public virtual Club Club { get; set; }
        public virtual Entrenadores Entrenador { get; set; }
    }
}
