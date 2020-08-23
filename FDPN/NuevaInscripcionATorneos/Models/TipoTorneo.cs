using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class TipoTorneo
    {
        public TipoTorneo()
        {
            SetupTorneo = new HashSet<SetupTorneo>();
        }

        public int TipoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<SetupTorneo> SetupTorneo { get; set; }
    }
}
