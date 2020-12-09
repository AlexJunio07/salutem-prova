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

        public string teste;

        string conStr = ConfigurationManager.ConnectionStrings["conMySql"].ConnectionString;

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
                    else
                    {
                        bindingSource1.DataSource = clientedao.BuscarRazaoSocial(txtRazaoSocial.Text, "ASC");
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
            else
            {

                //This line of code creates a text file for the data export.
                StreamWriter file = new System.IO.StreamWriter(txtCaminho.Text.ToString().Replace("\\", "\\\\") +
                    "\\\\export_dados.txt");
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
                MessageBox.Show("Selecione o caminho do arquivo.", "Atenção", 0, MessageBoxIcon.Warning);
            }
            else
            {

                //This line of code creates a text file for the data export.
                StreamWriter file = new System.IO.StreamWriter(txtCaminho.Text.ToString().Replace("\\", "\\\\") +
                    "\\\\export_dados.csv");
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
        }

        private void rdbCodCliente_CheckedChanged(object sender, EventArgs e)
        {
            txtCodCliente.Enabled = true;
            txtRazaoSocial.Enabled = false;
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
    }
}
