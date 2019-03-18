using FDPN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FDPN.ViewModels.Resultados
{
    public class RankingViewModel
    {
        public List<RESULTS> resultados { get; set; }
        public Dictionary<string, string> Sexo { get; set; }
        public List<string> Periodo { get; set; }
        public Dictionary<string, string> piscinas { get; set; }
        public List<int> edadminima { get; set; }
        public List<int> edadmaxima { get; set; }
        public List<string> Estilos { get; set; }
        public List<int> distancias { get; set; }
        public string estilo { get; set; }
        public int distancia { get; set; }
        public string piscina { get; set; }
        public int Minima { get; set; }
        public int Maxima { get; set; }
        public string sex { get; set; }


        public RankingViewModel()
        {
            resultados = new List<RESULTS>();
            Sexo = new Dictionary<string, string>
            {
                { "F", "Damas"},
                {"M", "Varones" }
            };
            piscinas = new Dictionary<string, string>
            {
                {"L", "Larga" },
                {"S", "Corta" }
            };
            edadminima = new List<int> { 0, 9, 10, 11, 12, 13, 14, 15, 16, 17 };
            edadmaxima = new List<int> { 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 109 };
            Periodo = new List<string> { "Todo", "Últimos 6 meses", "Últimos 12 meses" };
            distancias = new List<int> { 50, 100, 200, 400, 800, 1500 };
            Estilos = new List<string> { "Libre", "Espalda", "Mariposa", "Pecho", "Combinado" };


            int anno = DateTime.Now.Year;
            for(int i= anno; i>1999; i--)
            {
                Periodo.Add("Año " + i.ToString());
            }
        }
    }
}
