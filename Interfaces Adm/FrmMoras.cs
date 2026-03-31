using REPORTES.Calculations;
using REPORTES.Domain;
using System;
using System.Linq;
using System.Windows.Forms;

namespace REPORTES.Interfaces
{
    public partial class FrmMoras : Form
    {
        PrestamosDBEntities db = new PrestamosDBEntities();

        public FrmMoras()
        {
            InitializeComponent();
        }

        private void FrmMoras_Load(object sender, EventArgs e)
        {
            cmbPrestamo.DataSource = db.Prestamos
                .Select(p => new
                {
                    p.Id,
                    Cliente = p.Clientes.NombreCompleto
                }).ToList();

            cmbPrestamo.DisplayMember = "Cliente";
            cmbPrestamo.ValueMember = "Id";

            CargarMoras();
        }

        public void CargarMoras()
        {
            dgvMoras.DataSource = db.Moras
                .Select(m => new
                {
                    m.Id,
                    m.PrestamoId,
                    m.Cantidad
                }).ToList();
        }

        private void btnCalcularMora_Click(object sender, EventArgs e)
        {
            decimal cuota = Convert.ToDecimal(txtCuotaMensual.Text);

            decimal mora = LoanCalculator.CalcularMora(cuota);

            txtMora.Text = mora.ToString();
        }

        private void btnRegistrarMora_Click(object sender, EventArgs e)
        {
            decimal cantidadMora;

            bool esNumero = decimal.TryParse(txtMora.Text, out cantidadMora);

            if (!esNumero)
            {
                MessageBox.Show("Ingrese un número válido");
                return;
            }

            Moras nuevaMora = new Moras();

            nuevaMora.PrestamoId = (int)cmbPrestamo.SelectedValue;
            nuevaMora.Cantidad = (int)cantidadMora;

            db.Moras.Add(nuevaMora);
            db.SaveChanges();

            MessageBox.Show("Mora registrada correctamente");

            CargarMoras();
            LimpiarCampos();
        }

        public void LimpiarCampos()
        {
            txtCuotaMensual.Clear();
            txtMora.Clear();
        }
    }
}
