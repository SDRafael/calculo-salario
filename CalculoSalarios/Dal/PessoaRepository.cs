using CalculoSalarios.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
                string sql = @"
                    INSERT INTO pessoa 
                    (nome, cidade, email, cep, endereco, pais, usuario, telefone, data_nascimento, cargo_id)
                    VALUES
                    (@nome, @cidade, @email, @cep, @endereco, @pais, @usuario, @telefone, @data_nascimento, @cargo_id)";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@nome", pessoa.Nome);
                    cmd.Parameters.AddWithValue("@cidade", pessoa.Cidade);
                    cmd.Parameters.AddWithValue("@email", pessoa.Email);
                    cmd.Parameters.AddWithValue("@cep", pessoa.Cep);
                    cmd.Parameters.AddWithValue("@endereco", pessoa.Endereco);
                    cmd.Parameters.AddWithValue("@pais", pessoa.Pais);
                    cmd.Parameters.AddWithValue("@usuario", pessoa.Usuario);
                    cmd.Parameters.AddWithValue("@telefone", pessoa.Telefone);
                    cmd.Parameters.AddWithValue("@data_nascimento", pessoa.DataNascimento);
                    cmd.Parameters.AddWithValue("@cargo_id", pessoa.CargoId);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
