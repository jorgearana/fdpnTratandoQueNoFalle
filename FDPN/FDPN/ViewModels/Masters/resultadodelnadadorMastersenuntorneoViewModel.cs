using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FDPN.Models;

namespace FDPN.ViewModels.Masters
{
    public class resultadodelnadadorMastersenuntorneoViewModel
    {
        public MeetMasters torneo { get; set; }
        public AthleteMasters atleta { get; set; }
        public List<RESULTSMasters> resultados { get; set; }
        public Inscripciones Inscripciones { get; set; }

    }
}