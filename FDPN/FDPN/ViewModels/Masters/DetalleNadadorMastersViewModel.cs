using FDPN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FDPN.ViewModels.Masters
{
    public class DetalleNadadorMastersViewModel
    {

        public AthleteMasters nadador { get; set; }
        public Inscripciones Inscripciones { get; set; }
        public List<RESULTSMasters> UltimasParticipaciones { get; set; }
        public List<RESULTSMasters> MejoresResultados { get; set; }
        public Dictionary<Pruebas, ListaTiempos> Mejorestiempos { get; set; }
        public Dictionary<Pruebas, PorAnnoLarga> MejorPorAnnoLarga { get; set; }
        public Dictionary<Pruebas, PorAnnoCorta> MejorPorAnnoCorta { get; set; }
        public List<int> Annos { get; set; }
        public Dictionary<int, Puestos> ContadorDePuestos { get; set; }
        public string searchString { get; set; }
    }

    public class ListaTiempos
    {
        public RESULTSMasters Mejortiempolarga { get; set; }
        public RESULTSMasters Mejortiempocorta { get; set; }
        public RESULTSMasters Ultimoannolarga { get; set; }
        public RESULTSMasters Ultimoannocorta { get; set; }
    }

    public class PorAnnoLarga
    {
        public RESULTSMasters uno { get; set; }
        public RESULTSMasters dos { get; set; }
        public RESULTSMasters tres { get; set; }
        public RESULTSMasters cuatro { get; set; }
        public RESULTSMasters cinco { get; set; }
    }
    public class PorAnnoCorta
    {
        public RESULTSMasters uno { get; set; }
        public RESULTSMasters dos { get; set; }
        public RESULTSMasters tres { get; set; }
        public RESULTSMasters cuatro { get; set; }
        public RESULTSMasters cinco { get; set; }
    }

    public class Puestos
    {
        public int cantidad { get; set; }
        public double porcentaje { get; set; }

    }
}