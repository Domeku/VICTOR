using REPORTES.Calculations;
using REPORTES.Interfaces;
using REPORTES.Services;
using System;
using System.Linq;
using System.Windows.Forms;

namespace REPORTES.Interfaces
{
    public partial class FrmSolicitudPrestamo : Form
    {
        PrestamosDBEntities db = new PrestamosDBEntities();
        PrestamoService prestamoService = new PrestamoService();

        public FrmSolicitudPrestamo()
        {
            InitializeComponent();
        }

        private void FrmSolicitudPrestamo_Load(object sender, EventArgs e)
        {
            cmbCliente.DataSource = db.Clientes.ToList();
            cmbCliente.DisplayMember = "NombreCompleto";
            cmbCliente.ValueMember = "Id";
            cmbCliente.SelectedIndex = -1;

            CargarPrestamos();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMonto.Text) || string.IsNullOrWhiteSpace(txtMeses.Text))
                {
                    MessageBox.Show("Debe completar monto y meses.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal monto;
                int meses;

                if (!decimal.TryParse(txtMonto.Text, out monto))
                {
                    MessageBox.Show("El monto no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(txtMeses.Text, out meses))
                {
                    MessageBox.Show("Los meses no son válidos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                decimal tasaAnual = LoanCalculator.ObtenerTasaAnual(meses);
                decimal interes = LoanCalculator.CalcularInteresSimple(monto, tasaAnual, meses);
                decimal montoTotal = LoanCalculator.CalcularMontoTotal(monto, interes);
                decimal cuota = LoanCalculator.CalcularCuotaMensual(monto, tasaAnual, meses);

                txtInteres.Text = interes.ToString("N2");
                txtTotal.Text = montoTotal.ToString("N2");
                txtCuota.Text = cuota.ToString("N2");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al calcular: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        public void CargarPrestamos()
        {
            dataGridView1.DataSource = db.Prestamos
                .Select(p => new
                {
                    p.Id,
                    Cliente = p.Clientes.NombreCompleto,
                    p.Monto,
                    p.Meses,
                    p.InteresGenerado,
                    p.MontoTotal,
                    p.FechaPrestamo
                })
                .ToList();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbCliente.SelectedIndex == -1 || string.IsNullOrWhiteSpace(txtMonto.Text) || string.IsNullOrWhiteSpace(txtMeses.Text))
                {
                    MessageBox.Show("Debe completar todos los campos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int clienteId = Convert.ToInt32(cmbCliente.SelectedValue);
                decimal monto;
                int meses;

                if (!decimal.TryParse(txtMonto.Text, out monto))
                {
                    MessageBox.Show("El monto no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(txtMeses.Text, out meses))
                {
                    MessageBox.Show("Los meses no son válidos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // AQUÍ es donde se usa la lógica de negocio
                prestamoService.CrearPrestamo(clienteId, monto, meses);

                MessageBox.Show("Préstamo guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Recargar contexto y grid
                db = new PrestamosDBEntities();
                CargarPrestamos();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "No se pudo guardar el préstamo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LimpiarCampos()
        {
            cmbCliente.SelectedIndex = -1;
            txtMonto.Clear();
            txtMeses.Clear();
            txtInteres.Clear();
            txtTotal.Clear();
            txtCuota.Clear();
        }
    }
}