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
        public List<RESULTS> resultadoFinales { get; set; }
        public List<RESULTS> resultadoPreliminares { get; set; }
        public  Dictionary<float, DiccionarioPruebas> pruebas { get; set; }
        public int meetid { get; set; }
        public int clubid { get; set; }
        public string pruebaid { get; set; }
        public  MEET torneo{ get; set; }
        public TEAM club { get; set; }

        public Dictionary<int, int> NadadoresPorPuestos { get; set; }
        public Dictionary<int, int> HombresPorPuestos { get; set; }
        public Dictionary<int, int> MujeresPorPuestos { get; set; }
        public int CantidaddeParticipantes { get; set; }
        public int CantidadDeResultados { get; set; }
    }

    public class DiccionarioPruebas
    {
        public float MeetEvent { get; set; }
        public string NombrePrueba { get; set; }
    }
}