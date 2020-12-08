using Salutem.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Salutem
{
    public partial class FrmExportClientes : Form
    {
        public FrmExportClientes()
        {
            InitializeComponent();
        }

        string conStr = ConfigurationManager.ConnectionStrings["conMySql"].ConnectionString;

        private void btnExportTxt_Click(object sender, EventArgs e)
        {
            
        }

        private void FrmExportClientes_Load(object sender, EventArgs e)
        {
            ClienteDAO clientedao = new ClienteDAO();
            bindingSource1.DataSource = clientedao.BuscarRazaoSocial("%");

            dgvExport.AutoGenerateColumns = false;
            dgvExport.DataSource = bindingSource1;
        }
    }
}
