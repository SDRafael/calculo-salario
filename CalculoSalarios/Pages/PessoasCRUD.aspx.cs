using System;
using CalculoSalarios.BLL;
using CalculoSalarios.Models;

namespace CalculoSalarios.Pages
{
    public partial class PessoasCRUD : System.Web.UI.Page
    {
        private readonly PessoaService pessoaService = new PessoaService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarCargos();
            }
        }

        private void CarregarCargos()
        {
            var cargos = pessoaService.ObterCargosAtivos();
            ddlCargo.DataSource = cargos;
            ddlCargo.DataTextField = "Nome";
            ddlCargo.DataValueField = "Id";
            ddlCargo.DataBind();
        }

        protected void btnAdicionar_Click(object sender, EventArgs e)
        {
            var pessoa = new Pessoa
            {
                Nome = txtNome.Text.Trim(),
                Cidade = txtCidade.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Cep = txtCep.Text.Trim(),
                Endereco = txtEndereco.Text.Trim(),
                Pais = txtPais.Text.Trim(),
                Usuario = txtUsuario.Text.Trim(),
                Telefone = txtTelefone.Text.Trim(),
                DataNascimento = DateTime.Parse(txtDataNascimento.Text),
                CargoId = int.Parse(ddlCargo.SelectedValue)
            };

            pessoaService.AdicionarPessoa(pessoa);
            lblMensagem.Text = "Pessoa adicionada com sucesso!";
            LimparCampos();
        }
        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            string email = txtEmailExcluir.Text.Trim();

            try
            {
                pessoaService.ExcluirPessoaPorEmail(email);
                lblMensagemExcluir.Text = "Pessoa excluída com sucesso.";
                lblMensagemExcluir.ForeColor = System.Drawing.Color.Green;
            }
            catch (Exception ex)
            {
                lblMensagemExcluir.Text = ex.Message;
                lblMensagemExcluir.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void LimparCampos()
        {
            txtNome.Text = "";
            txtCidade.Text = "";
            txtEmail.Text = "";
            txtCep.Text = "";
            txtEndereco.Text = "";
            txtPais.Text = "";
            txtUsuario.Text = "";
            txtTelefone.Text = "";
            txtDataNascimento.Text = "";
            ddlCargo.SelectedIndex = 0;
        }
    }
}
