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
    
    public partial class ChopiOrganizador
    {
        public int OrganizadorId { get; set; }
        public int ClubId { get; set; }
        public int TorneoId { get; set; }
        public bool Activo { get; set; }
    
        public virtual ChopiClubes ChopiClubes { get; set; }
        public virtual ChopiTorneo ChopiTorneo { get; set; }
    }
}
