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
        DB_9B1F4C_afiliacionesEntities1 af = new DB_9B1F4C_afiliacionesEntities1();

        FilesHelper filesHelper;
        String tempPath = "~/img/Fotos/";
        String serverMapPath = "~/Content/img/Fotos/";

        public ActionResult Index(string searchString)
        {

            if (!ValidarPrensa())
            {
                return View("NoAutorizado");
            }
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
                Base = query.Where(x => x.CategoriaNoticia.TipoNoticia == "Base").OrderByDescending(x => x.NoticiaId).Take(20).ToList(),
                Comunicado = query.Where(x => x.CategoriaNoticia.TipoNoticia == "Comunicado").OrderByDescending(x => x.NoticiaId).Take(20).ToList(),
                Curso = query.Where(x => x.CategoriaNoticia.TipoNoticia == "Curso").OrderByDescending(x => x.NoticiaId).Take(20).ToList(),
                Evento = query.Where(x => x.CategoriaNoticia.TipoNoticia == "Evento").OrderByDescending(x => x.NoticiaId).Take(20).ToList(),
                Criterio = query.Where(x => x.CategoriaNoticia.TipoNoticia == "Criterio").OrderByDescending(x => x.NoticiaId).Take(20).ToList(),
                Noticia = query.Where(x => x.CategoriaNoticia.TipoNoticia == "Noticia").OrderByDescending(x => x.NoticiaId).Take(20).ToList(),
                Reglamento = query.Where(x => x.CategoriaNoticia.TipoNoticia == "Reglamento").OrderByDescending(x => x.NoticiaId).Take(20).ToList(),
                Subvencion = query.Where(x => x.CategoriaNoticia.TipoNoticia == "Subvencion").OrderByDescending(x => x.NoticiaId).Take(20).ToList(),
                Records = query.Where(x => x.CategoriaNoticia.TipoNoticia == "Record").OrderByDescending(x => x.NoticiaId).Take(20).ToList(),
                Resultados = query.Where(x => x.CategoriaNoticia.TipoNoticia == "Resultado").OrderByDescending(x => x.NoticiaId).Take(20).ToList(),
                ventanaModal = db.Modals.OrderBy(x => x.Titulo).ToList(),
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

            if (!ValidarPrensa())
            {
                return View("NoAutorizado");
            }
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
            if (VM.noticia.Youtube != null)
            {

                string[] cadenaArray = VM.noticia.Youtube.Split('/');
                VM.noticia.Youtube = "https://www.youtube.com/embed/" + cadenaArray[cadenaArray.Length - 1].ToString();
            }
            if (VM.noticia.Corta == null)
            {
                VM.noticia.Corta = "";
            }
            if (VM.noticia.Larga == null)
            {
                VM.noticia.Larga = "";
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
            if (!ValidarPrensa())
            {
                return View("NoAutorizado");
            }
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
            if (!ValidarPrensa())
            {
                return View("NoAutorizado");
            }
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
            if (!ValidarPrensa())
            {
                return View("NoAutorizado");
            }
            //EditarViewModel VM = new EditarViewModel
            //{
            //    noticia = db.Noticias.Find(id),
            //    fotos = db.Fotos.Where(x => x.NoticiaId == id).ToList(),
            //    files = new ViewDataUploadFilesResult[0],
            //    categorias = db.CategoriaNoticia.OrderBy(x => x.TipoNoticia).ToList(),
            //    disciplinas = db.Disciplina.OrderBy(x => x.TipoDisciplina).ToList(),
            //};

            IngresoDatosViewModel VM = new IngresoDatosViewModel
            {
                noticia = db.Noticias.Find(id),
                categorias = db.CategoriaNoticia.OrderBy(x => x.TipoNoticia).ToList(),
                disciplinas = db.Disciplina.OrderBy(x => x.TipoDisciplina).ToList(),
                id = id,
            };


            return View(VM);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Editar(IngresoDatosViewModel VM)
        {
            if (!ValidarPrensa())
            {
                return View("NoAutorizado");
            }

            Noticias noticia = db.Noticias.Find(VM.id);


            noticia.Corta = VM.noticia.Corta;
            noticia.Larga = VM.noticia.Larga;
            noticia.Titulo = VM.noticia.Titulo;
            noticia.Palabrasclaves = VM.noticia.Palabrasclaves;
            noticia.DisciplinaId = VM.noticia.DisciplinaId;
            noticia.CategoriaId = VM.noticia.CategoriaId;
            noticia.Youtube = VM.noticia.Youtube;
            if (noticia.Youtube != null)
            {

                string[] cadenaArray = VM.noticia.Youtube.Split('/');
                noticia.Youtube = "https://www.youtube.com/embed/" + cadenaArray[cadenaArray.Length - 1].ToString();
            }
            db.SaveChanges();

            //Primero hay que borrar las fotos anteriores
            //List<Fotos> antiguasfotos = db.Fotos.Where(x => x.NoticiaId == noticia.NoticiaId).ToList();
            //foreach (Fotos foto in antiguasfotos)
            //{
            //    db.Fotos.Remove(foto);
            //}
            //db.SaveChanges();

            //Agregar las nuevas fotos
            //foreach (var item in VM.fotos)
            //{
            //    Fotos foto = item;
            //    foto.NoticiaId = noticia.NoticiaId;
            //    db.Fotos.Add(foto);
            //}
            //db.SaveChanges();
            return RedirectToAction("index");
        }

        [HttpGet]
        public ActionResult Login()
        {
            Usuario usuario = new Usuario();
            return View(usuario);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Usuario usuario, string ReturnUrl)
        {
            Session.Clear();
            if (ModelState.IsValid)
            {

                Usuario logUsuario = af.Usuario.Where(x => x.Usuario1 == usuario.Usuario1 && x.Password == usuario.Password).FirstOrDefault();

                if (logUsuario != null)
                {

                    Rol rol = af.Rol.Where(x => x.RolId == logUsuario.RolId).FirstOrDefault();
                    Club club = af.Club.Where(x => x.ClubID == usuario.ClubId).FirstOrDefault();

                    Session.Add("Usuario", logUsuario);
                    Session.Add("Club", logUsuario.Club);
                    Session.Add("Rol", logUsuario.Rol);

                    if (ReturnUrl != null)
                    {
                        return Redirect(ReturnUrl);
                    }
                    if (rol.RolId == 10)
                    {
                        return RedirectToAction("index", "administrador");
                    }
                }
            }
            ModelState.AddModelError("", "Ooh oh, el nombre de usuario o el password están errados");
            return RedirectToAction("index", "administrador");
        }

        [HttpGet]
        public ActionResult IngresarModal()
        {
            List<string> nombrefotos = new List<string>();
            Session["fotos"] = nombrefotos;

            return View();
        }

        [HttpPost]
        public ActionResult IngresarModal(Modals modal)
        {
            if (ModelState.IsValid)
            {
                List<string> nombrefotos = Session["Fotos"] as List<string> ?? new List<string>();
                if (nombrefotos.Count > 0)
                {
                    List<Modals> modals = db.Modals.ToList();
                    foreach (Modals ventanamodal in modals)
                    {
                        ventanamodal.Activo = false;
                    }

                    modal.Image = nombrefotos[0];
                    db.Modals.Add(modal);

                    db.SaveChanges();
                    return RedirectToAction("index");
                }

            }
            return View(modal);
        }

        public bool ValidarPrensa()
        {
            if (System.Web.HttpContext.Current.Session["Rol"] != null)
            {

                FDPN.Models.Rol rol = (System.Web.HttpContext.Current.Session["Rol"] as FDPN.Models.Rol);

                return (rol.Rol1 == "prensa" || rol.Rol1 == "admin");
            }
            return false;
        }

        public ActionResult ActivarModal(int id)
        {
            List<Modals> modals = db.Modals.ToList();
            foreach (Modals ventanamodal in modals)
            {
                ventanamodal.Activo = false;
            }
            Modals Actualmodal = db.Modals.Find(id);
            Actualmodal.Activo = true;
            db.SaveChanges();
            return RedirectToAction("index");
        }

        public ActionResult Desactivar(int id)
        {
            Modals Actualmodal = db.Modals.Find(id);
            Actualmodal.Activo = false;
            db.SaveChanges();
            return RedirectToAction("index");
        }
        [HttpGet]
        public ActionResult BorrarModal(int id)
        {
            Modals Actualmodal = db.Modals.Find(id);
            return View("confirmaBorrar", Actualmodal);
        }
        [HttpPost]
        public ActionResult BorrarModal(Modals modelo)
        {
            Modals modalaborrar = db.Modals.Find(modelo.Modalid);
            db.Modals.Remove(modalaborrar);
            db.SaveChanges();
            return RedirectToAction("index");

        }

        public ActionResult MostrarCalendario()
        {
            List<Calendario> calendarios = db.Calendario.OrderBy(x => x.Inicio).ToList();
            return View(calendarios);

        }
        [HttpGet]
        public ActionResult editarCalendario(int id)
        {
            EditarCalendarioViewModel VM = new EditarCalendarioViewModel
            {
                calendario = db.Calendario.Find(id),
                disciplinas = db.Disciplina.ToList(),
            };
            return View(VM);
        }

        [HttpPost]
        public ActionResult editarCalendario(EditarCalendarioViewModel VM)
        {
            if (!TryUpdateModel(VM.calendario))
            {
                return View(VM.calendario);
            }
            return RedirectToAction("index");
        }

    }
}