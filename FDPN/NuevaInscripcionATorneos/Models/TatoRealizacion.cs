using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class TatoRealizacion
    {
        public TatoRealizacion()
        {
            TatoInformeEntrenador = new HashSet<TatoInformeEntrenador>();
        }

        public int RealizacionId { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<TatoInformeEntrenador> TatoInformeEntrenador { get; set; }
    }
}
