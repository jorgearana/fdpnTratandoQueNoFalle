using FDPN.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InscripcionNatacion.ViewModels.Inscrito
{
    public class InscritoViewModel
    {
        public Eventos evento { get; set; }
        public bool entradayainscrita { get; set; }
        

        public int sesion { get; set; }
        

        public float segundos { get; set; }
        public float MMLarga { get; set; }
        public float MMCorta { get; set; }

        public string estilo { get; set; }
        public string MMLargaString { get; set; }
        public string MMCortaString { get; set; }
        public string tiempo { get; set; }

        public string torneo { get; set; }
        public string PiscinaDelTiempo { get; set; }

        public Boolean  Cumple { get; set; }

    }
    public class InscritoViewModelDesSerializado
    {
        public string sesion{ get; set; }
        public string Event_ptr { get; set; }


        public string Event_dist { get; set; }


        public string estilo { get; set; }
        public string Edades { get; set; }
        public string tiempo { get; set; }

        public string piscina { get; set; }
        public string MMLargaString { get; set; }
        public string MMCortaString { get; set; }
        public string torneo { get; set; }


    }
}