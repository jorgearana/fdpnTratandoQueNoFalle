﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FDPN.Models
{
    
    [MetadataType(typeof(AfiliadoMetaData))]
    public partial class Afiliado
    {
    }
    public class AfiliadoMetaData
    {
        [Required(ErrorMessage = "Debe de ingresar el nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Debe de ingresar el Apellido paterno")]
        public string Apellido_Paterno { get; set; }

        [Required(ErrorMessage = "Debe de ingresar el número de documento de identidad")]
        public string DNI { get; set; }

        [Required(ErrorMessage = "Debe de escoger el sexo del(a) deportista")]
        public string Sexo { get; set; }

        [Required(ErrorMessage = "Debe de ingresar la fecha de nacimiento")]
        public System.DateTime Fecha_de_nacimiento { get; set; }
    }

   
}