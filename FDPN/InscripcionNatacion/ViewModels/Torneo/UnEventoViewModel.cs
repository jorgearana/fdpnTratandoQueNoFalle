
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InscripcionNatacion.ViewModels.Torneo
{
    public class UnEventoViewModel
    {
        public int EventoId { get; set; }
        public List<UnEvento> UnosEventos { get; set; }

    }
    public class UnEvento
    {
        public int id { get; set; }
        public string Nombre { get; set; }
    }
}