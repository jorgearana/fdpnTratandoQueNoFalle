using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InscripcionNatacion.Helpers;
using InscripcionNatacion.ViewModels.Exportar;
using OfficeOpenXml;
using Rotativa;
using System.Text;
using FDPN.Models;

namespace InscripcionNatacion.Controllers
{
    public class ExportarController : BASEController
    {
       
        Repository repository = new Repository();
        // GET: Exportar
        public ActionResult ExportarHYV(int meetid)
        {
            CrearArchivo(meetid);
            return View();
        }

        [HttpPost]
        public ActionResult ExportarEntrenadoresyDelegados(int MeetId)
        {
           
            List<Delegados>delegados = db.Delegados.Where(x => x.MeetId == MeetId).ToList();
            List<EntrenadorInscrito> entrenadores = db.EntrenadorInscrito.Where(x => x.MeetId == MeetId).ToList();
            Torneo torneo = db.Torneo.Find(MeetId);

            ExcelPackage ExcelFile = new ExcelPackage();
            ExcelWorksheet resumen = ExcelFile.Workbook.Worksheets.Add("Entrenadores");

            resumen.Cells[1, 1].Value = "Relación de entrenadores";
            resumen.Cells[2, 1].Value = torneo.Meet_name1;

            int i = 4; // a partir de la línea 5 se escribirán las inscripciones
            
            foreach (var entrenador in entrenadores)
            {

                resumen.Cells[i, 1].Value = entrenador.Entrenadores.Nombre;
                resumen.Cells[i, 2].Value = entrenador.Entrenadores.Paterno;
                resumen.Cells[i, 3].Value = entrenador.Entrenadores.Usuario.Club.NombreUsuario;
                i += 1;
            }

            resumen = ExcelFile.Workbook.Worksheets.Add("Delegados");

            resumen.Cells[1, 1].Value = "Relación de entrenadores";
            resumen.Cells[2, 1].Value = torneo.Meet_name1;

             i = 4; // a partir de la línea 5 se escribirán las inscripciones
           
            foreach (var delegado in delegados)
            {

                resumen.Cells[i, 1].Value = delegado.Nombre;
                resumen.Cells[i, 2].Value = delegado.Apellido;
                resumen.Cells[i, 3].Value = delegado.Usuario.Club.NombreUsuario;
                i += 1;
            }

            string handle = Guid.NewGuid().ToString();

            using (MemoryStream memoryStream = new MemoryStream())
            {
                ExcelFile.SaveAs(memoryStream);
                memoryStream.Position = 0;
                TempData[handle] = memoryStream.ToArray();
            }
            return new JsonResult()
            {
                Data = new { FileGuid = handle, FileName = "Entrenadores.xlsx" }
            };

        }

        [HttpGet]
        public virtual ActionResult Download(string fileGuid, string fileName)
        {
            if (TempData[fileGuid] != null)
            {
                byte[] data = TempData[fileGuid] as byte[];
                return File(data, "application/vnd.ms-excel", fileName);
            }
            else
            {
                // Problem - Log the error, generate a blank file,
                //           redirect to another controller action - whatever fits with your application
                return new EmptyResult();
            }
        }

        public ActionResult CrearArchivo(int meetid)
        {
            using (MemoryStream memoryStream = new MemoryStream())

            {
                Torneo torneo = db.Torneo.Find(meetid);
                List<atletas> atletas = db.atletas.Where(x => x.Meetid == meetid).OrderBy(x => x.Team_no).ToList();
                List<Eventos> eventos = db.Eventos.Where(x => x.MeetId == meetid).OrderBy(x => x.Event_ptr).ToList();
                List<Entradas> entradas = db.Entradas.Where(x => x.MeetId == meetid).ToList();
                List<Equipos> equipos = db.Equipos.Where(x => x.MeetId == meetid).ToList();
                List<MultiEdad> multiedades = db.MultiEdad.Where(x => x.MeetId == meetid).ToList();


                string FilePath = "ARchivoHTY3.hy3";

                TextWriter file = new StreamWriter(memoryStream, Encoding.GetEncoding("iso-8859-1"));

                //}

                //using (System.IO.StreamWriter file = new System.IO.StreamWriter(FilePath, true))
                //{

                file.WriteLine(PrimeraLineaA1());
                file.WriteLine(SegundaLineaB1(torneo));
                file.WriteLine(TerceraLineaB2(torneo));



                foreach (Equipos equipo in equipos)
                {

                    file.WriteLine(SwimTeamNameInformationC1(equipo));
                    file.WriteLine(SwimTeamAddressInformationC2(equipo));
                    file.WriteLine(SwimTeamAddressInformation2C3(equipo));

                    List<atletas> atletasDelEquipo = atletas.Where(x => x.Team_no == equipo.Team_no).ToList();
                    List<string> letras = new List<string> { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U" };

                    foreach (var atleta in atletasDelEquipo)
                    {
                        List<Entradas> entradasDelAtleta = entradas.Where(x => x.Ath_no == atleta.Ath_no).ToList();
                        file.WriteLine(SwimerEntryD1(atleta));
                        foreach (var entrada in entradasDelAtleta)
                        {
                            string letra = "A";
                            Eventos evento = eventos.Where(x => x.Event_ptr == entrada.Event_ptr).FirstOrDefault();
                            List<MultiEdad> multiedad = multiedades.Where(x => x.event_ptr == evento.Event_ptr).ToList();
                            if (multiedad.Count() > 0)
                            {
                                int i = 0;
                                foreach (MultiEdad multi in multiedad)
                                {
                                    letra = letras[i];
                                    if (multi.low_age <= atleta.Ath_age && multi.high_age >= atleta.Ath_age)
                                    {
                                        file.WriteLine(EventEntryE1(entrada, atleta, evento, multi, letra));
                                        break;
                                    }
                                    i++;
                                }
                            }
                            else
                            {
                                MultiEdad multi = new MultiEdad
                                {
                                    high_age = evento.High_Age,
                                    low_age = evento.Low_age,
                                };
                                file.WriteLine(EventEntryE1(entrada, atleta, evento, multi, letra));
                            }



                        }
                    }

                }

                file.Flush();
                file.Close();

                return File(memoryStream.GetBuffer(), "text/plain", FilePath);

            }
        }
        public string PrimeraLineaA1()
        {
            string Linea = "A101Merge Meet Entries       Hy-Tek, Ltd    MM5 7.0Eb     ";
            string fecha = DateTime.Now.ToString("ddMMyyyy");
            string hora = DateTime.Now.ToString("HH:mm tt").ToUpper();
            hora = hora.Replace(".", "");

            string federacion = "Peruvian Swim Fed. Champ. Meet                       ";

            string retorno = Linea + fecha + " " + hora + federacion;
            retorno = AgrandarString(retorno, 128);
            retorno = EncontrarCheckSum(retorno);
            return retorno;
        }

        public string SegundaLineaB1(Torneo torneo)
        {
            string MeetName = "";
            string Facility = "";
            string MeetStart = "";
            string MeetEnd = "";
            string AgeUP = "";
            string Elevation = "";
            string resultado = "B1";


            MeetName = AgrandarString(torneo.Meet_name1, 45);

            Facility = AgrandarString(torneo.Meet_location, 45);
            MeetStart = (torneo.Meet_start ?? DateTime.Now).ToString("MMddyyyy");
            MeetEnd = (torneo.Meet_end ?? DateTime.Now).ToString("MMddyyyy");
            AgeUP = (torneo.Calc_date ?? DateTime.Now).ToString("MMddyyyy");
            Elevation = AgrandarString("   0", 4);

            resultado = "B1" + MeetName + Facility + MeetStart + MeetEnd + AgeUP + Elevation;
            resultado = AgrandarString(resultado, 128);
            resultado = EncontrarCheckSum(resultado);
            return resultado;

        }

        public string TerceraLineaB2(Torneo torneo)
        {
            string MeetInformation = "                                                                                          060101";
            string curso = "L";
            string resto = "1  0.00                      ";

            if (torneo.Meet_course == 2)
            {
                curso = "S";
            }
            string resultado = "B2" + MeetInformation + curso + resto;
            resultado = EncontrarCheckSum(resultado);
            return resultado;
        }

        public string SwimTeamNameInformationC1(Equipos equipo)
        {
            string teamAbbreviation = AgrandarString(equipo.Team_abbr, 5);
            string teamName = AgrandarString(equipo.Team_name, 30);
            string teamShort = AgrandarString(equipo.Team_short, 16);
            string LSC = AgrandarString(equipo.Team_lsc, 2);
            string teamHead = AgrandarString(equipo.Team_head, 30);
            string teamAsistant = AgrandarString(equipo.Team_asst, 30);
            string resto = "   0  0      ";
            string resultado = "C1" + teamAbbreviation + teamName + teamShort + LSC + teamHead + teamAsistant + resto;
            resultado = EncontrarCheckSum(resultado);
            return resultado;
        }

        public string SwimTeamAddressInformationC2(Equipos equipo)
        {
            string TeamAddress = AgrandarString(equipo.Team_addr1, 30);
            string TeamAddress2 = AgrandarString(equipo.Team_addr2, 30);
            string TeamCity = AgrandarString(equipo.Team_city, 30);
            string TeamState = AgrandarString(equipo.Team_statenew, 2);
            string TeamZips = AgrandarString(equipo.Team_zip, 10);
            string country = AgrandarString(equipo.Team_cntry, 3);
            string resto = "                     ";
            string resultado = "C2" + TeamAddress + TeamAddress2 + TeamCity + TeamState + TeamZips + country + resto;
            resultado = AgrandarString(resultado, 128);
            resultado = EncontrarCheckSum(resultado);
            return resultado;
        }

        public string SwimTeamAddressInformation2C3(Equipos equipo)
        {
            string Inicio = AgrandarString("", 30);
            string telef = AgrandarString(equipo.Team_daytele, 20);
            string telef2 = AgrandarString(equipo.Team_evetele, 20);
            string fax = AgrandarString(equipo.Team_faxtele, 20);
            string email = AgrandarString(equipo.Team_email, 36);

            string resultado = "C3" + Inicio + telef + telef2 + fax + email;
            resultado = AgrandarString(resultado, 128);
            resultado = EncontrarCheckSum(resultado);
            return resultado;
        }

        public string SwimerEntryD1(atletas atleta)
        {
            string sex = atleta.Ath_Sex;
            string Nro = AgrandarNumero(atleta.Ath_no, 5);
            string Apellido = AgrandarString(atleta.Last_name, 20);
            string nombre = AgrandarString(atleta.First_name, 20);
            string Nick = "                    ";
            string inicial = AgrandarString(atleta.Initial, 1);
            string Reg_No = AgrandarString(atleta.Reg_no, 14);
            string CompNo = AgrandarNumero(atleta.Comp_no ?? 0, 5);
            string DBO = AgrandarString((atleta.Birth_date ?? DateTime.Now).ToString("MMddyyyy"), 9);
            string Edad = AgrandarString(atleta.Ath_age.ToString(), 3);
            string foreigner = AgrandarString("    0", 6);
            string Nacionalidad = AgrandarString("      PER", 10);
            string resto = "             ";


            string resultado = "D1" + sex + Nro + Apellido + nombre + Nick + inicial + Reg_No + CompNo + DBO + Edad +foreigner+Nacionalidad+ resto;
            resultado = AgrandarString(resultado, 128);
            resultado = EncontrarCheckSum(resultado);
            return resultado;
        }

        public string EventEntryE1(Entradas entrada, atletas atleta, Eventos evento, MultiEdad multiedad, string letra)
        {
            string number = FormatearString((evento.Event_ptr + letra), 4);

            string sex = atleta.Ath_Sex;
            string Nro = AgrandarNumero(atleta.Ath_no, 5);
            string Apellido = AgrandarString(atleta.Last_name, 5);

            string distancia = AgrandarNumero((int)evento.Event_dist, 4);
            string stroke = AgrandarString(evento.Event_stroke, 1);
            string lowage = AgrandarNumero((int)multiedad.low_age, 3);
            string highAge = AgrandarNumero((int)multiedad.high_age, 3);
            string cuatro = "    ";
            string Fee = FormatearTiempo((double)evento.Entry_fee, 6);

            string Seed1 = FormatearTiempo((entrada.ActualSeed_time), 8);
            string CourseSeed1 = entrada.ActSeed_course;
            string Seed2 = FormatearTiempo((entrada.ConvSeed_time), 8);
            string CourseSeed2 = entrada.ConvSeed_course;
            string resto = "    0.00    0.00  0NN               N                               ";

            string espacio = "  ";
            string sex2 = "B";
            if (sex == "F" || sex == "f")
            {
                sex2 = "G";
            }



            string resultado = "E1" + sex + Nro + Apellido + sex + sex2 + espacio + distancia + stroke + lowage + highAge + cuatro + Fee + number + Seed1 + CourseSeed1 + Seed2 + CourseSeed2 + resto;
            resultado = AgrandarString(resultado, 128);
            resultado =  EncontrarCheckSum(resultado);
            return resultado;


        }


        public string EncontrarCheckSum(string linea)
        {
            
            int largo = linea.Length;
            string impares = "";
            string pares = "";
            int valorpares = 0;
            int valorimpares = 0;
           
            byte[] a = System.Text.Encoding.UTF8.GetBytes(linea);
            


            for (int i = 0; i < largo; i++)
            {                
                string letra = linea.Substring(i, 1);
                //switch (letra)
                //{
                //    case "á":
                //        letra = "a";
                //        break;
                //    case "é":
                //        letra = "e";
                //        break;
                //    case "í":
                //        letra = "i";
                //        break;
                //    case "ó":
                //        letra = "o";
                //        break;
                //    case "ú":
                //        letra = "u";
                //        break;

                //}
                char c = letra[0];
               
                if (i % 2 == 0)
                {
                    pares += c;
                    valorpares += ((byte)c);
                }
                else
                {
                    impares += c;
                    valorimpares += ((byte)c);
                }
            }

            int ValorTotal = valorpares + valorimpares * 2;

            double Dividido = (ValorTotal / 21) + 205;

            int valorResultado = (int)Dividido;

            string Resultadoconvertido = valorResultado.ToString();

            char ultimodigito = Resultadoconvertido[Resultadoconvertido.Length - 1];
            char penultimodigito = Resultadoconvertido[Resultadoconvertido.Length - 2];

            string resultado = "";
            resultado += ultimodigito;
            resultado += penultimodigito;

            string prueba2 = System.Text.Encoding.UTF8.GetString(a)+resultado;
            return prueba2;


        }

        public string AgrandarString(string antigua, int tamano)
        {
            if (antigua == null)
            {
                antigua = "";
            }
            while (antigua.Length < tamano)
            {
                antigua = antigua.Insert(antigua.Length, " ");
            }
            antigua = antigua.Substring(0, tamano);
            return antigua;
        }

        public string AgrandarNumero(int? numeronulo, int tamano)
        {
            int numero = numeronulo ?? 0;

            string antigua = numero.ToString();
            while (antigua.Length < tamano)
            {
                antigua = antigua.Insert(0, " ");
            }
            antigua = antigua.Substring(0, tamano);
            return antigua;
        }

        public string FormatearTiempo(double? tiempo, int tamano)
        {
            double numero = tiempo ?? 0;

            string antigua = numero.ToString("0.00");
            while (antigua.Length < tamano)
            {
                antigua = antigua.Insert(0, " ");
            }
            antigua = antigua.Substring(0, tamano);
            return antigua;
        }

        public string FormatearString(string antigua, int tamano)
        {
            if (antigua == null)
            {
                antigua = "";
            }
            while (antigua.Length < tamano)
            {
                antigua = antigua.Insert(0, " ");
            }
            antigua = antigua.Substring(0, tamano);
            return antigua;
        }

        public PartialViewResult _footerheader()
        {
            return PartialView();
        }
       
        public ActionResult ExportarResumen(int meetid, int usuarioid)
        {

            Usuario usuario = db.Usuario.Find(usuarioid);
            Equipos equipo = db.Equipos.Where(x => x.Team_abbr == usuario.Club.Iniciales && x.MeetId == meetid).FirstOrDefault();
            Torneo torneo = db.Torneo.Find(meetid);
            List<atletas> atletas = db.atletas.Where(x => x.Meetid == meetid && x.Team_no == equipo.Team_no)
                .OrderBy(x => x.Last_name).ThenBy(x => x.First_name).ThenByDescending(x => x.Birth_date).ToList();
            List<Eventos> eventos = db.Eventos.Where(x => x.MeetId == meetid).OrderBy(x => x.Event_ptr).ToList();
            List<Entradas> entradas = db.Entradas.Where(x => x.MeetId == meetid).ToList();
            List<Estilos> estilos = db.Estilos.ToList();
          
            ModelAExportar VM = new ModelAExportar
            {
                entrenadorInscritos = db.EntrenadorInscrito.Where(x => x.MeetId == meetid && x.Entrenadores.Club.Iniciales == equipo.Team_abbr).ToList(),
                delegados = db.Delegados.Where(x => x.Usuario.Club.Iniciales == equipo.Team_abbr && x.MeetId == meetid).ToList(),
               
        };
             VM.resumenentradas = new List<ResumenViewModel>();
            ViewBag.torneo = torneo.Meet_name1;

            int numeroDeAtleta = 0;
            foreach (atletas atleta in atletas)
            {
                numeroDeAtleta += 1;
                ResumenViewModel Nadador = new ResumenViewModel
                {
                    FN = atleta.Birth_date ?? DateTime.Now,
                    atleta = atleta,
                    afiliado = db.Afiliado .Where(x=>x.DNI == atleta.Reg_no).FirstOrDefault(),
                    NumeroAtleta = numeroDeAtleta,
                    detalle = new List<DetalleDeEntradas>(),
                };

                
                List<Entradas> EntradasDelAtleta = entradas.Where(x => x.Ath_no == atleta.Ath_no).ToList();

                foreach (Entradas entrada in EntradasDelAtleta)
                {
                    DetalleDeEntradas detalle = new DetalleDeEntradas
                    {
                        entrada = entrada,                       
                        evento = eventos.Where(x => x.Event_ptr == entrada.Event_ptr).FirstOrDefault(),
                    };
                    detalle.estilo = estilos.Where(x => x.tag_stroke == detalle.evento.Event_stroke).FirstOrDefault();
                    detalle.Marca = FormatearMarcaSegunPiscina (detalle.entrada.ActualSeed_time, detalle.entrada.ActSeed_course);
                    Nadador.detalle.Add(detalle);
                }
                VM.resumenentradas.Add(Nadador);
                
                ViewBag.equipo = equipo;
            }
            return View(VM);
        }



        public ActionResult ImprimirResumen(int meetid)
        {
            if (!repository.validarUsuario()) return RedirectToAction("login", "home");
            Usuario usuario = Session["Usuario"] as Usuario;
            var p = new ActionAsPdf("ExportarResumen", new { meetid = meetid, usuarioid = usuario.UsuarioID });
            //{
            //    PageSize = Rotativa.Options.Size.A4,
            //    PageOrientation = Rotativa.Options.Orientation.Portrait,
            //    FileName = "Resumen.pdf",
            //    CustomSwitches = "--disable-smart-shrinking",
            //    PageMargins = new Rotativa.Options.Margins(10, 20, 0,20),
                
            //};
            return p;
        }

        public ActionResult PreviewResumen(int meetid)
        {
            Usuario usuario = Session["Usuario"] as Usuario;
            return RedirectToAction("ExportarResumen", new { meetid = meetid, usuarioid = usuario.UsuarioID });
        }

        public string convertirSegundosATiempo(double? tiempo)
        {
            double marca = tiempo ?? 0;

            int minutos, segundos;
            double numeroentero, numerofraccion;

            numeroentero = Math.Truncate(marca);
            numerofraccion = (marca - numeroentero);
            numerofraccion = (Math.Round((numerofraccion / .010), 0) * 0.010)*100; //esto lo encontré en la internet
            segundos = (int)numeroentero;
            minutos = 0;
            
            if (numeroentero > 60)
            {
                minutos =(int)marca/60;
                segundos = (int)(numeroentero - minutos * 60);
            }
            string respuesta = minutos.ToString("00") + ":" + segundos.ToString("00") + "." + numerofraccion.ToString("00");
            return respuesta;
        }

        public string FormatearMarcaSegunPiscina(double? tiempo, string piscina)
        {
            double marca = tiempo ?? 0;
            string respuesta;
            if (marca>0)
            {
               respuesta =  convertirSegundosATiempo(marca) + " " + piscina;
            }
            else
            {
                return "Sin marca";
            }
            return respuesta;
        }

     
    }


    //public void ExportarResumen(int meetid)
    //{
    //    Usuario usuario = Session["usuario"] as Usuario;

    //    Equipos equipo = db.Equipos.Where(x => x.Team_abbr == usuario.Club.Iniciales && x.MeetId == meetid).FirstOrDefault();
    //    Torneo torneo = db.Torneo.Find(meetid);


    //    List<atletas> atletas = db.atletas.Where(x => x.Meetid == meetid && x.Team_no == equipo.Team_no).OrderBy(x => x.Last_name).ThenBy(x => x.First_name).ThenByDescending(x => x.Birth_date).ToList();
    //    List<Eventos> eventos = db.Eventos.Where(x => x.MeetId == meetid).OrderBy(x => x.Event_ptr).ToList();
    //    List<Entradas> entradas = db.Entradas.Where(x => x.MeetId == meetid).ToList();
    //    List<Estilos> estilos = db.Estilos.ToList();

    //    ExcelPackage ExcelFile = new ExcelPackage();
    //    ExcelWorksheet resumen = ExcelFile.Workbook.Worksheets.Add("Resumen");
    //    resumen.Cells[1, 1].Value = "Resumen del proceso de inscripción en";
    //    resumen.Cells[2, 1].Value = torneo.Meet_name1;
    //    resumen.Cells[3, 1].Value = "Club";
    //    resumen.Cells[3, 2].Value = equipo.Team_name;

    //    int i = 5; // a partir de la línea 5 se escribirán las inscripciones
    //    int numeroDeAtleta = 0;
    //    foreach (atletas atleta in atletas)
    //    {
    //        numeroDeAtleta += 1;
    //        i += 1;
    //        DateTime FN = atleta.Birth_date ?? DateTime.Now;
    //        List<Entradas> EntradasDelAtleta = entradas.Where(x => x.Ath_no == atleta.Ath_no).ToList();
    //        resumen.Cells[i, 1].Value = numeroDeAtleta + " " + ;
    //        resumen.Cells[i, 2].Value = atleta.First_name;
    //        resumen.Cells[i, 3].Value = atleta.Last_name;
    //        resumen.Cells[i, 5].Value = ().ToString("dd/MM/yyyy");
    //        foreach (Entradas entrada in EntradasDelAtleta)
    //        {

    //            i += 1;
    //            Eventos evento = eventos.Where(x => x.Event_ptr == entrada.Event_ptr).FirstOrDefault();
    //            Estilos estilo = estilos.Where(x => x.tag_stroke == evento.Event_stroke).FirstOrDefault();
    //            resumen.Cells[i, 1].Value = "# " + entrada.Event_ptr;
    //            resumen.Cells[i, 2].Value = evento.Event_sex;
    //            resumen.Cells[i, 3].Value = evento.Event_dist + " " + estilo.Estilo;
    //            resumen.Cells[i, 5].Value = entrada.ConvSeed_time;
    //        }
    //    }


    //    string handle = Guid.NewGuid().ToString();

    //    using (var memoryStream = new MemoryStream())
    //    {
    //        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
    //        Response.AddHeader("content-disposition", "attachment; filename=" + resumen + ".xlsx");
    //        ExcelFile.SaveAs(memoryStream);
    //        memoryStream.WriteTo(Response.OutputStream);
    //        Response.Flush();
    //        Response.End();
    //    }


    //}



}
