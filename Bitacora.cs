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
    public partial class Bitacora : Form
    {
        Conexion clConexion = new Conexion();
        Funciones funciones = new Funciones();
        private int articulo = 0;
        private int marca = 0;
        private int modelo = 0;
        private int proveedor = 0;
        public Bitacora()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (funciones.ComboBoxVacios(cbModelo, cbProveedor, cbMarca, cbArticulo))
            {
                errorProviderGenerico.SetError(cbArticulo, "El campo artículo no puede estar vacío.");
                errorProviderGenerico.SetError(cbMarca, "El campo marca no puede estar vacío.");
                errorProviderGenerico.SetError(cbModelo, "El campo modelo no puede estar vacío.");
                errorProviderGenerico.SetError(cbProveedor, "El campo proveedor no puede estar vacío.");

                MessageBox.Show("Error... No puede insertar datos en blanco", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                clConexion.abrir();

                using (var agregar = new SqlCommand("INSERT INTO Bitacora (bitacora_Articulo, bitacora_Marca, bitacora_Modelo, bitacora_Fecha, bitacora_Garantia, bitacora_Proveedor) " +
                                                    "VALUES (@bitacora_Articulo, @bitacora_Marca, @bitacora_Modelo, @bitacora_Fecha, @bitacora_Garantia, @bitacora_Proveedor)", clConexion.sconexion))
                {
                    agregar.Parameters.AddWithValue("@bitacora_Articulo", Convert.ToInt64(cbArticulo.SelectedValue));
                    agregar.Parameters.AddWithValue("@bitacora_Marca", Convert.ToInt64(cbMarca.SelectedValue));
                    agregar.Parameters.AddWithValue("@bitacora_Modelo", Convert.ToInt64(cbModelo.SelectedValue));
                    agregar.Parameters.AddWithValue("@bitacora_Fecha", dtpIngreso.Value);
                    agregar.Parameters.AddWithValue("@bitacora_Garantia", dtpCierre.Value);
                    agregar.Parameters.AddWithValue("@bitacora_Proveedor", Convert.ToInt64(cbProveedor.SelectedValue));

                    agregar.ExecuteNonQuery();
                    MessageBox.Show("Aviso ... Los Datos se agregaron exitosamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    funciones.LimpiarCampos(txtDias, txtBuscar, txtCodigo);
                    funciones.LimpiarComboBox(cbArticulo, cbMarca, cbModelo, cbProveedor);
                    dtpCierre.ResetText();
                    dtpIngreso.ResetText();
                    cbArticulo.Focus();
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
                clConexion.cargarDatos(dgvGrip, "Bitacora");
                errorProviderGenerico.Clear();
                // Agregar columna calculada
                CargarDatosConDiasRestantes();
            }

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si hay campos vacíos y mostrar errores
                if (funciones.ComboBoxVacios(cbArticulo, cbMarca, cbModelo, cbProveedor))
                {
                    // Establecer los mensajes de error
                    errorProviderGenerico.SetError(cbArticulo, "El nombre de articulo no puede estar vacío.");
                    errorProviderGenerico.SetError(cbMarca, "El campo marca no puede estar vacío.");
                    errorProviderGenerico.SetError(cbModelo, "El campo modelo no puede estar vacío.");
                    errorProviderGenerico.SetError(cbProveedor, "El campo proveedor no puede estar vacío.");

                    MessageBox.Show("Error... No puede insertar datos en blanco", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Abrir la conexión a la base de datos
                clConexion.abrir();

                // Verificar si el registro existe en la base de datos (si es necesario)
                using (var verificar = new SqlCommand("SELECT COUNT(*) FROM Bitacora WHERE id_Ditacora = @id_Ditacora", clConexion.sconexion))
                {
                    verificar.Parameters.AddWithValue("@id_Ditacora", txtCodigo.Text);

                    int count = (int)verificar.ExecuteScalar();

                    if (count == 0)
                    {
                        MessageBox.Show("Error... El registro no existe en la base de datos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Proceder con la modificación del registro en la base de datos
                using (var modificar = new SqlCommand("UPDATE Bitacora SET bitacora_Articulo=@bitacora_Articulo, bitacora_Marca=@bitacora_Marca, bitacora_Modelo=@bitacora_Modelo, bitacora_Fecha=@bitacora_Fecha, bitacora_Garantia=@bitacora_Garantia, bitacora_Proveedor=@bitacora_Proveedor WHERE id_Ditacora=@id_Ditacora", clConexion.sconexion))
                {
                    modificar.Parameters.AddWithValue("@bitacora_Articulo", cbArticulo.SelectedValue);
                    modificar.Parameters.AddWithValue("@bitacora_Marca", cbMarca.SelectedValue);
                    modificar.Parameters.AddWithValue("@bitacora_Modelo", cbModelo.SelectedValue);
                    modificar.Parameters.AddWithValue("@bitacora_Fecha", dtpIngreso.Value);
                    modificar.Parameters.AddWithValue("@bitacora_Garantia", dtpCierre.Value);
                    modificar.Parameters.AddWithValue("@bitacora_Proveedor", cbProveedor.SelectedValue);
                    modificar.Parameters.AddWithValue("@id_Ditacora", txtCodigo.Text);

                    modificar.ExecuteNonQuery();

                    MessageBox.Show("Aviso... Los datos se modificaron exitosamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    funciones.LimpiarCampos(txtCodigo, txtBuscar);
                    funciones.LimpiarComboBox(cbProveedor, cbModelo, cbMarca, cbArticulo);
                    dtpCierre.ResetText();
                    dtpIngreso.ResetText();
                    cbArticulo.Focus();
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
                CargarDatosConDiasRestantes(); // Actualizar la tabla de usuarios
                errorProviderGenerico.Clear(); // Limpiar todos los mensajes de error
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si hay campos vacíos y mostrar errores
                if (funciones.CamposVacios(txtCodigo))
                {
                    errorProviderGenerico.SetError(txtCodigo, "Este campo no puede estar vacío.");
                    MessageBox.Show("Error...Realice doble click al registro que desea eliminar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Abrir la conexión a la base de datos
                clConexion.abrir();

                // Verificar si el usuario existe en la base de datos antes de eliminarlo
                SqlCommand verificar = new SqlCommand("SELECT COUNT(*) FROM Bitacora WHERE id_Ditacora = @id_Ditacora", clConexion.sconexion);
                verificar.Parameters.AddWithValue("@id_Ditacora", txtCodigo.Text);

                int count = (int)verificar.ExecuteScalar();

                if (count == 0)
                {
                    funciones.LimpiarCampos(txtCodigo);
                    funciones.LimpiarComboBox(cbArticulo, cbMarca, cbModelo, cbProveedor);
                    // Si el usuario no existe, mostramos un mensaje de error
                    MessageBox.Show("Error... El registro no existe en la base de datos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // Si el usuario existe, procedemos con la eliminación
                    SqlCommand eliminar = new SqlCommand("DELETE FROM Bitacora WHERE id_Ditacora = @id_Ditacora", clConexion.sconexion);
                    eliminar.Parameters.AddWithValue("@id_Ditacora", txtCodigo.Text);

                    eliminar.ExecuteNonQuery();
                    MessageBox.Show("Aviso ... El registro se eliminó exitosamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Limpiar los campos después de la eliminación
                    funciones.LimpiarCampos(txtCodigo);
                    funciones.LimpiarComboBox(cbArticulo, cbMarca, cbModelo, cbProveedor);
                    dtpCierre.ResetText();
                    dtpIngreso.ResetText();

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
                CargarDatosConDiasRestantes();
                errorProviderGenerico.Clear(); // Limpiar todos los mensajes de error
            }
        }

        private void dgvGrip_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //// Obtener el ID del usuario desde la primera celda de la fila seleccionada
            txtCodigo.Text = dgvGrip.CurrentRow.Cells[0].Value.ToString();
            articulo = Convert.ToInt32( dgvGrip.CurrentRow.Cells[1].Value.ToString());
            marca = Convert.ToInt32(dgvGrip.CurrentRow.Cells[2].Value.ToString());
            modelo = Convert.ToInt32(dgvGrip.CurrentRow.Cells[3].Value.ToString());
            proveedor = Convert.ToInt32(dgvGrip.CurrentRow.Cells[6].Value.ToString());
            dtpIngreso.Text = dgvGrip.CurrentRow.Cells[4].Value.ToString();
            dtpCierre.Text = dgvGrip.CurrentRow.Cells[5].Value.ToString();
            // Establece el valor del ComboBox a la categoría correspondiente
            cbArticulo.SelectedValue = articulo;
            cbMarca.SelectedValue = marca;
            cbModelo.SelectedValue = modelo;
            cbProveedor.SelectedValue = proveedor;

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = txtBuscar.Text.Trim();

            clConexion.abrir();

            SqlCommand buscar;

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                // Si el campo está vacío, selecciona todos los registros de Bitacora
                buscar = new SqlCommand("SELECT id_Ditacora, bitacora_Articulo, bitacora_Marca, bitacora_Modelo, bitacora_Fecha, bitacora_Garantia, bitacora_Proveedor, " +
                                        "DATEDIFF(DAY, GETDATE(), bitacora_Garantia) AS DiasRestantes " +
                                        "FROM Bitacora", clConexion.sconexion);
            }
            else
            {
                // Si hay texto en el campo, filtra por bitacora_Articulo
                buscar = new SqlCommand("SELECT id_Ditacora, bitacora_Articulo, bitacora_Marca, bitacora_Modelo, bitacora_Fecha, bitacora_Garantia, bitacora_Proveedor, " +
                                        "DATEDIFF(DAY, GETDATE(), bitacora_Garantia) AS DiasRestantes " +
                                        "FROM Bitacora WHERE bitacora_Articulo LIKE @bitacora_Articulo;", clConexion.sconexion);
                buscar.Parameters.AddWithValue("@bitacora_Articulo", "%" + searchTerm + "%");
            }

            SqlDataAdapter adapter = new SqlDataAdapter(buscar);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            // Asignar los resultados al DataGridView
            dgvGrip.DataSource = dt;

            clConexion.cerrar();
        }

        private void Bitacora_Load(object sender, EventArgs e)
        {
            string consultaSQL = "";
           
            consultaSQL = "SELECT id_Articulo, articulo_Nombre FROM Articulo";
            DataTable DTArticulo = clConexion.EjecutarConsulta(consultaSQL);
            cbArticulo.DataSource = DTArticulo;
            cbArticulo.DisplayMember = "articulo_Nombre";
            cbArticulo.ValueMember = "id_Articulo";

            consultaSQL = "SELECT id_Marca, marca_Nombre FROM Marca";
            DataTable DTMarca = clConexion.EjecutarConsulta(consultaSQL);
            cbMarca.DataSource = DTMarca;
            cbMarca.DisplayMember = "marca_Nombre";
            cbMarca.ValueMember = "id_Marca";

            consultaSQL = "SELECT id_modelo, modelo_Nombre FROM Modelo";
            DataTable DTModelo = clConexion.EjecutarConsulta(consultaSQL);
            cbModelo.DataSource = DTModelo;
            cbModelo.DisplayMember = "modelo_Nombre";
            cbModelo.ValueMember = "id_Modelo";

            consultaSQL = "SELECT id_Proveedor, proveedor_Nombre FROM Proveedor";
            DataTable DTProveedor = clConexion.EjecutarConsulta(consultaSQL);
            cbProveedor.DataSource = DTProveedor;
            cbProveedor.DisplayMember = "proveedor_Nombre";
            cbProveedor.ValueMember = "id_Proveedor";

            CargarDatosConDiasRestantes();
            dtpCierre.Value = dtpIngreso.Value.AddDays(90);

        }

        private void dgvGrip_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            // Verificar si la celda actual es de la columna "DiasRestantes"
            if (dgvGrip.Columns[e.ColumnIndex].Name == "DiasRestantes" && e.Value != null)
            {
                int diasRestantes;

                // Intentar convertir el valor de la celda a un entero
                if (int.TryParse(e.Value.ToString(), out diasRestantes))
                {
                    // Aplicar estilos según el valor de "DiasRestantes"
                    if (diasRestantes >= 100)
                    {
                        // Más de 100 días restantes - verde
                        e.CellStyle.BackColor = Color.Green;
                        e.CellStyle.ForeColor = Color.White;
                    }
                    else if (diasRestantes >= 65)
                    {
                        // Entre 50 y 99 días restantes - naranja
                        e.CellStyle.BackColor = Color.GreenYellow;
                        e.CellStyle.ForeColor = Color.Black;
                    }
                    else if (diasRestantes >= 30)
                    {
                        // Entre 50 y 99 días restantes - naranja
                        e.CellStyle.BackColor = Color.Yellow;
                        e.CellStyle.ForeColor = Color.Black;
                    }
                    else if (diasRestantes >= 0)
                    {
                        // Entre 50 y 99 días restantes - naranja
                        e.CellStyle.BackColor = Color.Orange;
                        e.CellStyle.ForeColor = Color.Black;
                    }
                    else
                    {
                        // Menos de 50 días restantes - rojo
                        e.CellStyle.BackColor = Color.Red;
                        e.CellStyle.ForeColor = Color.White;
                    }

                }
            }
        }

        private void dtpCierre_ValueChanged(object sender, EventArgs e)
        {
            txtDias.Text = Convert.ToString((dtpCierre.Value - DateTime.Today).Days);

        }

        // Método para agregar columna de días restantes y calcular su valor

        private void CargarDatosConDiasRestantes()
        {
            try
            {
                clConexion.abrir();

                // Consulta que obtiene los datos junto con el cálculo de los días restantes
                string query = "SELECT id_Ditacora, bitacora_Articulo, bitacora_Marca, bitacora_Modelo, bitacora_Fecha, bitacora_Garantia, bitacora_Proveedor, " +
                               "DATEDIFF(DAY, GETDATE(), bitacora_Garantia) AS DiasRestantes " +
                               "FROM Bitacora";

                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, clConexion.sconexion);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                // Asignar los datos al DataGridView
                dgvGrip.DataSource = dataTable;

                // Agregar columna "Días Restantes" si no existe en el DataGridView
                if (!dgvGrip.Columns.Contains("Días Restantes"))
                {
                    dgvGrip.Columns["DiasRestantes"].HeaderText = "Días Restantes";
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al cargar los datos... " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                clConexion.cerrar();
            }
        }

        private void dtpIngreso_ValueChanged(object sender, EventArgs e)
        {
            dtpCierre.Value = dtpIngreso.Value.AddDays(90);
        }
    }
}
