using FDPN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FDPN.ViewModels.Resultados
{
    public class DetalleNadadorViewModel
    {


        public Athlete nadador { get; set; }
        public Inscripciones Inscripciones { get; set; }
        public List<RESULTS> UltimasParticipaciones { get; set; }
        public List<RESULTS> MejoresResultados { get; set; }
        public Dictionary<Pruebas, ListaTiempos> Mejorestiempos { get; set; }
        public Dictionary <Pruebas, PorAnnoLarga> MejorPorAnnoLarga { get; set; }
        public Dictionary<Pruebas, PorAnnoCorta> MejorPorAnnoCorta{ get; set; }
        public List<int> Annos { get; set; }
        public Dictionary<int,Puestos> ContadorDePuestos { get; set; }
        public string searchString { get; set; }

    }

    public class ListaTiempos
    {
        public RESULTS Mejortiempolarga { get; set; }
        public RESULTS Mejortiempocorta { get; set; }
        public RESULTS Ultimoannolarga { get; set; }
        public RESULTS Ultimoannocorta { get; set; }
    }

    public class PorAnnoLarga
    {
        public RESULTS uno { get; set; }
        public RESULTS dos { get; set; }
        public RESULTS tres { get; set; }
        public RESULTS cuatro { get; set; }
        public RESULTS cinco { get; set; }
    }
    public class PorAnnoCorta
    {
        public  RESULTS uno { get; set; }
        public RESULTS dos { get; set; }
        public RESULTS tres { get; set; }
        public RESULTS cuatro { get; set; }
        public RESULTS cinco { get; set; }
    }

    public class Puestos
    {
        public int cantidad { get; set; }
        public double porcentaje { get; set; }
         
    }


}