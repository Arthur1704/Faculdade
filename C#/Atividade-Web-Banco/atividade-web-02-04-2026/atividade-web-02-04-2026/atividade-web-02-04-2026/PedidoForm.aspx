<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PedidoForm.aspx.cs" Inherits="AppPedidos.PedidoForm" %>
<!DOCTYPE html>
<html>
<head runat="server"><title>Novo Pedido</title></head>
<body>
  <form id="form1" runat="server">
    <h2>Novo Pedido</h2>
    Cliente:
    <asp:DropDownList ID="ddlCliente" runat="server" DataTextField="nome" DataValueField="id_cliente"></asp:DropDownList>
    <br /><br />
    Produto:
    <asp:DropDownList ID="ddlProduto" runat="server" DataTextField="nome" DataValueField="id_produto"></asp:DropDownList>
    <br /><br />
    Quantidade: <asp:TextBox ID="txtQtd" runat="server" /><br /><br />
    Data: <asp:TextBox ID="txtData" runat="server" /><br /><br />
    <asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click" />
    <asp:Button ID="btnVoltar" runat="server" Text="Voltar" OnClick="btnVoltar_Click" />
  </form>
</body>
</html>