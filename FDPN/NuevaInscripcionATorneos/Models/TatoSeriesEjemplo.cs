using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class TatoSeriesEjemplo
    {
        public TatoSeriesEjemplo()
        {
            TatoInformeEntrenador = new HashSet<TatoInformeEntrenador>();
        }

        public int SerieId { get; set; }
        public int Zona { get; set; }
        public int Series { get; set; }
        public int Repeticiones { get; set; }
        public int Parcial { get; set; }
        public double Tolerancia { get; set; }
        public double Micropausa { get; set; }
        public int Piscina { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<TatoInformeEntrenador> TatoInformeEntrenador { get; set; }
    }
}
