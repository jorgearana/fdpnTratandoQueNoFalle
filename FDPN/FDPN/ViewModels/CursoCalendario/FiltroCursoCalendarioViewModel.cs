using FDPN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FDPN.ViewModels.CursoCalendario
{
    public class FiltroCursoCalendarioViewModel
    {
        public List<PCalendario> Calendarios { get; set; }
        public List<DisciplinaCheck> DisciplinasCheck { get; set; }
        public List<CursoCheck> CursoCheck { get; set; }

        public List<NivelCheck> NivelCheck { get; set; }
    }


    public class DisciplinaCheck
    {
        public Disciplina Disciplina { get; set; }
        public bool Seleccionada { get; set; }
    }

    public class NivelCheck
    {
        public bool Seleccionado { get; set; }
        public string Nombre { get; set; }
    }

    public class CursoCheck 
    {
        public bool Seleccionado { get; set; }
        public string Nombre { get; set; }
    }

}