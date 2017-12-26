using FDPN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FDPN.ViewModels.Resultados
{
    public class CalendarioViewModel
    {
        public List<Models.Calendario> calendario { get; set; }
        public List<Disciplina> disciplinas { get; set; }
        public string disciplina { get; set; }

        
    }
}