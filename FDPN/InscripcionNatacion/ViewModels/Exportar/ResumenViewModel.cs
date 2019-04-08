using FDPN.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InscripcionNatacion.ViewModels.Exportar
{
    public class ModelAExportar
    {
        public List<ResumenViewModel> resumenentradas { get; set; }
        public List<Delegados> delegados { get; set; }
        public List<EntrenadorInscrito> entrenadorInscritos { get; set; }
        public List<atletas> SoloPostas { get; set; }
    }
    public class ResumenViewModel
    {
        public Afiliado afiliado { get; set; }
        public atletas atleta { get; set; }
        public List<DetalleDeEntradas> detalle { get; set; }
       
        public DateTime FN { get; set; }
        public int NumeroAtleta { get; set; }
    }

    public class DetalleDeEntradas
    {
        public Eventos evento { get; set; }
        public Entradas entrada { get; set; }
        public Estilos estilo { get; set; }
        public string Marca { get; set; }

    }
}