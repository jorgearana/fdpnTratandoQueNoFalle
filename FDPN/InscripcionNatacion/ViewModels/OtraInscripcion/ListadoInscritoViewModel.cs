using FDPN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InscripcionNatacion.ViewModels.OtraInscripcion
{
    public class ListadoInscritoViewModel
    {
        public Inscripciones afiliado { get; set; }

        public bool YaestaInscrito { get; set; }

        public int PruebasTotales { get; set; }//que puede nadar por torneo

        public int PruebasInscritas { get; set; }//sumando con marca y sin marca

        public int TorneoId { get; set; }

        public int EquipoId { get; set; }
    }
}