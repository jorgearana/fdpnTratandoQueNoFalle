using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class CursoInscripcion
    {
        public int InscripcionId { get; set; }
        public int ParticipanteId { get; set; }
        public int CursoId { get; set; }

        public virtual Curso Curso { get; set; }
        public virtual CursoParticipante Participante { get; set; }
    }
}
