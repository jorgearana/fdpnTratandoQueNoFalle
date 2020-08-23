using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Afiliacion = new HashSet<Afiliacion>();
            Delegados = new HashSet<Delegados>();
            Entrenadores = new HashSet<Entrenadores>();
            HistorialTraspasos = new HashSet<HistorialTraspasos>();
            Multas = new HashSet<Multas>();
            Traspasos = new HashSet<Traspasos>();
            Vouchers = new HashSet<Vouchers>();
        }

        public int UsuarioId { get; set; }
        public string Usuario1 { get; set; }
        public string Password { get; set; }
        public int RolId { get; set; }
        public int ClubId { get; set; }
        public int RememberMe { get; set; }

        public virtual Club Club { get; set; }
        public virtual Rol Rol { get; set; }
        public virtual ICollection<Afiliacion> Afiliacion { get; set; }
        public virtual ICollection<Delegados> Delegados { get; set; }
        public virtual ICollection<Entrenadores> Entrenadores { get; set; }
        public virtual ICollection<HistorialTraspasos> HistorialTraspasos { get; set; }
        public virtual ICollection<Multas> Multas { get; set; }
        public virtual ICollection<Traspasos> Traspasos { get; set; }
        public virtual ICollection<Vouchers> Vouchers { get; set; }
    }
}
