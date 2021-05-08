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
        public List<TeamMasters > EquiposParticipantes { get; set; }
        public List<RESULTSMasters> resultadoFinales { get; set; }
        public List<RESULTSMasters> resultadoPreliminares { get; set; }
        public Dictionary<float, DiccionarioPruebas> pruebas { get; set; }
        public int MeetId { get; set; }
        public int clubid { get; set; }
        public string pruebaid { get; set; }
        public MeetMasters torneo { get; set; }
        public TeamMasters club { get; set; }
    }

    public class DiccionarioPruebas
    {
        public float MeetEvent { get; set; }
        public string NombrePrueba { get; set; }
    }
}