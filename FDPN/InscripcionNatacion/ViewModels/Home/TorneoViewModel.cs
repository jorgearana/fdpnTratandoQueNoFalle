using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace InscripcionNatacion.ViewModels.Home
{
    public class TorneoViewModel
    {
        public FDPN.Models.SetupTorneo torneo { get; set; }
        public int diferencia { get; set; }
        public DateTime FechaFin{ get; set; }
        public DateTime Start { get; set; }
        public bool Tieneinscritos { get; set; }
        public bool Masters { get; set; }
    }
}