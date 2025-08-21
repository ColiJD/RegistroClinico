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

namespace BitacoraLeo
{
    public partial class Fr_TipoUsuarios : Form
    {
        Conexion clConexion = new Conexion();
        Funciones funciones = new Funciones();
        public Fr_TipoUsuarios()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Verificar si hay campos vacíos y mostrar errores
            if (funciones.CamposVacios(txtTipoUsuario))
            {
                errorProviderGenerico.SetError(txtTipoUsuario, "El tipo de usuario no puede estar vacío.");
                MessageBox.Show("Error... No puede insertar datos en blanco", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {

                {
                    clConexion.abrir(); // Abrir la conexión a la base de datos

                    // Verificar si el nombre del usuario ya existe en la base de datos
                    using (var verificar = new SqlCommand("SELECT COUNT(*) FROM Tipo_Usuario WHERE nombre_tipo = @nombre_tipo", clConexion.sconexion))
                    {
                        verificar.Parameters.AddWithValue("@nombre_tipo", txtTipoUsuario.Text);
                        int count = (int)verificar.ExecuteScalar();

                        if (count > 0)
                        {
                            funciones.LimpiarCampos(txtTipoUsuario);
                            MessageBox.Show("Error... El tipo de usuario ya existe en la base de datos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            // Inserción del usuario en la base de datos
                            using (var agregar = new SqlCommand("INSERT INTO Tipo_Usuario (nombre_tipo) " +
                                                                "VALUES (@nombre_tipo)", clConexion.sconexion))
                            {
                                agregar.Parameters.AddWithValue("@nombre_tipo", txtTipoUsuario.Text);
                               

                                agregar.ExecuteNonQuery(); // Ejecutar la inserción
                                MessageBox.Show("Aviso ... Los Datos se agregaron exitosamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Limpiar los campos después de la inserción
                                funciones.LimpiarCampos(txtTipoUsuario,txtBuscar);
                                txtTipoUsuario.Focus(); // Foco en el campo de nombre de usuario


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
                clConexion.cargarDatos(dgvGrip, "Tipo_Usuario");
                errorProviderGenerico.Clear(); // Limpiar todos los mensajes de error
            }

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si hay campos vacíos y mostrar errores
                if (funciones.CamposVacios(txtTipoUsuario))
                {
                    // Establecer los mensajes de error
                    errorProviderGenerico.SetError(txtTipoUsuario, "El tipo de usuario no puede estar vacío.");
                   
                    MessageBox.Show("Error... No puede insertar datos en blanco", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Abrir la conexión a la base de datos
                clConexion.abrir();

                
               
                txtCodigo.Text = dgvGrip.CurrentRow.Cells[0].Value.ToString();


               
                using (var verificar = new SqlCommand("SELECT COUNT(*) FROM Tipo_Usuario WHERE nombre_tipo = @nombre_tipo AND codigo_tipo != @codigo_tipo", clConexion.sconexion))
                {
                    verificar.Parameters.AddWithValue("@nombre_tipo", txtTipoUsuario.Text);
                    verificar.Parameters.AddWithValue("@codigo_tipo", txtCodigo.Text);  
                    int count = (int)verificar.ExecuteScalar();

                    if (count > 0)
                    {
                        
                        MessageBox.Show("Error... El tipo de usuario ya existe en la base de datos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Proceder con la modificación del usuario en la base de datos
                    using (var modificar = new SqlCommand("UPDATE Tipo_Usuario SET nombre_tipo=@nombre_tipo WHERE codigo_tipo=@codigo_tipo", clConexion.sconexion))
                    {
                        modificar.Parameters.AddWithValue("@nombre_tipo", txtTipoUsuario.Text);
                       
                        modificar.Parameters.AddWithValue("@codigo_tipo", txtCodigo.Text);

                        modificar.ExecuteNonQuery(); // Ejecutar la modificación
                        MessageBox.Show("Aviso ... Los datos se modificaron exitosamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Limpiar los campos después de la modificación
                        funciones.LimpiarCampos(txtTipoUsuario,txtCodigo, txtBuscar);
                        txtTipoUsuario.Focus(); // Poner el foco en el campo de nombre
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
                clConexion.cargarDatos(dgvGrip, "Tipo_Usuario");
                errorProviderGenerico.Clear(); // Limpiar todos los mensajes de error
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si hay campos vacíos y mostrar errores
                if (funciones.CamposVacios(txtTipoUsuario))
                {
                    errorProviderGenerico.SetError(txtTipoUsuario, "Este campo no puede estar vacío.");
                    MessageBox.Show("Error...Seleccione un tipo de Usuario para Eliminar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Abrir la conexión a la base de datos
                clConexion.abrir();

                // Verificar si el usuario existe en la base de datos antes de eliminarlo
                SqlCommand verificar = new SqlCommand("SELECT COUNT(*) FROM Tipo_Usuario WHERE nombre_tipo = @nombre_tipo", clConexion.sconexion);
                verificar.Parameters.AddWithValue("@nombre_tipo", txtTipoUsuario.Text);

                int count = (int)verificar.ExecuteScalar();

                if (count == 0)
                {
                    funciones.LimpiarCampos(txtTipoUsuario);
                    // Si el usuario no existe, mostramos un mensaje de error
                    MessageBox.Show("Error... El tipo de usuario no existe en la base de datos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // Si el usuario existe, procedemos con la eliminación
                    SqlCommand eliminar = new SqlCommand("DELETE FROM Tipo_Usuario WHERE nombre_tipo = @nombre_tipo", clConexion.sconexion);
                    eliminar.Parameters.AddWithValue("@nombre_tipo", txtTipoUsuario.Text);

                    eliminar.ExecuteNonQuery();
                    MessageBox.Show("Aviso ... El tipo de usuario se eliminó exitosamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Limpiar los campos después de la eliminación
                    funciones.LimpiarCampos(txtTipoUsuario, txtCodigo, txtBuscar);
                    txtTipoUsuario.Focus(); // Foco en el campo de nombre de usuario

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
                clConexion.cargarDatos(dgvGrip, "Tipo_Usuario");
                errorProviderGenerico.Clear(); // Limpiar todos los mensajes de error
            }
        }

        private void dgvGrip_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Obtener el ID del usuario desde la primera celda de la fila seleccionada
            txtCodigo.Text = dgvGrip.CurrentRow.Cells[0].Value.ToString();
            txtTipoUsuario.Text = dgvGrip.CurrentRow.Cells[1].Value.ToString();
           
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = txtBuscar.Text.Trim();


            clConexion.abrir();

            SqlCommand buscar;

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                // Si el campo está vacío, selecciona todos los clientes
                buscar = new SqlCommand("SELECT * FROM Tipo_Usuario", clConexion.sconexion);
            }
            else
            {
                // Si hay texto en el campo, filtra por el nombre del cliente
                buscar = new SqlCommand("SELECT * FROM Tipo_Usuario WHERE nombre_tipo LIKE @nombre_tipo", clConexion.sconexion);
                buscar.Parameters.AddWithValue("@nombre_tipo", "%" + searchTerm + "%");
            }

            SqlDataAdapter adapter = new SqlDataAdapter(buscar);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            // Asignar los resultados al DataGridView
            dgvGrip.DataSource = dt;

            clConexion.cerrar();
        }

        private void Fr_TipoUsuarios_Load(object sender, EventArgs e)
        {
            clConexion.cargarDatos(dgvGrip, "Tipo_Usuario");
        }
    }
}
