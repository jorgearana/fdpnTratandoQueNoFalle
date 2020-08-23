using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class Resultsmasters
    {
        public int Meet { get; set; }
        public int Athlete { get; set; }
        public string IR { get; set; }
        public int Team { get; set; }
        public string Score { get; set; }
        public string FP { get; set; }
        public string Ex { get; set; }
        public byte Nt { get; set; }
        public short Age { get; set; }
        public string Distance { get; set; }
        public string Stroke { get; set; }
        public string Mtev { get; set; }
        public short LoHi { get; set; }
        public short Points { get; set; }
        public short Place { get; set; }
        public string Course { get; set; }
        public string Division { get; set; }
        public int? Pfina { get; set; }
        public int? AthleteId { get; set; }
        public int? MeetId { get; set; }
        public int? TeamId { get; set; }
        public int? PruebaId { get; set; }
        public int ResultId { get; set; }
        public double? Tiempobase { get; set; }

        public virtual AthleteMasters AthleteNavigation { get; set; }
        public virtual Meetmasters MeetNavigation { get; set; }
        public virtual Pruebas Prueba { get; set; }
        public virtual Teammasters TeamNavigation { get; set; }
    }
}
