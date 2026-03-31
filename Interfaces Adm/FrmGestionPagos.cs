using REPORTES.Calculations;
using REPORTES.Domain;
using System;
using System.Linq;
using System.Windows.Forms;

namespace REPORTES.Interfaces
{
    public partial class FrmGestionPagos : Form
    {
        PrestamosDBEntities db = new PrestamosDBEntities();

        public FrmGestionPagos()
        {
            InitializeComponent();
        }

        private void FrmGestionPagos_Load(object sender, EventArgs e)
        {
            cmbCliente.DataSource = db.Prestamos
                .Select(p => new
                {
                    p.Id,
                    Cliente = p.Clientes.NombreCompleto
                }).ToList();

            cmbCliente.DisplayMember = "Cliente";
            cmbCliente.ValueMember = "Id";

            CargarPagos();
        }

        private void btnCalcularPago_Click(object sender, EventArgs e)
        {
            decimal montoAnterior = Convert.ToDecimal(txtMontoAnterior.Text);
            int mesesRestantes = Convert.ToInt32(txtMesesRestantes.Text);
            decimal interesesPrevios = Convert.ToDecimal(txtTotalIntereses.Text);
            decimal abonoExtra = Convert.ToDecimal(txtCuota.Text);

            var pago = LoanCalculator.CalcularPagoDelMes(
                montoAnterior,
                mesesRestantes,
                interesesPrevios,
                abonoExtra
            );

            txtInteres.Text = pago.InteresAPagar.ToString();
            txtNuevoMonto.Text = pago.NuevoMontoAdeudado.ToString();
            txtMesesRestantes.Text = pago.MesesRestantes.ToString();
            txtTotalIntereses.Text = pago.TotalInteresesAcumulados.ToString();
        }

        private void btnRegistrarPago_Click(object sender, EventArgs e)
        {
            if (cmbCliente.Text == "" || txtCuota.Text == "")
            {
                MessageBox.Show("Debe completar los campos");
                return;
            }

            Pagos pago = new Pagos();

            pago.PrestamoId = (int)cmbCliente.SelectedValue;
            pago.MontoAnterior = Convert.ToDecimal(txtMontoAnterior.Text);
            pago.InteresPagado = Convert.ToDecimal(txtInteres.Text);
            pago.MontoAbonado = Convert.ToDecimal(txtCuota.Text);
            pago.NuevoMonto = Convert.ToDecimal(txtNuevoMonto.Text);
            pago.FechaPago = DateTime.Now;

            db.Pagos.Add(pago);
            db.SaveChanges();

            CargarPagos();
            LimpiarCampos();
        }

        public void CargarPagos()
        {
            dataGridView1.DataSource = db.Pagos
                .Select(p => new
                {
                    p.Id,
                    p.PrestamoId,
                    p.MontoAnterior,
                    p.InteresPagado,
                    p.MontoAbonado,
                    p.NuevoMonto,
                    p.FechaPago
                }).ToList();
        }

        private void LimpiarCampos()
        {
            cmbCliente.SelectedIndex = -1;
            txtMontoAnterior.Clear();
            txtInteres.Clear();
            txtCuota.Clear();
            txtNuevoMonto.Clear();
            txtMesesRestantes.Clear();
            txtTotalIntereses.Clear();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
    }
}
