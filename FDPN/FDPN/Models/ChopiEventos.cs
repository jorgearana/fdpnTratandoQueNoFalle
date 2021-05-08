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
    
    public partial class ChopiEventos
    {
        public ChopiEventos()
        {
            this.ChopiInscripciones = new HashSet<ChopiInscripciones>();
            this.ChopiPostas = new HashSet<ChopiPostas>();
        }
    
        public int EventoId { get; set; }
        public int Distancia { get; set; }
        public int EstiloId { get; set; }
        public int CategoriaId { get; set; }
        public int SexoId { get; set; }
        public bool IR { get; set; }
        public int TorneoId { get; set; }
        public int Numero { get; set; }
        public bool Finalizado { get; set; }
        public bool Puntuable { get; set; }
    
        public virtual ChopiCategorias ChopiCategorias { get; set; }
        public virtual ChopiEstilos ChopiEstilos { get; set; }
        public virtual ChopiSexos ChopiSexos { get; set; }
        public virtual ChopiTorneo ChopiTorneo { get; set; }
        public virtual ICollection<ChopiInscripciones> ChopiInscripciones { get; set; }
        public virtual ICollection<ChopiPostas> ChopiPostas { get; set; }
    }
}
