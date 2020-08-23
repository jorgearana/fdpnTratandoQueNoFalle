using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class Disciplina
    {
        public Disciplina()
        {
            Calendario = new HashSet<Calendario>();
            Inscripciones = new HashSet<Inscripciones>();
            Noticias = new HashSet<Noticias>();
            OtroCategorias = new HashSet<OtroCategorias>();
            OtroTorneo = new HashSet<OtroTorneo>();
        }

        public int DisciplinaId { get; set; }
        public string TipoDisciplina { get; set; }
        public string Clase { get; set; }

        public virtual ICollection<Calendario> Calendario { get; set; }
        public virtual ICollection<Inscripciones> Inscripciones { get; set; }
        public virtual ICollection<Noticias> Noticias { get; set; }
        public virtual ICollection<OtroCategorias> OtroCategorias { get; set; }
        public virtual ICollection<OtroTorneo> OtroTorneo { get; set; }
    }
}
