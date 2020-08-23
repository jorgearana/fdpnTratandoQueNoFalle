using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class OtroCategorias
    {
        public int CategoriaId { get; set; }
        public int DisciplinaId { get; set; }
        public string Nombre { get; set; }
        public int EdadMaxima { get; set; }
        public int EdadMinima { get; set; }

        public virtual Disciplina Disciplina { get; set; }
    }
}
