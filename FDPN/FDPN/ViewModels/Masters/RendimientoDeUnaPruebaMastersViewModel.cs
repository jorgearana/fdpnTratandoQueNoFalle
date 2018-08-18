using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FDPN.Models;

namespace FDPN.ViewModels.Masters
{
    public class RendimientoDeUnaPruebaMastersViewModel
    {
        public AthleteMasters atleta { get; set; }
        public List<RESULTSMasters> ResultadosCorta { get; set; }
        public List<RESULTSMasters> ResultadosLarga { get; set; }
        public Pruebas prueba { get; set; }
        public Afiliado afiliado { get; set; }
    }
}