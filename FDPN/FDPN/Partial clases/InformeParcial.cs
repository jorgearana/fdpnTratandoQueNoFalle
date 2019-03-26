using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace FDPN.Models
{
    [MetadataType(typeof(TatoInformeEntrenador_Validation))]
    public partial class TatoInformeEntrenador
    {

    }

    public class TatoInformeEntrenador_Validation
    {

        [Required(ErrorMessage = "Debe de escoger la serie")]
        public int SerieId { get; set; }

        [Required(ErrorMessage = "Debe de ingresar la fecha del control")]
        public System.DateTime Fecha { get; set; }


        [Required(ErrorMessage = "Debe de escoger la prueba")]
        public int Pruebaid { get; set; }

        [Required(ErrorMessage = "Debe de ingresar el tiempo de control")]
        public double MarcaEntrenamiento { get; set; }

        [Required(ErrorMessage = "Debe de ingresar la sensaciòn del entrenamiento")]
        public string Sensacion { get; set; }

        [Required(ErrorMessage = "Debe de escoger el nivel realizado")]
        public int RealizacionId { get; set; }

    }
}