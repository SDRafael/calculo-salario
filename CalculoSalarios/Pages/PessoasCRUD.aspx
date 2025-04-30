<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PessoasCRUD.aspx.cs" Inherits="CalculoSalarios.Pages.PessoasCRUD" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Adicionar Pessoa</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Adicionar Nova Pessoa</h2>
            <asp:HyperLink ID="lnkPessoas" runat="server" NavigateUrl="Salarios.aspx" Text="Salarios" /><br /><br />

            <asp:Label Text="Nome:" runat="server" /><br />
            <asp:TextBox ID="txtNome" runat="server" /><br /><br />

            <asp:Label Text="Cidade:" runat="server" /><br />
            <asp:TextBox ID="txtCidade" runat="server" /><br /><br />

            <asp:Label Text="Email:" runat="server" /><br />
            <asp:TextBox ID="txtEmail" runat="server" /><br /><br />

            <asp:Label Text="CEP:" runat="server" /><br />
            <asp:TextBox ID="txtCep" runat="server" /><br /><br />

            <asp:Label Text="Endereço:" runat="server" /><br />
            <asp:TextBox ID="txtEndereco" runat="server" /><br /><br />

            <asp:Label Text="País:" runat="server" /><br />
            <asp:TextBox ID="txtPais" runat="server" /><br /><br />

            <asp:Label Text="Usuário:" runat="server" /><br />
            <asp:TextBox ID="txtUsuario" runat="server" /><br /><br />

            <asp:Label Text="Telefone:" runat="server" /><br />
            <asp:TextBox ID="txtTelefone" runat="server" /><br /><br />

            <asp:Label Text="Data de Nascimento:" runat="server" /><br />
            <asp:TextBox ID="txtDataNascimento" runat="server" TextMode="Date" /><br /><br />

            <asp:Label Text="Cargo:" runat="server" /><br />
            <asp:DropDownList ID="ddlCargo" runat="server" /><br /><br />

            <asp:Button ID="btnAdicionar" runat="server" Text="Adicionar" OnClick="btnAdicionar_Click" /><br /><br />

            <asp:Label ID="lblMensagem" runat="server" ForeColor="Green" />
        </div>
        <div>
            
            <h3>Excluir Pessoa</h3>
            <label for="txtEmailExcluir">Email da Pessoa:</label>
            <asp:TextBox ID="txtEmailExcluir" runat="server" CssClass="form-control" />

            <asp:Button ID="btnExcluir" runat="server" Text="Excluir Pessoa" OnClick="btnExcluir_Click" CssClass="btn btn-danger" />
            <asp:Label ID="lblMensagemExcluir" runat="server" CssClass="text-danger" />

        </div>
    </form>
</body>
</html>
