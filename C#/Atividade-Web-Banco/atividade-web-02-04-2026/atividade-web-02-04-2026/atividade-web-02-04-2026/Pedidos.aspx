<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pedidos.aspx.cs" Inherits="AppPedidos.Pedidos" %>
<!DOCTYPE html>
<html>
<head runat="server"><title>Pedidos</title></head>
<body>
  <form id="form1" runat="server">
    <h2>Pedidos</h2>
    <asp:Button ID="btnNovo" runat="server" Text="Inserir Novo Pedido" OnClick="btnNovo_Click" />
    &nbsp;
    <asp:Button ID="btnCidades" runat="server" Text="Cidades" OnClick="btnCidades_Click" />
    <asp:Button ID="btnClientes" runat="server" Text="Clientes" OnClick="btnClientes_Click" />
    <asp:Button ID="btnProdutos" runat="server" Text="Produtos" OnClick="btnProdutos_Click" />
    <br /><br />
    <asp:GridView ID="gvPedidos" runat="server" AutoGenerateColumns="False"
      DataKeyNames="id_pedido" OnRowEditing="gvPedidos_RowEditing"
      OnRowDeleting="gvPedidos_RowDeleting" OnRowUpdating="gvPedidos_RowUpdating"
      OnRowCancelingEdit="gvPedidos_RowCancelingEdit">
      <Columns>
        <asp:BoundField DataField="id_pedido" HeaderText="ID" ReadOnly="True" />
        <asp:BoundField DataField="cliente" HeaderText="Cliente" ReadOnly="True" />
        <asp:BoundField DataField="produto" HeaderText="Produto" ReadOnly="True" />
        <asp:BoundField DataField="quantidade" HeaderText="Qtd" />
        <asp:BoundField DataField="data_pedido" HeaderText="Data" DataFormatString="{0:dd/MM/yyyy}" />
        <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
      </Columns>
    </asp:GridView>
    <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
  </form>
</body>
</html>