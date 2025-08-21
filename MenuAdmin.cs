using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;
using ComboBox = System.Windows.Forms.ComboBox;
using TextBox = System.Windows.Forms.TextBox;

namespace BitacoraLeo
{
    public partial class MenuAdmin : Form
    {
        private Form currentChildForm;


        public MenuAdmin()
        {
            InitializeComponent();
        }
        private void MenuAdmin_Load(object sender, EventArgs e)
        {
            // Establecer los límites para evitar que la barra de tareas sea ocultada
            this.MaximumSize = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);

            // Maximizar el formulario
            this.WindowState = FormWindowState.Maximized;

        }
        public void OpenChildForm(Form childForm)
        {
            // Cerrar el formulario hijo actual si existe
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }

            currentChildForm = childForm;

            // Configurar el nuevo formulario hijo
            childForm.TopLevel = false; // No se comporta como un formulario principal
            childForm.FormBorderStyle = FormBorderStyle.None; // Sin bordes
            childForm.Dock = DockStyle.Fill; // Ocupar todo el espacio disponible

            // Añadir el formulario hijo al panel contenedor
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;

            // Traer al frente y mostrar el formulario hijo
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Fr_Usuarios());
        }

        private void btnTipoUsuario_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Fr_TipoUsuarios());
        }

        private void btnMarca_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Fr_Marcas());
        }

        private void btnModelo_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Fr_Modelo());
        }

        private void btnArticulos_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Fr_Articulo());
        }

        private void btnProveedor_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Fr_Paciente());
        }

        private void btnBitacora_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Bitacora());
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
            Fr_Login Fr_Login = new Fr_Login();
            Fr_Login.Show();
        }
        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void plSuperior_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {

            OpenChildForm(new Fr_Reporte());
        }


        private void btnMax_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void btnmin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void plSuperior_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

       
    }
}
