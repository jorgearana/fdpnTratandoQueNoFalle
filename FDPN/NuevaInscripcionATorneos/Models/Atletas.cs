using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class Atletas
    {
        public int AthNo { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Initial { get; set; }
        public string AthSex { get; set; }
        public DateTime? BirthDate { get; set; }
        public int? TeamNo { get; set; }
        public string SchlYr { get; set; }
        public short? AthAge { get; set; }
        public string RegNo { get; set; }
        public string AthStat { get; set; }
        public int? DivNo { get; set; }
        public int? CompNo { get; set; }
        public string PrefName { get; set; }
        public string HomeAddr1 { get; set; }
        public string HomeAddr2 { get; set; }
        public string HomeCity { get; set; }
        public string HomeProv { get; set; }
        public string HomeStatenew { get; set; }
        public string HomeZip { get; set; }
        public string HomeCntry { get; set; }
        public string HomeDaytele { get; set; }
        public string HomeEvetele { get; set; }
        public string HomeFaxtele { get; set; }
        public string HomeEmail { get; set; }
        public string CitizenOf { get; set; }
        public string PictureBmp { get; set; }
        public string SecondClub { get; set; }
        public string HomeCelltele { get; set; }
        public string BcssaType { get; set; }
        public string HomeEmergcontact { get; set; }
        public string HomeEmergtele { get; set; }
        public short? DisabScode { get; set; }
        public short? DisabSbcode { get; set; }
        public short? DisabSmcode { get; set; }
        public string DisabSdmsid { get; set; }
        public string DisabExeptioncodes { get; set; }
        public bool MastersRegVerified { get; set; }
        public int AtletaId { get; set; }
        public int Meetid { get; set; }
        public int TeamId { get; set; }

        public virtual Torneo Meet { get; set; }
        public virtual Equipos Team { get; set; }
    }
}
