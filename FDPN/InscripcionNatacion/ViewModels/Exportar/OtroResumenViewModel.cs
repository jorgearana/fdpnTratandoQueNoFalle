using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FDPN.Models;

namespace InscripcionNatacion.ViewModels.Exportar
{
    public class OtroResumenViewModel
    {
        public List<OtroEventos> eventos { get; set; }
        public List<OtroEntradas> entradas { get; set; }
    }
}