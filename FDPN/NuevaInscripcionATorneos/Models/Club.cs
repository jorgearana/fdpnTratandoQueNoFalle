using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class Club
    {
        public Club()
        {
            Afiliacion = new HashSet<Afiliacion>();
            Directivos = new HashSet<Directivos>();
            Entrenadores = new HashSet<Entrenadores>();
            HistorialEntrenador = new HashSet<HistorialEntrenador>();
            HistorialTraspasos = new HashSet<HistorialTraspasos>();
            Inscripciones = new HashSet<Inscripciones>();
            Traspasos = new HashSet<Traspasos>();
            TraspasosEnEspera = new HashSet<TraspasosEnEspera>();
            Usuario = new HashSet<Usuario>();
            Vouchers = new HashSet<Vouchers>();
        }

        public int ClubId { get; set; }
        public string NombreClub { get; set; }
        public string Iniciales { get; set; }
        public string NombreUsuario { get; set; }
        public int Activo { get; set; }
        public int? AsociacionId { get; set; }
        public DateTime FechaPagoAfiliacion { get; set; }
        public DateTime FinVigenciaPoderes { get; set; }
        public DateTime FinVigenciaRenade { get; set; }
        public string Resolucion { get; set; }
        public string VoucherPagoAfiliacionAnual { get; set; }
        public bool Academia { get; set; }

        public virtual Asociaciones Asociacion { get; set; }
        public virtual ICollection<Afiliacion> Afiliacion { get; set; }
        public virtual ICollection<Directivos> Directivos { get; set; }
        public virtual ICollection<Entrenadores> Entrenadores { get; set; }
        public virtual ICollection<HistorialEntrenador> HistorialEntrenador { get; set; }
        public virtual ICollection<HistorialTraspasos> HistorialTraspasos { get; set; }
        public virtual ICollection<Inscripciones> Inscripciones { get; set; }
        public virtual ICollection<Traspasos> Traspasos { get; set; }
        public virtual ICollection<TraspasosEnEspera> TraspasosEnEspera { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }
        public virtual ICollection<Vouchers> Vouchers { get; set; }
    }
}
