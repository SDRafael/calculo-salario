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
            ddlCargo.DataValueField = "Nome";
            ddlCargo.DataBind();
        }
 
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

                if (string.IsNullOrWhiteSpace(txtLogradouro.Text))
                    throw new Exception("O campo Logradouro é obrigatório.");
                
                if (string.IsNullOrWhiteSpace(txtNumero.Text))
                    throw new Exception("O campo Numero é obrigatório.");

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

                if (string.IsNullOrWhiteSpace(ddlCargo.SelectedValue))
                    throw new Exception("Selecione um cargo válido.");
                
                if (string.IsNullOrWhiteSpace(txtCPF.Text))
                    throw new Exception("O campo CPF é obrigatório.");

                // Se tudo estiver ok, cria a nova pessoa
                var pessoa = new Pessoa
                {
                    Nome = txtNome.Text.Trim(),
                    Cidade = txtCidade.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Cep = txtCep.Text.Trim(),
                    Logradouro = txtLogradouro.Text.Trim(),
                    Numero = txtNumero.Text.Trim(),
                    Pais = txtPais.Text.Trim(),
                    Usuario = txtUsuario.Text.Trim(),
                    Telefone = txtTelefone.Text.Trim(),
                    DataNascimento = dataNascimento,
                    Cargo = ddlCargo.SelectedValue,
                    Cpf = txtCPF.Text.Trim()
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
            string matricula = txtMatriculaExcluir.Text.Trim();

            try
            {
                pessoaService.ExcluirPessoaPorEmail(matricula);
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
            txtLogradouro.Text = "";
            txtNumero.Text = "";
            txtPais.Text = "";
            txtUsuario.Text = "";
            txtTelefone.Text = "";
            txtDataNascimento.Text = "";
            txtCPF.Text = "";
        }
    }
}
