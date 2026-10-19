<%@ Page Title="Backup" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="backup.aspx.cs" Inherits="WebApplication1.backup" %>
<asp:Content ID="Title" ContentPlaceHolderID="TitleContent" runat="server">Backup</asp:Content>
<asp:Content ID="Breadcrumb" ContentPlaceHolderID="BreadcrumbContent" runat="server">Backup</asp:Content>
<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-header">
        <div>
            <div class="eyebrow">Administração</div>
            <h1 class="page-title">Backup dos dados</h1>
            <p class="page-description">Gere uma cópia de segurança completa do banco de dados e baixe o arquivo.</p>
        </div>
    </div>

    <div class="filter-card">
        <p>Pasta dos backups (no computador do SQL Server): <strong><asp:Label ID="lblPasta" runat="server" /></strong></p>
        <p class="muted">O arquivo .bak é gravado nessa pasta pelo próprio SQL Server, que precisa ter permissão de escrita nela.
            A pasta é definida em <code>PastaBackup</code> no Web.config.</p>
        <asp:Button ID="btnBackup" runat="server" Text="Gerar backup agora" CssClass="btn btn-primary" OnClick="btnBackup_Click"
            OnClientClick="return confirm('Gerar o backup agora? Pode levar alguns instantes.');" CausesValidation="false" />
    </div>

    <div class="table-card">
        <div class="table-toolbar"><strong>Arquivos de backup na pasta</strong></div>
        <div class="table-wrap">
            <asp:GridView ID="gvArquivos" runat="server" AutoGenerateColumns="False" CssClass="data-table" GridLines="None"
                ShowHeaderWhenEmpty="True" OnRowCommand="gvArquivos_RowCommand">
                <EmptyDataRowStyle CssClass="empty-row" />
                <EmptyDataTemplate>Nenhum arquivo de backup encontrado (ou a pasta não está acessível pelo site).</EmptyDataTemplate>
                <Columns>
                    <asp:BoundField DataField="Nome" HeaderText="Arquivo" />
                    <asp:TemplateField HeaderText="Tamanho"><ItemTemplate><%# Tamanho(Eval("Tamanho")) %></ItemTemplate></asp:TemplateField>
                    <asp:TemplateField HeaderText="Data"><ItemTemplate><%# ((DateTime)Eval("Data")).ToString("dd/MM/yyyy HH:mm") %></ItemTemplate></asp:TemplateField>
                    <asp:TemplateField HeaderText="Ações" ItemStyle-CssClass="actions-cell"><ItemTemplate>
                        <asp:LinkButton runat="server" CommandName="Baixar" CommandArgument='<%# Eval("Nome") %>' CssClass="link-action" CausesValidation="false">Baixar</asp:LinkButton>
                    </ItemTemplate></asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>

    <div class="table-card" style="margin-top:16px">
        <div class="table-toolbar"><strong>Histórico dos últimos backups</strong></div>
        <div class="table-wrap">
            <asp:GridView ID="gvHistorico" runat="server" AutoGenerateColumns="False" CssClass="data-table" GridLines="None"
                ShowHeaderWhenEmpty="True">
                <EmptyDataRowStyle CssClass="empty-row" />
                <EmptyDataTemplate>Nenhum backup registrado ainda.</EmptyDataTemplate>
                <Columns>
                    <asp:TemplateField HeaderText="Data"><ItemTemplate><%# ((DateTime)Eval("CriadoEm")).ToString("dd/MM/yyyy HH:mm") %></ItemTemplate></asp:TemplateField>
                    <asp:BoundField DataField="Usuario" HeaderText="Usuário" />
                    <asp:BoundField DataField="Arquivo" HeaderText="Arquivo" />
                    <asp:TemplateField HeaderText="Resultado"><ItemTemplate>
                        <span class='status <%# (bool)Eval("Sucesso") ? "ok" : "off" %>'><%# (bool)Eval("Sucesso") ? "OK" : "Falhou" %></span>
                    </ItemTemplate></asp:TemplateField>
                    <asp:BoundField DataField="Mensagem" HeaderText="Mensagem" />
                </Columns>
            </asp:GridView>
        </div>
    </div>

    <div class="alert alert-info" style="margin-top:16px">
        <strong>Como restaurar:</strong> no SSMS, execute
        <code>RESTORE DATABASE CadernetaObras FROM DISK = 'C:\Backups\CadernetaObras\arquivo.bak' WITH REPLACE</code>
        (feche as conexões abertas antes). Guarde uma cópia dos arquivos .bak em outro computador ou na nuvem.
    </div>
</asp:Content>
