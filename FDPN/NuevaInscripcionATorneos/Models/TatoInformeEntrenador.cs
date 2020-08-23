using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class TatoInformeEntrenador
    {
        public int InformeId { get; set; }
        public int EntrenadorId { get; set; }
        public int InscripcionId { get; set; }
        public int SerieId { get; set; }
        public string MejorMarca { get; set; }
        public DateTime Fecha { get; set; }
        public int Pruebaid { get; set; }
        public double MarcaEntrenamiento { get; set; }
        public string Sensacion { get; set; }
        public int RealizacionId { get; set; }
        public int Zona { get; set; }

        public virtual Entrenadores Entrenador { get; set; }
        public virtual Inscripciones Inscripcion { get; set; }
        public virtual TatoRealizacion Realizacion { get; set; }
        public virtual TatoSeriesEjemplo Serie { get; set; }
    }
}
