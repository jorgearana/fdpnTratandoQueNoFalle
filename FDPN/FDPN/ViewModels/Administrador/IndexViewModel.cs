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
        public List<Noticias> Comunicado { get; set; }
        public List<Noticias> Base { get; set; }
        public List<Noticias> Subvencion { get; set; }
        public List<Noticias> Records { get; set; }
        public List<Noticias> Marcasminimas { get; set; }
        public List<Noticias> Marcasclasificatorias { get; set; }
        public List<Noticias> Ranking { get; set; }
        public List<Noticias> Resultados { get; set; }
        public List<Noticias> Criterios { get; set; }
        public List<Noticias> Convocatorias { get; set; }
        public List<Noticias> Habiles { get; set; }
        public List<Modals> ventanaModal { get; set; }
    }
}