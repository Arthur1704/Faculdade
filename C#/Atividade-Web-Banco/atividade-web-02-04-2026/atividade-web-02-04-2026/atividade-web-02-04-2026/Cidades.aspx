<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cidades.aspx.cs" Inherits="AppPedidos.Cidades" %>
<!DOCTYPE html>
<html>
<head runat="server"><title>Cidades</title></head>
<body>
  <form id="form1" runat="server">
    <h2>Cidades</h2>
    <asp:Button ID="btnNovo" runat="server" Text="Inserir Nova Cidade" OnClick="btnNovo_Click" />
    &nbsp;
    <asp:Button ID="btnClientes" runat="server" Text="Clientes" OnClick="btnClientes_Click" />
    <asp:Button ID="btnProdutos" runat="server" Text="Produtos" OnClick="btnProdutos_Click" />
    <asp:Button ID="btnPedidos" runat="server" Text="Pedidos" OnClick="btnPedidos_Click" />
    <br /><br />
    <asp:GridView ID="gvCidades" runat="server" AutoGenerateColumns="False"
      DataKeyNames="id_cidade" OnRowEditing="gvCidades_RowEditing"
      OnRowDeleting="gvCidades_RowDeleting" OnRowUpdating="gvCidades_RowUpdating"
      OnRowCancelingEdit="gvCidades_RowCancelingEdit">
      <Columns>
        <asp:BoundField DataField="id_cidade" HeaderText="ID" ReadOnly="True" />
        <asp:BoundField DataField="nome" HeaderText="Nome" />
        <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
      </Columns>
    </asp:GridView>
    <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
  </form>
</body>
</html>