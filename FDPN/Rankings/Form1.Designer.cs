
namespace Rankings
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
            this.BtnCalcular = new System.Windows.Forms.Button();
            this.TxtNadadores = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.datepickerDesde = new System.Windows.Forms.DateTimePicker();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.DatepickerHasta = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.CboPiscina = new System.Windows.Forms.ComboBox();
            this.chkopen = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ChkMinima = new System.Windows.Forms.CheckBox();
            this.CboSexo = new System.Windows.Forms.ComboBox();
            this.ChkMay = new System.Windows.Forms.CheckBox();
            this.ChkInfA = new System.Windows.Forms.CheckBox();
            this.ChkJuvB = new System.Windows.Forms.CheckBox();
            this.ChkInfB = new System.Windows.Forms.CheckBox();
            this.ChkJuvA = new System.Windows.Forms.CheckBox();
            this.Grid1 = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Ranking = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Distancia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estilo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tiempo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Puntos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sexo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Piscina = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Anno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Equipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnCalcular
            // 
            this.BtnCalcular.BackColor = System.Drawing.Color.Salmon;
            this.BtnCalcular.Location = new System.Drawing.Point(1490, 18);
            this.BtnCalcular.Name = "BtnCalcular";
            this.BtnCalcular.Size = new System.Drawing.Size(228, 65);
            this.BtnCalcular.TabIndex = 12;
            this.BtnCalcular.Text = "Ejecutar";
            this.BtnCalcular.UseVisualStyleBackColor = false;
            this.BtnCalcular.Click += new System.EventHandler(this.BtnCalcular_Click);
            // 
            // TxtNadadores
            // 
            this.TxtNadadores.Location = new System.Drawing.Point(832, 55);
            this.TxtNadadores.Name = "TxtNadadores";
            this.TxtNadadores.Size = new System.Drawing.Size(186, 22);
            this.TxtNadadores.TabIndex = 10;
            this.TxtNadadores.Text = "0";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(829, 25);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(150, 17);
            this.Label2.TabIndex = 9;
            this.Label2.Text = "Número de nadadores";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(481, 18);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(90, 17);
            this.Label1.TabIndex = 8;
            this.Label1.Text = "Fecha desde";
            // 
            // datepickerDesde
            // 
            this.datepickerDesde.CustomFormat = "dd MM yyyy";
            this.datepickerDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datepickerDesde.Location = new System.Drawing.Point(484, 46);
            this.datepickerDesde.Name = "datepickerDesde";
            this.datepickerDesde.Size = new System.Drawing.Size(130, 22);
            this.datepickerDesde.TabIndex = 7;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.label5);
            this.GroupBox1.Controls.Add(this.BtnCalcular);
            this.GroupBox1.Controls.Add(this.DatepickerHasta);
            this.GroupBox1.Controls.Add(this.label4);
            this.GroupBox1.Controls.Add(this.CboPiscina);
            this.GroupBox1.Controls.Add(this.chkopen);
            this.GroupBox1.Controls.Add(this.label3);
            this.GroupBox1.Controls.Add(this.ChkMinima);
            this.GroupBox1.Controls.Add(this.CboSexo);
            this.GroupBox1.Controls.Add(this.ChkMay);
            this.GroupBox1.Controls.Add(this.TxtNadadores);
            this.GroupBox1.Controls.Add(this.ChkInfA);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.ChkJuvB);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.ChkInfB);
            this.GroupBox1.Controls.Add(this.datepickerDesde);
            this.GroupBox1.Controls.Add(this.ChkJuvA);
            this.GroupBox1.Location = new System.Drawing.Point(3, 3);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(1739, 90);
            this.GroupBox1.TabIndex = 10;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Categorías";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(638, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 17);
            this.label5.TabIndex = 16;
            this.label5.Text = "Hasta";
            // 
            // DatepickerHasta
            // 
            this.DatepickerHasta.CustomFormat = "dd MM yyyy";
            this.DatepickerHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DatepickerHasta.Location = new System.Drawing.Point(641, 46);
            this.DatepickerHasta.Name = "DatepickerHasta";
            this.DatepickerHasta.Size = new System.Drawing.Size(130, 22);
            this.DatepickerHasta.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1217, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 17);
            this.label4.TabIndex = 14;
            this.label4.Text = "Piscina";
            // 
            // CboPiscina
            // 
            this.CboPiscina.FormattingEnabled = true;
            this.CboPiscina.Items.AddRange(new object[] {
            "S",
            "L"});
            this.CboPiscina.Location = new System.Drawing.Point(1220, 53);
            this.CboPiscina.Name = "CboPiscina";
            this.CboPiscina.Size = new System.Drawing.Size(165, 24);
            this.CboPiscina.TabIndex = 13;
            this.CboPiscina.Text = "Ambas";
            // 
            // chkopen
            // 
            this.chkopen.AutoSize = true;
            this.chkopen.Location = new System.Drawing.Point(392, 21);
            this.chkopen.Name = "chkopen";
            this.chkopen.Size = new System.Drawing.Size(65, 21);
            this.chkopen.TabIndex = 6;
            this.chkopen.Text = "Open";
            this.chkopen.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1046, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Sexo";
            // 
            // ChkMinima
            // 
            this.ChkMinima.AutoSize = true;
            this.ChkMinima.Location = new System.Drawing.Point(15, 21);
            this.ChkMinima.Name = "ChkMinima";
            this.ChkMinima.Size = new System.Drawing.Size(74, 21);
            this.ChkMinima.TabIndex = 0;
            this.ChkMinima.Text = "Mínima";
            this.ChkMinima.UseVisualStyleBackColor = true;
            // 
            // CboSexo
            // 
            this.CboSexo.FormattingEnabled = true;
            this.CboSexo.Items.AddRange(new object[] {
            "F",
            "M"});
            this.CboSexo.Location = new System.Drawing.Point(1049, 53);
            this.CboSexo.Name = "CboSexo";
            this.CboSexo.Size = new System.Drawing.Size(131, 24);
            this.CboSexo.TabIndex = 11;
            this.CboSexo.Text = "Ambos";
            // 
            // ChkMay
            // 
            this.ChkMay.AutoSize = true;
            this.ChkMay.Location = new System.Drawing.Point(272, 61);
            this.ChkMay.Name = "ChkMay";
            this.ChkMay.Size = new System.Drawing.Size(84, 21);
            this.ChkMay.TabIndex = 5;
            this.ChkMay.Text = "Mayores";
            this.ChkMay.UseVisualStyleBackColor = true;
            // 
            // ChkInfA
            // 
            this.ChkInfA.AutoSize = true;
            this.ChkInfA.Location = new System.Drawing.Point(15, 61);
            this.ChkInfA.Name = "ChkInfA";
            this.ChkInfA.Size = new System.Drawing.Size(84, 21);
            this.ChkInfA.TabIndex = 1;
            this.ChkInfA.Text = "Infantil A";
            this.ChkInfA.UseVisualStyleBackColor = true;
            // 
            // ChkJuvB
            // 
            this.ChkJuvB.AutoSize = true;
            this.ChkJuvB.Location = new System.Drawing.Point(269, 21);
            this.ChkJuvB.Name = "ChkJuvB";
            this.ChkJuvB.Size = new System.Drawing.Size(87, 21);
            this.ChkJuvB.TabIndex = 4;
            this.ChkJuvB.Text = "Juvenil B";
            this.ChkJuvB.UseVisualStyleBackColor = true;
            // 
            // ChkInfB
            // 
            this.ChkInfB.AutoSize = true;
            this.ChkInfB.Location = new System.Drawing.Point(137, 21);
            this.ChkInfB.Name = "ChkInfB";
            this.ChkInfB.Size = new System.Drawing.Size(84, 21);
            this.ChkInfB.TabIndex = 2;
            this.ChkInfB.Text = "Infantil B";
            this.ChkInfB.UseVisualStyleBackColor = true;
            // 
            // ChkJuvA
            // 
            this.ChkJuvA.AutoSize = true;
            this.ChkJuvA.Location = new System.Drawing.Point(137, 61);
            this.ChkJuvA.Name = "ChkJuvA";
            this.ChkJuvA.Size = new System.Drawing.Size(87, 21);
            this.ChkJuvA.TabIndex = 3;
            this.ChkJuvA.Text = "Juvenil A";
            this.ChkJuvA.UseVisualStyleBackColor = true;
            // 
            // Grid1
            // 
            this.Grid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ranking,
            this.Nombre,
            this.Apellido,
            this.Distancia,
            this.Estilo,
            this.Tiempo,
            this.Puntos,
            this.Sexo,
            this.Piscina,
            this.Anno,
            this.Fecha,
            this.Equipo,
            this.Categoria,
            this.Edad});
            this.Grid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Grid1.Location = new System.Drawing.Point(3, 99);
            this.Grid1.Name = "Grid1";
            this.Grid1.RowHeadersWidth = 51;
            this.Grid1.RowTemplate.Height = 24;
            this.Grid1.Size = new System.Drawing.Size(1830, 602);
            this.Grid1.TabIndex = 13;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.Grid1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.GroupBox1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1836, 704);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // Ranking
            // 
            this.Ranking.HeaderText = "Ranking";
            this.Ranking.MinimumWidth = 6;
            this.Ranking.Name = "Ranking";
            this.Ranking.Width = 125;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.MinimumWidth = 6;
            this.Nombre.Name = "Nombre";
            this.Nombre.Width = 125;
            // 
            // Apellido
            // 
            this.Apellido.HeaderText = "Apellido";
            this.Apellido.MinimumWidth = 6;
            this.Apellido.Name = "Apellido";
            this.Apellido.Width = 125;
            // 
            // Distancia
            // 
            this.Distancia.HeaderText = "Distancia";
            this.Distancia.MinimumWidth = 6;
            this.Distancia.Name = "Distancia";
            this.Distancia.Width = 125;
            // 
            // Estilo
            // 
            this.Estilo.HeaderText = "Estilo";
            this.Estilo.MinimumWidth = 6;
            this.Estilo.Name = "Estilo";
            this.Estilo.Width = 125;
            // 
            // Tiempo
            // 
            this.Tiempo.HeaderText = "Tiempo";
            this.Tiempo.MinimumWidth = 6;
            this.Tiempo.Name = "Tiempo";
            this.Tiempo.Width = 125;
            // 
            // Puntos
            // 
            this.Puntos.HeaderText = "Puntos";
            this.Puntos.MinimumWidth = 6;
            this.Puntos.Name = "Puntos";
            this.Puntos.Width = 125;
            // 
            // Sexo
            // 
            this.Sexo.HeaderText = "Sexo";
            this.Sexo.MinimumWidth = 6;
            this.Sexo.Name = "Sexo";
            this.Sexo.Width = 125;
            // 
            // Piscina
            // 
            this.Piscina.HeaderText = "Piscina";
            this.Piscina.MinimumWidth = 6;
            this.Piscina.Name = "Piscina";
            this.Piscina.Width = 125;
            // 
            // Anno
            // 
            this.Anno.HeaderText = "Anno";
            this.Anno.MinimumWidth = 6;
            this.Anno.Name = "Anno";
            this.Anno.Width = 125;
            // 
            // Fecha
            // 
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.MinimumWidth = 6;
            this.Fecha.Name = "Fecha";
            this.Fecha.Width = 125;
            // 
            // Equipo
            // 
            this.Equipo.HeaderText = "Equipo";
            this.Equipo.MinimumWidth = 6;
            this.Equipo.Name = "Equipo";
            this.Equipo.Width = 125;
            // 
            // Categoria
            // 
            this.Categoria.HeaderText = "Categoría";
            this.Categoria.MinimumWidth = 6;
            this.Categoria.Name = "Categoria";
            this.Categoria.Width = 125;
            // 
            // Edad
            // 
            this.Edad.HeaderText = "Edad";
            this.Edad.MinimumWidth = 6;
            this.Edad.Name = "Edad";
            this.Edad.Width = 125;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1836, 704);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button BtnCalcular;
        internal System.Windows.Forms.TextBox TxtNadadores;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.DateTimePicker datepickerDesde;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.CheckBox ChkMinima;
        internal System.Windows.Forms.CheckBox ChkMay;
        internal System.Windows.Forms.CheckBox ChkInfA;
        internal System.Windows.Forms.CheckBox ChkJuvB;
        internal System.Windows.Forms.CheckBox ChkInfB;
        internal System.Windows.Forms.CheckBox ChkJuvA;
        private System.Windows.Forms.DataGridView Grid1;
        internal System.Windows.Forms.CheckBox chkopen;
        internal System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CboSexo;
        internal System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CboPiscina;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.DateTimePicker DatepickerHasta;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ranking;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Distancia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estilo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tiempo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Puntos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sexo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Piscina;
        private System.Windows.Forms.DataGridViewTextBoxColumn Anno;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Equipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn Edad;
    }
}

