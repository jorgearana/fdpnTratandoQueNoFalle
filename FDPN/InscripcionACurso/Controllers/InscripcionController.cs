using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using InscripcionACurso.Helpers;
using InscripcionACurso.Models;
using InscripcionACurso.ViewModels.Inscripcion;

namespace InscripcionACurso.Controllers
{
    public class InscripcionController : Controller
    {
        DB_9B1F4C_MVCcompetenciasEntities db = new DB_9B1F4C_MVCcompetenciasEntities();   
        // GET: Inscripcion
        public ActionResult Gracias()
        {
            return View();
        }

        // GET: Inscripcion/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Inscripcion/Create
        public ActionResult Create(int meetid)
        {
            InscripcionViewModel VM = new InscripcionViewModel
            {

                CursoParticipante = new CursoParticipante(),
                curso = db.Curso.Find(meetid),
                hacetiempo=DateTime.Now.AddYears(-10),
        };
            return View(VM);
        }

        // POST: Inscripcion/Create
        [HttpPost]
        public ActionResult Create(InscripcionViewModel VM)
        {
            try
            {
                if(TryValidateModel(VM.CursoParticipante))
                {
                    if(IsValidEmailAddress(VM.CursoParticipante.Email))
                    {
                        DateTime hacetiempo = DateTime.Now.AddYears(-18);
                        DateTime haceunsiglo = new DateTime(1900, 1, 1);

                        
                        if (VM.CursoParticipante.Nacimiento< hacetiempo && VM.CursoParticipante.Nacimiento> haceunsiglo)
                        {
                            db.CursoParticipante.Add(VM.CursoParticipante);
                            db.SaveChanges();
                            CursoInscripcion inscripcion = new CursoInscripcion
                            {
                                CursoId = VM.curso.CursoId,
                                ParticipanteId = VM.CursoParticipante.ParticipanteId
                            };
                            db.CursoInscripcion.Add(inscripcion);
                            db.SaveChanges();
                            string EnviarEmail = EnviarConfirmacion(inscripcion.InscripcionId);
                            if (EnviarEmail.Length>0)
                            {
                                VM.Mensaje = EnviarEmail;
                            }
                            
                            return RedirectToAction("Gracias");
                        }
                        else
                        {
                            VM.Mensaje = "Tienes que tener al menos 15 años de edad";
                            return View(VM);
                        }
                    }     
                }
            }
            catch
            {
                VM.Mensaje = "Algún dato está mal ingresado";
                return View(VM);
            }
            return View(VM);
        }

        // GET: Inscripcion/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Inscripcion/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Inscripcion/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Inscripcion/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private static bool IsValidEmailAddress(string emailAddress)
        {
            return new System.ComponentModel.DataAnnotations
                                .EmailAddressAttribute()
                                .IsValid(emailAddress);
        }

        public ActionResult Confirmacion(int Id)
        {
            ConfirmacionViewModel VM = new ConfirmacionViewModel
            {
                inscripcion = db.CursoInscripcion.Find(Id),
            };
            VM.participante = db.CursoParticipante.Find(VM.inscripcion.ParticipanteId);
            VM.curso = db.Curso.Find(VM.inscripcion.CursoId);
            return View(VM);
        }
        public string EnviarConfirmacion(int Id)
        {
            //CursoInscripcion inscripcion = db.CursoInscripcion.Find(Id);
            //CursoParticipante participante = db.CursoParticipante.Find(inscripcion.ParticipanteId);
            //Curso curso = db.Curso.Find(inscripcion.CursoId);
            InscripcionACurso.ViewModels.Inscripcion.ConfirmacionViewModel VM = new ConfirmacionViewModel
            {
                inscripcion = db.CursoInscripcion.Find(Id),
            };
            VM.participante = db.CursoParticipante.Find(VM.inscripcion.ParticipanteId);
            VM.curso = db.Curso.Find(VM.inscripcion.CursoId);

            try
            {
                if (ModelState.IsValid)
                {
                    string result = RazorViewToString.RenderRazorViewToString(this, "PrepararConfirmacion", VM);
                    //string mensaje =
                    //    "<div background: #417378;>" +
                    //    "<div id='left-block' class='col-md-6 col-sm-12 left-block' style='height: 662px;'><div class='left-content'>"+
                    //    "img src='http://inscripcionacursos.jorgearananeyra.com/Content/images/Logo_fdpn.png' border='0' class='CToWUd'>" +
                    //"<h1>Federación Deportiva Peruana de Natación</h1>"+

                    //"<p>Hola " + VM.participante.Nombres + " " + VM.participante.Paterno + " " + VM.participante.Materno + " </p>" +
                    //"<p> Te has inscrito en el evento <span style = 'font-size: 14pt;'> " + VM.curso.Nombre + "</span></p>" +
                    //"<p> este evento empezar&aacute; el d&iacute; a <span style = 'font-size: 12pt;' > " + VM.curso.Inicio + "</ span ></p>" +
                    //"<p> la dirección es: " + VM.curso.Direccion + " en la ciudad de " + VM.curso.Ciudad + "</p>" +
                    //"<p> Tus datos grabados son:</p>" +
                    //"<ul> <li> DNI:" + VM.participante.DNI + " </li> " +
                    //"<li> Fecha de Nacimiento: " + VM.participante.Nacimiento.ToString("dd/MMMM/yyyy") + " </li>" +
                    //"<li> Celular :" + VM.participante.Celular + "</li>" +
                    //"<li> Email :" + VM.participante.Email + " </li> </ul> " +
                    //"<p> Gracias por seguir a la FDPN </ p > " +
                    //"<hr><p>En caso sus datos estén errados, envíen un correo a inscripciones@fdpn.org con los datos correctos. </p>"+
                    //"<br><p><strong>Nota.- No responda este correo</strong></p>" +
                    //"</div>";
                    MailAddress from = new MailAddress("postmaster@jorgearananeyra.com");
                    MailAddress to = new MailAddress(VM.participante.Email);

                    bool isGenParam = typeof(List<>).GetGenericArguments()[0].IsGenericParameter; ;

                    var message = new MailMessage(from, to);

                    message.Subject = "Te has inscrito a un evento";

                    message.Body = string.Format(result);
                    message.IsBodyHtml = true;

                    using (var smtp = new SmtpClient())
                    {
                        smtp.Send(message);
                    }
                }
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
                return mensaje + " " + DateTime.Now.ToShortTimeString();
            }
            return "Correo enviado";
        }

        public PartialViewResult PrepararConfirmacion(int Id)
        {
            ConfirmacionViewModel VM = new ConfirmacionViewModel
            {
                inscripcion = db.CursoInscripcion.Find(Id),
            };
            VM.participante = db.CursoParticipante.Find(VM.inscripcion.ParticipanteId);
            VM.curso = db.Curso.Find(VM.inscripcion.CursoId);
            return PartialView(VM);
        }

        

    }
}
