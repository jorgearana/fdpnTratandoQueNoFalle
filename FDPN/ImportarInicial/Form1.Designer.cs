namespace ImportarInicial
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.cboTipoTorneo = new MetroFramework.Controls.MetroComboBox();
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.chkPorLigas = new MetroFramework.Controls.MetroCheckBox();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.txtPruebasXEquipo = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.txtPruebasXTorneo = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.TxtPruebasXSesion = new MetroFramework.Controls.MetroTextBox();
            this.metroTabPage2 = new MetroFramework.Controls.MetroTabPage();
            this.btnBorrar = new MetroFramework.Controls.MetroButton();
            this.CboTorneos = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.lblResultado = new MetroFramework.Controls.MetroLabel();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.txtPruebasSinMarca = new MetroFramework.Controls.MetroTextBox();
            this.metroTabControl1.SuspendLayout();
            this.metroTabPage1.SuspendLayout();
            this.metroTabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "ReportViewer";
            this.reportViewer1.Size = new System.Drawing.Size(396, 246);
            this.reportViewer1.TabIndex = 0;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.BackColor = System.Drawing.Color.Black;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.metroLabel1.Location = new System.Drawing.Point(283, 27);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(145, 15);
            this.metroLabel1.TabIndex = 3;
            this.metroLabel1.Text = "Seleccione el tipo de Torneo";
            // 
            // metroButton1
            // 
            this.metroButton1.DialogResult = System.Windows.Forms.DialogResult.Ignore;
            this.metroButton1.ForeColor = System.Drawing.Color.Red;
            this.metroButton1.Location = new System.Drawing.Point(401, 133);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(170, 23);
            this.metroButton1.Style = MetroFramework.MetroColorStyle.Green;
            this.metroButton1.TabIndex = 4;
            this.metroButton1.Text = "Empezar a subir torneo";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // cboTipoTorneo
            // 
            this.cboTipoTorneo.FormattingEnabled = true;
            this.cboTipoTorneo.ItemHeight = 23;
            this.cboTipoTorneo.Location = new System.Drawing.Point(450, 13);
            this.cboTipoTorneo.Name = "cboTipoTorneo";
            this.cboTipoTorneo.Size = new System.Drawing.Size(121, 29);
            this.cboTipoTorneo.TabIndex = 5;
            this.cboTipoTorneo.UseSelectable = true;
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.metroTabPage1);
            this.metroTabControl1.Controls.Add(this.metroTabPage2);
            this.metroTabControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.metroTabControl1.Location = new System.Drawing.Point(20, 85);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 0;
            this.metroTabControl1.Size = new System.Drawing.Size(609, 236);
            this.metroTabControl1.Style = MetroFramework.MetroColorStyle.Green;
            this.metroTabControl1.TabIndex = 6;
            this.metroTabControl1.UseSelectable = true;
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.metroTabPage1.Controls.Add(this.metroLabel6);
            this.metroTabPage1.Controls.Add(this.txtPruebasSinMarca);
            this.metroTabPage1.Controls.Add(this.chkPorLigas);
            this.metroTabPage1.Controls.Add(this.metroLabel5);
            this.metroTabPage1.Controls.Add(this.txtPruebasXEquipo);
            this.metroTabPage1.Controls.Add(this.metroLabel4);
            this.metroTabPage1.Controls.Add(this.txtPruebasXTorneo);
            this.metroTabPage1.Controls.Add(this.metroLabel3);
            this.metroTabPage1.Controls.Add(this.TxtPruebasXSesion);
            this.metroTabPage1.Controls.Add(this.metroButton1);
            this.metroTabPage1.Controls.Add(this.cboTipoTorneo);
            this.metroTabPage1.Controls.Add(this.metroLabel1);
            this.metroTabPage1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.HorizontalScrollbarSize = 10;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Size = new System.Drawing.Size(601, 194);
            this.metroTabPage1.TabIndex = 0;
            this.metroTabPage1.Text = "Agregar torneo";
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            this.metroTabPage1.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.VerticalScrollbarSize = 10;
            // 
            // chkPorLigas
            // 
            this.chkPorLigas.AutoSize = true;
            this.chkPorLigas.Location = new System.Drawing.Point(450, 87);
            this.chkPorLigas.Name = "chkPorLigas";
            this.chkPorLigas.Size = new System.Drawing.Size(108, 15);
            this.chkPorLigas.TabIndex = 13;
            this.chkPorLigas.Text = "Torneo por ligas";
            this.chkPorLigas.UseSelectable = true;
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.BackColor = System.Drawing.Color.Black;
            this.metroLabel5.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel5.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.metroLabel5.Location = new System.Drawing.Point(21, 95);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(107, 15);
            this.metroLabel5.TabIndex = 11;
            this.metroLabel5.Text = "Pruebas por equipo";
            // 
            // txtPruebasXEquipo
            // 
            // 
            // 
            // 
            this.txtPruebasXEquipo.CustomButton.Image = null;
            this.txtPruebasXEquipo.CustomButton.Location = new System.Drawing.Point(53, 1);
            this.txtPruebasXEquipo.CustomButton.Name = "";
            this.txtPruebasXEquipo.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtPruebasXEquipo.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPruebasXEquipo.CustomButton.TabIndex = 1;
            this.txtPruebasXEquipo.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPruebasXEquipo.CustomButton.UseSelectable = true;
            this.txtPruebasXEquipo.CustomButton.Visible = false;
            this.txtPruebasXEquipo.Lines = new string[0];
            this.txtPruebasXEquipo.Location = new System.Drawing.Point(188, 87);
            this.txtPruebasXEquipo.MaxLength = 32767;
            this.txtPruebasXEquipo.Name = "txtPruebasXEquipo";
            this.txtPruebasXEquipo.PasswordChar = '\0';
            this.txtPruebasXEquipo.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPruebasXEquipo.SelectedText = "";
            this.txtPruebasXEquipo.SelectionLength = 0;
            this.txtPruebasXEquipo.SelectionStart = 0;
            this.txtPruebasXEquipo.ShortcutsEnabled = true;
            this.txtPruebasXEquipo.Size = new System.Drawing.Size(75, 23);
            this.txtPruebasXEquipo.TabIndex = 10;
            this.txtPruebasXEquipo.UseSelectable = true;
            this.txtPruebasXEquipo.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPruebasXEquipo.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.BackColor = System.Drawing.Color.Black;
            this.metroLabel4.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel4.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.metroLabel4.Location = new System.Drawing.Point(21, 66);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(106, 15);
            this.metroLabel4.TabIndex = 9;
            this.metroLabel4.Text = "Pruebas por torneo";
            // 
            // txtPruebasXTorneo
            // 
            // 
            // 
            // 
            this.txtPruebasXTorneo.CustomButton.Image = null;
            this.txtPruebasXTorneo.CustomButton.Location = new System.Drawing.Point(53, 1);
            this.txtPruebasXTorneo.CustomButton.Name = "";
            this.txtPruebasXTorneo.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtPruebasXTorneo.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPruebasXTorneo.CustomButton.TabIndex = 1;
            this.txtPruebasXTorneo.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPruebasXTorneo.CustomButton.UseSelectable = true;
            this.txtPruebasXTorneo.CustomButton.Visible = false;
            this.txtPruebasXTorneo.Lines = new string[0];
            this.txtPruebasXTorneo.Location = new System.Drawing.Point(188, 58);
            this.txtPruebasXTorneo.MaxLength = 32767;
            this.txtPruebasXTorneo.Name = "txtPruebasXTorneo";
            this.txtPruebasXTorneo.PasswordChar = '\0';
            this.txtPruebasXTorneo.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPruebasXTorneo.SelectedText = "";
            this.txtPruebasXTorneo.SelectionLength = 0;
            this.txtPruebasXTorneo.SelectionStart = 0;
            this.txtPruebasXTorneo.ShortcutsEnabled = true;
            this.txtPruebasXTorneo.Size = new System.Drawing.Size(75, 23);
            this.txtPruebasXTorneo.TabIndex = 8;
            this.txtPruebasXTorneo.UseSelectable = true;
            this.txtPruebasXTorneo.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPruebasXTorneo.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.BackColor = System.Drawing.Color.Black;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel3.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.metroLabel3.Location = new System.Drawing.Point(21, 35);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(103, 15);
            this.metroLabel3.TabIndex = 7;
            this.metroLabel3.Text = "Pruebas por sesión";
            // 
            // TxtPruebasXSesion
            // 
            // 
            // 
            // 
            this.TxtPruebasXSesion.CustomButton.Image = null;
            this.TxtPruebasXSesion.CustomButton.Location = new System.Drawing.Point(53, 1);
            this.TxtPruebasXSesion.CustomButton.Name = "";
            this.TxtPruebasXSesion.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.TxtPruebasXSesion.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TxtPruebasXSesion.CustomButton.TabIndex = 1;
            this.TxtPruebasXSesion.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TxtPruebasXSesion.CustomButton.UseSelectable = true;
            this.TxtPruebasXSesion.CustomButton.Visible = false;
            this.TxtPruebasXSesion.Lines = new string[0];
            this.TxtPruebasXSesion.Location = new System.Drawing.Point(188, 27);
            this.TxtPruebasXSesion.MaxLength = 32767;
            this.TxtPruebasXSesion.Name = "TxtPruebasXSesion";
            this.TxtPruebasXSesion.PasswordChar = '\0';
            this.TxtPruebasXSesion.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TxtPruebasXSesion.SelectedText = "";
            this.TxtPruebasXSesion.SelectionLength = 0;
            this.TxtPruebasXSesion.SelectionStart = 0;
            this.TxtPruebasXSesion.ShortcutsEnabled = true;
            this.TxtPruebasXSesion.Size = new System.Drawing.Size(75, 23);
            this.TxtPruebasXSesion.TabIndex = 6;
            this.TxtPruebasXSesion.UseSelectable = true;
            this.TxtPruebasXSesion.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TxtPruebasXSesion.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroTabPage2
            // 
            this.metroTabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.metroTabPage2.Controls.Add(this.btnBorrar);
            this.metroTabPage2.Controls.Add(this.CboTorneos);
            this.metroTabPage2.Controls.Add(this.metroLabel2);
            this.metroTabPage2.HorizontalScrollbarBarColor = true;
            this.metroTabPage2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.HorizontalScrollbarSize = 10;
            this.metroTabPage2.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage2.Name = "metroTabPage2";
            this.metroTabPage2.Size = new System.Drawing.Size(601, 194);
            this.metroTabPage2.TabIndex = 1;
            this.metroTabPage2.Text = "Borrar torneo";
            this.metroTabPage2.VerticalScrollbarBarColor = true;
            this.metroTabPage2.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.VerticalScrollbarSize = 10;
            // 
            // btnBorrar
            // 
            this.btnBorrar.Location = new System.Drawing.Point(401, 114);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(170, 23);
            this.btnBorrar.Style = MetroFramework.MetroColorStyle.Green;
            this.btnBorrar.TabIndex = 7;
            this.btnBorrar.Text = "Borrar torneo";
            this.btnBorrar.UseSelectable = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // CboTorneos
            // 
            this.CboTorneos.FormattingEnabled = true;
            this.CboTorneos.ItemHeight = 23;
            this.CboTorneos.Location = new System.Drawing.Point(22, 40);
            this.CboTorneos.Name = "CboTorneos";
            this.CboTorneos.Size = new System.Drawing.Size(549, 29);
            this.CboTorneos.TabIndex = 8;
            this.CboTorneos.UseSelectable = true;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.BackColor = System.Drawing.Color.Black;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.metroLabel2.Location = new System.Drawing.Point(22, 19);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(145, 15);
            this.metroLabel2.TabIndex = 6;
            this.metroLabel2.Text = "Seleccione el tipo de Torneo";
            // 
            // lblResultado
            // 
            this.lblResultado.AutoSize = true;
            this.lblResultado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblResultado.Location = new System.Drawing.Point(379, 35);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(0, 0);
            this.lblResultado.TabIndex = 7;
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.BackColor = System.Drawing.Color.Black;
            this.metroLabel6.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel6.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.metroLabel6.Location = new System.Drawing.Point(21, 126);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(102, 15);
            this.metroLabel6.TabIndex = 15;
            this.metroLabel6.Text = "Pruebas sin marcar";
            // 
            // txtPruebasSinMarca
            // 
            // 
            // 
            // 
            this.txtPruebasSinMarca.CustomButton.Image = null;
            this.txtPruebasSinMarca.CustomButton.Location = new System.Drawing.Point(53, 1);
            this.txtPruebasSinMarca.CustomButton.Name = "";
            this.txtPruebasSinMarca.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtPruebasSinMarca.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPruebasSinMarca.CustomButton.TabIndex = 1;
            this.txtPruebasSinMarca.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPruebasSinMarca.CustomButton.UseSelectable = true;
            this.txtPruebasSinMarca.CustomButton.Visible = false;
            this.txtPruebasSinMarca.Lines = new string[0];
            this.txtPruebasSinMarca.Location = new System.Drawing.Point(188, 118);
            this.txtPruebasSinMarca.MaxLength = 32767;
            this.txtPruebasSinMarca.Name = "txtPruebasSinMarca";
            this.txtPruebasSinMarca.PasswordChar = '\0';
            this.txtPruebasSinMarca.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPruebasSinMarca.SelectedText = "";
            this.txtPruebasSinMarca.SelectionLength = 0;
            this.txtPruebasSinMarca.SelectionStart = 0;
            this.txtPruebasSinMarca.ShortcutsEnabled = true;
            this.txtPruebasSinMarca.Size = new System.Drawing.Size(75, 23);
            this.txtPruebasSinMarca.TabIndex = 14;
            this.txtPruebasSinMarca.UseSelectable = true;
            this.txtPruebasSinMarca.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPruebasSinMarca.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(649, 341);
            this.Controls.Add(this.lblResultado);
            this.Controls.Add(this.metroTabControl1);
            this.Name = "Form1";
            this.Style = MetroFramework.MetroColorStyle.Lime;
            this.Text = "Form1";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTabControl1.ResumeLayout(false);
            this.metroTabPage1.ResumeLayout(false);
            this.metroTabPage1.PerformLayout();
            this.metroTabPage2.ResumeLayout(false);
            this.metroTabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroComboBox cboTipoTorneo;
        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroTabPage metroTabPage1;
        private MetroFramework.Controls.MetroTabPage metroTabPage2;
        private MetroFramework.Controls.MetroButton btnBorrar;
        private MetroFramework.Controls.MetroComboBox CboTorneos;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel lblResultado;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroTextBox TxtPruebasXSesion;
        private MetroFramework.Controls.MetroCheckBox chkPorLigas;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroTextBox txtPruebasXEquipo;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroTextBox txtPruebasXTorneo;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroTextBox txtPruebasSinMarca;
    }
}

