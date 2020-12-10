using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Salutem
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        private void cadastroDeClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCadastroClientes frmcadastroclientes = new FrmCadastroClientes();
            frmcadastroclientes.ShowDialog();
        }

        private void cadastroDeVendedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCadastroVendedor frmcadastrovendedor = new FrmCadastroVendedor();
            frmcadastrovendedor.ShowDialog();
        }

        private void exportaçãDeClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmExportClientes frmexportclientes = new FrmExportClientes();
            frmexportclientes.ShowDialog();
        }

        private void exportaçãoDeVendedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmExportVendedores frmexportvendedores = new FrmExportVendedores();
            frmexportvendedores.ShowDialog();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
