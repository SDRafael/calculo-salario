using CalculoSalarios.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;


namespace CalculoSalarios.DAL
{
    public class SalarioRepository
    {
        private readonly string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

        public int ObterTotalRegistros()
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM pessoa_salario WHERE ativo = 1", conn))
                {
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }    
        public List<PessoaSalario> ObterSalarios(int offset, int limit)
        {
            List<PessoaSalario> salarios = new List<PessoaSalario>();

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT nome, email, salario FROM vw_pessoa_salario_ativo LIMIT @limit OFFSET @offset";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@limit", limit);
                    cmd.Parameters.AddWithValue("@offset", offset);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            salarios.Add(new PessoaSalario
                            {
                                Nome = reader.GetString("nome"),
                                Email = reader.GetString("email"),
                                Salario = reader.GetDecimal("salario")
                            });
                        }
                    }
                }
            }

            return salarios;
        }

        public void CalcularSalarios(decimal bonus)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("calcular_salarios", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_bonus", bonus);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        
    }
}
