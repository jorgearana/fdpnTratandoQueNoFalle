using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class Pruebas
    {
        public Pruebas()
        {
            Results = new HashSet<Results>();
            Resultsmasters = new HashSet<Resultsmasters>();
        }

        public int PruebaId { get; set; }
        public int Distancia { get; set; }
        public string Estilo { get; set; }
        public double? FactorF { get; set; }
        public double? FactorM { get; set; }
        public string EstiloMeet { get; set; }

        public virtual ICollection<Results> Results { get; set; }
        public virtual ICollection<Resultsmasters> Resultsmasters { get; set; }
    }
}
