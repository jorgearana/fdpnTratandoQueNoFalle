using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class Traspasos
    {
        public int TraspasoId { get; set; }
        public int UsuarioId { get; set; }
        public int ClubId { get; set; }
        public string NumeroDeOperacion { get; set; }
        public DateTime FechaDeTraspaso { get; set; }
        public int NumeroDeTraspasos { get; set; }
        public double Monto { get; set; }
        public int TraspasosRestantes { get; set; }
        public int? IsncripcionId { get; set; }

        public virtual Club Club { get; set; }
        public virtual Inscripciones Isncripcion { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
