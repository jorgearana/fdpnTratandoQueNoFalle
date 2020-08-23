using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class CategoriasMasters
    {
        public int CategoriaId { get; set; }
        public int EdadMinima { get; set; }
        public int EdadMaxima { get; set; }
        public string Nombre { get; set; }
    }
}
