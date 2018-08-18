using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InscripcionACurso.Models;

namespace InscripcionACurso.ViewModels.Inscripcion
{
    public class InscripcionViewModel
    {
        public Curso curso { get; set; }
        public CursoParticipante CursoParticipante  { get; set; }
        public string Mensaje { get; set; }
        public DateTime hacetiempo { get; set; }
    }
}