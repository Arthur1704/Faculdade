<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CidadeForm.aspx.cs" Inherits="AppPedidos.CidadeForm" %>
<!DOCTYPE html>
<html>
<head runat="server"><title>Nova Cidade</title></head>
<body>
  <form id="form1" runat="server">
    <h2>Nova Cidade</h2>
    Nome:<br />
&nbsp;<asp:TextBox ID="txtNome" runat="server" /><br /><br />
    <asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click" />
      <br />
    <asp:Button ID="btnVoltar" runat="server" Text="Voltar" OnClick="btnVoltar_Click" />
    <br />
    <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
  </form>
</body>
</html>