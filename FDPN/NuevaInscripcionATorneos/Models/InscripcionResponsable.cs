using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class InscripcionResponsable
    {
        public int ResponsableId { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public int TeamId { get; set; }
        public string Celular { get; set; }

        public virtual Equipos Team { get; set; }
    }
}
