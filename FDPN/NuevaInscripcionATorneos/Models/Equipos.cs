using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class Equipos
    {
        public Equipos()
        {
            Atletas = new HashSet<Atletas>();
            InscripcionResponsable = new HashSet<InscripcionResponsable>();
        }

        public int TeamNo { get; set; }
        public string TeamName { get; set; }
        public string TeamShort { get; set; }
        public string TeamAbbr { get; set; }
        public string TeamStat { get; set; }
        public string TeamLsc { get; set; }
        public short? TeamDiv { get; set; }
        public short? TeamRegion { get; set; }
        public string TeamHead { get; set; }
        public string TeamAsst { get; set; }
        public string TeamAddr1 { get; set; }
        public string TeamAddr2 { get; set; }
        public string TeamCity { get; set; }
        public string TeamProv { get; set; }
        public string TeamStatenew { get; set; }
        public string TeamZip { get; set; }
        public string TeamCntry { get; set; }
        public string TeamDaytele { get; set; }
        public string TeamEvetele { get; set; }
        public string TeamFaxtele { get; set; }
        public string TeamEmail { get; set; }
        public string TeamC3 { get; set; }
        public string TeamC4 { get; set; }
        public string TeamC5 { get; set; }
        public string TeamC6 { get; set; }
        public string TeamC7 { get; set; }
        public string TeamC8 { get; set; }
        public string TeamC9 { get; set; }
        public string TeamC10 { get; set; }
        public string TeamAltabbr { get; set; }
        public bool TeamNoPoints { get; set; }
        public bool TeamSelected { get; set; }
        public string TeamAltname { get; set; }
        public bool NoTeamSurcharge { get; set; }
        public bool NoFacilitySurcharge { get; set; }
        public bool NoAthleteSurcharge { get; set; }
        public string TeamCell { get; set; }
        public bool NoRelayOnlySurcharge { get; set; }
        public int TeamId { get; set; }
        public int MeetId { get; set; }

        public virtual Torneo Meet { get; set; }
        public virtual ICollection<Atletas> Atletas { get; set; }
        public virtual ICollection<InscripcionResponsable> InscripcionResponsable { get; set; }
    }
}
