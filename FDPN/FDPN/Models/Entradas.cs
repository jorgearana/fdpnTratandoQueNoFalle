//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FDPN.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Entradas
    {
        public Nullable<int> Event_ptr { get; set; }
        public Nullable<int> Ath_no { get; set; }
        public string ActSeed_course { get; set; }
        public Nullable<float> ActualSeed_time { get; set; }
        public string ConvSeed_course { get; set; }
        public Nullable<float> ConvSeed_time { get; set; }
        public bool Scr_stat { get; set; }
        public string Spec_stat { get; set; }
        public string Dec_stat { get; set; }
        public bool Alt_stat { get; set; }
        public Nullable<bool> Bonus_event { get; set; }
        public Nullable<int> Div_no { get; set; }
        public Nullable<float> Ev_score { get; set; }
        public Nullable<float> JDEv_score { get; set; }
        public Nullable<short> Seed_place { get; set; }
        public Nullable<short> event_age { get; set; }
        public Nullable<short> Pre_heat { get; set; }
        public Nullable<short> Pre_lane { get; set; }
        public string Pre_stat { get; set; }
        public Nullable<float> Pre_Time { get; set; }
        public string Pre_course { get; set; }
        public Nullable<short> Pre_heatplace { get; set; }
        public Nullable<short> Pre_place { get; set; }
        public Nullable<short> Pre_jdplace { get; set; }
        public string Pre_exh { get; set; }
        public Nullable<short> Pre_points { get; set; }
        public Nullable<float> Pre_back1 { get; set; }
        public Nullable<float> Pre_back2 { get; set; }
        public Nullable<float> Pre_back3 { get; set; }
        public Nullable<float> Pre_watch1 { get; set; }
        public Nullable<float> Pre_pad { get; set; }
        public string Pre_reactiontime1 { get; set; }
        public string Pre_dqcode { get; set; }
        public string Pre_dqcodeSecond { get; set; }
        public string Pre_TimeType { get; set; }
        public Nullable<short> Fin_heat { get; set; }
        public Nullable<short> Fin_lane { get; set; }
        public string Fin_stat { get; set; }
        public Nullable<float> Fin_Time { get; set; }
        public string Fin_course { get; set; }
        public Nullable<short> Fin_heatplace { get; set; }
        public Nullable<short> Fin_jdheatplace { get; set; }
        public Nullable<short> Fin_place { get; set; }
        public Nullable<short> Fin_jdplace { get; set; }
        public string Fin_exh { get; set; }
        public Nullable<short> Fin_points { get; set; }
        public Nullable<float> Fin_back1 { get; set; }
        public Nullable<float> Fin_back2 { get; set; }
        public Nullable<float> Fin_back3 { get; set; }
        public Nullable<float> Fin_watch1 { get; set; }
        public Nullable<float> Fin_pad { get; set; }
        public string Fin_reactiontime1 { get; set; }
        public string Fin_dqcode { get; set; }
        public string Fin_dqcodeSecond { get; set; }
        public Nullable<short> Fin_ptsplace { get; set; }
        public string fin_heatltr { get; set; }
        public string fin_TimeType { get; set; }
        public Nullable<short> Sem_heat { get; set; }
        public Nullable<short> Sem_lane { get; set; }
        public string Sem_stat { get; set; }
        public Nullable<float> Sem_Time { get; set; }
        public string Sem_course { get; set; }
        public Nullable<short> Sem_heatplace { get; set; }
        public Nullable<short> Sem_place { get; set; }
        public Nullable<short> Sem_jdplace { get; set; }
        public string Sem_exh { get; set; }
        public Nullable<short> Sem_points { get; set; }
        public Nullable<float> Sem_back1 { get; set; }
        public Nullable<float> Sem_back2 { get; set; }
        public Nullable<float> Sem_back3 { get; set; }
        public Nullable<float> Sem_watch1 { get; set; }
        public Nullable<float> Sem_pad { get; set; }
        public string Sem_reactiontime1 { get; set; }
        public string Sem_dqcode { get; set; }
        public string Sem_dqcodeSecond { get; set; }
        public string Sem_TimeType { get; set; }
        public string dq_type { get; set; }
        public Nullable<short> Fin_group { get; set; }
        public Nullable<float> Fin_dolphin1 { get; set; }
        public Nullable<float> Fin_dolphin2 { get; set; }
        public Nullable<float> Fin_dolphin3 { get; set; }
        public Nullable<float> Pre_dolphin1 { get; set; }
        public Nullable<float> Pre_dolphin2 { get; set; }
        public Nullable<float> Pre_dolphin3 { get; set; }
        public Nullable<float> Sem_dolphin1 { get; set; }
        public Nullable<float> Sem_dolphin2 { get; set; }
        public Nullable<float> Sem_dolphin3 { get; set; }
        public bool early_seed { get; set; }
        public bool super_prefinalist { get; set; }
        public bool super_finfinalist { get; set; }
        public string fin_adjuststat { get; set; }
        public string pre_adjuststat { get; set; }
        public string sem_adjuststat { get; set; }
        public string fin_divingdd { get; set; }
        public string pre_divingdd { get; set; }
        public string sem_divingdd { get; set; }
        public string entry_method { get; set; }
        public Nullable<int> fin_dqofficial { get; set; }
        public Nullable<int> pre_dqofficial { get; set; }
        public Nullable<int> sem_dqofficial { get; set; }
        public bool pre_contacted { get; set; }
        public int EntryId { get; set; }
        public int MeetId { get; set; }
        public int AtletaId { get; set; }
        public int EventId { get; set; }
    
        public virtual Atletas Atletas { get; set; }
        public virtual Eventos Eventos { get; set; }
    }
}
