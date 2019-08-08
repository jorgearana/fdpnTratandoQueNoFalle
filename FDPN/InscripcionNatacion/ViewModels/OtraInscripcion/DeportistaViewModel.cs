using FDPN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InscripcionNatacion.ViewModels.OtraInscripcion
{
    public class DeportistaViewModel
    {
        public Inscripciones Deportista{ get; set; }
        public Boolean TieneInscripcio { get; set; }
        public Boolean  TieneFoto { get; set; }
    }
}