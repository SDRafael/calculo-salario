using CalculoSalarios.Models;
using System.Collections.Generic;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace CalculoSalarios.DAL
{
    public class CargoRepository
    {
        private readonly string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

        public List<Cargo> ObterCargosAtivos()
        {
            List<Cargo> cargos = new List<Cargo>();

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT nome, salario FROM cargo";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cargos.Add(new Cargo
                        {
                            Nome = reader.GetString("nome"),
                            Salario = reader.GetDecimal("salario")
                        });
                    }
                }
            }

            return cargos;
        }
    }
}
