using FDPN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FDPN.ViewModels.Documento
{
    public class BasesViewModel
    {
        public List<Disciplina> disciplinas { get; set; }
        public List<Fotos> fotos { get; set; }
        public int? disciplinaid { get; set; }
    }
}