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

        //public int ObterTotalRegistros()
        //{
        //    using (MySqlConnection conn = new MySqlConnection(connStr))
        //    {
        //        conn.Open();
        //        using (MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM pessoa_salario WHERE ativo = 1", conn))
        //        {
        //            return Convert.ToInt32(cmd.ExecuteScalar());
        //        }
        //    }
        //}
        public int ObterTotalRegistros(int cargoId = 0)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM vw_pessoa_salario_ativo";
                if (cargoId > 0)
                {
                    query += " WHERE cargo_id = @cargoId";
                }

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    if (cargoId > 0)
                        cmd.Parameters.AddWithValue("@cargoId", cargoId);

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }
        //public List<PessoaSalario> ObterSalarios(int offset, int limit)
        //{
        //    List<PessoaSalario> salarios = new List<PessoaSalario>();
        //
        //    using (MySqlConnection conn = new MySqlConnection(connStr))
        //    {
        //        conn.Open();
        //        string query = "SELECT nome, email, salario FROM vw_pessoa_salario_ativo LIMIT @limit OFFSET @offset";
        //
        //        using (MySqlCommand cmd = new MySqlCommand(query, conn))
        //        {
        //            cmd.Parameters.AddWithValue("@limit", limit);
        //            cmd.Parameters.AddWithValue("@offset", offset);
        //
        //            using (var reader = cmd.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    salarios.Add(new PessoaSalario
        //                    {
        //                        Nome = reader.GetString("nome"),
        //                        Email = reader.GetString("email"),
        //                        Salario = reader.GetDecimal("salario")
        //                    });
        //                }
        //            }
        //        }
        //    }
        //
        //    return salarios;
        //}
        public List<PessoaSalario> ObterSalarios(int offset, int limit, int cargoId = 0)
        {
            List<PessoaSalario> salarios = new List<PessoaSalario>();

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT nome, email, cargo, salario FROM vw_pessoa_salario_ativo";
                if (cargoId > 0)
                {
                    query += " WHERE cargo_id = @cargoId";
                }

                query += " LIMIT @limit OFFSET @offset";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    if (cargoId > 0)
                    {
                        cmd.Parameters.AddWithValue("@cargoId", cargoId);
                    }
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
                                Cargo = reader.GetString("cargo"),
                                Salario = reader.GetDecimal("salario")
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
                string query = "SELECT id, nome FROM cargo ORDER BY nome";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cargos.Add(new Cargo
                        {
                            Id = reader.GetInt32("id"),
                            Nome = reader.GetString("nome")
                        });
                    }
                }
            }

            return cargos;
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
