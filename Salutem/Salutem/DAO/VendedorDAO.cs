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
    class VendedorDAO
    {
        string conStr = ConfigurationManager.ConnectionStrings["conMySql"].ConnectionString;

        public bool Inserir(Vendedor vendedor)
        {
            string sql = "INSERT INTO TB_VENDEDORES (CPF_VENDEDOR, NOME_VENDEDOR, LATITUDE_VENDEDOR, LONGITUDE_VENDEDOR)";
            sql = sql + " VALUES (@cpf, @nome, @latitude, @longitude)";

            using (MySqlConnection conn = new MySqlConnection(conStr))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@cpf", vendedor.cpf);
                    cmd.Parameters.AddWithValue("@nome", vendedor.nome);
                    cmd.Parameters.AddWithValue("@latitude", vendedor.latitude);
                    cmd.Parameters.AddWithValue("@longitude", vendedor.longitude);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Vendedor Cadastrado com sucesso!", "Vendedor", 0, MessageBoxIcon.Exclamation);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao salvar o vendedor: " + ex.Message);
                    return false;
                }
            }

        }

        public bool Alterar(Vendedor vendedor)
        {
            string sql = "UPDATE TB_VENDEDORES SET CPF_VENDEDOR = @cpf, NOME_VENDEDOR = @nome, LATITUDE_VENDEDOR = @latitude, LONGITUDE_VENDEDOR = @longitude ";

            sql = sql + "WHERE COD_VENDEDOR = @cod_vendedor";

            using (MySqlConnection conn = new MySqlConnection(conStr))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@cod_vendedor", vendedor.cod_vendedor);
                    cmd.Parameters.AddWithValue("@cpf", vendedor.cpf);
                    cmd.Parameters.AddWithValue("@nome", vendedor.nome);
                    cmd.Parameters.AddWithValue("@latitude", vendedor.latitude);
                    cmd.Parameters.AddWithValue("@longitude", vendedor.longitude);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Vendedor Alterado com sucesso!", "Vendedor", 0, MessageBoxIcon.Exclamation);
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

        public bool Excluir(int cod_vendedor)
        {
            string sql = "DELETE FROM TB_VENDEDORES WHERE COD_VENDEDOR = @cod_vendedor";

            using (MySqlConnection conn = new MySqlConnection(conStr))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@cod_vendedor", cod_vendedor);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Vendedor excluido com sucesso!", "Exclusão", 0, MessageBoxIcon.Exclamation);
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

        public Vendedor ValidarCPF(string cpf_vendedor)
        {
            Vendedor vendedor = new Vendedor();
            string sql = "SELECT COD_VENDEDOR, CPF_VENDEDOR FROM TB_VENDEDORES WHERE CPF_VENDEDOR = @CPF_VENDEDOR";

            using (MySqlConnection conn = new MySqlConnection(conStr))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@CPF_VENDEDOR", cpf_vendedor);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    vendedor.cod_vendedor = int.Parse(reader["COD_VENDEDOR"].ToString());
                    vendedor.cpf = reader["CPF_VENDEDOR"].ToString();
                }
                conn.Close();
            }
            return vendedor;
        }

        public Vendedor PesquisarCodVendedor(int cod_vendedor)
        {
            Vendedor vendedor = new Vendedor();
            string sql = "SELECT COD_VENDEDOR, CPF_VENDEDOR, NOME_VENDEDOR, LATITUDE_VENDEDOR, LONGITUDE_VENDEDOR FROM TB_VENDEDORES WHERE COD_VENDEDOR = @COD_VENDEDOR";
            using (MySqlConnection conn = new MySqlConnection(conStr))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@COD_VENDEDOR", cod_vendedor);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    vendedor.cod_vendedor = int.Parse(reader["COD_VENDEDOR"].ToString());
                    vendedor.cpf = reader["CPF_VENDEDOR"].ToString();
                    vendedor.nome = reader["NOME_VENDEDOR"].ToString();
                    vendedor.latitude = reader["LATITUDE_VENDEDOR"].ToString();
                    vendedor.longitude = reader["LONGITUDE_VENDEDOR"].ToString();
                }
                conn.Close();
            }
            return vendedor;
        }

        public List<Vendedor> BuscarCodVendedor(int cod_vendedor, string ordem)
        {
            List<Vendedor> lista = new List<Vendedor>();

            string sql = string.Empty;

            if (cod_vendedor == 0)
            {
                sql = "SELECT COD_VENDEDOR, CPF_VENDEDOR, NOME_VENDEDOR, LATITUDE_VENDEDOR, LONGITUDE_VENDEDOR " +
                    "FROM TB_VENDEDORES ORDER BY COD_VENDEDOR " + ordem;
            }

            else if (ordem == "ASC")
            {
                sql = "SELECT COD_VENDEDOR, CPF_VENDEDOR, NOME_VENDEDOR, LATITUDE_VENDEDOR, LONGITUDE_VENDEDOR " +
                    "FROM TB_VENDEDORES WHERE COD_VENDEDOR = @COD_VENDEDOR ORDER BY COD_VENDEDOR " + ordem;
            }
            else
            {
                sql = "SELECT COD_VENDEDOR, CPF_VENDEDOR, NOME_VENDEDOR, LATITUDE_VENDEDOR, LONGITUDE_VENDEDOR " +
                    "FROM TB_VENDEDORES WHERE COD_VENDEDOR = @COD_VENDEDOR ORDER BY COD_VENDEDOR " + ordem;
            }


            using (MySqlConnection conn = new MySqlConnection(conStr))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@COD_VENDEDOR", cod_vendedor);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Vendedor vendedor = new Vendedor();
                    vendedor.cod_vendedor = int.Parse(reader["COD_VENDEDOR"].ToString());
                    vendedor.cpf = reader["CPF_VENDEDOR"].ToString();
                    vendedor.nome = reader["NOME_VENDEDOR"].ToString();
                    vendedor.latitude = reader["LATITUDE_VENDEDOR"].ToString();
                    vendedor.longitude = reader["LONGITUDE_VENDEDOR"].ToString();

                    lista.Add(vendedor);
                }
                conn.Close();
            }
            return lista;
        }

        public List<Vendedor> BuscarNome(string nome_vendedor, string ordem)
        {
            List<Vendedor> lista = new List<Vendedor>();

            string sql = string.Empty;

            if (ordem == "ASC")
            {
                sql = "SELECT COD_VENDEDOR, CPF_VENDEDOR, NOME_VENDEDOR, LATITUDE_VENDEDOR, LONGITUDE_VENDEDOR ";
                sql = sql + "FROM TB_VENDEDORES WHERE NOME_VENDEDOR LIKE @nome ORDER BY NOME_VENDEDOR ASC";
            }
            else
            {
                sql = "SELECT COD_VENDEDOR, CPF_VENDEDOR, NOME_VENDEDOR, LATITUDE_VENDEDOR, LONGITUDE_VENDEDOR ";
                sql = sql + "FROM TB_VENDEDORES WHERE NOME_VENDEDOR LIKE @nome ORDER BY NOME_VENDEDOR DESC";
            }

            using (MySqlConnection conn = new MySqlConnection(conStr))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@nome", '%' + nome_vendedor + '%');
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Vendedor vendedor = new Vendedor();
                    vendedor.cod_vendedor = int.Parse(reader["COD_VENDEDOR"].ToString());
                    vendedor.cpf = reader["CPF_VENDEDOR"].ToString();
                    vendedor.nome = reader["NOME_VENDEDOR"].ToString();
                    vendedor.latitude = reader["LATITUDE_VENDEDOR"].ToString();
                    vendedor.longitude = reader["LONGITUDE_VENDEDOR"].ToString();

                    lista.Add(vendedor);
                }
                conn.Close();
            }
            return lista;
        }
    }
}
