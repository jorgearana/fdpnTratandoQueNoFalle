using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class Procesado
    {
        public Procesado()
        {
            Afiliacion = new HashSet<Afiliacion>();
        }

        public int ProcesadoId { get; set; }
        public string Detalle { get; set; }

        public virtual ICollection<Afiliacion> Afiliacion { get; set; }
    }
}
