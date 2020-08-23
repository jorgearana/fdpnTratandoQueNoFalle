﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using InscripcionACurso.Helpers;
using InscripcionACurso.Models;
using InscripcionACurso.ViewModels.Inscripcion;
using Microsoft.Ajax.Utilities;

namespace InscripcionACurso.Controllers
{
    public class InscripcionController : Controller
    {
        DB_9B1F4C_comentariosEntities db = new DB_9B1F4C_comentariosEntities();   
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
            Curso curso = db.Curso.Find(meetid);
            if (curso.ParaAfiliados)
            {
                return RedirectToAction("CreateParaAfiliados", new { meetid });
            }
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
                        DateTime hacetiempo = DateTime.Now.AddYears(-5);
                        DateTime haceunsiglo = new DateTime(1900, 1, 1);

                        
                        
                        if (VM.CursoParticipante.Nacimiento< hacetiempo && VM.CursoParticipante.Nacimiento> haceunsiglo)
                        {
                            CursoParticipante participante;
                            CursoInscripcion inscripcion;
                            if (db.CursoParticipante.Any(x=>x.DNI == VM.CursoParticipante.DNI))
                            {
                                 participante = db.CursoParticipante.Where(x => x.DNI == VM.CursoParticipante.DNI).FirstOrDefault();
                                participante.Nombres = VM.CursoParticipante.Nombres;
                                participante.Paterno = VM.CursoParticipante.Paterno;
                                participante.Materno = VM.CursoParticipante.Materno;
                                participante.Nacimiento = VM.CursoParticipante.Nacimiento;
                                participante.DNI = VM.CursoParticipante.DNI;
                                participante.Email = VM.CursoParticipante.Email;
                                participante.Celular = VM.CursoParticipante.Celular;
                                participante.Nacionalidad = VM.CursoParticipante.Nacionalidad;
                                participante.Actividad = VM.CursoParticipante.Actividad;
                             }
                            else
                            {                               
                                participante = VM.CursoParticipante;
                                db.CursoParticipante.Add(participante);
                            }
                            db.SaveChanges();
                            if ( !(db.CursoInscripcion.Any(x => x.CursoId == VM.curso.CursoId && x.CursoParticipante.DNI == VM.CursoParticipante.DNI)))
                            {
                                 inscripcion = new CursoInscripcion
                                {
                                    CursoId = VM.curso.CursoId,
                                    ParticipanteId = participante.ParticipanteId
                                };
                                db.CursoInscripcion.Add(inscripcion);
                                db.SaveChanges();
                            }
                            else
                            {
                                inscripcion = db.CursoInscripcion.Where(x => x.ParticipanteId == participante.ParticipanteId && x.CursoId == VM.curso.CursoId).FirstOrDefault();
                            }
                           
                           
                            string EnviarEmail = EnviarConfirmacion(inscripcion.InscripcionId);
                            if (EnviarEmail.Length>0)
                            {
                                VM.Mensaje = EnviarEmail;
                            }
                            
                            return RedirectToAction("Gracias");
                        }
                        else
                        {
                            VM.Mensaje = "Verifica tu fecha de nacimiento por favor";
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

        public ActionResult CreateParaAfiliados(int meetid)
        {
            ViewModelBuscarDNI VM = new ViewModelBuscarDNI
            {
                curso = db.Curso.Find(meetid),
                DNI = "",
            };
            return View(VM);
        }
        
        public ActionResult VerificarSiExisteDNI(string DNI, int cursoid)
        {

            if (db.Inscripciones.Any(x=>x.DNI == DNI && x.EstadoID ==3))
            {
               
                ViewModelInscripcionParaNadador VM = new ViewModelInscripcionParaNadador
                {
                    Inscripcion= db.Inscripciones.Where(x => x.DNI == DNI).FirstOrDefault(),
                    curso = db.Curso.Find(cursoid),
                };

                return View("GetNadador", VM);
            }
            else if( db.Entrenadores.Any(x=>x.DNI== DNI))
            {
                Entrenadores entrenador = db.Entrenadores.Where(x => x.DNI == DNI).FirstOrDefault();
                ViewModelInscripcionParaEntrenador VM = new ViewModelInscripcionParaEntrenador
                {
                    Entrenador = entrenador,
                    curso = db.Curso.Find(cursoid),
                };
                return View("GetEntrenador", VM);
            }
            return PartialView("NoGetNothing");
        }

        [HttpPost]
        public ActionResult GrabarEntrenador(ViewModelInscripcionParaEntrenador VM)
        {
            Entrenadores entrenador = db.Entrenadores.Find(VM.Entrenador.EntrenadorId);
            CursoParticipante participante = new CursoParticipante
            {
                Nombres = entrenador.Nombre,
                Paterno = entrenador.Paterno,
                Nacimiento = entrenador.Fecha_de_nacimiento,
                DNI = entrenador.DNI,
                Email = entrenador.Email1,
                Celular = entrenador.Celular1,
                Actividad = "entrenador",
                Nacionalidad ="",
            };
            if (entrenador.Materno != null)
            {
                participante.Materno = entrenador.Materno;
            }
            else
            {
                participante.Materno = "";
            }

            db.CursoParticipante.Add(participante);
            db.SaveChanges();
            CursoInscripcion CursoInscripcion = new CursoInscripcion
            {
                ParticipanteId = participante.ParticipanteId,
                CursoId = VM.curso.CursoId,
            };
            db.CursoInscripcion.Add(CursoInscripcion);           
            db.SaveChanges();

            string EnviarEmail = EnviarConfirmacion(CursoInscripcion.InscripcionId);
            return RedirectToAction("Gracias");

        }


        [HttpPost]
        public ActionResult GrabarNadador(ViewModelInscripcionParaNadador VM)
        {
            if (!TryUpdateModel(VM))
            {
                VM.Inscripcion = db.Inscripciones.Find(VM.Inscripcion.InscripcionId);
                VM.curso = db.Curso.Find(VM.curso.CursoId);
                VM.mensaje = "Debe de ingresar su celular y correo";
                return View("GetNadador", VM);
            }
            Inscripciones inscripcion = db.Inscripciones.Find(VM.Inscripcion.InscripcionId);
            CursoParticipante participante = new CursoParticipante
            {
                Nombres = inscripcion.Afiliado.Nombre,
                Paterno = inscripcion.Afiliado.Apellido_Paterno,              
               
                Nacimiento = inscripcion.Afiliado.Fecha_de_nacimiento,
                DNI = inscripcion.Afiliado.DNI,
                Email = VM.Email,
                Celular = VM.Celular,
                Actividad = "deportista",
                Nacionalidad = "",
            };
            if (inscripcion.Afiliado.Apellido_Materno != null)
            {
                participante.Materno = inscripcion.Afiliado.Apellido_Materno;
            }
            else
            {
                participante.Materno = "";
            }
            db.CursoParticipante.Add(participante);
            db.SaveChanges();
            CursoInscripcion CursoInscripcion = new CursoInscripcion
            {
                ParticipanteId = participante.ParticipanteId,
                CursoId = VM.curso.CursoId,
            };
            db.CursoInscripcion.Add(CursoInscripcion);
            db.SaveChanges();

            string EnviarEmail = EnviarConfirmacion(CursoInscripcion.InscripcionId);
            return RedirectToAction("Gracias");
        }

        public JsonResult BuscarDNI(string DNI)
        {
            var participante = db.CursoParticipante.Where(x => x.DNI == DNI)
                .Select(x=> new { x.Nombres, x.DNI, x.Paterno, x.Materno, x.Nacimiento, x.Email, x.Celular, x.Nacionalidad, x.Actividad })
                .FirstOrDefault();
            return Json(participante, JsonRequestBehavior.AllowGet);
        }
    }
}
