using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using FDPN.Models;

namespace FDPN.Models
{
    [MetadataType(typeof(DirectivoMetaData))]
    public partial class Directivos
    {
    }
    public class  DirectivoMetaData
    {
        [Required]  public string Nombre { get; set; }
        [Required]  public string Apellidos { get; set; }
        [Required] public string Email { get; set; }
        [Required] public string Celular { get; set; }
        [Required] public string Cargo { get; set; }
    }
}