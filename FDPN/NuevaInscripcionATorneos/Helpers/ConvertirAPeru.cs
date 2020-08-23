using NuevaInscripcionATorneos.Data.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NuevaInscripcionATorneos.Helpers
{
    public static class ConvertirAPeru
    {
        public static  DateTime ToPeru(DateTime hora)
        {
            TimeZoneInfo husoPeru = TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time");
            DateTime Peru = TimeZoneInfo.ConvertTime(hora, husoPeru);
            return Peru;
        }


        public static string ConvertirDeSegundosATiempo(float segundos)
        {
            string tiempo = "";
            int num = (int)segundos;
            int hor = (num / 3600);
            int min = ((num - hor * 3600) / 60);
            int seg = num - (hor * 3600 + min * 60);
            double cent = Math.Round((segundos - num) * 100);

            if (hor > 0)
            {
                tiempo = hor.ToString();
            }
            string centesimas = ((int)cent).ToString("00");
            tiempo += min.ToString("00") + ":" + seg.ToString("00") + "." + centesimas;
            return tiempo;
        }

        public static float ConvertirDeTiempoASegundos(string tiempo)
        {
            if (tiempo != null)
            {
                tiempo = tiempo.Trim();
                int posiciondospuntos = tiempo.IndexOf(":");
                int posicionpuntdo = tiempo.IndexOf(".");
                int minutos = 0;
                int segundos = 0;

                //Revisar esto cuando se haga inscripciones con tiempos de más de una hora
                //if (tiempo.Length > 8)
                //{
                //    int horas = tiempo.Substring()
                //}

                string dato;
                if (posiciondospuntos >= 0)
                {
                    dato = tiempo.Substring(0, posiciondospuntos);
                    minutos = Int32.Parse(dato);
                    dato = tiempo.Substring(posiciondospuntos + 1, 2); // medio extraño pero funciona
                    segundos = Int32.Parse(dato);
                }
                else if (posiciondospuntos == 0)
                {
                    dato = tiempo.Substring(0, posicionpuntdo);
                    segundos = Int32.Parse(dato);
                }
                else
                {
                    dato = tiempo.Substring(0, posicionpuntdo);
                    segundos = Int32.Parse(dato);
                }

                int largodecadena = tiempo.Length;
                if (largodecadena - (posicionpuntdo + 1) > 1)
                {
                    dato = tiempo.Substring(posicionpuntdo + 1, 2);
                }
                else
                {
                    dato = tiempo.Substring(posicionpuntdo + 1, 1) + "0";
                }




                int centesimas = Int32.Parse(dato);
                float segundosfloat = (minutos * 6000 + segundos * 100 + centesimas); //Como los datos son int no pueden dividirse entre 100
                float a = segundosfloat / 100;
                return (a);
            }
            else
            {
                return 0;
            }

        }


    }
}
