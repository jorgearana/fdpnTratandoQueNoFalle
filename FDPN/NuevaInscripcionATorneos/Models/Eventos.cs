using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class Eventos
    {
        public short? EventNo { get; set; }
        public string EventLtr { get; set; }
        public int EventPtr { get; set; }
        public string IndRel { get; set; }
        public string EventSex { get; set; }
        public string EventGender { get; set; }
        public float? EventDist { get; set; }
        public string EventStroke { get; set; }
        public short? LowAge { get; set; }
        public short? HighAge { get; set; }
        public bool MultiAge { get; set; }
        public string EventStat { get; set; }
        public short? EventRounds { get; set; }
        public short? NumPrelanes { get; set; }
        public short? NumFinlanes { get; set; }
        public string HeatsInfinal { get; set; }
        public short? HeatsInsemi { get; set; }
        public string StdLanes { get; set; }
        public bool AutoSeed { get; set; }
        public bool TwoperlaneReq { get; set; }
        public string PreheatOrder { get; set; }
        public string FinheatOrder { get; set; }
        public bool ScoreEvent { get; set; }
        public short? DivNo { get; set; }
        public short? RelaySize { get; set; }
        public string Comm1 { get; set; }
        public string Comm2 { get; set; }
        public string Comm3 { get; set; }
        public string Comm4 { get; set; }
        public decimal? EntryFee { get; set; }
        public bool IsLocked { get; set; }
        public string LockedBy { get; set; }
        public string EventType { get; set; }
        public string LockedList { get; set; }
        public string EventNote { get; set; }
        public bool SuppressStroke { get; set; }
        public bool CustomAbcfinal { get; set; }
        public short? NumDives { get; set; }
        public short? NumHeatsInFinal { get; set; }
        public bool MultiageSuperFinal { get; set; }
        public bool FinalsLanesVary { get; set; }
        public string FinalsLanesVaryOrder { get; set; }
        public string AbcfinalOrder { get; set; }
        public bool AbcStyle { get; set; }
        public bool PrelimsAsExtendedFinal { get; set; }
        public short? NumLanesInBestHeatsTimedFinal { get; set; }
        public short? NumBestHeatsTimedFinal { get; set; }
        public bool TimedFinalLanesVary { get; set; }
        public bool ScoreTimedFinalAsAbc { get; set; }
        public short? NumHeatsInTimedFinalToScore { get; set; }
        public bool PadsBothEnds { get; set; }
        public bool MultiageSuperSeed { get; set; }
        public bool SuppressDistance { get; set; }
        public bool FinAwardsPrinted { get; set; }
        public bool PreAwardsPrinted { get; set; }
        public bool SemAwardsPrinted { get; set; }
        public string FastTimeStdAbbr { get; set; }
        public string SlowTimeStdAbbr { get; set; }
        public bool SuperFinalElimOldAgeGrp { get; set; }
        public bool SeedMultiAgeOldToYoung { get; set; }
        public bool MultiAgeScnd { get; set; }
        public short? NumRelayLegs { get; set; }
        public bool PadsBothEndsFinals { get; set; }
        public int? CheckinStarttime { get; set; }
        public int? CheckinEndtime { get; set; }
        public DateTime? CheckinStartdate { get; set; }
        public DateTime? CheckinEnddate { get; set; }
        public short? NumSemlanes { get; set; }
        public short? EvtMaxAgeForCfinal { get; set; }
        public short? EvtMaxAgeNumHeatsCfinal { get; set; }
        public int? FinActualstarttime { get; set; }
        public int? SemActualstarttime { get; set; }
        public int? PreActualstarttime { get; set; }
        public int EventId { get; set; }
        public int MeetId { get; set; }

        public virtual Torneo Meet { get; set; }
    }
}
