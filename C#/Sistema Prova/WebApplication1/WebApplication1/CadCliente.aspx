<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaPrincipal.Master" AutoEventWireup="true" CodeBehind="CadCliente.aspx.cs" Inherits="WebApplication1.CadCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
    <h3>Cadastro de Cliente</h3>
    <div class="row g-3">
        <div class="col-md-6">
            <label class="form-label">Nome Completo</label>
            <asp:TextBox ID="txtNome" runat="server" CssClass="form-control" placeholder="Nome do cliente"></asp:TextBox>
        </div>
        <div class="col-md-6">
            <label class="form-label">CPF ou CNPJ</label>
            <asp:TextBox ID="txtDocumento" runat="server" CssClass="form-control" placeholder="000.000.000-00"></asp:TextBox>
        </div>
        <div class="col-md-6">
            <label class="form-label">Telefone / WhatsApp</label>
            <asp:TextBox ID="txtTelefone" runat="server" CssClass="form-control" placeholder="(00) 00000-0000"></asp:TextBox>
        </div>
        <div class="col-md-6">
            <label class="form-label">E-mail</label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" placeholder="exemplo@email.com"></asp:TextBox>
        </div>
        <div class="col-12 mt-3">
            <asp:Button ID="btnSalvar" runat="server" Text="Cadastrar Cliente" CssClass="btn btn-primary" OnClick="btnSalvar_Click" />
            <a href="Clientes.aspx" class="btn btn-secondary">Voltar</a>
        </div>
    </div>
</div>
</asp:Content>
