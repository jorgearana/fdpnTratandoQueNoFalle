using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InscripcionACurso.Helpers
{
    public class ConvertirAPeru
    {
        public DateTime ToPeru(DateTime hora)
        {

            TimeZoneInfo husoPeru = TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time");
            DateTime Peru = TimeZoneInfo.ConvertTime(hora, husoPeru);
            return Peru;
        }

    
    }


}