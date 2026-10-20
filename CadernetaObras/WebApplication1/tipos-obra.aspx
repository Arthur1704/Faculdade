<%@ Page Title="Tipos de obra" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="tipos-obra.aspx.cs" Inherits="WebApplication1.tipos_obra" %>
<asp:Content ID="Title" ContentPlaceHolderID="TitleContent" runat="server">Tipos de obra</asp:Content>
<asp:Content ID="Breadcrumb" ContentPlaceHolderID="BreadcrumbContent" runat="server">Tipos de obra</asp:Content>
<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-header">
        <div>
            <div class="eyebrow">Obras</div>
            <h1 class="page-title">Tipos de obra</h1>
            <p class="page-description">Mantenha os tipos usados no cadastro de obras.</p>
        </div>
        <div class="actions">
            <asp:Button ID="btnNovo" runat="server" Text="+ Novo tipo" CssClass="btn btn-primary" OnClick="btnNovo_Click" CausesValidation="false" />
        </div>
    </div>

    <div class="filter-card">
        <div class="filter-grid">
            <div class="field wide"><label>Pesquisar</label>
                <asp:TextBox ID="txtPesquisa" runat="server" CssClass="input" placeholder="Descrição ou observação" />
            </div>
            <div class="field"><label>Status</label>
                <asp:DropDownList ID="ddlFiltroStatus" runat="server" CssClass="select"><asp:ListItem Value="">Todos</asp:ListItem><asp:ListItem Value="Ativo">Ativo</asp:ListItem><asp:ListItem Value="Inativo">Inativo</asp:ListItem></asp:DropDownList>
            </div>
            <div class="field"><label>Ordenar por</label>
                <asp:DropDownList ID="ddlOrdem" runat="server" CssClass="select"><asp:ListItem Value="recentes">Mais recentes</asp:ListItem><asp:ListItem Value="az">Nome A-Z</asp:ListItem><asp:ListItem Value="za">Nome Z-A</asp:ListItem></asp:DropDownList>
            </div>
            <asp:Button ID="btnPesquisar" runat="server" Text="Pesquisar" CssClass="btn btn-primary" OnClick="btnPesquisar_Click" CausesValidation="false" />
            <asp:Button ID="btnLimpar" runat="server" Text="Limpar" CssClass="btn" OnClick="btnLimpar_Click" CausesValidation="false" />
        </div>
    </div>

    <div class="table-card">
        <div class="table-toolbar"><strong>Registros cadastrados</strong><asp:Label ID="lblTotal" runat="server" CssClass="muted" /></div>
        <div class="table-wrap">
            <asp:GridView ID="gvDados" runat="server" AutoGenerateColumns="False" CssClass="data-table" GridLines="None"
                DataKeyNames="TipoObraId" AllowPaging="True" PageSize="10" UseAccessibleHeader="True" ShowHeaderWhenEmpty="True"
                OnPageIndexChanging="gvDados_PageIndexChanging" OnRowCommand="gvDados_RowCommand">
                <PagerStyle CssClass="grid-pager" />
                <EmptyDataRowStyle CssClass="empty-row" />
                <EmptyDataTemplate>Nenhum registro encontrado.</EmptyDataTemplate>
                <Columns>
                <asp:BoundField DataField="Descricao" HeaderText="Descrição" />
                <asp:BoundField DataField="Observacoes" HeaderText="Observações" />
                <asp:TemplateField HeaderText="Status"><ItemTemplate><span class="status <%# ClasseStatus(Eval("Status")) %>"><%# Eval("Status") %></span></ItemTemplate></asp:TemplateField>
                <asp:TemplateField HeaderText="Ações" ItemStyle-CssClass="actions-cell"><ItemTemplate>
                        <asp:LinkButton runat="server" CommandName="Ver" CommandArgument='<%# Eval("TipoObraId") %>' CssClass="link-action" CausesValidation="false">Ver</asp:LinkButton>
                        <asp:LinkButton runat="server" CommandName="Editar" CommandArgument='<%# Eval("TipoObraId") %>' CssClass="link-action" CausesValidation="false">Editar</asp:LinkButton>
                        <asp:LinkButton runat="server" CommandName="Excluir" CommandArgument='<%# Eval("TipoObraId") %>' CssClass="link-action" CausesValidation="false" OnClientClick="return confirm('Excluir este tipo de obra?');">Excluir</asp:LinkButton>
                </ItemTemplate></asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>

    <asp:Panel ID="pnlForm" runat="server" CssClass="modal-backdrop">
        <div class="modal">
            <div class="modal-header">
                <h2 class="modal-title"><asp:Label ID="lblTituloForm" runat="server" /></h2>
                <asp:LinkButton ID="btnFecharForm" runat="server" CssClass="close" OnClick="btnCancelar_Click" CausesValidation="false">&times;</asp:LinkButton>
            </div>
            <div class="modal-body">
                <asp:Label ID="lblErroForm" runat="server" CssClass="alert alert-error" Visible="false" style="display:block" />
                <asp:HiddenField ID="hfId" runat="server" />
                <div class="form-grid">
                    <div class="field">
                        <label class="required">Descrição</label>
                        <asp:TextBox ID="txtDescricao" runat="server" CssClass="input" />
                    </div>
                    <div class="field">
                        <label>Status</label>
                        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="select"><asp:ListItem Value="Ativo">Ativo</asp:ListItem><asp:ListItem Value="Inativo">Inativo</asp:ListItem></asp:DropDownList>
                    </div>
                    <div class="field span-2">
                        <label>Observações</label>
                        <asp:TextBox ID="txtObservacoes" runat="server" CssClass="textarea" TextMode="MultiLine" Rows="4" />
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn" OnClick="btnCancelar_Click" CausesValidation="false" />
                <asp:Button ID="btnSalvar" runat="server" Text="Salvar" CssClass="btn btn-primary" OnClick="btnSalvar_Click" />
            </div>
        </div>
    </asp:Panel>

    <asp:Panel ID="pnlView" runat="server" CssClass="modal-backdrop">
        <div class="modal">
            <div class="modal-header">
                <h2 class="modal-title"><asp:Label ID="lblTituloView" runat="server" /></h2>
                <asp:LinkButton ID="btnFecharView" runat="server" CssClass="close" OnClick="btnFecharView_Click" CausesValidation="false">&times;</asp:LinkButton>
            </div>
            <div class="modal-body">
                <div class="detail-grid">
                    <div class="detail-item"><small>Descrição</small><strong><asp:Label ID="vDescricao" runat="server" /></strong></div>
                    <div class="detail-item"><small>Status</small><strong><asp:Label ID="vStatus" runat="server" /></strong></div>
                    <div class="detail-item"><small>Última atualização</small><strong><asp:Label ID="vAtualizacao" runat="server" /></strong></div>
                    <div class="detail-item span-2"><small>Observações</small><strong><asp:Label ID="vObservacoes" runat="server" /></strong></div>
                </div>
            </div>
            <div class="modal-footer">
                <asp:Button ID="btnFecharView2" runat="server" Text="Fechar" CssClass="btn" OnClick="btnFecharView_Click" CausesValidation="false" />
            </div>
        </div>
    </asp:Panel>
</asp:Content>
