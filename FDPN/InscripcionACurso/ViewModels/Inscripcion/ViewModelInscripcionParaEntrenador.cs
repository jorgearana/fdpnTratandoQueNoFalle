using InscripcionACurso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InscripcionACurso.ViewModels.Inscripcion
{
    public class ViewModelInscripcionParaEntrenador
    {
        public Entrenadores     Entrenador{ get; set; }
        public Curso curso { get; set; }      

        public string mensaje { get; set; }
    }
}