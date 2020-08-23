using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class Fotos
    {
        public int FotoId { get; set; }
        public string Nombrefoto { get; set; }
        public int? NoticiaId { get; set; }

        public virtual Noticias Noticia { get; set; }
    }
}
