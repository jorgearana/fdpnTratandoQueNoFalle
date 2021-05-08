using FDPN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FDPN.ViewModels.Documento;
using FDPN.ViewModels.Home;
using FDPN.ViewModels.Noticia;
using MoreLinq;

namespace FDPN.Controllers
{
   
    public class AcademiaController : BASEController
    {
       
      
        public ActionResult academia(int id)
        {
            DetalleNoticiaViewModel VM = new DetalleNoticiaViewModel
            {
                noticia = db.Noticias.Find(id),
                fotos = db.Fotos.Where(x => x.NoticiaId == id).OrderBy(x => x.FotoId).ToList(),
            };
            return View(VM);
        }

        public ActionResult _PreviewAcademia()
        {

            List<Noticias> noticias = db.Noticias.Where(x => x.CategoriaNoticia.TipoNoticia == "Academia").OrderByDescending(x => x.NoticiaId).ToList();
            return PartialView(noticias);
        }



    }
}