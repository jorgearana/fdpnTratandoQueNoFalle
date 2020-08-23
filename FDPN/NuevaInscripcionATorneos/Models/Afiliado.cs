using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class Afiliado
    {
        public Afiliado()
        {
            Inscripciones = new HashSet<Inscripciones>();
        }

        public int DeportistaId { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Dni { get; set; }
        public string TipoDeDocumento { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
        public string Sexo { get; set; }

        public virtual ICollection<Inscripciones> Inscripciones { get; set; }
    }
}
