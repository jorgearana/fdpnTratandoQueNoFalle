using FDPN.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InscripcionNatacion.ViewModels.Torneo
{
    public class EventosViewModel
    {
        public Eventos Evento { get; set; }
        public string Nombre { get; set; }
        public FDPN.Models.Torneo torneo { get; set; }
        public string MMlargastring { get; set; }
        public string MMCortastring { get; set; }
        public float MMCorta { get; set; }
        public float MMlarga { get; set; }
        public int Sesion { get; set; }
    }

    public class DatosEventoViewModel
    {
        public Eventos Evento { get; set; }
        public List<ListadoDeMarcasMinimasViewModel> Marcas { get; set; }
    }

    public class ListadoDeMarcasMinimasViewModel
    {
      
        public int EdadMinima { get; set; }
        public int EdadMaxima { get; set; }
        public string MM { get; set; }
        public string Curso { get; set; }

    }
}