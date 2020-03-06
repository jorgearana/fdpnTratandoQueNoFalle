using FDPN.Models;
using InscripcionACurso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InscripcionNatacion.ViewModels.Inscrito
{
    public class ResumenCantidadesFDPN
    {
        public SetupTorneo torneo { get; set; }
        public int nadadores { get; set; }
        public int equipos { get; set; }

    }
}