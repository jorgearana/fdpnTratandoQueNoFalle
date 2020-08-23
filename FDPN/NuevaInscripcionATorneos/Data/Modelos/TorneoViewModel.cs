

using NuevaInscripcionATorneos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NuevaInscripcionATorneos.Data.Modelos
{
    public class TorneoViewModel
    {
       public SetupTorneo torneo { get; set; }
        public int diferencia { get; set; }
        public DateTime FechaFin { get; set; }
        public DateTime Start { get; set; }
        public bool Tieneinscritos { get; set; }
        public bool Masters { get; set; }
    }
}
