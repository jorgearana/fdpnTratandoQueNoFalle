using FDPN.Models;
using FDPN.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FDPN.ViewModels.Disciplinas
{
    public class DisciplinaViewModel
    {
        public string Nombre { get; set; }
        public List<Noticias> noticias { get; set; }
        public List<Noticias> Eventos { get; set; }
        public List<Noticias> Reglamentos { get; set; }
        public List<Noticias> Comunicados { get; set; }
        public List<Noticias> Bases { get; set; }
      
        public List<Noticias> Resultados { get; set; }
        public List<previewNoticiasViewModel> Fotos { get; set; }
    }
}