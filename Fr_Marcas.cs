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
    public partial class Fr_Marcas : Form
    {
        Conexion clConexion = new Conexion();
        Funciones funciones = new Funciones();
        public Fr_Marcas()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (funciones.CamposVacios(txtMarca))
            {
                errorProviderGenerico.SetError(txtMarca, "El campo no puede estar vacío.");
                MessageBox.Show("Error... No puede insertar datos en blanco", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                {
                    clConexion.abrir();
                    using (var verificar = new SqlCommand("SELECT COUNT(*) FROM Marca WHERE marca_Nombre = @marca_Nombre", clConexion.sconexion))
                    {
                        verificar.Parameters.AddWithValue("@marca_Nombre", txtMarca.Text);
                        int count = (int)verificar.ExecuteScalar();

                        if (count > 0)
                        {
                            funciones.LimpiarCampos(txtMarca);
                            MessageBox.Show("Error... La marca ya existe en la base de datos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            using (var agregar = new SqlCommand("INSERT INTO Marca (marca_Nombre) " +
                                                                "VALUES (@marca_Nombre)", clConexion.sconexion))
                            {
                                agregar.Parameters.AddWithValue("@marca_Nombre", txtMarca.Text);


                                agregar.ExecuteNonQuery(); 
                                MessageBox.Show("Aviso ... Los Datos se agregaron exitosamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                funciones.LimpiarCampos(txtMarca, txtBuscar);
                                txtMarca.Focus();


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
                
                clConexion.cargarDatos(dgvGrip, "Marca");
                errorProviderGenerico.Clear();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (funciones.CamposVacios(txtMarca))
                {
                    errorProviderGenerico.SetError(txtMarca, "El campo no puede estar vacío.");

                    MessageBox.Show("Error... No puede insertar datos en blanco", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                clConexion.abrir();



                txtCodigo.Text = dgvGrip.CurrentRow.Cells[0].Value.ToString();



                using (var verificar = new SqlCommand("SELECT COUNT(*) FROM Marca WHERE marca_Nombre = @marca_Nombre AND id_Marca != @id_Marca", clConexion.sconexion))
                {
                    verificar.Parameters.AddWithValue("@marca_Nombre", txtMarca.Text);
                    verificar.Parameters.AddWithValue("@id_Marca", txtCodigo.Text);
                    int count = (int)verificar.ExecuteScalar();

                    if (count > 0)
                    {

                        MessageBox.Show("Error... La marca ya existe en la base de datos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    using (var modificar = new SqlCommand("UPDATE Marca SET marca_Nombre=@marca_Nombre WHERE id_Marca=@id_Marca", clConexion.sconexion))
                    {
                        modificar.Parameters.AddWithValue("@marca_Nombre", txtMarca.Text);

                        modificar.Parameters.AddWithValue("@id_Marca", txtCodigo.Text);

                        modificar.ExecuteNonQuery();
                        MessageBox.Show("Aviso ... Los datos se modificaron exitosamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        funciones.LimpiarCampos(txtMarca, txtCodigo, txtBuscar);
                        txtMarca.Focus(); 
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
                                     
                clConexion.cargarDatos(dgvGrip, "Marca");
                errorProviderGenerico.Clear(); 
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (funciones.CamposVacios(txtMarca))
                {
                    errorProviderGenerico.SetError(txtMarca, "Este campo no puede estar vacío.");
                    MessageBox.Show("Error...Seleccione un tipo de Usuario para Eliminar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                clConexion.abrir();
                SqlCommand verificar = new SqlCommand("SELECT COUNT(*) FROM Marca WHERE marca_Nombre = @marca_Nombre", clConexion.sconexion);
                verificar.Parameters.AddWithValue("@marca_Nombre", txtMarca.Text);

                int count = (int)verificar.ExecuteScalar();

                if (count == 0)
                {
                    funciones.LimpiarCampos(txtMarca);
                    MessageBox.Show("Error... La marca no existe en la base de datos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    SqlCommand eliminar = new SqlCommand("DELETE FROM Marca WHERE marca_Nombre = @marca_Nombre", clConexion.sconexion);
                    eliminar.Parameters.AddWithValue("@marca_Nombre", txtMarca.Text);
                    eliminar.ExecuteNonQuery();
                    MessageBox.Show("Aviso ... La marca se eliminó exitosamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    funciones.LimpiarCampos(txtMarca, txtCodigo, txtBuscar);
                    txtMarca.Focus(); 

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
                clConexion.cargarDatos(dgvGrip, "Marca");
                errorProviderGenerico.Clear();
            }
        }

        private void dgvGrip_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigo.Text = dgvGrip.CurrentRow.Cells[0].Value.ToString();
            txtMarca.Text = dgvGrip.CurrentRow.Cells[1].Value.ToString();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = txtBuscar.Text.Trim();


            clConexion.abrir();

            SqlCommand buscar;

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
               
                buscar = new SqlCommand("SELECT * FROM Marca", clConexion.sconexion);
            }
            else
            {
              
                buscar = new SqlCommand("SELECT * FROM Marca WHERE marca_Nombre LIKE @marca_Nombre", clConexion.sconexion);
                buscar.Parameters.AddWithValue("@marca_Nombre", "%" + searchTerm + "%");
            }

            SqlDataAdapter adapter = new SqlDataAdapter(buscar);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

           
            dgvGrip.DataSource = dt;

            clConexion.cerrar();
        }

        private void Fr_Marcas_Load(object sender, EventArgs e)
        {
            clConexion.cargarDatos(dgvGrip, "Marca");
        }
    }
}
