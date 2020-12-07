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
    public partial class FrmCadastroClientes : Form
    {

        string Operacao;

        public FrmCadastroClientes()
        {
            InitializeComponent();
        }

        private bool ValidarCampos()
        {
            if (mskCNPJ.Text.Trim() == string.Empty)
            {
                MessageBox.Show("O campo CNPJ é obrigatório!", "Atenção", 0, MessageBoxIcon.Warning);
                return false;
            }

            else if (txtRazaoSocial.Text.Trim() == string.Empty)
            {
                MessageBox.Show("O campo Razão Social é obrigatório!", "Atenção", 0, MessageBoxIcon.Warning);
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

        private void HabilitarBotoes(string Situacao)
        {
            if (Situacao == "Salvar")
            {
                btnNovo.Enabled = false;
                btnEditar.Enabled = false;
                btnExcluir.Enabled = false;
                btnSalvar.Enabled = true;
                btnCancelar.Enabled = true;
                btnSair.Enabled = false;
            }
            else if (Situacao == "Editar")
            {
                btnNovo.Enabled = false;
                btnEditar.Enabled = true;
                btnExcluir.Enabled = true;
                btnSalvar.Enabled = false;
                btnCancelar.Enabled = true;
                btnSair.Enabled = false;
            }

            else if (Situacao == "Novo")
            {
                btnNovo.Enabled = true;
                btnEditar.Enabled = false;
                btnExcluir.Enabled = false;
                btnSalvar.Enabled = false;
                btnCancelar.Enabled = false;
                btnSair.Enabled = true;
            }
        }

        private void BuscarRegistro()
        {
            int cod_cliente = int.Parse(txtCodCliente.Text);
            Funcoes.Limpar(this);
            ClienteDAO clientedao = new ClienteDAO();
            Cliente cliente = new Cliente();

            cliente = clientedao.PesquisarCodCliente(cod_cliente);

            if (cliente.cod_cliente > 0)
            {
                txtCodCliente.Text = cliente.cod_cliente.ToString();
                mskCNPJ.Text = cliente.cnpj;
                txtRazaoSocial.Text = cliente.razao_social;
                txtLatitude.Text = cliente.latitude;
                txtLongitude.Text = cliente.longitude;

                Funcoes.HabilitarBotoes(this, "Editar");

            }
            else
                MessageBox.Show("Código do cliente não encontrado !", "Atenção");

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

            if (ValidarCampos() == true)
            {
                Cliente cliente = new Cliente();
                cliente.cnpj = mskCNPJ.Text;
                cliente.razao_social = txtRazaoSocial.Text;
                cliente.latitude = txtLatitude.Text;
                cliente.longitude = txtLongitude.Text;

                ClienteDAO clientedao = new ClienteDAO();

                if (Operacao == "Novo")
                {
                    if (ValidacaoCNPJ.ValidaCNPJ.IsCnpj(mskCNPJ.Text))
                    {
                        if (clientedao.Inserir(cliente) == false)
                        {
                            mskCNPJ.Focus();
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("O número é um CNPJ Inválido !", "Atenção", 0, MessageBoxIcon.Warning);
                    }
                }

                else if (Operacao == "Editar")
                {
                    if (ValidacaoCNPJ.ValidaCNPJ.IsCnpj(mskCNPJ.Text))
                    {
                        cliente.cod_cliente = int.Parse(txtCodCliente.Text);
                        if (clientedao.Alterar(cliente) == false)
                        {
                            mskCNPJ.Focus();
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("O número é um CNPJ Inválido !", "Atenção", 0, MessageBoxIcon.Warning);
                    }
                }

                Funcoes.HabilitarCampos(this, false);
                Funcoes.Limpar(this);
                Funcoes.HabilitarBotoes(this, "Novo");
                txtCodCliente.Enabled = true;
                txtPesquisa.Enabled = true;
                Operacao = "";
                txtCodCliente.Focus();
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            Funcoes.HabilitarCampos(this, true);
            Funcoes.Limpar(this);
            Funcoes.HabilitarBotoes(this, "Salvar");
            txtCodCliente.Enabled = false;
            mskCNPJ.Focus();
            Operacao = "Novo";
        }

        private void txtCodCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtCodCliente.Text.Length > 0)
                {
                    BuscarRegistro();
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Funcoes.HabilitarCampos(this, true);
            Funcoes.HabilitarBotoes(this, "Salvar");
            txtCodCliente.Enabled = false;
            mskCNPJ.Focus();
            Operacao = "Editar";
        }
    }
}
