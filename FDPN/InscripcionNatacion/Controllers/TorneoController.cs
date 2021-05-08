using FDPN.Models;
using InscripcionNatacion.Helpers;

using InscripcionNatacion.ViewModels.Torneo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InscripcionNatacion.Controllers
{
    public class TorneoController : BASEController
    {
        
        Repository repository = new Repository();
        // GET: Torneo
        public ActionResult Detalle(int Id=0)
        {
            if (!repository.validarUsuario()) return RedirectToAction("Login", "home");
                ListadoDeTorneosViewModel VM = new ListadoDeTorneosViewModel
            {
                torneo= db.Torneo.Find(Id),
                sesiones= db.Sesion.Where(x => x.MeetId == Id).OrderBy(x=>x.Sess_no).ToList(),
            };
            return View(VM);
        }

        public ActionResult Eventos(int id=0)
        {
            if (!repository.validarUsuario()) return RedirectToAction("Login", "home");
            List<EventosViewModel> VM = new List<ViewModels.Torneo.EventosViewModel>();
           
            List<Eventos> Eventos = db.Eventos.Where(x => x.MeetId == id && x.Ind_rel == "I").OrderBy(x => x.Event_no).ToList();
            List<MarcasMinimas> MMDelTorneo = db.MarcasMinimas.Where(x => x.MeetId == id).ToList();
            List<SessionItem> SesionesDelTorneo = db.SessionItem.Where(x => x.Meetid == id).OrderBy(x=>x.Sess_ptr).ToList();
            foreach (Eventos evento in Eventos)
            {

                EventosViewModel eventoVM = new EventosViewModel
                {
                    Evento = evento,
                    MMCorta = MMDelTorneo
                    .Where(x => x.tag_dist == evento.Event_dist
                    && x.tag_stroke == evento.Event_stroke
                    && x.MeetId == id
                    && x.tag_course == "S"
                    && x.low_age <= evento.Low_age
                    && x.tag_gender == evento.Event_gender)
                     .Select(x => x.tag_time).FirstOrDefault() ?? 0,

                    MMlarga = MMDelTorneo
                    .Where(x => x.tag_dist == evento.Event_dist
                   && x.tag_stroke == evento.Event_stroke
                   && x.MeetId == id
                   && x.tag_course == "L"
                   && x.low_age <= evento.Low_age
                    && x.tag_gender == evento.Event_gender)
                    .Select(x => x.tag_time).FirstOrDefault() ?? 0,

                    Sesion = SesionesDelTorneo.Where(x => x.Event_ptr == evento.Event_ptr).Select(x => x.Sess_ptr).FirstOrDefault() ??1,
                };

                eventoVM.MMlargastring = ConvertirAMinutos(eventoVM.MMlarga);
                eventoVM.MMCortastring = ConvertirAMinutos(eventoVM.MMCorta);
                VM.Add(eventoVM);

            }
            return View(VM);
        }
        public ActionResult ListadoNadadores(int MeetId, int pruebaId)
        {
            int annoActual = DateTime.Now.Year - 1; /*Para calcular la edad al año pasado*/
            DateTime haceunanno = DateTime.Now.AddYears(-1);
            float marcaminima1 = 0;
            float marcaminima2 = 0;

            Eventos evento = db.Eventos.Where(x => x.MeetId == MeetId && x.EventId == pruebaId).FirstOrDefault();
            int annomenor = evento.Low_age ?? 0;
            int annomayor = evento.High_Age ?? 0;

            int annomin = annoActual - annomenor; /*2005*/
            int annomax = annoActual - annomayor; /*2004*/

            List<Athlete> deportistasConTiempo = new List<Athlete>();

            //List<NadadorConTiempoViewModel> listadonadadorescontiempo = new List<NadadorConTiempoViewModel>();

            ListadoNadadoresConTiempoViewModel VM = new ListadoNadadoresConTiempoViewModel
            {
                edadesmaximas = new List<int>(),
                edadesminimas = new List<int>(),

            };

            // para obtener la marca mínima del evento a realizar
            string sexo = evento.Event_gender;
            string stroke = "Free";
            string estilo = "Libre";

            switch (evento.Event_stroke)
            {
                case "A":
                    estilo = "Libre";
                    stroke = "Free";
                    break;
                case "B":
                    estilo = "Espalda";
                    stroke = "Back";
                    break;
                case "C":
                    estilo = "Pecho";
                    stroke = "Breast";
                    break;
                case "D":
                    estilo = "Mariposa";
                    stroke = "Fly";
                    break;
                case "E":
                    estilo = "Combinado";
                    stroke = "IM";
                    break;

            }

            int distancia = (int)evento.Event_dist;

            //Hallo el dato de la BD
            if (!evento.Multi_age)
            {
                MarcasMinimas MarcasMinimas = db.MarcasMinimas
               .Where(x => x.tag_gender == sexo && x.tag_stroke == evento.Event_stroke && x.tag_dist == distancia && x.low_age == evento.Low_age)
               .FirstOrDefault();

                marcaminima1 = MarcasMinimas.tag_time ?? 0;
                VM.edadesminimas.Add(evento.Low_age ?? 0);
                VM.edadesmaximas.Add(evento.High_Age ?? 0);
            }
            else
            {
                //Hallo la marca mínima para el evento con la edad mínima
                MarcasMinimas MarcasMinimas = db.MarcasMinimas
                 .Where(x => x.tag_gender == sexo && x.tag_stroke == evento.Event_stroke && x.tag_dist == distancia && x.low_age == evento.Low_age)
                 .FirstOrDefault();

                marcaminima1 = MarcasMinimas.tag_time ?? 0;
                VM.edadesminimas.Add(MarcasMinimas.low_age ?? 0);
                VM.edadesmaximas.Add(MarcasMinimas.high_Age ?? 0);

                //Ahora hallo la edad mínima de la siguiente timestd 
                int nuevalow_age = MarcasMinimas.high_Age + 1 ?? 0;

                MarcasMinimas = db.MarcasMinimas
                 .Where(x => x.tag_gender == sexo && x.tag_stroke == evento.Event_stroke && x.tag_dist == distancia && x.low_age == nuevalow_age)
                 .FirstOrDefault();

                marcaminima2 = MarcasMinimas.tag_time ?? 0;
                VM.edadesminimas.Add(MarcasMinimas.low_age ?? 0);
                VM.edadesmaximas.Add(MarcasMinimas.high_Age ?? 0);

            }



            VM.Prueba = "Prueba N° " + evento.Event_ptr + " : " + distancia.ToString() + " " + estilo + " " + evento.Low_age + " a " + evento.High_Age + " años";
            VM.Listado = new List<NadadorConTiempoViewModel>();

            if (marcaminima1 != 0)
            {
                VM.Prueba += ", marca mínima " + marcaminima1;
            }

            List<Inscripciones> TodoslosNadadoresDeLaCategoria = db.Inscripciones
                .Where(x => x.ClubID == 40 && x.Afiliado.Fecha_de_nacimiento.Year >= annomax && x.Afiliado.Fecha_de_nacimiento.Year <= annomin && x.Afiliado.Sexo == sexo)
                .ToList();

            foreach (Inscripciones afiliado in TodoslosNadadoresDeLaCategoria)
            {
                NadadorConTiempoViewModel nadadorcontiempo = new NadadorConTiempoViewModel
                {
                    afiliado = afiliado,
                    resultado = db.RESULTS
                    .Where(x => x.Athlete1.ID_NO == afiliado.DNI && x.DISTANCE == distancia.ToString() && x.STROKE == stroke && x.Meet1.Start > haceunanno)
                    .OrderByDescending(x => x.SCORE).FirstOrDefault(),
                };


                if (nadadorcontiempo.resultado != null)
                {
                    VM.Listado.Add(nadadorcontiempo);
                }
            }
            return View(VM);
        }


        public string ConvertirAMinutos(float segundos)
        {
            string tiempo = "";
            int num = (int)segundos;
            int hor = (num / 3600);
            int min = ((num - hor * 3600) / 60);
            int seg = num - (hor * 3600 + min * 60);
            double cent = Math.Round((segundos - num) * 100);

            if (hor > 0)
            {
                tiempo = hor.ToString();
            }
            tiempo += min.ToString("00") + ":" + seg.ToString("00") + "." + ((int)cent).ToString();
            return tiempo;
        }


    }
}