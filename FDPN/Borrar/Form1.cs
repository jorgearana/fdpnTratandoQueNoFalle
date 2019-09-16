using FDPN.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Borrar
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        { 
             FDPN.Models.DB_9B1F4C_comentariosEntities db = new FDPN.Models.DB_9B1F4C_comentariosEntities();
           
            List<Afiliado> afiliados = db.Afiliado.Take(10).ToList();
            foreach(var item in afiliados)
            {
                Cambiar(item.Nombre);
                Cambiar(item.Nombre);
                Cambiar(item.Nombre);
                db.SaveChanges();
            }
        }

        public void Cambiar(string value)
        {
            char[] array = value.ToCharArray();
            // Handle the first letter in the string.
            if (array.Length >= 1)
            {
                if (char.IsLower(array[0]))
                {
                    array[0] = char.ToUpper(array[0]);
                }
            }
            // Scan through the letters, checking for spaces.
            // ... Uppercase the lowercase letters following spaces.
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i - 1] == ' ')
                {
                    if (char.IsLower(array[i]))
                    {
                        array[i] = char.ToUpper(array[i]);
                    }
                }
            }
        }
    }
}
