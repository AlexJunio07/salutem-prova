using Salutem.DAO;
using Salutem.Model;
using Salutem.Util;
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
    public partial class FrmCadastroVendedor : Form
    {
        public FrmCadastroVendedor()
        {
            InitializeComponent();
        }

        string Operacao;

        private bool ValidarCampos()
        {
            if (mskCPF.Text.Trim() == string.Empty)
            {
                MessageBox.Show("O campo CPF é obrigatório!", "Atenção", 0, MessageBoxIcon.Warning);
                return false;
            }

            else if (txtNome.Text.Trim() == string.Empty)
            {
                MessageBox.Show("O campo Nome é obrigatório!", "Atenção", 0, MessageBoxIcon.Warning);
                return false;
            }

            else if (txtLatitude.Text.Trim() == string.Empty)
            {
                MessageBox.Show("O campo Latitude é obrigatório!", "Atenção", 0, MessageBoxIcon.Warning);
                return false;
            }

            else if (txtLongitude.Text.Trim() == string.Empty)
            {
                MessageBox.Show("O campo Longitude é obrigatório!", "Atenção", 0, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void BuscarRegistro()
        {
            int cod_vendedor = int.Parse(txtCodVendedor.Text);
            Funcoes.Limpar(this);
            VendedorDAO vendedordao = new VendedorDAO();
            Vendedor vendedor = new Vendedor();

            vendedor = vendedordao.PesquisarCodVendedor(cod_vendedor);

            if (vendedor.cod_vendedor > 0)
            {
                txtCodVendedor.Text = vendedor.cod_vendedor.ToString();
                mskCPF.Text = vendedor.cpf;
                txtNome.Text = vendedor.nome;
                txtLatitude.Text = vendedor.latitude;
                txtLongitude.Text = vendedor.longitude;

                Funcoes.HabilitarBotoes(this, "Editar");

            }
            else
                MessageBox.Show("Código do vendedor não encontrado !", "Atenção");

        }

        private void LevarID()
        {
            if (dgvDados.RowCount > 0)
            {
                txtCodVendedor.Text = dgvDados.CurrentRow.Cells[0].Value.ToString();
                tabControl1.SelectedTab = tbpCadastro;
                txtCodVendedor.Focus();
                BuscarRegistro();
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)

        {
            if (ValidarCampos() == true)
            {
                Vendedor vendedor = new Vendedor();
                vendedor.cpf = mskCPF.Text;

                VendedorDAO vendedordao = new VendedorDAO();

                if (Operacao == "Novo")
                {
                    //Valida o CNPJ.
                    if (ValidacaoCPF.ValidaCPF.IsCpf(mskCPF.Text))
                    {
                        //Chama a classe para verificar se ja existe CNPJ cadastrado.
                        vendedor = vendedordao.ValidarCPF(this.mskCPF.Text);
                        if (vendedor.cod_vendedor > 0)
                        {
                            MessageBox.Show("Já existe um vendedor cadastrado com este numero de CPF: " + mskCPF.Text);
                        }
                        else
                        {
                            //Recebe os valores em seus atributos apos a confirmação.
                            vendedor.cpf = mskCPF.Text;
                            vendedor.nome = txtNome.Text;
                            vendedor.latitude = txtLatitude.Text;
                            vendedor.longitude = txtLongitude.Text;

                            if (vendedordao.Inserir(vendedor) == false)
                            {
                                mskCPF.Focus();
                                return;
                            }
                            else
                            {
                                Funcoes.HabilitarCampos(this, false);
                                Funcoes.Limpar(this);
                                Funcoes.HabilitarBotoes(this, "Novo");
                                txtCodVendedor.Enabled = true;
                                txtPesquisa.Enabled = true;
                                Operacao = "";
                                txtCodVendedor.Focus();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("O número é um CPF Inválido !", "Atenção", 0, MessageBoxIcon.Warning);
                    }
                }

                else if (Operacao == "Editar")
                {
                    if (ValidacaoCPF.ValidaCPF.IsCpf(mskCPF.Text))
                    {
                        //Chama a classe para verificar se ja existe CNPJ cadastrado.
                        vendedor = vendedordao.ValidarCPF(this.mskCPF.Text);
                        if (vendedor.cod_vendedor > 0 && vendedor.cod_vendedor != int.Parse(txtCodVendedor.Text))
                        {
                            MessageBox.Show("Já existe um vendedor cadastrado com este numero de CPF: " + mskCPF.Text);
                        }
                        else
                        {
                            //Recebe os valores em seus atributos apos a confirmação.
                            vendedor.cpf = mskCPF.Text;
                            vendedor.nome = txtNome.Text;
                            vendedor.latitude = txtLatitude.Text;
                            vendedor.longitude = txtLongitude.Text;

                            vendedor.cod_vendedor = int.Parse(txtCodVendedor.Text);
                            if (vendedordao.Alterar(vendedor) == false)
                            {
                                mskCPF.Focus();
                                return;
                            }
                            else
                            {
                                Funcoes.HabilitarCampos(this, false);
                                Funcoes.Limpar(this);
                                Funcoes.HabilitarBotoes(this, "Novo");
                                txtCodVendedor.Enabled = true;
                                txtPesquisa.Enabled = true;
                                Operacao = "";
                                txtCodVendedor.Focus();
                            }
                        }

                    }
                    else
                    {
                        MessageBox.Show("O número é um CPF Inválido !", "Atenção", 0, MessageBoxIcon.Warning);
                    }
                }


            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            Funcoes.HabilitarCampos(this, true);
            Funcoes.Limpar(this);
            Funcoes.HabilitarBotoes(this, "Salvar");
            txtCodVendedor.Enabled = false;
            mskCPF.Focus();
            Operacao = "Novo";
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Funcoes.HabilitarCampos(this, true);
            Funcoes.HabilitarBotoes(this, "Salvar");
            txtCodVendedor.Enabled = false;
            mskCPF.Focus();
            Operacao = "Editar";
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtNome.Text.Length > 0)
            {
                if (MessageBox.Show("Confirma a exclusão do registro ?", "Atenção !", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    VendedorDAO vendedordao = new VendedorDAO();
                    if (vendedordao.Excluir(int.Parse(txtCodVendedor.Text)) == false)
                    {
                        txtCodVendedor.Focus();
                        return;
                    }
                    else
                    {
                        Funcoes.Limpar(this);
                        Funcoes.HabilitarBotoes(this, "Novo");
                        txtCodVendedor.Focus();
                    }
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente cancelar a edição do registro ?",
                "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Funcoes.HabilitarCampos(this, false);
                Funcoes.Limpar(this);
                Funcoes.HabilitarBotoes(this, "Novo");
                txtCodVendedor.Enabled = true;
                txtPesquisa.Enabled = true;
                txtCodVendedor.Focus();
                Operacao = "";
            }
        }

        private void txtPesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtPesquisa.Text.Length > 0)
                {
                    VendedorDAO vendedordao = new VendedorDAO();
                    bindingSource1.DataSource = vendedordao.BuscarRazaoSocial(txtPesquisa.Text);

                    dgvDados.AutoGenerateColumns = false;
                    dgvDados.DataSource = bindingSource1;
                }
            }
        }

        private void dgvDados_DoubleClick(object sender, EventArgs e)
        {
            LevarID();
        }

        private void txtCodVendedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtCodVendedor.Text.Length > 0)
                {
                    BuscarRegistro();
                }
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tbpPesquisa && Operacao == "Editar")
            {
                if (MessageBox.Show("Deseja realmente cancelar a edição do registro ?",
               "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Funcoes.HabilitarCampos(this, false);
                    Funcoes.Limpar(this);
                    Funcoes.HabilitarBotoes(this, "Novo");
                    txtCodVendedor.Enabled = true;
                    txtPesquisa.Enabled = true;
                    txtCodVendedor.Focus();
                    Operacao = "";
                }
                else
                {
                    tabControl1.SelectedTab = tbpCadastro;
                }

            }
            else if (tabControl1.SelectedTab == tbpPesquisa && Operacao == "Novo")
            {
                if (MessageBox.Show("Deseja realmente cancelar a inclusão do registro ?",
               "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Funcoes.HabilitarCampos(this, false);
                    Funcoes.Limpar(this);
                    Funcoes.HabilitarBotoes(this, "Novo");
                    txtCodVendedor.Enabled = true;
                    txtPesquisa.Enabled = true;
                    txtCodVendedor.Focus();
                    Operacao = "";
                }
                else
                {
                    tabControl1.SelectedTab = tbpCadastro;
                }
            }
        }
    }
}
