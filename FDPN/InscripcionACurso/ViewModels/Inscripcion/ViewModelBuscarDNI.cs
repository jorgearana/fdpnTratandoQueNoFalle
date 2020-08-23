using InscripcionACurso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InscripcionACurso.ViewModels.Inscripcion
{
    public class ViewModelBuscarDNI
    {
        public Curso curso { get; set; }
        public string DNI { get; set; }
    }
}