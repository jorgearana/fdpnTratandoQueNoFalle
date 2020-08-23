using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class Entradas
    {
        public int? EventPtr { get; set; }
        public int? AthNo { get; set; }
        public string ActSeedCourse { get; set; }
        public float? ActualSeedTime { get; set; }
        public string ConvSeedCourse { get; set; }
        public float? ConvSeedTime { get; set; }
        public bool ScrStat { get; set; }
        public string SpecStat { get; set; }
        public string DecStat { get; set; }
        public bool AltStat { get; set; }
        public bool? BonusEvent { get; set; }
        public int? DivNo { get; set; }
        public float? EvScore { get; set; }
        public float? JdevScore { get; set; }
        public short? SeedPlace { get; set; }
        public short? EventAge { get; set; }
        public short? PreHeat { get; set; }
        public short? PreLane { get; set; }
        public string PreStat { get; set; }
        public float? PreTime { get; set; }
        public string PreCourse { get; set; }
        public short? PreHeatplace { get; set; }
        public short? PrePlace { get; set; }
        public short? PreJdplace { get; set; }
        public string PreExh { get; set; }
        public short? PrePoints { get; set; }
        public float? PreBack1 { get; set; }
        public float? PreBack2 { get; set; }
        public float? PreBack3 { get; set; }
        public float? PreWatch1 { get; set; }
        public float? PrePad { get; set; }
        public string PreReactiontime1 { get; set; }
        public string PreDqcode { get; set; }
        public string PreDqcodeSecond { get; set; }
        public string PreTimeType { get; set; }
        public short? FinHeat { get; set; }
        public short? FinLane { get; set; }
        public string FinStat { get; set; }
        public float? FinTime { get; set; }
        public string FinCourse { get; set; }
        public short? FinHeatplace { get; set; }
        public short? FinJdheatplace { get; set; }
        public short? FinPlace { get; set; }
        public short? FinJdplace { get; set; }
        public string FinExh { get; set; }
        public short? FinPoints { get; set; }
        public float? FinBack1 { get; set; }
        public float? FinBack2 { get; set; }
        public float? FinBack3 { get; set; }
        public float? FinWatch1 { get; set; }
        public float? FinPad { get; set; }
        public string FinReactiontime1 { get; set; }
        public string FinDqcode { get; set; }
        public string FinDqcodeSecond { get; set; }
        public short? FinPtsplace { get; set; }
        public string FinHeatltr { get; set; }
        public string FinTimeType { get; set; }
        public short? SemHeat { get; set; }
        public short? SemLane { get; set; }
        public string SemStat { get; set; }
        public float? SemTime { get; set; }
        public string SemCourse { get; set; }
        public short? SemHeatplace { get; set; }
        public short? SemPlace { get; set; }
        public short? SemJdplace { get; set; }
        public string SemExh { get; set; }
        public short? SemPoints { get; set; }
        public float? SemBack1 { get; set; }
        public float? SemBack2 { get; set; }
        public float? SemBack3 { get; set; }
        public float? SemWatch1 { get; set; }
        public float? SemPad { get; set; }
        public string SemReactiontime1 { get; set; }
        public string SemDqcode { get; set; }
        public string SemDqcodeSecond { get; set; }
        public string SemTimeType { get; set; }
        public string DqType { get; set; }
        public short? FinGroup { get; set; }
        public float? FinDolphin1 { get; set; }
        public float? FinDolphin2 { get; set; }
        public float? FinDolphin3 { get; set; }
        public float? PreDolphin1 { get; set; }
        public float? PreDolphin2 { get; set; }
        public float? PreDolphin3 { get; set; }
        public float? SemDolphin1 { get; set; }
        public float? SemDolphin2 { get; set; }
        public float? SemDolphin3 { get; set; }
        public bool EarlySeed { get; set; }
        public bool SuperPrefinalist { get; set; }
        public bool SuperFinfinalist { get; set; }
        public string FinAdjuststat { get; set; }
        public string PreAdjuststat { get; set; }
        public string SemAdjuststat { get; set; }
        public string FinDivingdd { get; set; }
        public string PreDivingdd { get; set; }
        public string SemDivingdd { get; set; }
        public string EntryMethod { get; set; }
        public int? FinDqofficial { get; set; }
        public int? PreDqofficial { get; set; }
        public int? SemDqofficial { get; set; }
        public bool PreContacted { get; set; }
        public int EntryId { get; set; }
        public int MeetId { get; set; }

        public virtual Torneo Meet { get; set; }
    }
}
