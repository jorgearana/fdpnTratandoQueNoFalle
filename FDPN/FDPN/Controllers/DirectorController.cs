using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FDPN.Models;
using OfficeOpenXml;
using MoreLinq;

namespace FDPN.Controllers
{
    public class DirectorController : BASEController
    {
        // GET: Director
        public ActionResult Index()
        { int fila = 2;
            DateTime haceunanno = DateTime.Now.AddDays(-15).AddYears(-1);
            List<Pruebas> pruebas = db.Pruebas.Where(x => x.PruebaId < 19).ToList();
            string[] sexos = { "F", "M" };
            string[] piscinas = { "L", "S" };
          
           
            ExcelPackage ExcelFile = new ExcelPackage();
            ExcelWorksheet resumen = ExcelFile.Workbook.Worksheets.Add("Resumen");
            resumen.Cells[1, 1].Value = "Ranking últimos 12 meses";

            resumen.Cells[2, 1].Value = "Nombre";
            resumen.Cells[2, 2].Value = "Apellido";
            resumen.Cells[2, 3].Value = "Sexo";
            resumen.Cells[2, 4].Value = "Tiempo";
            resumen.Cells[2, 5].Value = "Distancia";
            resumen.Cells[2, 6].Value = "Estilo";
            resumen.Cells[2, 7].Value = "Edad";
            resumen.Cells[2, 8].Value = "Puesto";
            resumen.Cells[2, 9].Value = "Puntos";
            resumen.Cells[2, 10].Value = "Torneo";
            resumen.Cells[2, 11].Value = "Equipo";
            resumen.Cells[2, 12].Value = "Fecha";
            resumen.Cells[2, 13].Value = "Piscina";
            foreach (var piscina in piscinas)
            {

            
            foreach (var sexo in sexos)
            {
                foreach(var prueba in pruebas)
                {
                    List<RESULTS> resultadosprueba = db.RESULTS.Where(x => x.Meet1.Start > haceunanno && x.NT == 0 && x.PFina > 400 && x.PruebaId == prueba.PruebaId && x.Athlete1.Sex == sexo && x.COURSE == piscina)
                        
                        .OrderBy(x=>x.SCORE)
                        .DistinctBy(x=>x.ATHLETE)
                        .ToList();

                    foreach (RESULTS resultado in resultadosprueba)
                    {
                        fila += 1;
                        resumen.Cells[fila, 1].Value = resultado.Athlete1.First;
                        resumen.Cells[fila, 2].Value = resultado.Athlete1.Last;
                        resumen.Cells[fila, 3].Value = resultado.Athlete1.Sex;
                        resumen.Cells[fila, 4].Value = resultado.SCORE;
                        resumen.Cells[fila, 5].Value = resultado.DISTANCE;
                        resumen.Cells[fila, 6].Value = resultado.STROKE;
                        resumen.Cells[fila, 7].Value = resultado.Athlete1.Age;
                        resumen.Cells[fila, 8].Value = resultado.PLACE;
                        resumen.Cells[fila, 9].Value = resultado.PFina;
                        resumen.Cells[fila, 10].Value = resultado.Meet1.MName;
                        if(resultado.Team1 != null)
                        {
                            resumen.Cells[fila, 11].Value = resultado.Team1.TCode ;
                        }
                        resumen.Cells[fila, 12].Value = resultado.Meet1.Start;
                            resumen.Cells[fila, 13].Value = resultado.COURSE;
                        }                  

                }
            }
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
                Data = new { FileGuid = handle, FileName = "resumen.xlsx" }
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
    }
}