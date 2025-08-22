using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitacoraLeo
{
	public class Data
	{
		private Conexion conexion = new Conexion();

		public DataTable ObtenerPacientes()
		{
			DataTable dt = conexion.EjecutarConsulta("SELECT pacienteID, nombre + ' ' + apellido AS NombreCompleto FROM Pacientes ORDER BY nombre, apellido");

			// Fila vacía al inicio
			DataRow row = dt.NewRow();
			dt.Rows.InsertAt(row, 0);
			return dt;
		}

		public DataTable ObtenerMedicos()
		{
			DataTable dt = conexion.EjecutarConsulta("SELECT medicoID, nombre + ' ' + apellido AS NombreCompleto FROM Medicos ORDER BY nombre, apellido");

			// Fila vacía al inicio
			DataRow row = dt.NewRow();
			dt.Rows.InsertAt(row, 0);
			return dt;
		}
	}
}