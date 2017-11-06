using FDPN.Models;
using FDPN.ViewModels.Home;
using FDPN.ViewModels.Noticia;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FDPN.Controllers
{
    public class NoticiasController : Controller
    {
        DB_9B1F4C_MVCcompetenciasEntities1 db = new DB_9B1F4C_MVCcompetenciasEntities1();

        // GET: Noticias
        public ActionResult Noticias(string searchString)
        {
            
          
            List<previewNoticiasViewModel> VM = new List<previewNoticiasViewModel>();

            var query = db.Noticias.Where(x => x.CategoriaId == 1).AsQueryable();
            if (!String.IsNullOrEmpty(searchString))
            {
               query = query.Where(s => s.Titulo.Contains(searchString)
                                       || s.Corta.Contains(searchString)
                                       || s.Palabrasclaves.Contains(searchString)
                                        || s.Larga.Contains(searchString));
            }
            var noticias = query.OrderByDescending(x => x.Fecha).ThenByDescending(x=>x.NoticiaId).Take(24).ToList();
          
            foreach (Noticias noticia in noticias)
            {
                previewNoticiasViewModel preview = new previewNoticiasViewModel
                {
                    noticia = noticia,
                    fotos = db.Fotos.Where(x => x.NoticiaId == noticia.NoticiaId).ToList(),
                };
                VM.Add(preview);
            }

            return View(VM);
        }

        public ActionResult Eventos(string searchString)
        {


            List<previewNoticiasViewModel> VM = new List<previewNoticiasViewModel>();

            var query = db.Noticias.Where(x => x.CategoriaNoticia.TipoNoticia == "Eventos" || x.CategoriaNoticia.TipoNoticia =="comunicado").AsQueryable();
            if (!String.IsNullOrEmpty(searchString))
            {
                query = query.Where(s => s.Titulo.Contains(searchString)
                                        || s.Corta.Contains(searchString)
                                        || s.Palabrasclaves.Contains(searchString)
                                         || s.Larga.Contains(searchString));
            }
            var noticias = query.OrderByDescending(x => x.Fecha).ThenByDescending(x => x.NoticiaId).ToList();

            foreach (Noticias noticia in noticias)
            {
                previewNoticiasViewModel preview = new previewNoticiasViewModel
                {
                    noticia = noticia,
                    fotos = db.Fotos.Where(x => x.NoticiaId == noticia.NoticiaId).ToList(),
                };
                VM.Add(preview);
            }

            return View(VM);
        }


        public ActionResult Buscar(string palabrasclaves)
        {
            string[] terms = palabrasclaves.Split();
            List<Noticias> noticias = (from p in db.Noticias
                                       where (terms.Any(r => p.Corta.Contains(r))) ||
                                        (terms.Any(r => p.Titulo.Contains(r))) ||
                                         (terms.Any(r => p.Larga.Contains(r))) &&
                                         p.CategoriaId ==1
                                       select p).ToList();

            return View("Noticias", noticias);
        }

        public ActionResult Noticia(int id)
        {
            DetalleNoticiaViewModel VM = new DetalleNoticiaViewModel
            {
                noticia = db.Noticias.Find(id),
                fotos = db.Fotos.Where(x => x.NoticiaId == id).ToList(),
            };
            return View(VM);

        }


    }
}