using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class Modals
    {
        public int Modalid { get; set; }
        public string Titulo { get; set; }
        public string Cuerpo { get; set; }
        public string Image { get; set; }
        public string Enlace { get; set; }
        public bool Activo { get; set; }
    }
}
