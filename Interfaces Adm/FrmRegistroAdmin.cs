using System;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace REPORTES.Interfaces
{
    public partial class FrmRegistroAdmin : Form
    {
        public FrmRegistroAdmin()
        {
            InitializeComponent();
        }

        private void FrmRegistroAdmin_Load(object sender, EventArgs e)
        {
            txtClave.PasswordChar = '*';
            CargarAdmins();
        }

        // 🔥 GUARDAR ADMIN
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "" || txtClave.Text == "")
            {
                MessageBox.Show("Debe llenar todos los campos");
                return;
            }

            try
            {
                using (PrestamosDBEntities db = new PrestamosDBEntities())
                {
                    // 🔍 Validar duplicado
                    var existe = db.Administradores
                        .Any(a => a.Usuario == txtUsuario.Text);

                    if (existe)
                    {
                        MessageBox.Show("Ese usuario ya existe");
                        return;
                    }

                    // 💾 Guardar
                    var admin = new Administradores
                    {
                        Usuario = txtUsuario.Text,
                        Clave = txtClave.Text
                    };

                    db.Administradores.Add(admin);
                    db.SaveChanges();

                    MessageBox.Show("Administrador guardado");

                    txtUsuario.Clear();
                    txtClave.Clear();

                    CargarAdmins(); // 🔄 refrescar tabla
                    LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        // 🔥 CARGAR DATOS EN EL GRID
        private void CargarAdmins()
        {
            using (PrestamosDBEntities db = new PrestamosDBEntities())
            {
                dataGridView1.DataSource = db.Administradores
                    .Select(a => new
                    {
                        a.Id,
                        a.Usuario
                    })
                    .ToList();
            }
        }

        private void label2_Click(object sender, EventArgs e) { }
        private void txtClave_TextChanged(object sender, EventArgs e) { }
        private void txtUsuario_TextChanged(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }


        private void LimpiarCampos()
        {
            txtUsuario.Clear();
            txtClave.Clear();
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}