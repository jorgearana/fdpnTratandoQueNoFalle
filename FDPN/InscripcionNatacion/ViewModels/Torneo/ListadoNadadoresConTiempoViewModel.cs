using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InscripcionNatacion.ViewModels.Torneo
{
    public class ListadoNadadoresConTiempoViewModel
    {
        public string Prueba { get; set; }
        public List<NadadorConTiempoViewModel> Listado { get; set; }
        public List<int> edadesminimas { get; set; }
        public List<int> edadesmaximas { get; set; }
    }
}