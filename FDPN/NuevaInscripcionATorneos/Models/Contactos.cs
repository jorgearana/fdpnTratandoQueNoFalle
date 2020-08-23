using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class Contactos
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Appaterno { get; set; }
        public string Apmaterno { get; set; }
        public string Telefono { get; set; }
        public string Extension { get; set; }
        public int? Planta { get; set; }
        public int? Asiento { get; set; }
        public string Cargo { get; set; }
        public string Ubicacion { get; set; }
        public int? EmpresaId { get; set; }
        public string Celular { get; set; }
        public string Observaciones { get; set; }
        public string Email { get; set; }
    }
}
