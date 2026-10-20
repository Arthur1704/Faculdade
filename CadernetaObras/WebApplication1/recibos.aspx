<%@ Page Title="Recibos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="recibos.aspx.cs" Inherits="WebApplication1.recibos" %>
<%@ Register Src="~/Assinaturas.ascx" TagPrefix="uc" TagName="Assinaturas" %>
<asp:Content ID="Title" ContentPlaceHolderID="TitleContent" runat="server">Recibos</asp:Content>
<asp:Content ID="Breadcrumb" ContentPlaceHolderID="BreadcrumbContent" runat="server">Recibos</asp:Content>
<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-header">
        <div>
            <div class="eyebrow">Documentos</div>
            <h1 class="page-title">Recibos</h1>
            <p class="page-description">Emita e consulte os recibos das obras.</p>
        </div>
        <div class="actions">
            <asp:Button ID="btnNovo" runat="server" Text="+ Novo recibo" CssClass="btn btn-primary" OnClick="btnNovo_Click" CausesValidation="false" />
        </div>
    </div>

    <div class="filter-card">
        <div class="filter-grid" style="grid-template-columns:2fr 1fr 1fr auto auto">
            <div class="field wide"><label>Pesquisar</label>
                <asp:TextBox ID="txtPesquisa" runat="server" CssClass="input" placeholder="Número, obra ou proprietário" />
            </div>
            <div class="field"><label>Status</label>
                <asp:DropDownList ID="ddlFiltroStatus" runat="server" CssClass="select"><asp:ListItem Value="">Todos</asp:ListItem><asp:ListItem Value="Emitido">Emitido</asp:ListItem><asp:ListItem Value="Aguardando">Aguardando</asp:ListItem><asp:ListItem Value="Cancelado">Cancelado</asp:ListItem></asp:DropDownList>
            </div>
            <div class="field"><label>Período</label>
                <asp:DropDownList ID="ddlPeriodo" runat="server" CssClass="select"><asp:ListItem Value="">Todos</asp:ListItem><asp:ListItem Value="mes">Este mês</asp:ListItem><asp:ListItem Value="90">Últimos 90 dias</asp:ListItem></asp:DropDownList>
            </div>
            <asp:Button ID="btnPesquisar" runat="server" Text="Pesquisar" CssClass="btn btn-primary" OnClick="btnPesquisar_Click" CausesValidation="false" />
            <asp:Button ID="btnLimpar" runat="server" Text="Limpar" CssClass="btn" OnClick="btnLimpar_Click" CausesValidation="false" />
        </div>
    </div>

    <div class="table-card">
        <div class="table-toolbar"><strong>Registros cadastrados</strong><asp:Label ID="lblTotal" runat="server" CssClass="muted" /></div>
        <div class="table-wrap">
            <asp:GridView ID="gvDados" runat="server" AutoGenerateColumns="False" CssClass="data-table" GridLines="None"
                DataKeyNames="ReciboId" AllowPaging="True" PageSize="10" UseAccessibleHeader="True" ShowHeaderWhenEmpty="True"
                OnPageIndexChanging="gvDados_PageIndexChanging" OnRowCommand="gvDados_RowCommand">
                <PagerStyle CssClass="grid-pager" />
                <EmptyDataRowStyle CssClass="empty-row" />
                <EmptyDataTemplate>Nenhum recibo encontrado.</EmptyDataTemplate>
                <Columns>
                <asp:BoundField DataField="Numero" HeaderText="Nº" />
                <asp:BoundField DataField="Obra" HeaderText="Obra" />
                <asp:BoundField DataField="Proprietario" HeaderText="Proprietário" />
                <asp:TemplateField HeaderText="Data"><ItemTemplate><%# FormatarData(Eval("DataEmissao")) %></ItemTemplate></asp:TemplateField>
                <asp:TemplateField HeaderText="Valor"><ItemTemplate><%# FormatarMoeda(Eval("Valor")) %></ItemTemplate></asp:TemplateField>
                <asp:TemplateField HeaderText="Status"><ItemTemplate><span class="status <%# ClasseStatus(Eval("Status")) %>"><%# Eval("Status") %></span></ItemTemplate></asp:TemplateField>
                <asp:TemplateField HeaderText="Ações" ItemStyle-CssClass="actions-cell"><ItemTemplate>
                        <asp:LinkButton runat="server" CommandName="Ver" CommandArgument='<%# Eval("ReciboId") %>' CssClass="link-action" CausesValidation="false">Ver</asp:LinkButton>
                        <asp:LinkButton runat="server" CommandName="Editar" CommandArgument='<%# Eval("ReciboId") %>' CssClass="link-action" CausesValidation="false">Editar</asp:LinkButton>
                        <asp:LinkButton runat="server" CommandName="Imprimir" CommandArgument='<%# Eval("ReciboId") %>' CssClass="link-action" CausesValidation="false">Imprimir</asp:LinkButton>
                </ItemTemplate></asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>

    <!-- Formulário (cadastro / edição) -->
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
                        <label class="required">Obra</label>
                        <asp:DropDownList ID="ddlObra" runat="server" CssClass="select" AutoPostBack="True" OnSelectedIndexChanged="ddlObra_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                    <div class="field">
                        <label class="required">Proprietário</label>
                        <asp:DropDownList ID="ddlProprietario" runat="server" CssClass="select"></asp:DropDownList>
                    </div>
                    <div class="field">
                        <label class="required">Data de emissão</label>
                        <asp:TextBox ID="txtData" runat="server" CssClass="input" TextMode="Date" />
                    </div>
                    <div class="field">
                        <label class="required">Valor (R$)</label>
                        <asp:TextBox ID="txtValor" runat="server" CssClass="input" placeholder="0,00" />
                    </div>
                    <div class="field">
                        <label>Forma de pagamento</label>
                        <asp:DropDownList ID="ddlForma" runat="server" CssClass="select"></asp:DropDownList>
                    </div>
                    <div class="field">
                        <label>Status</label>
                        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="select"><asp:ListItem Value="Emitido">Emitido</asp:ListItem><asp:ListItem Value="Aguardando">Aguardando</asp:ListItem><asp:ListItem Value="Cancelado">Cancelado</asp:ListItem></asp:DropDownList>
                    </div>
                    <div class="field span-2">
                        <label>Referente a</label>
                        <asp:TextBox ID="txtReferente" runat="server" CssClass="input" placeholder="Ex.: serviços de alvenaria - etapa 2" />
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

    <!-- Visualização -->
    <asp:Panel ID="pnlView" runat="server" CssClass="modal-backdrop">
        <div class="modal">
            <div class="modal-header">
                <h2 class="modal-title"><asp:Label ID="lblTituloView" runat="server" /></h2>
                <asp:LinkButton ID="btnFecharView" runat="server" CssClass="close" OnClick="btnFecharView_Click" CausesValidation="false">&times;</asp:LinkButton>
            </div>
            <div class="modal-body">
                <div class="detail-grid">
                    <div class="detail-item"><small>Número</small><strong><asp:Label ID="vNumero" runat="server" /></strong></div>
                    <div class="detail-item"><small>Data de emissão</small><strong><asp:Label ID="vData" runat="server" /></strong></div>
                    <div class="detail-item"><small>Obra</small><strong><asp:Label ID="vObra" runat="server" /></strong></div>
                    <div class="detail-item"><small>Proprietário</small><strong><asp:Label ID="vProprietario" runat="server" /></strong></div>
                    <div class="detail-item"><small>Valor</small><strong><asp:Label ID="vValor" runat="server" /></strong></div>
                    <div class="detail-item"><small>Forma de pagamento</small><strong><asp:Label ID="vForma" runat="server" /></strong></div>
                    <div class="detail-item"><small>Status</small><strong><asp:Label ID="vStatus" runat="server" /></strong></div>
                    <div class="detail-item span-2"><small>Referente a</small><strong><asp:Label ID="vReferente" runat="server" /></strong></div>
                    <div class="detail-item span-2"><small>Observações</small><strong><asp:Label ID="vObservacoes" runat="server" /></strong></div>
                </div>
                <uc:Assinaturas ID="ucAssinaturas" runat="server" />
            </div>
            <div class="modal-footer">
                <asp:Button ID="btnImprimirView" runat="server" Text="Imprimir" CssClass="btn" OnClientClick="window.print(); return false;" UseSubmitBehavior="false" />
                <asp:Button ID="btnFecharView2" runat="server" Text="Fechar" CssClass="btn" OnClick="btnFecharView_Click" CausesValidation="false" />
            </div>
        </div>
    </asp:Panel>
</asp:Content>
