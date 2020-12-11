using Salutem.DAO;
using Salutem.Model;
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
    public partial class FrmDistribuicao : Form
    {
        public FrmDistribuicao()
        {
            InitializeComponent();
        }
        

        private void btnExecutarDist_Click(object sender, EventArgs e)
        {
            try
            {
                ClienteDAO clientedao = new ClienteDAO();
                Cliente cliente = new Cliente();

                for (int i = 0; i < dgvClientes.Rows.Count; i++)
                {
                    int cod_cliente = int.Parse(dgvClientes.Rows[i].Cells[0].Value.ToString());
                    

                    bindingSource2.DataSource = clientedao.BuscarClienteDist(cod_cliente);
                    
                    dgvDistribuicao.AutoGenerateColumns = false;
                    dgvDistribuicao.DataSource = bindingSource2;

                    //Update na table Cliente para inserir e corrigir os viculos com o vendedor
                    int cod_vendedor = int.Parse(dgvDistribuicao.Rows[0].Cells[2].Value.ToString());
                    string distancia = dgvDistribuicao.Rows[0].Cells[4].Value.ToString();

                    cliente.cod_vendedor_fk = cod_vendedor;
                    cliente.distancia = distancia;

                    cliente.cod_cliente = cod_cliente;
                    if (clientedao.Alterar(cliente, "DIST") == false)
                    {
                        return;
                    }
                }
                dgvDistribuicao.Rows.Clear();
                MessageBox.Show("Cliente viculados aos vendedores!", "Sucesso", 0, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }

        }

        private void FrmDistribuicao_Load(object sender, EventArgs e)
        {
            ClienteDAO clientedao = new ClienteDAO();
            bindingSource1.DataSource = clientedao.BuscarRazaoSocial("", "ASC");

            dgvClientes.AutoGenerateColumns = false;
            dgvClientes.DataSource = bindingSource1;
        }
    }
}
