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
            {
                CarregarCargos();
                CarregarGrid(0);
            }
        }

        protected void btnCalcular_Click(object sender, EventArgs e)
        {
            decimal bonus = 0m;

            if (!string.IsNullOrWhiteSpace(txtBonus.Text))
                decimal.TryParse(txtBonus.Text, out bonus);

            _service.CalcularSalarios(bonus);
            CarregarGrid(ObterCargoIdSelecionado());
        }

        protected void btnProximaPagina_Click(object sender, EventArgs e)
        {
            int totalPaginas = _service.ObterTotalPaginas(ObterCargoIdSelecionado());
            if (PaginaAtual < totalPaginas - 1)
            {
                PaginaAtual++;
                CarregarGrid(ObterCargoIdSelecionado());
            }
        }

        protected void btnVoltarPagina_Click(object sender, EventArgs e)
        {
            if (PaginaAtual > 0)
            {
                PaginaAtual--;
                CarregarGrid(ObterCargoIdSelecionado());
            }
        }

        private void CarregarGrid(int cargoId)
        {
            List<PessoaSalario> salarios = _service.ObterSalarios(PaginaAtual, cargoId);
            gridSalarios.DataSource = salarios;
            gridSalarios.DataBind();

            int totalPaginas = _service.ObterTotalPaginas(cargoId);
            lblPaginaAtual.Text = $"Página {PaginaAtual + 1} de {totalPaginas}";

            AtualizarPaginas(cargoId);
        }

        private void CarregarCargos()
        {
            ddlCargos.Items.Clear();
            ddlCargos.Items.Add(new System.Web.UI.WebControls.ListItem("Todos", "0"));

            var cargos = _service.ObterTodosCargos();

            foreach (var cargo in cargos)
            {
                ddlCargos.Items.Add(new System.Web.UI.WebControls.ListItem(cargo.Nome, cargo.Id.ToString()));
            }
        }

        private void AtualizarPaginas(int cargoId)
        {
            int totalPaginas = _service.ObterTotalPaginas(cargoId);
            int paginasPorBloco = 10;
            int inicioPagina = BlocoAtual * paginasPorBloco + 1;
            int fimPagina = Math.Min(inicioPagina + paginasPorBloco - 1, totalPaginas);

            var paginas = new List<string>();

            if (BlocoAtual >= 0)
            {
                paginas.Add("|<");
                paginas.Add("<<");
            }

            for (int i = inicioPagina; i <= fimPagina; i++)
            {
                paginas.Add(i.ToString());
            }

            int maxBloco = (totalPaginas - 1) / paginasPorBloco;
            if (BlocoAtual < maxBloco)
            {
                paginas.Add(">>");
                paginas.Add(">|");
            }

            rptPaginas.DataSource = paginas;
            rptPaginas.DataBind();
        }

        protected void rptPaginas_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
        {
            string comando = e.CommandArgument.ToString();
            int paginasPorBloco = 10;
            int totalPaginas = _service.ObterTotalPaginas(ObterCargoIdSelecionado());

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

            CarregarGrid(ObterCargoIdSelecionado());
        }

        protected void ddlCargos_SelectedIndexChanged(object sender, EventArgs e)
        {
            PaginaAtual = 0;
            BlocoAtual = 0;
            CarregarGrid(ObterCargoIdSelecionado());
        }

        private int ObterCargoIdSelecionado()
        {
            return int.TryParse(ddlCargos.SelectedValue, out int id) ? id : 0;
        }
    }
}
