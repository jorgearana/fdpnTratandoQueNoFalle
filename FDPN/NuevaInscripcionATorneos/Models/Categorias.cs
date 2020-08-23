using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class Categorias
    {
        public int CategoriaId { get; set; }
        public string NombreCategoria { get; set; }
        public int EdadMaxima { get; set; }
        public int EdadMinima { get; set; }
    }
}
