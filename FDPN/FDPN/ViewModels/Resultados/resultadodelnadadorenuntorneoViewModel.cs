﻿using FDPN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FDPN.ViewModels.Resultados
{
    public class resultadodelnadadorenuntorneoViewModel
    {
        public MEET torneo  { get; set; }
        public  Athlete atleta { get; set; }
        public List<RESULTS> resultados { get; set; }
        public Afiliado afiliado { get; set; }

    }
}