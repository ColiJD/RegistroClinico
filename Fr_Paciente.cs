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
    public partial class Fr_Paciente : Form
    {
        Conexion clConexion = new Conexion();
        Funciones funciones = new Funciones();
        public Fr_Paciente()
        {
            InitializeComponent();
        }

        private void Fr_Proveedores_Load(object sender, EventArgs e)
        {
            clConexion.cargarDatos(dgvGrip, "Pacientes");
			funciones.RestringirCorreoElectronico(txtCorreo);
			funciones.SoloNumeros(txtTelefono, txtCedula);   // Teléfono y cédula = solo números
			funciones.MaximoNumeros(txtCedula);          // cédula máximo 8 dígitos
			funciones.MinimoOchoNumeros(txtCedula);          // cédula mínimo 8 dígitos
			funciones.SoloLetras(txtNombre, txtApellido);    // Nombre y apellido solo letras
			funciones.UnaSolaLetra(txtSexo);
			funciones.SoloLetra(txtSexo);
		}

        private void btnAgregar_Click(object sender, EventArgs e)
        {
			if (funciones.CamposVacios(txtCedula, txtNombre, txtApellido, txtTelefono, txtCorreo))
			{
				errorProviderGenerico.SetError(txtCedula, "El campo cédula no puede estar vacío.");
				errorProviderGenerico.SetError(txtNombre, "El campo nombre no puede estar vacío.");
				errorProviderGenerico.SetError(txtApellido, "El campo apellido no puede estar vacío.");
				errorProviderGenerico.SetError(txtTelefono, "El campo teléfono no puede estar vacío.");
				errorProviderGenerico.SetError(txtCorreo, "El campo correo no puede estar vacío.");
				MessageBox.Show("Error... No puede insertar datos en blanco", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			try
			{
				clConexion.abrir();
				using (var verificar = new SqlCommand("SELECT COUNT(*) FROM Pacientes WHERE cedula = @cedula", clConexion.sconexion))
				{
					verificar.Parameters.AddWithValue("@cedula", txtCedula.Text);
					int count = (int)verificar.ExecuteScalar();

					if (count > 0)
					{
						funciones.LimpiarCampos(txtCedula);
						MessageBox.Show("Error... El paciente ya existe en la base de datos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					else
					{
						using (var agregar = new SqlCommand(
							"INSERT INTO Pacientes (cedula, nombre, apellido, fechaNacimiento, sexo, telefono, email, direccion, fechaRegistro) " +
							"VALUES (@cedula, @nombre, @apellido, @fechaNacimiento, @sexo, @telefono, @correo, @direccion, @fechaRegistro)", clConexion.sconexion))
						{
							agregar.Parameters.AddWithValue("@cedula", txtCedula.Text);
							agregar.Parameters.AddWithValue("@nombre", txtNombre.Text);
							agregar.Parameters.AddWithValue("@apellido", txtApellido.Text);
							agregar.Parameters.AddWithValue("@fechaNacimiento", dtpNacimiento.Value); // asumiendo DateTimePicker
							agregar.Parameters.AddWithValue("@sexo", txtSexo.Text);
							agregar.Parameters.AddWithValue("@telefono", txtTelefono.Text); // mejor string
							agregar.Parameters.AddWithValue("@correo", txtCorreo.Text);
							agregar.Parameters.AddWithValue("@direccion", txtDireccion.Text);
							agregar.Parameters.AddWithValue("@fechaRegistro", DateTime.Now); // valor actual

							agregar.ExecuteNonQuery();
							MessageBox.Show("Aviso ... Los Datos se agregaron exitosamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);

							funciones.LimpiarCampos(txtCedula, txtNombre, txtApellido, txtTelefono, txtCorreo, txtDireccion, txtBuscar, txtCodigo);
							txtCedula.Focus();
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
				clConexion.cargarDatos(dgvGrip, "Pacientes");
				errorProviderGenerico.Clear();
			}
		}

		private void btnModificar_Click(object sender, EventArgs e)
        {
			try
			{
				if (funciones.CamposVacios(txtCedula, txtNombre, txtApellido))
				{
					MessageBox.Show("Error... No puede dejar campos vacíos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				clConexion.abrir();

				txtCodigo.Text = dgvGrip.CurrentRow.Cells[0].Value.ToString();

				using (var verificar = new SqlCommand("SELECT COUNT(*) FROM Pacientes WHERE cedula = @cedula AND pacienteID != @pacienteID", clConexion.sconexion))
				{
					verificar.Parameters.AddWithValue("@cedula", txtCedula.Text);
					verificar.Parameters.AddWithValue("@pacienteID", txtCodigo.Text);
					int count = (int)verificar.ExecuteScalar();

					if (count > 0)
					{
						MessageBox.Show("Error... Ya existe un paciente con esa cédula", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}

					using (var modificar = new SqlCommand(
						"UPDATE Pacientes SET cedula=@cedula, nombre=@nombre, apellido=@apellido, fechaNacimiento=@fechaNacimiento, sexo=@sexo, telefono=@telefono, email=@correo, direccion=@direccion " +
						"WHERE pacienteID=@pacienteID", clConexion.sconexion))
					{
						modificar.Parameters.AddWithValue("@cedula", txtCedula.Text);
						modificar.Parameters.AddWithValue("@nombre", txtNombre.Text);
						modificar.Parameters.AddWithValue("@apellido", txtApellido.Text);
						modificar.Parameters.AddWithValue("@fechaNacimiento", dtpNacimiento.Value);
						modificar.Parameters.AddWithValue("@sexo", txtSexo.Text);
						modificar.Parameters.AddWithValue("@telefono", txtTelefono.Text);
						modificar.Parameters.AddWithValue("@correo", txtCorreo.Text);
						modificar.Parameters.AddWithValue("@direccion", txtDireccion.Text);
						modificar.Parameters.AddWithValue("@pacienteID", txtCodigo.Text);

						modificar.ExecuteNonQuery();
						MessageBox.Show("Aviso ... Los datos se modificaron exitosamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);

						funciones.LimpiarCampos(txtCedula, txtNombre, txtApellido, txtTelefono, txtCorreo, txtDireccion, txtCodigo, txtBuscar);
						txtCedula.Focus();
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
				clConexion.cargarDatos(dgvGrip, "Pacientes");
				errorProviderGenerico.Clear();
			}
		}

		private void btnEliminar_Click(object sender, EventArgs e)
		{
			try
			{
				if (funciones.CamposVacios(txtCedula))
				{
					errorProviderGenerico.SetError(txtCedula, "Debe seleccionar un paciente.");
					MessageBox.Show("Error...Seleccione un paciente para eliminar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				clConexion.abrir();

				SqlCommand verificar = new SqlCommand("SELECT COUNT(*) FROM Pacientes WHERE cedula = @cedula", clConexion.sconexion);
				verificar.Parameters.AddWithValue("@cedula", txtCedula.Text);

				int count = (int)verificar.ExecuteScalar();

				if (count == 0)
				{
					funciones.LimpiarCampos(txtCedula);
					MessageBox.Show("Error... El paciente no existe en la base de datos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else
				{
					SqlCommand eliminar = new SqlCommand("DELETE FROM Pacientes WHERE cedula = @cedula", clConexion.sconexion);
					eliminar.Parameters.AddWithValue("@cedula", txtCedula.Text);
					eliminar.ExecuteNonQuery();
					MessageBox.Show("Aviso ... El paciente se eliminó exitosamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);

					funciones.LimpiarCampos(txtCedula, txtNombre, txtApellido, txtTelefono, txtCorreo, txtDireccion, txtCodigo, txtBuscar);
					txtCedula.Focus();
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
				clConexion.cargarDatos(dgvGrip, "Pacientes");
				errorProviderGenerico.Clear();
			}
		}

		private void dgvGrip_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
			txtCodigo.Text = dgvGrip.CurrentRow.Cells["pacienteID"].Value.ToString();
			txtCedula.Text = dgvGrip.CurrentRow.Cells["cedula"].Value.ToString();
			txtNombre.Text = dgvGrip.CurrentRow.Cells["nombre"].Value.ToString();
			txtApellido.Text = dgvGrip.CurrentRow.Cells["apellido"].Value.ToString();
			dtpNacimiento.Value = Convert.ToDateTime(dgvGrip.CurrentRow.Cells["fechaNacimiento"].Value);
			txtSexo.Text = dgvGrip.CurrentRow.Cells["sexo"].Value.ToString();
			txtTelefono.Text = dgvGrip.CurrentRow.Cells["telefono"].Value.ToString();
			txtCorreo.Text = dgvGrip.CurrentRow.Cells["email"].Value.ToString();
			txtDireccion.Text = dgvGrip.CurrentRow.Cells["direccion"].Value.ToString();
		}

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
			string searchTerm = txtBuscar.Text.Trim();

			clConexion.abrir();

			SqlCommand buscar;

			if (string.IsNullOrWhiteSpace(searchTerm))
			{
				buscar = new SqlCommand("SELECT * FROM Pacientes", clConexion.sconexion);
			}
			else
			{
				buscar = new SqlCommand("SELECT * FROM Pacientes WHERE nombre LIKE @nombre OR apellido LIKE @apellido", clConexion.sconexion);
				buscar.Parameters.AddWithValue("@nombre", "%" + searchTerm + "%");
				buscar.Parameters.AddWithValue("@apellido", "%" + searchTerm + "%");
			}

			SqlDataAdapter adapter = new SqlDataAdapter(buscar);
			DataTable dt = new DataTable();
			adapter.Fill(dt);

			dgvGrip.DataSource = dt;

			clConexion.cerrar();
		}

private void dgvGrip_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}
	}
}
