namespace BitacoraLeo
{
    partial class Fr_Login
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
			this.plSuperior = new System.Windows.Forms.Panel();
			this.btnCerrar = new System.Windows.Forms.Button();
			this.btnAcceder = new System.Windows.Forms.Button();
			this.txtUsuario = new System.Windows.Forms.TextBox();
			this.Usuario = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtPass = new System.Windows.Forms.TextBox();
			this.errorProviderUsuario = new System.Windows.Forms.ErrorProvider(this.components);
			this.errorProviderContra = new System.Windows.Forms.ErrorProvider(this.components);
			this.panel1 = new System.Windows.Forms.Panel();
			this.chbVisible = new System.Windows.Forms.CheckBox();
			this.plSuperior.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.errorProviderUsuario)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.errorProviderContra)).BeginInit();
			this.SuspendLayout();
			// 
			// plSuperior
			// 
			this.plSuperior.BackColor = System.Drawing.Color.Gold;
			this.plSuperior.Controls.Add(this.btnCerrar);
			this.plSuperior.Dock = System.Windows.Forms.DockStyle.Top;
			this.plSuperior.Location = new System.Drawing.Point(0, 0);
			this.plSuperior.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.plSuperior.Name = "plSuperior";
			this.plSuperior.Size = new System.Drawing.Size(1128, 92);
			this.plSuperior.TabIndex = 2;
			this.plSuperior.MouseDown += new System.Windows.Forms.MouseEventHandler(this.plSuperior_MouseDown);
			// 
			// btnCerrar
			// 
			this.btnCerrar.BackColor = System.Drawing.Color.Red;
			this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnCerrar.ForeColor = System.Drawing.Color.White;
			this.btnCerrar.Location = new System.Drawing.Point(1066, 18);
			this.btnCerrar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnCerrar.Name = "btnCerrar";
			this.btnCerrar.Size = new System.Drawing.Size(45, 46);
			this.btnCerrar.TabIndex = 0;
			this.btnCerrar.Text = "X";
			this.btnCerrar.UseVisualStyleBackColor = false;
			this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
			// 
			// btnAcceder
			// 
			this.btnAcceder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAcceder.BackColor = System.Drawing.Color.Gold;
			this.btnAcceder.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnAcceder.Location = new System.Drawing.Point(446, 551);
			this.btnAcceder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnAcceder.Name = "btnAcceder";
			this.btnAcceder.Size = new System.Drawing.Size(226, 77);
			this.btnAcceder.TabIndex = 3;
			this.btnAcceder.Text = "Acceder";
			this.btnAcceder.UseVisualStyleBackColor = false;
			this.btnAcceder.Click += new System.EventHandler(this.btnAcceder_Click);
			// 
			// txtUsuario
			// 
			this.txtUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.txtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtUsuario.Location = new System.Drawing.Point(303, 374);
			this.txtUsuario.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtUsuario.Name = "txtUsuario";
			this.txtUsuario.Size = new System.Drawing.Size(523, 40);
			this.txtUsuario.TabIndex = 4;
			// 
			// Usuario
			// 
			this.Usuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.Usuario.AutoSize = true;
			this.Usuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Usuario.Location = new System.Drawing.Point(297, 332);
			this.Usuario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.Usuario.Name = "Usuario";
			this.Usuario.Size = new System.Drawing.Size(123, 33);
			this.Usuario.TabIndex = 5;
			this.Usuario.Text = "Usuario";
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(297, 437);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(175, 33);
			this.label2.TabIndex = 7;
			this.label2.Text = "Contraseña";
			// 
			// txtPass
			// 
			this.txtPass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.txtPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtPass.Location = new System.Drawing.Point(303, 478);
			this.txtPass.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtPass.Name = "txtPass";
			this.txtPass.Size = new System.Drawing.Size(523, 40);
			this.txtPass.TabIndex = 6;
			// 
			// errorProviderUsuario
			// 
			this.errorProviderUsuario.ContainerControl = this;
			// 
			// errorProviderContra
			// 
			this.errorProviderContra.ContainerControl = this;
			// 
			// panel1
			// 
			this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.panel1.BackgroundImage = global::BitacoraLeo.Properties.Resources.logo;
			this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.panel1.Enabled = false;
			this.panel1.Location = new System.Drawing.Point(446, 102);
			this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(226, 226);
			this.panel1.TabIndex = 8;
			// 
			// chbVisible
			// 
			this.chbVisible.AutoSize = true;
			this.chbVisible.Location = new System.Drawing.Point(837, 495);
			this.chbVisible.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.chbVisible.Name = "chbVisible";
			this.chbVisible.Size = new System.Drawing.Size(22, 21);
			this.chbVisible.TabIndex = 9;
			this.chbVisible.UseVisualStyleBackColor = true;
			this.chbVisible.CheckedChanged += new System.EventHandler(this.chbVisible_CheckedChanged);
			// 
			// Fr_Login
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(1128, 678);
			this.Controls.Add(this.chbVisible);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtPass);
			this.Controls.Add(this.Usuario);
			this.Controls.Add(this.txtUsuario);
			this.Controls.Add(this.btnAcceder);
			this.Controls.Add(this.plSuperior);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.Name = "Fr_Login";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Fr_Login";
			this.Load += new System.EventHandler(this.Fr_Login_Load);
			this.Shown += new System.EventHandler(this.Fr_Login_Shown);
			this.plSuperior.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.errorProviderUsuario)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.errorProviderContra)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel plSuperior;
        private System.Windows.Forms.Button btnAcceder;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label Usuario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.ErrorProvider errorProviderUsuario;
        private System.Windows.Forms.ErrorProvider errorProviderContra;
        private System.Windows.Forms.CheckBox chbVisible;
    }
}