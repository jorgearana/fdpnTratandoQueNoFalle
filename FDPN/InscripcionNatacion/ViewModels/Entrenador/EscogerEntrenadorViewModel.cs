using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FDPN.Models;

namespace InscripcionNatacion.ViewModels.Entrenador
{
    public class EscogerEntrenadorViewModel
    {
        public List<FDPN.Models.Entrenadores> entrenadores { get; set; }
        public FDPN.Models.Torneo torneo { get; set; }
    }
}