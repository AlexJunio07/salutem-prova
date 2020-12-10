using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Salutem.Util
{
    static class Funcoes
    {
        public static void HabilitarCampos(Control formulario, bool p)
        {
            foreach (Control ctl in formulario.Controls)
            {
                if (ctl is TextBox)
                {
                    ((TextBox)ctl).Enabled = p;
                }
                else if (ctl is MaskedTextBox)
                {
                    ((MaskedTextBox)ctl).Enabled = p;
                }
                else if (ctl is ComboBox)
                {
                    ((ComboBox)ctl).Enabled = p;
                }
                else if (ctl.Controls.Count > 0)
                {
                    HabilitarCampos(ctl, p);
                }


            }

        }

        public static void Limpar(Control formulario)
        {
            foreach (Control ctl in formulario.Controls)
            {
                if (ctl is TextBox)
                {
                    ((TextBox)ctl).Text = "";
                }
                else if (ctl is MaskedTextBox)
                {
                    ((MaskedTextBox)ctl).Text = "";
                }
                else if (ctl is ComboBox)
                {
                    ((ComboBox)ctl).SelectedIndex = -1;
                }
                else if (ctl.Controls.Count > 0)
                {
                    Limpar(ctl);
                }
            }
        }

        public static void HabilitarBotoes(Control formulario, String sit)
        {
            foreach (Control ctl in formulario.Controls)
            {
                if (ctl is Button)
                {
                    if (sit == "Salvar")
                    {
                        if (((Button)ctl).Name == "btnNovo")
                        {
                            ((Button)ctl).Enabled = false;
                        }
                        else if (((Button)ctl).Name == "btnEditar")
                        {
                            ((Button)ctl).Enabled = false;
                        }
                        else if (((Button)ctl).Name == "btnSalvar")
                        {
                            ((Button)ctl).Enabled = true;
                        }
                        else if (((Button)ctl).Name == "btnExcluir")
                        {
                            ((Button)ctl).Enabled = false;
                        }
                        else if (((Button)ctl).Name == "btnCancelar")
                        {
                            ((Button)ctl).Enabled = true;
                        }
                        else if (((Button)ctl).Name == "btnSair")
                        {
                            ((Button)ctl).Enabled = false;
                        }
                    }
                    else if (sit == "Editar")
                    {
                        if (((Button)ctl).Name == "btnNovo")
                        {
                            ((Button)ctl).Enabled = false;
                        }
                        else if (((Button)ctl).Name == "btnEditar")
                        {
                            ((Button)ctl).Enabled = true;
                        }
                        else if (((Button)ctl).Name == "btnSalvar")
                        {
                            ((Button)ctl).Enabled = false;
                        }
                        else if (((Button)ctl).Name == "btnExcluir")
                        {
                            ((Button)ctl).Enabled = true;
                        }
                        else if (((Button)ctl).Name == "btnCancelar")
                        {
                            ((Button)ctl).Enabled = true;
                        }
                        else if (((Button)ctl).Name == "btnSair")
                        {
                            ((Button)ctl).Enabled = false;
                        }
                    }
                    else if (sit == "Novo")
                    {
                        if (((Button)ctl).Name == "btnNovo")
                        {
                            ((Button)ctl).Enabled = true;
                        }
                        else if (((Button)ctl).Name == "btnEditar")
                        {
                            ((Button)ctl).Enabled = false;
                        }
                        else if (((Button)ctl).Name == "btnSalvar")
                        {
                            ((Button)ctl).Enabled = false;
                        }
                        else if (((Button)ctl).Name == "btnExcluir")
                        {
                            ((Button)ctl).Enabled = false;
                        }
                        else if (((Button)ctl).Name == "btnCancelar")
                        {
                            ((Button)ctl).Enabled = false;
                        }
                        else if (((Button)ctl).Name == "btnSair")
                        {
                            ((Button)ctl).Enabled = true;
                        }
                    }
                }
                else if (ctl.Controls.Count > 0)
                {
                    HabilitarBotoes(ctl, sit);
                }

            }
        }

        public static void DigitarNumeros(KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
