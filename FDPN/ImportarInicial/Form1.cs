using AutoMapper;
using DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework;
using FDPN.Models;

namespace ImportarInicial
{
    public partial class Form1 : MetroForm
    {
        public DB_9B1F4C_comentariosEntities db = new DB_9B1F4C_comentariosEntities();
        DATABASEMEETDB access = new DATABASEMEETDB();
        int MeetId = 0;
      


        public Form1()
        {
            InitializeComponent();
            List<Torneo> torneos = db.Torneo.ToList();
            List<TipoTorneo> tiposDeTorneo = db.TipoTorneo.ToList();

            CboTorneos.DataSource = torneos;
            CboTorneos.DisplayMember = "Meet_name1";
            CboTorneos.ValueMember = "MeetId";

            cboTipoTorneo.DataSource = tiposDeTorneo;
            cboTipoTorneo.DisplayMember = "Nombre";
            cboTipoTorneo.ValueMember = "TipoId";
        }

       
        private void MostrarError()
        {
            string message = "You did not enter a server name. Cancel this operation?";
            string caption = "Error Detected in Input";
            DialogResult result;
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            // Displays the MessageBox.

            result = MessageBox.Show(message, caption, buttons);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {

                // Closes the parent form.

                this.Close();

            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            lblResultado.Text = "Espere un momento";

            List<Meet> meet = access.Meets.ToList();
            List<Event> events = access.Events.ToList();
            List<Session> sessions = access.Sessions.ToList();
            List<Sessitem> SessionItems = access.Sessitems.ToList();
            List<TimeStd> TimeStds = access.TimeStds.ToList();
            List<Multiage> multiages = access.Multiages.ToList();

            List<Entry> Entries = access.Entries.ToList();
            List<Team> Teams = access.Teams.ToList();
            List<DataModels.Athlete> Athletes = access.Athletes.ToList();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Meet, Torneo>();
            });
            IMapper mapper = config.CreateMapper();


            Torneo torneo = mapper.Map<Meet, Torneo>(meet[0]);
            db.Torneo.Add(torneo);
            db.SaveChanges();

            TipoTorneo tipo = cboTipoTorneo.SelectedItem as TipoTorneo;
            SetupTorneo setup = new SetupTorneo
            {
                TipoId = tipo.TipoId,
                pruebasXsesion = Int32.Parse(TxtPruebasXSesion.Text),
                pruebasXtorneo = Int32.Parse(txtPruebasXTorneo.Text),
                pruebasXEquipo = Int32.Parse(txtPruebasXEquipo.Text),
                SinMarca = Int32.Parse(txtPruebasSinMarca.Text),
                Meetid = torneo.Meetid,
                PorLigas = chkPorLigas.Checked,
                PermiteNoAfiliados = chkNoAfiliado.Checked,
                PermiteSinMarca = chkNoMarca.Checked,
                UsaMarcaMaxima = chkConMarcaMaxima.Checked,
                Masters = chkMasters.Checked,
                Debutantes= chkDebutantes.Checked,
            };
            db.SetupTorneo.Add(setup);
            db.SaveChanges();
            //Jalamos el torneo

            MeetId = torneo.Meetid;

            db.SaveChanges();

            try
            {

                foreach (Event prueba in events)
                {
                    config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<Event, Eventos>();
                    });
                    mapper = config.CreateMapper();
                    Eventos Evento = mapper.Map<Event, Eventos>(prueba);
                    Evento.MeetId = MeetId;
                    db.Eventos.Add(Evento);
                }
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MostrarError();
            }
            //Jalamos sesione
            try
            {

                foreach (Session session in sessions)
                {

                    config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<Session, Sesion>();
                    });
                    mapper = config.CreateMapper();

                    Sesion sesion = mapper.Map<Session, Sesion>(session);
                    sesion.MeetId = MeetId;
                    db.Sesion.Add(sesion);
                }
               db.SaveChanges();
            }
            catch (Exception ex)
            {
                MostrarError();
            }
            try
            {
                //Jalamos sesionitems
                foreach (Sessitem item in SessionItems)
                {

                    config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<Sessitem, SessionItem>();
                    });
                    mapper = config.CreateMapper();

                    SessionItem sesionitem = mapper.Map<Sessitem, SessionItem>(item);
                    sesionitem.Meetid = MeetId;
                    db.SessionItem.Add(sesionitem);
                }
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MostrarError();
            }
            //Jalamos sesione
            try
            {
                //Jalamos Multiedades
                foreach (Multiage item in multiages)
                {

                    config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<Multiage, MultiEdad>();
                    });
                    mapper = config.CreateMapper();

                    MultiEdad multi = mapper.Map<Multiage, MultiEdad>(item);
                    multi.MeetId = MeetId;
                    db.MultiEdad.Add(multi);
                }
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MostrarError();
            }
            //Jalamos sesione
            try
            {
                //Jalamos Marcas Mínimas
                foreach (var item in TimeStds)
                {

                    config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<TimeStd, MarcasMinimas>();
                    });
                    mapper = config.CreateMapper();

                    MarcasMinimas MM = mapper.Map<TimeStd, MarcasMinimas>(item);
                    MM.MeetId = MeetId;
                    db.MarcasMinimas.Add(MM);
                }


                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MostrarError();

            }


            try
            {
                //Jalamos Athletes
                foreach (var item in Teams)
                {

                    config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<DataModels.Team, Equipos>();
                    });
                    mapper = config.CreateMapper();

                    Equipos MM = mapper.Map<DataModels.Team, Equipos>(item);
                    MM.MeetId = MeetId;
                    db.Equipos.Add(MM);
                }


                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MostrarError();
            }

            try
            {
                //Jalamos Athletes
                foreach (var item in Athletes)
                {

                    config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<DataModels.Athlete, atletas>();
                    });
                    mapper = config.CreateMapper();

                    atletas MM = mapper.Map<DataModels.Athlete, atletas>(item);
                    MM.Meetid = MeetId;
                    db.atletas.Add(MM);
                }


                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MostrarError();
            }

            try
            {
                //Jalamos Entradas
                foreach (var item in Entries)
                {

                    config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<Entry, Entradas>();
                    });
                    mapper = config.CreateMapper();

                    Entradas MM = mapper.Map<Entry, Entradas>(item);
                    MM.MeetId = MeetId;
                    db.Entradas.Add(MM);
                }


                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MostrarError();
            }

            lblResultado.Text = "Terminé de agregar el torneo";
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            lblResultado.Text = "Espere un momento";
            int ID = (int)CboTorneos.SelectedValue;
            List<atletas> atletas = db.atletas.Where(x => x.Meetid == ID).ToList();
            List<Entradas> Entradas = db.Entradas.Where(x => x.MeetId == ID).ToList();
            List<Equipos> Equipos = db.Equipos.Where(x => x.MeetId == ID).ToList();
            List<Eventos> Eventos = db.Eventos.Where(x => x.MeetId == ID).ToList();
            List<MultiEdad> MultiEdad = db.MultiEdad.Where(x => x.MeetId == ID).ToList();
            List<Sesion> Sesion = db.Sesion.Where(x => x.MeetId == ID).ToList();
            List<SessionItem> SessionItem = db.SessionItem.Where(x => x.Meetid == ID).ToList();
            List<MarcasMinimas> MarcasMinimas = db.MarcasMinimas.Where(x => x.MeetId == ID).ToList();
            List<SetupTorneo> SetupTorneo = db.SetupTorneo.Where(x => x.Meetid == ID).ToList();
            List<Torneo> Torneo = db.Torneo.Where(x => x.Meetid == ID).ToList();

            foreach(var atleta in atletas)
            {
                db.atletas.Remove(atleta);
            }
            db.SaveChanges();

            foreach (var Entrada in Entradas)
            {
                db.Entradas.Remove(Entrada);
            }
            db.SaveChanges();

            foreach (var Equipo in Equipos)
            {
                db.Equipos.Remove(Equipo);
            }
            db.SaveChanges();

            foreach (var Evento in Eventos)
            {
                db.Eventos.Remove(Evento);
            }
            db.SaveChanges();

            foreach (var Multi in MultiEdad)
            {
                db.MultiEdad.Remove(Multi);
            }
            db.SaveChanges();

            foreach (var Sesi in Sesion)
            {
                db.Sesion.Remove(Sesi);
            }
            db.SaveChanges();

            foreach (var Item in SessionItem)
            {
                db.SessionItem.Remove(Item);
            }
            db.SaveChanges();

            foreach (var MarcasMinima in MarcasMinimas)
            {
                db.MarcasMinimas.Remove(MarcasMinima);
            }
            db.SaveChanges();

            foreach (var Setup in SetupTorneo)
            {
                db.SetupTorneo.Remove(Setup);
            }
            db.SaveChanges();

            foreach (var Torne in Torneo)
            {
                db.Torneo.Remove(Torne);
            }
            db.SaveChanges();

            lblResultado.Text = "Terminé de borrar el torneo";
        }
    }
}
