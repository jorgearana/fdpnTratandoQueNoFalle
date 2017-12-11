using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FDPN.ViewModels.Shared;
using FDPN.Models;
using MoreLinq;
using FDPN.ViewModels.Home;

namespace FDPN.Controllers
{
    public class HomeController : Controller
    {
        DB_9B1F4C_MVCcompetenciasEntities1 db = new DB_9B1F4C_MVCcompetenciasEntities1();
        DB_9B1F4C_afiliacionesEntities1 af = new DB_9B1F4C_afiliacionesEntities1(); 

        public ActionResult Index()
        {
            //IndexViewModels VM = new IndexViewModels
            //{
            //    //resultado = new List<Models.RESULTS>(),
            //    //destacados = new List<Models.RESULTS>(),
            //    //calendario= new List<Models.Calendario>(),
            //};
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Construccion()
        {
           
            return View();
        }

        public ActionResult _TopBar()
        {
            Random rnd = new Random();
            int i = rnd.Next(1, 10);
            string banner = "site-header";
            switch(i)
            {
                case 1:
                    banner = "site-header--prensa2";
                    break;
                case 2:
                    banner = "site-header--prensa3";
                    break;
                case 3:
                    banner = "site-header--prensa4";
                    break;
                case 4:
                    banner = "site-header--default";
                    break;
                case 5:
                    banner = "site-header--prensa";
                    break;
                case 6:
                    banner = "site-header--documentos";
                    break;
                case 7:
                    banner = "site-header--resultados";
                    break;
                case 8:
                    banner = "site-header--rankings";
                    break;
                case 9:
                    banner = "site-header--calendar";
                    break;
                case 10:
                    banner = "site-header--news";
                    break;
            }
            ViewBag.clase = banner;
            return PartialView();
        }

        public ActionResult _indexranking()
        {
            string sexo = "F";
            string piscina = "L";
            Random rnd = new Random();
            int prueba = rnd.Next(1, 17);
            int i = rnd.Next(0,2);

            if(i ==1)
            {
                sexo = "M";
            }
            i = rnd.Next(0, 2);
            if(i ==1)
            {
                piscina = "S";
            }
            List<RESULTS> resultado = db.RESULTS
                .Where(x => x.PruebaId == prueba && x.NT ==0  && x.SCORE != "" && x.ATHLETE !=0 && x.Athlete1.Sex== sexo && x.COURSE== piscina && x.PLACE!=0)
                .OrderBy(x => x.SCORE)
                .DistinctBy(x=>x.AthleteId)
                .Take(10).ToList();

            return PartialView("_indexranking", resultado);
        }

        public ActionResult _nadadordestacado()
        {
            DateTime iniciomes = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            Random rnd = new Random();
           //List< TorneoDestacado> torneodestacado = db.TorneoDestacado.OrderByDescending(x => x.DestacadoId).Take(3).ToList();
            int i = rnd.Next(1, 3);
            int categoria = rnd.Next(0, 3);
            int edadminima = 0;
            int edadmaxima = 109;
            switch(categoria)
            {
                case 0:
                    edadminima = 13;
                    edadmaxima = 14;
                    break;
                case 1:
                    edadminima = 15;
                    edadmaxima = 17;
                    break;
              
            }
            //int meet = torneodestacado[i].Meet;
            string sexo = "M";

            List<MEET> torneosDelMes = db.MEET.Where(x => x.Start > iniciomes).ToList();
            if (torneosDelMes.Count()==0)
            {
                iniciomes.AddMonths(-1);
               
            }
            //List<RESULTS> tiempos = db.RESULTS.Where(x => x.MEET == meet )
            //    .Where(x=>x.PLACE != 0)
            //    .OrderByDescending(x => x.PFina)
            //    .ToList();
            if(i == 2)
            {
                sexo = "F";
            }
            RESULTS resultadomejor = db.RESULTS.Where(x=>x.Athlete1.Sex==sexo && x.MEET1.Start>iniciomes && x.COURSE!= "Y" && x.Athlete1.Age >= edadminima && x.Athlete1.Age<=edadmaxima).OrderByDescending(x => x.PFina).FirstOrDefault();
            if (resultadomejor == null || resultadomejor.PFina < 500  )
            {
               iniciomes= iniciomes.AddMonths(-1);
                resultadomejor = db.RESULTS.Where(x => x.Athlete1.Sex == sexo && x.MEET1.Start > iniciomes && x.COURSE != "Y" && x.Athlete1.Age >= edadminima && x.Athlete1.Age <= edadmaxima).OrderByDescending(x => x.PFina).FirstOrDefault();
            }
            //int ponderado = tiempos.Count() / 5;
            //tiempos = tiempos.Take(ponderado).ToList();


            //i = rnd.Next(1, tiempos.Count);
            //int athleteID = tiempos[i].AthleteId ?? 0;

            //string dni = tiempos[i].Athlete1.ID_NO ?? "";





            string dni = resultadomejor.Athlete1.ID_NO ?? "";
            NadadorDestacadoViewModels VM = new NadadorDestacadoViewModels
            {
               // resultados = tiempos.Where(x => x.AthleteId == athleteID).OrderBy(x => x.PLACE).ThenByDescending(x => x.PFina).ToList(),
               //afiliado = af.Afiliado.Where(x => x.DNI == dni).FirstOrDefault(),
               resultados = resultadomejor,
               afiliado = af.Afiliado.Where(x => x.DNI == dni).FirstOrDefault(),
            };

            if (VM.afiliado == null)
            {
                VM.afiliado = new Afiliado
                {
                    RutaFoto = "sinfoto"
                };
            }
            
            return PartialView("_nadadordestacado", VM);
        }

        public PartialViewResult _PreviewCalendario()
        {
            DateTime hoy = (DateTime.Now).AddDays(-7); /*Para tomar los eventos que vienen más adelante y una semana atrás*/

            List<Calendario> calendario = db.Calendario.Where(x => x.Inicio > hoy).OrderBy(x=>x.Inicio).Take(6).ToList();
            return PartialView("_PreviewCalendario", calendario);

        }

        public ActionResult _PreviewNoticias()
        {
            List<previewNoticiasViewModel> VM = new List<previewNoticiasViewModel>();
            List<Noticias> noticias = db.Noticias.Where(x => x.CategoriaId == 1).OrderByDescending(x => x.Fecha).ThenByDescending(x=>x.NoticiaId).Take(9).ToList();
            foreach(Noticias noticia in noticias)
            {
                previewNoticiasViewModel preview = new previewNoticiasViewModel
                {
                    noticia = noticia,
                    fotos = db.Fotos.Where(x=>x.NoticiaId == noticia.NoticiaId).ToList(),
                };
                VM.Add(preview);
            }
            return PartialView("_PreviewNoticias", VM);
        }
        public ActionResult _PreviewComunicados()
        {
            List<previewNoticiasViewModel> VM = new List<previewNoticiasViewModel>();
            List<Noticias> noticias = db.Noticias.Where(x => x.CategoriaNoticia.TipoNoticia  == "Comunicado").OrderByDescending(x => x.NoticiaId).Take(12).ToList();
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
        public ActionResult _PreviewEventos()
        {
            List<previewNoticiasViewModel> VM = new List<previewNoticiasViewModel>();
            List<Noticias> noticias = db.Noticias.Where(x => x.CategoriaNoticia.TipoNoticia == "Comunicado" || x.CategoriaNoticia.TipoNoticia =="Eventos").OrderByDescending(x => x.NoticiaId).Take(12).ToList();
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

        public ActionResult _PreviewEnVivo()
        {
            DateTime haceunasemana = DateTime.Now.AddDays(-57);
            List<Vivo> Envivo = new List<Vivo>();
            Envivo = db.Vivo.Where(x=>x.Fecha> haceunasemana).OrderByDescending(x => x.Fecha).ToList();
            return View(Envivo);
        }

        public ActionResult _Modal()
        {
            Modals modal = db.Modals.Where(x => x.Activo).FirstOrDefault();
            return PartialView("_Modal", modal);
        }
    }
}