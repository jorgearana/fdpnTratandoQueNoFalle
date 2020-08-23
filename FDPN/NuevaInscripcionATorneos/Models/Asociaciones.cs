using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class Asociaciones
    {
        public Asociaciones()
        {
            Club = new HashSet<Club>();
        }

        public int AsociacionId { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Club> Club { get; set; }
    }
}
