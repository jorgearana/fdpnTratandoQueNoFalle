using FDPN.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InscripcionNatacion.ViewModels.Inscrito
{
    public class EventosParaListadoProPruebaViewmodel
    {
        public List<Eventos> eventos { get; set; }
        public int EventoID { get; set; }
    }
}