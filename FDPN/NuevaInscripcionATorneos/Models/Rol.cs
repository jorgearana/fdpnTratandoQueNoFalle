using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class Rol
    {
        public Rol()
        {
            Usuario = new HashSet<Usuario>();
        }

        public int RolId { get; set; }
        public string Rol1 { get; set; }
        public string Detalle { get; set; }

        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
