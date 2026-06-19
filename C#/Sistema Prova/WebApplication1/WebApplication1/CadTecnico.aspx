<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaPrincipal.Master" AutoEventWireup="true" CodeBehind="CadTecnico.aspx.cs" Inherits="WebApplication1.CadTecnico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
    <h3>Cadastro de Técnico</h3>
    <div class="row g-3">
        <div class="col-md-6">
            <label class="form-label">Nome Completo</label>
            <asp:TextBox ID="txtNomeTecnico" runat="server" CssClass="form-control" placeholder="Nome do técnico"></asp:TextBox>
        </div>
        <div class="col-md-6">
            <label class="form-label">Especialidade</label>
            <asp:TextBox ID="txtEspecialidade" runat="server" CssClass="form-control" placeholder="Ex: Hardware, Redes, Software"></asp:TextBox>
        </div>
        <div class="col-md-6">
            <label class="form-label">Telefone de Contato</label>
            <asp:TextBox ID="txtTelefoneTecnico" runat="server" CssClass="form-control" placeholder="(00) 00000-0000"></asp:TextBox>
        </div>
        <div class="col-md-6">
            <label class="form-label">E-mail</label>
            <asp:TextBox ID="txtEmailTecnico" runat="server" CssClass="form-control" TextMode="Email" placeholder="tecnico@empresa.com"></asp:TextBox>
        </div>
        <div class="col-12 mt-3">
            <asp:Button ID="btnSalvarTecnico" runat="server" Text="Cadastrar Técnico" CssClass="btn btn-primary" OnClick="btnSalvarTecnico_Click" />
            <a href="index.aspx" class="btn btn-secondary">Voltar</a>
        </div>
    </div>
</div>
</asp:Content>
