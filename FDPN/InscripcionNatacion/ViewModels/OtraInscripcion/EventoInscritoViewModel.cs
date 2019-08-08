using FDPN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InscripcionNatacion.ViewModels.OtraInscripcion
{
    public class EventoInscritoViewModel
    {
        public OtroEventos evento { get; set; }
        public Boolean Yainscrito { get; set; }
        public string marca { get; set; }
        public string clase { get; set; }
    }
}