using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class Comentarios
    {
        public int ComentarioId { get; set; }
        public string Comentario { get; set; }
        public int UsuarioId { get; set; }
        public int NoticiaId { get; set; }
        public string Estado { get; set; }
        public DateTime Fecha { get; set; }
    }
}
