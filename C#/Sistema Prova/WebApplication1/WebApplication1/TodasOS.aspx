<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaPrincipal.Master" AutoEventWireup="true" CodeBehind="TodasOS.aspx.cs" Inherits="WebApplication1.TodasOS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container container-demandas">
    <h2>Demandas Técnicas</h2>
    <table class="table tabela-demandas">
        <thead>
            <tr>
                <th>#</th>
                <th>Cliente</th>
                <th>Equipamento</th>
                <th>Defeito Relatado</th>
                <th>Data Entrada</th>
                <th>Status</th>
                <th>Técnico</th>
                <th>Ações</th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="rptTodasDemandas" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("id") %></td>
                        <td><%# Eval("nome_cliente") %></td>
                        <td><%# Eval("equipamento") %></td>
                        <td><%# Eval("defeito") %></td>
                        <td><%# Eval("data_entrada", "{0:dd/MM/yyyy}") %></td>
                        <td><span class="status-badge"><%# Eval("status") %></span></td>
                        <td><%# Eval("nome_tecnico") %></td>
                        <td>                                
                            <a href='OS.aspx?id=<%# Eval("id") %>' class="btn btn-editar btn-sm">Editar</a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
</div>
</asp:Content>
