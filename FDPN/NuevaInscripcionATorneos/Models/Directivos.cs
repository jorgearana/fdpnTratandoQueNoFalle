using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class Directivos
    {
        public int DirectivoId { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int ClubId { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public string Cargo { get; set; }
        public DateTime FinVigencia { get; set; }

        public virtual Club Club { get; set; }
    }
}
