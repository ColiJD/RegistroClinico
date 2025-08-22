namespace BitacoraLeo
{
	partial class Fr_HistorialClinico
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.txtDiagnostico = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.btnEliminar = new System.Windows.Forms.Button();
			this.btnModificar = new System.Windows.Forms.Button();
			this.btnAgregar = new System.Windows.Forms.Button();
			this.txtBuscar = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.dgvGrip = new System.Windows.Forms.DataGridView();
			this.dtpFecha = new System.Windows.Forms.DateTimePicker();
			this.cbMedico = new System.Windows.Forms.ComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.cbPaciente = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtCodigo = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtSintomas = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtNotas = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.errorProviderGenerico = new System.Windows.Forms.ErrorProvider(this.components);
			this.label10 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.txtObservacion = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.btnDeTrata = new System.Windows.Forms.Button();
			this.btnUpTrata = new System.Windows.Forms.Button();
			this.btnAddTrata = new System.Windows.Forms.Button();
			this.dgvTratamiento = new System.Windows.Forms.DataGridView();
			this.txtDuracion = new System.Windows.Forms.TextBox();
			this.txtDosis = new System.Windows.Forms.TextBox();
			this.txtMedicamentos = new System.Windows.Forms.TextBox();
			this.txtIdTratamiento = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.dgvGrip)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.errorProviderGenerico)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvTratamiento)).BeginInit();
			this.SuspendLayout();
			// 
			// txtDiagnostico
			// 
			this.txtDiagnostico.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtDiagnostico.Location = new System.Drawing.Point(225, 266);
			this.txtDiagnostico.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtDiagnostico.MaximumSize = new System.Drawing.Size(1078, 41);
			this.txtDiagnostico.Multiline = true;
			this.txtDiagnostico.Name = "txtDiagnostico";
			this.txtDiagnostico.Size = new System.Drawing.Size(332, 41);
			this.txtDiagnostico.TabIndex = 121;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(28, 586);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(201, 33);
			this.label3.TabIndex = 120;
			this.label3.Text = "Medicamento";
			// 
			// btnEliminar
			// 
			this.btnEliminar.BackColor = System.Drawing.Color.Blue;
			this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnEliminar.ForeColor = System.Drawing.Color.White;
			this.btnEliminar.Location = new System.Drawing.Point(347, 436);
			this.btnEliminar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnEliminar.Name = "btnEliminar";
			this.btnEliminar.Size = new System.Drawing.Size(150, 50);
			this.btnEliminar.TabIndex = 119;
			this.btnEliminar.Text = "Eliminar";
			this.btnEliminar.UseVisualStyleBackColor = false;
			this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
			// 
			// btnModificar
			// 
			this.btnModificar.BackColor = System.Drawing.Color.Blue;
			this.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnModificar.ForeColor = System.Drawing.Color.White;
			this.btnModificar.Location = new System.Drawing.Point(189, 436);
			this.btnModificar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnModificar.Name = "btnModificar";
			this.btnModificar.Size = new System.Drawing.Size(150, 50);
			this.btnModificar.TabIndex = 118;
			this.btnModificar.Text = "Modificar";
			this.btnModificar.UseVisualStyleBackColor = false;
			this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
			// 
			// btnAgregar
			// 
			this.btnAgregar.BackColor = System.Drawing.Color.Blue;
			this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnAgregar.ForeColor = System.Drawing.Color.White;
			this.btnAgregar.Location = new System.Drawing.Point(31, 436);
			this.btnAgregar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnAgregar.Name = "btnAgregar";
			this.btnAgregar.Size = new System.Drawing.Size(150, 50);
			this.btnAgregar.TabIndex = 117;
			this.btnAgregar.Text = "Agregar";
			this.btnAgregar.UseVisualStyleBackColor = false;
			this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
			// 
			// txtBuscar
			// 
			this.txtBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtBuscar.Location = new System.Drawing.Point(707, 81);
			this.txtBuscar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtBuscar.MaximumSize = new System.Drawing.Size(448, 36);
			this.txtBuscar.Multiline = true;
			this.txtBuscar.Name = "txtBuscar";
			this.txtBuscar.Size = new System.Drawing.Size(393, 36);
			this.txtBuscar.TabIndex = 116;
			this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(587, 84);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(112, 33);
			this.label2.TabIndex = 115;
			this.label2.Text = "Buscar";
			// 
			// dgvGrip
			// 
			this.dgvGrip.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvGrip.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvGrip.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.dgvGrip.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvGrip.Location = new System.Drawing.Point(587, 127);
			this.dgvGrip.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.dgvGrip.Name = "dgvGrip";
			this.dgvGrip.ReadOnly = true;
			this.dgvGrip.RowHeadersWidth = 62;
			this.dgvGrip.Size = new System.Drawing.Size(513, 284);
			this.dgvGrip.TabIndex = 114;
			this.dgvGrip.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGrip_CellContentClick);
			this.dgvGrip.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGrip_CellDoubleClick);
			// 
			// dtpFecha
			// 
			this.dtpFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpFecha.Location = new System.Drawing.Point(170, 221);
			this.dtpFecha.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.dtpFecha.Name = "dtpFecha";
			this.dtpFecha.Size = new System.Drawing.Size(387, 35);
			this.dtpFecha.TabIndex = 113;
			// 
			// cbMedico
			// 
			this.cbMedico.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cbMedico.FormattingEnabled = true;
			this.cbMedico.Location = new System.Drawing.Point(170, 174);
			this.cbMedico.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.cbMedico.Name = "cbMedico";
			this.cbMedico.Size = new System.Drawing.Size(387, 37);
			this.cbMedico.TabIndex = 112;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(28, 178);
			this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(115, 33);
			this.label7.TabIndex = 111;
			this.label7.Text = "Medico";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(28, 223);
			this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(101, 33);
			this.label6.TabIndex = 110;
			this.label6.Text = "Fecha";
			// 
			// cbPaciente
			// 
			this.cbPaciente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cbPaciente.FormattingEnabled = true;
			this.cbPaciente.Location = new System.Drawing.Point(170, 127);
			this.cbPaciente.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.cbPaciente.Name = "cbPaciente";
			this.cbPaciente.Size = new System.Drawing.Size(387, 37);
			this.cbPaciente.TabIndex = 109;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(28, 131);
			this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(136, 33);
			this.label5.TabIndex = 108;
			this.label5.Text = "Paciente";
			// 
			// txtCodigo
			// 
			this.txtCodigo.Enabled = false;
			this.txtCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtCodigo.Location = new System.Drawing.Point(170, 76);
			this.txtCodigo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtCodigo.MaximumSize = new System.Drawing.Size(1078, 41);
			this.txtCodigo.Multiline = true;
			this.txtCodigo.Name = "txtCodigo";
			this.txtCodigo.Size = new System.Drawing.Size(387, 41);
			this.txtCodigo.TabIndex = 107;
			this.txtCodigo.TextChanged += new System.EventHandler(this.txtCodigo_TextChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(28, 84);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(113, 33);
			this.label1.TabIndex = 106;
			this.label1.Text = "Codigo";
			// 
			// txtSintomas
			// 
			this.txtSintomas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtSintomas.Location = new System.Drawing.Point(170, 319);
			this.txtSintomas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtSintomas.MaximumSize = new System.Drawing.Size(1078, 41);
			this.txtSintomas.Multiline = true;
			this.txtSintomas.Name = "txtSintomas";
			this.txtSintomas.Size = new System.Drawing.Size(387, 41);
			this.txtSintomas.TabIndex = 123;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(28, 639);
			this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(94, 33);
			this.label4.TabIndex = 122;
			this.label4.Text = "Dosis";
			// 
			// txtNotas
			// 
			this.txtNotas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtNotas.Location = new System.Drawing.Point(170, 370);
			this.txtNotas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtNotas.MaximumSize = new System.Drawing.Size(1078, 41);
			this.txtNotas.Multiline = true;
			this.txtNotas.Name = "txtNotas";
			this.txtNotas.Size = new System.Drawing.Size(387, 41);
			this.txtNotas.TabIndex = 125;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.Location = new System.Drawing.Point(28, 690);
			this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(140, 33);
			this.label8.TabIndex = 124;
			this.label8.Text = "Duracion";
			// 
			// errorProviderGenerico
			// 
			this.errorProviderGenerico.ContainerControl = this;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label10.Location = new System.Drawing.Point(209, 532);
			this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(182, 33);
			this.label10.TabIndex = 128;
			this.label10.Text = "Tratamiento";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.Location = new System.Drawing.Point(28, 378);
			this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(96, 33);
			this.label9.TabIndex = 133;
			this.label9.Text = "Notas";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label11.Location = new System.Drawing.Point(28, 327);
			this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(145, 33);
			this.label11.TabIndex = 131;
			this.label11.Text = "Sintomas";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label12.Location = new System.Drawing.Point(28, 274);
			this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(179, 33);
			this.label12.TabIndex = 129;
			this.label12.Text = "Diagnostico";
			// 
			// txtObservacion
			// 
			this.txtObservacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtObservacion.Location = new System.Drawing.Point(237, 733);
			this.txtObservacion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtObservacion.MaximumSize = new System.Drawing.Size(1078, 41);
			this.txtObservacion.Multiline = true;
			this.txtObservacion.Name = "txtObservacion";
			this.txtObservacion.Size = new System.Drawing.Size(320, 41);
			this.txtObservacion.TabIndex = 136;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label13.Location = new System.Drawing.Point(28, 741);
			this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(200, 33);
			this.label13.TabIndex = 135;
			this.label13.Text = "Observacion ";
			// 
			// btnDeTrata
			// 
			this.btnDeTrata.BackColor = System.Drawing.Color.Blue;
			this.btnDeTrata.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnDeTrata.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnDeTrata.ForeColor = System.Drawing.Color.White;
			this.btnDeTrata.Location = new System.Drawing.Point(347, 797);
			this.btnDeTrata.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnDeTrata.Name = "btnDeTrata";
			this.btnDeTrata.Size = new System.Drawing.Size(150, 50);
			this.btnDeTrata.TabIndex = 139;
			this.btnDeTrata.Text = "Eliminar";
			this.btnDeTrata.UseVisualStyleBackColor = false;
			this.btnDeTrata.Click += new System.EventHandler(this.btnDeTrata_Click);
			// 
			// btnUpTrata
			// 
			this.btnUpTrata.BackColor = System.Drawing.Color.Blue;
			this.btnUpTrata.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnUpTrata.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnUpTrata.ForeColor = System.Drawing.Color.White;
			this.btnUpTrata.Location = new System.Drawing.Point(189, 797);
			this.btnUpTrata.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnUpTrata.Name = "btnUpTrata";
			this.btnUpTrata.Size = new System.Drawing.Size(150, 50);
			this.btnUpTrata.TabIndex = 138;
			this.btnUpTrata.Text = "Modificar";
			this.btnUpTrata.UseVisualStyleBackColor = false;
			this.btnUpTrata.Click += new System.EventHandler(this.btnUpTrata_Click);
			// 
			// btnAddTrata
			// 
			this.btnAddTrata.BackColor = System.Drawing.Color.Blue;
			this.btnAddTrata.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnAddTrata.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnAddTrata.ForeColor = System.Drawing.Color.White;
			this.btnAddTrata.Location = new System.Drawing.Point(31, 797);
			this.btnAddTrata.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnAddTrata.Name = "btnAddTrata";
			this.btnAddTrata.Size = new System.Drawing.Size(150, 50);
			this.btnAddTrata.TabIndex = 137;
			this.btnAddTrata.Text = "Agregar";
			this.btnAddTrata.UseVisualStyleBackColor = false;
			this.btnAddTrata.Click += new System.EventHandler(this.btnAddTrata_Click);
			// 
			// dgvTratamiento
			// 
			this.dgvTratamiento.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvTratamiento.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvTratamiento.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.dgvTratamiento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvTratamiento.Location = new System.Drawing.Point(587, 532);
			this.dgvTratamiento.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.dgvTratamiento.Name = "dgvTratamiento";
			this.dgvTratamiento.ReadOnly = true;
			this.dgvTratamiento.RowHeadersWidth = 62;
			this.dgvTratamiento.Size = new System.Drawing.Size(513, 330);
			this.dgvTratamiento.TabIndex = 140;
			this.dgvTratamiento.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTratamiento_CellDoubleClick);
			// 
			// txtDuracion
			// 
			this.txtDuracion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtDuracion.Location = new System.Drawing.Point(170, 682);
			this.txtDuracion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtDuracion.MaximumSize = new System.Drawing.Size(1078, 41);
			this.txtDuracion.Multiline = true;
			this.txtDuracion.Name = "txtDuracion";
			this.txtDuracion.Size = new System.Drawing.Size(387, 41);
			this.txtDuracion.TabIndex = 143;
			// 
			// txtDosis
			// 
			this.txtDosis.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtDosis.Location = new System.Drawing.Point(130, 631);
			this.txtDosis.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtDosis.MaximumSize = new System.Drawing.Size(1078, 41);
			this.txtDosis.Multiline = true;
			this.txtDosis.Name = "txtDosis";
			this.txtDosis.Size = new System.Drawing.Size(427, 41);
			this.txtDosis.TabIndex = 142;
			// 
			// txtMedicamentos
			// 
			this.txtMedicamentos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtMedicamentos.Location = new System.Drawing.Point(237, 578);
			this.txtMedicamentos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtMedicamentos.MaximumSize = new System.Drawing.Size(1078, 41);
			this.txtMedicamentos.Multiline = true;
			this.txtMedicamentos.Name = "txtMedicamentos";
			this.txtMedicamentos.Size = new System.Drawing.Size(320, 41);
			this.txtMedicamentos.TabIndex = 141;
			// 
			// txtIdTratamiento
			// 
			this.txtIdTratamiento.Enabled = false;
			this.txtIdTratamiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtIdTratamiento.Location = new System.Drawing.Point(34, 535);
			this.txtIdTratamiento.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtIdTratamiento.MaximumSize = new System.Drawing.Size(30, 30);
			this.txtIdTratamiento.MinimumSize = new System.Drawing.Size(30, 30);
			this.txtIdTratamiento.Multiline = true;
			this.txtIdTratamiento.Name = "txtIdTratamiento";
			this.txtIdTratamiento.Size = new System.Drawing.Size(30, 30);
			this.txtIdTratamiento.TabIndex = 144;
			// 
			// Fr_HistorialClinico
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1128, 894);
			this.Controls.Add(this.txtIdTratamiento);
			this.Controls.Add(this.txtDuracion);
			this.Controls.Add(this.txtDosis);
			this.Controls.Add(this.txtMedicamentos);
			this.Controls.Add(this.dgvTratamiento);
			this.Controls.Add(this.btnDeTrata);
			this.Controls.Add(this.btnUpTrata);
			this.Controls.Add(this.btnAddTrata);
			this.Controls.Add(this.txtObservacion);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.txtNotas);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.txtSintomas);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtDiagnostico);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.btnEliminar);
			this.Controls.Add(this.btnModificar);
			this.Controls.Add(this.btnAgregar);
			this.Controls.Add(this.txtBuscar);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.dgvGrip);
			this.Controls.Add(this.dtpFecha);
			this.Controls.Add(this.cbMedico);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.cbPaciente);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.txtCodigo);
			this.Controls.Add(this.label1);
			this.Name = "Fr_HistorialClinico";
			this.Text = "Fr_HistorialClinico";
			this.Load += new System.EventHandler(this.Fr_HistorialClinico_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgvGrip)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.errorProviderGenerico)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvTratamiento)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.TextBox txtDiagnostico;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnEliminar;
		private System.Windows.Forms.Button btnModificar;
		private System.Windows.Forms.Button btnAgregar;
		private System.Windows.Forms.TextBox txtBuscar;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DataGridView dgvGrip;
		private System.Windows.Forms.DateTimePicker dtpFecha;
		private System.Windows.Forms.ComboBox cbMedico;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox cbPaciente;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtCodigo;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtSintomas;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtNotas;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ErrorProvider errorProviderGenerico;
		private System.Windows.Forms.Button btnDeTrata;
		private System.Windows.Forms.Button btnUpTrata;
		private System.Windows.Forms.Button btnAddTrata;
		private System.Windows.Forms.TextBox txtObservacion;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.DataGridView dgvTratamiento;
		private System.Windows.Forms.TextBox txtDuracion;
		private System.Windows.Forms.TextBox txtDosis;
		private System.Windows.Forms.TextBox txtMedicamentos;
		private System.Windows.Forms.TextBox txtIdTratamiento;
	}
}