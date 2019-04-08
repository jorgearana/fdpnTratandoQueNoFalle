using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FDPN.Models;


namespace InscripcionNatacion.ViewModels.Torneo
{
    public class NadadorConTiempoViewModel
    {
        public Inscripciones afiliado{ get; set; }
        public RESULTS resultado { get; set; }

    }
}