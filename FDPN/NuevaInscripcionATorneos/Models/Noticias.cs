using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class Noticias
    {
        public Noticias()
        {
            Alertas = new HashSet<Alertas>();
            Fotos = new HashSet<Fotos>();
        }

        public int NoticiaId { get; set; }
        public string Titulo { get; set; }
        public string Corta { get; set; }
        public string Larga { get; set; }
        public DateTime Fecha { get; set; }
        public int DisciplinaId { get; set; }
        public int UsuarioId { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public int CategoriaId { get; set; }
        public string Palabrasclaves { get; set; }
        public bool? Visible { get; set; }
        public string Youtube { get; set; }

        public virtual CategoriaNoticia Categoria { get; set; }
        public virtual Disciplina Disciplina { get; set; }
        public virtual ICollection<Alertas> Alertas { get; set; }
        public virtual ICollection<Fotos> Fotos { get; set; }
    }
}
