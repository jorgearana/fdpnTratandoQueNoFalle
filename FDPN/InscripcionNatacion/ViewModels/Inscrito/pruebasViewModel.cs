using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InscripcionNatacion.ViewModels.Inscrito
{
    public class pruebasViewModel
    {
        public int sesion { get; set; }
        public int evento { get; set; }
        public int distancia { get; set; }
        public string estilo { get; set; }
        public string  tiempo { get; set; }
        public float tiempoensegundos { get; set; }

        public string  MMCorta { get; set; }
        public string MMLarga { get; set; }
        public float MMCortaensegundos { get; set; }
        public float MMLargaensegundos { get; set; }

        public bool YaSeleccionada { get; set; }
    }
}