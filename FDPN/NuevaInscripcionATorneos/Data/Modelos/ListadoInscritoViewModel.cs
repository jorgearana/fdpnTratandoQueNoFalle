using NuevaInscripcionATorneos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NuevaInscripcionATorneos.Data.Modelos
{
    public class ListadoInscritoViewModel
    {
        public Inscripciones afiliado { get; set; }

        public List<InscritoViewModel> listaDeEventos { get; set; }

        public bool YaestaInscrito { get; set; }

        public List<SesionViewModel> Sesiones { get; set; }

        public int SinMarca { get; set; }
        //Sirve para ver cuantas pruebas sin marca se puede inscribir

        public int PruebasInscritasSinMarca { get; set; }

        public int PruebasTotales { get; set; }//que puede nadar por torneo

        public int PruebasInscritas { get; set; }//sumando con marca y sin marca

        public string Piscina { get; set; }

        public int MeetId { get; set; }

        public int TeamId { get; set; }
    }

    public class InscritoViewModel
    {
        public Eventos evento { get; set; }
        public bool entradayainscrita { get; set; }


        public int sesion { get; set; }


        public float segundos { get; set; }
        public float MMLarga { get; set; }
        public float MMCorta { get; set; }

        public string estilo { get; set; }
        public string MMLargaString { get; set; }
        public string MMCortaString { get; set; }
        public string tiempo { get; set; }

        public string torneo { get; set; }
        public string PiscinaDelTiempo { get; set; }

        public string MejorCursoDePiscina { get; set; }

        public Boolean Cumple { get; set; }


        public string Clase { get; set; }

    }
    public class InscritoViewModelDesSerializado
    {
        public string sesion { get; set; }
        public string Event_ptr { get; set; }


        public string Event_dist { get; set; }


        public string estilo { get; set; }
        public string Edades { get; set; }
        public string tiempo { get; set; }

        public string piscina { get; set; }
        public string MMLargaString { get; set; }
        public string MMCortaString { get; set; }
        public string torneo { get; set; }


    }

    public class SesionViewModel
    {
        public int Sesion { get; set; }
        public int Maximopermitido { get; set; }
        public int Inscritos { get; set; }
        public int Pendiente { get; set; }


    }

}
