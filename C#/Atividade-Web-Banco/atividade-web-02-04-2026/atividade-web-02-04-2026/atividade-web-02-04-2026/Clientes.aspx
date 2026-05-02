<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="AppPedidos.Clientes" %>
<!DOCTYPE html>
<html>
<head runat="server"><title>Clientes</title></head>
<body>
  <form id="form1" runat="server">
    <h2>Clientes</h2>
    <asp:Button ID="btnNovo" runat="server" Text="Inserir Novo Cliente" OnClick="btnNovo_Click" />
    &nbsp;
    <asp:Button ID="btnCidades" runat="server" Text="Cidades" OnClick="btnCidades_Click" />
    <asp:Button ID="btnProdutos" runat="server" Text="Produtos" OnClick="btnProdutos_Click" />
    <asp:Button ID="btnPedidos" runat="server" Text="Pedidos" OnClick="btnPedidos_Click" />
    <br /><br />
    <asp:GridView ID="gvClientes" runat="server" AutoGenerateColumns="False"
      DataKeyNames="id_cliente" OnRowEditing="gvClientes_RowEditing"
      OnRowDeleting="gvClientes_RowDeleting" OnRowUpdating="gvClientes_RowUpdating"
      OnRowCancelingEdit="gvClientes_RowCancelingEdit">
      <Columns>
        <asp:BoundField DataField="id_cliente" HeaderText="ID" ReadOnly="True" />
        <asp:BoundField DataField="nome" HeaderText="Nome" />
        <asp:BoundField DataField="email" HeaderText="Email" />
        <asp:BoundField DataField="cidade" HeaderText="Cidade" ReadOnly="True" />
        <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
      </Columns>
    </asp:GridView>
    <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
  </form>
</body>
</html>