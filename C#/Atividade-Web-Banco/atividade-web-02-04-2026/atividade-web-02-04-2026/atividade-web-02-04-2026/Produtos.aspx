<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Produtos.aspx.cs" Inherits="AppPedidos.Produtos" %>
<!DOCTYPE html>
<html>
<head runat="server"><title>Produtos</title></head>
<body>
  <form id="form1" runat="server">
    <h2>Produtos</h2>
    <asp:Button ID="btnNovo" runat="server" Text="Inserir Novo Produto" OnClick="btnNovo_Click" />
    &nbsp;
    <asp:Button ID="btnCidades" runat="server" Text="Cidades" OnClick="btnCidades_Click" />
    <asp:Button ID="btnClientes" runat="server" Text="Clientes" OnClick="btnClientes_Click" />
    <asp:Button ID="btnPedidos" runat="server" Text="Pedidos" OnClick="btnPedidos_Click" />
    <br /><br />
    <asp:GridView ID="gvProdutos" runat="server" AutoGenerateColumns="False"
      DataKeyNames="id_produto" OnRowEditing="gvProdutos_RowEditing"
      OnRowDeleting="gvProdutos_RowDeleting" OnRowUpdating="gvProdutos_RowUpdating"
      OnRowCancelingEdit="gvProdutos_RowCancelingEdit">
      <Columns>
        <asp:BoundField DataField="id_produto" HeaderText="ID" ReadOnly="True" />
        <asp:BoundField DataField="nome" HeaderText="Nome" />
        <asp:BoundField DataField="preco" HeaderText="Preço" DataFormatString="{0:C}" />
        <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
      </Columns>
    </asp:GridView>
    <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
  </form>
</body>
</html>