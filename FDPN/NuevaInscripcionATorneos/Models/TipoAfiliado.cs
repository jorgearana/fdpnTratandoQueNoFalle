using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class TipoAfiliado
    {
        public TipoAfiliado()
        {
            Inscripciones = new HashSet<Inscripciones>();
        }

        public int AfiliadoId { get; set; }
        public string Detalle { get; set; }

        public virtual ICollection<Inscripciones> Inscripciones { get; set; }
    }
}
