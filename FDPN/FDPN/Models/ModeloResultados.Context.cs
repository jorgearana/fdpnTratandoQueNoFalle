﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DB_9B1F4C_MVCcompetenciasEntities : DbContext
    {
        public DB_9B1F4C_MVCcompetenciasEntities()
            : base("name=DB_9B1F4C_MVCcompetenciasEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Athlete> Athlete { get; set; }
        public virtual DbSet<Atletas> Atletas { get; set; }
        public virtual DbSet<BASETIMES> BASETIMES { get; set; }
        public virtual DbSet<Calendario> Calendario { get; set; }
        public virtual DbSet<CategoriaNoticia> CategoriaNoticia { get; set; }
        public virtual DbSet<Comentarios> Comentarios { get; set; }
        public virtual DbSet<Disciplina> Disciplina { get; set; }
        public virtual DbSet<Encuentros> Encuentros { get; set; }
        public virtual DbSet<Entradas> Entradas { get; set; }
        public virtual DbSet<Equipos> Equipos { get; set; }
        public virtual DbSet<Eventos> Eventos { get; set; }
        public virtual DbSet<Fotos> Fotos { get; set; }
        public virtual DbSet<Goleadores> Goleadores { get; set; }
        public virtual DbSet<Hoja1_> Hoja1_ { get; set; }
        public virtual DbSet<Hoja2_> Hoja2_ { get; set; }
        public virtual DbSet<Jugadores> Jugadores { get; set; }
        public virtual DbSet<MarcasMinimas> MarcasMinimas { get; set; }
        public virtual DbSet<MEET> MEET { get; set; }
        public virtual DbSet<Modals> Modals { get; set; }
        public virtual DbSet<Noticias> Noticias { get; set; }
        public virtual DbSet<Pais> Pais { get; set; }
        public virtual DbSet<PosicionFinal> PosicionFinal { get; set; }
        public virtual DbSet<Pruebas> Pruebas { get; set; }
        public virtual DbSet<Resultados> Resultados { get; set; }
        public virtual DbSet<RESULTS> RESULTS { get; set; }
        public virtual DbSet<Sesion> Sesion { get; set; }
        public virtual DbSet<SessionItem> SessionItem { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TEAM> TEAM { get; set; }
        public virtual DbSet<Torneo> Torneo { get; set; }
        public virtual DbSet<TorneoDestacado> TorneoDestacado { get; set; }
        public virtual DbSet<Vivo> Vivo { get; set; }
        public virtual DbSet<Consulta> Consulta { get; set; }
        public virtual DbSet<Estilos> Estilos { get; set; }
        public virtual DbSet<MultiEdad> MultiEdad { get; set; }
        public virtual DbSet<Query> Query { get; set; }
        public virtual DbSet<Session> Session { get; set; }
        public virtual DbSet<Sessitem> Sessitem { get; set; }
    }
}