using FDPN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FDPN.ViewModels.Administrador
{
    public class IndexViewModel
    {
        public List<Noticias> Noticia { get; set; }
        public List<Noticias> Evento { get; set; }
        public List<Noticias> Curso { get; set; }
        public List<Noticias> Reglamento { get; set; }
        public List<Noticias> Criterio { get; set; }
        public List<Noticias> Comunicado { get; set; }
        public List<Noticias> Base { get; set; }
        public List<Noticias> Subvencion { get; set; }
        public List<Noticias> Records { get; set; }

    }
}