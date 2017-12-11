using FDPN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FDPN.ViewModels.Administrador
{
    public class EditarCalendarioViewModel
    {
        public Calendario calendario { get; set; }
        public List<Disciplina> disciplinas{ get; set; }

    }
}