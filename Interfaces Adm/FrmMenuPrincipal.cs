using REPORTES.Reportes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace REPORTES.Interfaces
{
    public partial class FrmMenuPrincipal : Form
    {
        public FrmMenuPrincipal()
        {
            InitializeComponent();
        }

        private void registrarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRegistroCliente frm = new FrmRegistroCliente();
            frm.ShowDialog();
        }

        private void solicitarPréstamoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSolicitudPrestamo frm = new FrmSolicitudPrestamo();
            frm.ShowDialog();
        }

        private void gestiónDePagosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGestionPagos frm = new FrmGestionPagos();
            frm.ShowDialog();
        }

        private void verInformaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmVisualizacionDatos frm = new FrmVisualizacionDatos();
            frm.ShowDialog();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tablaDeAmortizaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTablaAmortizacion frm = new FrmTablaAmortizacion();
            frm.Show();
        }

        private void informaciónDeClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmInformacionCliente frm = new FrmInformacionCliente();
            frm.Show();
        }

        private void salirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void totalPrestadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTotalPrestado frm = new FrmTotalPrestado();
            frm.Show();
        }

        private void morasAcumuladasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMorasAcumuladas frm = new FrmMorasAcumuladas();
            frm.Show();
        }

        private void clientesMorososToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmClientesMorosos frm = new FrmClientesMorosos();
            frm.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void visualizacionDeMorasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMoras frm = new FrmMoras();
            frm.Show();
        }

        private void FrmMenuPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void adminsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRegistroAdmin frm = new FrmRegistroAdmin();
            frm.Show();
        }
    }
}
