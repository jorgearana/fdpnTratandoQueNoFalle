using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FDPN.Models;


namespace InscripcionNatacion.ViewModels.Inscrito
{
    public class ListadoInscritoViewModel
    {
        public Inscripciones afiliado { get; set; }

        public List<InscritoViewModel> listaDeEventos { get; set; }

        public bool YaestaInscrito { get; set; }

        public List<SesionViewModel> Sesiones { get; set; }

        public int  SinMarca { get; set; }
        //Sirve para ver cuantas pruebas sin marca se puede inscribir

        public int PruebasInscritasSinMarca { get; set; } 

        public int PruebasTotales { get; set; }//que puede nadar por torneo

        public int PruebasInscritas { get; set; }//sumando con marca y sin marca

        public string Piscina  { get; set; }

        public int MeetId { get; set; }

        public int TeamId { get; set; }
    }
}