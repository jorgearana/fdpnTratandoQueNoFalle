using FDPN.Helpers;
using FDPN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FDPN.ViewModels.Administrador
{
    public class EditarViewModel
    {

        public Noticias noticia { get; set; }
        public List<Fotos> fotos { get; set; }
        public ViewDataUploadFilesResult[] files  { get; set; }
        public List<Disciplina> disciplinas { get; set; }
        public List<CategoriaNoticia> categorias { get; set; }
    }
}