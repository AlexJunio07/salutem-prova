using Salutem.DAO;
using Salutem.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
                if (dgvClientes.RowCount < 1)
                {
                    MessageBox.Show("Não existe nenhum Cliente cadastrado", "Atenção", 0, MessageBoxIcon.Warning);
                }
                else
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
                        double distancia = Convert.ToDouble(dgvDistribuicao.Rows[0].Cells[4].Value.ToString());

                        cliente.cod_vendedor_fk = cod_vendedor;

                        //Converte para Metros
                        distancia = distancia * 1000;
                        //Formata a distancia
                        string valor_distancia = string.Empty;
                        valor_distancia = distancia.ToString().Split(',')[0];

                        cliente.distancia = valor_distancia;

                        cliente.cod_cliente = cod_cliente;
                        if (clientedao.Alterar(cliente, "DIST") == false)
                        {
                            return;
                        }
                    }

                    dgvDistribuicao.Rows.Clear();
                    //Mudar Name da Coluna para receber o cod do vendedor FK
                    dgvDistribuicao.Columns[2].DataPropertyName = "COD_VENDEDOR_FK";
                    bindingSource2.DataSource = clientedao.BuscarCodCliente(0, "ASC");
                    dgvDistribuicao.AutoGenerateColumns = false;
                    dgvDistribuicao.DataSource = bindingSource2;

                    MessageBox.Show("Cliente viculados aos vendedores!", "Sucesso", 0, MessageBoxIcon.Exclamation);

                    //Gerar CSV
                    string caminhoCSV = string.Empty;
                    using (var pasta = new FolderBrowserDialog())
                    {
                        DialogResult result = pasta.ShowDialog();

                        if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(pasta.SelectedPath))
                        {
                            caminhoCSV = pasta.SelectedPath;
                        }
                    }
                    //Cria o arquivo passando seu caminho
                    StreamWriter file = new System.IO.StreamWriter(caminhoCSV.ToString().Replace("\\", "\\\\") +
                    "\\\\dist_cliente_vendedor.csv");


                    string sLine = "";
                    //Percorre todas as linhas da tabela
                    for (int r = 0; r <= dgvDistribuicao.Rows.Count - 1; r++)
                    {
                        //Percorre cada coluna e o número da linha
                        for (int c = 0; c <= dgvDistribuicao.Columns.Count - 1; c++)
                        {
                            sLine = sLine + dgvDistribuicao.Rows[r].Cells[c].Value;
                            if (c != dgvDistribuicao.Columns.Count - 1)
                            {
                                //Separador dos dados
                                sLine = sLine + ",";
                            }
                        }
                        //CSV gravado
                        file.WriteLine(sLine);
                        sLine = "";
                    }

                    file.Close();
                    MessageBox.Show("Exportação de Clientes/Vendedores Completada.", "Expotação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }

        }

        private void FrmDistribuicao_Load(object sender, EventArgs e)
        {
            ClienteDAO clientedao = new ClienteDAO();
            bindingSource1.DataSource = clientedao.PesquisarCliente("%");

            dgvClientes.AutoGenerateColumns = false;
            dgvClientes.DataSource = bindingSource1;
        }
    }
}
