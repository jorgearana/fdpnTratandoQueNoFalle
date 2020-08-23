using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
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
        public DateTime Fecha { get; set; }
        public int ClubId { get; set; }

        public virtual Inscripciones Inscripcion { get; set; }
    }
}
