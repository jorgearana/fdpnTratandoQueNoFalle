using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class Piscinas
    {
        public Piscinas()
        {
            RecordsActuales = new HashSet<RecordsActuales>();
        }

        public string Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<RecordsActuales> RecordsActuales { get; set; }
    }
}
