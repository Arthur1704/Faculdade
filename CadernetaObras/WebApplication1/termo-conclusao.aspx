<%@ Page Title="Termo de conclusão" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="termo-conclusao.aspx.cs" Inherits="WebApplication1.termo_conclusao" %>
<%@ Register Src="~/Assinaturas.ascx" TagPrefix="uc" TagName="Assinaturas" %>
<asp:Content ID="Title" ContentPlaceHolderID="TitleContent" runat="server">Termo de conclusão</asp:Content>
<asp:Content ID="Breadcrumb" ContentPlaceHolderID="BreadcrumbContent" runat="server">Termo de conclusão</asp:Content>
<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-header">
        <div>
            <div class="eyebrow">Documentos</div>
            <h1 class="page-title">Termo de conclusão</h1>
            <p class="page-description">Gere o termo de conclusão com os dados já cadastrados e o PDF único com capa e termo.</p>
        </div>
        <div class="actions">
            <asp:Button ID="btnNovo" runat="server" Text="+ Novo termo" CssClass="btn btn-primary" OnClick="btnNovo_Click" CausesValidation="false" />
        </div>
    </div>

    <div class="filter-card">
        <div class="filter-grid" style="grid-template-columns:2fr 1fr 1fr auto auto">
            <div class="field wide"><label>Pesquisar</label>
                <asp:TextBox ID="txtPesquisa" runat="server" CssClass="input" placeholder="Número, obra ou proprietário" />
            </div>
            <div class="field"><label>Status</label>
                <asp:DropDownList ID="ddlFiltroStatus" runat="server" CssClass="select"><asp:ListItem Value="">Todos</asp:ListItem><asp:ListItem Value="Rascunho">Rascunho</asp:ListItem><asp:ListItem Value="Pronto para assinatura">Pronto para assinatura</asp:ListItem><asp:ListItem Value="Concluído">Concluído</asp:ListItem></asp:DropDownList>
            </div>
            <div class="field"><label>Ano</label>
                <asp:DropDownList ID="ddlAno" runat="server" CssClass="select"><asp:ListItem Value="">Todos</asp:ListItem></asp:DropDownList>
            </div>
            <asp:Button ID="btnPesquisar" runat="server" Text="Pesquisar" CssClass="btn btn-primary" OnClick="btnPesquisar_Click" CausesValidation="false" />
            <asp:Button ID="btnLimpar" runat="server" Text="Limpar" CssClass="btn" OnClick="btnLimpar_Click" CausesValidation="false" />
        </div>
    </div>

    <div class="table-card">
        <div class="table-toolbar"><strong>Registros cadastrados</strong><asp:Label ID="lblTotal" runat="server" CssClass="muted" /></div>
        <div class="table-wrap">
            <asp:GridView ID="gvDados" runat="server" AutoGenerateColumns="False" CssClass="data-table" GridLines="None"
                DataKeyNames="TermoConclusaoId" AllowPaging="True" PageSize="10" UseAccessibleHeader="True" ShowHeaderWhenEmpty="True"
                OnPageIndexChanging="gvDados_PageIndexChanging" OnRowCommand="gvDados_RowCommand">
                <PagerStyle CssClass="grid-pager" />
                <EmptyDataRowStyle CssClass="empty-row" />
                <EmptyDataTemplate>Nenhum termo encontrado.</EmptyDataTemplate>
                <Columns>
                <asp:BoundField DataField="Numero" HeaderText="Nº" />
                <asp:BoundField DataField="Obra" HeaderText="Obra" />
                <asp:BoundField DataField="Proprietario" HeaderText="Proprietário" />
                <asp:TemplateField HeaderText="Conclusão"><ItemTemplate><%# FormatarData(Eval("DataConclusao")) %></ItemTemplate></asp:TemplateField>
                <asp:TemplateField HeaderText="Status"><ItemTemplate><span class="status <%# ClasseStatus(Eval("Status")) %>"><%# Eval("Status") %></span></ItemTemplate></asp:TemplateField>
                <asp:TemplateField HeaderText="Ações" ItemStyle-CssClass="actions-cell"><ItemTemplate>
                        <asp:LinkButton runat="server" CommandName="Ver" CommandArgument='<%# Eval("TermoConclusaoId") %>' CssClass="link-action" CausesValidation="false">Ver</asp:LinkButton>
                        <asp:LinkButton runat="server" CommandName="Editar" CommandArgument='<%# Eval("TermoConclusaoId") %>' CssClass="link-action" CausesValidation="false">Editar</asp:LinkButton>
                        <asp:LinkButton runat="server" CommandName="Imprimir" CommandArgument='<%# Eval("TermoConclusaoId") %>' CssClass="link-action" CausesValidation="false">Imprimir</asp:LinkButton>
                        <asp:LinkButton runat="server" CommandName="PDF" CommandArgument='<%# Eval("TermoConclusaoId") %>' CssClass="link-action" CausesValidation="false">PDF</asp:LinkButton>
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
                        <label class="required">Obra</label>
                        <asp:DropDownList ID="ddlObra" runat="server" CssClass="select" AutoPostBack="True" OnSelectedIndexChanged="ddlObra_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                    <div class="field">
                        <label>Proprietário (da obra)</label>
                        <asp:DropDownList ID="ddlProprietario" runat="server" CssClass="select" Enabled="False"></asp:DropDownList>
                    </div>
                    <div class="field">
                        <label class="required">Data de conclusão</label>
                        <asp:TextBox ID="txtData" runat="server" CssClass="input" TextMode="Date" />
                    </div>
                    <div class="field">
                        <label>Status</label>
                        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="select"><asp:ListItem Value="Rascunho">Rascunho</asp:ListItem><asp:ListItem Value="Pronto para assinatura">Pronto para assinatura</asp:ListItem><asp:ListItem Value="Concluído">Concluído</asp:ListItem></asp:DropDownList>
                    </div>
                    <div class="field span-2">
                        <label>Documento de referência (ART/RRT, recibo ou protocolo)</label>
                        <asp:TextBox ID="txtDocumento" runat="server" CssClass="input" />
                    </div>
                    <div class="field span-2">
                        <label class="required">Declaração de conclusão</label>
                        <asp:TextBox ID="txtDeclaracao" runat="server" CssClass="textarea" TextMode="MultiLine" Rows="4" />
                    </div>
                    <div class="field span-2">
                        <label>Observações finais</label>
                        <asp:TextBox ID="txtObservacoes" runat="server" CssClass="textarea" TextMode="MultiLine" Rows="4" />
                    </div>
                </div>
                <div class="ficha-bloco" style="margin-top:14px">
                    <h3>Dados da obra (preenchidos automaticamente pelo cadastro)</h3>
                    <div class="detail-grid">
                    <div class="detail-item"><small>Profissional</small><strong><asp:Label ID="tProfissional" runat="server" /></strong></div>
                    <div class="detail-item"><small>Nº de registro</small><strong><asp:Label ID="tRegistro" runat="server" /></strong></div>
                    <div class="detail-item"><small>Empresa</small><strong><asp:Label ID="tEmpresa" runat="server" /></strong></div>
                    <div class="detail-item"><small>CPF/CNPJ do proprietário</small><strong><asp:Label ID="tDocProp" runat="server" /></strong></div>
                    <div class="detail-item"><small>Telefone do proprietário</small><strong><asp:Label ID="tTelefone" runat="server" /></strong></div>
                    <div class="detail-item span-2"><small>Local da obra</small><strong><asp:Label ID="tLocal" runat="server" /></strong></div>
                    </div>
                    <asp:Label ID="tAviso" runat="server" CssClass="muted" />
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
                    <asp:HiddenField ID="hfIdView" runat="server" />
                    <div class="detail-item"><small>Número</small><strong><asp:Label ID="vNumero" runat="server" /></strong></div>
                    <div class="detail-item"><small>Data de conclusão</small><strong><asp:Label ID="vData" runat="server" /></strong></div>
                    <div class="detail-item"><small>Profissional</small><strong><asp:Label ID="vProfissional" runat="server" /></strong></div>
                    <div class="detail-item"><small>Nº de registro</small><strong><asp:Label ID="vRegistro" runat="server" /></strong></div>
                    <div class="detail-item"><small>Empresa</small><strong><asp:Label ID="vEmpresa" runat="server" /></strong></div>
                    <div class="detail-item"><small>Obra</small><strong><asp:Label ID="vObra" runat="server" /></strong></div>
                    <div class="detail-item"><small>Proprietário</small><strong><asp:Label ID="vProprietario" runat="server" /></strong></div>
                    <div class="detail-item"><small>CPF/CNPJ do proprietário</small><strong><asp:Label ID="vDocProp" runat="server" /></strong></div>
                    <div class="detail-item"><small>Telefone do proprietário</small><strong><asp:Label ID="vTelefone" runat="server" /></strong></div>
                    <div class="detail-item span-2"><small>Local da obra</small><strong><asp:Label ID="vLocal" runat="server" /></strong></div>
                    <div class="detail-item"><small>Status</small><strong><asp:Label ID="vStatus" runat="server" /></strong></div>
                    <div class="detail-item"><small>Documento de referência</small><strong><asp:Label ID="vDocumento" runat="server" /></strong></div>
                    <div class="detail-item span-2"><small>Declaração</small><strong><asp:Label ID="vDeclaracao" runat="server" /></strong></div>
                    <div class="detail-item span-2"><small>Observações finais</small><strong><asp:Label ID="vObservacoes" runat="server" /></strong></div>
                </div>
                <uc:Assinaturas ID="ucAssinaturas" runat="server" />
            </div>
            <div class="modal-footer">
                <asp:Button ID="btnImprimirView" runat="server" Text="Imprimir" CssClass="btn" OnClientClick="window.print(); return false;" UseSubmitBehavior="false" />
                <asp:Button ID="btnGerarPdf" runat="server" Text="Gerar PDF (capa + termo)" CssClass="btn btn-primary" OnClick="btnGerarPdf_Click" CausesValidation="false" />
                <asp:Button ID="btnFecharView2" runat="server" Text="Fechar" CssClass="btn" OnClick="btnFecharView_Click" CausesValidation="false" />
            </div>
        </div>
    </asp:Panel>
</asp:Content>
