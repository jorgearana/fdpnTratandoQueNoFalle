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
   
    public class DocumentosController : BASEController
    {
       
      
        public ActionResult ListadoDocumentos(int categoriaid, string searchString)
        {
            CategoriaNoticia categoria = db.CategoriaNoticia.FirstOrDefault(x => x.CategoriaId == categoriaid);
            var query = db.Fotos.Where(x => x.Noticias.CategoriaId == categoriaid).OrderByDescending(x => x.Noticias.Fecha).Take(100).AsQueryable();
            if (searchString != null)
            {
                query = query.Where(x => x.Noticias.Titulo.Contains(searchString));
            }
            List<Fotos> listado = query.ToList();
            ViewBag.Titulo = categoria.Detalle;
            return View(listado);
        }

        public ActionResult ListadoNoticias(string searchString)
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
            var noticias = query.OrderByDescending(x => x.Fecha).ThenByDescending(x => x.NoticiaId).Take(50).ToList();

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

        public ActionResult FormularioBusqueda(string searchString)
        {

            formularioBusquedaViewModel VM = new formularioBusquedaViewModel();
          
            //try
            //{


                if (searchString != null)
                {
                    List<string> busqueda = searchString.Split(' ').ToList();

                    busqueda.RemoveAll(BuscarPalabrasQueNoSeBuscan);

                

                    VM.Noticias = db.Noticias.Where(r =>
                   ( busqueda.Any(s => r.Titulo.Contains(s)) ||
                    busqueda.Any(s => r.Larga.Contains(s)) ||
                    busqueda.Any(s => r.Corta.Contains(s)) ) &&
                    r.CategoriaId == 1).OrderByDescending(x => x.Fecha).Take(50).ToList();



                    VM.Documentos = db.Fotos.Where(r =>
                   (busqueda.Any(s => r.Noticias.Titulo.Contains(s)) ||
                    busqueda.Any(s => r.Noticias.Larga.Contains(s)) ||
                    busqueda.Any(s => r.Noticias.Corta.Contains(s))) &&
                    r.Noticias.CategoriaId != 1)
                        .DistinctBy(x => x.NoticiaId).OrderByDescending(x => x.Noticias.NoticiaId).Take(50).ToList();


                   
                    VM.Otros = db.Noticias.Where(x=> busqueda.Any(b=>x.CategoriaNoticia.Detalle.Contains(b)))
                        .OrderByDescending(x => x.Fecha).Take(50).ToList();

                }
            //}
            //catch (Exception ex)
            //{
            //    List<string> errores = new List<string> { ex.Message };
            //    if (ex.InnerException != null)
            //    {
            //        errores.Add(ex.InnerException.Message);
            //    }
            //    return RedirectToAction("MostrarError", "Home", new { errores });
            //}
            return View(VM);
        }
        private static bool BuscarPalabrasQueNoSeBuscan(String s)
        {
            List<string> PalabrasQueNoSeBuscan = new List<string> { "de", "el", "la", "los", "las", "tu", "mi", "su", "yo", "del", "y", "que" };
            var resultado = PalabrasQueNoSeBuscan.Contains(s);
            return resultado;
        }

        public ActionResult BusquedaNoticia(string searchString)
        {
            var query = db.Noticias
                .Where(x => x.Titulo.Contains(searchString) || x.Corta.Contains(searchString) || x.Larga.Contains(searchString) && x.CategoriaId == 1)
                .OrderByDescending(x => x.Fecha).Take(50).ToList();
            return View(query);
        }

        public ActionResult Noticia(int id)
        {
            DetalleNoticiaViewModel VM = new DetalleNoticiaViewModel
            {
                noticia = db.Noticias.Find(id),
                fotos = db.Fotos.Where(x => x.NoticiaId == id).OrderBy(x => x.FotoId).ToList(),
            };
            return View(VM);

        }

        public ActionResult DetalleBusqueda(int id)
        {
            Noticias noticia = db.Noticias.Find(id);
            return View(noticia);
        }

      


        public ActionResult Subvenciones(string searchString)
        {
            var query = db.Fotos.Where(x => x.Noticias.CategoriaNoticia.TipoNoticia == "Subvencion").OrderBy(x => x.Noticias.Fecha).AsQueryable();

            if (searchString != null)
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
        public ActionResult ResolucionesIPD(string searchString)
        {
            var query = db.Fotos.Where(x => x.Noticias.CategoriaNoticia.TipoNoticia == "ResolucionesIPD").OrderBy(x => x.Noticias.Fecha).AsQueryable();

            if (searchString != null)
            {
                query = query.Where(x => x.Noticias.Titulo.Contains(searchString));
            }

            List<Fotos> listado = query.ToList();

            return View(listado);
        }

        public ActionResult MarcasMinimas(string searchString)
        {
            var query = db.Fotos.Where(x => x.Noticias.CategoriaNoticia.TipoNoticia == "MarcasMinimas").OrderBy(x => x.Noticias.Fecha).AsQueryable();

            if (searchString != null)
            {
                query = query.Where(x => x.Noticias.Titulo.Contains(searchString));
            }

            List<Fotos> listado = query.ToList();

            return View(listado);
        }
        public ActionResult Marcasclasificatorias(string searchString)
        {
            var query = db.Fotos.Where(x => x.Noticias.CategoriaNoticia.TipoNoticia == "MarcasClasificatorias").OrderBy(x => x.Noticias.Fecha).AsQueryable();

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
        public ActionResult habiles(string searchString)
        {
            var query = db.Fotos.Where(x => x.Noticias.CategoriaNoticia.TipoNoticia == "Hábiles").OrderBy(x => x.Noticias.Fecha).AsQueryable();

            if (searchString != null)
            {
                query = query.Where(x => x.Noticias.Titulo.Contains(searchString));
            }

            List<Fotos> listado = query.ToList();

            return View(listado);
        }
        public ActionResult Convocatorias(string searchString)
        {
            var query = db.Fotos.Where(x => x.Noticias.CategoriaNoticia.TipoNoticia == "Convocatorias").OrderBy(x => x.Noticias.Fecha).AsQueryable();

            if (searchString != null)
            {
                query = query.Where(x => x.Noticias.Titulo.Contains(searchString));
            }

            List<Fotos> listado = query.ToList();

            return View(listado);
        }
        public ActionResult Formatos(string searchString)
        {
            var query = db.Fotos.Where(x => x.Noticias.CategoriaNoticia.TipoNoticia == "Formatos").OrderBy(x => x.Noticias.Fecha).AsQueryable();

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
        public ActionResult Bases(BasesViewModel modelo)
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
        public ActionResult Criterios(string searchString)
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
            query = query.Where(x => x.CategoriaNoticia.TipoNoticia == "Resultado").OrderByDescending(x => x.Fecha).Take(100);

            var VM = query.OrderByDescending(x => x.Fecha).GroupBy(x => x.Fecha.Year).OrderByDescending(x => x.Key).ToList();

            return View(VM);
        }

        public ActionResult RankingPDF(string searchString)
        {
            var query = db.Noticias.AsQueryable();
            if (searchString != null)
            {
                query = query.Where(x => x.Titulo.Contains(searchString) ||
                x.CategoriaNoticia.TipoNoticia.Contains(searchString) ||
                x.Corta.Contains(searchString) ||
                x.Larga.Contains(searchString));
            }
            query = query.Where(x => x.CategoriaNoticia.TipoNoticia == "Ranking").OrderByDescending(x => x.NoticiaId).Take(20);

            var VM = query.ToList();
            return View(VM);
        }

        public ActionResult AfiliarClub()
        {

            return View();
        }
       
    }
}