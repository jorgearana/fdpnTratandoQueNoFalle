using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class Empresa
    {
        public int EmpresaId { get; set; }
        public string Empresa1 { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Telefono2 { get; set; }
        public string Ciudad { get; set; }
        public string Pais { get; set; }
        public string Ubicacion { get; set; }
        public string Web { get; set; }
        public string Notas { get; set; }
    }
}
