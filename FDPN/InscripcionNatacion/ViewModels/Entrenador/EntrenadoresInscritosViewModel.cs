using FDPN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InscripcionNatacion.ViewModels.Entrenador
{
    public class EntrenadoresInscritosViewModel
    {
        public FDPN.Models.Torneo torneo { get; set; }
        public List<EntrenadorInscrito> entrenadores { get; set; }
    }
}