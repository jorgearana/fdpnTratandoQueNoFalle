using FDPN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FDPN.ViewModels.Resultados
{
    public class RankingFInaViewModel
    {
        public List<Meet> torneos { get; set; }
        public Dictionary<int, string> periodo { get; set; }
        public List<int> edadesminimas { get; set; }
        public List<int> edadesmaximas { get; set; }
        public List<string> Piscinas { get; set; }
        public Dictionary<int, string> Sexos { get; set; }

        public string Sexo { get; set; }

        public int edadminima { get; set; }
        public int edadmaxima { get; set; }
        public int periodoid { get; set; }

        public List<RESULTS> resultados { get; set; }
        public int[] torneosId { get; set; }

        public string piscina { get; set; }


    }

}