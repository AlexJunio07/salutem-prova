using MySql.Data.MySqlClient;
using Salutem.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Salutem.DAO
{
    class ClienteDAO
    {
        string conStr = ConfigurationManager.ConnectionStrings["conMySql"].ConnectionString;

        public bool Inserir(Cliente cliente)
        {
            string sql = "INSERT INTO TB_CLIENTES (CNPJ_CLIENTE, RAZAO_SOCIAL_CLIENTE, LATITUDE_CLIENTE, LONGITUDE_CLIENTE)";
            sql = sql + " VALUES (@cnpj, @razao_social, @latitude, @longitude)";

            using (MySqlConnection conn = new MySqlConnection(conStr))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@cnpj", cliente.cnpj);
                    cmd.Parameters.AddWithValue("@razao_social", cliente.razao_social);
                    cmd.Parameters.AddWithValue("@latitude", cliente.latitude);
                    cmd.Parameters.AddWithValue("@longitude", cliente.longitude);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Cliente Cadastrado com sucesso!", "Cliente", 0, MessageBoxIcon.Exclamation);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao salvar o cliente: " + ex.Message);
                    return false;
                }
            }

        }
    }
}