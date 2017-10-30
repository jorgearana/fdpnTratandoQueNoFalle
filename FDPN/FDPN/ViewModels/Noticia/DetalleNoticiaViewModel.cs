using FDPN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FDPN.ViewModels.Noticia
{
    public class DetalleNoticiaViewModel
    {
        public Noticias noticia { get; set; }
        public List<Fotos> fotos { get; set; }
    }
}