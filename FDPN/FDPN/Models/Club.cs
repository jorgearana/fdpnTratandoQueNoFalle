//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FDPN.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Club
    {
        public Club()
        {
            this.Afiliacion = new HashSet<Afiliacion>();
            this.Directivos = new HashSet<Directivos>();
            this.Entrenadores = new HashSet<Entrenadores>();
            this.HistorialEntrenador = new HashSet<HistorialEntrenador>();
            this.HistorialTraspasos = new HashSet<HistorialTraspasos>();
            this.Inscripciones = new HashSet<Inscripciones>();
            this.Traspasos = new HashSet<Traspasos>();
            this.TraspasosEnEspera = new HashSet<TraspasosEnEspera>();
            this.Usuario = new HashSet<Usuario>();
            this.Vouchers = new HashSet<Vouchers>();
        }
    
        public int ClubID { get; set; }
        public string NombreClub { get; set; }
        public string Iniciales { get; set; }
        public string NombreUsuario { get; set; }
        public int Activo { get; set; }
        public Nullable<int> AsociacionId { get; set; }
        public System.DateTime FechaPagoAfiliacion { get; set; }
        public System.DateTime FinVigenciaPoderes { get; set; }
        public System.DateTime FinVigenciaRenade { get; set; }
        public string Resolucion { get; set; }
        public string VoucherPagoAfiliacionAnual { get; set; }
        public bool Academia { get; set; }
        public string RutaLogo { get; set; }
        public string EMailOficial { get; set; }
        public string Paginaweb { get; set; }
        public bool Renade { get; set; }
    
        public virtual ICollection<Afiliacion> Afiliacion { get; set; }
        public virtual Asociaciones Asociaciones { get; set; }
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
