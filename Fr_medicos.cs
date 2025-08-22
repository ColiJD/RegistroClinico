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
	public partial class Fr_medicos : Form
	{
		Conexion clConexion = new Conexion();
		Funciones funciones = new Funciones();
		public Fr_medicos()
		{
			InitializeComponent();
		}

		private void Fr_medicos_Load(object sender, EventArgs e)
		{
			clConexion.cargarDatos(dgvGrip, "Medicos");
			funciones.RestringirCorreoElectronico(txtCorreo);
			funciones.SoloNumeros(txtTelefono, txtCedula);
			funciones.MaximoNumeros(txtCedula);
			funciones.MinimoOchoNumeros(txtCedula);
			funciones.SoloLetras(txtNombre, txtApellido, txtEspecialidad);
		}

		private void btnAgregar_Click(object sender, EventArgs e)
		{
			if (funciones.CamposVacios(txtCedula, txtNombre, txtApellido, txtTelefono, txtCorreo, txtEspecialidad))
			{
				errorProviderGenerico.SetError(txtCedula, "El campo cédula no puede estar vacío.");
				errorProviderGenerico.SetError(txtNombre, "El campo nombre no puede estar vacío.");
				errorProviderGenerico.SetError(txtApellido, "El campo apellido no puede estar vacío.");
				errorProviderGenerico.SetError(txtTelefono, "El campo teléfono no puede estar vacío.");
				errorProviderGenerico.SetError(txtCorreo, "El campo correo no puede estar vacío.");
				errorProviderGenerico.SetError(txtEspecialidad, "El campo especialidad no puede estar vacío.");
				MessageBox.Show("Error... No puede insertar datos en blanco", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			try
			{
				clConexion.abrir();
				using (var verificar = new SqlCommand("SELECT COUNT(*) FROM Medicos WHERE cedula = @cedula", clConexion.sconexion))
				{
					verificar.Parameters.AddWithValue("@cedula", txtCedula.Text);
					int count = (int)verificar.ExecuteScalar();

					if (count > 0)
					{
						funciones.LimpiarCampos(txtCedula);
						MessageBox.Show("Error... El médico ya existe en la base de datos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					else
					{
						using (var agregar = new SqlCommand(
							"INSERT INTO Medicos (cedula, nombre, apellido, especialidad, telefono, email, fechaContratacion) " +
							"VALUES (@cedula, @nombre, @apellido, @especialidad, @telefono, @correo, @fechaContratacion)", clConexion.sconexion))
						{
							agregar.Parameters.AddWithValue("@cedula", txtCedula.Text);
							agregar.Parameters.AddWithValue("@nombre", txtNombre.Text);
							agregar.Parameters.AddWithValue("@apellido", txtApellido.Text);
							agregar.Parameters.AddWithValue("@especialidad", txtEspecialidad.Text);
							agregar.Parameters.AddWithValue("@telefono", txtTelefono.Text);
							agregar.Parameters.AddWithValue("@correo", txtCorreo.Text);
							agregar.Parameters.AddWithValue("@fechaContratacion", DateTime.Now);

							agregar.ExecuteNonQuery();
							MessageBox.Show("Aviso ... Los datos se agregaron exitosamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);

							funciones.LimpiarCampos(txtCedula, txtNombre, txtApellido, txtTelefono, txtCorreo, txtEspecialidad, txtBuscar, txtCodigo);
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
				clConexion.cargarDatos(dgvGrip, "Medicos");
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

				using (var verificar = new SqlCommand("SELECT COUNT(*) FROM Medicos WHERE cedula = @cedula AND medicoID != @medicoID", clConexion.sconexion))
				{
					verificar.Parameters.AddWithValue("@cedula", txtCedula.Text);
					verificar.Parameters.AddWithValue("@medicoID", txtCodigo.Text);
					int count = (int)verificar.ExecuteScalar();

					if (count > 0)
					{
						MessageBox.Show("Error... Ya existe un médico con esa cédula", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}

					using (var modificar = new SqlCommand(
						"UPDATE Medicos SET cedula=@cedula, nombre=@nombre, apellido=@apellido, especialidad=@especialidad, telefono=@telefono, email=@correo " +
						"WHERE medicoID=@medicoID", clConexion.sconexion))
					{
						modificar.Parameters.AddWithValue("@cedula", txtCedula.Text);
						modificar.Parameters.AddWithValue("@nombre", txtNombre.Text);
						modificar.Parameters.AddWithValue("@apellido", txtApellido.Text);
						modificar.Parameters.AddWithValue("@especialidad", txtEspecialidad.Text);
						modificar.Parameters.AddWithValue("@telefono", txtTelefono.Text);
						modificar.Parameters.AddWithValue("@correo", txtCorreo.Text);
						modificar.Parameters.AddWithValue("@medicoID", txtCodigo.Text);

						modificar.ExecuteNonQuery();
						MessageBox.Show("Aviso ... Los datos se modificaron exitosamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);

						funciones.LimpiarCampos(txtCedula, txtNombre, txtApellido, txtTelefono, txtCorreo, txtEspecialidad, txtCodigo, txtBuscar);
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
				clConexion.cargarDatos(dgvGrip, "Medicos");
				errorProviderGenerico.Clear();
			}
		}

		private void btnEliminar_Click(object sender, EventArgs e)
		{
			try
			{
				if (funciones.CamposVacios(txtCedula))
				{
					errorProviderGenerico.SetError(txtCedula, "Debe seleccionar un médico.");
					MessageBox.Show("Error...Seleccione un médico para eliminar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				clConexion.abrir();

				SqlCommand verificar = new SqlCommand("SELECT COUNT(*) FROM Medicos WHERE cedula = @cedula", clConexion.sconexion);
				verificar.Parameters.AddWithValue("@cedula", txtCedula.Text);

				int count = (int)verificar.ExecuteScalar();

				if (count == 0)
				{
					funciones.LimpiarCampos(txtCedula);
					MessageBox.Show("Error... El médico no existe en la base de datos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else
				{
					SqlCommand eliminar = new SqlCommand("DELETE FROM Medicos WHERE cedula = @cedula", clConexion.sconexion);
					eliminar.Parameters.AddWithValue("@cedula", txtCedula.Text);
					eliminar.ExecuteNonQuery();
					MessageBox.Show("Aviso ... El médico se eliminó exitosamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);

					funciones.LimpiarCampos(txtCedula, txtNombre, txtApellido, txtTelefono, txtCorreo, txtEspecialidad, txtCodigo, txtBuscar);
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
				clConexion.cargarDatos(dgvGrip, "Medicos");
				errorProviderGenerico.Clear();
			}
		}

		private void dgvGrip_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			txtCodigo.Text = dgvGrip.CurrentRow.Cells["medicoID"].Value.ToString();
			txtCedula.Text = dgvGrip.CurrentRow.Cells["cedula"].Value.ToString();
			txtNombre.Text = dgvGrip.CurrentRow.Cells["nombre"].Value.ToString();
			txtApellido.Text = dgvGrip.CurrentRow.Cells["apellido"].Value.ToString();
			txtEspecialidad.Text = dgvGrip.CurrentRow.Cells["especialidad"].Value.ToString();
			txtTelefono.Text = dgvGrip.CurrentRow.Cells["telefono"].Value.ToString();
			txtCorreo.Text = dgvGrip.CurrentRow.Cells["email"].Value.ToString();
		}

		private void txtBuscar_TextChanged(object sender, EventArgs e)
		{
			string searchTerm = txtBuscar.Text.Trim();
			clConexion.abrir();

			SqlCommand buscar;
			if (string.IsNullOrWhiteSpace(searchTerm))
			{
				buscar = new SqlCommand("SELECT * FROM Medicos", clConexion.sconexion);
			}
			else
			{
				buscar = new SqlCommand("SELECT * FROM Medicos WHERE nombre LIKE @nombre OR apellido LIKE @apellido OR especialidad LIKE @especialidad", clConexion.sconexion);
				buscar.Parameters.AddWithValue("@nombre", "%" + searchTerm + "%");
				buscar.Parameters.AddWithValue("@apellido", "%" + searchTerm + "%");
				buscar.Parameters.AddWithValue("@especialidad", "%" + searchTerm + "%");
			}

			SqlDataAdapter adapter = new SqlDataAdapter(buscar);
			DataTable dt = new DataTable();
			adapter.Fill(dt);
			dgvGrip.DataSource = dt;

			clConexion.cerrar();
		}
	}
}
