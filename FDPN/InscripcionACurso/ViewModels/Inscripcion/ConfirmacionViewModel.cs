using InscripcionACurso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InscripcionACurso.ViewModels.Inscripcion
{
    public class ConfirmacionViewModel
    {
        public  Curso  curso { get; set; }
        public CursoInscripcion inscripcion { get; set; }
        public CursoParticipante participante { get; set; }
    }
}