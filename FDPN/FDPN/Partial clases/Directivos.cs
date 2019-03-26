using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace FDPN.Models
{
    [MetadataType(typeof(Directivos_Validation))]
    public partial class Directivos
    {

    }

    public class Directivos_Validation
    {
        [StringLength(50,  ErrorMessage = "No puede tener más de 50 caracteres")]
        public string Cargo { get; set; }

        [Required(ErrorMessage = "Debe de seleccionar un club")]
        public int ClubId { get; set; }




    }


    }