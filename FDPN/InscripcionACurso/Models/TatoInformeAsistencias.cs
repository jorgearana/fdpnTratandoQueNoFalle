//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InscripcionACurso.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TatoInformeAsistencias
    {
        public int InformeId { get; set; }
        public int SesionesPlanificadas { get; set; }
        public int SesionesRealizadas { get; set; }
        public int VolumenPlanificado { get; set; }
        public int VolumenRealizado { get; set; }
        public int GimnasioPlanificado { get; set; }
        public int GimnasioRealizado { get; set; }
        public int InscripcionId { get; set; }
        public string Observaciones { get; set; }
        public int EntrenadorId { get; set; }
        public System.DateTime Fecha { get; set; }
        public int ClubId { get; set; }
    
        public virtual Inscripciones Inscripciones { get; set; }
    }
}
