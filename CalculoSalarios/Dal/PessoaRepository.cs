using CalculoSalarios.Models;
using System;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace CalculoSalarios.DAL
{
    public class PessoaRepository
    {
        private readonly string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

        public void Inserir(Pessoa pessoa)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("inserir_pessoa", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@p_nome", pessoa.Nome);
                    cmd.Parameters.AddWithValue("@p_cidade", pessoa.Cidade);
                    cmd.Parameters.AddWithValue("@p_email", pessoa.Email);
                    cmd.Parameters.AddWithValue("@p_cep", pessoa.Cep);
                    cmd.Parameters.AddWithValue("@p_endereco", pessoa.Endereco);
                    cmd.Parameters.AddWithValue("@p_pais", pessoa.Pais);
                    cmd.Parameters.AddWithValue("@p_usuario", pessoa.Usuario);
                    cmd.Parameters.AddWithValue("@p_telefone", pessoa.Telefone);
                    cmd.Parameters.AddWithValue("@p_data_nascimento", pessoa.DataNascimento);
                    cmd.Parameters.AddWithValue("@p_cargo_id", pessoa.CargoId);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void ExcluirPessoaPorEmail(string email)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                string query = "UPDATE pessoa SET ativo = 0 WHERE email = @email AND ativo = 1"; // Apenas desativa se a pessoa for ativa
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                    {
                        throw new Exception("Pessoa não encontrada ou já está inativa.");
                    }
                }
            }

        }
    }
}
