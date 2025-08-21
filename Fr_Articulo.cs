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
    public partial class Fr_Articulo : Form
    {
        Conexion clConexion = new Conexion();
        Funciones funciones = new Funciones();
        public Fr_Articulo()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (funciones.CamposVacios(txtArticulo,txtDesc))
            {
                errorProviderGenerico.SetError(txtArticulo, "El campo articulo no puede estar vacío.");
                errorProviderGenerico.SetError(txtDesc, "El campo descripcion no puede estar vacío.");
                MessageBox.Show("Error... No puede insertar datos en blanco", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                {
                    clConexion.abrir();
                    using (var verificar = new SqlCommand("SELECT COUNT(*) FROM Articulo WHERE articulo_Nombre = @articulo_Nombre", clConexion.sconexion))
                    {
                        verificar.Parameters.AddWithValue("@articulo_Nombre", txtArticulo.Text);
                        int count = (int)verificar.ExecuteScalar();

                        if (count > 0)
                        {
                            funciones.LimpiarCampos(txtArticulo);
                            MessageBox.Show("Error... El articulo ya existe en la base de datos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            using (var agregar = new SqlCommand("INSERT INTO Articulo (articulo_Nombre,articulo_Descripcion) " +
                                                                "VALUES (@articulo_Nombre,@articulo_Descripcion)", clConexion.sconexion))
                            {
                                agregar.Parameters.AddWithValue("@articulo_Nombre", txtArticulo.Text);
                                agregar.Parameters.AddWithValue("@articulo_Descripcion", txtDesc.Text);


                                agregar.ExecuteNonQuery();
                                MessageBox.Show("Aviso ... Los Datos se agregaron exitosamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                funciones.LimpiarCampos(txtArticulo, txtBuscar,txtDesc);
                                txtArticulo.Focus();


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

                clConexion.cargarDatos(dgvGrip, "Articulo");
                errorProviderGenerico.Clear();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (funciones.CamposVacios(txtArticulo,txtDesc))
                {
                    errorProviderGenerico.SetError(txtArticulo, "El campo articulo no puede estar vacío.");
                    errorProviderGenerico.SetError(txtDesc, "El campo descripcion no puede estar vacío.");

                    MessageBox.Show("Error... No puede insertar datos en blanco", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                clConexion.abrir();



                txtCodigo.Text = dgvGrip.CurrentRow.Cells[2].Value.ToString();



                using (var verificar = new SqlCommand("SELECT COUNT(*) FROM Articulo WHERE articulo_Nombre = @articulo_Nombre AND id_Articulo != @id_Articulo", clConexion.sconexion))
                {
                    verificar.Parameters.AddWithValue("@articulo_Nombre", txtArticulo.Text);
                    verificar.Parameters.AddWithValue("@id_Articulo", txtCodigo.Text);
                    int count = (int)verificar.ExecuteScalar();

                    if (count > 0)
                    {

                        MessageBox.Show("Error... El articulo ya existe en la base de datos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    using (var modificar = new SqlCommand("UPDATE Articulo SET articulo_Nombre=@articulo_Nombre, articulo_Descripcion=@articulo_Descripcion WHERE id_Articulo=@id_Articulo", clConexion.sconexion))
                    {
                        modificar.Parameters.AddWithValue("@articulo_Nombre", txtArticulo.Text);
                        modificar.Parameters.AddWithValue("@articulo_Descripcion", txtDesc.Text);
                        modificar.Parameters.AddWithValue("@id_Articulo", txtCodigo.Text);

                        modificar.ExecuteNonQuery();
                        MessageBox.Show("Aviso ... Los datos se modificaron exitosamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        funciones.LimpiarCampos(txtArticulo, txtCodigo, txtBuscar,txtDesc);
                        txtArticulo.Focus();
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

                clConexion.cargarDatos(dgvGrip, "Articulo");
                errorProviderGenerico.Clear();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (funciones.CamposVacios(txtArticulo))
                {
                    errorProviderGenerico.SetError(txtArticulo, "Este campo no puede estar vacío.");

                    MessageBox.Show("Error...Seleccione un tipo de Usuario para Eliminar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                clConexion.abrir();
                SqlCommand verificar = new SqlCommand("SELECT COUNT(*) FROM Articulo WHERE articulo_Nombre = @articulo_Nombre", clConexion.sconexion);
                verificar.Parameters.AddWithValue("@articulo_Nombre", txtArticulo.Text);

                int count = (int)verificar.ExecuteScalar();

                if (count == 0)
                {
                    funciones.LimpiarCampos(txtArticulo);
                    MessageBox.Show("Error... El articulo no existe en la base de datos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    SqlCommand eliminar = new SqlCommand("DELETE FROM articulo WHERE articulo_Nombre = @articulo_Nombre", clConexion.sconexion);
                    eliminar.Parameters.AddWithValue("@articulo_Nombre", txtArticulo.Text);
                    eliminar.ExecuteNonQuery();
                    MessageBox.Show("Aviso ... El articulo se eliminó exitosamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    funciones.LimpiarCampos(txtArticulo, txtCodigo, txtBuscar,txtDesc);
                    txtArticulo.Focus();

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
                clConexion.cargarDatos(dgvGrip, "Articulo");
                errorProviderGenerico.Clear();
            }
        }

        private void dgvGrip_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
            txtArticulo.Text = dgvGrip.CurrentRow.Cells[0].Value.ToString();
            txtDesc.Text = dgvGrip.CurrentRow.Cells[1].Value.ToString();
            txtCodigo.Text = dgvGrip.CurrentRow.Cells[2].Value.ToString();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = txtBuscar.Text.Trim();


            clConexion.abrir();

            SqlCommand buscar;

            if (string.IsNullOrWhiteSpace(searchTerm))
            {

                buscar = new SqlCommand("SELECT * FROM Articulo", clConexion.sconexion);
            }
            else
            {

                buscar = new SqlCommand("SELECT * FROM Articulo WHERE articulo_Nombre LIKE @articulo_Nombre", clConexion.sconexion);
                buscar.Parameters.AddWithValue("@articulo_Nombre", "%" + searchTerm + "%");
            }

            SqlDataAdapter adapter = new SqlDataAdapter(buscar);
            DataTable dt = new DataTable();
            adapter.Fill(dt);


            dgvGrip.DataSource = dt;

            clConexion.cerrar();
        }

        private void Fr_Articulo_Load(object sender, EventArgs e)
        {
            clConexion.cargarDatos(dgvGrip, "Articulo");
        }
    }
}
