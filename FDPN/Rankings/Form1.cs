using MoreLinq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Rankings
{

    public partial class Form1 : Form
    {
        int AnnoMaximo;
        int AnnoMinimo;
        List<RESULTS> Resultados;
        List<RESULTS> Filtrados;
        DateTime FechaDesde;
        DateTime FechaHasta;
        List<Pruebas> pruebas;
        List<Categorias> categorias;
        public DB_9B1F4C_comentariosEntities db;
        public Form1()
        {
            InitializeComponent();
            datepickerDesde.Value = new DateTime(DateTime.Now.Year, 1, 1);
        }

        private async void BtnCalcular_Click(object sender, EventArgs e)
        
        {
            db = new DB_9B1F4C_comentariosEntities();
            FechaDesde = datepickerDesde.Value;
            FechaHasta = DatepickerHasta.Value;
           
            pruebas = await db.Pruebas.Where(x => x.PruebaId <20 ).ToListAsync();
            categorias = await db.Categorias.ToListAsync();
           await  CalcularPorEdades();
        }

        async Task CalcularPorEdades ()
        {
            Categorias categoria = new Categorias(); ;
            if (ChkMinima.Checked)
            { 
                categoria = categorias.FirstOrDefault(x => x.NombreCategoria == "Mínima");
                await FiltrarResultados(categoria);
            }
            if (ChkInfA.Checked)
            {
                categoria = categorias.FirstOrDefault(x => x.NombreCategoria == "Infantil A");
                await FiltrarResultados(categoria);
            }
            if (ChkInfB.Checked)
            {
                categoria = categorias.FirstOrDefault(x => x.NombreCategoria == "Infantil B");
                await FiltrarResultados(categoria);
            }
            if (ChkJuvA.Checked)
            {
                categoria = categorias.FirstOrDefault(x => x.NombreCategoria == "Juvenil A");
                await FiltrarResultados(categoria);
            }
            if (ChkJuvB.Checked)
            {
                categoria = categorias.FirstOrDefault(x => x.NombreCategoria == "Juvenil B");
                await FiltrarResultados(categoria);
            }
            if (ChkMay.Checked)
            {
                categoria = categorias.FirstOrDefault(x => x.NombreCategoria == "Mayores");
                await FiltrarResultados(categoria);
            }
            if (chkopen.Checked)
            {
                categoria = categorias.FirstOrDefault(x => x.NombreCategoria == "Open");
                await FiltrarResultados(categoria);
            }

        }

        async Task FiltrarResultados( Categorias categoria)
        {
            List<string> sexos = new List<string>();
            List<string> piscinas = new List<string> ();
            int numeronadadores = Int32.Parse(TxtNadadores.Text);
            AnnoMinimo = (DateTime.Now.Year - categoria.Edad_maxima) - 1;
            AnnoMaximo = (DateTime.Now.Year - categoria.Edad_minima) - 1;
            int annoActual = DateTime.Now.Year - 1;
            int edad = 0;
            string categoriaactual ="";
            //AnnoMinimo = 1999;
            //AnnoMaximo = 2006;
            //if (categoria.Edad_maxima >22)
            //{
            //    AnnoMinimo = DateTime.Now.Year - 22 - 1;
            //}

            switch (CboSexo.Text.ToUpper())
            {
                case "F": sexos.Add("F");
                    break;
                case "M":
                    sexos.Add("M");
                    break;
                default:
                    sexos.Add("F");
                    sexos.Add("M");
                    break;
            }

            switch (CboPiscina.Text.ToUpper())
            {
                case "L":
                    piscinas.Add("L");
                    break;
                case "S":
                    piscinas.Add("S");
                    break;
                default:
                    piscinas.Add("L");
                    piscinas.Add("S");
                    break;
            }


            foreach (var item in pruebas)
            {
                foreach (var piscina in piscinas)
                {
                    int ranking = 1;
                    foreach (var sexo in sexos)
                    {
                        //if (sexo == "F")
                        //{
                        //    AnnoMaximo = 2007;
                        //}


                        Resultados = await db.RESULTS.Where(x => x.PruebaId == item.PruebaId && x.Athlete1.Birth.HasValue &&
                      x.Athlete1.Birth.Value.Year <= AnnoMaximo && x.Athlete1.Birth.Value.Year >= AnnoMinimo && x.MEET1.Start > FechaDesde 
                      && x.MEET1.Start<FechaHasta &&
                      x.Athlete1.Sex == sexo && x.MEET1.Course == piscina)
                            .OrderByDescending(x => x.PFina).Take(100).ToListAsync();

                   Filtrados=     Resultados.OrderByDescending(x=>x.PFina)
                            .DistinctBy(x => x.ATHLETE)
                            .Take(numeronadadores).ToList();

                        foreach (var resultado in Filtrados)
                        {
                            if (resultado.TEAM1 == null)
                            {
                                resultado.TEAM1 = new TEAM
                                {
                                    TName = "",
                                };
                            }
                            edad = annoActual - resultado.Athlete1.Birth.Value.Year;
                            switch (edad)
                            {
                                case 13:
                                case 14:
                                    categoriaactual = "Juv A";
                                    break;
                                case 15:
                                case 16:
                                case 17:
                                    categoriaactual = "Juv B";
                                    break;
                            }
                            Grid1.Rows.Add(ranking, resultado.Athlete1.First, resultado.Athlete1.Last, resultado.DISTANCE,
                                resultado.STROKE, resultado.SCORE, resultado.PFina, resultado.Athlete1.Sex, resultado.MEET1.Course,
                                resultado.Athlete1.Birth.Value.Year, resultado.MEET1.Start, resultado.TEAM1.TName, categoriaactual, edad);
                            ranking++;
                        }
                    }

                }
            }
        }


    }
}
