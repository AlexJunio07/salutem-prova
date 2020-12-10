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

        string conStr = ConfigurationManager.ConnectionStrings["conMySql"].ConnectionString;

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

                //This line of code creates a text file for the data export.
                StreamWriter file = new System.IO.StreamWriter(txtCaminho.Text.ToString().Replace("\\", "\\\\") +
                    "\\\\export_vendedores.csv");
                try
                {
                    string sLine = "";

                    //This for loop loops through each row in the table
                    for (int r = 0; r <= dgvExport.Rows.Count - 1; r++)
                    {
                        //This for loop loops through each column, and the row number
                        //is passed from the for loop above.
                        for (int c = 0; c <= dgvExport.Columns.Count - 1; c++)
                        {
                            sLine = sLine + dgvExport.Rows[r].Cells[c].Value;
                            if (c != dgvExport.Columns.Count - 1)
                            {
                                //A comma is added as a text delimiter in order
                                //to separate each field in the text file.
                                //You can choose another character as a delimiter.
                                sLine = sLine + ",";
                            }
                        }
                        //The exported text is written to the text file, one line at a time.
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

                //This line of code creates a text file for the data export.
                StreamWriter file = new System.IO.StreamWriter(txtCaminho.Text.ToString().Replace("\\", "\\\\") +
                    "\\\\export_vendedores.txt");
                try
                {
                    string sLine = "";

                    //This for loop loops through each row in the table
                    for (int r = 0; r <= dgvExport.Rows.Count - 1; r++)
                    {
                        //This for loop loops through each column, and the row number
                        //is passed from the for loop above.
                        for (int c = 0; c <= dgvExport.Columns.Count - 1; c++)
                        {
                            sLine = sLine + dgvExport.Rows[r].Cells[c].Value;
                            if (c != dgvExport.Columns.Count - 1)
                            {
                                //A comma is added as a text delimiter in order
                                //to separate each field in the text file.
                                //You can choose another character as a delimiter.
                                sLine = sLine + "  ";
                            }
                        }
                        //The exported text is written to the text file, one line at a time.
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
