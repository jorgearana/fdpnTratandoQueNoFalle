using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class Alertas
    {
        public int AlertaId { get; set; }
        public DateTime Fecha { get; set; }
        public string Alerta { get; set; }
        public int? NoticiaId { get; set; }

        public virtual Noticias Noticia { get; set; }
    }
}
