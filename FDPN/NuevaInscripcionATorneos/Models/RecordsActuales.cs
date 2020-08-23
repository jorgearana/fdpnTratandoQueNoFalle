using System;
using System.Collections.Generic;

namespace NuevaInscripcionATorneos.Models
{
    public partial class RecordsActuales
    {
        public int RecordId { get; set; }
        public DateTime Fecha { get; set; }
        public string Torneo { get; set; }
        public int PruebaId { get; set; }
        public int EdadId { get; set; }
        public double TiempoSegundos { get; set; }
        public string Nombre1 { get; set; }
        public string Nombre2 { get; set; }
        public string Nombre3 { get; set; }
        public string Nombre4 { get; set; }
        public double? Split1 { get; set; }
        public double? Split2 { get; set; }
        public double? Split3 { get; set; }
        public string Equipo { get; set; }
        public int TipoId { get; set; }
        public string PiscinaId { get; set; }
        public double? Split4 { get; set; }

        public virtual RecordsEdades Edad { get; set; }
        public virtual Piscinas Piscina { get; set; }
        public virtual RecordsPruebas Prueba { get; set; }
        public virtual RecordTipo Tipo { get; set; }
    }
}
