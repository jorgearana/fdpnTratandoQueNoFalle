using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FDPN.ViewModels.CursoCalendario
{
    public class DTOAlumno
    {

        public int AlumnoId { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string Nombres { get; set; }
        [Required]
        [Display(Name = "Apellido paterno")]
        public string ApellidoP { get; set; }
        [Required]
        [Display(Name = "Apellido materno")]
        public string ApellidoM { get; set; }
        [Required]
        [Display(Name = "DNI")]
        public string DNI { get; set; }
        [Required]
        [Display(Name = "Sexo")]
        public string Sexo { get; set; }
        [Required]
        [Display(Name = "Nacimiento")]
        public System.DateTime Nacimiento { get; set; }
        [Required]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }
        [Required]
        [Display(Name = "Celular")]
        public string Celular { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }
        public Nullable<int> FotoId { get; set; }
    }
}