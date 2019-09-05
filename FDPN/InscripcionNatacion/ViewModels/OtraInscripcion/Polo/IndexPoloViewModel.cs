using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FDPN.Models;

namespace InscripcionNatacion.ViewModels.OtraInscripcion.Polo
{
    public class IndexPoloViewModel
    {
        
        public List<Inscripciones> deportistas { get; set; }

        public List<EventoPolo> Eventopolo { get; set; }

        public int PoloEventoId { get; set; }
    }

    public class EventoPolo
    {
        public int EventoId { get; set; }
        public string EventNombre { get; set; }

    }
}