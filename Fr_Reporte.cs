using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BitacoraLeo
{
    public partial class Fr_Reporte : Form
    {
        public Fr_Reporte()
        {
            InitializeComponent();
        }

        private void Fr_Reporte_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dataSetReporte.Bitacora' Puede moverla o quitarla según sea necesario.
            this.bitacoraTableAdapter.Fill(this.dataSetReporte.Bitacora);

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
