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
        public int ObterTotalRegistros(string cargo = "")
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM vw_pessoa_salario_ativo";
                if (!string.IsNullOrEmpty(cargo))
                {
                    query += " WHERE cargo = @cargo";
                }

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    if (!string.IsNullOrEmpty(cargo))
                        cmd.Parameters.AddWithValue("@cargo", cargo);

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }
        
        public List<PessoaSalarioView> ObterSalarios(int offset, int limit, string cargo = "")
        {
            List<PessoaSalarioView> salarios = new List<PessoaSalarioView>();

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT matricula, nome, email, cargo, salario_base, bonus, descontos, salario_liquido FROM vw_pessoa_salario_ativo";
                if (!string.IsNullOrEmpty(cargo))
                {
                    query += " WHERE cargo = @cargo";
                }

                query += " LIMIT @limit OFFSET @offset";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    if (!string.IsNullOrEmpty(cargo))
                    {
                        cmd.Parameters.AddWithValue("@cargo", cargo);
                    }
                    cmd.Parameters.AddWithValue("@limit", limit);
                    cmd.Parameters.AddWithValue("@offset", offset);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            salarios.Add(new PessoaSalarioView
                            {
                                Matricula = reader.GetString("matricula"),
                                Nome = reader.GetString("nome"),
                                Email = reader.GetString("email"),
                                Cargo = reader.GetString("cargo"),
                                SalarioBase = reader.GetDecimal("salario_base"),
                                Bonus = reader.GetDecimal("bonus"),
                                Descontos = reader.GetDecimal("descontos"),
                                SalarioLiquido = reader.GetDecimal("salario_liquido")
                            });
                        }
                    }
                }
            }

            return salarios;
        }
        public List<Cargo> ObterTodosCargos()
        {
            var cargos = new List<Cargo>();

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT nome FROM cargo ORDER BY nome";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cargos.Add(new Cargo
                        {
                            Nome = reader.GetString("nome")
                        });
                    }
                }
            }

            return cargos;
        }


        public void CalcularSalarios(decimal bonus, decimal descontos)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("calcular_salarios", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_bonus", bonus);
                    cmd.Parameters.AddWithValue("@p_descontos", descontos);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        
    }
}
