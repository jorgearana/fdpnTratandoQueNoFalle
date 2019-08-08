using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InscripcionNatacion.ViewModels.OtraInscripcion
{
    public class OtroTorneoViewModel
    {
        public FDPN.Models.OtroTorneo torneo { get; set; }
        public int diferencia { get; set; }
        public DateTime FechaFin { get; set; }
        public Boolean Tieneinscritos { get; set; }
    }
}