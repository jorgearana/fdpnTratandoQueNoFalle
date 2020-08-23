using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class Curso
    {
        public Curso()
        {
            CursoInscripcion = new HashSet<CursoInscripcion>();
        }

        public int CursoId { get; set; }
        public string Nombre { get; set; }
        public string Ciudad { get; set; }
        public string Direccion { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fin { get; set; }
        public int? DisciplinaId { get; set; }
        public TimeSpan? Hora { get; set; }
        public int CantidadMaxima { get; set; }
        public bool ParaAfiliados { get; set; }
        public string Enlace { get; set; }
        public string PassWord { get; set; }

        public virtual ICollection<CursoInscripcion> CursoInscripcion { get; set; }
    }
}
