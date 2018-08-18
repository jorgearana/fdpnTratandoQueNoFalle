using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FDPN.Models;

namespace FDPN.ViewModels.Masters
{
    public class ResultadosDeUnaPruebaMastersViewModel
    {
        public Dictionary<CategoriasMasters, List<RESULTSMasters>> Resultados { get; set; }
        public MEETMasters torneo { get; set; }
        public Pruebas prueba { get; set; }
    }
    
}

 