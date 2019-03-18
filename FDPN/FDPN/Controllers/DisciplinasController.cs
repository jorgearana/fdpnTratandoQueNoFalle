using FDPN.Models;
using FDPN.ViewModels.Disciplinas;
using FDPN.ViewModels.Home;
using FDPN.ViewModels.Noticia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FDPN.ViewModels.Documento;

namespace FDPN.Controllers
{
    public class DisciplinasController : BASEController
    {
       
        public ActionResult Index(int disciplina)
        {
            Disciplina dis = db.Disciplina.Find(disciplina);
            return View(dis);
        }

        public PartialViewResult _PreviewCalendario(int disciplina)
        {
            ViewBag.disciplina = disciplina;
            DateTime hoy = (DateTime.Now).AddDays(-7); /*Para tomar los eventos que vienen más adelante y una semana atrás*/

            List<Calendario> calendario = db.Calendario.Where(x => x.Inicio > hoy && (x.DisciplinaId == disciplina || x.DisciplinaId == 7)).OrderBy(x => x.Inicio).Take(6).ToList();
            return PartialView("_PreviewCalendario", calendario);

        }

        public ActionResult _PreviewNoticias(int disciplina)
        {
            ViewBag.disciplina = disciplina;
            List<previewNoticiasViewModel> VM = new List<previewNoticiasViewModel>();
            List<Noticias> noticias = db.Noticias.Where(x => x.CategoriaId == 1 && (x.DisciplinaId == disciplina || x.DisciplinaId == 7)).OrderByDescending(x => x.Fecha).ThenByDescending(x => x.NoticiaId).Take(6).ToList();
            foreach (Noticias noticia in noticias)
            {
                previewNoticiasViewModel preview = new previewNoticiasViewModel
                {
                    noticia = noticia,
                    fotos = db.Fotos.Where(x => x.NoticiaId == noticia.NoticiaId).ToList(),
                };
                VM.Add(preview);
            }
            return PartialView("_PreviewNoticias", VM);
        }
        public ActionResult _PreviewComunicados(int disciplina)
        {
            ViewBag.disciplina = disciplina;
            List<previewNoticiasViewModel> VM = new List<previewNoticiasViewModel>();
            List<Noticias> noticias = db.Noticias.Where(x => x.CategoriaNoticia.TipoNoticia == "Comunicado" && (x.DisciplinaId == disciplina || x.DisciplinaId == 7)).OrderByDescending(x => x.NoticiaId).Take(12).ToList();
            foreach (Noticias noticia in noticias)
            {
                previewNoticiasViewModel preview = new previewNoticiasViewModel
                {
                    noticia = noticia,
                    fotos = db.Fotos.Where(x => x.NoticiaId == noticia.NoticiaId).ToList(),
                };
                VM.Add(preview);
            }
            return PartialView("_PreviewComunicados", VM);
        }
        public ActionResult _PreviewEventos(int disciplina)
        {
            ViewBag.disciplina = disciplina;
            List<previewNoticiasViewModel> VM = new List<previewNoticiasViewModel>();
            List<Noticias> noticias = db.Noticias.Where(x => x.CategoriaNoticia.TipoNoticia == "Comunicado" || x.CategoriaNoticia.TipoNoticia == "Evento" && (x.DisciplinaId == disciplina || x.DisciplinaId == 7)).OrderByDescending(x => x.NoticiaId).Take(12).ToList();
            foreach (Noticias noticia in noticias)
            {
                previewNoticiasViewModel preview = new previewNoticiasViewModel
                {
                    noticia = noticia,
                    fotos = db.Fotos.Where(x => x.NoticiaId == noticia.NoticiaId).ToList(),
                };
                VM.Add(preview);
            }
            return PartialView("_PreviewEventos", VM);
        }

        public ActionResult Bases(int disciplina)
        {
            ViewBag.disciplina = disciplina;
            BasesViewModel VM = new BasesViewModel
            {
                fotos = db.Fotos.Where(x => x.Noticias.CategoriaNoticia.TipoNoticia == "Base" && (x.Noticias.DisciplinaId == disciplina || x.Noticias.DisciplinaId == 7)).OrderBy(x => x.Noticias.Fecha).ToList(),
                disciplinas = db.Disciplina.ToList(),
            };

            return PartialView(VM);
        }
        public ActionResult Resultados (int disciplina)
        {
            ViewBag.disciplina = disciplina;
            BasesViewModel VM = new BasesViewModel
            {
                fotos = db.Fotos.Where(x => x.Noticias.CategoriaNoticia.TipoNoticia == "Resultado" && (x.Noticias.DisciplinaId == disciplina || x.Noticias.DisciplinaId == 7)).OrderBy(x => x.Noticias.Fecha).ToList(),
                disciplinas = db.Disciplina.ToList(),
            };

            return PartialView(VM);
        }

        public ActionResult Reglamentos(int disciplina)
        {
            ViewBag.disciplina = disciplina;
            BasesViewModel VM = new BasesViewModel
            {
                fotos = db.Fotos.Where(x => x.Noticias.CategoriaNoticia.TipoNoticia == "Reglamento" && (x.Noticias.DisciplinaId == disciplina || x.Noticias.DisciplinaId == 7)).OrderBy(x => x.Noticias.Fecha).ToList(),
                disciplinas = db.Disciplina.ToList(),
            };
            return PartialView(VM);
        }























































        //public ActionResult Index(int disciplina)
        //{

        //    var query = db.Noticias.Where(x=>x.DisciplinaId ==disciplina || x.DisciplinaId == 7).AsQueryable();


        //    query = query.OrderByDescending(x => x.Fecha).ThenByDescending(x => x.NoticiaId);
        //    DisciplinaViewModel VM = new DisciplinaViewModel
        //    {

        //        Bases = query.Where(x => x.CategoriaNoticia.TipoNoticia == "Base").OrderByDescending(x => x.NoticiaId).Take(20).ToList(),
        //        Comunicados = query.Where(x => x.CategoriaNoticia.TipoNoticia == "Comunicado").OrderByDescending(x => x.NoticiaId).Take(20).ToList(),
        //        Eventos = query.Where(x => x.CategoriaNoticia.TipoNoticia == "Evento").OrderByDescending(x => x.NoticiaId).Take(20).ToList(),
        //        noticias = query.Where(x => x.CategoriaNoticia.TipoNoticia == "Noticia").OrderByDescending(x => x.NoticiaId).Take(20).ToList(),
        //        Reglamentos = query.Where(x => x.CategoriaNoticia.TipoNoticia == "Reglamento").OrderByDescending(x => x.NoticiaId).Take(20).ToList(),
        //        Resultados = query.Where(x => x.CategoriaNoticia.TipoNoticia == "Resultado").OrderByDescending(x => x.NoticiaId).Take(20).ToList(), 
        //        Fotos = new List<previewNoticiasViewModel>(),
        //    };


        //    VM.Nombre = db.Disciplina.Where(x => x.DisciplinaId == disciplina).Select(x => x.TipoDisciplina).FirstOrDefault();
        //    foreach (Noticias noticia in VM.noticias)
        //    {
        //        previewNoticiasViewModel preview = new previewNoticiasViewModel
        //        {
        //            noticia = noticia,
        //            fotos = db.Fotos.Where(x => x.NoticiaId == noticia.NoticiaId).ToList(),
        //        };
        //        VM.Fotos.Add(preview);
        //    }
        //    ViewBag.disciplina = disciplina;
        //    return View(VM);
        //}

        //public ActionResult Noticias(FormCollection collection, string searchString, int disciplina)
        //{
        //    List<previewNoticiasViewModel> VM = new List<previewNoticiasViewModel>();

        //    var query = db.Noticias.Where(x => x.CategoriaId == 1 && x.DisciplinaId == disciplina).AsQueryable();
        //    if (!String.IsNullOrEmpty(searchString))
        //    {
        //        query = query.Where(s => s.Titulo.Contains(searchString)
        //                                || s.Corta.Contains(searchString)
        //                                || s.Palabrasclaves.Contains(searchString)
        //                                 || s.Larga.Contains(searchString));
        //    }
        //    var noticias = query.OrderByDescending(x => x.Fecha).ThenByDescending(x => x.NoticiaId).Take(24).ToList();

        //    foreach (Noticias noticia in noticias)
        //    {
        //        previewNoticiasViewModel preview = new previewNoticiasViewModel
        //        {
        //            noticia = noticia,
        //            fotos = db.Fotos.Where(x => x.NoticiaId == noticia.NoticiaId).ToList(),
        //        };
        //        VM.Add(preview);
        //    }
        //    ViewBag.disciplina = disciplina;
        //    return View(VM);
        //}

        //public ActionResult Noticia(int id, int disciplina)
        //{
        //    DetalleNoticiaViewModel VM = new DetalleNoticiaViewModel
        //    {
        //        noticia = db.Noticias.Find(id),
        //        fotos = db.Fotos.Where(x => x.NoticiaId == id).ToList(),
        //    };
        //    return View(VM);

        //}
    }
}