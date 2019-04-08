using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using FDPN.Models;

namespace InscripcionNatacion.ViewModels.Torneo
{
    public class ListadoDeTorneosViewModel
    {
        public FDPN.Models.Torneo torneo { get; set; }
        public List<Sesion> sesiones { get; set; }
    }
}