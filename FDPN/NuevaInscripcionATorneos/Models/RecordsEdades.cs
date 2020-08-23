using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class RecordsEdades
    {
        public RecordsEdades()
        {
            RecordsActuales = new HashSet<RecordsActuales>();
        }

        public int EdadId { get; set; }
        public int EdadMinima { get; set; }
        public int EdadMaxima { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<RecordsActuales> RecordsActuales { get; set; }
    }
}
