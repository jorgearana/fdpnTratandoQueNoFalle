using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InscripcionNatacion.ViewModels.Masters
{
    public class NadadorMasterViewModel
    {
        public bool TieneResultado { get; set; }
        public bool YaEstaInscrito { get; set; }
        public bool TieneMulta { get; set; }
        public string DNI { get; set; }
        public string Nombre { get; set; }
        public string Apellido_Paterno { get; set; }
        public string Sexo { get; set; }
        public int InscripcionId { get; set; }
        public DateTime Fecha_de_nacimiento { get; set; }
    }
}