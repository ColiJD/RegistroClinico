using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace BitacoraLeo
{
    public partial class Fr_Login : Form
    {
        
        Conexion clConexion = new Conexion();
        Funciones funciones = new Funciones();
        public Fr_Login()
        {
            InitializeComponent();
        }

        private void Fr_Login_Load(object sender, EventArgs e)
        {
            // Configuración inicial del TextBox para que oculte la contraseña
            txtPass.UseSystemPasswordChar = true;
            



        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            int tipologin = 0;

            // Validación de campos vacíos
            if (funciones.CamposVacios(txtPass, txtUsuario))
            {
                errorProviderUsuario.SetError(txtUsuario, "El campo usuario no puede estar vacío.");
                errorProviderContra.SetError(txtPass, "El campo contraseña no puede estar vacío.");
                MessageBox.Show("Error... No puede insertar datos en blanco", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SqlDataReader sda = null;
            try
            {
                clConexion.abrir();

                SqlCommand cmd = new SqlCommand("SELECT codigo_usuario, username, codigo_tipo, password FROM Usuarios WHERE username = @username AND password = @password", clConexion.sconexion);

                cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = txtUsuario.Text;
                cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = txtPass.Text;

                sda = cmd.ExecuteReader();

                if (sda.Read())
                {
                    tipologin = Convert.ToInt32(sda["codigo_tipo"]);  // Usar el nombre de columna en lugar del índice
                    string mensaje = "Usuario Encontrado";

                    // Muestra mensaje dependiendo del tipo de usuario
                    switch (tipologin)
                    {
                        case 1:
                            MessageBox.Show(mensaje);
                            Fr_Login.ActiveForm.Hide();
                            MenuAdmin fr_MenuAdmin = new MenuAdmin();
                            fr_MenuAdmin.Show();
                            break;
                        case 2:
                            MessageBox.Show(mensaje);
                            Fr_Login.ActiveForm.Hide();
                            Fr_MenuUsuarios fr_MenuUsuarios = new Fr_MenuUsuarios();
                            fr_MenuUsuarios.Show();
                            break;
                        case 3:
                            MessageBox.Show(mensaje);
                            Fr_Login.ActiveForm.Hide();
                            Fr_Public fr_Public = new Fr_Public();
                            fr_Public.Show();
                            break;
                        case 4:
                            MessageBox.Show(mensaje);
                            Fr_Login.ActiveForm.Hide();
                            Fr_Generico fr_Generico = new Fr_Generico();
                            fr_Generico.Show();
                            break;
                        default:
                            MessageBox.Show("Tipo de usuario desconocido.");
                            break;
                    }

                    // Limpieza de errores
                    errorProviderContra.Clear();
                    errorProviderUsuario.Clear();
                }
                else
                {
                    MessageBox.Show("Usuario No Encontrado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al intentar acceder: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Cerrar el lector de datos si está abierto
                if (sda != null && !sda.IsClosed)
                {
                    sda.Close();
                }

                // Cerrar la conexión
                clConexion.cerrar();
            }
        }

        private void chbVisible_CheckedChanged(object sender, EventArgs e)
        {
            // Cambiar la visibilidad de la contraseña según el estado del CheckBox
            txtPass.UseSystemPasswordChar = !chbVisible.Checked;
        }
        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void plSuperior_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Fr_Login_Shown(object sender, EventArgs e)
        {
            txtUsuario.Focus();
        }
    }
}