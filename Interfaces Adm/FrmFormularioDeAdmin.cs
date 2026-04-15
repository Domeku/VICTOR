using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using System.Data.SqlClient;

namespace REPORTES.Interfaces
{
    public partial class FrmFormularioDeAdmin : Form
    {
        public FrmFormularioDeAdmin()
        {
            InitializeComponent();
            btnGuardar.Click += btnGuardar_Click;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "" || txtClave.Text == "")
            {
                MessageBox.Show("Debe llenar todos los campos");
                return;
            }

            using (PrestamosDBEntities db = new PrestamosDBEntities())
            {
                // 🔎 Buscar usuario en la BD
                var usuario = db.Administradores
                    .FirstOrDefault(a => a.Usuario == txtUsuario.Text
                                      && a.Clave == txtClave.Text);

                if (usuario != null)
                {
                    MessageBox.Show("Bienvenido " + usuario.Usuario);
                    this.Hide();

                    
                    FrmMenuPrincipal menu = new FrmMenuPrincipal();
                    menu.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos");
                }
            }
        }
    }
}
