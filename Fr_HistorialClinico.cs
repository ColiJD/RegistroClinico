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
	public partial class Fr_HistorialClinico : Form
	{
		Conexion clConexion = new Conexion();
		Funciones funciones = new Funciones();
		// ✅ Variable global para usar en todo el form
		private int historialID = 0;

		Data Data = new Data();

		public Fr_HistorialClinico()
		{
			InitializeComponent();
		}

		private void Fr_HistorialClinico_Load(object sender, EventArgs e)
		{
			CargarPacientes();
			CargarMedicos();
			MostrarHistorial();
			
		}
		private void CargarPacientes()
		{
			string query = "SELECT pacienteID, nombre + ' ' + apellido AS NombreCompleto FROM Pacientes";
			SqlDataAdapter da = new SqlDataAdapter(query, clConexion.sconexion);
			DataTable dt = new DataTable();
			da.Fill(dt);

			DataRow row = dt.NewRow();
			row["pacienteID"] = 0;
			row["NombreCompleto"] = "";
			dt.Rows.InsertAt(row, 0);

			cbPaciente.DataSource = dt;
			cbPaciente.DisplayMember = "NombreCompleto";
			cbPaciente.ValueMember = "pacienteID";
			cbPaciente.SelectedIndex = 0;
		}

		private void CargarMedicos()
		{
			string query = "SELECT medicoID, nombre + ' ' + apellido AS NombreCompleto FROM Medicos";
			SqlDataAdapter da = new SqlDataAdapter(query, clConexion.sconexion);
			DataTable dt = new DataTable();
			da.Fill(dt);

			DataRow row = dt.NewRow();
			row["medicoID"] = 0;
			row["NombreCompleto"] = "";
			dt.Rows.InsertAt(row, 0);

			cbMedico.DataSource = dt;
			cbMedico.DisplayMember = "NombreCompleto";
			cbMedico.ValueMember = "medicoID";
			cbMedico.SelectedIndex = 0;
		}

		private void MostrarHistorial(string filtro = "")
		{
			try
			{
				clConexion.abrir();

				string query = @"
                    SELECT h.historialID,
                           h.pacienteID,
                           h.medicoID,
                           p.nombre + ' ' + p.apellido AS Paciente,
                           m.nombre + ' ' + m.apellido AS Medico,
                           h.fechaRegistro,
                           h.diagnostico,
                           h.sintomas,
                           h.notas
                    FROM HistorialClinico h
                    INNER JOIN Pacientes p ON h.pacienteID = p.pacienteID
                    LEFT JOIN Medicos m ON h.medicoID = m.medicoID";

				if (!string.IsNullOrWhiteSpace(filtro))
				{
					query += " WHERE p.nombre + ' ' + p.apellido LIKE @filtro OR h.diagnostico LIKE @filtro OR h.sintomas LIKE @filtro";
				}

				query += " ORDER BY h.fechaRegistro DESC";

				SqlDataAdapter da = new SqlDataAdapter(query, clConexion.sconexion);
				if (!string.IsNullOrWhiteSpace(filtro))
				{
					da.SelectCommand.Parameters.AddWithValue("@filtro", "%" + filtro + "%");
				}

				DataTable dt = new DataTable();
				da.Fill(dt);
				dgvGrip.DataSource = dt;

				dgvGrip.Columns["pacienteID"].Visible = false;
				dgvGrip.Columns["medicoID"].Visible = false;
			}
			finally
			{
				clConexion.cerrar();
			}
		}

		private void btnAgregar_Click(object sender, EventArgs e)
		{
			errorProviderGenerico.Clear();

			if (funciones.CamposVacios(txtDiagnostico, txtSintomas))
			{
				if (string.IsNullOrWhiteSpace(txtDiagnostico.Text))
					errorProviderGenerico.SetError(txtDiagnostico, "El diagnóstico no puede estar vacío.");
				if (string.IsNullOrWhiteSpace(txtSintomas.Text))
					errorProviderGenerico.SetError(txtSintomas, "Los síntomas no pueden estar vacíos.");

				MessageBox.Show("Error... No puede insertar datos en blanco", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			try
			{
				clConexion.abrir();

				// Validar duplicado por historialID
				if (!string.IsNullOrWhiteSpace(txtCodigo.Text))
				{
					SqlCommand validar = new SqlCommand("SELECT COUNT(*) FROM HistorialClinico WHERE historialID=@id", clConexion.sconexion);
					validar.Parameters.AddWithValue("@id", Convert.ToInt32(txtCodigo.Text));
					int existe = (int)validar.ExecuteScalar();
					if (existe > 0)
					{
						MessageBox.Show("Ya existe un historial con ese ID.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						return;
					}
				}

				using (var cmd = new SqlCommand(
					@"INSERT INTO HistorialClinico (pacienteID, medicoID, diagnostico, sintomas, notas) 
                      VALUES (@pacienteID, @medicoID, @diagnostico, @sintomas, @notas)", clConexion.sconexion))
				{
					cmd.Parameters.AddWithValue("@pacienteID", cbPaciente.SelectedValue);
					cmd.Parameters.AddWithValue("@medicoID", cbMedico.SelectedValue == null ? (object)DBNull.Value : cbMedico.SelectedValue);
					cmd.Parameters.AddWithValue("@diagnostico", txtDiagnostico.Text);
					cmd.Parameters.AddWithValue("@sintomas", txtSintomas.Text);
					cmd.Parameters.AddWithValue("@notas", txtNotas.Text);

					cmd.ExecuteNonQuery();
					MessageBox.Show("Historial clínico agregado exitosamente.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);

					funciones.LimpiarCampos(txtDiagnostico, txtSintomas, txtNotas, txtCodigo);
					cbPaciente.SelectedIndex = 0;
					cbMedico.SelectedIndex = 0;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error al agregar historial... " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				clConexion.cerrar();
				MostrarHistorial();
				funciones.LimpiarCampos(txtDiagnostico, txtSintomas, txtNotas, txtCodigo);
				funciones.LimpiarComboBox(cbPaciente, cbMedico);
			}
		}
		private void btnModificar_Click(object sender, EventArgs e)
		{
			errorProviderGenerico.Clear();

			if (string.IsNullOrWhiteSpace(txtCodigo.Text))
			{
				errorProviderGenerico.SetError(txtCodigo, "Debe seleccionar un historial para modificar.");
				MessageBox.Show("Error... Seleccione un historial para modificar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			DialogResult confirmacion = MessageBox.Show("¿Está seguro que desea modificar este historial?", "Confirmar modificación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (confirmacion != DialogResult.Yes) return;

			try
			{
				clConexion.abrir();

				using (var cmd = new SqlCommand(
					@"UPDATE HistorialClinico 
                      SET pacienteID=@pacienteID, medicoID=@medicoID, diagnostico=@diagnostico, 
                          sintomas=@sintomas, notas=@notas
                      WHERE historialID=@historialID", clConexion.sconexion))
				{
					cmd.Parameters.AddWithValue("@historialID", Convert.ToInt32(txtCodigo.Text));
					cmd.Parameters.AddWithValue("@pacienteID", cbPaciente.SelectedValue);
					cmd.Parameters.AddWithValue("@medicoID", cbMedico.SelectedValue == null ? (object)DBNull.Value : cbMedico.SelectedValue);
					cmd.Parameters.AddWithValue("@diagnostico", txtDiagnostico.Text);
					cmd.Parameters.AddWithValue("@sintomas", txtSintomas.Text);
					cmd.Parameters.AddWithValue("@notas", txtNotas.Text);

					cmd.ExecuteNonQuery();
					MessageBox.Show("Historial clínico modificado exitosamente.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);

					funciones.LimpiarCampos(txtDiagnostico, txtSintomas, txtNotas, txtCodigo);
					cbPaciente.SelectedIndex = 0;
					cbMedico.SelectedIndex = 0;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error al modificar historial... " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				clConexion.cerrar();
				MostrarHistorial();
				funciones.LimpiarCampos(txtDiagnostico, txtSintomas, txtNotas, txtCodigo);
				funciones.LimpiarComboBox(cbPaciente, cbMedico);
			}
		}
		private void btnEliminar_Click(object sender, EventArgs e)
		{
			errorProviderGenerico.Clear();

			if (string.IsNullOrWhiteSpace(txtCodigo.Text))
			{
				errorProviderGenerico.SetError(txtCodigo, "Debe seleccionar un historial para eliminar.");
				MessageBox.Show("Error... Seleccione un historial para eliminar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			DialogResult confirmacion = MessageBox.Show("¿Desea eliminar este historial clínico?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (confirmacion != DialogResult.Yes) return;

			try
			{
				clConexion.abrir();

				using (var cmd = new SqlCommand("DELETE FROM HistorialClinico WHERE historialID=@historialID", clConexion.sconexion))
				{
					cmd.Parameters.AddWithValue("@historialID", Convert.ToInt32(txtCodigo.Text));
					cmd.ExecuteNonQuery();
				}

				MessageBox.Show("Historial clínico eliminado.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
				funciones.LimpiarCampos(txtDiagnostico, txtSintomas, txtNotas, txtCodigo);
				cbPaciente.SelectedIndex = 0;
				cbMedico.SelectedIndex = 0;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error al eliminar historial... " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				clConexion.cerrar();
				MostrarHistorial();
				funciones.LimpiarCampos(txtDiagnostico, txtSintomas, txtNotas, txtCodigo);
				funciones.LimpiarComboBox(cbPaciente, cbMedico);
			}
		}

		private void txtBuscar_TextChanged(object sender, EventArgs e)
		{
			string searchTerm = txtBuscar.Text.Trim();
			try
			{
				clConexion.abrir();
				string query = @"
                    SELECT h.historialID, h.pacienteID, h.medicoID,
                           p.nombre + ' ' + p.apellido AS Paciente,
                           m.nombre + ' ' + m.apellido AS Medico,
                           h.fechaRegistro, h.diagnostico, h.sintomas, h.notas
                    FROM HistorialClinico h
                    INNER JOIN Pacientes p ON h.pacienteID = p.pacienteID
                    LEFT JOIN Medicos m ON h.medicoID = m.medicoID
                    WHERE (p.nombre + ' ' + p.apellido LIKE @buscar
                           OR m.nombre + ' ' + m.apellido LIKE @buscar)
                    ORDER BY h.fechaRegistro DESC";

				using (var cmd = new SqlCommand(query, clConexion.sconexion))
				{
					cmd.Parameters.AddWithValue("@buscar", "%" + searchTerm + "%");
					DataTable dt = new DataTable();
					using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
					{
						adapter.Fill(dt);
					}
					dgvGrip.DataSource = dt;
				}
			}
			finally
			{
				clConexion.cerrar();
			}
		}

	

		private void dgvGrip_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void dgvGrip_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			{
				if (dgvGrip.CurrentRow == null) return;

				txtCodigo.Text = dgvGrip.CurrentRow.Cells["historialID"].Value.ToString();
				cbPaciente.SelectedValue = dgvGrip.CurrentRow.Cells["pacienteID"].Value ?? null;
				cbMedico.SelectedValue = dgvGrip.CurrentRow.Cells["medicoID"].Value == DBNull.Value ? null : dgvGrip.CurrentRow.Cells["medicoID"].Value;
				dtpFecha.Value = Convert.ToDateTime(dgvGrip.CurrentRow.Cells["fechaRegistro"].Value);
				txtDiagnostico.Text = dgvGrip.CurrentRow.Cells["diagnostico"].Value.ToString();
				txtSintomas.Text = dgvGrip.CurrentRow.Cells["sintomas"].Value.ToString();
				txtNotas.Text = dgvGrip.CurrentRow.Cells["notas"].Value.ToString();
			}
		}

		private void btnAddTrata_Click(object sender, EventArgs e)
		{
			errorProviderGenerico.Clear();

			if (funciones.CamposVacios(txtMedicamentos, txtDuracion,txtDosis))
			{
				if (string.IsNullOrWhiteSpace(txtMedicamentos.Text))
					errorProviderGenerico.SetError(txtMedicamentos, "El medicamento no puede estar vacío.");
				if (string.IsNullOrWhiteSpace(txtDosis.Text))
					errorProviderGenerico.SetError(txtDosis, "La dosis no pueden estar vacíos.");
				if (string.IsNullOrWhiteSpace(txtDuracion.Text))
					errorProviderGenerico.SetError(txtDuracion, "La duracion no pueden estar vacíos.");
				if (string.IsNullOrWhiteSpace(txtCodigo.Text))
					errorProviderGenerico.SetError(txtCodigo, "El id historico no pueden estar vacíos.");

				MessageBox.Show("Error... No puede insertar datos en blanco", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			try
			{
				clConexion.abrir();

				// Validar duplicado por historialID
				if (!string.IsNullOrWhiteSpace(txtIdTratamiento.Text))
				{
					SqlCommand validar = new SqlCommand("SELECT COUNT(*) FROM Tratamientos WHERE tratamientoID=@id", clConexion.sconexion);
					validar.Parameters.AddWithValue("@id", Convert.ToInt32(txtIdTratamiento.Text));
					int existe = (int)validar.ExecuteScalar();
					if (existe > 0)
					{
						MessageBox.Show("Ya existe un tratamiento con ese ID.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						return;
					}
				}

				using (var cmd = new SqlCommand(
					@"INSERT INTO Tratamientos (historialID, medicamento, dosis, duracion, observaciones) 
                      VALUES (@historialID, @medicamento, @dosis, @duracion, @observaciones)", clConexion.sconexion))
				{
					cmd.Parameters.AddWithValue("@historialID",txtCodigo.Text);
					cmd.Parameters.AddWithValue("@medicamento", txtMedicamentos.Text);
					cmd.Parameters.AddWithValue("@dosis", txtDosis.Text);
					cmd.Parameters.AddWithValue("@duracion", txtDuracion.Text);
					cmd.Parameters.AddWithValue("@observaciones", txtObservacion.Text);

					cmd.ExecuteNonQuery();
					MessageBox.Show("Tratamiento agregado exitosamente.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
					funciones.LimpiarCampos(txtDiagnostico, txtSintomas, txtNotas, txtCodigo);
					funciones.LimpiarComboBox(cbPaciente, cbMedico);
					funciones.LimpiarCampos(txtCodigo, txtIdTratamiento, txtDosis, txtDuracion, txtObservacion, txtMedicamentos);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error al agregar historial... " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				clConexion.cerrar();
				funciones.LimpiarCampos(txtDiagnostico, txtSintomas, txtNotas, txtCodigo);
				funciones.LimpiarComboBox(cbPaciente, cbMedico);
				MostrarTratamientosPorHistorial(historialID);
				funciones.LimpiarCampos(txtCodigo, txtIdTratamiento, txtDosis, txtDuracion, txtObservacion, txtMedicamentos);
			}
		}

		private void btnUpTrata_Click(object sender, EventArgs e)
		{
			
				errorProviderGenerico.Clear();

				if (string.IsNullOrWhiteSpace(txtIdTratamiento.Text))
				{
					errorProviderGenerico.SetError(txtIdTratamiento, "Debe seleccionar un tratamiento para modificar.");
					MessageBox.Show("Error... Seleccione un tratamietno para modificar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				DialogResult confirmacion = MessageBox.Show("¿Está seguro que desea modificar este historial?", "Confirmar modificación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (confirmacion != DialogResult.Yes) return;

				try
				{
					clConexion.abrir();

					using (var cmd = new SqlCommand(
						@"UPDATE Tratamientos 
                      SET historialID=@historialID, medicamento=@medicamento, dosis=@dosis, 
                          duracion=@duracion, observaciones=@observaciones
                      WHERE tratamientoID=@tratamientoID", clConexion.sconexion))
					{
						cmd.Parameters.AddWithValue("@tratamientoID", Convert.ToInt32(txtIdTratamiento.Text));
						cmd.Parameters.AddWithValue("@historialID", Convert.ToInt32(txtCodigo.Text));
					cmd.Parameters.AddWithValue("@medicamento", txtMedicamentos.Text);
					cmd.Parameters.AddWithValue("@dosis", txtDosis.Text);
						cmd.Parameters.AddWithValue("@duracion", txtDuracion.Text);
						cmd.Parameters.AddWithValue("@observaciones", txtObservacion.Text);

						cmd.ExecuteNonQuery();
						MessageBox.Show("Tratamiento modificado exitosamente.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);

					funciones.LimpiarCampos(txtDiagnostico, txtSintomas, txtNotas, txtCodigo);
					funciones.LimpiarComboBox(cbPaciente, cbMedico);
					funciones.LimpiarCampos(txtCodigo, txtIdTratamiento, txtDosis, txtDuracion, txtObservacion, txtMedicamentos);
				}
				}
				catch (Exception ex)
				{
					MessageBox.Show("Error al modificar historial... " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				finally
				{
					clConexion.cerrar();
				funciones.LimpiarCampos(txtDiagnostico, txtSintomas, txtNotas, txtCodigo);
				funciones.LimpiarComboBox(cbPaciente, cbMedico);
				MostrarTratamientosPorHistorial(historialID);
				funciones.LimpiarCampos(txtCodigo, txtIdTratamiento, txtDosis, txtDuracion, txtObservacion, txtMedicamentos);
			}
			}

		private void btnDeTrata_Click(object sender, EventArgs e)
		{
				errorProviderGenerico.Clear();

				if (string.IsNullOrWhiteSpace(txtIdTratamiento.Text))
				{
					errorProviderGenerico.SetError(txtCodigo, "Debe seleccionar un tratamiento para eliminar.");
					MessageBox.Show("Error... Seleccione un tratamiento para eliminar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				DialogResult confirmacion = MessageBox.Show("¿Desea eliminar este tratamiento?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (confirmacion != DialogResult.Yes) return;

				try
				{
					clConexion.abrir();

					using (var cmd = new SqlCommand("DELETE FROM Tratamientos WHERE tratamientoID=@tratamientoID", clConexion.sconexion))
					{
						cmd.Parameters.AddWithValue("@tratamientoID", Convert.ToInt32(txtCodigo.Text));
						cmd.ExecuteNonQuery();
					}

					MessageBox.Show("Tratamietno eliminado.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
				funciones.LimpiarCampos(txtDiagnostico, txtSintomas, txtNotas, txtCodigo);
				funciones.LimpiarComboBox(cbPaciente, cbMedico);
				funciones.LimpiarCampos(txtCodigo, txtIdTratamiento, txtDosis, txtDuracion, txtObservacion, txtMedicamentos);
			}
				catch (Exception ex)
				{
					MessageBox.Show("Error al eliminar tratamiento... " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				finally
				{
					clConexion.cerrar();
				funciones.LimpiarCampos(txtDiagnostico, txtSintomas, txtNotas, txtCodigo);
				funciones.LimpiarComboBox(cbPaciente, cbMedico);
				MostrarTratamientosPorHistorial(historialID);
				funciones.LimpiarCampos(txtCodigo, txtIdTratamiento, txtDosis, txtDuracion, txtObservacion, txtMedicamentos);
			}
			}
		private void MostrarTratamientosPorHistorial(int historialID)
		{
			try
			{
				clConexion.abrir();

				string query = @"SELECT t.tratamientoID,t.historialID, t.medicamento, t.dosis, 
                                t.duracion, t.observaciones
                         FROM Tratamientos t
                         WHERE t.historialID = @historialID";

				SqlDataAdapter da = new SqlDataAdapter(query, clConexion.sconexion);
				da.SelectCommand.Parameters.AddWithValue("@historialID", historialID);

				DataTable dt = new DataTable();
				da.Fill(dt);

				dgvTratamiento.DataSource = dt;
			}
			finally
			{
				clConexion.cerrar();
			}
		}

		private void txtCodigo_TextChanged(object sender, EventArgs e)
		{
			if (int.TryParse(txtCodigo.Text, out int id))
			{
				historialID = id; // guardamos el valor en la variable global
				MostrarTratamientosPorHistorial(historialID);
			}
			else
			{
				historialID = 0;
				dgvTratamiento.DataSource = null;
			}
		}

		private void dgvTratamiento_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			{
				if (dgvTratamiento.CurrentRow == null) return;

				txtIdTratamiento.Text = dgvTratamiento.CurrentRow.Cells["tratamientoID"].Value.ToString();
				txtCodigo.Text = dgvTratamiento.CurrentRow.Cells["historialID"].Value.ToString();
				txtMedicamentos.Text = dgvTratamiento.CurrentRow.Cells["medicamento"].Value.ToString();
				txtDosis.Text = dgvTratamiento.CurrentRow.Cells["dosis"].Value.ToString();
				txtDuracion.Text = dgvTratamiento.CurrentRow.Cells["duracion"].Value.ToString();
				txtObservacion.Text = dgvTratamiento.CurrentRow.Cells["observaciones"].Value.ToString();
			}
		}
	}
}