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

                if (clientedao.Inserir(cliente) == false)
                {
                    mskCNPJ.Focus();
                    return;
                }

            }

            if (ValidacaoCNPJ.ValidaCNPJ.IsCnpj(mskCNPJ.Text))
            {
                MessageBox.Show("O número é um CNPJ Válido !");
            }
            else
            {
                MessageBox.Show("O número é um CNPJ Inválido !");
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
    }
}
