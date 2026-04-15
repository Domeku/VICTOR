using Microsoft.Reporting.WinForms;
using REPORTES.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace REPORTES.Reportes
{
    public partial class FrmTablaAmortizacion : Form
    {
        public FrmTablaAmortizacion()
        {
            InitializeComponent();
        }

        private void FrmTablaAmortizacion_Load(object sender, EventArgs e)
        {
            reportViewer1.Reset();
        }

      

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtPrestamo_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funciona");

            if (!int.TryParse(txtPrestamo.Text, out int prestamoId))
            {
                MessageBox.Show("Ingrese un ID válido");
                return;
            }

            var service = new PrestamoService();
            var datos = service.ObtenerTablaAmortizacion(prestamoId);

            reportViewer1.Reset();
            reportViewer1.LocalReport.ReportEmbeddedResource = "REPORTES.Reportes.ReporteAmortizacion.rdlc";

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(
                new ReportDataSource("Amortizacion", datos)
            );

            reportViewer1.RefreshReport();
        }
    }
}
