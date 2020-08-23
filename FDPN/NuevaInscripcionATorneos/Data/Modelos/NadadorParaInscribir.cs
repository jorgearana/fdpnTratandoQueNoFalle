using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NuevaInscripcionATorneos.Helpers;
using NuevaInscripcionATorneos.Models;

namespace NuevaInscripcionATorneos.Data.Modelos
{
    
    public class NadadorParaInscribir
    {
       
        public string DNI { get; set; }
        public string Nombre { get; set; }
        public string Paterno   { get; set; }
        public string Materno { get; set; }
        public DateTime Nacimiento { get; set; }
        public string Sexo { get; set; }
        public int Edad { get; set; }

        public int InscripcionId { get; set; }
        public string Estado { get; set; }

        public NadadorParaInscribir(string _DNI, string _Nombre, string _Paterno, string _Materno, DateTime _Nacimiento, string _Sexo , int _InscripcionId, int _Estado)
        {
            DNI = _DNI;
            Nombre = _Nombre;
            Paterno = _Paterno;
            Materno = _Materno;
            Nacimiento = _Nacimiento;
            Sexo = _Sexo;
            
            Edad = DateTime.Today.Year - Nacimiento.Year;
            InscripcionId = _InscripcionId;
            if (DateTime.Today < Nacimiento.AddYears(Edad)) Edad--;

            switch(_Estado)
            {
                case 1:
                    Estado = "Inactivo";
                    break;
                case 2:
                    Estado = "En espera";
                    break;
                case 3:
                    Estado = "Activo";
                    break;
            }
        }

    }
}
