<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProdutoForm.aspx.cs" Inherits="AppPedidos.ProdutoForm" %>
<!DOCTYPE html>
<html>
<head runat="server"><title>Novo Produto</title></head>
<body>
  <form id="form1" runat="server">
    <h2>Novo Produto</h2>
    Nome: <asp:TextBox ID="txtNome" runat="server" /><br /><br />
    Preço: <asp:TextBox ID="txtPreco" runat="server" /><br /><br />
    <asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click" />
    <asp:Button ID="btnVoltar" runat="server" Text="Voltar" OnClick="btnVoltar_Click" />
  </form>
</body>
</html>