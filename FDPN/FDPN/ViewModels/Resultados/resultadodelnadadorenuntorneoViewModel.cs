using FDPN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FDPN.ViewModels.Resultados
{
    public class resultadodelnadadorenuntorneoViewModel
    {
        public Meet torneo  { get; set; }
        public  Athlete atleta { get; set; }
        public List<RESULTS> resultados { get; set; }
        public Inscripciones Inscripciones { get; set; }

    }
}