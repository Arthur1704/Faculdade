<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaPrincipal.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="WebApplication1.Clientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="./Clientes.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container container-demandas">
        <h2>Clientes Cadastrados</h2>
        <div class="d-flex justify-content-end mb-3">
            <a href="CadCliente.aspx" class="btn btn-primary">Novo Cliente</a>
        </div>

        <table class="table tabela-demandas">
            <thead>
                <tr>
                    <th>ID</th>
                    <th>Nome</th>
                    <th>Documento</th>
                    <th>Telefone</th>
                    <th>Email</th>
                    <th>Ações</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptClientes" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("id") %></td>
                            <td><%# Eval("nome_completo") %></td>
                            <td><%# Eval("documento") %></td>
                            <td><%# Eval("telefone") %></td>
                            <td><%# Eval("Email") %></td>
                            <td>
                                <a href='CadCliente.aspx?id=<%# Eval("id") %>' class="btn-editar">Editar</a>
                                <asp:Button ID="btnExcluir" runat="server" Text="Excluir" CssClass="btn-excluir" 
                                    CommandArgument='<%# Eval("id") %>' OnClick="btnExcluir_Click"
                                    OnClientClick="return confirm('Deseja realmente excluir este cliente?');" />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>
</asp:Content>
