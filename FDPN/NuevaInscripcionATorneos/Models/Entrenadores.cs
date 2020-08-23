using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class Entrenadores
    {
        public Entrenadores()
        {
            EntrenadorInscrito = new HashSet<EntrenadorInscrito>();
            HistorialEntrenador = new HashSet<HistorialEntrenador>();
            TatoInformeEntrenador = new HashSet<TatoInformeEntrenador>();
        }

        public int EntrenadorId { get; set; }
        public string Nombre { get; set; }
        public string Paterno { get; set; }
        public string Materno { get; set; }
        public string Dni { get; set; }
        public int Clubid { get; set; }
        public int EstadoId { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
        public string Sexo { get; set; }
        public int AntiguoId { get; set; }
        public string RutaFoto { get; set; }
        public string Email1 { get; set; }
        public string Celular1 { get; set; }
        public string Celular2 { get; set; }
        public string Email2 { get; set; }
        public int UsuarioId { get; set; }

        public virtual Antiguo Antiguo { get; set; }
        public virtual Club Club { get; set; }
        public virtual Estado Estado { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<EntrenadorInscrito> EntrenadorInscrito { get; set; }
        public virtual ICollection<HistorialEntrenador> HistorialEntrenador { get; set; }
        public virtual ICollection<TatoInformeEntrenador> TatoInformeEntrenador { get; set; }
    }
}
