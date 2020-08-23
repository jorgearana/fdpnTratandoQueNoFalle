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
    
    public partial class TatoInformeEntrenador
    {
        public int InformeId { get; set; }
        public int EntrenadorId { get; set; }
        public int InscripcionId { get; set; }
        public int SerieId { get; set; }
        public string MejorMarca { get; set; }
        public System.DateTime Fecha { get; set; }
        public int Pruebaid { get; set; }
        public double MarcaEntrenamiento { get; set; }
        public string Sensacion { get; set; }
        public int RealizacionId { get; set; }
        public int Zona { get; set; }
    
        public virtual Entrenadores Entrenadores { get; set; }
        public virtual Inscripciones Inscripciones { get; set; }
        public virtual TatoRealizacion TatoRealizacion { get; set; }
        public virtual TatoSeriesEjemplo TatoSeriesEjemplo { get; set; }
    }
}
