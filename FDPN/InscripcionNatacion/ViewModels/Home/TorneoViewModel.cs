﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace InscripcionNatacion.ViewModels.Home
{
    public class TorneoViewModel
    {
        public FDPN.Models.Torneo torneo { get; set; }
        public int diferencia { get; set; }
        public DateTime FechaFin{ get; set; }
        public Boolean Tieneinscritos { get; set; }
    }
}