using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;

namespace CalculoSalarios
{
    public partial class Salarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarGrid();
            }
        }

        protected void btnCalcular_Click(object sender, EventArgs e)
        {
            decimal bonus = 0;
            decimal.TryParse(txtBonus.Text, out bonus);

            CalcularSalarios(bonus);
            CarregarGrid();
        }

        private void CalcularSalarios(decimal bonus)
        {
            // Configurando a string de conexão
            string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

            // Usando MySql.Data.MySqlClient para conexão
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

        private void CarregarGrid()
        {
            try
            {
                string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

                // Usando MySql.Data.MySqlClient para conexão
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SELECT pessoa_id, cargo_id, salario FROM pessoa_salario", conn))
                    {
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            gridSalarios.DataSource = dt;
                            gridSalarios.DataBind();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Captura de exceções genéricas para depuração
                Response.Write("Erro: " + ex.Message);
            }
        }
    }
}

