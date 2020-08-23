using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NuevaInscripcionATorneos.Models
{
    public partial class DB_9B1F4C_comentariosContext : DbContext
    {
        public DB_9B1F4C_comentariosContext()
        {
        }

        public DB_9B1F4C_comentariosContext(DbContextOptions<DB_9B1F4C_comentariosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Afiliacion> Afiliacion { get; set; }
        public virtual DbSet<Afiliado> Afiliado { get; set; }
        public virtual DbSet<Alertas> Alertas { get; set; }
        public virtual DbSet<Antiguo> Antiguo { get; set; }
        public virtual DbSet<Apagado> Apagado { get; set; }
        public virtual DbSet<Asociaciones> Asociaciones { get; set; }
        public virtual DbSet<Atfdeportista> Atfdeportista { get; set; }
        public virtual DbSet<Atfexpediente> Atfexpediente { get; set; }
        public virtual DbSet<Athlete> Athlete { get; set; }
        public virtual DbSet<AthleteMasters> AthleteMasters { get; set; }
        public virtual DbSet<Atletas> Atletas { get; set; }
        public virtual DbSet<Banners> Banners { get; set; }
        public virtual DbSet<Basetimes> Basetimes { get; set; }
        public virtual DbSet<Calendario> Calendario { get; set; }
        public virtual DbSet<CambiosDni> CambiosDni { get; set; }
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
        public virtual DbSet<EntrenadorInscrito> EntrenadorInscrito { get; set; }
        public virtual DbSet<Entrenadores> Entrenadores { get; set; }
        public virtual DbSet<Equipos> Equipos { get; set; }
        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<Estilos> Estilos { get; set; }
        public virtual DbSet<Eventos> Eventos { get; set; }
        public virtual DbSet<Fotos> Fotos { get; set; }
        public virtual DbSet<HistorialEntrenador> HistorialEntrenador { get; set; }
        public virtual DbSet<HistorialTraspasos> HistorialTraspasos { get; set; }
        public virtual DbSet<HistorialdeAfiliaciones> HistorialdeAfiliaciones { get; set; }
        public virtual DbSet<Hoja2> Hoja2 { get; set; }
        public virtual DbSet<InscripcionResponsable> InscripcionResponsable { get; set; }
        public virtual DbSet<Inscripciones> Inscripciones { get; set; }
        public virtual DbSet<Landing> Landing { get; set; }
        public virtual DbSet<MarcasMinimas> MarcasMinimas { get; set; }
        public virtual DbSet<Meet> Meet { get; set; }
        public virtual DbSet<Meetmasters> Meetmasters { get; set; }
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
        public virtual DbSet<Query> Query { get; set; }
        public virtual DbSet<RecordTipo> RecordTipo { get; set; }
        public virtual DbSet<Records> Records { get; set; }
        public virtual DbSet<RecordsActuales> RecordsActuales { get; set; }
        public virtual DbSet<RecordsEdades> RecordsEdades { get; set; }
        public virtual DbSet<RecordsPruebas> RecordsPruebas { get; set; }
        public virtual DbSet<Results> Results { get; set; }
        public virtual DbSet<Resultsmasters> Resultsmasters { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<Saltos> Saltos { get; set; }
        public virtual DbSet<Sesion> Sesion { get; set; }
        public virtual DbSet<SessionItem> SessionItem { get; set; }
        public virtual DbSet<SetupTorneo> SetupTorneo { get; set; }
        public virtual DbSet<Sheet1> Sheet1 { get; set; }
        public virtual DbSet<Suscritos> Suscritos { get; set; }
        public virtual DbSet<TagNames> TagNames { get; set; }
        public virtual DbSet<TatoInformeAsistencias> TatoInformeAsistencias { get; set; }
        public virtual DbSet<TatoInformeEntrenador> TatoInformeEntrenador { get; set; }
        public virtual DbSet<TatoRealizacion> TatoRealizacion { get; set; }
        public virtual DbSet<TatoSeleccionado> TatoSeleccionado { get; set; }
        public virtual DbSet<TatoSeriesEjemplo> TatoSeriesEjemplo { get; set; }
        public virtual DbSet<TbSuscritos> TbSuscritos { get; set; }
        public virtual DbSet<Team> Team { get; set; }
        public virtual DbSet<Teammasters> Teammasters { get; set; }
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=sql5014.site4now.net;Persist Security Info=True;User ID=DB_9B1F4C_comentarios_admin;Password= jujituss");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Afiliacion>(entity =>
            {
                entity.Property(e => e.AfiliacionId).HasColumnName("AfiliacionID");

                entity.Property(e => e.FechaAfiliacion).HasColumnType("date");

                entity.HasOne(d => d.Club)
                    .WithMany(p => p.Afiliacion)
                    .HasForeignKey(d => d.ClubId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Afiliacion_Club");

                entity.HasOne(d => d.Inscripcion)
                    .WithMany(p => p.Afiliacion)
                    .HasForeignKey(d => d.InscripcionId)
                    .HasConstraintName("FK_Afiliacion_Inscripciones");

                entity.HasOne(d => d.Procesado)
                    .WithMany(p => p.Afiliacion)
                    .HasForeignKey(d => d.ProcesadoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Afiliacion_Procesado");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Afiliacion)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Afiliacion_Usuario");

                entity.HasOne(d => d.Voucher)
                    .WithMany(p => p.Afiliacion)
                    .HasForeignKey(d => d.VoucherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Afiliacion_Vouchers");
            });

            modelBuilder.Entity<Afiliado>(entity =>
            {
                entity.HasKey(e => e.Dni);

                entity.Property(e => e.Dni)
                    .HasColumnName("DNI")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ApellidoMaterno)
                    .HasColumnName("Apellido Materno")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ApellidoPaterno)
                    .IsRequired()
                    .HasColumnName("Apellido Paterno")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DeportistaId).ValueGeneratedOnAdd();

                entity.Property(e => e.FechaDeNacimiento)
                    .HasColumnName("Fecha de nacimiento")
                    .HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sexo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TipoDeDocumento)
                    .IsRequired()
                    .HasColumnName("Tipo de documento")
                    .HasMaxLength(5)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Alertas>(entity =>
            {
                entity.HasKey(e => e.AlertaId);

                entity.Property(e => e.Alerta)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.HasOne(d => d.Noticia)
                    .WithMany(p => p.Alertas)
                    .HasForeignKey(d => d.NoticiaId)
                    .HasConstraintName("FK_Alertas_Noticias");
            });

            modelBuilder.Entity<Antiguo>(entity =>
            {
                entity.Property(e => e.AntiguoId).ValueGeneratedNever();

                entity.Property(e => e.Detalle)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Apagado>(entity =>
            {
                entity.HasKey(e => e.ConfiguraId);

                entity.Property(e => e.Apagado1).HasColumnName("Apagado");
            });

            modelBuilder.Entity<Asociaciones>(entity =>
            {
                entity.HasKey(e => e.AsociacionId);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Atfdeportista>(entity =>
            {
                entity.HasKey(e => e.DeportistaId);

                entity.ToTable("ATFDeportista");

                entity.Property(e => e.CopiaDni).HasColumnName("CopiaDNI");

                entity.Property(e => e.CopiaDniapoderado).HasColumnName("CopiaDNIApoderado");

                entity.HasOne(d => d.Expediente)
                    .WithMany(p => p.Atfdeportista)
                    .HasForeignKey(d => d.Expedienteid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ATFDeportista_ATFExpediente");
            });

            modelBuilder.Entity<Atfexpediente>(entity =>
            {
                entity.HasKey(e => e.ExpedienteId);

                entity.ToTable("ATFExpediente");

                entity.Property(e => e.ExpedienteId).ValueGeneratedNever();

                entity.HasOne(d => d.Evento)
                    .WithMany(p => p.Atfexpediente)
                    .HasForeignKey(d => d.EventoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ATFExpediente_Calendario");
            });

            modelBuilder.Entity<Athlete>(entity =>
            {
                entity.Property(e => e.Athlete1).HasColumnName("Athlete");

                entity.Property(e => e.Birth).HasColumnType("smalldatetime");

                entity.Property(e => e.First)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.IdNo)
                    .IsRequired()
                    .HasColumnName("ID_NO")
                    .HasMaxLength(17);

                entity.Property(e => e.Last)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Sex)
                    .IsRequired()
                    .HasMaxLength(1);
            });

            modelBuilder.Entity<AthleteMasters>(entity =>
            {
                entity.HasKey(e => e.AthleteId);

                entity.Property(e => e.Birth).HasColumnType("smalldatetime");

                entity.Property(e => e.First)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.IdNo)
                    .IsRequired()
                    .HasColumnName("ID_NO")
                    .HasMaxLength(17);

                entity.Property(e => e.Last)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Sex)
                    .IsRequired()
                    .HasMaxLength(1);
            });

            modelBuilder.Entity<Atletas>(entity =>
            {
                entity.HasKey(e => e.AtletaId);

                entity.ToTable("atletas");

                entity.Property(e => e.AthAge).HasColumnName("Ath_age");

                entity.Property(e => e.AthNo).HasColumnName("Ath_no");

                entity.Property(e => e.AthSex)
                    .HasColumnName("Ath_Sex")
                    .HasMaxLength(1);

                entity.Property(e => e.AthStat)
                    .HasColumnName("Ath_stat")
                    .HasMaxLength(1);

                entity.Property(e => e.BcssaType)
                    .HasColumnName("bcssa_type")
                    .HasMaxLength(2);

                entity.Property(e => e.BirthDate)
                    .HasColumnName("Birth_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.CitizenOf)
                    .HasColumnName("Citizen_of")
                    .HasMaxLength(3);

                entity.Property(e => e.CompNo).HasColumnName("Comp_no");

                entity.Property(e => e.DisabExeptioncodes)
                    .HasColumnName("Disab_Exeptioncodes")
                    .HasMaxLength(14);

                entity.Property(e => e.DisabSbcode).HasColumnName("Disab_SBcode");

                entity.Property(e => e.DisabScode).HasColumnName("Disab_Scode");

                entity.Property(e => e.DisabSdmsid)
                    .HasColumnName("Disab_SDMSID")
                    .HasMaxLength(7);

                entity.Property(e => e.DisabSmcode).HasColumnName("Disab_SMcode");

                entity.Property(e => e.DivNo).HasColumnName("Div_no");

                entity.Property(e => e.FirstName)
                    .HasColumnName("First_name")
                    .HasMaxLength(20);

                entity.Property(e => e.HomeAddr1)
                    .HasColumnName("Home_addr1")
                    .HasMaxLength(30);

                entity.Property(e => e.HomeAddr2)
                    .HasColumnName("Home_addr2")
                    .HasMaxLength(30);

                entity.Property(e => e.HomeCelltele)
                    .HasColumnName("Home_celltele")
                    .HasMaxLength(20);

                entity.Property(e => e.HomeCity)
                    .HasColumnName("Home_city")
                    .HasMaxLength(30);

                entity.Property(e => e.HomeCntry)
                    .HasColumnName("Home_cntry")
                    .HasMaxLength(3);

                entity.Property(e => e.HomeDaytele)
                    .HasColumnName("Home_daytele")
                    .HasMaxLength(20);

                entity.Property(e => e.HomeEmail)
                    .HasColumnName("Home_email")
                    .HasMaxLength(50);

                entity.Property(e => e.HomeEmergcontact)
                    .HasColumnName("Home_emergcontact")
                    .HasMaxLength(30);

                entity.Property(e => e.HomeEmergtele)
                    .HasColumnName("Home_emergtele")
                    .HasMaxLength(20);

                entity.Property(e => e.HomeEvetele)
                    .HasColumnName("Home_evetele")
                    .HasMaxLength(20);

                entity.Property(e => e.HomeFaxtele)
                    .HasColumnName("Home_faxtele")
                    .HasMaxLength(20);

                entity.Property(e => e.HomeProv)
                    .HasColumnName("Home_prov")
                    .HasMaxLength(30);

                entity.Property(e => e.HomeStatenew)
                    .HasColumnName("Home_statenew")
                    .HasMaxLength(3);

                entity.Property(e => e.HomeZip)
                    .HasColumnName("Home_zip")
                    .HasMaxLength(10);

                entity.Property(e => e.Initial).HasMaxLength(1);

                entity.Property(e => e.LastName)
                    .HasColumnName("Last_name")
                    .HasMaxLength(20);

                entity.Property(e => e.MastersRegVerified).HasColumnName("Masters_RegVerified");

                entity.Property(e => e.PictureBmp)
                    .HasColumnName("Picture_bmp")
                    .HasMaxLength(30);

                entity.Property(e => e.PrefName)
                    .HasColumnName("Pref_name")
                    .HasMaxLength(20);

                entity.Property(e => e.RegNo)
                    .HasColumnName("Reg_no")
                    .HasMaxLength(14);

                entity.Property(e => e.SchlYr)
                    .HasColumnName("Schl_yr")
                    .HasMaxLength(2);

                entity.Property(e => e.SecondClub)
                    .HasColumnName("second_club")
                    .HasMaxLength(16);

                entity.Property(e => e.TeamNo).HasColumnName("Team_no");

                entity.HasOne(d => d.Meet)
                    .WithMany(p => p.Atletas)
                    .HasForeignKey(d => d.Meetid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_atletas_Torneo");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.Atletas)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_atletas_Equipos");
            });

            modelBuilder.Entity<Banners>(entity =>
            {
                entity.HasKey(e => e.BannerId);

                entity.Property(e => e.Clase)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Foto)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Basetimes>(entity =>
            {
                entity.HasKey(e => e.TiempoId);

                entity.ToTable("BASETIMES");

                entity.Property(e => e.TiempoId).HasColumnName("tiempoId");

                entity.Property(e => e.Basetime)
                    .HasColumnName("BASETIME")
                    .HasMaxLength(255);

                entity.Property(e => e.Course)
                    .HasColumnName("COURSE")
                    .HasMaxLength(255);

                entity.Property(e => e.Distance).HasColumnName("DISTANCE");

                entity.Property(e => e.Gender)
                    .HasColumnName("GENDER")
                    .HasMaxLength(255);

                entity.Property(e => e.RelayCount).HasColumnName("RELAY- COUNT");

                entity.Property(e => e.Segundos).HasColumnName("SEGUNDOS");

                entity.Property(e => e.Stroke)
                    .HasColumnName("STROKE")
                    .HasMaxLength(255);

                entity.Property(e => e.Year).HasColumnName("YEAR");
            });

            modelBuilder.Entity<Calendario>(entity =>
            {
                entity.HasKey(e => e.EventoId);

                entity.Property(e => e.Carácter).HasMaxLength(255);

                entity.Property(e => e.Evento)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Fin).HasColumnType("datetime");

                entity.Property(e => e.Inicio).HasColumnType("datetime");

                entity.Property(e => e.Observación).HasMaxLength(255);

                entity.Property(e => e.Organizador).HasMaxLength(255);

                entity.Property(e => e.Sede)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.Disciplina)
                    .WithMany(p => p.Calendario)
                    .HasForeignKey(d => d.DisciplinaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Calendario_Disciplina");
            });

            modelBuilder.Entity<CambiosDni>(entity =>
            {
                entity.HasKey(e => e.CambioId);

                entity.ToTable("CambiosDNI");

                entity.Property(e => e.Dni)
                    .IsRequired()
                    .HasColumnName("DNI")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Dniantiguo)
                    .IsRequired()
                    .HasColumnName("DNIAntiguo")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<CategoriaNoticia>(entity =>
            {
                entity.HasKey(e => e.CategoriaId);

                entity.Property(e => e.TipoNoticia)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Categorias>(entity =>
            {
                entity.HasKey(e => e.CategoriaId);

                entity.Property(e => e.EdadMaxima).HasColumnName("Edad maxima");

                entity.Property(e => e.EdadMinima).HasColumnName("Edad minima");

                entity.Property(e => e.NombreCategoria)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CategoriasMasters>(entity =>
            {
                entity.HasKey(e => e.CategoriaId);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Club>(entity =>
            {
                entity.Property(e => e.ClubId).HasColumnName("ClubID");

                entity.Property(e => e.FechaPagoAfiliacion).HasColumnType("date");

                entity.Property(e => e.FinVigenciaPoderes).HasColumnType("date");

                entity.Property(e => e.FinVigenciaRenade).HasColumnType("date");

                entity.Property(e => e.Iniciales)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.NombreClub)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NombreUsuario)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Resolucion).HasMaxLength(100);

                entity.Property(e => e.VoucherPagoAfiliacionAnual).HasMaxLength(50);

                entity.HasOne(d => d.Asociacion)
                    .WithMany(p => p.Club)
                    .HasForeignKey(d => d.AsociacionId)
                    .HasConstraintName("FK_Club_Asociaciones");
            });

            modelBuilder.Entity<Comentario>(entity =>
            {
                entity.Property(e => e.Asunto)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("date");

                entity.Property(e => e.Mensaje)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Comentarios>(entity =>
            {
                entity.HasKey(e => e.ComentarioId);

                entity.Property(e => e.Comentario).IsRequired();

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Fecha).HasColumnType("date");
            });

            modelBuilder.Entity<ConFechas>(entity =>
            {
                entity.HasKey(e => e.CalendarioId);

                entity.Property(e => e.Ciudad)
                    .HasColumnName("CIUDAD")
                    .HasMaxLength(255);

                entity.Property(e => e.Eventos)
                    .HasColumnName("EVENTOS")
                    .HasMaxLength(255);

                entity.Property(e => e.F7).HasMaxLength(255);

                entity.Property(e => e.Final)
                    .HasColumnName("FINAL")
                    .HasColumnType("datetime");

                entity.Property(e => e.Inicio)
                    .HasColumnName("INICIO")
                    .HasColumnType("datetime");

                entity.Property(e => e.Modalidad)
                    .HasColumnName("MODALIDAD")
                    .HasMaxLength(255);

                entity.Property(e => e.Nota).HasMaxLength(255);

                entity.Property(e => e.Organiza).HasMaxLength(255);

                entity.Property(e => e.Pais)
                    .HasColumnName("PAIS")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Configuracion>(entity =>
            {
                entity.HasKey(e => e.SetupId);
            });

            modelBuilder.Entity<Contactos>(entity =>
            {
                entity.Property(e => e.Apmaterno).HasMaxLength(255);

                entity.Property(e => e.Appaterno).HasMaxLength(255);

                entity.Property(e => e.Cargo).HasMaxLength(255);

                entity.Property(e => e.Celular).HasMaxLength(255);

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.Extension).HasMaxLength(255);

                entity.Property(e => e.Nombre).HasMaxLength(255);

                entity.Property(e => e.Telefono).HasMaxLength(255);

                entity.Property(e => e.Ubicacion).HasMaxLength(255);
            });

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.Property(e => e.Ciudad)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Enlace)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Fin).HasColumnType("datetime");

                entity.Property(e => e.Inicio).HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.PassWord)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CursoInscripcion>(entity =>
            {
                entity.HasKey(e => e.InscripcionId);

                entity.HasOne(d => d.Curso)
                    .WithMany(p => p.CursoInscripcion)
                    .HasForeignKey(d => d.CursoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CursoInscripcion_Curso");

                entity.HasOne(d => d.Participante)
                    .WithMany(p => p.CursoInscripcion)
                    .HasForeignKey(d => d.ParticipanteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CursoInscripcion_CursoParticipante");
            });

            modelBuilder.Entity<CursoParticipante>(entity =>
            {
                entity.HasKey(e => e.ParticipanteId);

                entity.Property(e => e.Actividad).IsRequired();

                entity.Property(e => e.Celular)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Dni)
                    .IsRequired()
                    .HasColumnName("DNI")
                    .HasMaxLength(25);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Materno).HasMaxLength(50);

                entity.Property(e => e.Nacimiento).HasColumnType("date");

                entity.Property(e => e.Nacionalidad)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Paterno)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Delegados>(entity =>
            {
                entity.HasKey(e => e.DelegadoId);

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Meet)
                    .WithMany(p => p.Delegados)
                    .HasForeignKey(d => d.MeetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Delegados_Torneo");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Delegados)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Delegados_Usuario");
            });

            modelBuilder.Entity<Directivos>(entity =>
            {
                entity.HasKey(e => e.DirectivoId);

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Cargo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Celular)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FinVigencia).HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Club)
                    .WithMany(p => p.Directivos)
                    .HasForeignKey(d => d.ClubId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Directivos_Club");
            });

            modelBuilder.Entity<Disciplina>(entity =>
            {
                entity.Property(e => e.Clase)
                    .HasColumnName("clase")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TipoDisciplina)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.Property(e => e.Ciudad).HasMaxLength(255);

                entity.Property(e => e.Empresa1)
                    .HasColumnName("Empresa")
                    .HasMaxLength(255);

                entity.Property(e => e.Pais).HasMaxLength(255);

                entity.Property(e => e.Telefono).HasMaxLength(255);

                entity.Property(e => e.Telefono2).HasMaxLength(255);

                entity.Property(e => e.Web).HasMaxLength(255);
            });

            modelBuilder.Entity<Entradas>(entity =>
            {
                entity.HasKey(e => e.EntryId);

                entity.Property(e => e.ActSeedCourse)
                    .HasColumnName("ActSeed_course")
                    .HasMaxLength(1);

                entity.Property(e => e.ActualSeedTime).HasColumnName("ActualSeed_time");

                entity.Property(e => e.AltStat).HasColumnName("Alt_stat");

                entity.Property(e => e.AthNo).HasColumnName("Ath_no");

                entity.Property(e => e.BonusEvent).HasColumnName("Bonus_event");

                entity.Property(e => e.ConvSeedCourse)
                    .HasColumnName("ConvSeed_course")
                    .HasMaxLength(1);

                entity.Property(e => e.ConvSeedTime).HasColumnName("ConvSeed_time");

                entity.Property(e => e.DecStat)
                    .HasColumnName("Dec_stat")
                    .HasMaxLength(1);

                entity.Property(e => e.DivNo).HasColumnName("Div_no");

                entity.Property(e => e.DqType)
                    .HasColumnName("dq_type")
                    .HasMaxLength(1);

                entity.Property(e => e.EarlySeed).HasColumnName("early_seed");

                entity.Property(e => e.EntryMethod)
                    .HasColumnName("entry_method")
                    .HasMaxLength(1);

                entity.Property(e => e.EvScore).HasColumnName("Ev_score");

                entity.Property(e => e.EventAge).HasColumnName("event_age");

                entity.Property(e => e.EventPtr).HasColumnName("Event_ptr");

                entity.Property(e => e.FinAdjuststat)
                    .HasColumnName("fin_adjuststat")
                    .HasMaxLength(1);

                entity.Property(e => e.FinBack1).HasColumnName("Fin_back1");

                entity.Property(e => e.FinBack2).HasColumnName("Fin_back2");

                entity.Property(e => e.FinBack3).HasColumnName("Fin_back3");

                entity.Property(e => e.FinCourse)
                    .HasColumnName("Fin_course")
                    .HasMaxLength(1);

                entity.Property(e => e.FinDivingdd)
                    .HasColumnName("fin_divingdd")
                    .HasMaxLength(4);

                entity.Property(e => e.FinDolphin1).HasColumnName("Fin_dolphin1");

                entity.Property(e => e.FinDolphin2).HasColumnName("Fin_dolphin2");

                entity.Property(e => e.FinDolphin3).HasColumnName("Fin_dolphin3");

                entity.Property(e => e.FinDqcode)
                    .HasColumnName("Fin_dqcode")
                    .HasMaxLength(2);

                entity.Property(e => e.FinDqcodeSecond)
                    .HasColumnName("Fin_dqcodeSecond")
                    .HasMaxLength(2);

                entity.Property(e => e.FinDqofficial).HasColumnName("fin_dqofficial");

                entity.Property(e => e.FinExh)
                    .HasColumnName("Fin_exh")
                    .HasMaxLength(1);

                entity.Property(e => e.FinGroup).HasColumnName("Fin_group");

                entity.Property(e => e.FinHeat).HasColumnName("Fin_heat");

                entity.Property(e => e.FinHeatltr)
                    .HasColumnName("fin_heatltr")
                    .HasMaxLength(1);

                entity.Property(e => e.FinHeatplace).HasColumnName("Fin_heatplace");

                entity.Property(e => e.FinJdheatplace).HasColumnName("Fin_jdheatplace");

                entity.Property(e => e.FinJdplace).HasColumnName("Fin_jdplace");

                entity.Property(e => e.FinLane).HasColumnName("Fin_lane");

                entity.Property(e => e.FinPad).HasColumnName("Fin_pad");

                entity.Property(e => e.FinPlace).HasColumnName("Fin_place");

                entity.Property(e => e.FinPoints).HasColumnName("Fin_points");

                entity.Property(e => e.FinPtsplace).HasColumnName("Fin_ptsplace");

                entity.Property(e => e.FinReactiontime1)
                    .HasColumnName("Fin_reactiontime1")
                    .HasMaxLength(5);

                entity.Property(e => e.FinStat)
                    .HasColumnName("Fin_stat")
                    .HasMaxLength(1);

                entity.Property(e => e.FinTime).HasColumnName("Fin_Time");

                entity.Property(e => e.FinTimeType)
                    .HasColumnName("fin_TimeType")
                    .HasMaxLength(1);

                entity.Property(e => e.FinWatch1).HasColumnName("Fin_watch1");

                entity.Property(e => e.JdevScore).HasColumnName("JDEv_score");

                entity.Property(e => e.PreAdjuststat)
                    .HasColumnName("pre_adjuststat")
                    .HasMaxLength(1);

                entity.Property(e => e.PreBack1).HasColumnName("Pre_back1");

                entity.Property(e => e.PreBack2).HasColumnName("Pre_back2");

                entity.Property(e => e.PreBack3).HasColumnName("Pre_back3");

                entity.Property(e => e.PreContacted).HasColumnName("pre_contacted");

                entity.Property(e => e.PreCourse)
                    .HasColumnName("Pre_course")
                    .HasMaxLength(1);

                entity.Property(e => e.PreDivingdd)
                    .HasColumnName("pre_divingdd")
                    .HasMaxLength(4);

                entity.Property(e => e.PreDolphin1).HasColumnName("Pre_dolphin1");

                entity.Property(e => e.PreDolphin2).HasColumnName("Pre_dolphin2");

                entity.Property(e => e.PreDolphin3).HasColumnName("Pre_dolphin3");

                entity.Property(e => e.PreDqcode)
                    .HasColumnName("Pre_dqcode")
                    .HasMaxLength(2);

                entity.Property(e => e.PreDqcodeSecond)
                    .HasColumnName("Pre_dqcodeSecond")
                    .HasMaxLength(2);

                entity.Property(e => e.PreDqofficial).HasColumnName("pre_dqofficial");

                entity.Property(e => e.PreExh)
                    .HasColumnName("Pre_exh")
                    .HasMaxLength(1);

                entity.Property(e => e.PreHeat).HasColumnName("Pre_heat");

                entity.Property(e => e.PreHeatplace).HasColumnName("Pre_heatplace");

                entity.Property(e => e.PreJdplace).HasColumnName("Pre_jdplace");

                entity.Property(e => e.PreLane).HasColumnName("Pre_lane");

                entity.Property(e => e.PrePad).HasColumnName("Pre_pad");

                entity.Property(e => e.PrePlace).HasColumnName("Pre_place");

                entity.Property(e => e.PrePoints).HasColumnName("Pre_points");

                entity.Property(e => e.PreReactiontime1)
                    .HasColumnName("Pre_reactiontime1")
                    .HasMaxLength(5);

                entity.Property(e => e.PreStat)
                    .HasColumnName("Pre_stat")
                    .HasMaxLength(1);

                entity.Property(e => e.PreTime).HasColumnName("Pre_Time");

                entity.Property(e => e.PreTimeType)
                    .HasColumnName("Pre_TimeType")
                    .HasMaxLength(1);

                entity.Property(e => e.PreWatch1).HasColumnName("Pre_watch1");

                entity.Property(e => e.ScrStat).HasColumnName("Scr_stat");

                entity.Property(e => e.SeedPlace).HasColumnName("Seed_place");

                entity.Property(e => e.SemAdjuststat)
                    .HasColumnName("sem_adjuststat")
                    .HasMaxLength(1);

                entity.Property(e => e.SemBack1).HasColumnName("Sem_back1");

                entity.Property(e => e.SemBack2).HasColumnName("Sem_back2");

                entity.Property(e => e.SemBack3).HasColumnName("Sem_back3");

                entity.Property(e => e.SemCourse)
                    .HasColumnName("Sem_course")
                    .HasMaxLength(1);

                entity.Property(e => e.SemDivingdd)
                    .HasColumnName("sem_divingdd")
                    .HasMaxLength(4);

                entity.Property(e => e.SemDolphin1).HasColumnName("Sem_dolphin1");

                entity.Property(e => e.SemDolphin2).HasColumnName("Sem_dolphin2");

                entity.Property(e => e.SemDolphin3).HasColumnName("Sem_dolphin3");

                entity.Property(e => e.SemDqcode)
                    .HasColumnName("Sem_dqcode")
                    .HasMaxLength(2);

                entity.Property(e => e.SemDqcodeSecond)
                    .HasColumnName("Sem_dqcodeSecond")
                    .HasMaxLength(2);

                entity.Property(e => e.SemDqofficial).HasColumnName("sem_dqofficial");

                entity.Property(e => e.SemExh)
                    .HasColumnName("Sem_exh")
                    .HasMaxLength(1);

                entity.Property(e => e.SemHeat).HasColumnName("Sem_heat");

                entity.Property(e => e.SemHeatplace).HasColumnName("Sem_heatplace");

                entity.Property(e => e.SemJdplace).HasColumnName("Sem_jdplace");

                entity.Property(e => e.SemLane).HasColumnName("Sem_lane");

                entity.Property(e => e.SemPad).HasColumnName("Sem_pad");

                entity.Property(e => e.SemPlace).HasColumnName("Sem_place");

                entity.Property(e => e.SemPoints).HasColumnName("Sem_points");

                entity.Property(e => e.SemReactiontime1)
                    .HasColumnName("Sem_reactiontime1")
                    .HasMaxLength(5);

                entity.Property(e => e.SemStat)
                    .HasColumnName("Sem_stat")
                    .HasMaxLength(1);

                entity.Property(e => e.SemTime).HasColumnName("Sem_Time");

                entity.Property(e => e.SemTimeType)
                    .HasColumnName("Sem_TimeType")
                    .HasMaxLength(1);

                entity.Property(e => e.SemWatch1).HasColumnName("Sem_watch1");

                entity.Property(e => e.SpecStat)
                    .HasColumnName("Spec_stat")
                    .HasMaxLength(1);

                entity.Property(e => e.SuperFinfinalist).HasColumnName("super_finfinalist");

                entity.Property(e => e.SuperPrefinalist).HasColumnName("super_prefinalist");

                entity.HasOne(d => d.Meet)
                    .WithMany(p => p.Entradas)
                    .HasForeignKey(d => d.MeetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Entradas_Torneo");
            });

            modelBuilder.Entity<EntrenadorInscrito>(entity =>
            {
                entity.HasOne(d => d.Entrenador)
                    .WithMany(p => p.EntrenadorInscrito)
                    .HasForeignKey(d => d.EntrenadorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EntrenadorInscrito_Entrenadores");

                entity.HasOne(d => d.Meet)
                    .WithMany(p => p.EntrenadorInscrito)
                    .HasForeignKey(d => d.MeetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EntrenadorInscrito_Torneo");
            });

            modelBuilder.Entity<Entrenadores>(entity =>
            {
                entity.HasKey(e => e.EntrenadorId);

                entity.Property(e => e.Celular1)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Celular2)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Dni)
                    .IsRequired()
                    .HasColumnName("DNI")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Email1)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Email2)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.FechaDeNacimiento)
                    .HasColumnName("Fecha de nacimiento")
                    .HasColumnType("date");

                entity.Property(e => e.Materno)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Paterno)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RutaFoto)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Sexo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Antiguo)
                    .WithMany(p => p.Entrenadores)
                    .HasForeignKey(d => d.AntiguoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Entrenadores_Antiguo");

                entity.HasOne(d => d.Club)
                    .WithMany(p => p.Entrenadores)
                    .HasForeignKey(d => d.Clubid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Entrenadores_Club");

                entity.HasOne(d => d.Estado)
                    .WithMany(p => p.Entrenadores)
                    .HasForeignKey(d => d.EstadoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Entrenadores_Estado");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Entrenadores)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Entrenadores_Usuario");
            });

            modelBuilder.Entity<Equipos>(entity =>
            {
                entity.HasKey(e => e.TeamId);

                entity.Property(e => e.NoAthleteSurcharge).HasColumnName("NoAthlete_surcharge");

                entity.Property(e => e.NoFacilitySurcharge).HasColumnName("NoFacility_surcharge");

                entity.Property(e => e.NoRelayOnlySurcharge).HasColumnName("NoRelayOnly_surcharge");

                entity.Property(e => e.NoTeamSurcharge).HasColumnName("NoTeam_surcharge");

                entity.Property(e => e.TeamAbbr)
                    .HasColumnName("Team_abbr")
                    .HasMaxLength(5);

                entity.Property(e => e.TeamAddr1)
                    .HasColumnName("Team_addr1")
                    .HasMaxLength(30);

                entity.Property(e => e.TeamAddr2)
                    .HasColumnName("Team_addr2")
                    .HasMaxLength(30);

                entity.Property(e => e.TeamAltabbr)
                    .HasColumnName("Team_altabbr")
                    .HasMaxLength(5);

                entity.Property(e => e.TeamAltname)
                    .HasColumnName("Team_altname")
                    .HasMaxLength(16);

                entity.Property(e => e.TeamAsst)
                    .HasColumnName("Team_asst")
                    .HasMaxLength(30);

                entity.Property(e => e.TeamC10)
                    .HasColumnName("Team_c10")
                    .HasMaxLength(30);

                entity.Property(e => e.TeamC3)
                    .HasColumnName("Team_c3")
                    .HasMaxLength(30);

                entity.Property(e => e.TeamC4)
                    .HasColumnName("Team_c4")
                    .HasMaxLength(30);

                entity.Property(e => e.TeamC5)
                    .HasColumnName("Team_c5")
                    .HasMaxLength(30);

                entity.Property(e => e.TeamC6)
                    .HasColumnName("Team_c6")
                    .HasMaxLength(30);

                entity.Property(e => e.TeamC7)
                    .HasColumnName("Team_c7")
                    .HasMaxLength(30);

                entity.Property(e => e.TeamC8)
                    .HasColumnName("Team_c8")
                    .HasMaxLength(30);

                entity.Property(e => e.TeamC9)
                    .HasColumnName("Team_c9")
                    .HasMaxLength(30);

                entity.Property(e => e.TeamCell)
                    .HasColumnName("Team_cell")
                    .HasMaxLength(20);

                entity.Property(e => e.TeamCity)
                    .HasColumnName("Team_city")
                    .HasMaxLength(30);

                entity.Property(e => e.TeamCntry)
                    .HasColumnName("Team_cntry")
                    .HasMaxLength(3);

                entity.Property(e => e.TeamDaytele)
                    .HasColumnName("Team_daytele")
                    .HasMaxLength(20);

                entity.Property(e => e.TeamDiv).HasColumnName("Team_div");

                entity.Property(e => e.TeamEmail)
                    .HasColumnName("Team_email")
                    .HasMaxLength(36);

                entity.Property(e => e.TeamEvetele)
                    .HasColumnName("Team_evetele")
                    .HasMaxLength(20);

                entity.Property(e => e.TeamFaxtele)
                    .HasColumnName("Team_faxtele")
                    .HasMaxLength(20);

                entity.Property(e => e.TeamHead)
                    .HasColumnName("Team_head")
                    .HasMaxLength(30);

                entity.Property(e => e.TeamLsc)
                    .HasColumnName("Team_lsc")
                    .HasMaxLength(3);

                entity.Property(e => e.TeamName)
                    .HasColumnName("Team_name")
                    .HasMaxLength(30);

                entity.Property(e => e.TeamNo).HasColumnName("Team_no");

                entity.Property(e => e.TeamNoPoints).HasColumnName("Team_NoPoints");

                entity.Property(e => e.TeamProv)
                    .HasColumnName("Team_prov")
                    .HasMaxLength(30);

                entity.Property(e => e.TeamRegion).HasColumnName("Team_region");

                entity.Property(e => e.TeamSelected).HasColumnName("Team_Selected");

                entity.Property(e => e.TeamShort)
                    .HasColumnName("Team_short")
                    .HasMaxLength(16);

                entity.Property(e => e.TeamStat)
                    .HasColumnName("Team_stat")
                    .HasMaxLength(1);

                entity.Property(e => e.TeamStatenew)
                    .HasColumnName("Team_statenew")
                    .HasMaxLength(3);

                entity.Property(e => e.TeamZip)
                    .HasColumnName("Team_zip")
                    .HasMaxLength(10);

                entity.HasOne(d => d.Meet)
                    .WithMany(p => p.Equipos)
                    .HasForeignKey(d => d.MeetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Equipos_Torneo");
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.Property(e => e.EstadoId)
                    .HasColumnName("EstadoID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Detalle)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Estilos>(entity =>
            {
                entity.HasKey(e => e.EstiloId);

                entity.Property(e => e.Estilo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TagStroke)
                    .IsRequired()
                    .HasColumnName("tag_stroke")
                    .HasMaxLength(1)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Eventos>(entity =>
            {
                entity.HasKey(e => e.EventId);

                entity.Property(e => e.AbcStyle).HasColumnName("ABC_Style");

                entity.Property(e => e.AbcfinalOrder)
                    .HasColumnName("ABCfinal_order")
                    .HasMaxLength(6);

                entity.Property(e => e.AutoSeed).HasColumnName("Auto_seed");

                entity.Property(e => e.CheckinEnddate)
                    .HasColumnName("Checkin_enddate")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.CheckinEndtime).HasColumnName("Checkin_endtime");

                entity.Property(e => e.CheckinStartdate)
                    .HasColumnName("Checkin_startdate")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.CheckinStarttime).HasColumnName("Checkin_starttime");

                entity.Property(e => e.Comm1)
                    .HasColumnName("Comm_1")
                    .HasMaxLength(36);

                entity.Property(e => e.Comm2)
                    .HasColumnName("Comm_2")
                    .HasMaxLength(36);

                entity.Property(e => e.Comm3)
                    .HasColumnName("Comm_3")
                    .HasMaxLength(36);

                entity.Property(e => e.Comm4)
                    .HasColumnName("Comm_4")
                    .HasMaxLength(36);

                entity.Property(e => e.CustomAbcfinal).HasColumnName("Custom_ABCFinal");

                entity.Property(e => e.DivNo).HasColumnName("Div_no");

                entity.Property(e => e.EntryFee)
                    .HasColumnName("Entry_fee")
                    .HasColumnType("money");

                entity.Property(e => e.EventDist).HasColumnName("Event_dist");

                entity.Property(e => e.EventGender)
                    .HasColumnName("Event_gender")
                    .HasMaxLength(1);

                entity.Property(e => e.EventLtr)
                    .HasColumnName("Event_ltr")
                    .HasMaxLength(1);

                entity.Property(e => e.EventNo).HasColumnName("Event_no");

                entity.Property(e => e.EventNote)
                    .HasColumnName("Event_note")
                    .HasMaxLength(20);

                entity.Property(e => e.EventPtr).HasColumnName("Event_ptr");

                entity.Property(e => e.EventRounds).HasColumnName("Event_rounds");

                entity.Property(e => e.EventSex)
                    .HasColumnName("Event_sex")
                    .HasMaxLength(1);

                entity.Property(e => e.EventStat)
                    .HasColumnName("Event_stat")
                    .HasMaxLength(1);

                entity.Property(e => e.EventStroke)
                    .HasColumnName("Event_stroke")
                    .HasMaxLength(1);

                entity.Property(e => e.EventType)
                    .HasColumnName("Event_Type")
                    .HasMaxLength(1);

                entity.Property(e => e.EvtMaxAgeForCfinal).HasColumnName("EvtMaxAgeFor_CFinal");

                entity.Property(e => e.EvtMaxAgeNumHeatsCfinal).HasColumnName("EvtMaxAgeNumHeats_CFinal");

                entity.Property(e => e.FastTimeStdAbbr)
                    .HasColumnName("FastTimeStd_Abbr")
                    .HasMaxLength(4);

                entity.Property(e => e.FinActualstarttime).HasColumnName("fin_actualstarttime");

                entity.Property(e => e.FinAwardsPrinted).HasColumnName("Fin_AwardsPrinted");

                entity.Property(e => e.FinalsLanesVary).HasColumnName("Finals_LanesVary");

                entity.Property(e => e.FinalsLanesVaryOrder)
                    .HasColumnName("Finals_LanesVaryOrder")
                    .HasMaxLength(18);

                entity.Property(e => e.FinheatOrder)
                    .HasColumnName("Finheat_order")
                    .HasMaxLength(1);

                entity.Property(e => e.HeatsInfinal)
                    .HasColumnName("Heats_infinal")
                    .HasMaxLength(1);

                entity.Property(e => e.HeatsInsemi).HasColumnName("Heats_insemi");

                entity.Property(e => e.HighAge).HasColumnName("High_Age");

                entity.Property(e => e.IndRel)
                    .HasColumnName("Ind_rel")
                    .HasMaxLength(1);

                entity.Property(e => e.IsLocked).HasColumnName("Is_locked");

                entity.Property(e => e.LockedBy)
                    .HasColumnName("Locked_by")
                    .HasMaxLength(20);

                entity.Property(e => e.LockedList)
                    .HasColumnName("Locked_list")
                    .HasMaxLength(12);

                entity.Property(e => e.LowAge).HasColumnName("Low_age");

                entity.Property(e => e.MultiAge).HasColumnName("Multi_age");

                entity.Property(e => e.MultiAgeScnd).HasColumnName("Multi_ageScnd");

                entity.Property(e => e.MultiageSuperFinal).HasColumnName("Multiage_SuperFinal");

                entity.Property(e => e.MultiageSuperSeed).HasColumnName("Multiage_SuperSeed");

                entity.Property(e => e.NumBestHeatsTimedFinal).HasColumnName("Num_BestHeatsTimedFinal");

                entity.Property(e => e.NumDives).HasColumnName("Num_dives");

                entity.Property(e => e.NumFinlanes).HasColumnName("Num_finlanes");

                entity.Property(e => e.NumHeatsInFinal).HasColumnName("Num_HeatsInFinal");

                entity.Property(e => e.NumHeatsInTimedFinalToScore).HasColumnName("Num_HeatsInTimedFinalToScore");

                entity.Property(e => e.NumLanesInBestHeatsTimedFinal).HasColumnName("Num_LanesInBestHeatsTimedFinal");

                entity.Property(e => e.NumPrelanes).HasColumnName("Num_prelanes");

                entity.Property(e => e.NumRelayLegs).HasColumnName("Num_RelayLegs");

                entity.Property(e => e.NumSemlanes).HasColumnName("Num_semlanes");

                entity.Property(e => e.PadsBothEnds).HasColumnName("Pads_BothEnds");

                entity.Property(e => e.PadsBothEndsFinals).HasColumnName("Pads_BothEndsFinals");

                entity.Property(e => e.PreActualstarttime).HasColumnName("pre_actualstarttime");

                entity.Property(e => e.PreAwardsPrinted).HasColumnName("Pre_AwardsPrinted");

                entity.Property(e => e.PreheatOrder)
                    .HasColumnName("Preheat_order")
                    .HasMaxLength(1);

                entity.Property(e => e.PrelimsAsExtendedFinal).HasColumnName("PrelimsAs_ExtendedFinal");

                entity.Property(e => e.RelaySize).HasColumnName("Relay_size");

                entity.Property(e => e.ScoreEvent).HasColumnName("Score_event");

                entity.Property(e => e.ScoreTimedFinalAsAbc).HasColumnName("ScoreTimedFinal_asABC");

                entity.Property(e => e.SeedMultiAgeOldToYoung).HasColumnName("SeedMultiAge_OldToYoung");

                entity.Property(e => e.SemActualstarttime).HasColumnName("sem_actualstarttime");

                entity.Property(e => e.SemAwardsPrinted).HasColumnName("Sem_AwardsPrinted");

                entity.Property(e => e.SlowTimeStdAbbr)
                    .HasColumnName("SlowTimeStd_Abbr")
                    .HasMaxLength(4);

                entity.Property(e => e.StdLanes)
                    .HasColumnName("Std_lanes")
                    .HasMaxLength(1);

                entity.Property(e => e.SuperFinalElimOldAgeGrp).HasColumnName("SuperFinal_ElimOldAgeGrp");

                entity.Property(e => e.SuppressDistance).HasColumnName("Suppress_distance");

                entity.Property(e => e.SuppressStroke).HasColumnName("Suppress_stroke");

                entity.Property(e => e.TimedFinalLanesVary).HasColumnName("TimedFinal_LanesVary");

                entity.Property(e => e.TwoperlaneReq).HasColumnName("Twoperlane_req");

                entity.HasOne(d => d.Meet)
                    .WithMany(p => p.Eventos)
                    .HasForeignKey(d => d.MeetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Eventos_Torneo");
            });

            modelBuilder.Entity<Fotos>(entity =>
            {
                entity.HasKey(e => e.FotoId);

                entity.Property(e => e.Nombrefoto).HasMaxLength(100);

                entity.HasOne(d => d.Noticia)
                    .WithMany(p => p.Fotos)
                    .HasForeignKey(d => d.NoticiaId)
                    .HasConstraintName("FK_Fotos_Noticias");
            });

            modelBuilder.Entity<HistorialEntrenador>(entity =>
            {
                entity.HasKey(e => e.HistoriaId);

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.HasOne(d => d.Club)
                    .WithMany(p => p.HistorialEntrenador)
                    .HasForeignKey(d => d.ClubId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HistorialEntrenador_Club");

                entity.HasOne(d => d.Entrenador)
                    .WithMany(p => p.HistorialEntrenador)
                    .HasForeignKey(d => d.EntrenadorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HistorialEntrenador_Entrenadores");
            });

            modelBuilder.Entity<HistorialTraspasos>(entity =>
            {
                entity.HasKey(e => e.HistorialId);

                entity.Property(e => e.Dni)
                    .IsRequired()
                    .HasColumnName("DNI")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FechaTraspaso).HasColumnType("date");

                entity.HasOne(d => d.Club)
                    .WithMany(p => p.HistorialTraspasos)
                    .HasForeignKey(d => d.ClubId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HistorialTraspasos_Club");

                entity.HasOne(d => d.Inscripcion)
                    .WithMany(p => p.HistorialTraspasos)
                    .HasForeignKey(d => d.InscripcionId)
                    .HasConstraintName("FK_HistorialTraspasos_Inscripciones");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.HistorialTraspasos)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HistorialTraspasos_Usuario");
            });

            modelBuilder.Entity<HistorialdeAfiliaciones>(entity =>
            {
                entity.HasKey(e => e.AfiliacionId);

                entity.Property(e => e.AfiliacionId).HasColumnName("afiliacionId");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.HasOne(d => d.Inscripcion)
                    .WithMany(p => p.HistorialdeAfiliaciones)
                    .HasForeignKey(d => d.InscripcionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HistorialdeAfiliaciones_Inscripciones");
            });

            modelBuilder.Entity<Hoja2>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Distancia).HasColumnName("distancia");

                entity.Property(e => e.Estilo)
                    .HasColumnName("estilo")
                    .HasMaxLength(1);

                entity.Property(e => e.Indi).HasMaxLength(1);

                entity.Property(e => e.Max).HasColumnName("max");

                entity.Property(e => e.Mini).HasColumnName("mini");

                entity.Property(e => e.Piscina).HasMaxLength(1);

                entity.Property(e => e.Segundos).HasColumnName("segundos");

                entity.Property(e => e.Sex).HasMaxLength(1);

                entity.Property(e => e.Uno).HasColumnName("UNO");
            });

            modelBuilder.Entity<InscripcionResponsable>(entity =>
            {
                entity.HasKey(e => e.ResponsableId);

                entity.Property(e => e.Celular)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsFixedLength();

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.InscripcionResponsable)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InscripcionResponsable_Equipos");
            });

            modelBuilder.Entity<Inscripciones>(entity =>
            {
                entity.HasKey(e => e.InscripcionId);

                entity.Property(e => e.ClubId).HasColumnName("ClubID");

                entity.Property(e => e.Dni)
                    .IsRequired()
                    .HasColumnName("DNI")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EstadoId).HasColumnName("EstadoID");

                entity.Property(e => e.FotoDni)
                    .HasColumnName("FotoDNI")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.RutaFoto)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RutaFotoAntigua)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TipoAfiliadoId).HasColumnName("TipoAfiliadoID");

                entity.HasOne(d => d.Antiguo)
                    .WithMany(p => p.Inscripciones)
                    .HasForeignKey(d => d.AntiguoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inscripciones_Antiguo");

                entity.HasOne(d => d.Club)
                    .WithMany(p => p.Inscripciones)
                    .HasForeignKey(d => d.ClubId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inscripciones_Club");

                entity.HasOne(d => d.Disciplina)
                    .WithMany(p => p.Inscripciones)
                    .HasForeignKey(d => d.DisciplinaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inscripciones_Disciplina");

                entity.HasOne(d => d.DniNavigation)
                    .WithMany(p => p.Inscripciones)
                    .HasForeignKey(d => d.Dni)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inscripciones_Afiliado1");

                entity.HasOne(d => d.Estado)
                    .WithMany(p => p.Inscripciones)
                    .HasForeignKey(d => d.EstadoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inscripciones_Estado");

                entity.HasOne(d => d.TipoAfiliado)
                    .WithMany(p => p.Inscripciones)
                    .HasForeignKey(d => d.TipoAfiliadoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inscripciones_TipoAfiliado");
            });

            modelBuilder.Entity<Landing>(entity =>
            {
                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MarcasMinimas>(entity =>
            {
                entity.HasKey(e => e.TimeStdId);

                entity.Property(e => e.DivAbbr)
                    .HasColumnName("div_abbr")
                    .HasMaxLength(3);

                entity.Property(e => e.HighAge).HasColumnName("high_Age");

                entity.Property(e => e.LowAge).HasColumnName("low_age");

                entity.Property(e => e.TagCourse)
                    .HasColumnName("tag_course")
                    .HasMaxLength(1);

                entity.Property(e => e.TagDist).HasColumnName("tag_dist");

                entity.Property(e => e.TagGender)
                    .HasColumnName("tag_gender")
                    .HasMaxLength(1);

                entity.Property(e => e.TagIndrel)
                    .HasColumnName("tag_indrel")
                    .HasMaxLength(1);

                entity.Property(e => e.TagPtr).HasColumnName("tag_ptr");

                entity.Property(e => e.TagStroke)
                    .HasColumnName("tag_stroke")
                    .HasMaxLength(1);

                entity.Property(e => e.TagTime).HasColumnName("tag_time");

                entity.HasOne(d => d.Meet)
                    .WithMany(p => p.MarcasMinimas)
                    .HasForeignKey(d => d.MeetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MarcasMinimas_Torneo");
            });

            modelBuilder.Entity<Meet>(entity =>
            {
                entity.ToTable("MEET");

                entity.Property(e => e.Course)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.End).HasColumnType("smalldatetime");

                entity.Property(e => e.Meet1).HasColumnName("Meet");

                entity.Property(e => e.Mname)
                    .IsRequired()
                    .HasColumnName("MName")
                    .HasMaxLength(45);

                entity.Property(e => e.Start).HasColumnType("smalldatetime");
            });

            modelBuilder.Entity<Meetmasters>(entity =>
            {
                entity.HasKey(e => e.MeetId);

                entity.ToTable("MEETMasters");

                entity.Property(e => e.Course)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.End).HasColumnType("smalldatetime");

                entity.Property(e => e.Mname)
                    .IsRequired()
                    .HasColumnName("MName")
                    .HasMaxLength(45);

                entity.Property(e => e.Start).HasColumnType("smalldatetime");
            });

            modelBuilder.Entity<Modals>(entity =>
            {
                entity.HasKey(e => e.Modalid);

                entity.Property(e => e.Enlace).HasMaxLength(200);

                entity.Property(e => e.Image).HasMaxLength(200);

                entity.Property(e => e.Titulo).HasMaxLength(500);
            });

            modelBuilder.Entity<Multas>(entity =>
            {
                entity.HasKey(e => e.MultaId);

                entity.Property(e => e.Boleta)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.DcsoMedico).HasMaxLength(50);

                entity.Property(e => e.FechaPago).HasColumnType("date");

                entity.Property(e => e.FechaTorneo).HasColumnType("date");

                entity.Property(e => e.Torneo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Inscripcion)
                    .WithMany(p => p.Multas)
                    .HasForeignKey(d => d.InscripcionId)
                    .HasConstraintName("FK_Multas_Inscripciones");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Multas)
                    .HasForeignKey(d => d.UsuarioId)
                    .HasConstraintName("FK_Multas_Usuario");
            });

            modelBuilder.Entity<MultiEdad>(entity =>
            {
                entity.HasKey(e => e.MultiAgeId);

                entity.Property(e => e.EventPtr).HasColumnName("event_ptr");

                entity.Property(e => e.HeatsInfinal)
                    .HasColumnName("Heats_infinal")
                    .HasMaxLength(1);

                entity.Property(e => e.HighAge).HasColumnName("high_age");

                entity.Property(e => e.LowAge).HasColumnName("low_age");

                entity.Property(e => e.NumHeatsinfinal).HasColumnName("Num_Heatsinfinal");

                entity.HasOne(d => d.Meet)
                    .WithMany(p => p.MultiEdad)
                    .HasForeignKey(d => d.MeetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MultiEdad_Torneo");
            });

            modelBuilder.Entity<Noticias>(entity =>
            {
                entity.HasKey(e => e.NoticiaId);

                entity.Property(e => e.Corta)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.FechaModificacion).HasColumnType("date");

                entity.Property(e => e.Palabrasclaves)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Youtube)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.Noticias)
                    .HasForeignKey(d => d.CategoriaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Noticias_CategoriaNoticia");

                entity.HasOne(d => d.Disciplina)
                    .WithMany(p => p.Noticias)
                    .HasForeignKey(d => d.DisciplinaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Noticias_Disciplina");
            });

            modelBuilder.Entity<OtroAtleta>(entity =>
            {
                entity.HasKey(e => e.AtletaId);

                entity.HasOne(d => d.Inscripcion)
                    .WithMany(p => p.OtroAtleta)
                    .HasForeignKey(d => d.InscripcionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OtroAtleta_Inscripciones");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.OtroAtleta)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OtroAtleta_OtroEquipo");
            });

            modelBuilder.Entity<OtroCategorias>(entity =>
            {
                entity.HasKey(e => e.CategoriaId);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Disciplina)
                    .WithMany(p => p.OtroCategorias)
                    .HasForeignKey(d => d.DisciplinaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OtroCategorias_Disciplina");
            });

            modelBuilder.Entity<OtroEntradas>(entity =>
            {
                entity.HasKey(e => e.EntradaId);

                entity.HasOne(d => d.Atleta)
                    .WithMany(p => p.OtroEntradas)
                    .HasForeignKey(d => d.AtletaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OtroEntradas_OtroAtleta");

                entity.HasOne(d => d.Evento)
                    .WithMany(p => p.OtroEntradas)
                    .HasForeignKey(d => d.EventoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OtroEntradas_OtroEventos");

                entity.HasOne(d => d.Torneo)
                    .WithMany(p => p.OtroEntradas)
                    .HasForeignKey(d => d.TorneoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OtroEntradas_OtroTorneo");
            });

            modelBuilder.Entity<OtroEquipo>(entity =>
            {
                entity.HasKey(e => e.TeamId);

                entity.Property(e => e.TeamAbbr)
                    .IsRequired()
                    .HasColumnName("Team_abbr")
                    .HasMaxLength(5);

                entity.Property(e => e.TeamName)
                    .IsRequired()
                    .HasColumnName("Team_name")
                    .HasMaxLength(30);

                entity.HasOne(d => d.Torneo)
                    .WithMany(p => p.OtroEquipo)
                    .HasForeignKey(d => d.TorneoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OtroEquipo_OtroTorneo");
            });

            modelBuilder.Entity<OtroEventos>(entity =>
            {
                entity.HasKey(e => e.EventoId);

                entity.Property(e => e.EventNombre)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.EventSex)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.HasOne(d => d.Torneo)
                    .WithMany(p => p.OtroEventos)
                    .HasForeignKey(d => d.TorneoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OtroEventos_OtroTorneo");
            });

            modelBuilder.Entity<OtroGrupal>(entity =>
            {
                entity.HasKey(e => e.GrupalId);

                entity.HasOne(d => d.Evento)
                    .WithMany(p => p.OtroGrupal)
                    .HasForeignKey(d => d.EventoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OtroGrupal_OtroEventos");
            });

            modelBuilder.Entity<OtroResponsable>(entity =>
            {
                entity.HasKey(e => e.ResponsableId);

                entity.Property(e => e.Celular)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsFixedLength();

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.OtroResponsable)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OtroResponsable_OtroEquipo");
            });

            modelBuilder.Entity<OtroSetupTorneo>(entity =>
            {
                entity.HasKey(e => e.SetupId);

                entity.HasOne(d => d.Torneo)
                    .WithMany(p => p.OtroSetupTorneo)
                    .HasForeignKey(d => d.TorneoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OtroSetupTorneo_OtroTorneo");
            });

            modelBuilder.Entity<OtroTorneo>(entity =>
            {
                entity.HasKey(e => e.TorneoId);

                entity.Property(e => e.EdadAdiciembre).HasColumnName("EdadADiciembre");

                entity.Property(e => e.FechaCierre).HasColumnType("date");

                entity.Property(e => e.FechaInicio).HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.HasOne(d => d.Disciplina)
                    .WithMany(p => p.OtroTorneo)
                    .HasForeignKey(d => d.DisciplinaId)
                    .HasConstraintName("FK_OtroTorneo_Disciplina");
            });

            modelBuilder.Entity<Piscinas>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<PoloEquipos>(entity =>
            {
                entity.HasKey(e => e.EquipoId);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sexo)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<PoloFechas>(entity =>
            {
                entity.HasKey(e => e.FechaId);

                entity.Property(e => e.Dia).HasColumnType("date");

                entity.HasOne(d => d.Torneo)
                    .WithMany(p => p.PoloFechas)
                    .HasForeignKey(d => d.TorneoId)
                    .HasConstraintName("FK_PoloFechas_PoloTorneo");
            });

            modelBuilder.Entity<PoloGoleadores>(entity =>
            {
                entity.HasKey(e => e.GoleadorId);

                entity.HasOne(d => d.Jugador)
                    .WithMany(p => p.PoloGoleadores)
                    .HasForeignKey(d => d.JugadorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PoloGoleadores_PoloJugadores");

                entity.HasOne(d => d.Torneo)
                    .WithMany(p => p.PoloGoleadores)
                    .HasForeignKey(d => d.TorneoId)
                    .HasConstraintName("FK_PoloGoleadores_PoloTorneo");
            });

            modelBuilder.Entity<PoloGrupos>(entity =>
            {
                entity.HasKey(e => e.GrupoId);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<PoloJugadores>(entity =>
            {
                entity.HasKey(e => e.JugadorId);

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sexo)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.HasOne(d => d.Equipo)
                    .WithMany(p => p.PoloJugadores)
                    .HasForeignKey(d => d.EquipoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PoloJugadores_PoloEquipos");

                entity.HasOne(d => d.Torneo)
                    .WithMany(p => p.PoloJugadores)
                    .HasForeignKey(d => d.TorneoId)
                    .HasConstraintName("FK_PoloJugadores_PoloTorneo");
            });

            modelBuilder.Entity<PoloPartidos>(entity =>
            {
                entity.HasKey(e => e.PartidoId);

                entity.Property(e => e.Sexo)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.HasOne(d => d.Fecha)
                    .WithMany(p => p.PoloPartidos)
                    .HasForeignKey(d => d.FechaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PoloPartidos_PoloFechas");

                entity.HasOne(d => d.Grupo)
                    .WithMany(p => p.PoloPartidos)
                    .HasForeignKey(d => d.GrupoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PoloPartidos_PoloGrupos");

                entity.HasOne(d => d.Ronda)
                    .WithMany(p => p.PoloPartidos)
                    .HasForeignKey(d => d.RondaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PoloPartidos_PoloRondas");

                entity.HasOne(d => d.Torneo)
                    .WithMany(p => p.PoloPartidos)
                    .HasForeignKey(d => d.TorneoId)
                    .HasConstraintName("FK_PoloPartidos_PoloTorneo");
            });

            modelBuilder.Entity<PoloPosicion>(entity =>
            {
                entity.HasKey(e => e.PosicionId);

                entity.Property(e => e.Dg).HasColumnName("DG");

                entity.Property(e => e.Gc).HasColumnName("GC");

                entity.Property(e => e.Gf).HasColumnName("GF");

                entity.Property(e => e.Pe).HasColumnName("PE");

                entity.Property(e => e.Pg).HasColumnName("PG");

                entity.Property(e => e.Pj).HasColumnName("PJ");

                entity.Property(e => e.Pp).HasColumnName("PP");

                entity.Property(e => e.Puntos).HasColumnName("PUNTOS");

                entity.HasOne(d => d.Equipo)
                    .WithMany(p => p.PoloPosicion)
                    .HasForeignKey(d => d.EquipoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PoloPosicion_PoloEquipos");

                entity.HasOne(d => d.Grupo)
                    .WithMany(p => p.PoloPosicion)
                    .HasForeignKey(d => d.GrupoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PoloPosicion_PoloGrupos");

                entity.HasOne(d => d.Torneo)
                    .WithMany(p => p.PoloPosicion)
                    .HasForeignKey(d => d.TorneoId)
                    .HasConstraintName("FK_PoloPosicion_PoloTorneo");
            });

            modelBuilder.Entity<PoloPosicionFinal>(entity =>
            {
                entity.HasKey(e => e.PosicionId);

                entity.Property(e => e.PosicionId).ValueGeneratedNever();

                entity.HasOne(d => d.Equipo)
                    .WithMany(p => p.PoloPosicionFinal)
                    .HasForeignKey(d => d.EquipoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PoloPosicionFinal_PoloEquipos");

                entity.HasOne(d => d.Torneo)
                    .WithMany(p => p.PoloPosicionFinal)
                    .HasForeignKey(d => d.TorneoId)
                    .HasConstraintName("FK_PoloPosicionFinal_PoloTorneo");
            });

            modelBuilder.Entity<PoloResultados>(entity =>
            {
                entity.HasKey(e => e.ResultadoId);

                entity.HasOne(d => d.Partida)
                    .WithMany(p => p.PoloResultados)
                    .HasForeignKey(d => d.PartidaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PoloResultados_PoloPartidos");

                entity.HasOne(d => d.Torneo)
                    .WithMany(p => p.PoloResultados)
                    .HasForeignKey(d => d.TorneoId)
                    .HasConstraintName("FK_PoloResultados_PoloTorneo");
            });

            modelBuilder.Entity<PoloRondas>(entity =>
            {
                entity.HasKey(e => e.RondaId);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Torneo)
                    .WithMany(p => p.PoloRondas)
                    .HasForeignKey(d => d.TorneoId)
                    .HasConstraintName("FK_PoloRondas_PoloTorneo");
            });

            modelBuilder.Entity<PoloSetupTorneo>(entity =>
            {
                entity.HasKey(e => e.SetupId);

                entity.HasOne(d => d.Torneo)
                    .WithMany(p => p.PoloSetupTorneo)
                    .HasForeignKey(d => d.TorneoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PoloSetupTorneo_PoloTorneo");
            });

            modelBuilder.Entity<PoloTorneo>(entity =>
            {
                entity.HasKey(e => e.TorneoId);

                entity.Property(e => e.FechaCierre).HasColumnType("date");

                entity.Property(e => e.FechaInicio).HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<Procesado>(entity =>
            {
                entity.Property(e => e.ProcesadoId).ValueGeneratedNever();

                entity.Property(e => e.Detalle)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pruebas>(entity =>
            {
                entity.HasKey(e => e.PruebaId);

                entity.Property(e => e.Distancia).HasColumnName("distancia");

                entity.Property(e => e.Estilo)
                    .IsRequired()
                    .HasColumnName("estilo")
                    .HasMaxLength(10);

                entity.Property(e => e.EstiloMeet)
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Query>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Birth).HasColumnType("datetime2(3)");

                entity.Property(e => e.First)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.IdNo)
                    .IsRequired()
                    .HasColumnName("ID_NO")
                    .HasMaxLength(17);

                entity.Property(e => e.Last)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Sex)
                    .IsRequired()
                    .HasMaxLength(1);
            });

            modelBuilder.Entity<RecordTipo>(entity =>
            {
                entity.HasKey(e => e.TipoId);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Records>(entity =>
            {
                entity.HasKey(e => e.RecordId);

                entity.Property(e => e.DivAbbr)
                    .HasColumnName("div_abbr")
                    .HasMaxLength(3);

                entity.Property(e => e.HighAge).HasColumnName("high_Age");

                entity.Property(e => e.LowAge).HasColumnName("low_age");

                entity.Property(e => e.RecordCourse)
                    .HasColumnName("Record_course")
                    .HasMaxLength(1);

                entity.Property(e => e.RecordDay).HasColumnName("Record_day");

                entity.Property(e => e.RecordHolder)
                    .HasColumnName("Record_Holder")
                    .HasMaxLength(30);

                entity.Property(e => e.RecordHolderteam)
                    .HasColumnName("Record_Holderteam")
                    .HasMaxLength(16);

                entity.Property(e => e.RecordMonth).HasColumnName("Record_month");

                entity.Property(e => e.RecordTeamabbr)
                    .HasColumnName("Record_teamabbr")
                    .HasMaxLength(5);

                entity.Property(e => e.RecordTeamlsc)
                    .HasColumnName("Record_teamlsc")
                    .HasMaxLength(2);

                entity.Property(e => e.RecordTime).HasColumnName("Record_Time");

                entity.Property(e => e.RecordYear).HasColumnName("Record_year");

                entity.Property(e => e.RelayNames)
                    .HasColumnName("Relay_Names")
                    .HasMaxLength(50);

                entity.Property(e => e.TagDist).HasColumnName("tag_dist");

                entity.Property(e => e.TagGender)
                    .HasColumnName("tag_gender")
                    .HasMaxLength(1);

                entity.Property(e => e.TagIndrel)
                    .HasColumnName("tag_indrel")
                    .HasMaxLength(1);

                entity.Property(e => e.TagPtr).HasColumnName("tag_ptr");

                entity.Property(e => e.TagStroke)
                    .HasColumnName("tag_stroke")
                    .HasMaxLength(1);
            });

            modelBuilder.Entity<RecordsActuales>(entity =>
            {
                entity.HasKey(e => e.RecordId);

                entity.Property(e => e.Equipo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.Nombre1)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Nombre2)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Nombre3)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Nombre4)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PiscinaId)
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.Split1).HasColumnName("split1");

                entity.Property(e => e.Split2).HasColumnName("split2");

                entity.Property(e => e.Split3).HasColumnName("split3");

                entity.Property(e => e.Split4).HasColumnName("split4");

                entity.Property(e => e.Torneo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Edad)
                    .WithMany(p => p.RecordsActuales)
                    .HasForeignKey(d => d.EdadId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RecordsActuales_RecordsEdades");

                entity.HasOne(d => d.Piscina)
                    .WithMany(p => p.RecordsActuales)
                    .HasForeignKey(d => d.PiscinaId)
                    .HasConstraintName("FK_RecordsActuales_Piscinas");

                entity.HasOne(d => d.Prueba)
                    .WithMany(p => p.RecordsActuales)
                    .HasForeignKey(d => d.PruebaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RecordsActuales_RecordsPruebas");

                entity.HasOne(d => d.Tipo)
                    .WithMany(p => p.RecordsActuales)
                    .HasForeignKey(d => d.TipoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RecordsActuales_RecordTipo");
            });

            modelBuilder.Entity<RecordsEdades>(entity =>
            {
                entity.HasKey(e => e.EdadId);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RecordsPruebas>(entity =>
            {
                entity.HasKey(e => e.PruebaId);

                entity.Property(e => e.Estilo)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Sexo)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Results>(entity =>
            {
                entity.HasKey(e => e.ResultId);

                entity.ToTable("RESULTS");

                entity.Property(e => e.Age).HasColumnName("AGE");

                entity.Property(e => e.Athlete).HasColumnName("ATHLETE");

                entity.Property(e => e.Course)
                    .IsRequired()
                    .HasColumnName("COURSE")
                    .HasMaxLength(1);

                entity.Property(e => e.Distance)
                    .IsRequired()
                    .HasColumnName("DISTANCE")
                    .HasMaxLength(12);

                entity.Property(e => e.Division)
                    .HasColumnName("DIVISION")
                    .HasMaxLength(3);

                entity.Property(e => e.Ex)
                    .HasColumnName("EX")
                    .HasMaxLength(1);

                entity.Property(e => e.FP)
                    .IsRequired()
                    .HasColumnName("F_P")
                    .HasMaxLength(1);

                entity.Property(e => e.IR)
                    .IsRequired()
                    .HasColumnName("I_R")
                    .HasMaxLength(1);

                entity.Property(e => e.LoHi).HasColumnName("LO_HI");

                entity.Property(e => e.Meet).HasColumnName("MEET");

                entity.Property(e => e.Mtev)
                    .IsRequired()
                    .HasColumnName("MTEV")
                    .HasMaxLength(8);

                entity.Property(e => e.Nt).HasColumnName("NT");

                entity.Property(e => e.Pfina).HasColumnName("PFina");

                entity.Property(e => e.Place).HasColumnName("PLACE");

                entity.Property(e => e.Points).HasColumnName("POINTS");

                entity.Property(e => e.Score)
                    .IsRequired()
                    .HasColumnName("SCORE")
                    .HasMaxLength(12);

                entity.Property(e => e.Stroke)
                    .IsRequired()
                    .HasColumnName("STROKE")
                    .HasMaxLength(12);

                entity.Property(e => e.Team).HasColumnName("TEAM");

                entity.HasOne(d => d.AthleteNavigation)
                    .WithMany(p => p.Results)
                    .HasForeignKey(d => d.AthleteId)
                    .HasConstraintName("FK_RESULTS_Athlete");

                entity.HasOne(d => d.MeetNavigation)
                    .WithMany(p => p.Results)
                    .HasForeignKey(d => d.MeetId)
                    .HasConstraintName("FK_RESULTS_MEET");

                entity.HasOne(d => d.Prueba)
                    .WithMany(p => p.Results)
                    .HasForeignKey(d => d.PruebaId)
                    .HasConstraintName("FK_RESULTS_Pruebas");

                entity.HasOne(d => d.TeamNavigation)
                    .WithMany(p => p.Results)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK_RESULTS_TEAM");
            });

            modelBuilder.Entity<Resultsmasters>(entity =>
            {
                entity.HasKey(e => e.ResultId);

                entity.ToTable("RESULTSMasters");

                entity.Property(e => e.Age).HasColumnName("AGE");

                entity.Property(e => e.Athlete).HasColumnName("ATHLETE");

                entity.Property(e => e.Course)
                    .IsRequired()
                    .HasColumnName("COURSE")
                    .HasMaxLength(1);

                entity.Property(e => e.Distance)
                    .IsRequired()
                    .HasColumnName("DISTANCE")
                    .HasMaxLength(12);

                entity.Property(e => e.Division)
                    .HasColumnName("DIVISION")
                    .HasMaxLength(3);

                entity.Property(e => e.Ex)
                    .HasColumnName("EX")
                    .HasMaxLength(1);

                entity.Property(e => e.FP)
                    .IsRequired()
                    .HasColumnName("F_P")
                    .HasMaxLength(1);

                entity.Property(e => e.IR)
                    .IsRequired()
                    .HasColumnName("I_R")
                    .HasMaxLength(1);

                entity.Property(e => e.LoHi).HasColumnName("LO_HI");

                entity.Property(e => e.Meet).HasColumnName("MEET");

                entity.Property(e => e.Mtev)
                    .IsRequired()
                    .HasColumnName("MTEV")
                    .HasMaxLength(8);

                entity.Property(e => e.Nt).HasColumnName("NT");

                entity.Property(e => e.Pfina).HasColumnName("PFina");

                entity.Property(e => e.Place).HasColumnName("PLACE");

                entity.Property(e => e.Points).HasColumnName("POINTS");

                entity.Property(e => e.Score)
                    .IsRequired()
                    .HasColumnName("SCORE")
                    .HasMaxLength(12);

                entity.Property(e => e.Stroke)
                    .IsRequired()
                    .HasColumnName("STROKE")
                    .HasMaxLength(12);

                entity.Property(e => e.Team).HasColumnName("TEAM");

                entity.HasOne(d => d.AthleteNavigation)
                    .WithMany(p => p.Resultsmasters)
                    .HasForeignKey(d => d.AthleteId)
                    .HasConstraintName("FK_RESULTSMasters_AthleteMasters");

                entity.HasOne(d => d.MeetNavigation)
                    .WithMany(p => p.Resultsmasters)
                    .HasForeignKey(d => d.MeetId)
                    .HasConstraintName("FK_RESULTSMasters_MEETMasters");

                entity.HasOne(d => d.Prueba)
                    .WithMany(p => p.Resultsmasters)
                    .HasForeignKey(d => d.PruebaId)
                    .HasConstraintName("FK_RESULTSMasters_Pruebas");

                entity.HasOne(d => d.TeamNavigation)
                    .WithMany(p => p.Resultsmasters)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK_RESULTSMasters_TEAMMasters");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.Property(e => e.RolId).ValueGeneratedNever();

                entity.Property(e => e.Detalle)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Rol1)
                    .IsRequired()
                    .HasColumnName("Rol")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Saltos>(entity =>
            {
                entity.HasKey(e => e.SaltoId);

                entity.Property(e => e.Nombre).HasMaxLength(255);

                entity.Property(e => e.Tipo).HasMaxLength(255);
            });

            modelBuilder.Entity<Sesion>(entity =>
            {
                entity.HasKey(e => e.SessionId);

                entity.Property(e => e.SessBackinterval).HasColumnName("Sess_backinterval");

                entity.Property(e => e.SessChaseinterval).HasColumnName("Sess_chaseinterval");

                entity.Property(e => e.SessCourse)
                    .HasColumnName("Sess_course")
                    .HasMaxLength(1);

                entity.Property(e => e.SessDay).HasColumnName("Sess_day");

                entity.Property(e => e.SessDivinginterval).HasColumnName("Sess_divinginterval");

                entity.Property(e => e.SessEntrymax).HasColumnName("Sess_entrymax");

                entity.Property(e => e.SessEntrymaxind).HasColumnName("Sess_entrymaxind");

                entity.Property(e => e.SessEntrymaxrel).HasColumnName("Sess_entrymaxrel");

                entity.Property(e => e.SessInterval).HasColumnName("Sess_interval");

                entity.Property(e => e.SessLtr)
                    .HasColumnName("Sess_ltr")
                    .HasMaxLength(1);

                entity.Property(e => e.SessName)
                    .HasColumnName("Sess_name")
                    .HasMaxLength(60);

                entity.Property(e => e.SessNo).HasColumnName("Sess_no");

                entity.Property(e => e.SessPtr).HasColumnName("Sess_ptr");

                entity.Property(e => e.SessStarttime).HasColumnName("Sess_starttime");

                entity.HasOne(d => d.Meet)
                    .WithMany(p => p.Sesion)
                    .HasForeignKey(d => d.MeetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sesion_Torneo");
            });

            modelBuilder.Entity<SessionItem>(entity =>
            {
                entity.HasKey(e => e.SessitemId);

                entity.Property(e => e.AltHeatsStartCount).HasColumnName("AltHeats_StartCount");

                entity.Property(e => e.AltWith).HasColumnName("Alt_With");

                entity.Property(e => e.DelayDesc)
                    .HasColumnName("Delay_desc")
                    .HasMaxLength(50);

                entity.Property(e => e.DelaySeconds).HasColumnName("Delay_seconds");

                entity.Property(e => e.EventPtr).HasColumnName("Event_ptr");

                entity.Property(e => e.EventToAlternateWith).HasColumnName("EventTo_AlternateWith");

                entity.Property(e => e.ReptType)
                    .HasColumnName("Rept_type")
                    .HasMaxLength(1);

                entity.Property(e => e.SessOrder).HasColumnName("Sess_order");

                entity.Property(e => e.SessPtr).HasColumnName("Sess_ptr");

                entity.Property(e => e.SessRnd)
                    .HasColumnName("Sess_rnd")
                    .HasMaxLength(1);

                entity.Property(e => e.TimedFinalheats).HasColumnName("Timed_finalheats");

                entity.HasOne(d => d.Meet)
                    .WithMany(p => p.SessionItem)
                    .HasForeignKey(d => d.Meetid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SessionItem_Torneo");
            });

            modelBuilder.Entity<SetupTorneo>(entity =>
            {
                entity.HasKey(e => e.SetupId)
                    .HasName("PK__SetupTor__C9C734D3D5F59273");

                entity.Property(e => e.FechaMarcas).HasColumnType("date");

                entity.Property(e => e.PruebasXequipo).HasColumnName("pruebasXEquipo");

                entity.Property(e => e.PruebasXsesion).HasColumnName("pruebasXsesion");

                entity.Property(e => e.PruebasXtorneo).HasColumnName("pruebasXtorneo");

                entity.HasOne(d => d.Meet)
                    .WithMany(p => p.SetupTorneo)
                    .HasForeignKey(d => d.Meetid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SetupTorneo_Torneo");

                entity.HasOne(d => d.Tipo)
                    .WithMany(p => p.SetupTorneo)
                    .HasForeignKey(d => d.TipoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SetupTorn__TipoI__2AA05119");
            });

            modelBuilder.Entity<Sheet1>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Sheet1$");

                entity.Property(e => e.Carácter).HasMaxLength(255);

                entity.Property(e => e.Disciplina).HasColumnName("disciplina");

                entity.Property(e => e.Evento)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Fin).HasColumnType("datetime");

                entity.Property(e => e.Inicio).HasColumnType("datetime");

                entity.Property(e => e.Internacional).HasColumnName("internacional");

                entity.Property(e => e.Observación).HasMaxLength(255);

                entity.Property(e => e.Organizador).HasMaxLength(255);

                entity.Property(e => e.Sede)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Suscritos>(entity =>
            {
                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Fnacimiento)
                    .HasColumnName("FNacimiento")
                    .HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TagNames>(entity =>
            {
                entity.HasKey(e => e.TagId);

                entity.Property(e => e.ForEntryqual).HasColumnName("for_entryqual");

                entity.Property(e => e.ForScoring).HasColumnName("for_scoring");

                entity.Property(e => e.ForTimestd).HasColumnName("for_timestd");

                entity.Property(e => e.TagDesc)
                    .HasColumnName("tag_desc")
                    .HasMaxLength(20);

                entity.Property(e => e.TagName)
                    .HasColumnName("tag_name")
                    .HasMaxLength(4);

                entity.Property(e => e.TagPtr).HasColumnName("tag_ptr");
            });

            modelBuilder.Entity<TatoInformeAsistencias>(entity =>
            {
                entity.HasKey(e => e.InformeId);

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.Observaciones)
                    .IsRequired()
                    .HasMaxLength(4000);

                entity.HasOne(d => d.Inscripcion)
                    .WithMany(p => p.TatoInformeAsistencias)
                    .HasForeignKey(d => d.InscripcionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TatoInformeAsistencias_Inscripciones");
            });

            modelBuilder.Entity<TatoInformeEntrenador>(entity =>
            {
                entity.HasKey(e => e.InformeId);

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.MejorMarca)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Sensacion).IsRequired();

                entity.HasOne(d => d.Entrenador)
                    .WithMany(p => p.TatoInformeEntrenador)
                    .HasForeignKey(d => d.EntrenadorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TatoInformeEntrenador_Entrenadores");

                entity.HasOne(d => d.Inscripcion)
                    .WithMany(p => p.TatoInformeEntrenador)
                    .HasForeignKey(d => d.InscripcionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TatoInformeEntrenador_Inscripciones");

                entity.HasOne(d => d.Realizacion)
                    .WithMany(p => p.TatoInformeEntrenador)
                    .HasForeignKey(d => d.RealizacionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TatoInformeEntrenador_TatoRealizacion");

                entity.HasOne(d => d.Serie)
                    .WithMany(p => p.TatoInformeEntrenador)
                    .HasForeignKey(d => d.SerieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TatoInformeEntrenador_TatoSeriesEjemplo");
            });

            modelBuilder.Entity<TatoRealizacion>(entity =>
            {
                entity.HasKey(e => e.RealizacionId);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<TatoSeleccionado>(entity =>
            {
                entity.HasKey(e => e.SeleccionadoId);

                entity.HasOne(d => d.Inscripcion)
                    .WithMany(p => p.TatoSeleccionado)
                    .HasForeignKey(d => d.InscripcionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TatoSeleccionado_Inscripciones");
            });

            modelBuilder.Entity<TatoSeriesEjemplo>(entity =>
            {
                entity.HasKey(e => e.SerieId);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsFixedLength();
            });

            modelBuilder.Entity<TbSuscritos>(entity =>
            {
                entity.ToTable("tb_Suscritos");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Fnacimiento)
                    .HasColumnName("FNacimiento")
                    .HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.ToTable("TEAM");

                entity.Property(e => e.Tcode)
                    .IsRequired()
                    .HasColumnName("TCode")
                    .HasMaxLength(5);

                entity.Property(e => e.Team1).HasColumnName("Team");

                entity.Property(e => e.Tname)
                    .HasColumnName("TName")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Teammasters>(entity =>
            {
                entity.HasKey(e => e.TeamId);

                entity.ToTable("TEAMMasters");

                entity.Property(e => e.Tcode)
                    .IsRequired()
                    .HasColumnName("TCode")
                    .HasMaxLength(5);

                entity.Property(e => e.Tname)
                    .HasColumnName("TName")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<TipoAfiliado>(entity =>
            {
                entity.HasKey(e => e.AfiliadoId);

                entity.Property(e => e.AfiliadoId).ValueGeneratedNever();

                entity.Property(e => e.Detalle)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoTorneo>(entity =>
            {
                entity.HasKey(e => e.TipoId);

                entity.Property(e => e.Descripcion).HasMaxLength(500);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Torneo>(entity =>
            {
                entity.HasKey(e => e.Meetid);

                entity.Property(e => e.ARelaysonly).HasColumnName("A_Relaysonly");

                entity.Property(e => e.AbcfinalOrder)
                    .HasColumnName("abcfinal_order")
                    .HasMaxLength(3);

                entity.Property(e => e.AllowSameEventDupRelayNames).HasColumnName("AllowSameEvent_DupRelayNames");

                entity.Property(e => e.AnyoneOnrelay).HasColumnName("anyone_onrelay");

                entity.Property(e => e.ApnewsDir)
                    .HasColumnName("APNews_Dir")
                    .HasMaxLength(80);

                entity.Property(e => e.ApnewsTeam)
                    .HasColumnName("apnews_team")
                    .HasMaxLength(1);

                entity.Property(e => e.AthleteEarlysurcharge)
                    .HasColumnName("athlete_earlysurcharge")
                    .HasColumnType("money");

                entity.Property(e => e.AthleteEarlysurchargedate)
                    .HasColumnName("athlete_earlysurchargedate")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.AthleteLatesurcharge)
                    .HasColumnName("athlete_latesurcharge")
                    .HasColumnType("money");

                entity.Property(e => e.AthleteLatesurchargedate)
                    .HasColumnName("athlete_latesurchargedate")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.AutobackupInterval).HasColumnName("autobackup_interval");

                entity.Property(e => e.AutoincCompno).HasColumnName("autoinc_compno");

                entity.Property(e => e.BackupDir)
                    .HasColumnName("Backup_Dir")
                    .HasMaxLength(80);

                entity.Property(e => e.BcssaDivbyTimeStd).HasColumnName("BCSSA_DivbyTimeStd");

                entity.Property(e => e.CalcDate)
                    .HasColumnName("Calc_date")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.CheckTimes).HasColumnName("check_times");

                entity.Property(e => e.CopiesToprinter).HasColumnName("copies_toprinter");

                entity.Property(e => e.CountTimeTrialEvents).HasColumnName("CountTimeTrial_Events");

                entity.Property(e => e.CountrelayAlt).HasColumnName("countrelay_alt");

                entity.Property(e => e.CourseOrder)
                    .HasColumnName("course_order")
                    .HasMaxLength(255);

                entity.Property(e => e.CustomQualTimes).HasColumnName("Custom_QualTimes");

                entity.Property(e => e.DiffptsEachdivision).HasColumnName("diffpts_eachdivision");

                entity.Property(e => e.DiffptsMalefemale).HasColumnName("diffpts_malefemale");

                entity.Property(e => e.DirectlyToprinter).HasColumnName("directly_toprinter");

                entity.Property(e => e.DisabledDoNotAdvanceToFinals).HasColumnName("DisabledDoNot_AdvanceToFinals");

                entity.Property(e => e.DisabledIgnoreQualTimeForScoring).HasColumnName("DisabledIgnoreQualTime_ForScoring");

                entity.Property(e => e.DisabledSeedWithAgeGroupIfTimedFinalSuperSeed).HasColumnName("DisabledSeedWithAgeGroup_IfTimedFinalSuperSeed");

                entity.Property(e => e.DisplayActualEntryTime).HasColumnName("Display_ActualEntryTime");

                entity.Property(e => e.DisplayNtforTimesUnder5Sec).HasColumnName("DisplayNTfor_TimesUnder5Sec");

                entity.Property(e => e.DoubleEndedsplits).HasColumnName("double_endedsplits");

                entity.Property(e => e.DqcodesType)
                    .HasColumnName("DQCodes_Type")
                    .HasMaxLength(1);

                entity.Property(e => e.DualEvenodd).HasColumnName("dual_evenodd");

                entity.Property(e => e.DualseedingAltunusedlane).HasColumnName("dualseeding_altunusedlane");

                entity.Property(e => e.DualteamLane1).HasColumnName("dualteam_lane1");

                entity.Property(e => e.DualteamLane10).HasColumnName("dualteam_lane10");

                entity.Property(e => e.DualteamLane11).HasColumnName("dualteam_lane11");

                entity.Property(e => e.DualteamLane12).HasColumnName("dualteam_lane12");

                entity.Property(e => e.DualteamLane2).HasColumnName("dualteam_lane2");

                entity.Property(e => e.DualteamLane3).HasColumnName("dualteam_lane3");

                entity.Property(e => e.DualteamLane4).HasColumnName("dualteam_lane4");

                entity.Property(e => e.DualteamLane5).HasColumnName("dualteam_lane5");

                entity.Property(e => e.DualteamLane6).HasColumnName("dualteam_lane6");

                entity.Property(e => e.DualteamLane7).HasColumnName("dualteam_lane7");

                entity.Property(e => e.DualteamLane8).HasColumnName("dualteam_lane8");

                entity.Property(e => e.DualteamLane9).HasColumnName("dualteam_lane9");

                entity.Property(e => e.EnterAges).HasColumnName("Enter_ages");

                entity.Property(e => e.EnterAthStat).HasColumnName("Enter_AthStat");

                entity.Property(e => e.EnterBirthcentury).HasColumnName("Enter_birthcentury");

                entity.Property(e => e.EnterBirthdate).HasColumnName("Enter_birthdate");

                entity.Property(e => e.EnterCitizenof).HasColumnName("enter_citizenof");

                entity.Property(e => e.EnterSchoolyr).HasColumnName("Enter_schoolyr");

                entity.Property(e => e.EnterkeyAstab).HasColumnName("enterkey_astab");

                entity.Property(e => e.EntryDeadline)
                    .HasColumnName("entry_deadline")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.EntryEligibilityDate)
                    .HasColumnName("EntryEligibility_date")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.EntryMsg)
                    .HasColumnName("entry_msg")
                    .HasMaxLength(80);

                entity.Property(e => e.EntryOpenDate)
                    .HasColumnName("entry_OpenDate")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.EntrylimitsWarn).HasColumnName("entrylimits_warn");

                entity.Property(e => e.EntrymaxTotal).HasColumnName("entrymax_total");

                entity.Property(e => e.EntryqualFaster).HasColumnName("entryqual_faster");

                entity.Property(e => e.ExcludeNtentriesWhenImporting).HasColumnName("ExcludeNTEntries_WhenImporting");

                entity.Property(e => e.ExhInfinal).HasColumnName("exh_infinal");

                entity.Property(e => e.ExportDir)
                    .HasColumnName("Export_Dir")
                    .HasMaxLength(80);

                entity.Property(e => e.FacilitySurcharge)
                    .HasColumnName("Facility_Surcharge")
                    .HasColumnType("money");

                entity.Property(e => e.FastestHeatSomeLanesDoNotScore).HasColumnName("FastestHeat_SomeLanesDoNotScore");

                entity.Property(e => e.FirstinitialFulllastname).HasColumnName("firstinitial_fulllastname");

                entity.Property(e => e.FlagFastestRecordOnly).HasColumnName("Flag_FastestRecordOnly");

                entity.Property(e => e.FlagOverachievers).HasColumnName("flag_overachievers");

                entity.Property(e => e.FlagUnderachievers).HasColumnName("flag_underachievers");

                entity.Property(e => e.FlatHtmlDir)
                    .HasColumnName("FlatHtml_Dir")
                    .HasMaxLength(80);

                entity.Property(e => e.FlightedBasedOnResultsTime).HasColumnName("Flighted_BasedOnResultsTime");

                entity.Property(e => e.FlightedFlightcount).HasColumnName("flighted_flightcount");

                entity.Property(e => e.FlightedInclDq).HasColumnName("flighted_inclDQ");

                entity.Property(e => e.FlightedMinentries).HasColumnName("flighted_minentries");

                entity.Property(e => e.ForeignGetteampoints).HasColumnName("foreign_getteampoints");

                entity.Property(e => e.ForeignInfinal).HasColumnName("foreign_infinal");

                entity.Property(e => e.ImportDir)
                    .HasColumnName("Import_Dir")
                    .HasMaxLength(80);

                entity.Property(e => e.IncludeSanction).HasColumnName("include_sanction");

                entity.Property(e => e.IncludeSwimupsinteamscore).HasColumnName("include_swimupsinteamscore");

                entity.Property(e => e.IndmaxPerath).HasColumnName("indmax_perath");

                entity.Property(e => e.IndmaxadvancePerteam).HasColumnName("indmaxadvance_perteam");

                entity.Property(e => e.IndmaxscorersPerteam).HasColumnName("indmaxscorers_perteam");

                entity.Property(e => e.IndtopmanyAwards).HasColumnName("indtopmany_awards");

                entity.Property(e => e.IndtopmanyAwardsSr).HasColumnName("indtopmany_awardsSr");

                entity.Property(e => e.IsCanadianMasters).HasColumnName("IsCanadian_Masters");

                entity.Property(e => e.LanguageChoice)
                    .HasColumnName("language_choice")
                    .HasMaxLength(20);

                entity.Property(e => e.LastUpdated)
                    .HasColumnName("Last_updated")
                    .HasMaxLength(40);

                entity.Property(e => e.LastnameAsinitial).HasColumnName("lastname_asinitial");

                entity.Property(e => e.LastnameFirst).HasColumnName("Lastname_first");

                entity.Property(e => e.MastersAgegrpsskip).HasColumnName("masters_agegrpsskip");

                entity.Property(e => e.MastersBytimeonly).HasColumnName("masters_bytimeonly");

                entity.Property(e => e.MastersIndlowage).HasColumnName("masters_indlowage");

                entity.Property(e => e.MastersRellowage).HasColumnName("masters_rellowage");

                entity.Property(e => e.MaxageforCfinal).HasColumnName("maxagefor_cfinal");

                entity.Property(e => e.MaxforeignInfinal).HasColumnName("maxforeign_infinal");

                entity.Property(e => e.MeetAddr1)
                    .HasColumnName("Meet_addr1")
                    .HasMaxLength(30);

                entity.Property(e => e.MeetAddr2)
                    .HasColumnName("Meet_addr2")
                    .HasMaxLength(30);

                entity.Property(e => e.MeetAltitude).HasColumnName("Meet_altitude");

                entity.Property(e => e.MeetCity)
                    .HasColumnName("Meet_city")
                    .HasMaxLength(30);

                entity.Property(e => e.MeetClass).HasColumnName("Meet_class");

                entity.Property(e => e.MeetCountry)
                    .HasColumnName("Meet_country")
                    .HasMaxLength(3);

                entity.Property(e => e.MeetCourse).HasColumnName("Meet_course");

                entity.Property(e => e.MeetEnd)
                    .HasColumnName("Meet_end")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.MeetHeader1)
                    .HasColumnName("Meet_header1")
                    .HasMaxLength(75);

                entity.Property(e => e.MeetHeader2)
                    .HasColumnName("Meet_header2")
                    .HasMaxLength(75);

                entity.Property(e => e.MeetHostlsc)
                    .HasColumnName("Meet_hostlsc")
                    .HasMaxLength(3);

                entity.Property(e => e.MeetIdformat).HasColumnName("Meet_idformat");

                entity.Property(e => e.MeetLocation)
                    .HasColumnName("Meet_location")
                    .HasMaxLength(45);

                entity.Property(e => e.MeetLsc)
                    .HasColumnName("Meet_lsc")
                    .HasMaxLength(3);

                entity.Property(e => e.MeetMeetstyle).HasColumnName("meet_meetstyle");

                entity.Property(e => e.MeetMeettype).HasColumnName("Meet_meettype");

                entity.Property(e => e.MeetName1)
                    .HasColumnName("Meet_name1")
                    .HasMaxLength(45);

                entity.Property(e => e.MeetNumlanes).HasColumnName("meet_numlanes");

                entity.Property(e => e.MeetStart)
                    .HasColumnName("Meet_start")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.MeetState)
                    .HasColumnName("Meet_state")
                    .HasMaxLength(3);

                entity.Property(e => e.MeetUsmastersMeetId)
                    .HasColumnName("Meet_USMastersMeetID")
                    .HasMaxLength(20);

                entity.Property(e => e.MeetZip)
                    .HasColumnName("Meet_zip")
                    .HasMaxLength(10);

                entity.Property(e => e.MilitaryTime).HasColumnName("military_time");

                entity.Property(e => e.MixedRelaysDividedPoints).HasColumnName("MixedRelays_DividedPoints");

                entity.Property(e => e.NonConformingPoolFactor).HasColumnName("NonConforming_PoolFactor");

                entity.Property(e => e.NonconformLast).HasColumnName("nonconform_last");

                entity.Property(e => e.OpenLowage).HasColumnName("open_lowage");

                entity.Property(e => e.OpenSeniorNone)
                    .HasColumnName("open_senior_none")
                    .HasMaxLength(1);

                entity.Property(e => e.PenaltyPtsForNs).HasColumnName("PenaltyPts_ForNS");

                entity.Property(e => e.PentscoringUsedqtime).HasColumnName("pentscoring_usedqtime");

                entity.Property(e => e.PointsAwardedForDq).HasColumnName("PointsAwarded_ForDQ");

                entity.Property(e => e.PointsAwardedForExh).HasColumnName("PointsAwarded_ForExh");

                entity.Property(e => e.PointsAwardedForNt).HasColumnName("PointsAwarded_ForNT");

                entity.Property(e => e.PointsAwardedForScratch).HasColumnName("PointsAwarded_ForScratch");

                entity.Property(e => e.PointsbasedonSeedtime).HasColumnName("pointsbasedon_seedtime");

                entity.Property(e => e.PointsforOverachievers).HasColumnName("pointsfor_overachievers");

                entity.Property(e => e.PointsforUnderachievers).HasColumnName("pointsfor_underachievers");

                entity.Property(e => e.Pool1Name)
                    .HasColumnName("Pool1_name")
                    .HasMaxLength(30);

                entity.Property(e => e.Pool2Name)
                    .HasColumnName("Pool2_name")
                    .HasMaxLength(30);

                entity.Property(e => e.PrelimheatsCircle).HasColumnName("prelimheats_circle");

                entity.Property(e => e.PrelimheatsCircledist).HasColumnName("prelimheats_circledist");

                entity.Property(e => e.PunctNames).HasColumnName("Punct_names");

                entity.Property(e => e.PunctRecholders).HasColumnName("Punct_recholders");

                entity.Property(e => e.PunctTeams).HasColumnName("Punct_teams");

                entity.Property(e => e.QualNonConformCourseUseMinStd).HasColumnName("QualNonConformCourse_UseMinStd");

                entity.Property(e => e.RankDisabledByPoints).HasColumnName("RankDisabled_ByPoints");

                entity.Property(e => e.ReadOnly).HasColumnName("Read_Only");

                entity.Property(e => e.RefereeHomphone)
                    .HasColumnName("referee_homphone")
                    .HasMaxLength(20);

                entity.Property(e => e.RefereeName)
                    .HasColumnName("referee_name")
                    .HasMaxLength(30);

                entity.Property(e => e.RefereeOffphone)
                    .HasColumnName("referee_offphone")
                    .HasMaxLength(20);

                entity.Property(e => e.RelayNamesLinkByLsc).HasColumnName("RelayNames_LinkByLSC");

                entity.Property(e => e.RelayOnlySurcharge)
                    .HasColumnName("RelayOnly_Surcharge")
                    .HasColumnType("money");

                entity.Property(e => e.RelaysAlternateTwoFastestFirst).HasColumnName("RelaysAlternate_TwoFastestFirst");

                entity.Property(e => e.RelaysAs4x100Style).HasColumnName("RelaysAs_4x100Style");

                entity.Property(e => e.RelmaxPerath).HasColumnName("relmax_perath");

                entity.Property(e => e.RelmaxadvancePerteam).HasColumnName("relmaxadvance_perteam");

                entity.Property(e => e.RelmaxscorersPerteam).HasColumnName("relmaxscorers_perteam");

                entity.Property(e => e.ReltopmanyAwards).HasColumnName("reltopmany_awards");

                entity.Property(e => e.ReltopmanyAwardsSr).HasColumnName("reltopmany_awardsSr");

                entity.Property(e => e.ReportHeadersonly).HasColumnName("report_headersonly");

                entity.Property(e => e.RestoreFromDir)
                    .HasColumnName("RestoreFrom_Dir")
                    .HasMaxLength(80);

                entity.Property(e => e.RestoreToDir)
                    .HasColumnName("RestoreTo_Dir")
                    .HasMaxLength(80);

                entity.Property(e => e.SanctionNumber)
                    .HasColumnName("Sanction_number")
                    .HasMaxLength(20);

                entity.Property(e => e.ScbdCycle).HasColumnName("scbd_cycle");

                entity.Property(e => e.ScbdCycleseconds).HasColumnName("scbd_cycleseconds");

                entity.Property(e => e.ScbdNames).HasColumnName("scbd_names");

                entity.Property(e => e.ScbdPort).HasColumnName("scbd_port");

                entity.Property(e => e.ScbdPunctuation).HasColumnName("scbd_punctuation");

                entity.Property(e => e.ScbdRelaynames).HasColumnName("scbd_relaynames");

                entity.Property(e => e.ScbdVendor)
                    .HasColumnName("scbd_vendor")
                    .HasMaxLength(4);

                entity.Property(e => e.ScoreArelayonly).HasColumnName("score_Arelayonly");

                entity.Property(e => e.ScoreFastestheatonly).HasColumnName("score_fastestheatonly");

                entity.Property(e => e.ScoreonlyIfexceedqualtime).HasColumnName("scoreonly_ifexceedqualtime");

                entity.Property(e => e.ScoresAfterevt).HasColumnName("Scores_afterevt");

                entity.Property(e => e.SeedExhlast).HasColumnName("seed_exhlast");

                entity.Property(e => e.ShowAgeandBirthYear).HasColumnName("Show_AgeandBirthYear");

                entity.Property(e => e.ShowCountrycode).HasColumnName("Show_countrycode");

                entity.Property(e => e.ShowFirstNameOverPreferred).HasColumnName("ShowFirstName_OverPreferred");

                entity.Property(e => e.ShowHyTekDecimals).HasColumnName("Show_HyTekDecimals");

                entity.Property(e => e.ShowInitial).HasColumnName("show_initial");

                entity.Property(e => e.ShowSecondclub).HasColumnName("Show_secondclub");

                entity.Property(e => e.ShowYearInPlaceOfAge).HasColumnName("ShowYear_InPlaceOfAge");

                entity.Property(e => e.ShowathleteStatus).HasColumnName("showathlete_status");

                entity.Property(e => e.SortTeamCombosByTeamName).HasColumnName("SortTeamCombos_ByTeamName");

                entity.Property(e => e.SpecialParapoints).HasColumnName("special_parapoints");

                entity.Property(e => e.SpecialPoints).HasColumnName("special_points");

                entity.Property(e => e.StrictEvenodd).HasColumnName("strict_evenodd");

                entity.Property(e => e.StrictEvenoddfastestheatonly).HasColumnName("strict_evenoddfastestheatonly");

                entity.Property(e => e.SuppressArelay).HasColumnName("suppress_Arelay");

                entity.Property(e => e.SuppressJd).HasColumnName("suppress_jd");

                entity.Property(e => e.SuppressLsc).HasColumnName("suppress_lsc");

                entity.Property(e => e.SuppressResultsAdvQ).HasColumnName("Suppress_ResultsAdvQ");

                entity.Property(e => e.SuppressSmallx).HasColumnName("suppress_smallx");

                entity.Property(e => e.SuppressSplitsForDqs).HasColumnName("Suppress_SplitsForDQs");

                entity.Property(e => e.SuppressSplitsForDqsRelay).HasColumnName("Suppress_SplitsForDQsRelay");

                entity.Property(e => e.SuppressTimeStdAbbr).HasColumnName("Suppress_TimeStdAbbr");

                entity.Property(e => e.SuppressTimesNotMeetQualTime).HasColumnName("SuppressTimes_NotMeetQualTime");

                entity.Property(e => e.SwimmerSurcharge)
                    .HasColumnName("swimmer_surcharge")
                    .HasColumnType("money");

                entity.Property(e => e.TeamEvenlanes).HasColumnName("team_evenlanes");

                entity.Property(e => e.TeamOddlanes).HasColumnName("team_oddlanes");

                entity.Property(e => e.TeamSurcharge)
                    .HasColumnName("team_surcharge")
                    .HasColumnType("money");

                entity.Property(e => e.ThirteenandoverAssenior).HasColumnName("thirteenandover_assenior");

                entity.Property(e => e.TimeAdjMethod)
                    .HasColumnName("TimeAdj_Method")
                    .HasMaxLength(1);

                entity.Property(e => e.TimedfinalCircleseed).HasColumnName("timedfinal_circleseed");

                entity.Property(e => e.TimedfinalnonconformLast).HasColumnName("timedfinalnonconform_last");

                entity.Property(e => e.TimerPort).HasColumnName("timer_port");

                entity.Property(e => e.TimerVendor)
                    .HasColumnName("timer_vendor")
                    .HasMaxLength(4);

                entity.Property(e => e.TurnonAutobackup).HasColumnName("turnon_autobackup");

                entity.Property(e => e.UcaseNames).HasColumnName("ucase_names");

                entity.Property(e => e.UcaseRecholders).HasColumnName("ucase_recholders");

                entity.Property(e => e.UcaseTeams).HasColumnName("ucase_teams");

                entity.Property(e => e.UnderEventname).HasColumnName("under_eventname");

                entity.Property(e => e.UseAltTeamAbbr).HasColumnName("Use_AltTeamAbbr");

                entity.Property(e => e.UseCompnumbers).HasColumnName("use_compnumbers");

                entity.Property(e => e.UseHometown).HasColumnName("Use_hometown");

                entity.Property(e => e.UseNonConformingPoolFactor).HasColumnName("UseNonConforming_PoolFactor");

                entity.Property(e => e.UseeventsexTeamscore).HasColumnName("useeventsex_teamscore");

                entity.Property(e => e.UsingTwopools).HasColumnName("Using_twopools");

                entity.Property(e => e.WinMm).HasColumnName("win_mm");
            });

            modelBuilder.Entity<TorneoDestacado>(entity =>
            {
                entity.HasKey(e => e.DestacadoId);
            });

            modelBuilder.Entity<TorneoDestacadoMasters>(entity =>
            {
                entity.HasKey(e => e.DestacadoId);
            });

            modelBuilder.Entity<Traspasos>(entity =>
            {
                entity.HasKey(e => e.TraspasoId);

                entity.Property(e => e.FechaDeTraspaso)
                    .HasColumnName("Fecha de traspaso")
                    .HasColumnType("date");

                entity.Property(e => e.NumeroDeOperacion)
                    .IsRequired()
                    .HasColumnName("Numero de operacion")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroDeTraspasos).HasColumnName("Numero de traspasos");

                entity.Property(e => e.TraspasosRestantes).HasColumnName("Traspasos restantes");

                entity.HasOne(d => d.Club)
                    .WithMany(p => p.Traspasos)
                    .HasForeignKey(d => d.ClubId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Traspasos_Club");

                entity.HasOne(d => d.Isncripcion)
                    .WithMany(p => p.Traspasos)
                    .HasForeignKey(d => d.IsncripcionId)
                    .HasConstraintName("FK_Traspasos_Inscripciones");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Traspasos)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Traspasos_Usuario");
            });

            modelBuilder.Entity<TraspasosEnEspera>(entity =>
            {
                entity.HasKey(e => e.EEsperaId);

                entity.Property(e => e.EEsperaId).HasColumnName("eEsperaId");

                entity.Property(e => e.Dni)
                    .IsRequired()
                    .HasColumnName("DNI")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.HasOne(d => d.ClubSolicitanteNavigation)
                    .WithMany(p => p.TraspasosEnEspera)
                    .HasForeignKey(d => d.ClubSolicitante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TraspasosEnEspera_Club");

                entity.HasOne(d => d.Isncripcion)
                    .WithMany(p => p.TraspasosEnEspera)
                    .HasForeignKey(d => d.IsncripcionId)
                    .HasConstraintName("FK_TraspasosEnEspera_Inscripciones");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario1)
                    .IsRequired()
                    .HasColumnName("Usuario")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Club)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.ClubId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_Club");

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.RolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_Rol");
            });

            modelBuilder.Entity<Vivo>(entity =>
            {
                entity.Property(e => e.Directorio)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(120);
            });

            modelBuilder.Entity<Vouchers>(entity =>
            {
                entity.HasKey(e => e.VoucherId);

                entity.Property(e => e.FechaDeCreacion)
                    .HasColumnName("Fecha de creacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaDeModificacion)
                    .HasColumnName("Fecha de modificacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.NroOperacion)
                    .IsRequired()
                    .HasColumnName("Nro. operacion")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroDeAfiliados).HasColumnName("Numero de afiliados");

                entity.Property(e => e.NumeroDeReafiliados).HasColumnName("Numero de reafiliados");

                entity.Property(e => e.NumeroDeVinculados).HasColumnName("Numero de vinculados");

                entity.HasOne(d => d.Club)
                    .WithMany(p => p.Vouchers)
                    .HasForeignKey(d => d.ClubId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vouchers_Club");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Vouchers)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vouchers_Usuario");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
