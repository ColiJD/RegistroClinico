using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BitacoraLeo
{

    public class Conexion
    {
        public static string conexion = "Data Source=localhost;Initial Catalog=ClinicaRegistro;Integrated Security=True";
        public SqlConnection sconexion = new SqlConnection();

        //Constructor de la clase conexión
        public Conexion()
        {
            sconexion.ConnectionString = conexion;

        }

        //Metodo para abrir la conexion a Sql Server
        public void abrir()
        {
            try
            {
                sconexion.Open();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error");
            }
        }

        //Metodo para cerrar la conexion a Sql Server
        public void cerrar()
        {
            try
            {
                sconexion.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error al cerrar");
            }
        }

        // Funcion para cargarDatos de cualquier tabla y asignarlos a un datagridview
        /// <param name="dgv"></Recibe el DataGridView en el cual queremos cargar los datos>
        /// <param name="NameTable"></Recibe la tablade Sql en la cual se buscaran los datos a cargar>

        public void cargarDatos(DataGridView dgv, string NameTable)
        {
            try
            {
                sconexion.Open();
                SqlDataAdapter da = new SqlDataAdapter("Select * from " + NameTable, conexion);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;
                sconexion.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pueden cargar los datos " + ex.ToString());
            }
        }
        // Función para obtener datos de una consulta SQL personalizada y devolverlos como un DataTable
        public DataTable EjecutarConsulta(string consultaSQL)
        {
            {
                sconexion.Open();
                using (SqlCommand cmd = new SqlCommand(consultaSQL, sconexion))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    // Insertar una fila vacía al inicio
                    DataRow emptyRow = table.NewRow();
                    table.Rows.InsertAt(emptyRow, 0);
                    sconexion.Close();

                    return table;
                    
                }
            }
        }
    }
}







