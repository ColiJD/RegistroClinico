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
	public partial class Fr_Citas : Form
	{
		Conexion clConexion = new Conexion();
		Funciones funciones = new Funciones();
		public Fr_Citas()
		{
			InitializeComponent();
		}

		private void Fr_Citas_Load(object sender, EventArgs e)
		{
			// 🔹 Cargar combos
			CargarPacientes();
			CargarMedicos();
			CargarEstados();
			MostrarCitasConNombres();


			// 🔹 Mostrar citas en el grid
			clConexion.cargarDatos(dgvGrip, "Citas");
		}

		private void CargarPacientes()
		{
			string query = "SELECT pacienteID, nombre + ' ' + apellido AS NombreCompleto FROM Pacientes";
			SqlDataAdapter da = new SqlDataAdapter(query, clConexion.sconexion);
			DataTable dt = new DataTable();
			da.Fill(dt);

			// Agregar fila vacía
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

			// Agregar fila vacía
			DataRow row = dt.NewRow();
			row["medicoID"] = 0;
			row["NombreCompleto"] = "";
			dt.Rows.InsertAt(row, 0);

			cbMedico.DataSource = dt;
			cbMedico.DisplayMember = "NombreCompleto";
			cbMedico.ValueMember = "medicoID";
			cbMedico.SelectedIndex = 0;
		}


		private void CargarEstados()
		{
			cbEstado.Items.Clear();
			cbEstado.Items.Add("Pendiente");
			cbEstado.Items.Add("Confirmada");
			cbEstado.Items.Add("Cancelada");
			cbEstado.Items.Add("Finalizada");
			cbEstado.SelectedIndex = 0; // valor por defecto
		}

		private void btnAgregar_Click(object sender, EventArgs e)
		{
			if (funciones.CamposVacios(txtMotivo))
			{
				errorProviderGenerico.SetError(txtMotivo, "El campo motivo no puede estar vacío.");
				MessageBox.Show("Error... No puede insertar datos en blanco", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			try
			{
				clConexion.abrir();

				// 🔹 Validación de cita duplicada
				using (var validar = new SqlCommand(
					"SELECT COUNT(*) FROM Citas WHERE pacienteID=@pacienteID AND medicoID=@medicoID AND fechaHora=@fechaHora", clConexion.sconexion))
				{
					validar.Parameters.AddWithValue("@pacienteID", cbPaciente.SelectedValue);
					validar.Parameters.AddWithValue("@medicoID", cbMedico.SelectedValue);
					validar.Parameters.AddWithValue("@fechaHora", dtpFecha.Value);

					int existe = (int)validar.ExecuteScalar();
					if (existe > 0)
					{
						MessageBox.Show("Ya existe una cita registrada con el mismo paciente, médico y fecha/hora.",
										"AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						return;
					}
				}

				// 🔹 Insertar si no está repetida
				using (var agregar = new SqlCommand(
					"INSERT INTO Citas (pacienteID, medicoID, fechaHora, motivoConsulta, estado) " +
					"VALUES (@pacienteID, @medicoID, @fechaHora, @motivo, @estado)", clConexion.sconexion))
				{
					agregar.Parameters.AddWithValue("@pacienteID", cbPaciente.SelectedValue);
					agregar.Parameters.AddWithValue("@medicoID", cbMedico.SelectedValue);
					agregar.Parameters.AddWithValue("@fechaHora", dtpFecha.Value);
					agregar.Parameters.AddWithValue("@motivo", txtMotivo.Text);
					agregar.Parameters.AddWithValue("@estado", cbEstado.SelectedItem.ToString());

					agregar.ExecuteNonQuery();
					MessageBox.Show("Aviso ... La cita se agregó exitosamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);

					funciones.LimpiarCampos(txtMotivo, txtCodigo, txtBuscar);
					funciones.LimpiarComboBox(cbEstado, cbMedico, cbPaciente);
					cbPaciente.SelectedIndex = 0;
					cbMedico.SelectedIndex = 0;
					cbEstado.SelectedIndex = 0;
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
				MostrarCitasConNombres(); // 🔹 recarga el grid con los nombres
				errorProviderGenerico.Clear();
				funciones.LimpiarCampos(txtMotivo, txtCodigo, txtBuscar);
				funciones.LimpiarComboBox(cbEstado, cbMedico, cbPaciente);

			}
		}

		private void MostrarCitasConNombres()
		{
			try
			{
				clConexion.abrir();

				SqlDataAdapter da = new SqlDataAdapter(@"
            SELECT 
                c.citaID,
                c.pacienteID,
                c.medicoID,
                p.nombre + ' ' + p.apellido AS Paciente,
                m.nombre + ' ' + m.apellido AS Medico,
                c.fechaHora,
                c.motivoConsulta,
                c.estado
            FROM Citas c
            INNER JOIN Pacientes p ON c.pacienteID = p.pacienteID
            INNER JOIN Medicos m ON c.medicoID = m.medicoID
            ORDER BY c.fechaHora", clConexion.sconexion);

				DataTable dt = new DataTable();
				da.Fill(dt);

				dgvGrip.DataSource = dt;

				// Ocultar columnas de ID para mostrar solo nombres
				dgvGrip.Columns["pacienteID"].Visible = false;
				dgvGrip.Columns["medicoID"].Visible = false;
			}
			finally
			{
				clConexion.cerrar();
			}
		}
		private void btnModificar_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtCodigo.Text))
			{
				MessageBox.Show("Debe seleccionar una cita para modificar.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// 🔹 Confirmación antes de modificar
			DialogResult confirmacion = MessageBox.Show(
				"¿Está seguro que desea modificar esta cita?",
				"Confirmar modificación",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question
			);

			if (confirmacion != DialogResult.Yes) return;

			try
			{
				clConexion.abrir();

				using (var modificar = new SqlCommand(
					@"UPDATE Citas 
              SET pacienteID=@pacienteID, 
                  medicoID=@medicoID, 
                  fechaHora=@fechaHora, 
                  motivoConsulta=@motivoConsulta, 
                  estado=@estado 
              WHERE citaID=@citaID", clConexion.sconexion))
				{
					// 🔹 Usamos SelectedValue para ID de paciente y médico
					int pacienteID = Convert.ToInt32(cbPaciente.SelectedValue ?? 0);
					int medicoID = Convert.ToInt32(cbMedico.SelectedValue ?? 0);

					if (pacienteID == 0 || medicoID == 0)
					{
						MessageBox.Show("Debe seleccionar un paciente y un médico válidos.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}

					modificar.Parameters.AddWithValue("@citaID", Convert.ToInt32(txtCodigo.Text));
					modificar.Parameters.AddWithValue("@pacienteID", pacienteID);
					modificar.Parameters.AddWithValue("@medicoID", medicoID);
					modificar.Parameters.AddWithValue("@fechaHora", dtpFecha.Value);
					modificar.Parameters.AddWithValue("@motivoConsulta", txtMotivo.Text);
					modificar.Parameters.AddWithValue("@estado", cbEstado.SelectedItem?.ToString() ?? "Pendiente");

					modificar.ExecuteNonQuery();
					funciones.LimpiarCampos(txtMotivo, txtCodigo, txtBuscar);
					funciones.LimpiarComboBox(cbEstado, cbMedico, cbPaciente);
				}

				MessageBox.Show("La cita se modificó exitosamente.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
				funciones.LimpiarCampos(txtMotivo, txtCodigo, txtBuscar);
				funciones.LimpiarComboBox(cbEstado, cbMedico, cbPaciente);
				MostrarCitasConNombres();
			}
		}


		private void btnEliminar_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtCodigo.Text))
			{
				MessageBox.Show("Debe seleccionar una cita para eliminar.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// 🔹 Confirmación antes de eliminar
			DialogResult confirmacion = MessageBox.Show(
				"¿Está seguro que desea eliminar esta cita?",
				"Confirmar eliminación",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question
			);

			if (confirmacion != DialogResult.Yes)
			{
				return; // ❌ Cancela la eliminación
			}

			try
			{
				clConexion.abrir();
				int citaID = Convert.ToInt32(txtCodigo.Text);

				using (var eliminar = new SqlCommand("DELETE FROM Citas WHERE citaID=@citaID", clConexion.sconexion))
				{
					eliminar.Parameters.AddWithValue("@citaID", citaID);
					eliminar.ExecuteNonQuery();
				}

				MessageBox.Show("La cita se eliminó exitosamente.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);

				// 🔹 Limpiar campos después de eliminar
				txtCodigo.Clear();
				txtMotivo.Clear();
				cbPaciente.SelectedIndex = 0;
				cbMedico.SelectedIndex = 0;
				cbEstado.SelectedIndex = 0;
				dtpFecha.Value = DateTime.Now;
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
				MostrarCitasConNombres();
				funciones.LimpiarCampos(txtMotivo, txtCodigo, txtBuscar);
				funciones.LimpiarComboBox(cbEstado, cbMedico, cbPaciente);
			}
		}

		private void dgvGrip_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (dgvGrip.CurrentRow == null) return;

			txtCodigo.Text = dgvGrip.CurrentRow.Cells["citaID"].Value.ToString();

			// Asignar los IDs a los ComboBox
			cbPaciente.SelectedValue = dgvGrip.CurrentRow.Cells["pacienteID"].Value;
			cbMedico.SelectedValue = dgvGrip.CurrentRow.Cells["medicoID"].Value;

			dtpFecha.Value = Convert.ToDateTime(dgvGrip.CurrentRow.Cells["fechaHora"].Value);
			txtMotivo.Text = dgvGrip.CurrentRow.Cells["motivoConsulta"].Value.ToString();

			// Asignar estado si existe en el ComboBox
			string estado = dgvGrip.CurrentRow.Cells["estado"].Value.ToString();
			if (cbEstado.Items.Contains(estado))
				cbEstado.SelectedItem = estado;
			else
				cbEstado.SelectedIndex = 0; // Pendiente por defecto
		}

		private void txtBuscar_TextChanged(object sender, EventArgs e)
		{
			string searchTerm = txtBuscar.Text.Trim();
			clConexion.abrir();

			SqlCommand buscar;
			if (string.IsNullOrWhiteSpace(searchTerm))
			{
				buscar = new SqlCommand("SELECT * FROM Citas", clConexion.sconexion);
			}
			else
			{
				buscar = new SqlCommand(
					"SELECT * FROM Citas WHERE motivoConsulta LIKE @motivo", clConexion.sconexion);
				buscar.Parameters.AddWithValue("@motivo", "%" + searchTerm + "%");
			}

			SqlDataAdapter adapter = new SqlDataAdapter(buscar);
			DataTable dt = new DataTable();
			adapter.Fill(dt);
			dgvGrip.DataSource = dt;

			clConexion.cerrar();
		}
	}
}