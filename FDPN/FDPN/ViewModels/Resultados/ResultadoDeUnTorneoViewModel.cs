using FDPN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FDPN.ViewModels.Resultados
{
    public class ResultadoDeUnTorneoViewModel
    {
        public List<TEAM> EquiposParticipantes { get; set; }
        public List<RESULTS> resultado { get; set; }
        public Dictionary<string, DiccionarioPruebas> pruebas { get; set; }
        public int meetid { get; set; }
        public int clubid { get; set; }
        public string pruebaid { get; set; }
        public  MEET torneo{ get; set; }
        public TEAM club { get; set; }


    }

    public class DiccionarioPruebas
    {
        public string MeetEvent { get; set; }
        public string NombrePrueba { get; set; }
    }
}