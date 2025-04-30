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

        //protected void btnAdicionar_Click(object sender, EventArgs e)
        //{
        //    var pessoa = new Pessoa
        //    {
        //        Nome = txtNome.Text.Trim(),
        //        Cidade = txtCidade.Text.Trim(),
        //        Email = txtEmail.Text.Trim(),
        //        Cep = txtCep.Text.Trim(),
        //        Endereco = txtEndereco.Text.Trim(),
        //        Pais = txtPais.Text.Trim(),
        //        Usuario = txtUsuario.Text.Trim(),
        //        Telefone = txtTelefone.Text.Trim(),
        //        DataNascimento = DateTime.Parse(txtDataNascimento.Text),
        //        CargoId = int.Parse(ddlCargo.SelectedValue)
        //    };
        //
        //    pessoaService.AdicionarPessoa(pessoa);
        //    lblMensagem.Text = "Pessoa adicionada com sucesso!";
        //    LimparCampos();
        //}
        protected void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validação de campos obrigatórios
                if (string.IsNullOrWhiteSpace(txtNome.Text))
                    throw new Exception("O campo Nome é obrigatório.");

                if (string.IsNullOrWhiteSpace(txtCidade.Text))
                    throw new Exception("O campo Cidade é obrigatório.");

                if (string.IsNullOrWhiteSpace(txtEmail.Text))
                    throw new Exception("O campo Email é obrigatório.");

                if (string.IsNullOrWhiteSpace(txtCep.Text))
                    throw new Exception("O campo CEP é obrigatório.");

                if (string.IsNullOrWhiteSpace(txtEndereco.Text))
                    throw new Exception("O campo Endereço é obrigatório.");

                if (string.IsNullOrWhiteSpace(txtPais.Text))
                    throw new Exception("O campo País é obrigatório.");

                if (string.IsNullOrWhiteSpace(txtUsuario.Text))
                    throw new Exception("O campo Usuário é obrigatório.");

                if (string.IsNullOrWhiteSpace(txtTelefone.Text))
                    throw new Exception("O campo Telefone é obrigatório.");

                if (string.IsNullOrWhiteSpace(txtDataNascimento.Text))
                    throw new Exception("O campo Data de Nascimento é obrigatório.");

                if (!DateTime.TryParse(txtDataNascimento.Text, out DateTime dataNascimento))
                    throw new Exception("A Data de Nascimento está em formato inválido.");

                if (string.IsNullOrEmpty(ddlCargo.SelectedValue) || ddlCargo.SelectedValue == "0")
                    throw new Exception("Selecione um cargo válido.");

                // Se tudo estiver ok, cria a nova pessoa
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
                    DataNascimento = dataNascimento,
                    CargoId = int.Parse(ddlCargo.SelectedValue)
                };

                pessoaService.AdicionarPessoa(pessoa);
                lblMensagem.ForeColor = System.Drawing.Color.Green;
                lblMensagem.Text = "Pessoa adicionada com sucesso!";
                LimparCampos();
            }
            catch (Exception ex)
            {
                lblMensagem.ForeColor = System.Drawing.Color.Red;
                lblMensagem.Text = "Erro: " + ex.Message;
            }
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
