using FDPN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FDPN.ViewModels.Documento;

namespace FDPN.Controllers
{
    public class DocumentosController : Controller
    {
        DB_9B1F4C_MVCcompetenciasEntities1 db = new DB_9B1F4C_MVCcompetenciasEntities1();
        // GET: Documentos
        public ActionResult Subvenciones(string searchString)
        {
            var query = db.Fotos.Where(x => x.Noticias.CategoriaNoticia.TipoNoticia == "Subvencion").OrderBy(x => x.Noticias.Fecha).AsQueryable();

            if(searchString != null)
            {
                query = query.Where(x => x.Noticias.Titulo.Contains(searchString));
            }

            List<Fotos> listado = query.ToList();

            return View(listado);
        }
        public ActionResult Reglamentos(string searchString)
        {
            var query = db.Fotos.Where(x => x.Noticias.CategoriaNoticia.TipoNoticia == "Reglamento").OrderBy(x => x.Noticias.Fecha).AsQueryable();

            if (searchString != null)
            {
                query = query.Where(x => x.Noticias.Titulo.Contains(searchString));
            }

            List<Fotos> listado = query.ToList();

            return View(listado);
        }
        public ActionResult Comunicados(string searchString)
        {
            var query = db.Fotos.Where(x => x.Noticias.CategoriaNoticia.TipoNoticia == "Comunicado").OrderBy(x => x.Noticias.Fecha).AsQueryable();

            if (searchString != null)
            {
                query = query.Where(x => x.Noticias.Titulo.Contains(searchString));
            }

            List<Fotos> listado = query.ToList();

            return View(listado);
        }

        [HttpGet]
        public ActionResult Bases()
        {
            BasesViewModel VM = new BasesViewModel
            {
                fotos = db.Fotos.Where(x => x.Noticias.CategoriaNoticia.TipoNoticia == "Base").OrderBy(x => x.Noticias.Fecha).ToList(),
                disciplinas = db.Disciplina.ToList(),
            };
            
            return View(VM);
        }

        [HttpPost]
        public ActionResult Bases( BasesViewModel modelo)
        {
            var query = db.Fotos.Where(x => x.Noticias.CategoriaNoticia.TipoNoticia == "Base").OrderBy(x => x.Noticias.Fecha).AsQueryable();

            if (modelo.disciplinaid != null)
            {
                query = query.Where(x => x.Noticias.DisciplinaId == modelo.disciplinaid);
            }

            BasesViewModel VM = new BasesViewModel
            {
                fotos = query.ToList(),
                disciplinas = db.Disciplina.ToList(),
            };
           
        

            return View(VM);
        }
        public ActionResult Normas(string searchString)
        {
            var query = db.Fotos.Where(x => x.Noticias.CategoriaNoticia.TipoNoticia == "Criterio").OrderBy(x => x.Noticias.Fecha).AsQueryable();

            if (searchString != null)
            {
                query = query.Where(x => x.Noticias.Titulo.Contains(searchString));
            }

            List<Fotos> listado = query.ToList();

            return View(listado);
        }
        public ActionResult Records(string searchString)
        {
            var query = db.Fotos.Where(x => x.Noticias.CategoriaNoticia.TipoNoticia == "Record").OrderBy(x => x.Noticias.Titulo).AsQueryable();

            if (searchString != null)
            {
                query = query.Where(x => x.Noticias.Titulo.Contains(searchString));
            }

            List<Fotos> listado = query.ToList();

            return View(listado);
        }
        public ActionResult Documentos()
        {
            return View();
        }

        public ActionResult EnVivo(string searchString)
        {
            var query = db.Vivo.OrderByDescending(x => x.Fecha).AsQueryable();

            if (searchString != null)
            {
                query = query.Where(x => x.Nombre.Contains(searchString));
            }

            List<Vivo> listado = query.ToList();

            return View(listado);
        }

        public ActionResult resultadosPDF(string searchString)
        {
            var query = db.Noticias.AsQueryable();
            if (searchString != null)
            {
                query = query.Where(x => x.Titulo.Contains(searchString) ||
                x.CategoriaNoticia.TipoNoticia.Contains(searchString) ||
                x.Corta.Contains(searchString) ||
                x.Larga.Contains(searchString));
            }
            query = query.Where(x => x.CategoriaNoticia.TipoNoticia == "Resultado").OrderByDescending(x => x.NoticiaId).Take(20);

            var VM = query.GroupBy(x => x.Fecha.Year).ToList();
            return View(VM);
        }

        public ActionResult AfiliarClub()
        {
            
            return View();
        }

    }
}