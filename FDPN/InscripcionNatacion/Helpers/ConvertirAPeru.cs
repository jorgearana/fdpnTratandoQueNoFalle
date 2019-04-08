using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InscripcionNatacion.Helpers
{
    public class ConvertirAPeru
    {
        public DateTime ToPeru(DateTime hora)
        {

            TimeZoneInfo husoPeru = TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time");
            DateTime Peru = TimeZoneInfo.ConvertTime(hora, husoPeru);
            return Peru;
        }

        public string AMarca(double inicial)
        {

            double resto = 0;
            var horas = (int)(inicial / 3600);
            resto = inicial - horas * 3600;
            var minutos = (int)(resto / 60);
            resto = resto - minutos * 60;
            var segundos = (int)(resto / 1);
            resto = resto - segundos;
            var centesimas = resto * 100;

            string Marca = "";
            if (horas > 0)
            {
                Marca = horas.ToString() + ":";
            }
            if (minutos > 0)
            {
                Marca = Marca + minutos.ToString("00") + ":";
            }
            Marca = Marca + segundos.ToString("00") + "." + centesimas.ToString("00");
            return Marca;
        }

        public double ATiempo(string marca)
        {
            int largocadena = marca.Count();
            int horas = 0;
            int minutos = 0;
            int segundos = 0;
            double centesimas = 0;
            int posicioncaracter = marca.IndexOf(":");
            string resto = marca;
            if (largocadena > 9)
            {
                string numerohoras = resto.Substring(0, posicioncaracter);
                horas = Int32.Parse(numerohoras);
                resto = resto.Substring(posicioncaracter + 1);
            }
            posicioncaracter = resto.IndexOf(":");
            if (posicioncaracter > 0)
            {
                string numerominutos = resto.Substring(0, posicioncaracter);
                minutos = Int32.Parse(numerominutos);
                resto = resto.Substring(posicioncaracter + 1);
            }

            posicioncaracter = resto.IndexOf(".");
            string numerosegundos = resto.Substring(0, posicioncaracter);
            segundos = Int32.Parse(numerosegundos);
            resto = resto.Substring(posicioncaracter + 1);
            centesimas = Int32.Parse(resto);
            double respuesta = horas * 3600 + minutos * 60 + segundos + centesimas / 100;
            return respuesta;
        }

        public string AFormatoMarca(double inicial)
        {

            double resto = 0;
            var horas = (int)(inicial / 1000000);
            resto = inicial - horas * 1000000;
            var minutos = (int)(resto / 10000);
            resto = resto - minutos * 10000;
            var segundos = (int)(resto / 100);
            resto = resto - segundos * 100;
            var centesimas = resto;

            string Marca = "";
            if (horas > 0)
            {
                Marca = horas.ToString() + ":";
            }
            if (minutos > 0)
            {
                Marca = Marca + minutos.ToString("00") + ":";
            }
            Marca = Marca + segundos.ToString("00") + "." + centesimas.ToString("00");
            return Marca;
        }

    }
}