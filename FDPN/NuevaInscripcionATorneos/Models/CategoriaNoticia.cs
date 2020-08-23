using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class CategoriaNoticia
    {
        public CategoriaNoticia()
        {
            Noticias = new HashSet<Noticias>();
        }

        public int CategoriaId { get; set; }
        public string TipoNoticia { get; set; }

        public virtual ICollection<Noticias> Noticias { get; set; }
    }
}
