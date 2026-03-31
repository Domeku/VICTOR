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
    public partial class log : Form
    {
        public log()
        {
            InitializeComponent();
        }

        private void btnAdm_Click(object sender, EventArgs e)
        {
            FrmFormularioDeAdmin frm = new FrmFormularioDeAdmin();
            frm.Show();
            this.Hide();
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            FrmMenuCliente frm = new FrmMenuCliente();
            frm.Show();
            this.Hide();
        }
    }
}
