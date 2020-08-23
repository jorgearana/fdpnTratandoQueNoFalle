using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class Inscripciones
    {
        public Inscripciones()
        {
            Afiliacion = new HashSet<Afiliacion>();
            HistorialTraspasos = new HashSet<HistorialTraspasos>();
            HistorialdeAfiliaciones = new HashSet<HistorialdeAfiliaciones>();
            Multas = new HashSet<Multas>();
            OtroAtleta = new HashSet<OtroAtleta>();
            TatoInformeAsistencias = new HashSet<TatoInformeAsistencias>();
            TatoInformeEntrenador = new HashSet<TatoInformeEntrenador>();
            TatoSeleccionado = new HashSet<TatoSeleccionado>();
            Traspasos = new HashSet<Traspasos>();
            TraspasosEnEspera = new HashSet<TraspasosEnEspera>();
        }

        public int InscripcionId { get; set; }
        public string Dni { get; set; }
        public int ClubId { get; set; }
        public int TipoAfiliadoId { get; set; }
        public int EstadoId { get; set; }
        public int AntiguoId { get; set; }
        public string RutaFotoAntigua { get; set; }
        public int? Borrado { get; set; }
        public string FotoDni { get; set; }
        public int DisciplinaId { get; set; }
        public string RutaFoto { get; set; }

        public virtual Antiguo Antiguo { get; set; }
        public virtual Club Club { get; set; }
        public virtual Disciplina Disciplina { get; set; }
        public virtual Afiliado DniNavigation { get; set; }
        public virtual Estado Estado { get; set; }
        public virtual TipoAfiliado TipoAfiliado { get; set; }
        public virtual ICollection<Afiliacion> Afiliacion { get; set; }
        public virtual ICollection<HistorialTraspasos> HistorialTraspasos { get; set; }
        public virtual ICollection<HistorialdeAfiliaciones> HistorialdeAfiliaciones { get; set; }
        public virtual ICollection<Multas> Multas { get; set; }
        public virtual ICollection<OtroAtleta> OtroAtleta { get; set; }
        public virtual ICollection<TatoInformeAsistencias> TatoInformeAsistencias { get; set; }
        public virtual ICollection<TatoInformeEntrenador> TatoInformeEntrenador { get; set; }
        public virtual ICollection<TatoSeleccionado> TatoSeleccionado { get; set; }
        public virtual ICollection<Traspasos> Traspasos { get; set; }
        public virtual ICollection<TraspasosEnEspera> TraspasosEnEspera { get; set; }
    }
}
