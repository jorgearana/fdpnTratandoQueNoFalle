//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FDPN.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ChopiInscripciones
    {
        public int InscripcionId { get; set; }
        public int DeportistaId { get; set; }
        public int EventoId { get; set; }
        public double TiempoSembrado { get; set; }
        public double TiempoFinal { get; set; }
        public int PuestoFinal { get; set; }
        public int EstadoId { get; set; }
        public double Puntos { get; set; }
    
        public virtual ChopiDeportistas ChopiDeportistas { get; set; }
        public virtual ChopiEstados ChopiEstados { get; set; }
        public virtual ChopiEventos ChopiEventos { get; set; }
    }
}
