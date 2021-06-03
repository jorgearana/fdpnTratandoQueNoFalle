//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Rankings
{
    using System;
    using System.Collections.Generic;
    
    public partial class Equipos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Equipos()
        {
            this.atletas = new HashSet<atletas>();
            this.InscripcionResponsable = new HashSet<InscripcionResponsable>();
        }
    
        public int Team_no { get; set; }
        public string Team_name { get; set; }
        public string Team_short { get; set; }
        public string Team_abbr { get; set; }
        public string Team_stat { get; set; }
        public string Team_lsc { get; set; }
        public Nullable<short> Team_div { get; set; }
        public Nullable<short> Team_region { get; set; }
        public string Team_head { get; set; }
        public string Team_asst { get; set; }
        public string Team_addr1 { get; set; }
        public string Team_addr2 { get; set; }
        public string Team_city { get; set; }
        public string Team_prov { get; set; }
        public string Team_statenew { get; set; }
        public string Team_zip { get; set; }
        public string Team_cntry { get; set; }
        public string Team_daytele { get; set; }
        public string Team_evetele { get; set; }
        public string Team_faxtele { get; set; }
        public string Team_email { get; set; }
        public string Team_c3 { get; set; }
        public string Team_c4 { get; set; }
        public string Team_c5 { get; set; }
        public string Team_c6 { get; set; }
        public string Team_c7 { get; set; }
        public string Team_c8 { get; set; }
        public string Team_c9 { get; set; }
        public string Team_c10 { get; set; }
        public string Team_altabbr { get; set; }
        public bool Team_NoPoints { get; set; }
        public bool Team_Selected { get; set; }
        public string Team_altname { get; set; }
        public bool NoTeam_surcharge { get; set; }
        public bool NoFacility_surcharge { get; set; }
        public bool NoAthlete_surcharge { get; set; }
        public string Team_cell { get; set; }
        public bool NoRelayOnly_surcharge { get; set; }
        public int TeamId { get; set; }
        public int MeetId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<atletas> atletas { get; set; }
        public virtual Torneo Torneo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InscripcionResponsable> InscripcionResponsable { get; set; }
    }
}