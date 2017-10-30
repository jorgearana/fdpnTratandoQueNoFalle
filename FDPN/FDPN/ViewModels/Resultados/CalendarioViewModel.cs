using FDPN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FDPN.ViewModels.Resultados
{
    public class CalendarioViewModel
    {
        public List<Calendario> calendario { get; set; }
        public List<string> disciplinas { get; set; }
        public string disciplina { get; set; }

        
    }
}