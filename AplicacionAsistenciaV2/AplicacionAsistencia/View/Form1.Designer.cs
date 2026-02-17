namespace AplicacionAsistencia
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblHMSAMPM = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tabCrearUsuario = new System.Windows.Forms.TabPage();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnModificarUsuario = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.comboBoxEstado = new System.Windows.Forms.ComboBox();
            this.dataGridViewUsuarios = new System.Windows.Forms.DataGridView();
            this.label11 = new System.Windows.Forms.Label();
            this.txtContraseñaNuevo = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBoxRegion = new System.Windows.Forms.ComboBox();
            this.btnCrear = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBoxComuna = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxRol = new System.Windows.Forms.ComboBox();
            this.comboBoxCargo = new System.Windows.Forms.ComboBox();
            this.comboBoxTurno = new System.Windows.Forms.ComboBox();
            this.comboBoxCiudad = new System.Windows.Forms.ComboBox();
            this.txtNombreNuevo = new System.Windows.Forms.TextBox();
            this.txtCorreoNuevo = new System.Windows.Forms.TextBox();
            this.txtDireccionNuevo = new System.Windows.Forms.TextBox();
            this.txtRutNuevo = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.dateTimePickerInicio = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerFin = new System.Windows.Forms.DateTimePicker();
            this.txtRutReporte = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.labelx = new System.Windows.Forms.Label();
            this.comboBoxReporte = new System.Windows.Forms.ComboBox();
            this.btnExportarCSV = new System.Windows.Forms.Button();
            this.dataGridViewReporte = new System.Windows.Forms.DataGridView();
            this.btnGenerarReporte = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabCrearUsuario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsuarios)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReporte)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabCrearUsuario);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(-3, -1);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1368, 763);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(235)))), ((int)(((byte)(239)))));
            this.tabPage1.Controls.Add(this.btnCerrarSesion);
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Controls.Add(this.lblHMSAMPM);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Size = new System.Drawing.Size(1360, 734);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Marcar Asistencia";
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.Location = new System.Drawing.Point(1224, 15);
            this.btnCerrarSesion.Margin = new System.Windows.Forms.Padding(1);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(120, 31);
            this.btnCerrarSesion.TabIndex = 6;
            this.btnCerrarSesion.Text = "Cerrar Sesión";
            this.btnCerrarSesion.UseVisualStyleBackColor = true;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(616, 246);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(106, 83);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // lblHMSAMPM
            // 
            this.lblHMSAMPM.AutoSize = true;
            this.lblHMSAMPM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblHMSAMPM.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHMSAMPM.Location = new System.Drawing.Point(589, 334);
            this.lblHMSAMPM.Name = "lblHMSAMPM";
            this.lblHMSAMPM.Size = new System.Drawing.Size(100, 27);
            this.lblHMSAMPM.TabIndex = 4;
            this.lblHMSAMPM.Text = "00:00:00";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Black;
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Location = new System.Drawing.Point(737, 400);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(95, 27);
            this.button2.TabIndex = 1;
            this.button2.Text = "SALIDA";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(504, 400);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 30);
            this.button1.TabIndex = 0;
            this.button1.Text = "ENTRADA";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabCrearUsuario
            // 
            this.tabCrearUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(235)))), ((int)(((byte)(239)))));
            this.tabCrearUsuario.Controls.Add(this.btnLimpiar);
            this.tabCrearUsuario.Controls.Add(this.btnModificarUsuario);
            this.tabCrearUsuario.Controls.Add(this.label15);
            this.tabCrearUsuario.Controls.Add(this.comboBoxEstado);
            this.tabCrearUsuario.Controls.Add(this.dataGridViewUsuarios);
            this.tabCrearUsuario.Controls.Add(this.label11);
            this.tabCrearUsuario.Controls.Add(this.txtContraseñaNuevo);
            this.tabCrearUsuario.Controls.Add(this.label10);
            this.tabCrearUsuario.Controls.Add(this.comboBoxRegion);
            this.tabCrearUsuario.Controls.Add(this.btnCrear);
            this.tabCrearUsuario.Controls.Add(this.label9);
            this.tabCrearUsuario.Controls.Add(this.comboBoxComuna);
            this.tabCrearUsuario.Controls.Add(this.label8);
            this.tabCrearUsuario.Controls.Add(this.label7);
            this.tabCrearUsuario.Controls.Add(this.label6);
            this.tabCrearUsuario.Controls.Add(this.label5);
            this.tabCrearUsuario.Controls.Add(this.label4);
            this.tabCrearUsuario.Controls.Add(this.label3);
            this.tabCrearUsuario.Controls.Add(this.label2);
            this.tabCrearUsuario.Controls.Add(this.label1);
            this.tabCrearUsuario.Controls.Add(this.comboBoxRol);
            this.tabCrearUsuario.Controls.Add(this.comboBoxCargo);
            this.tabCrearUsuario.Controls.Add(this.comboBoxTurno);
            this.tabCrearUsuario.Controls.Add(this.comboBoxCiudad);
            this.tabCrearUsuario.Controls.Add(this.txtNombreNuevo);
            this.tabCrearUsuario.Controls.Add(this.txtCorreoNuevo);
            this.tabCrearUsuario.Controls.Add(this.txtDireccionNuevo);
            this.tabCrearUsuario.Controls.Add(this.txtRutNuevo);
            this.tabCrearUsuario.ForeColor = System.Drawing.Color.Transparent;
            this.tabCrearUsuario.Location = new System.Drawing.Point(4, 25);
            this.tabCrearUsuario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabCrearUsuario.Name = "tabCrearUsuario";
            this.tabCrearUsuario.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabCrearUsuario.Size = new System.Drawing.Size(1360, 734);
            this.tabCrearUsuario.TabIndex = 1;
            this.tabCrearUsuario.Text = "Crear usuario";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnLimpiar.ForeColor = System.Drawing.Color.Black;
            this.btnLimpiar.Location = new System.Drawing.Point(1217, 97);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 55);
            this.btnLimpiar.TabIndex = 27;
            this.btnLimpiar.Text = "Limpiar campos";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnModificarUsuario
            // 
            this.btnModificarUsuario.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnModificarUsuario.ForeColor = System.Drawing.Color.Black;
            this.btnModificarUsuario.Location = new System.Drawing.Point(842, 243);
            this.btnModificarUsuario.Margin = new System.Windows.Forms.Padding(4);
            this.btnModificarUsuario.Name = "btnModificarUsuario";
            this.btnModificarUsuario.Size = new System.Drawing.Size(100, 28);
            this.btnModificarUsuario.TabIndex = 26;
            this.btnModificarUsuario.Text = "Modificar";
            this.btnModificarUsuario.UseVisualStyleBackColor = false;
            this.btnModificarUsuario.Click += new System.EventHandler(this.btnModificarUsuario_Click_1);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(897, 170);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(50, 16);
            this.label15.TabIndex = 25;
            this.label15.Text = "Estado";
            // 
            // comboBoxEstado
            // 
            this.comboBoxEstado.FormattingEnabled = true;
            this.comboBoxEstado.Items.AddRange(new object[] {
            "Inactivo",
            "Activo"});
            this.comboBoxEstado.Location = new System.Drawing.Point(1033, 167);
            this.comboBoxEstado.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxEstado.Name = "comboBoxEstado";
            this.comboBoxEstado.Size = new System.Drawing.Size(160, 24);
            this.comboBoxEstado.TabIndex = 24;
            // 
            // dataGridViewUsuarios
            // 
            this.dataGridViewUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUsuarios.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridViewUsuarios.Location = new System.Drawing.Point(25, 332);
            this.dataGridViewUsuarios.Name = "dataGridViewUsuarios";
            this.dataGridViewUsuarios.RowHeadersWidth = 51;
            this.dataGridViewUsuarios.RowTemplate.Height = 24;
            this.dataGridViewUsuarios.Size = new System.Drawing.Size(1306, 384);
            this.dataGridViewUsuarios.TabIndex = 23;
            this.dataGridViewUsuarios.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewUsuarios_CellContentClick);
            this.dataGridViewUsuarios.ForeColor = System.Drawing.Color.Black;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(74, 169);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 16);
            this.label11.TabIndex = 22;
            this.label11.Text = "Contraseña";
            // 
            // txtContraseñaNuevo
            // 
            this.txtContraseñaNuevo.Location = new System.Drawing.Point(210, 165);
            this.txtContraseñaNuevo.Margin = new System.Windows.Forms.Padding(4);
            this.txtContraseñaNuevo.Name = "txtContraseñaNuevo";
            this.txtContraseñaNuevo.Size = new System.Drawing.Size(160, 22);
            this.txtContraseñaNuevo.TabIndex = 21;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(484, 102);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 16);
            this.label10.TabIndex = 20;
            this.label10.Text = "Región";
            // 
            // comboBoxRegion
            // 
            this.comboBoxRegion.FormattingEnabled = true;
            this.comboBoxRegion.Location = new System.Drawing.Point(620, 98);
            this.comboBoxRegion.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxRegion.Name = "comboBoxRegion";
            this.comboBoxRegion.Size = new System.Drawing.Size(160, 24);
            this.comboBoxRegion.TabIndex = 19;
            // 
            // btnCrear
            // 
            this.btnCrear.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnCrear.ForeColor = System.Drawing.Color.Black;
            this.btnCrear.Location = new System.Drawing.Point(425, 243);
            this.btnCrear.Margin = new System.Windows.Forms.Padding(4);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(100, 28);
            this.btnCrear.TabIndex = 18;
            this.btnCrear.Text = "Crear";
            this.btnCrear.UseVisualStyleBackColor = false;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(484, 171);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 16);
            this.label9.TabIndex = 17;
            this.label9.Text = "Comuna";
            // 
            // comboBoxComuna
            // 
            this.comboBoxComuna.FormattingEnabled = true;
            this.comboBoxComuna.Location = new System.Drawing.Point(620, 167);
            this.comboBoxComuna.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxComuna.Name = "comboBoxComuna";
            this.comboBoxComuna.Size = new System.Drawing.Size(160, 24);
            this.comboBoxComuna.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(897, 70);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 16);
            this.label8.TabIndex = 15;
            this.label8.Text = "Rol";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(897, 103);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 16);
            this.label7.TabIndex = 14;
            this.label7.Text = "Cargo";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(897, 136);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "Turno";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(484, 136);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "Ciudad";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(484, 70);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "Dirección";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(74, 137);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Correo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(74, 105);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Nombre";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(74, 73);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Rut";
            // 
            // comboBoxRol
            // 
            this.comboBoxRol.FormattingEnabled = true;
            this.comboBoxRol.Location = new System.Drawing.Point(1033, 66);
            this.comboBoxRol.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxRol.Name = "comboBoxRol";
            this.comboBoxRol.Size = new System.Drawing.Size(160, 24);
            this.comboBoxRol.TabIndex = 7;
            // 
            // comboBoxCargo
            // 
            this.comboBoxCargo.FormattingEnabled = true;
            this.comboBoxCargo.Location = new System.Drawing.Point(1033, 99);
            this.comboBoxCargo.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxCargo.Name = "comboBoxCargo";
            this.comboBoxCargo.Size = new System.Drawing.Size(160, 24);
            this.comboBoxCargo.TabIndex = 6;
            // 
            // comboBoxTurno
            // 
            this.comboBoxTurno.FormattingEnabled = true;
            this.comboBoxTurno.Location = new System.Drawing.Point(1033, 133);
            this.comboBoxTurno.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxTurno.Name = "comboBoxTurno";
            this.comboBoxTurno.Size = new System.Drawing.Size(160, 24);
            this.comboBoxTurno.TabIndex = 5;
            // 
            // comboBoxCiudad
            // 
            this.comboBoxCiudad.FormattingEnabled = true;
            this.comboBoxCiudad.Location = new System.Drawing.Point(620, 133);
            this.comboBoxCiudad.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxCiudad.Name = "comboBoxCiudad";
            this.comboBoxCiudad.Size = new System.Drawing.Size(160, 24);
            this.comboBoxCiudad.TabIndex = 4;
            // 
            // txtNombreNuevo
            // 
            this.txtNombreNuevo.Location = new System.Drawing.Point(210, 101);
            this.txtNombreNuevo.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombreNuevo.Name = "txtNombreNuevo";
            this.txtNombreNuevo.Size = new System.Drawing.Size(160, 22);
            this.txtNombreNuevo.TabIndex = 3;
            // 
            // txtCorreoNuevo
            // 
            this.txtCorreoNuevo.Location = new System.Drawing.Point(210, 133);
            this.txtCorreoNuevo.Margin = new System.Windows.Forms.Padding(4);
            this.txtCorreoNuevo.Name = "txtCorreoNuevo";
            this.txtCorreoNuevo.Size = new System.Drawing.Size(160, 22);
            this.txtCorreoNuevo.TabIndex = 2;
            // 
            // txtDireccionNuevo
            // 
            this.txtDireccionNuevo.Location = new System.Drawing.Point(620, 66);
            this.txtDireccionNuevo.Margin = new System.Windows.Forms.Padding(4);
            this.txtDireccionNuevo.Name = "txtDireccionNuevo";
            this.txtDireccionNuevo.Size = new System.Drawing.Size(160, 22);
            this.txtDireccionNuevo.TabIndex = 1;
            // 
            // txtRutNuevo
            // 
            this.txtRutNuevo.Location = new System.Drawing.Point(210, 69);
            this.txtRutNuevo.Margin = new System.Windows.Forms.Padding(4);
            this.txtRutNuevo.Name = "txtRutNuevo";
            this.txtRutNuevo.Size = new System.Drawing.Size(160, 22);
            this.txtRutNuevo.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(235)))), ((int)(((byte)(239)))));
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.dateTimePickerInicio);
            this.tabPage2.Controls.Add(this.dateTimePickerFin);
            this.tabPage2.Controls.Add(this.txtRutReporte);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.labelx);
            this.tabPage2.Controls.Add(this.comboBoxReporte);
            this.tabPage2.Controls.Add(this.btnExportarCSV);
            this.tabPage2.Controls.Add(this.dataGridViewReporte);
            this.tabPage2.Controls.Add(this.btnGenerarReporte);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(1360, 734);
            this.tabPage2.TabIndex = 2;
            this.tabPage2.Text = "Reportes";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(131, 261);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(92, 16);
            this.label13.TabIndex = 14;
            this.label13.Text = "Fecha término";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(131, 212);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(79, 16);
            this.label12.TabIndex = 13;
            this.label12.Text = "Fecha inicio";
            // 
            // dateTimePickerInicio
            // 
            this.dateTimePickerInicio.Location = new System.Drawing.Point(278, 207);
            this.dateTimePickerInicio.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePickerInicio.Name = "dateTimePickerInicio";
            this.dateTimePickerInicio.Size = new System.Drawing.Size(265, 22);
            this.dateTimePickerInicio.TabIndex = 12;
            // 
            // dateTimePickerFin
            // 
            this.dateTimePickerFin.Location = new System.Drawing.Point(278, 257);
            this.dateTimePickerFin.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePickerFin.Name = "dateTimePickerFin";
            this.dateTimePickerFin.Size = new System.Drawing.Size(265, 22);
            this.dateTimePickerFin.TabIndex = 11;
            // 
            // txtRutReporte
            // 
            this.txtRutReporte.Location = new System.Drawing.Point(278, 154);
            this.txtRutReporte.Name = "txtRutReporte";
            this.txtRutReporte.Size = new System.Drawing.Size(121, 22);
            this.txtRutReporte.TabIndex = 10;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(131, 160);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(95, 16);
            this.label14.TabIndex = 9;
            this.label14.Text = "Rut funcionario";
            // 
            // labelx
            // 
            this.labelx.AutoSize = true;
            this.labelx.Location = new System.Drawing.Point(131, 111);
            this.labelx.Name = "labelx";
            this.labelx.Size = new System.Drawing.Size(56, 16);
            this.labelx.TabIndex = 8;
            this.labelx.Text = "Reporte";
            // 
            // comboBoxReporte
            // 
            this.comboBoxReporte.FormattingEnabled = true;
            this.comboBoxReporte.Items.AddRange(new object[] {
            "General",
            "Atrasos",
            "Salida Adelantada",
            "Inasistencias"});
            this.comboBoxReporte.Location = new System.Drawing.Point(278, 106);
            this.comboBoxReporte.Name = "comboBoxReporte";
            this.comboBoxReporte.Size = new System.Drawing.Size(121, 24);
            this.comboBoxReporte.TabIndex = 7;
            // 
            // btnExportarCSV
            // 
            this.btnExportarCSV.Location = new System.Drawing.Point(402, 401);
            this.btnExportarCSV.Margin = new System.Windows.Forms.Padding(4);
            this.btnExportarCSV.Name = "btnExportarCSV";
            this.btnExportarCSV.Size = new System.Drawing.Size(141, 28);
            this.btnExportarCSV.TabIndex = 4;
            this.btnExportarCSV.Text = "Exportar Reporte";
            this.btnExportarCSV.UseVisualStyleBackColor = true;
            // 
            // dataGridViewReporte
            // 
            this.dataGridViewReporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReporte.Location = new System.Drawing.Point(692, 31);
            this.dataGridViewReporte.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewReporte.Name = "dataGridViewReporte";
            this.dataGridViewReporte.RowHeadersWidth = 51;
            this.dataGridViewReporte.Size = new System.Drawing.Size(624, 663);
            this.dataGridViewReporte.TabIndex = 3;
            // 
            // btnGenerarReporte
            // 
            this.btnGenerarReporte.Location = new System.Drawing.Point(134, 401);
            this.btnGenerarReporte.Margin = new System.Windows.Forms.Padding(4);
            this.btnGenerarReporte.Name = "btnGenerarReporte";
            this.btnGenerarReporte.Size = new System.Drawing.Size(139, 28);
            this.btnGenerarReporte.TabIndex = 2;
            this.btnGenerarReporte.Text = "Generar Reporte";
            this.btnGenerarReporte.UseVisualStyleBackColor = true;
            this.btnGenerarReporte.Click += new System.EventHandler(this.btnGenerarReporte_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1368, 759);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabCrearUsuario.ResumeLayout(false);
            this.tabCrearUsuario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsuarios)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReporte)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabCrearUsuario;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblHMSAMPM;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.ComboBox comboBoxRol;
        private System.Windows.Forms.ComboBox comboBoxCargo;
        private System.Windows.Forms.ComboBox comboBoxTurno;
        private System.Windows.Forms.ComboBox comboBoxCiudad;
        private System.Windows.Forms.TextBox txtNombreNuevo;
        private System.Windows.Forms.TextBox txtCorreoNuevo;
        private System.Windows.Forms.TextBox txtDireccionNuevo;
        private System.Windows.Forms.TextBox txtRutNuevo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBoxComuna;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBoxRegion;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtContraseñaNuevo;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnGenerarReporte;
        private System.Windows.Forms.DataGridView dataGridViewReporte;
        private System.Windows.Forms.Button btnExportarCSV;
        private System.Windows.Forms.Label labelx;
        private System.Windows.Forms.ComboBox comboBoxReporte;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dateTimePickerInicio;
        private System.Windows.Forms.DateTimePicker dateTimePickerFin;
        private System.Windows.Forms.TextBox txtRutReporte;
        private System.Windows.Forms.DataGridView dataGridViewUsuarios;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox comboBoxEstado;
        private System.Windows.Forms.Button btnModificarUsuario;
        private System.Windows.Forms.Button btnLimpiar;
    }
}

