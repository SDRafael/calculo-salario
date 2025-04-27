<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Salarios.aspx.cs" Inherits="CalculoSalarios.Salarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Salários das Pessoas</title>
</head>
<body>
    <form id="form2" runat="server">
        <div>
            <h2>Salários</h2>
            
            <asp:Label ID="lblBonus" runat="server" Text="Bônus: "></asp:Label>
            <asp:TextBox ID="txtBonus" runat="server" Width="100px"></asp:TextBox>
            <asp:Button ID="btnCalcular" runat="server" Text="Calcular/Recalcular" OnClick="btnCalcular_Click" />
            
            <br /><br />
            
            <asp:GridView ID="gridSalarios" runat="server" AutoGenerateColumns="True"></asp:GridView>
        </div>
    </form>
</body>
</html>
