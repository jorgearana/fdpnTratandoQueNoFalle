using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class RecordTipo
    {
        public RecordTipo()
        {
            RecordsActuales = new HashSet<RecordsActuales>();
        }

        public int TipoId { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<RecordsActuales> RecordsActuales { get; set; }
    }
}
