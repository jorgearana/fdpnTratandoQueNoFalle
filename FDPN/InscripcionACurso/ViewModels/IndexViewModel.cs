using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InscripcionACurso.Models;

namespace InscripcionACurso.ViewModels
{
    public class IndexViewModel
    {
        public Curso curso { get; set; }
        public int cantidadinscritos { get; set; }
    }
}