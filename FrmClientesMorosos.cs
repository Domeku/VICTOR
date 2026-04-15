using Microsoft.Reporting.WinForms;
using REPORTES.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace REPORTES.Reportes
{
    public partial class FrmClientesMorosos : Form
    {
        public FrmClientesMorosos()
        {
            InitializeComponent();
        }

        private void FrmClientesMorosos_Load(object sender, EventArgs e)
        {
            var service = new ReporteService();

            var datos = service.ObtenerClientesMorosos();

            reportViewer1.Reset();

            reportViewer1.LocalReport.ReportPath = "Reportes/ReporteMorosos.rdlc";

            reportViewer1.LocalReport.DataSources.Clear();

            reportViewer1.LocalReport.DataSources.Add(
                new ReportDataSource("Morosos", datos)
            );

            reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
