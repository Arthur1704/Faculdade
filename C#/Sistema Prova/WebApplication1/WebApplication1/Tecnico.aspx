<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaPrincipal.Master" AutoEventWireup="true" CodeBehind="Tecnico.aspx.cs" Inherits="WebApplication1.Tecnico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="./Tecnico.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container container-demandas">
        <div class="d-flex justify-content-between align-items-center mb-3">
            <h2>Técnicos Cadastrados</h2>
            <a href="CadTecnico.aspx" class="btn btn-primary">Novo Técnico</a>
        </div>

        <table class="table tabela-demandas">
            <thead>
                <tr>
                    <th>ID</th>
                    <th>Nome</th>
                    <th>Especialidade</th>
                    <th>Telefone</th>
                    <th>Email</th>
                    <th>Ações</th>
                </tr>
            </thead>
            <tbody>
                 <asp:Repeater ID="rptTecnico" runat="server">
                     <ItemTemplate>
                         <tr>
                             <td><%# Eval("id") %></td>
                             <td><%# Eval("nome_completo") %></td>
                             <td><%# Eval("especialidade") %></td>
                             <td><%# Eval("telefone") %></td>
                             <td><%# Eval("email") %></td>
                             <td>
                                 <a href='CadTecnico.aspx?id=<%# Eval("id") %>' class="btn-editar">Editar</a>
                                 <asp:Button ID="btnExcluir" runat="server" Text="Excluir" CssClass="btn-excluir" 
                                     CommandArgument='<%# Eval("id") %>' OnClick="btnExcluir_Click"
                                     OnClientClick="return confirm('Deseja realmente excluir este Técnico?');" />
                             </td>
                         </tr>
                     </ItemTemplate>
                 </asp:Repeater>
            </tbody>
        </table>
    </div>
</asp:Content>