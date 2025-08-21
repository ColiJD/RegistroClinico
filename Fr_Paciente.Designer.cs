namespace BitacoraLeo
{
    partial class Fr_Paciente
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
			this.btnEliminar = new System.Windows.Forms.Button();
			this.btnModificar = new System.Windows.Forms.Button();
			this.txtNombre = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtBuscar = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtCodigo = new System.Windows.Forms.TextBox();
			this.btnAgregar = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.dgvGrip = new System.Windows.Forms.DataGridView();
			this.txtTelefono = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtCorreo = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.errorProviderGenerico = new System.Windows.Forms.ErrorProvider(this.components);
			this.txtCedula = new System.Windows.Forms.TextBox();
			this.Cedula = new System.Windows.Forms.Label();
			this.txtApellido = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.dtpNacimiento = new System.Windows.Forms.DateTimePicker();
			this.label9 = new System.Windows.Forms.Label();
			this.txtDireccion = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.txtSexo = new System.Windows.Forms.ComboBox();
			((System.ComponentModel.ISupportInitialize)(this.dgvGrip)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.errorProviderGenerico)).BeginInit();
			this.SuspendLayout();
			// 
			// btnEliminar
			// 
			this.btnEliminar.BackColor = System.Drawing.Color.Blue;
			this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnEliminar.ForeColor = System.Drawing.Color.White;
			this.btnEliminar.Location = new System.Drawing.Point(397, 565);
			this.btnEliminar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnEliminar.Name = "btnEliminar";
			this.btnEliminar.Size = new System.Drawing.Size(150, 77);
			this.btnEliminar.TabIndex = 62;
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
			this.btnModificar.Location = new System.Drawing.Point(210, 565);
			this.btnModificar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnModificar.Name = "btnModificar";
			this.btnModificar.Size = new System.Drawing.Size(150, 77);
			this.btnModificar.TabIndex = 61;
			this.btnModificar.Text = "Modificar";
			this.btnModificar.UseVisualStyleBackColor = false;
			this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
			// 
			// txtNombre
			// 
			this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtNombre.Location = new System.Drawing.Point(160, 179);
			this.txtNombre.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtNombre.MaximumSize = new System.Drawing.Size(1078, 41);
			this.txtNombre.Multiline = true;
			this.txtNombre.Name = "txtNombre";
			this.txtNombre.Size = new System.Drawing.Size(387, 41);
			this.txtNombre.TabIndex = 60;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(18, 187);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(125, 33);
			this.label3.TabIndex = 59;
			this.label3.Text = "Nombre";
			// 
			// txtBuscar
			// 
			this.txtBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtBuscar.Location = new System.Drawing.Point(597, 80);
			this.txtBuscar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtBuscar.MaximumSize = new System.Drawing.Size(448, 36);
			this.txtBuscar.Multiline = true;
			this.txtBuscar.Name = "txtBuscar";
			this.txtBuscar.Size = new System.Drawing.Size(448, 36);
			this.txtBuscar.TabIndex = 58;
			this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(591, 38);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(112, 33);
			this.label2.TabIndex = 57;
			this.label2.Text = "Buscar";
			// 
			// txtCodigo
			// 
			this.txtCodigo.Enabled = false;
			this.txtCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtCodigo.Location = new System.Drawing.Point(160, 77);
			this.txtCodigo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtCodigo.MaximumSize = new System.Drawing.Size(1078, 41);
			this.txtCodigo.Multiline = true;
			this.txtCodigo.Name = "txtCodigo";
			this.txtCodigo.Size = new System.Drawing.Size(387, 41);
			this.txtCodigo.TabIndex = 56;
			this.txtCodigo.Tag = "";
			// 
			// btnAgregar
			// 
			this.btnAgregar.BackColor = System.Drawing.Color.Blue;
			this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnAgregar.ForeColor = System.Drawing.Color.White;
			this.btnAgregar.Location = new System.Drawing.Point(22, 565);
			this.btnAgregar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnAgregar.Name = "btnAgregar";
			this.btnAgregar.Size = new System.Drawing.Size(150, 77);
			this.btnAgregar.TabIndex = 55;
			this.btnAgregar.Text = "Agregar";
			this.btnAgregar.UseVisualStyleBackColor = false;
			this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(18, 85);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(113, 33);
			this.label1.TabIndex = 54;
			this.label1.Text = "Codigo";
			// 
			// dgvGrip
			// 
			this.dgvGrip.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvGrip.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvGrip.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.dgvGrip.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvGrip.Location = new System.Drawing.Point(597, 128);
			this.dgvGrip.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.dgvGrip.Name = "dgvGrip";
			this.dgvGrip.ReadOnly = true;
			this.dgvGrip.RowHeadersWidth = 62;
			this.dgvGrip.Size = new System.Drawing.Size(513, 514);
			this.dgvGrip.TabIndex = 53;
			this.dgvGrip.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGrip_CellContentClick);
			this.dgvGrip.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGrip_CellDoubleClick);
			// 
			// txtTelefono
			// 
			this.txtTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtTelefono.Location = new System.Drawing.Point(160, 388);
			this.txtTelefono.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtTelefono.MaximumSize = new System.Drawing.Size(1078, 41);
			this.txtTelefono.Multiline = true;
			this.txtTelefono.Name = "txtTelefono";
			this.txtTelefono.Size = new System.Drawing.Size(387, 41);
			this.txtTelefono.TabIndex = 64;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(18, 396);
			this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(136, 33);
			this.label4.TabIndex = 63;
			this.label4.Text = "Telefono";
			// 
			// txtCorreo
			// 
			this.txtCorreo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtCorreo.Location = new System.Drawing.Point(160, 439);
			this.txtCorreo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtCorreo.MaximumSize = new System.Drawing.Size(1078, 41);
			this.txtCorreo.Multiline = true;
			this.txtCorreo.Name = "txtCorreo";
			this.txtCorreo.Size = new System.Drawing.Size(387, 41);
			this.txtCorreo.TabIndex = 66;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(18, 447);
			this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(110, 33);
			this.label5.TabIndex = 65;
			this.label5.Text = "Correo";
			// 
			// errorProviderGenerico
			// 
			this.errorProviderGenerico.ContainerControl = this;
			// 
			// txtCedula
			// 
			this.txtCedula.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtCedula.Location = new System.Drawing.Point(160, 128);
			this.txtCedula.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtCedula.MaximumSize = new System.Drawing.Size(1078, 41);
			this.txtCedula.Multiline = true;
			this.txtCedula.Name = "txtCedula";
			this.txtCedula.Size = new System.Drawing.Size(387, 41);
			this.txtCedula.TabIndex = 68;
			// 
			// Cedula
			// 
			this.Cedula.AutoSize = true;
			this.Cedula.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Cedula.Location = new System.Drawing.Point(18, 136);
			this.Cedula.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.Cedula.Name = "Cedula";
			this.Cedula.Size = new System.Drawing.Size(113, 33);
			this.Cedula.TabIndex = 67;
			this.Cedula.Text = "Cedula";
			// 
			// txtApellido
			// 
			this.txtApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtApellido.Location = new System.Drawing.Point(160, 236);
			this.txtApellido.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtApellido.MaximumSize = new System.Drawing.Size(1078, 41);
			this.txtApellido.Multiline = true;
			this.txtApellido.Name = "txtApellido";
			this.txtApellido.Size = new System.Drawing.Size(387, 41);
			this.txtApellido.TabIndex = 70;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(18, 244);
			this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(127, 33);
			this.label6.TabIndex = 69;
			this.label6.Text = "Apellido";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(18, 299);
			this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(267, 33);
			this.label7.TabIndex = 75;
			this.label7.Text = "Fecha Nacimiento";
			// 
			// dtpNacimiento
			// 
			this.dtpNacimiento.Location = new System.Drawing.Point(292, 291);
			this.dtpNacimiento.MinimumSize = new System.Drawing.Size(0, 41);
			this.dtpNacimiento.Name = "dtpNacimiento";
			this.dtpNacimiento.Size = new System.Drawing.Size(255, 41);
			this.dtpNacimiento.TabIndex = 76;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.Location = new System.Drawing.Point(18, 345);
			this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(85, 33);
			this.label9.TabIndex = 77;
			this.label9.Text = "Sexo";
			// 
			// txtDireccion
			// 
			this.txtDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtDireccion.Location = new System.Drawing.Point(160, 490);
			this.txtDireccion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtDireccion.MaximumSize = new System.Drawing.Size(1078, 41);
			this.txtDireccion.Multiline = true;
			this.txtDireccion.Name = "txtDireccion";
			this.txtDireccion.Size = new System.Drawing.Size(387, 41);
			this.txtDireccion.TabIndex = 80;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.Location = new System.Drawing.Point(18, 498);
			this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(147, 33);
			this.label8.TabIndex = 79;
			this.label8.Text = "Direccion";
			// 
			// txtSexo
			// 
			this.txtSexo.FormattingEnabled = true;
			this.txtSexo.Items.AddRange(new object[] {
            "M",
            "F"});
			this.txtSexo.Location = new System.Drawing.Point(160, 345);
			this.txtSexo.Name = "txtSexo";
			this.txtSexo.Size = new System.Drawing.Size(387, 28);
			this.txtSexo.TabIndex = 81;
			// 
			// Fr_Paciente
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1128, 678);
			this.Controls.Add(this.txtSexo);
			this.Controls.Add(this.txtDireccion);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.dtpNacimiento);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.txtApellido);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.txtCedula);
			this.Controls.Add(this.Cedula);
			this.Controls.Add(this.txtCorreo);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.txtTelefono);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.btnEliminar);
			this.Controls.Add(this.btnModificar);
			this.Controls.Add(this.txtNombre);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtBuscar);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtCodigo);
			this.Controls.Add(this.btnAgregar);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dgvGrip);
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.Name = "Fr_Paciente";
			this.Text = "Fr_Paciente";
			this.Load += new System.EventHandler(this.Fr_Proveedores_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgvGrip)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.errorProviderGenerico)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvGrip;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ErrorProvider errorProviderGenerico;
		private System.Windows.Forms.TextBox txtCedula;
		private System.Windows.Forms.Label Cedula;
		private System.Windows.Forms.TextBox txtApellido;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtDireccion;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.DateTimePicker dtpNacimiento;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox txtSexo;
	}
}