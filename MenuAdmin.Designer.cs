namespace BitacoraLeo
{
    partial class MenuAdmin
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
			this.btnUsuarios = new System.Windows.Forms.Button();
			this.btnTipoUsuario = new System.Windows.Forms.Button();
			this.btnPacientes = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnHistorial = new System.Windows.Forms.Button();
			this.btnCitas = new System.Windows.Forms.Button();
			this.btnMedicos = new System.Windows.Forms.Button();
			this.panel3 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.plSuperior = new System.Windows.Forms.Panel();
			this.btnmin = new System.Windows.Forms.Button();
			this.btnMax = new System.Windows.Forms.Button();
			this.btnCerrar = new System.Windows.Forms.Button();
			this.panelDesktop = new System.Windows.Forms.Panel();
			this.panel1.SuspendLayout();
			this.plSuperior.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnUsuarios
			// 
			this.btnUsuarios.BackColor = System.Drawing.Color.Maroon;
			this.btnUsuarios.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnUsuarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnUsuarios.ForeColor = System.Drawing.Color.White;
			this.btnUsuarios.Location = new System.Drawing.Point(0, 229);
			this.btnUsuarios.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnUsuarios.Name = "btnUsuarios";
			this.btnUsuarios.Size = new System.Drawing.Size(225, 77);
			this.btnUsuarios.TabIndex = 1;
			this.btnUsuarios.Text = "Usuarios";
			this.btnUsuarios.UseVisualStyleBackColor = false;
			this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
			// 
			// btnTipoUsuario
			// 
			this.btnTipoUsuario.BackColor = System.Drawing.Color.Maroon;
			this.btnTipoUsuario.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnTipoUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnTipoUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnTipoUsuario.ForeColor = System.Drawing.Color.White;
			this.btnTipoUsuario.Location = new System.Drawing.Point(0, 306);
			this.btnTipoUsuario.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnTipoUsuario.Name = "btnTipoUsuario";
			this.btnTipoUsuario.Size = new System.Drawing.Size(225, 77);
			this.btnTipoUsuario.TabIndex = 2;
			this.btnTipoUsuario.Text = "Tipo Usuarios";
			this.btnTipoUsuario.UseVisualStyleBackColor = false;
			this.btnTipoUsuario.Click += new System.EventHandler(this.btnTipoUsuario_Click);
			// 
			// btnPacientes
			// 
			this.btnPacientes.BackColor = System.Drawing.Color.Maroon;
			this.btnPacientes.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnPacientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnPacientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnPacientes.ForeColor = System.Drawing.Color.White;
			this.btnPacientes.Location = new System.Drawing.Point(0, 383);
			this.btnPacientes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnPacientes.Name = "btnPacientes";
			this.btnPacientes.Size = new System.Drawing.Size(225, 77);
			this.btnPacientes.TabIndex = 7;
			this.btnPacientes.Text = "Pacientes";
			this.btnPacientes.UseVisualStyleBackColor = false;
			this.btnPacientes.Click += new System.EventHandler(this.btnProveedor_Click);
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.Chocolate;
			this.panel1.Controls.Add(this.btnHistorial);
			this.panel1.Controls.Add(this.btnCitas);
			this.panel1.Controls.Add(this.btnMedicos);
			this.panel1.Controls.Add(this.btnPacientes);
			this.panel1.Controls.Add(this.btnTipoUsuario);
			this.panel1.Controls.Add(this.btnUsuarios);
			this.panel1.Controls.Add(this.panel3);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(225, 986);
			this.panel1.TabIndex = 0;
			// 
			// btnHistorial
			// 
			this.btnHistorial.BackColor = System.Drawing.Color.Maroon;
			this.btnHistorial.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnHistorial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnHistorial.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnHistorial.ForeColor = System.Drawing.Color.White;
			this.btnHistorial.Location = new System.Drawing.Point(0, 614);
			this.btnHistorial.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnHistorial.Name = "btnHistorial";
			this.btnHistorial.Size = new System.Drawing.Size(225, 77);
			this.btnHistorial.TabIndex = 11;
			this.btnHistorial.Text = "Historial";
			this.btnHistorial.UseVisualStyleBackColor = false;
			this.btnHistorial.Click += new System.EventHandler(this.btnHistorial_Click);
			// 
			// btnCitas
			// 
			this.btnCitas.BackColor = System.Drawing.Color.Maroon;
			this.btnCitas.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnCitas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCitas.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnCitas.ForeColor = System.Drawing.Color.White;
			this.btnCitas.Location = new System.Drawing.Point(0, 537);
			this.btnCitas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnCitas.Name = "btnCitas";
			this.btnCitas.Size = new System.Drawing.Size(225, 77);
			this.btnCitas.TabIndex = 10;
			this.btnCitas.Text = "Citas";
			this.btnCitas.UseVisualStyleBackColor = false;
			this.btnCitas.Click += new System.EventHandler(this.btnCitas_Click);
			// 
			// btnMedicos
			// 
			this.btnMedicos.BackColor = System.Drawing.Color.Maroon;
			this.btnMedicos.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnMedicos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnMedicos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnMedicos.ForeColor = System.Drawing.Color.White;
			this.btnMedicos.Location = new System.Drawing.Point(0, 460);
			this.btnMedicos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnMedicos.Name = "btnMedicos";
			this.btnMedicos.Size = new System.Drawing.Size(225, 77);
			this.btnMedicos.TabIndex = 9;
			this.btnMedicos.Text = "Medicos";
			this.btnMedicos.UseVisualStyleBackColor = false;
			this.btnMedicos.Click += new System.EventHandler(this.btnMedicos_Click);
			// 
			// panel3
			// 
			this.panel3.BackColor = System.Drawing.Color.Chocolate;
			this.panel3.BackgroundImage = global::BitacoraLeo.Properties.Resources.logo;
			this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(0, 0);
			this.panel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(225, 229);
			this.panel3.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.Snow;
			this.label1.Location = new System.Drawing.Point(27, 28);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(372, 33);
			this.label1.TabIndex = 2;
			this.label1.Text = "Bienvenido Administrador";
			// 
			// plSuperior
			// 
			this.plSuperior.BackColor = System.Drawing.Color.Chocolate;
			this.plSuperior.Controls.Add(this.btnmin);
			this.plSuperior.Controls.Add(this.btnMax);
			this.plSuperior.Controls.Add(this.label1);
			this.plSuperior.Controls.Add(this.btnCerrar);
			this.plSuperior.Dock = System.Windows.Forms.DockStyle.Top;
			this.plSuperior.Location = new System.Drawing.Point(225, 0);
			this.plSuperior.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.plSuperior.Name = "plSuperior";
			this.plSuperior.Size = new System.Drawing.Size(1203, 92);
			this.plSuperior.TabIndex = 1;
			this.plSuperior.Paint += new System.Windows.Forms.PaintEventHandler(this.plSuperior_Paint);
			this.plSuperior.MouseDown += new System.Windows.Forms.MouseEventHandler(this.plSuperior_MouseDown);
			// 
			// btnmin
			// 
			this.btnmin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnmin.BackColor = System.Drawing.Color.Snow;
			this.btnmin.BackgroundImage = global::BitacoraLeo.Properties.Resources.minimizar;
			this.btnmin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btnmin.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnmin.ForeColor = System.Drawing.Color.White;
			this.btnmin.Location = new System.Drawing.Point(1032, 18);
			this.btnmin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnmin.Name = "btnmin";
			this.btnmin.Size = new System.Drawing.Size(45, 46);
			this.btnmin.TabIndex = 4;
			this.btnmin.UseVisualStyleBackColor = false;
			this.btnmin.Click += new System.EventHandler(this.btnmin_Click);
			// 
			// btnMax
			// 
			this.btnMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnMax.BackColor = System.Drawing.Color.Snow;
			this.btnMax.BackgroundImage = global::BitacoraLeo.Properties.Resources.maximizar;
			this.btnMax.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btnMax.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnMax.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnMax.ForeColor = System.Drawing.Color.White;
			this.btnMax.Location = new System.Drawing.Point(1086, 18);
			this.btnMax.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnMax.Name = "btnMax";
			this.btnMax.Size = new System.Drawing.Size(45, 46);
			this.btnMax.TabIndex = 3;
			this.btnMax.UseVisualStyleBackColor = false;
			this.btnMax.Click += new System.EventHandler(this.btnMax_Click);
			// 
			// btnCerrar
			// 
			this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCerrar.BackColor = System.Drawing.Color.Red;
			this.btnCerrar.BackgroundImage = global::BitacoraLeo.Properties.Resources.cerrar;
			this.btnCerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnCerrar.ForeColor = System.Drawing.Color.White;
			this.btnCerrar.Location = new System.Drawing.Point(1140, 18);
			this.btnCerrar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnCerrar.Name = "btnCerrar";
			this.btnCerrar.Size = new System.Drawing.Size(45, 46);
			this.btnCerrar.TabIndex = 1;
			this.btnCerrar.UseVisualStyleBackColor = false;
			this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
			// 
			// panelDesktop
			// 
			this.panelDesktop.BackColor = System.Drawing.Color.White;
			this.panelDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelDesktop.Location = new System.Drawing.Point(225, 92);
			this.panelDesktop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.panelDesktop.Name = "panelDesktop";
			this.panelDesktop.Size = new System.Drawing.Size(1203, 894);
			this.panelDesktop.TabIndex = 4;
			// 
			// MenuAdmin
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.CornflowerBlue;
			this.ClientSize = new System.Drawing.Size(1428, 986);
			this.Controls.Add(this.panelDesktop);
			this.Controls.Add(this.plSuperior);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.Name = "MenuAdmin";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "MenuAdmin";
			this.Load += new System.EventHandler(this.MenuAdmin_Load);
			this.panel1.ResumeLayout(false);
			this.plSuperior.ResumeLayout(false);
			this.plSuperior.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnUsuarios;
        private System.Windows.Forms.Button btnTipoUsuario;
        private System.Windows.Forms.Button btnPacientes;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel plSuperior;
        private System.Windows.Forms.Button btnmin;
        private System.Windows.Forms.Button btnMax;
        private System.Windows.Forms.Panel panelDesktop;
		private System.Windows.Forms.Button btnMedicos;
		private System.Windows.Forms.Button btnCitas;
		private System.Windows.Forms.Button btnHistorial;
	}
}