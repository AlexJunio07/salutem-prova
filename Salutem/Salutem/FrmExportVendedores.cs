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
    public partial class FrmExportVendedores : Form
    {
        public FrmExportVendedores()
        {
            InitializeComponent();
        }
        
        private void BuscarDados()
        {
            try
            {


                VendedorDAO vendedordao = new VendedorDAO();

                if (rdbAscendente.Checked == true)
                {
                    if (rdbCodVendedor.Checked == true)
                    {
                        if (txtCodVendedor.Text == "")
                        {
                            bindingSource1.DataSource = vendedordao.BuscarCodVendedor(0, "ASC");
                        }
                        else
                        {
                            bindingSource1.DataSource = vendedordao.BuscarCodVendedor(int.Parse(txtCodVendedor.Text), "ASC");
                        }

                        dgvExport.AutoGenerateColumns = false;
                        dgvExport.DataSource = bindingSource1;
                    }
                    else
                    {
                        bindingSource1.DataSource = vendedordao.BuscarNome(txtNome.Text, "ASC");
                        dgvExport.AutoGenerateColumns = false;
                        dgvExport.DataSource = bindingSource1;
                    }
                }
                else
                {
                    if (rdbCodVendedor.Checked == true)
                    {

                        if (txtCodVendedor.Text == "")
                        {
                            bindingSource1.DataSource = vendedordao.BuscarCodVendedor(0, "DESC");
                        }
                        else
                        {
                            bindingSource1.DataSource = vendedordao.BuscarCodVendedor(int.Parse(txtCodVendedor.Text), "ASC");
                        }

                        dgvExport.AutoGenerateColumns = false;
                        dgvExport.DataSource = bindingSource1;
                    }

                    else
                    {
                        bindingSource1.DataSource = vendedordao.BuscarNome(txtNome.Text, "DESC");
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

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            BuscarDados();
        }

        private void rdbCodVendedor_CheckedChanged(object sender, EventArgs e)
        {
            txtCodVendedor.Enabled = true;
            txtNome.Enabled = false;
            txtNome.Text = string.Empty;
        }

        private void rdbRazaoSocial_CheckedChanged(object sender, EventArgs e)
        {
            txtCodVendedor.Enabled = false;
            txtNome.Enabled = true;
            txtCodVendedor.Text = string.Empty;
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
                MessageBox.Show("Selecione o caminho do arquivo.", "Atenção", 0, MessageBoxIcon.Warning);
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
                    "\\\\export_vendedores.csv");
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
                                sLine = sLine + ",";
                            }
                        }
                        //CSV gravado
                        file.WriteLine(sLine);
                        sLine = "";
                    }

                    file.Close();
                    MessageBox.Show("Exportação de Vendedores Completada.", "Expotação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    file.Close();
                }
            }
        }

        private void btnExportTxt_Click(object sender, EventArgs e)
        {
            if (txtCaminho.Text == "")
            {
                MessageBox.Show("Selecione o caminho do arquivo.", "Atenção", 0, MessageBoxIcon.Warning);
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
                    "\\\\export_vendedores.txt");
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
                    MessageBox.Show("Exportação de Vendedores Completada.", "Expotação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    file.Close();
                }
            }
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
