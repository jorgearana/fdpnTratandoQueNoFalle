using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FDPN.Models;

namespace FDPN.ViewModels.Masters
{
    public class resultadodelnadadorMastersenuntorneoViewModel
    {
        public MEETMasters torneo { get; set; }
        public AthleteMasters atleta { get; set; }
        public List<RESULTS> resultados { get; set; }
        public Afiliado afiliado { get; set; }

    }
}