using FDPN.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InscripcionNatacion.ViewModels.Inscrito
{
    public class NadadorPruebaViewModel
    {
        public atletas atleta { get; set; }
        public Entradas entrada { get; set; }
        public Equipos equipo { get; set; }
        public string  tiempo { get; set; }
        public int edad { get; set; }
    }
}