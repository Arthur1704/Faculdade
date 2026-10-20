<%@ Page Title="Relato de visita" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="relato-visita.aspx.cs" Inherits="WebApplication1.relato_visita" %>
<%@ Register Src="~/Assinaturas.ascx" TagPrefix="uc" TagName="Assinaturas" %>
<asp:Content ID="Title" ContentPlaceHolderID="TitleContent" runat="server">Relato de visita</asp:Content>
<asp:Content ID="Breadcrumb" ContentPlaceHolderID="BreadcrumbContent" runat="server">Relato de visita</asp:Content>
<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-header">
        <div>
            <div class="eyebrow">Documentos</div>
            <h1 class="page-title">Relato de visita</h1>
            <p class="page-description">Registre as visitas técnicas realizadas nas obras.</p>
        </div>
        <div class="actions">
            <asp:Button ID="btnNovo" runat="server" Text="+ Novo relato" CssClass="btn btn-primary" OnClick="btnNovo_Click" CausesValidation="false" />
        </div>
    </div>

    <div class="filter-card">
        <div class="filter-grid" style="grid-template-columns:2fr 1fr 1fr auto auto">
            <div class="field wide"><label>Pesquisar</label>
                <asp:TextBox ID="txtPesquisa" runat="server" CssClass="input" placeholder="Número, obra ou texto do relato" />
            </div>
            <div class="field"><label>Status</label>
                <asp:DropDownList ID="ddlFiltroStatus" runat="server" CssClass="select"><asp:ListItem Value="">Todos</asp:ListItem><asp:ListItem Value="Rascunho">Rascunho</asp:ListItem><asp:ListItem Value="Concluído">Concluído</asp:ListItem></asp:DropDownList>
            </div>
            <div class="field"><label>Obra</label>
                <asp:DropDownList ID="ddlFiltroObra" runat="server" CssClass="select"><asp:ListItem Value="">Todas</asp:ListItem></asp:DropDownList>
            </div>
            <asp:Button ID="btnPesquisar" runat="server" Text="Pesquisar" CssClass="btn btn-primary" OnClick="btnPesquisar_Click" CausesValidation="false" />
            <asp:Button ID="btnLimpar" runat="server" Text="Limpar" CssClass="btn" OnClick="btnLimpar_Click" CausesValidation="false" />
        </div>
    </div>

    <div class="table-card">
        <div class="table-toolbar"><strong>Registros cadastrados</strong><asp:Label ID="lblTotal" runat="server" CssClass="muted" /></div>
        <div class="table-wrap">
            <asp:GridView ID="gvDados" runat="server" AutoGenerateColumns="False" CssClass="data-table" GridLines="None"
                DataKeyNames="RelatoVisitaId" AllowPaging="True" PageSize="10" UseAccessibleHeader="True" ShowHeaderWhenEmpty="True"
                OnPageIndexChanging="gvDados_PageIndexChanging" OnRowCommand="gvDados_RowCommand">
                <PagerStyle CssClass="grid-pager" />
                <EmptyDataRowStyle CssClass="empty-row" />
                <EmptyDataTemplate>Nenhum relato encontrado.</EmptyDataTemplate>
                <Columns>
                <asp:BoundField DataField="Numero" HeaderText="Nº" />
                <asp:TemplateField HeaderText="Visita nº"><ItemTemplate><%# Convert.ToInt32(Eval("NumeroNaObra")).ToString("000") %></ItemTemplate></asp:TemplateField>
                <asp:BoundField DataField="Obra" HeaderText="Obra" />
                <asp:TemplateField HeaderText="Data da visita"><ItemTemplate><%# FormatarData(Eval("DataVisita")) %></ItemTemplate></asp:TemplateField>
                <asp:TemplateField HeaderText="Resumo"><ItemTemplate><%# Resumo(Eval("Relato")) %></ItemTemplate></asp:TemplateField>
                <asp:TemplateField HeaderText="Status"><ItemTemplate><span class="status <%# ClasseStatus(Eval("Status")) %>"><%# Eval("Status") %></span></ItemTemplate></asp:TemplateField>
                <asp:TemplateField HeaderText="Ações" ItemStyle-CssClass="actions-cell"><ItemTemplate>
                        <asp:LinkButton runat="server" CommandName="Ver" CommandArgument='<%# Eval("RelatoVisitaId") %>' CssClass="link-action" CausesValidation="false">Ver</asp:LinkButton>
                        <asp:LinkButton runat="server" CommandName="Editar" CommandArgument='<%# Eval("RelatoVisitaId") %>' CssClass="link-action" CausesValidation="false">Editar</asp:LinkButton>
                        <asp:LinkButton runat="server" CommandName="Imprimir" CommandArgument='<%# Eval("RelatoVisitaId") %>' CssClass="link-action" CausesValidation="false">Imprimir</asp:LinkButton>
                        <asp:LinkButton runat="server" CommandName="Excluir" CommandArgument='<%# Eval("RelatoVisitaId") %>' CssClass="link-action" CausesValidation="false" OnClientClick="return confirm('Excluir este relato e seus anexos?');">Excluir</asp:LinkButton>
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
                        <asp:DropDownList ID="ddlObra" runat="server" CssClass="select"></asp:DropDownList>
                    </div>
                    <div class="field">
                        <label class="required">Data da visita</label>
                        <asp:TextBox ID="txtData" runat="server" CssClass="input" TextMode="Date" />
                    </div>
                    <div class="field span-2">
                        <label>Participantes</label>
                        <asp:TextBox ID="txtParticipantes" runat="server" CssClass="input" />
                    </div>
                    <div class="field">
                        <label>Situação em relação ao projeto</label>
                        <asp:DropDownList ID="ddlSituacao" runat="server" CssClass="select"><asp:ListItem Value="De acordo com o projeto">De acordo com o projeto</asp:ListItem><asp:ListItem Value="Em desacordo com o projeto">Em desacordo com o projeto</asp:ListItem></asp:DropDownList>
                    </div>
                    <div class="field">
                        <label>Status da obra</label>
                        <asp:DropDownList ID="ddlStatusObra" runat="server" CssClass="select"><asp:ListItem Value="Em andamento">Em andamento</asp:ListItem><asp:ListItem Value="Paralisada">Paralisada</asp:ListItem></asp:DropDownList>
                    </div>
                    <div class="field span-2">
                        <label class="required">Relato da visita</label>
                        <asp:TextBox ID="txtRelato" runat="server" CssClass="textarea" TextMode="MultiLine" Rows="4" />
                    </div>
                    <div class="field span-2">
                        <label>Decisões, orientações e pendências</label>
                        <asp:TextBox ID="txtDecisoes" runat="server" CssClass="textarea" TextMode="MultiLine" Rows="4" />
                    </div>
                    <div class="field">
                        <label>Status do relato</label>
                        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="select"><asp:ListItem Value="Rascunho">Rascunho</asp:ListItem><asp:ListItem Value="Concluído">Concluído</asp:ListItem></asp:DropDownList>
                    </div>
                </div>
                <div class="field" style="margin-top:14px">
                    <label>Etapas verificadas</label>
                    <div class="checklist-grid">
                        <asp:Repeater ID="rptEtapas" runat="server">
                            <ItemTemplate>
                                <label class="check-row">
                                    <asp:CheckBox ID="chkEtapa" runat="server" />
                                    <asp:HiddenField ID="hfEtapaId" runat="server" Value='<%# Eval("EtapaObraId") %>' />
                                    <span><%# Eval("Descricao") %></span>
                                </label>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
                <div class="field" style="margin-top:14px">
                    <label>Anexos (PDF, imagens, Word ou Excel - até 10 MB cada)</label>
                    <asp:TextBox ID="txtDescricaoAnexo" runat="server" CssClass="input" placeholder="Descrição das imagens/documentos que serão anexados (opcional)" style="margin-bottom:8px" />
                    <asp:FileUpload ID="fuAnexos" runat="server" AllowMultiple="True" CssClass="input" />
                    <asp:Repeater ID="rptAnexosForm" runat="server" OnItemCommand="rptAnexos_ItemCommand">
                        <HeaderTemplate><div class="anexo-lista"></HeaderTemplate>
                        <ItemTemplate>
                            <div class="anexo-item">
                                <span><%# Server.HtmlEncode(Convert.ToString(Eval("NomeOriginal"))) %><span class="muted"> <%# Server.HtmlEncode(Convert.ToString(Eval("Descricao"))) %></span> <span class="muted"><%# Tamanho(Eval("TamanhoBytes")) %></span></span>
                                <span>
                                    <asp:LinkButton runat="server" CommandName="Baixar" CommandArgument='<%# Eval("AnexoId") %>' CssClass="link-action" CausesValidation="false">Baixar</asp:LinkButton>
                                    <asp:LinkButton runat="server" CommandName="Remover" CommandArgument='<%# Eval("AnexoId") %>' CssClass="link-action" CausesValidation="false" OnClientClick="return confirm('Remover este anexo?');">Remover</asp:LinkButton>
                                </span>
                            </div>
                        </ItemTemplate>
                        <FooterTemplate></div></FooterTemplate>
                    </asp:Repeater>
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
                    <div class="detail-item"><small>Número</small><strong><asp:Label ID="vNumero" runat="server" /></strong></div>
                    <div class="detail-item"><small>Visita nº (na obra)</small><strong><asp:Label ID="vNumeroNaObra" runat="server" /></strong></div>
                    <div class="detail-item"><small>Data da visita</small><strong><asp:Label ID="vData" runat="server" /></strong></div>
                    <div class="detail-item"><small>Obra</small><strong><asp:Label ID="vObra" runat="server" /></strong></div>
                    <div class="detail-item"><small>Proprietário</small><strong><asp:Label ID="vProprietario" runat="server" /></strong></div>
                    <div class="detail-item"><small>Situação</small><strong><asp:Label ID="vSituacao" runat="server" /></strong></div>
                    <div class="detail-item"><small>Status da obra</small><strong><asp:Label ID="vStatusObra" runat="server" /></strong></div>
                    <div class="detail-item span-2"><small>Participantes</small><strong><asp:Label ID="vParticipantes" runat="server" /></strong></div>
                    <div class="detail-item span-2"><small>Relato</small><strong><asp:Label ID="vRelato" runat="server" /></strong></div>
                    <div class="detail-item span-2"><small>Decisões e pendências</small><strong><asp:Label ID="vDecisoes" runat="server" /></strong></div>
                    <div class="detail-item"><small>Status do relato</small><strong><asp:Label ID="vStatus" runat="server" /></strong></div>
                </div>
                <div class="field" style="margin-top:14px">
                    <label>Etapas verificadas</label>
                    <strong><asp:Label ID="vEtapas" runat="server" /></strong>
                </div>
                <asp:Repeater ID="rptAnexosView" runat="server" OnItemCommand="rptAnexos_ItemCommand">
                    <HeaderTemplate><div class="field" style="margin-top:14px"><label>Anexos</label><div class="anexo-lista"></HeaderTemplate>
                    <ItemTemplate>
                        <div class="anexo-item">
                            <span><%# Server.HtmlEncode(Convert.ToString(Eval("NomeOriginal"))) %><span class="muted"> <%# Server.HtmlEncode(Convert.ToString(Eval("Descricao"))) %></span> <span class="muted"><%# Tamanho(Eval("TamanhoBytes")) %></span></span>
                            <asp:LinkButton runat="server" CommandName="Baixar" CommandArgument='<%# Eval("AnexoId") %>' CssClass="link-action" CausesValidation="false">Baixar</asp:LinkButton>
                        </div>
                    </ItemTemplate>
                    <FooterTemplate></div></div></FooterTemplate>
                </asp:Repeater>
                <uc:Assinaturas ID="ucAssinaturas" runat="server" />
            </div>
            <div class="modal-footer">
                <asp:Button ID="btnImprimirView" runat="server" Text="Imprimir" CssClass="btn" OnClientClick="window.print(); return false;" UseSubmitBehavior="false" />
                <asp:Button ID="btnFecharView2" runat="server" Text="Fechar" CssClass="btn" OnClick="btnFecharView_Click" CausesValidation="false" />
            </div>
        </div>
    </asp:Panel>
</asp:Content>
