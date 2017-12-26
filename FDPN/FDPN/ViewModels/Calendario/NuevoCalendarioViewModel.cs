using FDPN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FDPN.ViewModels.Calendario
{
    public class NuevoCalendarioViewModel
    {
        public Models.Calendario calendario { get; set; }
        public List<Disciplina> disciplinas { get; set; }
    }
}