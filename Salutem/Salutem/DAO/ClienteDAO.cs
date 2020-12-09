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

        public bool Alterar(Cliente cliente)
        {
            string sql = "UPDATE TB_CLIENTES SET CNPJ_CLIENTE = @cnpj, RAZAO_SOCIAL_CLIENTE = @razao_social, LATITUDE_CLIENTE = @latitude, LONGITUDE_CLIENTE = @longitude ";

            sql = sql + "WHERE COD_CLIENTE = @cod_cliente";

            using (MySqlConnection conn = new MySqlConnection(conStr))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@cod_cliente", cliente.cod_cliente);
                    cmd.Parameters.AddWithValue("@cnpj", cliente.cnpj);
                    cmd.Parameters.AddWithValue("@razao_social", cliente.razao_social);
                    cmd.Parameters.AddWithValue("@latitude", cliente.latitude);
                    cmd.Parameters.AddWithValue("@longitude", cliente.longitude);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Cliente Alterado com sucesso!", "Cliente", 0, MessageBoxIcon.Exclamation);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao salvar registro: " + ex.Message);
                    return false;

                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public bool Excluir(int cod_cliente)
        {
            string sql = "DELETE FROM TB_CLIENTES WHERE COD_CLIENTE = @cod_cliente";

            using (MySqlConnection conn = new MySqlConnection(conStr))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@cod_cliente", cod_cliente);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Cliente excluido com sucesso!", "Exclusão", 0, MessageBoxIcon.Exclamation);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao excluir o registro: " + ex.Message);
                    return false;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public Cliente ValidarCNPJ(string cnpj_cliente)
        {
            Cliente cliente = new Cliente();
            string sql = "SELECT COD_CLIENTE, CNPJ_CLIENTE FROM TB_CLIENTES WHERE CNPJ_CLIENTE = @CNPJ_CLIENTE";

            using (MySqlConnection conn = new MySqlConnection(conStr))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@CNPJ_CLIENTE", cnpj_cliente);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cliente.cod_cliente = int.Parse(reader["COD_CLIENTE"].ToString());
                    cliente.cnpj = reader["CNPJ_CLIENTE"].ToString();
                }
                conn.Close();
            }
            return cliente;
        }

        public Cliente PesquisarCodCliente(int cod_cliente)
        {
            Cliente cliente = new Cliente();
            string sql = "SELECT COD_CLIENTE, CNPJ_CLIENTE, RAZAO_SOCIAL_CLIENTE, LATITUDE_CLIENTE, LONGITUDE_CLIENTE FROM TB_CLIENTES WHERE COD_CLIENTE = @COD_CLIENTE";
            using (MySqlConnection conn = new MySqlConnection(conStr))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@COD_CLIENTE", cod_cliente);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cliente.cod_cliente = int.Parse(reader["COD_CLIENTE"].ToString());
                    cliente.cnpj = reader["CNPJ_CLIENTE"].ToString();
                    cliente.razao_social = reader["RAZAO_SOCIAL_CLIENTE"].ToString();
                    cliente.latitude = reader["LATITUDE_CLIENTE"].ToString();
                    cliente.longitude = reader["LONGITUDE_CLIENTE"].ToString();
                }
                conn.Close();
            }
            return cliente;
        }

        public List<Cliente> BuscarCodCliente(int cod_cliente, string ordem)
        {
            List<Cliente> lista = new List<Cliente>();

            string sql = string.Empty;

            if (cod_cliente == 0)
            {
                sql = "SELECT COD_CLIENTE, CNPJ_CLIENTE, RAZAO_SOCIAL_CLIENTE, LATITUDE_CLIENTE, LONGITUDE_CLIENTE " +
                    "FROM TB_CLIENTES ORDER BY COD_CLIENTE " + ordem;
            }

            else if (ordem == "ASC")
            {
                sql = "SELECT COD_CLIENTE, CNPJ_CLIENTE, RAZAO_SOCIAL_CLIENTE, LATITUDE_CLIENTE, LONGITUDE_CLIENTE " +
                    "FROM TB_CLIENTES WHERE COD_CLIENTE = @COD_CLIENTE ORDER BY COD_CLIENTE " + ordem;
            }
            else
            {
                sql = "SELECT COD_CLIENTE, CNPJ_CLIENTE, RAZAO_SOCIAL_CLIENTE, LATITUDE_CLIENTE, LONGITUDE_CLIENTE " +
                    "FROM TB_CLIENTES WHERE COD_CLIENTE = @COD_CLIENTE ORDER BY COD_CLIENTE " + ordem;
            }


            using (MySqlConnection conn = new MySqlConnection(conStr))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@COD_CLIENTE", cod_cliente);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Cliente cliente = new Cliente();
                    cliente.cod_cliente = int.Parse(reader["COD_CLIENTE"].ToString());
                    cliente.cnpj = reader["CNPJ_CLIENTE"].ToString();
                    cliente.razao_social = reader["RAZAO_SOCIAL_CLIENTE"].ToString();
                    cliente.latitude = reader["LATITUDE_CLIENTE"].ToString();
                    cliente.longitude = reader["LONGITUDE_CLIENTE"].ToString();

                    lista.Add(cliente);
                }
                conn.Close();
            }
            return lista;
        }

        public List<Cliente> BuscarRazaoSocial(string razao_social_cliente)
        {
            List<Cliente> lista = new List<Cliente>();

            string sql = "SELECT COD_CLIENTE, CNPJ_CLIENTE, RAZAO_SOCIAL_CLIENTE, LATITUDE_CLIENTE, LONGITUDE_CLIENTE ";
            sql = sql + "FROM TB_CLIENTES WHERE RAZAO_SOCIAL_CLIENTE LIKE @razao_social ORDER BY RAZAO_SOCIAL_CLIENTE";

            using (MySqlConnection conn = new MySqlConnection(conStr))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@razao_social", '%' + razao_social_cliente + '%');
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Cliente cliente = new Cliente();
                    cliente.cod_cliente = int.Parse(reader["COD_CLIENTE"].ToString());
                    cliente.cnpj = reader["CNPJ_CLIENTE"].ToString();
                    cliente.razao_social = reader["RAZAO_SOCIAL_CLIENTE"].ToString();
                    cliente.latitude = reader["LATITUDE_CLIENTE"].ToString();
                    cliente.longitude = reader["LONGITUDE_CLIENTE"].ToString();

                    lista.Add(cliente);
                }
                conn.Close();
            }
            return lista;
        }
    }
}