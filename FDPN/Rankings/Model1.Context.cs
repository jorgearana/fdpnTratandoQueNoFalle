﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DB_9B1F4C_comentariosEntities : DbContext
    {
        public DB_9B1F4C_comentariosEntities()
            : base("name=DB_9B1F4C_comentariosEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Afiliacion> Afiliacion { get; set; }
        public virtual DbSet<Afiliado> Afiliado { get; set; }
        public virtual DbSet<Alertas> Alertas { get; set; }
        public virtual DbSet<Antiguo> Antiguo { get; set; }
        public virtual DbSet<Apagado> Apagado { get; set; }
        public virtual DbSet<Asociaciones> Asociaciones { get; set; }
        public virtual DbSet<ATFDeportista> ATFDeportista { get; set; }
        public virtual DbSet<ATFExpediente> ATFExpediente { get; set; }
        public virtual DbSet<Athlete> Athlete { get; set; }
        public virtual DbSet<AthleteMasters> AthleteMasters { get; set; }
        public virtual DbSet<atletas> atletas { get; set; }
        public virtual DbSet<Banners> Banners { get; set; }
        public virtual DbSet<BASETIMES> BASETIMES { get; set; }
        public virtual DbSet<Calendario> Calendario { get; set; }
        public virtual DbSet<CalendarioCursos> CalendarioCursos { get; set; }
        public virtual DbSet<CambiosDNI> CambiosDNI { get; set; }
        public virtual DbSet<CategoriaNoticia> CategoriaNoticia { get; set; }
        public virtual DbSet<Categorias> Categorias { get; set; }
        public virtual DbSet<CategoriasMasters> CategoriasMasters { get; set; }
        public virtual DbSet<Club> Club { get; set; }
        public virtual DbSet<Comentario> Comentario { get; set; }
        public virtual DbSet<Comentarios> Comentarios { get; set; }
        public virtual DbSet<ConFechas> ConFechas { get; set; }
        public virtual DbSet<Configuracion> Configuracion { get; set; }
        public virtual DbSet<Contactos> Contactos { get; set; }
        public virtual DbSet<Curso> Curso { get; set; }
        public virtual DbSet<CursoInscripcion> CursoInscripcion { get; set; }
        public virtual DbSet<CursoParticipante> CursoParticipante { get; set; }
        public virtual DbSet<Delegados> Delegados { get; set; }
        public virtual DbSet<Directivos> Directivos { get; set; }
        public virtual DbSet<Disciplina> Disciplina { get; set; }
        public virtual DbSet<Empresa> Empresa { get; set; }
        public virtual DbSet<Entradas> Entradas { get; set; }
        public virtual DbSet<Entrenadores> Entrenadores { get; set; }
        public virtual DbSet<EntrenadorInscrito> EntrenadorInscrito { get; set; }
        public virtual DbSet<Equipos> Equipos { get; set; }
        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<Estilos> Estilos { get; set; }
        public virtual DbSet<Eventos> Eventos { get; set; }
        public virtual DbSet<Fotos> Fotos { get; set; }
        public virtual DbSet<HistorialdeAfiliaciones> HistorialdeAfiliaciones { get; set; }
        public virtual DbSet<HistorialEntrenador> HistorialEntrenador { get; set; }
        public virtual DbSet<HistorialTraspasos> HistorialTraspasos { get; set; }
        public virtual DbSet<Inscripciones> Inscripciones { get; set; }
        public virtual DbSet<InscripcionResponsable> InscripcionResponsable { get; set; }
        public virtual DbSet<Landing> Landing { get; set; }
        public virtual DbSet<MarcasMinimas> MarcasMinimas { get; set; }
        public virtual DbSet<Meet> Meet { get; set; }
        public virtual DbSet<MeetMasters> MeetMasters { get; set; }
        public virtual DbSet<Modals> Modals { get; set; }
        public virtual DbSet<Multas> Multas { get; set; }
        public virtual DbSet<MultiEdad> MultiEdad { get; set; }
        public virtual DbSet<Noticias> Noticias { get; set; }
        public virtual DbSet<OtroAtleta> OtroAtleta { get; set; }
        public virtual DbSet<OtroCategorias> OtroCategorias { get; set; }
        public virtual DbSet<OtroEntradas> OtroEntradas { get; set; }
        public virtual DbSet<OtroEquipo> OtroEquipo { get; set; }
        public virtual DbSet<OtroEventos> OtroEventos { get; set; }
        public virtual DbSet<OtroGrupal> OtroGrupal { get; set; }
        public virtual DbSet<OtroResponsable> OtroResponsable { get; set; }
        public virtual DbSet<OtroSetupTorneo> OtroSetupTorneo { get; set; }
        public virtual DbSet<OtroTorneo> OtroTorneo { get; set; }
        public virtual DbSet<Piscinas> Piscinas { get; set; }
        public virtual DbSet<PoloEquipos> PoloEquipos { get; set; }
        public virtual DbSet<PoloFechas> PoloFechas { get; set; }
        public virtual DbSet<PoloGoleadores> PoloGoleadores { get; set; }
        public virtual DbSet<PoloGrupos> PoloGrupos { get; set; }
        public virtual DbSet<PoloJugadores> PoloJugadores { get; set; }
        public virtual DbSet<PoloPartidos> PoloPartidos { get; set; }
        public virtual DbSet<PoloPosicion> PoloPosicion { get; set; }
        public virtual DbSet<PoloPosicionFinal> PoloPosicionFinal { get; set; }
        public virtual DbSet<PoloResultados> PoloResultados { get; set; }
        public virtual DbSet<PoloRondas> PoloRondas { get; set; }
        public virtual DbSet<PoloSetupTorneo> PoloSetupTorneo { get; set; }
        public virtual DbSet<PoloTorneo> PoloTorneo { get; set; }
        public virtual DbSet<Procesado> Procesado { get; set; }
        public virtual DbSet<Pruebas> Pruebas { get; set; }
        public virtual DbSet<Records> Records { get; set; }
        public virtual DbSet<RecordsActuales> RecordsActuales { get; set; }
        public virtual DbSet<RecordsEdades> RecordsEdades { get; set; }
        public virtual DbSet<RecordsPruebas> RecordsPruebas { get; set; }
        public virtual DbSet<RecordTipo> RecordTipo { get; set; }
        public virtual DbSet<RESULTS> RESULTS { get; set; }
        public virtual DbSet<RESULTSMasters> RESULTSMasters { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<Saltos> Saltos { get; set; }
        public virtual DbSet<Sesion> Sesion { get; set; }
        public virtual DbSet<SessionItem> SessionItem { get; set; }
        public virtual DbSet<SetupTorneo> SetupTorneo { get; set; }
        public virtual DbSet<Suscritos> Suscritos { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TagNames> TagNames { get; set; }
        public virtual DbSet<TatoInformeAsistencias> TatoInformeAsistencias { get; set; }
        public virtual DbSet<TatoInformeEntrenador> TatoInformeEntrenador { get; set; }
        public virtual DbSet<TatoRealizacion> TatoRealizacion { get; set; }
        public virtual DbSet<TatoSeleccionado> TatoSeleccionado { get; set; }
        public virtual DbSet<TatoSeriesEjemplo> TatoSeriesEjemplo { get; set; }
        public virtual DbSet<tb_Suscritos> tb_Suscritos { get; set; }
        public virtual DbSet<Team> Team { get; set; }
        public virtual DbSet<TeamMasters> TeamMasters { get; set; }
        public virtual DbSet<TipoAfiliado> TipoAfiliado { get; set; }
        public virtual DbSet<TipoTorneo> TipoTorneo { get; set; }
        public virtual DbSet<Torneo> Torneo { get; set; }
        public virtual DbSet<TorneoDestacado> TorneoDestacado { get; set; }
        public virtual DbSet<TorneoDestacadoMasters> TorneoDestacadoMasters { get; set; }
        public virtual DbSet<Traspasos> Traspasos { get; set; }
        public virtual DbSet<TraspasosEnEspera> TraspasosEnEspera { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Vivo> Vivo { get; set; }
        public virtual DbSet<Vouchers> Vouchers { get; set; }
        public virtual DbSet<Query> Query { get; set; }
        public virtual DbSet<Sheet1_> Sheet1_ { get; set; }
    }
}
