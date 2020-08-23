using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class Vouchers
    {
        public Vouchers()
        {
            Afiliacion = new HashSet<Afiliacion>();
        }

        public int VoucherId { get; set; }
        public double Monto { get; set; }
        public int NumeroDeAfiliados { get; set; }
        public int NumeroDeReafiliados { get; set; }
        public int UsuarioId { get; set; }
        public int AfiliadosRestantes { get; set; }
        public int ReafiliadosRestantes { get; set; }
        public int ClubId { get; set; }
        public DateTime FechaDeCreacion { get; set; }
        public DateTime FechaDeModificacion { get; set; }
        public string NroOperacion { get; set; }
        public int? NumeroDeVinculados { get; set; }
        public int? VinculadosRestantes { get; set; }

        public virtual Club Club { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<Afiliacion> Afiliacion { get; set; }
    }
}
