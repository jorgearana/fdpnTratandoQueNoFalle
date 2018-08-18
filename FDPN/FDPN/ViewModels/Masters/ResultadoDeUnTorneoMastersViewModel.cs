using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FDPN.ViewModels.Masters;
using FDPN.Models;

namespace FDPN.ViewModels.Masters
{
    public class ResultadoDeUnTorneoMastersViewModel
    {
        public List<TEAMMasters > EquiposParticipantes { get; set; }
        public List<RESULTSMasters> resultadoFinales { get; set; }
        public List<RESULTSMasters> resultadoPreliminares { get; set; }
        public Dictionary<float, DiccionarioPruebas> pruebas { get; set; }
        public int meetid { get; set; }
        public int clubid { get; set; }
        public string pruebaid { get; set; }
        public MEETMasters torneo { get; set; }
        public TEAMMasters club { get; set; }
    }

    public class DiccionarioPruebas
    {
        public float MeetEvent { get; set; }
        public string NombrePrueba { get; set; }
    }
}