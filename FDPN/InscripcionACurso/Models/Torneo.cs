//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InscripcionACurso.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Torneo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Torneo()
        {
            this.atletas = new HashSet<atletas>();
            this.Delegados = new HashSet<Delegados>();
            this.Entradas = new HashSet<Entradas>();
            this.EntrenadorInscrito = new HashSet<EntrenadorInscrito>();
            this.Equipos = new HashSet<Equipos>();
            this.Eventos = new HashSet<Eventos>();
            this.MarcasMinimas = new HashSet<MarcasMinimas>();
            this.MultiEdad = new HashSet<MultiEdad>();
            this.Sesion = new HashSet<Sesion>();
            this.SessionItem = new HashSet<SessionItem>();
            this.SetupTorneo = new HashSet<SetupTorneo>();
        }
    
        public string Meet_name1 { get; set; }
        public string Meet_header1 { get; set; }
        public string Meet_header2 { get; set; }
        public string Meet_location { get; set; }
        public Nullable<System.DateTime> Meet_start { get; set; }
        public Nullable<System.DateTime> Meet_end { get; set; }
        public Nullable<short> Meet_idformat { get; set; }
        public Nullable<short> Meet_class { get; set; }
        public Nullable<short> Meet_Meettype { get; set; }
        public Nullable<short> Meet_course { get; set; }
        public bool Enter_ages { get; set; }
        public bool Enter_birthdate { get; set; }
        public Nullable<System.DateTime> Calc_date { get; set; }
        public bool Enter_schoolyr { get; set; }
        public bool A_Relaysonly { get; set; }
        public bool Use_hometown { get; set; }
        public bool Show_countrycode { get; set; }
        public bool Scores_afterevt { get; set; }
        public bool Lastname_first { get; set; }
        public bool Punct_names { get; set; }
        public bool Punct_Teams { get; set; }
        public bool win_mm { get; set; }
        public Nullable<short> Meet_numlanes { get; set; }
        public Nullable<short> prelimheats_circle { get; set; }
        public bool timedfinal_circleseed { get; set; }
        public bool foreign_infinal { get; set; }
        public bool exh_infinal { get; set; }
        public bool nonconform_last { get; set; }
        public string course_order { get; set; }
        public bool seed_exhlast { get; set; }
        public bool dual_evenodd { get; set; }
        public bool strict_evenodd { get; set; }
        public Nullable<int> Team_evenlanes { get; set; }
        public Nullable<int> Team_oddlanes { get; set; }
        public bool masters_bytimeonly { get; set; }
        public Nullable<short> masters_agegrpsskip { get; set; }
        public Nullable<short> timer_port { get; set; }
        public Nullable<short> scbd_port { get; set; }
        public string timer_vendor { get; set; }
        public string scbd_vendor { get; set; }
        public bool show_initial { get; set; }
        public bool ucase_names { get; set; }
        public bool ucase_Teams { get; set; }
        public string open_senior_none { get; set; }
        public bool entryqual_faster { get; set; }
        public Nullable<decimal> Facility_Surcharge { get; set; }
        public bool anyone_onrelay { get; set; }
        public string language_choice { get; set; }
        public bool military_time { get; set; }
        public bool check_times { get; set; }
        public bool enterkey_astab { get; set; }
        public bool double_endedsplits { get; set; }
        public bool use_compnumbers { get; set; }
        public Nullable<short> flighted_minentries { get; set; }
        public bool diffpts_malefemale { get; set; }
        public bool diffpts_eachdivision { get; set; }
        public bool scoreonly_ifexceedqualtime { get; set; }
        public bool score_fastestheatonly { get; set; }
        public bool entrylimits_warn { get; set; }
        public bool pointsbasedon_seedtime { get; set; }
        public bool pointsfor_overachievers { get; set; }
        public bool pointsfor_underachievers { get; set; }
        public Nullable<short> indmaxscorers_perTeam { get; set; }
        public Nullable<short> relmaxscorers_perTeam { get; set; }
        public Nullable<short> indtopmany_awards { get; set; }
        public Nullable<short> reltopmany_awards { get; set; }
        public Nullable<short> entrymax_total { get; set; }
        public Nullable<short> indmax_perath { get; set; }
        public Nullable<short> relmax_perath { get; set; }
        public bool foreign_getTeampoints { get; set; }
        public bool include_swimupsinTeamscore { get; set; }
        public bool enter_citizenof { get; set; }
        public Nullable<short> Meet_Meetstyle { get; set; }
        public bool flag_overachievers { get; set; }
        public bool flag_underachievers { get; set; }
        public Nullable<short> scbd_punctuation { get; set; }
        public Nullable<short> scbd_names { get; set; }
        public Nullable<short> scbd_relaynames { get; set; }
        public bool scbd_cycle { get; set; }
        public Nullable<short> scbd_cycleseconds { get; set; }
        public Nullable<short> copies_toprinter { get; set; }
        public bool report_headersonly { get; set; }
        public bool autoinc_compno { get; set; }
        public bool pentscoring_usedqtime { get; set; }
        public Nullable<decimal> swimmer_surcharge { get; set; }
        public bool directly_toprinter { get; set; }
        public bool lastname_asinitial { get; set; }
        public bool under_eventname { get; set; }
        public bool suppress_Arelay { get; set; }
        public bool Punct_recholders { get; set; }
        public bool ucase_recholders { get; set; }
        public bool suppress_lsc { get; set; }
        public bool showathlete_status { get; set; }
        public Nullable<short> open_lowage { get; set; }
        public bool useeventsex_Teamscore { get; set; }
        public bool suppress_smallx { get; set; }
        public bool score_Arelayonly { get; set; }
        public bool thirteenandover_assenior { get; set; }
        public bool suppress_jd { get; set; }
        public string abcfinal_order { get; set; }
        public Nullable<short> maxagefor_cfinal { get; set; }
        public string Sanction_number { get; set; }
        public bool include_sanction { get; set; }
        public Nullable<short> special_points { get; set; }
        public bool countrelay_alt { get; set; }
        public bool UseNonConforming_PoolFactor { get; set; }
        public Nullable<float> NonConforming_PoolFactor { get; set; }
        public string apnews_Team { get; set; }
        public Nullable<float> PointsAwarded_ForDQ { get; set; }
        public Nullable<float> PointsAwarded_ForScratch { get; set; }
        public Nullable<float> PointsAwarded_ForNT { get; set; }
        public bool Enter_AthStat { get; set; }
        public bool Show_secondclub { get; set; }
        public bool firstinitial_fulllastname { get; set; }
        public bool turnon_autobackup { get; set; }
        public Nullable<short> autobackup_interval { get; set; }
        public bool PointsAwarded_ForExh { get; set; }
        public bool Use_AltTeamAbbr { get; set; }
        public bool IsCanadian_Masters { get; set; }
        public string entry_msg { get; set; }
        public bool timedfinalnonconform_last { get; set; }
        public string referee_name { get; set; }
        public string referee_homphone { get; set; }
        public string referee_offphone { get; set; }
        public Nullable<int> Meet_altitude { get; set; }
        public string Import_Dir { get; set; }
        public string Export_Dir { get; set; }
        public string Backup_Dir { get; set; }
        public string RestoreFrom_Dir { get; set; }
        public string RestoreTo_Dir { get; set; }
        public string FlatHtml_Dir { get; set; }
        public string APNews_Dir { get; set; }
        public bool AllowSameEvent_DupRelayNames { get; set; }
        public Nullable<int> dualTeam_lane1 { get; set; }
        public Nullable<int> dualTeam_lane2 { get; set; }
        public Nullable<int> dualTeam_lane3 { get; set; }
        public Nullable<int> dualTeam_lane4 { get; set; }
        public Nullable<int> dualTeam_lane5 { get; set; }
        public Nullable<int> dualTeam_lane6 { get; set; }
        public Nullable<int> dualTeam_lane7 { get; set; }
        public Nullable<int> dualTeam_lane8 { get; set; }
        public Nullable<int> dualTeam_lane9 { get; set; }
        public Nullable<int> dualTeam_lane10 { get; set; }
        public bool strict_evenoddfastestheatonly { get; set; }
        public bool dualseeding_altunusedlane { get; set; }
        public Nullable<decimal> Team_surcharge { get; set; }
        public bool Display_ActualEntryTime { get; set; }
        public Nullable<short> indmaxadvance_perTeam { get; set; }
        public Nullable<short> relmaxadvance_perTeam { get; set; }
        public bool RelayNames_LinkByLSC { get; set; }
        public bool Read_Only { get; set; }
        public bool Flighted_BasedOnResultsTime { get; set; }
        public bool ShowYear_InPlaceOfAge { get; set; }
        public Nullable<float> PenaltyPts_ForNS { get; set; }
        public Nullable<System.DateTime> EntryEligibility_date { get; set; }
        public bool Suppress_TimeStdAbbr { get; set; }
        public Nullable<short> masters_indlowage { get; set; }
        public Nullable<short> masters_rellowage { get; set; }
        public bool Custom_QualTimes { get; set; }
        public bool Suppress_SplitsForDQs { get; set; }
        public bool Suppress_SplitsForDQsRelay { get; set; }
        public string DQCodes_Type { get; set; }
        public bool SuppressTimes_NotMeetQualTime { get; set; }
        public bool Show_AgeandBirthYear { get; set; }
        public string Meet_state { get; set; }
        public string Meet_country { get; set; }
        public string Meet_lsc { get; set; }
        public bool BCSSA_DivbyTimeStd { get; set; }
        public bool Show_HyTekDecimals { get; set; }
        public bool Suppress_ResultsAdvQ { get; set; }
        public bool RelaysAs_4x100Style { get; set; }
        public Nullable<short> flighted_flightcount { get; set; }
        public bool flighted_inclDQ { get; set; }
        public bool RelaysAlternate_TwoFastestFirst { get; set; }
        public Nullable<int> dualTeam_lane11 { get; set; }
        public Nullable<int> dualTeam_lane12 { get; set; }
        public Nullable<System.DateTime> entry_deadline { get; set; }
        public string Meet_addr1 { get; set; }
        public string Meet_addr2 { get; set; }
        public string Meet_city { get; set; }
        public string Meet_zip { get; set; }
        public string Meet_hostlsc { get; set; }
        public string Meet_USMastersMeetID { get; set; }
        public bool ShowFirstName_OverPreferred { get; set; }
        public bool ExcludeNTEntries_WhenImporting { get; set; }
        public bool Enter_birthcentury { get; set; }
        public bool Using_twopools { get; set; }
        public string Pool1_name { get; set; }
        public string Pool2_name { get; set; }
        public Nullable<short> indtopmany_awardsSr { get; set; }
        public Nullable<short> reltopmany_awardsSr { get; set; }
        public Nullable<short> maxforeign_infinal { get; set; }
        public bool Flag_FastestRecordOnly { get; set; }
        public Nullable<decimal> athlete_earlysurcharge { get; set; }
        public Nullable<decimal> athlete_latesurcharge { get; set; }
        public Nullable<System.DateTime> athlete_earlysurchargedate { get; set; }
        public Nullable<System.DateTime> athlete_latesurchargedate { get; set; }
        public Nullable<System.DateTime> entry_OpenDate { get; set; }
        public bool DisplayNTfor_TimesUnder5Sec { get; set; }
        public bool SortTeamCombos_ByTeamName { get; set; }
        public bool FastestHeat_SomeLanesDoNotScore { get; set; }
        public bool RankDisabled_ByPoints { get; set; }
        public Nullable<short> special_parapoints { get; set; }
        public bool DisabledDoNot_AdvanceToFinals { get; set; }
        public Nullable<short> prelimheats_circledist { get; set; }
        public bool DisabledIgnoreQualTime_ForScoring { get; set; }
        public bool CountTimeTrial_Events { get; set; }
        public bool QualNonConformCourse_UseMinStd { get; set; }
        public string Last_updated { get; set; }
        public bool MixedRelays_DividedPoints { get; set; }
        public Nullable<decimal> RelayOnly_Surcharge { get; set; }
        public string TimeAdj_Method { get; set; }
        public bool DisabledSeedWithAgeGroup_IfTimedFinalSuperSeed { get; set; }
        public int Meetid { get; set; }
        public bool MarcaMaxima { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<atletas> atletas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Delegados> Delegados { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Entradas> Entradas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EntrenadorInscrito> EntrenadorInscrito { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Equipos> Equipos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Eventos> Eventos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MarcasMinimas> MarcasMinimas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MultiEdad> MultiEdad { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sesion> Sesion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SessionItem> SessionItem { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SetupTorneo> SetupTorneo { get; set; }
    }
}
