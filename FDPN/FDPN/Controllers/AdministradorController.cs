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
    public class AdministradorController : BASEController
    {

        FilesHelper filesHelper;
        readonly String tempPath = "~/img/Fotos/";
        readonly String serverMapPath = "~/Content/img/Fotos/";

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
            IndexViewModel VM = new IndexViewModel()
            {
                Base = query.Where(x => x.CategoriaNoticia.TipoNoticia == "Base").OrderByDescending(x => x.NoticiaId).ToList(),
                Comunicado = query.Where(x => x.CategoriaNoticia.TipoNoticia == "Comunicado").OrderByDescending(x => x.NoticiaId).ToList(),
                Curso = query.Where(x => x.CategoriaNoticia.TipoNoticia == "Curso").OrderByDescending(x => x.NoticiaId).ToList(),
                Evento = query.Where(x => x.CategoriaNoticia.TipoNoticia == "Evento").OrderByDescending(x => x.NoticiaId).ToList(),
                Noticia = query.Where(x => x.CategoriaNoticia.TipoNoticia == "Noticia").OrderByDescending(x => x.NoticiaId).ToList(),
                Reglamento = query.Where(x => x.CategoriaNoticia.TipoNoticia == "Reglamento").OrderByDescending(x => x.NoticiaId).ToList(),
                Subvencion = query.Where(x => x.CategoriaNoticia.TipoNoticia == "Subvencion").OrderByDescending(x => x.NoticiaId).ToList(),
                Records = query.Where(x => x.CategoriaNoticia.TipoNoticia == "Record").OrderByDescending(x => x.NoticiaId).ToList(),
                Resultados = query.Where(x => x.CategoriaNoticia.TipoNoticia == "Resultado").OrderByDescending(x => x.NoticiaId).ToList(),
                Criterios = query.Where(x => x.CategoriaNoticia.TipoNoticia == "Criterio").OrderByDescending(x => x.NoticiaId).ToList(),
                Ranking = query.Where(x => x.CategoriaNoticia.TipoNoticia == "Ranking").OrderByDescending(x => x.NoticiaId).ToList(),
                Marcasminimas = query.Where(x => x.CategoriaNoticia.TipoNoticia == "Marcasminimas").OrderByDescending(x => x.NoticiaId).ToList(),
                Marcasclasificatorias = query.Where(x => x.CategoriaNoticia.TipoNoticia == "MarcasClasificatorias").OrderByDescending(x => x.NoticiaId).ToList(),
                Convocatorias = query.Where(x => x.CategoriaNoticia.TipoNoticia == "Convocatorias").OrderByDescending(x => x.NoticiaId).ToList(),
                Habiles = query.Where(x => x.CategoriaNoticia.TipoNoticia == "Hábiles").OrderByDescending(x => x.NoticiaId).ToList(),
                ResolucionesIPD = query.Where(x => x.CategoriaNoticia.TipoNoticia == "ResolucionesIPD").OrderByDescending(x => x.NoticiaId).ToList(),
                Academia = query.Where(x => x.CategoriaNoticia.TipoNoticia == "Academia").OrderByDescending(x => x.NoticiaId).ToList(),
                Afiliaciones = query.Where(x => x.CategoriaNoticia.TipoNoticia == "Afiliaciones").OrderByDescending(x => x.NoticiaId).ToList(),

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
            InsertarAlertaNoticia(VM.noticia);


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
            if (VM.noticia.Larga == null) VM.noticia.Larga = "";
            if (VM.noticia.Corta == null) VM.noticia.Corta = "";
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
            Alertas alerta = db.Alertas.Where(x => x.NoticiaId == VM.noticiaid).FirstOrDefault();
            if (alerta != null)
            {
                db.Alertas.Remove(alerta);
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

                Usuario logUsuario = db.Usuario.Where(x => x.Usuario1 == usuario.Usuario1 && x.Password == usuario.Password).FirstOrDefault();

                if (logUsuario != null)
                {

                    Rol rol = db.Rol.Where(x => x.RolId == logUsuario.RolId).FirstOrDefault();
                    Club club = db.Club.Where(x => x.ClubID == usuario.ClubId).FirstOrDefault();

                    Session.Add("Usuario", logUsuario);
                    Session.Add("Club", logUsuario.Club);
                    Session.Add("Rol", logUsuario.Rol);

                    if (ReturnUrl != null)
                    {
                        return Redirect(ReturnUrl);
                    }
                    if (rol.RolId == 4)
                    {
                        return RedirectToAction("index", "administrador");
                    }
                    if (rol.RolId == 5)
                    {
                        return RedirectToAction("index", "calendarios");
                    }
                }
            }
            ModelState.AddModelError("", "Ooh oh, el nombre de usuario o el password están errados");
            return RedirectToAction("index", "administrador");
        }


        public bool ValidarPrensa()
        {
            if (System.Web.HttpContext.Current.Session["Rol"] != null)
            {

                FDPN.Models.Rol rol = (System.Web.HttpContext.Current.Session["Rol"] as FDPN.Models.Rol);

                return (rol.Rol1 == "prensa" || rol.RolId == 1 || rol.RolId == 4);
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
            return View(Actualmodal);
        }
        [HttpPost]
        public ActionResult BorrarModal(Modals modelo)
        {
            Modals modalaborrar = db.Modals.Find(modelo.Modalid);
            db.Modals.Remove(modalaborrar);
            db.SaveChanges();
            return RedirectToAction("index");

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


        [HttpGet]
        public ActionResult Calendario()
        {
            List<Calendario> calendarios = db.Calendario.OrderBy(x => x.Inicio).ToList();
            return View(calendarios);
        }

        public void InsertarAlertaNoticia(Noticias noticia)
        {
            ConvertirAPeru convertidor = new Helpers.ConvertirAPeru();
            DateTime today = convertidor.ToPeru(DateTime.UtcNow);
            Alertas alerta = new Alertas
            {
                Alerta = noticia.CategoriaNoticia + ": " + noticia.Titulo,
                Fecha = today,
            };
            alerta.NoticiaId = noticia.NoticiaId;
            db.Alertas.Add(alerta);
            db.SaveChanges();
        }


        public void ResumenAnnoViewModel(int anno)
        {
            DateTime primeroEnero = new DateTime(anno, 01, 01);
            List<ResumenAnnoViewModel> VM = new List<ViewModels.Administrador.ResumenAnnoViewModel>();

            List<RESULTS> resultadosDelAnno = db.RESULTS.Where(x => x.Meet1.Start > primeroEnero && x.PLACE != 0).ToList();

            var resultadoporClub = resultadosDelAnno.GroupBy(x => x.TEAM).ToList();

            foreach (var resultado in resultadoporClub)
            {

                var club = db.Team.Where(x => x.Team1 == resultado.Key).FirstOrDefault();
                var Nadadores = resultadosDelAnno.Where(x => x.TEAM == resultado.Key).GroupBy(x => x.ATHLETE);
                var cuenta = Nadadores.Count();
                ResumenAnnoViewModel resumen = new ViewModels.Administrador.ResumenAnnoViewModel
                {
                    club = db.Team.Where(x => x.Team1 == resultado.Key).FirstOrDefault(),
                    Nadadores = resultadosDelAnno.Where(x => x.TEAM == resultado.Key).GroupBy(x => x.ATHLETE).Count(),
                    Participaciones = resultadosDelAnno.Where(x => x.TEAM == resultado.Key).GroupBy(x => x.MEET).Count(),

                };
            }




        }


        public ActionResult ResultadosEnVivo(string searchString)
        {
            var query = db.Vivo.AsQueryable();
            if (searchString != null)
            {
                query = query.Where(x => x.Nombre.Contains(searchString) ||
                x.Directorio.Contains(searchString));
            }
            query = query.OrderByDescending(x => x.Fecha);
            List<Vivo> ListadoEnvivo = query.ToList();
            return View(ListadoEnvivo);
        }

        [HttpGet]
        public ActionResult IngresoEnVivo()
        {
            Vivo vivo = new Vivo();
            return View(vivo);
        }

        [HttpPost]
        public ActionResult IngresoEnVivo(Vivo vivo)
        {
            if (ModelState.IsValid)
            { string path = Server.MapPath("~/Resultados/");
                Directory.CreateDirectory(path + vivo.Directorio);
                db.Vivo.Add(vivo);
                db.SaveChanges();
            }
            return RedirectToAction("ResultadosEnVivo");
        }

        public ActionResult BorrarVivo(int id)
        {
            Vivo vivo = db.Vivo.Find(id);
            return View(vivo);
        }

        [HttpPost]
        public ActionResult BorrarVivo(Vivo vivo)
        {
            Vivo borrar = db.Vivo.Find(vivo.VivoId);
            db.Vivo.Remove(borrar);
            db.SaveChanges();
            return RedirectToAction("ResultadosEnVivo");
        }
    }
}