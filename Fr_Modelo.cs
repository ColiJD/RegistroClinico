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
    
    public partial class Fr_Modelo : Form
    {
        Conexion clConexion = new Conexion();
        Funciones funciones = new Funciones();
        public Fr_Modelo()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (funciones.CamposVacios(txtModelo))
            {
                errorProviderGenerico.SetError(txtModelo, "El campo no puede estar vacío.");
                MessageBox.Show("Error... No puede insertar datos en blanco", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                {
                    clConexion.abrir();
                    using (var verificar = new SqlCommand("SELECT COUNT(*) FROM Modelo WHERE modelo_Nombre = @modelo_Nombre", clConexion.sconexion))
                    {
                        verificar.Parameters.AddWithValue("@modelo_Nombre", txtModelo.Text);
                        int count = (int)verificar.ExecuteScalar();

                        if (count > 0)
                        {
                            funciones.LimpiarCampos(txtModelo);
                            MessageBox.Show("Error... El modelo ya existe en la base de datos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            using (var agregar = new SqlCommand("INSERT INTO Modelo (modelo_Nombre) " +
                                                                "VALUES (@modelo_Nombre)", clConexion.sconexion))
                            {
                                agregar.Parameters.AddWithValue("@modelo_Nombre", txtModelo.Text);


                                agregar.ExecuteNonQuery();
                                MessageBox.Show("Aviso ... Los Datos se agregaron exitosamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                funciones.LimpiarCampos(txtModelo, txtBuscar);
                                txtModelo.Focus();


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

                clConexion.cargarDatos(dgvGrip, "Modelo");
                errorProviderGenerico.Clear();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (funciones.CamposVacios(txtModelo))
                {
                    errorProviderGenerico.SetError(txtModelo, "El campo no puede estar vacío.");

                    MessageBox.Show("Error... No puede insertar datos en blanco", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                clConexion.abrir();



                txtCodigo.Text = dgvGrip.CurrentRow.Cells[0].Value.ToString();



                using (var verificar = new SqlCommand("SELECT COUNT(*) FROM Modelo WHERE modelo_Nombre = @modelo_Nombre AND id_Modelo != @id_Modelo", clConexion.sconexion))
                {
                    verificar.Parameters.AddWithValue("@modelo_Nombre", txtModelo.Text);
                    verificar.Parameters.AddWithValue("@id_Modelo", txtCodigo.Text);
                    int count = (int)verificar.ExecuteScalar();

                    if (count > 0)
                    {

                        MessageBox.Show("Error... El modelo ya existe en la base de datos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    using (var modificar = new SqlCommand("UPDATE Modelo SET modelo_Nombre=@modelo_Nombre WHERE id_Modelo=@id_Modelo", clConexion.sconexion))
                    {
                        modificar.Parameters.AddWithValue("@modelo_Nombre", txtModelo.Text);

                        modificar.Parameters.AddWithValue("@id_Modelo", txtCodigo.Text);

                        modificar.ExecuteNonQuery();
                        MessageBox.Show("Aviso ... Los datos se modificaron exitosamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        funciones.LimpiarCampos(txtModelo, txtCodigo, txtBuscar);
                        txtModelo.Focus();
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

                clConexion.cargarDatos(dgvGrip, "Modelo");
                errorProviderGenerico.Clear();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (funciones.CamposVacios(txtModelo))
                {
                    errorProviderGenerico.SetError(txtModelo, "Este campo no puede estar vacío.");
                    MessageBox.Show("Error...Seleccione un tipo de Usuario para Eliminar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                clConexion.abrir();
                SqlCommand verificar = new SqlCommand("SELECT COUNT(*) FROM Modelo WHERE modelo_Nombre = @modelo_Nombre", clConexion.sconexion);
                verificar.Parameters.AddWithValue("@modelo_Nombre", txtModelo.Text);

                int count = (int)verificar.ExecuteScalar();

                if (count == 0)
                {
                    funciones.LimpiarCampos(txtModelo);
                    MessageBox.Show("Error... El modelo no existe en la base de datos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    SqlCommand eliminar = new SqlCommand("DELETE FROM Modelo WHERE modelo_Nombre = @modelo_Nombre", clConexion.sconexion);
                    eliminar.Parameters.AddWithValue("@modelo_Nombre", txtModelo.Text);
                    eliminar.ExecuteNonQuery();
                    MessageBox.Show("Aviso ... El modelo se eliminó exitosamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    funciones.LimpiarCampos(txtModelo, txtCodigo, txtBuscar);
                    txtModelo.Focus();

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
                clConexion.cargarDatos(dgvGrip, "Modelo");
                errorProviderGenerico.Clear();
            }
        }

        private void dgvGrip_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigo.Text = dgvGrip.CurrentRow.Cells[0].Value.ToString();
            txtModelo.Text = dgvGrip.CurrentRow.Cells[1].Value.ToString();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = txtBuscar.Text.Trim();


            clConexion.abrir();

            SqlCommand buscar;

            if (string.IsNullOrWhiteSpace(searchTerm))
            {

                buscar = new SqlCommand("SELECT * FROM Modelo", clConexion.sconexion);
            }
            else
            {

                buscar = new SqlCommand("SELECT * FROM Modelo WHERE modelo_Nombre LIKE @modelo_Nombre", clConexion.sconexion);
                buscar.Parameters.AddWithValue("@modelo_Nombre", "%" + searchTerm + "%");
            }

            SqlDataAdapter adapter = new SqlDataAdapter(buscar);
            DataTable dt = new DataTable();
            adapter.Fill(dt);


            dgvGrip.DataSource = dt;

            clConexion.cerrar();
        }

        private void Fr_Modelo_Load(object sender, EventArgs e)
        {
            clConexion.cargarDatos(dgvGrip, "Modelo");
        }
    }
}
