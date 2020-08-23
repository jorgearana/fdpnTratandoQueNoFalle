using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class OtroResponsable
    {
        public int ResponsableId { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public int TeamId { get; set; }
        public string Celular { get; set; }

        public virtual OtroEquipo Team { get; set; }
    }
}
