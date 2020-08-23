using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class Delegados
    {
        public int DelegadoId { get; set; }
        public int UsuarioId { get; set; }
        public int MeetId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public virtual Torneo Meet { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
