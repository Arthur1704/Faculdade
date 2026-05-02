<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClienteForm.aspx.cs" Inherits="AppPedidos.ClienteForm" %>
<!DOCTYPE html>
<html>
<head runat="server"><title>Novo Cliente</title></head>
<body>
  <form id="form1" runat="server">
    <h2>Novo Cliente</h2>
    Nome: <asp:TextBox ID="txtNome" runat="server" /><br /><br />
    Email: <asp:TextBox ID="txtEmail" runat="server" /><br /><br />
    Cidade:
    <asp:DropDownList ID="ddlCidade" runat="server" DataTextField="nome" DataValueField="id_cidade"></asp:DropDownList>
    <br /><br />
    <asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click" />
    <asp:Button ID="btnVoltar" runat="server" Text="Voltar" OnClick="btnVoltar_Click" />
    <br />
    <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
  </form>
</body>
</html>