using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class CursoParticipante
    {
        public CursoParticipante()
        {
            CursoInscripcion = new HashSet<CursoInscripcion>();
        }

        public int ParticipanteId { get; set; }
        public string Nombres { get; set; }
        public string Paterno { get; set; }
        public string Materno { get; set; }
        public DateTime Nacimiento { get; set; }
        public string Dni { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public string Nacionalidad { get; set; }
        public string Actividad { get; set; }

        public virtual ICollection<CursoInscripcion> CursoInscripcion { get; set; }
    }
}
