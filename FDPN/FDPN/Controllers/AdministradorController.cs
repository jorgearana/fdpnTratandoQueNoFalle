using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FDPN.Models;
using FDPN.ViewModels.Administrador;
using System.IO;
using FDPN.Helpers;
using System.Web.Hosting;
using FDPN.Views.Administrador;

namespace FDPN.Controllers
{
    public class AdministradorController : Controller
    {
        DB_9B1F4C_MVCcompetenciasEntities1 db = new DB_9B1F4C_MVCcompetenciasEntities1();
        FilesHelper filesHelper;
        String tempPath = "~/img/Fotos/";
        String serverMapPath = "~/Content/img/Fotos/";

        public ActionResult Index(string searchString)
        {
            var query = db.Noticias.AsQueryable();

            if (searchString != null)
            {
                query = query.Where(x => x.Titulo.Contains(searchString) ||
                x.CategoriaNoticia.TipoNoticia.Contains(searchString) ||
                x.Corta.Contains(searchString) ||
                x.Larga.Contains(searchString));
            }
            query = query.OrderByDescending(x => x.Fecha).ThenByDescending(x => x.NoticiaId);
            IndexViewModel VM = new IndexViewModel
            {
                Base = query.Where(x => x.CategoriaNoticia.TipoNoticia == "Base").Take(12).ToList(),
                Comunicado = query.Where(x => x.CategoriaNoticia.TipoNoticia == "Comunicado").Take(12).ToList(),
                Curso = query.Where(x => x.CategoriaNoticia.TipoNoticia == "Curso").Take(12).ToList(),
                Evento = query.Where(x => x.CategoriaNoticia.TipoNoticia == "Evento").Take(12).ToList(),
                Criterio = query.Where(x => x.CategoriaNoticia.TipoNoticia == "Criterio").Take(12).ToList(),
                Noticia = query.Where(x => x.CategoriaNoticia.TipoNoticia == "Noticia").Take(12).ToList(),
                Reglamento = query.Where(x => x.CategoriaNoticia.TipoNoticia == "Reglamento").Take(12).ToList(),
                Subvencion = query.Where(x => x.CategoriaNoticia.TipoNoticia == "Subvencion").Take(12).ToList(),
                Records = query.Where(x => x.CategoriaNoticia.TipoNoticia == "Records").Take(12).ToList(),

            };
            return View(VM);
        }

        public IngresoDatosViewModel CrearVMIngresoDatos()
        {

            IngresoDatosViewModel VM = new IngresoDatosViewModel
            {
                noticia = CrearNoticiaVacia(),
                categorias = db.CategoriaNoticia.OrderBy(x => x.TipoNoticia).ToList(),
                disciplinas = db.Disciplina.OrderBy(x => x.TipoDisciplina).ToList(),
            };
            return VM;
        }

        [HttpGet]
        public ActionResult IngresoDatos()
        {
            List<string> nombrefotos = new List<string>();
            Session["fotos"] = nombrefotos;

            IngresoDatosViewModel VM = CrearVMIngresoDatos();
            return View(VM);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult IngresoDatos(IngresoDatosViewModel VM, FormCollection coleccion)
        {
            if (!ModelState.IsValid)
            {
                IngresoDatosViewModel VM2 = CrearVMIngresoDatos();
                return View(VM2);
            }

            VM.noticia.Fecha = DateTime.UtcNow;
            VM.noticia.FechaModificacion = DateTime.UtcNow;
           if(VM.noticia.Youtube != null)
            {
                
                string[] cadenaArray = VM.noticia.Youtube.Split('/');
                VM.noticia.Youtube = "https://www.youtube.com/embed/" + cadenaArray[cadenaArray.Length -1].ToString();
            }

            db.Noticias.Add(VM.noticia);
            db.SaveChanges();

            List<string> nombrefotos = Session["Fotos"] as List<string> ?? new List<string>();



            foreach (string nombre in nombrefotos)
            {
                Fotos foto = new Fotos
                {
                    Nombrefoto = nombre,
                    NoticiaId = VM.noticia.NoticiaId,
                };
              
                
                db.Fotos.Add(foto);
            }
            db.SaveChanges();



            return RedirectToAction("index");
        }

        public Noticias CrearNoticiaVacia()
        {
            Noticias noticia = new Noticias
            {
                Corta = "",
                Larga = "",
                DisciplinaId = 0,
                Titulo = "",
                CategoriaId = 0,
                Palabrasclaves = "",
                Visible = true,
            };
            return noticia;
        }

        private string StorageRoot
        {
            get { return Path.Combine(HostingEnvironment.MapPath(serverMapPath)); }
        }
        private string UrlBase = "/img/Fotos/";
        String DeleteURL = "/Administrador/DeleteFile/?file=";
        String DeleteType = "GET";

        public AdministradorController()
        {
            filesHelper = new FilesHelper(DeleteURL, DeleteType, StorageRoot, UrlBase, tempPath, serverMapPath);
        }

        [HttpGet]
        public ActionResult Borrar(int id)
        {
            BorrarViewModel VM = new BorrarViewModel
            {
                noticia = db.Noticias.Find(id),
                fotos = db.Fotos.Where(x => x.NoticiaId == id).ToList(),
                noticiaid = id,
            };
           
            return View(VM);
        }

        [HttpPost]
        public ActionResult Borrar(BorrarViewModel VM)
        {
            Noticias noticia = db.Noticias.Find(VM.noticiaid);
            List<Fotos> fotos = db.Fotos.Where(x => x.NoticiaId == VM.noticiaid).ToList();
            foreach (Fotos foto in fotos)
            {
                db.Fotos.Remove(foto);
            }
            db.SaveChanges();
            db.Noticias.Remove(noticia);
            db.SaveChanges();
            return RedirectToAction("index");
        }


        [HttpGet]
        public ActionResult Editar(int id)
        {
            EditarViewModel VM = new EditarViewModel
            {
                noticia = db.Noticias.Find(id),
                fotos = db.Fotos.Where(x => x.NoticiaId == id).ToList(),
                files = new ViewDataUploadFilesResult[0],
                categorias = db.CategoriaNoticia.OrderBy(x => x.TipoNoticia).ToList(),
                disciplinas = db.Disciplina.OrderBy(x => x.TipoDisciplina).ToList(),
            };

            JsonFiles ListOfFiles = filesHelper.GetFileList();
            VM.files = ListOfFiles.files;
            return View(VM);
        }

        [HttpPost]
        public ActionResult Editar(EditarViewModel VM)
        {
           
            Noticias noticia = db.Noticias.Find(VM.noticia.NoticiaId);
            noticia = VM.noticia;
            db.SaveChanges();

            //Primero hay que borrar las fotos anteriores
            List<Fotos> antiguasfotos = db.Fotos.Where(x => x.NoticiaId == noticia.NoticiaId).ToList();
            foreach (Fotos foto in antiguasfotos)
            {
                db.Fotos.Remove(foto);
            }
            db.SaveChanges();

            //Agregar las nuevas fotos
            foreach (var item in VM.fotos)
            {
                Fotos foto = item;
                foto.NoticiaId = noticia.NoticiaId;
                db.Fotos.Add(foto);
            }
            db.SaveChanges();
            return RedirectToAction("index");
        }

    }
}