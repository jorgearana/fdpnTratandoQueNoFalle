using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class PoloTorneo
    {
        public PoloTorneo()
        {
            PoloFechas = new HashSet<PoloFechas>();
            PoloGoleadores = new HashSet<PoloGoleadores>();
            PoloJugadores = new HashSet<PoloJugadores>();
            PoloPartidos = new HashSet<PoloPartidos>();
            PoloPosicion = new HashSet<PoloPosicion>();
            PoloPosicionFinal = new HashSet<PoloPosicionFinal>();
            PoloResultados = new HashSet<PoloResultados>();
            PoloRondas = new HashSet<PoloRondas>();
            PoloSetupTorneo = new HashSet<PoloSetupTorneo>();
        }

        public int TorneoId { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaCierre { get; set; }
        public int EdadMaxima { get; set; }
        public int EdadMinima { get; set; }

        public virtual ICollection<PoloFechas> PoloFechas { get; set; }
        public virtual ICollection<PoloGoleadores> PoloGoleadores { get; set; }
        public virtual ICollection<PoloJugadores> PoloJugadores { get; set; }
        public virtual ICollection<PoloPartidos> PoloPartidos { get; set; }
        public virtual ICollection<PoloPosicion> PoloPosicion { get; set; }
        public virtual ICollection<PoloPosicionFinal> PoloPosicionFinal { get; set; }
        public virtual ICollection<PoloResultados> PoloResultados { get; set; }
        public virtual ICollection<PoloRondas> PoloRondas { get; set; }
        public virtual ICollection<PoloSetupTorneo> PoloSetupTorneo { get; set; }
    }
}
