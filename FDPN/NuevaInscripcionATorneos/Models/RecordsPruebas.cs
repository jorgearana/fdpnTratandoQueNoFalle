using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class RecordsPruebas
    {
        public RecordsPruebas()
        {
            RecordsActuales = new HashSet<RecordsActuales>();
        }

        public int PruebaId { get; set; }
        public string Nombre { get; set; }
        public string Sexo { get; set; }
        public int Distancia { get; set; }
        public string Estilo { get; set; }

        public virtual ICollection<RecordsActuales> RecordsActuales { get; set; }
    }
}
