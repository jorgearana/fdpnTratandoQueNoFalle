using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InscripcionACurso.Models
{
    public class PartialCursoParticipante
    {
        [MetadataType(typeof(CursoParticipantemetadata))]
        public partial class CursoParticipante
        {
        }
        public class CursoParticipantemetadata
        {
            [Required(ErrorMessage = "El Email no puede dejarse vacío")]
            [DataType(DataType.EmailAddress, ErrorMessage = "no es una dirección válida")]
            [Display(Name = "Email address")]
            [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
            public string EMail { get; set; }

        }
    }
}

