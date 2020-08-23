using InscripcionACurso.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace InscripcionACurso.ViewModels.Inscripcion
{
    public class ViewModelInscripcionParaNadador
    {
        public Inscripciones     Inscripcion{ get; set; }
        public Curso curso { get; set; }

        [Required]
        public string Email { get; set; }
        [Required]
        public string Celular { get; set; }

        public string   mensaje{ get; set; }
    }
}