using Salutem.DAO;
using Salutem.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
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

        private void BuscarDados()
        {
            try
            {
                ClienteDAO clientedao = new ClienteDAO();

                if (rdbAscendente.Checked == true)
                {
                    if (rdbCodCliente.Checked == true)
                    {

                        if (txtCodCliente.Text == "")
                        {
                            bindingSource1.DataSource = clientedao.BuscarCodCliente(0, "ASC");
                        }
                        else
                        {
                            bindingSource1.DataSource = clientedao.BuscarCodCliente(int.Parse(txtCodCliente.Text), "ASC");
                        }

                        dgvExport.AutoGenerateColumns = false;
                        dgvExport.DataSource = bindingSource1;
                    }
                    else if (rdbRazaoSocial.Checked == true)
                    {
                        bindingSource1.DataSource = clientedao.BuscarRazaoSocial(txtRazaoSocial.Text, "ASC");
                        dgvExport.AutoGenerateColumns = false;
                        dgvExport.DataSource = bindingSource1;
                    }
                    else
                    {
                        if (txtCodVendedor.Text == "")
                        {
                            bindingSource1.DataSource = clientedao.BuscarCodVendedor(0, "ASC");
                        }
                        else
                        {
                            bindingSource1.DataSource = clientedao.BuscarCodVendedor(int.Parse(txtCodVendedor.Text), "ASC");
                        }
                        dgvExport.AutoGenerateColumns = false;
                        dgvExport.DataSource = bindingSource1;

                    }
                }
                else
                {
                    if (rdbCodCliente.Checked == true)
                    {

                        if (txtCodCliente.Text == "")
                        {
                            bindingSource1.DataSource = clientedao.BuscarCodCliente(0, "DESC");
                        }
                        else
                        {
                            bindingSource1.DataSource = clientedao.BuscarCodCliente(int.Parse(txtCodCliente.Text), "ASC");
                        }

                        dgvExport.AutoGenerateColumns = false;
                        dgvExport.DataSource = bindingSource1;
                    }

                    else
                    {
                        bindingSource1.DataSource = clientedao.BuscarRazaoSocial(txtRazaoSocial.Text, "DESC");
                        dgvExport.AutoGenerateColumns = false;
                        dgvExport.DataSource = bindingSource1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        private void btnExportTxt_Click(object sender, EventArgs e)
        {
            if (txtCaminho.Text == "")
            {
                MessageBox.Show("Selecione o caminho para salvar o arquivo.", "Atenção", 0, MessageBoxIcon.Warning);
                using (var pasta = new FolderBrowserDialog())
                {
                    DialogResult result = pasta.ShowDialog();

                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(pasta.SelectedPath))
                    {
                        txtCaminho.Text = pasta.SelectedPath;
                    }
                }
            }

            else if (dgvExport.RowCount == 0)
            {
                MessageBox.Show("Nenhum registro encontrado.", "Atenção", 0, MessageBoxIcon.Warning);
            }
            else
            {

                //Cria o arquivo passando seu caminho
                StreamWriter file = new System.IO.StreamWriter(txtCaminho.Text.ToString().Replace("\\", "\\\\") +
                    "\\\\export_clientes.txt");
                try
                {
                    string sLine = "";

                    //Percorre todas as linhas da tabela
                    for (int r = 0; r <= dgvExport.Rows.Count - 1; r++)
                    {
                        //Percorre cada coluna e o número da linha
                        for (int c = 0; c <= dgvExport.Columns.Count - 1; c++)
                        {
                            sLine = sLine + dgvExport.Rows[r].Cells[c].Value;
                            if (c != dgvExport.Columns.Count - 1)
                            {
                                //Separador de dados
                                sLine = sLine + "  ";
                            }
                        }
                        //TXT gravado
                        file.WriteLine(sLine);
                        sLine = "";
                    }

                    file.Close();
                    MessageBox.Show("Exportação de Clientes Completada.", "Expotação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    file.Close();
                }
            }

        }

        private void FrmExportClientes_Load(object sender, EventArgs e)
        {

        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            using (var pasta = new FolderBrowserDialog())
            {
                DialogResult result = pasta.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(pasta.SelectedPath))
                {
                    txtCaminho.Text = pasta.SelectedPath;
                }
            }
        }

        private void btnExportCSV_Click(object sender, EventArgs e)
        {

            if (txtCaminho.Text == "")
            {
                MessageBox.Show("Selecione o caminho para salvar o arquivo.", "Atenção", 0, MessageBoxIcon.Warning);
                using (var pasta = new FolderBrowserDialog())
                {
                    DialogResult result = pasta.ShowDialog();

                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(pasta.SelectedPath))
                    {
                        txtCaminho.Text = pasta.SelectedPath;
                    }
                }
            }
            else if (dgvExport.RowCount == 0)
            {
                MessageBox.Show("Nenhum registro encontrado.", "Atenção", 0, MessageBoxIcon.Warning);
            }
            else
            {
                //Cria o arquivo passando seu caminho
                StreamWriter file = new System.IO.StreamWriter(txtCaminho.Text.ToString().Replace("\\", "\\\\") +
                "\\\\export_clientes.csv");

                try
                {
                    string sLine = "";
                    //Percorre todas as linhas da tabela
                    for (int r = 0; r <= dgvExport.Rows.Count - 1; r++)
                    {
                        //Percorre cada coluna e o número da linha
                        for (int c = 0; c <= dgvExport.Columns.Count - 1; c++)
                        {
                            sLine = sLine + dgvExport.Rows[r].Cells[c].Value;
                            if (c != dgvExport.Columns.Count - 1)
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
                    MessageBox.Show("Exportação de Clientes Completada.", "Expotação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    file.Close();
                }
            }

        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            BuscarDados();
        }

        private void rdbRazaoSocial_CheckedChanged(object sender, EventArgs e)
        {
            txtCodCliente.Enabled = false;
            txtRazaoSocial.Enabled = true;
            txtCodVendedor.Enabled = false;
            txtCodCliente.Text = string.Empty;
            txtCodVendedor.Text = string.Empty;
            txtRazaoSocial.Focus();
        }

        private void rdbCodCliente_CheckedChanged(object sender, EventArgs e)
        {
            txtCodCliente.Enabled = true;
            txtRazaoSocial.Enabled = false;
            txtCodVendedor.Enabled = false;
            txtRazaoSocial.Text = string.Empty;
            txtCodVendedor.Text = string.Empty;
        }

        private void txtCodCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funcoes.DigitarNumeros(e);
        }

        private void txtCodCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BuscarDados();
            }
        }

        private void txtRazaoSocial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BuscarDados();
            }
        }

        private void rdbCodVendedor_CheckedChanged(object sender, EventArgs e)
        {
            txtCodCliente.Enabled = false;
            txtRazaoSocial.Enabled = false;
            txtCodVendedor.Enabled = true;
            txtCodVendedor.Focus();
            txtRazaoSocial.Text = string.Empty;
            txtCodCliente.Text = string.Empty;
        }

        private void txtCodVendedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funcoes.DigitarNumeros(e);
        }

        private void txtCodVendedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BuscarDados();
            }
        }
    }
}