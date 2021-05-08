using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class Torneo
    {
        public Torneo()
        {
            Atletas = new HashSet<Atletas>();
            Delegados = new HashSet<Delegados>();
            Entradas = new HashSet<Entradas>();
            EntrenadorInscrito = new HashSet<EntrenadorInscrito>();
            Equipos = new HashSet<Equipos>();
            Eventos = new HashSet<Eventos>();
            MarcasMinimas = new HashSet<MarcasMinimas>();
            MultiEdad = new HashSet<MultiEdad>();
            Sesion = new HashSet<Sesion>();
            SessionItem = new HashSet<SessionItem>();
            SetupTorneo = new HashSet<SetupTorneo>();
        }

        public string MeetName1 { get; set; }
        public string MeetHeader1 { get; set; }
        public string MeetHeader2 { get; set; }
        public string MeetLocation { get; set; }
        public DateTime? MeetStart { get; set; }
        public DateTime? MeetEnd { get; set; }
        public short? MeetIdformat { get; set; }
        public short? MeetClass { get; set; }
        public short? MeetMeettype { get; set; }
        public short? MeetCourse { get; set; }
        public bool EnterAges { get; set; }
        public bool EnterBirthdate { get; set; }
        public DateTime? CalcDate { get; set; }
        public bool EnterSchoolyr { get; set; }
        public bool ARelaysonly { get; set; }
        public bool UseHometown { get; set; }
        public bool ShowCountrycode { get; set; }
        public bool ScoresAfterevt { get; set; }
        public bool LastnameFirst { get; set; }
        public bool PunctNames { get; set; }
        public bool PunctTeams { get; set; }
        public bool WinMm { get; set; }
        public short? MeetNumlanes { get; set; }
        public short? PrelimheatsCircle { get; set; }
        public bool TimedfinalCircleseed { get; set; }
        public bool ForeignInfinal { get; set; }
        public bool ExhInfinal { get; set; }
        public bool NonconformLast { get; set; }
        public string CourseOrder { get; set; }
        public bool SeedExhlast { get; set; }
        public bool DualEvenodd { get; set; }
        public bool StrictEvenodd { get; set; }
        public int? TeamEvenlanes { get; set; }
        public int? TeamOddlanes { get; set; }
        public bool MastersBytimeonly { get; set; }
        public short? MastersAgegrpsskip { get; set; }
        public short? TimerPort { get; set; }
        public short? ScbdPort { get; set; }
        public string TimerVendor { get; set; }
        public string ScbdVendor { get; set; }
        public bool ShowInitial { get; set; }
        public bool UcaseNames { get; set; }
        public bool UcaseTeams { get; set; }
        public string OpenSeniorNone { get; set; }
        public bool EntryqualFaster { get; set; }
        public decimal? FacilitySurcharge { get; set; }
        public bool AnyoneOnrelay { get; set; }
        public string LanguageChoice { get; set; }
        public bool MilitaryTime { get; set; }
        public bool CheckTimes { get; set; }
        public bool EnterkeyAstab { get; set; }
        public bool DoubleEndedsplits { get; set; }
        public bool UseCompnumbers { get; set; }
        public short? FlightedMinentries { get; set; }
        public bool DiffptsMalefemale { get; set; }
        public bool DiffptsEachdivision { get; set; }
        public bool ScoreonlyIfexceedqualtime { get; set; }
        public bool ScoreFastestheatonly { get; set; }
        public bool EntrylimitsWarn { get; set; }
        public bool PointsbasedonSeedtime { get; set; }
        public bool PointsforOverachievers { get; set; }
        public bool PointsforUnderachievers { get; set; }
        public short? IndmaxscorersPerTeam { get; set; }
        public short? RelmaxscorersPerTeam { get; set; }
        public short? IndtopmanyAwards { get; set; }
        public short? ReltopmanyAwards { get; set; }
        public short? EntrymaxTotal { get; set; }
        public short? IndmaxPerath { get; set; }
        public short? RelmaxPerath { get; set; }
        public bool ForeignGetTeampoints { get; set; }
        public bool IncludeSwimupsinTeamscore { get; set; }
        public bool EnterCitizenof { get; set; }
        public short? MeetMeetstyle { get; set; }
        public bool FlagOverachievers { get; set; }
        public bool FlagUnderachievers { get; set; }
        public short? ScbdPunctuation { get; set; }
        public short? ScbdNames { get; set; }
        public short? ScbdRelaynames { get; set; }
        public bool ScbdCycle { get; set; }
        public short? ScbdCycleseconds { get; set; }
        public short? CopiesToprinter { get; set; }
        public bool ReportHeadersonly { get; set; }
        public bool AutoincCompno { get; set; }
        public bool PentscoringUsedqtime { get; set; }
        public decimal? SwimmerSurcharge { get; set; }
        public bool DirectlyToprinter { get; set; }
        public bool LastnameAsinitial { get; set; }
        public bool UnderEventname { get; set; }
        public bool SuppressArelay { get; set; }
        public bool PunctRecholders { get; set; }
        public bool UcaseRecholders { get; set; }
        public bool SuppressLsc { get; set; }
        public bool ShowathleteStatus { get; set; }
        public short? OpenLowage { get; set; }
        public bool UseeventsexTeamscore { get; set; }
        public bool SuppressSmallx { get; set; }
        public bool ScoreArelayonly { get; set; }
        public bool ThirteenandoverAssenior { get; set; }
        public bool SuppressJd { get; set; }
        public string AbcfinalOrder { get; set; }
        public short? MaxageforCfinal { get; set; }
        public string SanctionNumber { get; set; }
        public bool IncludeSanction { get; set; }
        public short? SpecialPoints { get; set; }
        public bool CountrelayAlt { get; set; }
        public bool UseNonConformingPoolFactor { get; set; }
        public float? NonConformingPoolFactor { get; set; }
        public string ApnewsTeam { get; set; }
        public float? PointsAwardedForDq { get; set; }
        public float? PointsAwardedForScratch { get; set; }
        public float? PointsAwardedForNt { get; set; }
        public bool EnterAthStat { get; set; }
        public bool ShowSecondclub { get; set; }
        public bool FirstinitialFulllastname { get; set; }
        public bool TurnonAutobackup { get; set; }
        public short? AutobackupInterval { get; set; }
        public bool PointsAwardedForExh { get; set; }
        public bool UseAltTeamAbbr { get; set; }
        public bool IsCanadianMasters { get; set; }
        public string EntryMsg { get; set; }
        public bool TimedfinalnonconformLast { get; set; }
        public string RefereeName { get; set; }
        public string RefereeHomphone { get; set; }
        public string RefereeOffphone { get; set; }
        public int? MeetAltitude { get; set; }
        public string ImportDir { get; set; }
        public string ExportDir { get; set; }
        public string BackupDir { get; set; }
        public string RestoreFromDir { get; set; }
        public string RestoreToDir { get; set; }
        public string FlatHtmlDir { get; set; }
        public string ApnewsDir { get; set; }
        public bool AllowSameEventDupRelayNames { get; set; }
        public int? DualTeamLane1 { get; set; }
        public int? DualTeamLane2 { get; set; }
        public int? DualTeamLane3 { get; set; }
        public int? DualTeamLane4 { get; set; }
        public int? DualTeamLane5 { get; set; }
        public int? DualTeamLane6 { get; set; }
        public int? DualTeamLane7 { get; set; }
        public int? DualTeamLane8 { get; set; }
        public int? DualTeamLane9 { get; set; }
        public int? DualTeamLane10 { get; set; }
        public bool StrictEvenoddfastestheatonly { get; set; }
        public bool DualseedingAltunusedlane { get; set; }
        public decimal? TeamSurcharge { get; set; }
        public bool DisplayActualEntryTime { get; set; }
        public short? IndmaxadvancePerTeam { get; set; }
        public short? RelmaxadvancePerTeam { get; set; }
        public bool RelayNamesLinkByLsc { get; set; }
        public bool ReadOnly { get; set; }
        public bool FlightedBasedOnResultsTime { get; set; }
        public bool ShowYearInPlaceOfAge { get; set; }
        public float? PenaltyPtsForNs { get; set; }
        public DateTime? EntryEligibilityDate { get; set; }
        public bool SuppressTimeStdAbbr { get; set; }
        public short? MastersIndlowage { get; set; }
        public short? MastersRellowage { get; set; }
        public bool CustomQualTimes { get; set; }
        public bool SuppressSplitsForDqs { get; set; }
        public bool SuppressSplitsForDqsRelay { get; set; }
        public string DqcodesType { get; set; }
        public bool SuppressTimesNotMeetQualTime { get; set; }
        public bool ShowAgeandBirthYear { get; set; }
        public string MeetState { get; set; }
        public string MeetCountry { get; set; }
        public string MeetLsc { get; set; }
        public bool BcssaDivbyTimeStd { get; set; }
        public bool ShowHyTekDecimals { get; set; }
        public bool SuppressResultsAdvQ { get; set; }
        public bool RelaysAs4x100Style { get; set; }
        public short? FlightedFlightcount { get; set; }
        public bool FlightedInclDq { get; set; }
        public bool RelaysAlternateTwoFastestFirst { get; set; }
        public int? DualTeamLane11 { get; set; }
        public int? DualTeamLane12 { get; set; }
        public DateTime? EntryDeadline { get; set; }
        public string MeetAddr1 { get; set; }
        public string MeetAddr2 { get; set; }
        public string MeetCity { get; set; }
        public string MeetZip { get; set; }
        public string MeetHostlsc { get; set; }
        public string MeetUsmastersMeetId { get; set; }
        public bool ShowFirstNameOverPreferred { get; set; }
        public bool ExcludeNtentriesWhenImporting { get; set; }
        public bool EnterBirthcentury { get; set; }
        public bool UsingTwopools { get; set; }
        public string Pool1Name { get; set; }
        public string Pool2Name { get; set; }
        public short? IndtopmanyAwardsSr { get; set; }
        public short? ReltopmanyAwardsSr { get; set; }
        public short? MaxforeignInfinal { get; set; }
        public bool FlagFastestRecordOnly { get; set; }
        public decimal? AthleteEarlysurcharge { get; set; }
        public decimal? AthleteLatesurcharge { get; set; }
        public DateTime? AthleteEarlysurchargedate { get; set; }
        public DateTime? AthleteLatesurchargedate { get; set; }
        public DateTime? EntryOpenDate { get; set; }
        public bool DisplayNtforTimesUnder5Sec { get; set; }
        public bool SortTeamCombosByTeamName { get; set; }
        public bool FastestHeatSomeLanesDoNotScore { get; set; }
        public bool RankDisabledByPoints { get; set; }
        public short? SpecialParapoints { get; set; }
        public bool DisabledDoNotAdvanceToFinals { get; set; }
        public short? PrelimheatsCircledist { get; set; }
        public bool DisabledIgnoreQualTimeForScoring { get; set; }
        public bool CountTimeTrialEvents { get; set; }
        public bool QualNonConformCourseUseMinStd { get; set; }
        public string LastUpdated { get; set; }
        public bool MixedRelaysDividedPoints { get; set; }
        public decimal? RelayOnlySurcharge { get; set; }
        public string TimeAdjMethod { get; set; }
        public bool DisabledSeedWithAgeGroupIfTimedFinalSuperSeed { get; set; }
        public int Meetid { get; set; }
        public bool MarcaMaxima { get; set; }

        public virtual ICollection<Atletas> Atletas { get; set; }
        public virtual ICollection<Delegados> Delegados { get; set; }
        public virtual ICollection<Entradas> Entradas { get; set; }
        public virtual ICollection<EntrenadorInscrito> EntrenadorInscrito { get; set; }
        public virtual ICollection<Equipos> Equipos { get; set; }
        public virtual ICollection<Eventos> Eventos { get; set; }
        public virtual ICollection<MarcasMinimas> MarcasMinimas { get; set; }
        public virtual ICollection<MultiEdad> MultiEdad { get; set; }
        public virtual ICollection<Sesion> Sesion { get; set; }
        public virtual ICollection<SessionItem> SessionItem { get; set; }
        public virtual ICollection<SetupTorneo> SetupTorneo { get; set; }
    }
}
