using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BitacoraLeo
{
    public partial class Fr_Usuarios : Form
    {
        Conexion clConexion = new Conexion();
        Funciones funciones = new Funciones();
        private string tipo_Usuario = "";
        private int codigo = 0;
        public Fr_Usuarios()
        {
            InitializeComponent();
        }


        private void Fr_Usuarios_Load(object sender, EventArgs e)
            
        {
           
            clConexion.cargarDatos(dgvUsuarios, "Usuarios");
            // Comando SQL para obtener los tipos de usuario
            string consultaSQL = "SELECT codigo_tipo, nombre_tipo FROM Tipo_Usuario";

            // Ejecutar la consulta y obtener el resultado en un DataTable
            DataTable tiposDeUsuario = clConexion.EjecutarConsulta(consultaSQL);

            // Asignar el DataTable al ComboBox
            cbTipoUsuario.DataSource = tiposDeUsuario;
            cbTipoUsuario.DisplayMember = "nombre_tipo";
            cbTipoUsuario.ValueMember = "codigo_tipo";
            clConexion.cerrar();

            funciones.SoloLetras(txtNombre);
            funciones.RestringirContraseña(txtContra);
            funciones.RestringirCorreoElectronico(txtCorreo);



        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbTipoUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verifica si hay un elemento seleccionado
            if (cbTipoUsuario.SelectedValue != null)
            {
                // Obtiene el valor seleccionado (el código del tipo de usuario)
                tipo_Usuario = cbTipoUsuario.SelectedValue.ToString();

                // Puedes usar la variable tipo_Usuario como desees
                Console.WriteLine("Código del tipo de usuario seleccionado: " + tipo_Usuario);

                // Realiza alguna acción adicional con tipo_Usuario, si es necesario
                // Ejemplo: Mostrar información relacionada con el tipo de usuario
                // O hacer una consulta a la base de datos si es necesario
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {  // Verificar si hay campos vacíos y mostrar errores
            if (funciones.CamposVacios(txtNombre, txtUsuario, txtContra, txtCorreo) || string.IsNullOrWhiteSpace(cbTipoUsuario.Text))
            {
                errorP_Usuarios.SetError(txtNombre, "El nombre de usuario no puede estar vacío.");
                errorP_Usuarios.SetError(txtUsuario, "Este campo no puede estar vacío.");
                errorP_Usuarios.SetError(txtContra, "Debe ingresar una contraseña.");
                errorP_Usuarios.SetError(txtCorreo, "El correo no puede estar vacío.");
                errorP_Usuarios.SetError(cbTipoUsuario, "Debe seleccionar un tipo de usuario.");
                MessageBox.Show("Error... No puede insertar datos en blanco", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
               
                {
                    clConexion.abrir(); // Abrir la conexión a la base de datos

                    // Verificar si el nombre del usuario ya existe en la base de datos
                    using (var verificar = new SqlCommand("SELECT COUNT(*) FROM Usuarios WHERE username = @username", clConexion.sconexion))
                    {
                        verificar.Parameters.AddWithValue("@username", txtUsuario.Text);
                        int count = (int)verificar.ExecuteScalar();

                        if (count > 0)
                        {
                            funciones.LimpiarCampos(txtUsuario);
                            MessageBox.Show("Error... El nombre del usuario ya existe en la base de datos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            // Inserción del usuario en la base de datos
                            using (var agregar = new SqlCommand("INSERT INTO Usuarios (nombre_usuario, username, password, codigo_tipo, correo) " +
                                                                "VALUES (@nombre_usuario, @username, @password, @codigo_tipo, @correo)", clConexion.sconexion))
                            {
                                agregar.Parameters.AddWithValue("@nombre_usuario", txtNombre.Text);
                                agregar.Parameters.AddWithValue("@username", txtUsuario.Text);
                                agregar.Parameters.AddWithValue("@password", txtContra.Text);
                                agregar.Parameters.AddWithValue("@codigo_tipo", cbTipoUsuario.SelectedValue); // Asegúrate de que este valor es correcto
                                agregar.Parameters.AddWithValue("@correo", txtCorreo.Text);

                                agregar.ExecuteNonQuery(); // Ejecutar la inserción
                                MessageBox.Show("Aviso ... Los Datos se agregaron exitosamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Limpiar los campos después de la inserción
                                funciones.LimpiarCampos(txtNombre, txtUsuario, txtContra, txtCorreo, txtBuscar);
                                cbTipoUsuario.ResetText(); // Limpiar el ComboBox
                                txtNombre.Focus(); // Foco en el campo de nombre de usuario

                               
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error en la base de datos... " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error... " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                clConexion.cerrar();
                // Actualizar la tabla de usuarios
                clConexion.cargarDatos(dgvUsuarios, "Usuarios");
                errorP_Usuarios.Clear(); // Limpiar todos los mensajes de error
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = txtBuscar.Text.Trim();

           
            clConexion.abrir();

            SqlCommand buscar;

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                // Si el campo está vacío, selecciona todos los clientes
                buscar = new SqlCommand("SELECT * FROM Usuarios", clConexion.sconexion);
            }
            else
            {
                // Si hay texto en el campo, filtra por el nombre del cliente
                buscar = new SqlCommand("SELECT * FROM Usuarios WHERE username LIKE @username", clConexion.sconexion);
                buscar.Parameters.AddWithValue("@username", "%" + searchTerm + "%");
            }

            SqlDataAdapter adapter = new SqlDataAdapter(buscar);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            // Asignar los resultados al DataGridView
            dgvUsuarios.DataSource = dt;

            clConexion.cerrar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si hay campos vacíos y mostrar errores
                if (funciones.CamposVacios(txtNombre, txtUsuario, txtContra, txtCorreo) || string.IsNullOrWhiteSpace(cbTipoUsuario.Text))
                {
                    // Establecer los mensajes de error
                    errorP_Usuarios.SetError(txtNombre, "El nombre de usuario no puede estar vacío.");
                    errorP_Usuarios.SetError(txtUsuario, "Este campo no puede estar vacío.");
                    errorP_Usuarios.SetError(txtContra, "Debe ingresar una contraseña.");
                    errorP_Usuarios.SetError(txtCorreo, "El correo no puede estar vacío.");
                    errorP_Usuarios.SetError(cbTipoUsuario, "Debe seleccionar un tipo de usuario.");
                    MessageBox.Show("Error... No puede insertar datos en blanco", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Abrir la conexión a la base de datos
                clConexion.abrir();

                // Obtener el código del usuario desde la fila seleccionada en el DataGridView
                codigo = Convert.ToInt32(dgvUsuarios.CurrentRow.Cells[0].Value);

                // Verificar si el nombre de usuario ya existe en la base de datos (excluyendo el usuario actual)
                using (var verificar = new SqlCommand("SELECT COUNT(*) FROM Usuarios WHERE username = @username AND codigo_usuario != @codigo_usuario", clConexion.sconexion))
                {
                    verificar.Parameters.AddWithValue("@username", txtUsuario.Text);
                    verificar.Parameters.AddWithValue("@codigo_usuario", codigo);  // Asegúrate de que se usa el código correcto
                    int count = (int)verificar.ExecuteScalar();

                    if (count > 0)
                    {
                        // Si el usuario ya existe, mostrar mensaje de error
                        MessageBox.Show("Error... El nombre del usuario ya existe en la base de datos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Proceder con la modificación del usuario en la base de datos
                    using (var modificar = new SqlCommand("UPDATE Usuarios SET nombre_usuario=@nombre_usuario, username=@username, password=@password, codigo_tipo=@codigo_tipo, correo=@correo WHERE codigo_usuario=@codigo_usuario", clConexion.sconexion))
                    {
                        modificar.Parameters.AddWithValue("@nombre_usuario", txtNombre.Text);
                        modificar.Parameters.AddWithValue("@username", txtUsuario.Text);
                        modificar.Parameters.AddWithValue("@password", txtContra.Text);
                        modificar.Parameters.AddWithValue("@codigo_tipo", cbTipoUsuario.SelectedValue); // Asegúrate de que este valor es correcto
                        modificar.Parameters.AddWithValue("@correo", txtCorreo.Text);
                        modificar.Parameters.AddWithValue("@codigo_usuario", codigo);  // Usar el código para realizar la actualización

                        modificar.ExecuteNonQuery(); // Ejecutar la modificación
                        MessageBox.Show("Aviso ... Los datos se modificaron exitosamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Limpiar los campos después de la modificación
                        funciones.LimpiarCampos(txtNombre, txtUsuario, txtContra, txtCorreo, txtBuscar);
                        cbTipoUsuario.ResetText(); // Limpiar el ComboBox
                        txtNombre.Focus(); // Poner el foco en el campo de nombre
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error en la base de datos... " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error... " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                clConexion.cerrar(); // Cerrar la conexión a la base de datos
                                     // Actualizar la tabla de usuarios
                clConexion.cargarDatos(dgvUsuarios, "Usuarios");
                errorP_Usuarios.Clear(); // Limpiar todos los mensajes de error
            }
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si hay campos vacíos y mostrar errores
                if (funciones.CamposVacios(txtUsuario))
                {
                    errorP_Usuarios.SetError(txtUsuario, "Este campo no puede estar vacío.");
                    MessageBox.Show("Error...Seleccione un nombre de Usuario para Eliminar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Abrir la conexión a la base de datos
                clConexion.abrir();

                // Verificar si el usuario existe en la base de datos antes de eliminarlo
                SqlCommand verificar = new SqlCommand("SELECT COUNT(*) FROM Usuarios WHERE username = @username", clConexion.sconexion);
                verificar.Parameters.AddWithValue("@username", txtUsuario.Text);

                int count = (int)verificar.ExecuteScalar();

                if (count == 0)
                {
                    funciones.LimpiarCampos(txtUsuario);
                    // Si el usuario no existe, mostramos un mensaje de error
                    MessageBox.Show("Error... El usuario no existe en la base de datos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // Si el usuario existe, procedemos con la eliminación
                    SqlCommand eliminar = new SqlCommand("DELETE FROM Usuarios WHERE username = @username", clConexion.sconexion);
                    eliminar.Parameters.AddWithValue("@username", txtUsuario.Text);

                    eliminar.ExecuteNonQuery();
                    MessageBox.Show("Aviso ... El usuario se eliminó exitosamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Limpiar los campos después de la eliminación
                    funciones.LimpiarCampos(txtNombre, txtUsuario, txtContra, txtCorreo, txtBuscar);
                    cbTipoUsuario.ResetText(); // Limpiar el ComboBox
                    txtNombre.Focus(); // Foco en el campo de nombre de usuario

                    // Actualizar la tabla de usuarios
                   
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error en la base de datos... " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error... " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                clConexion.cerrar();
                clConexion.cargarDatos(dgvUsuarios, "Usuarios");
                errorP_Usuarios.Clear(); // Limpiar todos los mensajes de error
            }
        }

        private void dgvUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Obtener el ID del usuario desde la primera celda de la fila seleccionada
            codigo = Convert.ToInt32(dgvUsuarios.CurrentRow.Cells[0].Value);
            txtNombre.Text = dgvUsuarios.CurrentRow.Cells[1].Value.ToString();
            txtUsuario.Text = dgvUsuarios.CurrentRow.Cells[2].Value.ToString();
            txtContra.Text = dgvUsuarios.CurrentRow.Cells[3].Value.ToString();
            tipo_Usuario = dgvUsuarios.CurrentRow.Cells[4].Value.ToString();

            // Establece el valor del ComboBox a la categoría correspondiente
            cbTipoUsuario.SelectedValue = tipo_Usuario;
            txtCorreo.Text = dgvUsuarios.CurrentRow.Cells[5].Value.ToString();
            
        }
    }
}
