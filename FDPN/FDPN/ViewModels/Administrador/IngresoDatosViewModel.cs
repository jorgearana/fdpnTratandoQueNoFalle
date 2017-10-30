using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FDPN.Models;

namespace FDPN.ViewModels.Administrador
{
    public class IngresoDatosViewModel
    {
        public Noticias noticia { get; set; }
        public List<Disciplina> disciplinas  { get; set; }
        public List<CategoriaNoticia> categorias { get; set; }
    }
}