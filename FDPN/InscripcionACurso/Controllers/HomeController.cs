﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InscripcionACurso.Models;
using InscripcionACurso.Helpers;
using InscripcionACurso.ViewModels;

namespace InscripcionACurso.Controllers
{
    public class HomeController : Controller
    {
        DB_9B1F4C_MVCcompetenciasEntities db = new DB_9B1F4C_MVCcompetenciasEntities();
        ConvertirAPeru convertidor = new ConvertirAPeru();

        public ActionResult Index()
        {
            

            DateTime hoy = convertidor.ToPeru(DateTime.UtcNow).AddDays(1);
            List<IndexViewModel> VM = new List<IndexViewModel>();
            List<Curso> cursos = db.Curso.Where(x => x.Fin >= hoy).OrderBy(x => x.Fin).ThenByDescending(x => x.Inicio).ToList();
            List<CursoInscripcion> Inscritos = db.CursoInscripcion.ToList();
            foreach(Curso curso in cursos)
            {
                IndexViewModel CursoYParticipante = new IndexViewModel
                {
                    curso = curso,
                    cantidadinscritos = Inscritos.Where(x=>x.CursoId == curso.CursoId).Count(),
                };
                if(CursoYParticipante.cantidadinscritos < CursoYParticipante.curso.CantidadMaxima)
                {
                    VM.Add(CursoYParticipante);
                }
               
            }
           
           
           
            return View(VM);
        }

        public ActionResult inscribir()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Mantenimiento()
        {
            return View();
        }

       
    }
}