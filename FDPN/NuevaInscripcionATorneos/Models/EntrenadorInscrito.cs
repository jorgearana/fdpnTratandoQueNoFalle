using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class EntrenadorInscrito
    {
        public int EntrenadorInscritoId { get; set; }
        public int EntrenadorId { get; set; }
        public int MeetId { get; set; }

        public virtual Entrenadores Entrenador { get; set; }
        public virtual Torneo Meet { get; set; }
    }
}
