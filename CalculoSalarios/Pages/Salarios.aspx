<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Salarios.aspx.cs" Inherits="CalculoSalarios.Pages.Salarios" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Salários das Pessoas</title>
</head>
<body>
    <form id="form2" runat="server">
        <div>
            <h2>Salários</h2>

            <!-- Link único para Gerenciar Pessoas -->
            <asp:HyperLink ID="lnkPessoas" runat="server" NavigateUrl="PessoasCRUD.aspx" Text="Ir para cadastro de Pessoas" /><br /><br />

            <br /><br />

            <asp:Label ID="Label1" runat="server" Text="Bônus: "></asp:Label>
            <asp:TextBox ID="txtBonus" runat="server" Width="100px"></asp:TextBox>
            <asp:Button ID="btnCalcular" runat="server" Text="Calcular/Recalcular" OnClick="btnCalcular_Click" />
            <br /><br />

            <asp:GridView ID="gridSalarios" runat="server" AutoGenerateColumns="True" PageSize="300" ></asp:GridView>

            <asp:Repeater ID="rptPaginas" runat="server" OnItemCommand="rptPaginas_ItemCommand">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkPagina" runat="server" 
                        CommandName="Pagina" 
                        CommandArgument='<%# Container.DataItem %>' 
                        Text='<%# Container.DataItem %>' />
                </ItemTemplate>
            </asp:Repeater>

            <br />
            <asp:Label ID="lblPaginaAtual" runat="server" Text="Página 1"></asp:Label>
            <br /><br />
            <asp:Button ID="btnVoltarPagina" runat="server" Text="⬅️ Voltar Página" OnClick="btnVoltarPagina_Click" />
            <asp:Button ID="btnProximaPagina" runat="server" Text="Próxima Página ➡️" OnClick="btnProximaPagina_Click" />
        </div>
    </form>
</body>
</html>
