using FDPN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FDPN.ViewModels.Resultados
{
    public class ResultadoDeUnTorneoViewModel
    {
        public List<Team> EquiposParticipantes { get; set; }
        public List<RESULTS> resultadoFinales { get; set; }
        public List<RESULTS> resultadoPreliminares { get; set; }
        public  Dictionary<float, DiccionarioPruebas> pruebas { get; set; }
        public int MeetId { get; set; }
        public int clubid { get; set; }
        public string pruebaid { get; set; }
        public  Meet torneo{ get; set; }
        public Team club { get; set; }

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