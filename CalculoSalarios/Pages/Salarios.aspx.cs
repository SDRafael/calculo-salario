using CalculoSalarios.BLL;
using CalculoSalarios.Models;
using System;
using System.Collections.Generic;

namespace CalculoSalarios.Pages
{
    public partial class Salarios : System.Web.UI.Page
    {
        private readonly SalarioService _service = new SalarioService();
        private int PaginaAtual
        {
            get => ViewState["PaginaAtual"] != null ? (int)ViewState["PaginaAtual"] : 0;
            set => ViewState["PaginaAtual"] = value;
        }

        private int BlocoAtual
        {
            get => ViewState["BlocoAtual"] != null ? (int)ViewState["BlocoAtual"] : 0;
            set => ViewState["BlocoAtual"] = value;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                CarregarGrid();
        }

        protected void btnCalcular_Click(object sender, EventArgs e)
        {
            decimal bonus = 0m;

            if (!string.IsNullOrWhiteSpace(txtBonus.Text))
                decimal.TryParse(txtBonus.Text, out bonus);

            _service.CalcularSalarios(bonus);
            CarregarGrid();
        }

        protected void btnProximaPagina_Click(object sender, EventArgs e)
        {
            int totalPaginas = _service.ObterTotalPaginas();
            if (PaginaAtual < totalPaginas - 1)
            {
                PaginaAtual++;
                CarregarGrid();
            }
        }

        protected void btnVoltarPagina_Click(object sender, EventArgs e)
        {
            if (PaginaAtual > 0)
            {
                PaginaAtual--;
                CarregarGrid();
            }
        }

        private void CarregarGrid()
        {
            List<PessoaSalario> salarios = _service.ObterSalarios(PaginaAtual);
            gridSalarios.DataSource = salarios;
            gridSalarios.DataBind();

            int totalPaginas = _service.ObterTotalPaginas();
            lblPaginaAtual.Text = $"Página {PaginaAtual + 1} de {totalPaginas}";

            AtualizarPaginas();
        }

        private void AtualizarPaginas()
        {
            int totalPaginas = _service.ObterTotalPaginas();
            int paginasPorBloco = 10;
            int inicioPagina = BlocoAtual * paginasPorBloco + 1;
            int fimPagina = Math.Min(inicioPagina + paginasPorBloco - 1, totalPaginas);

            var paginas = new List<string>();

            // Adiciona botões especiais se necessário
            if (BlocoAtual >= 0)
            {
                paginas.Add("|<"); // Voltar para primeira
                paginas.Add("<<"); // Voltar bloco anterior
            }

            // Adiciona os números das páginas
            for (int i = inicioPagina; i <= fimPagina; i++)
            {
                paginas.Add(i.ToString());
            }

            // Adiciona botões especiais se houver mais blocos
            int maxBloco = (totalPaginas - 1) / paginasPorBloco;
            if (BlocoAtual < maxBloco)
            {
                paginas.Add(">>"); // Avançar bloco
                paginas.Add(">|"); // Ir para última página
            }

            rptPaginas.DataSource = paginas;
            rptPaginas.DataBind();
        }


        protected void rptPaginas_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
        {
            string comando = e.CommandArgument.ToString();
            int paginasPorBloco = 10;
            int totalPaginas = _service.ObterTotalPaginas();

            switch (comando)
            {
                case "|<":
                    BlocoAtual = 0;
                    PaginaAtual = 0;
                    break;
                case "<<":
                    if (BlocoAtual > 0)
                    {
                        BlocoAtual--;
                        PaginaAtual = BlocoAtual * paginasPorBloco;
                    }
                    break;
                case ">>":
                    if (BlocoAtual < (totalPaginas - 1) / paginasPorBloco)
                    {
                        BlocoAtual++;
                        PaginaAtual = BlocoAtual * paginasPorBloco;
                    }
                    break;
                case ">|":
                    BlocoAtual = (totalPaginas - 1) / paginasPorBloco;
                    PaginaAtual = totalPaginas - 1;
                    break;
                default:
                    if (int.TryParse(comando, out int pagina))
                    {
                        PaginaAtual = pagina - 1;
                    }
                    break;
            }

            CarregarGrid();
        }
    }
}
