<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaPrincipal.Master" AutoEventWireup="true" CodeBehind="OS.aspx.cs" Inherits="WebApplication1.OS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
    <h3>Nova Demanda Técnica</h3>
    <div class="row g-3">
        <div class="col-md-6">
            <label class="form-label">Cliente</label>
            <asp:TextBox ID="txtCliente" runat="server" CssClass="form-control" placeholder="Nome do Cliente"></asp:TextBox>
        </div>
        <div class="col-md-6">
            <label class="form-label">Equipamento</label>
            <asp:TextBox ID="txtEquipamento" runat="server" CssClass="form-control" placeholder="Ex: Notebook"></asp:TextBox>
        </div>
        
        <div class="col-md-6">
            <label class="form-label">Modelo / Marca</label>
            <asp:TextBox ID="txtModeloMarca" runat="server" CssClass="form-control" placeholder="Ex: Dell Inspiron 15"></asp:TextBox>
        </div>
        <div class="col-md-6">
            <label class="form-label">Número de Série</label>
            <asp:TextBox ID="txtNumSerie" runat="server" CssClass="form-control" placeholder="Ex: ABC12345XYZ"></asp:TextBox>
        </div>

        <div class="col-12">
            <label class="form-label">Defeito Relatado</label>
            <asp:TextBox ID="txtDefeito" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="2"></asp:TextBox>
        </div>
        
        <div class="col-md-4">
            <label class="form-label">Data Entrada</label>
            <asp:TextBox ID="txtData" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
        </div>
        <div class="col-md-4">
            <label class="form-label">Status</label>
            <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-select">
                <asp:ListItem Text="Em Análise" Value="1"></asp:ListItem>
                <asp:ListItem Text="Em Manutenção" Value="2"></asp:ListItem>
                <asp:ListItem Text="Concluído" Value="3"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="col-md-4">
            <label class="form-label">Técnico</label>
            <asp:TextBox ID="txtTecnico" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        
        <div class="col-12 mt-3">
            <asp:Button ID="btnSalvar" runat="server" Text="Salvar Demanda" CssClass="btn btn-success" />
            <a href="index.aspx" class="btn btn-secondary">Cancelar</a>
        </div>
    </div>
</div>
</asp:Content>
