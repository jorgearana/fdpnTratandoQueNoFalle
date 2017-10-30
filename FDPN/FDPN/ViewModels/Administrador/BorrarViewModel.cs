using FDPN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FDPN.ViewModels.Administrador
{
    public class BorrarViewModel
    {
        public Noticias noticia{ get; set; }
        public  List<Fotos> fotos { get; set; }
        public int noticiaid { get; set; }
    }
}