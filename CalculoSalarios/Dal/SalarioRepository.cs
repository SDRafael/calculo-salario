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
                using (MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM pessoa_salario", conn))
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
                string query = $"SELECT pessoa_id, cargo_id, salario FROM pessoa_salario LIMIT {limit} OFFSET {offset}";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            salarios.Add(new PessoaSalario
                            {
                                PessoaId = reader.GetInt32("pessoa_id"),
                                CargoId = reader.GetInt32("cargo_id"),
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
                using (MySqlCommand cmd = new MySqlCommand("calcularSalarios", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_bonus", bonus);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
