<%@ Page Title="Obras" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="obras.aspx.cs" Inherits="WebApplication1.obras" %>
<%@ Register Src="~/Assinaturas.ascx" TagPrefix="uc" TagName="Assinaturas" %>
<asp:Content ID="Title" ContentPlaceHolderID="TitleContent" runat="server">Obras</asp:Content>
<asp:Content ID="Breadcrumb" ContentPlaceHolderID="BreadcrumbContent" runat="server">Obras</asp:Content>
<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-header">
        <div>
            <div class="eyebrow">Obras</div>
            <h1 class="page-title">Obras</h1>
            <p class="page-description">Cadastre as obras, seus responsáveis técnicos e os dados da capa da caderneta.</p>
        </div>
        <div class="actions">
            <asp:Button ID="btnNovo" runat="server" Text="+ Nova obra" CssClass="btn btn-primary" OnClick="btnNovo_Click" CausesValidation="false" />
        </div>
    </div>

    <div class="filter-card">
        <div class="filter-grid">
            <div class="field wide"><label>Pesquisar</label>
                <asp:TextBox ID="txtPesquisa" runat="server" CssClass="input" placeholder="Obra, proprietário, responsável, nº da caderneta ou RT" />
            </div>
            <div class="field"><label>Status</label>
                <asp:DropDownList ID="ddlFiltroStatus" runat="server" CssClass="select"><asp:ListItem Value="">Todos</asp:ListItem><asp:ListItem Value="Planejada">Planejada</asp:ListItem><asp:ListItem Value="Em andamento">Em andamento</asp:ListItem><asp:ListItem Value="Paralisada">Paralisada</asp:ListItem><asp:ListItem Value="Concluída">Concluída</asp:ListItem></asp:DropDownList>
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
                DataKeyNames="ObraId" AllowPaging="True" PageSize="10" UseAccessibleHeader="True" ShowHeaderWhenEmpty="True"
                OnPageIndexChanging="gvDados_PageIndexChanging" OnRowCommand="gvDados_RowCommand">
                <PagerStyle CssClass="grid-pager" />
                <EmptyDataRowStyle CssClass="empty-row" />
                <EmptyDataTemplate>Nenhum registro encontrado.</EmptyDataTemplate>
                <Columns>
                <asp:BoundField DataField="Obra" HeaderText="Obra" />
                <asp:BoundField DataField="Proprietario" HeaderText="Proprietário" />
                <asp:BoundField DataField="Responsavel" HeaderText="Responsável técnico" />
                <asp:BoundField DataField="Tipo" HeaderText="Tipo" />
                <asp:TemplateField HeaderText="Status"><ItemTemplate><span class="status <%# ClasseStatus(Eval("Status")) %>"><%# Eval("Status") %></span></ItemTemplate></asp:TemplateField>
                <asp:TemplateField HeaderText="Ações" ItemStyle-CssClass="actions-cell"><ItemTemplate>
                        <asp:LinkButton runat="server" CommandName="Ver" CommandArgument='<%# Eval("ObraId") %>' CssClass="link-action" CausesValidation="false">Ver</asp:LinkButton>
                        <asp:LinkButton runat="server" CommandName="Editar" CommandArgument='<%# Eval("ObraId") %>' CssClass="link-action" CausesValidation="false">Editar</asp:LinkButton>
                        <asp:LinkButton runat="server" CommandName="Capa" CommandArgument='<%# Eval("ObraId") %>' CssClass="link-action" CausesValidation="false">Capa</asp:LinkButton>
                        <asp:LinkButton runat="server" CommandName="Excluir" CommandArgument='<%# Eval("ObraId") %>' CssClass="link-action" CausesValidation="false" OnClientClick="return confirm('Excluir esta obra?');">Excluir</asp:LinkButton>
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
                    <div class="field span-2">
                        <label class="required">Nome da obra</label>
                        <asp:TextBox ID="txtNome" runat="server" CssClass="input" />
                    </div>
                    <div class="field">
                        <label>Nº da caderneta</label>
                        <asp:TextBox ID="txtNumeroCaderneta" runat="server" CssClass="input" placeholder="Número impresso na caderneta" />
                    </div>
                    <div class="field">
                        <label>Status</label>
                        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="select"><asp:ListItem Value="Em andamento">Em andamento</asp:ListItem><asp:ListItem Value="Planejada">Planejada</asp:ListItem><asp:ListItem Value="Concluída">Concluída</asp:ListItem><asp:ListItem Value="Paralisada">Paralisada</asp:ListItem></asp:DropDownList>
                    </div>
                    <div class="field">
                        <label class="required">Proprietário</label>
                        <asp:DropDownList ID="ddlProprietario" runat="server" CssClass="select"></asp:DropDownList>
                    </div>
                    <div class="field">
                        <label class="required">Responsável técnico</label>
                        <asp:DropDownList ID="ddlProfissional" runat="server" CssClass="select"></asp:DropDownList>
                    </div>
                    <div class="field">
                        <label>Nº da RT (ART/RRT)</label>
                        <asp:TextBox ID="txtNumeroRT" runat="server" CssClass="input" />
                    </div>
                    <div class="field">
                        <label>Empresa / construtor</label>
                        <asp:TextBox ID="txtEmpresa" runat="server" CssClass="input" />
                    </div>
                    <div class="field">
                        <label class="required">Tipo de edificação</label>
                        <asp:DropDownList ID="ddlTipoObra" runat="server" CssClass="select"></asp:DropDownList>
                    </div>
                    <div class="field">
                        <label>Atividade técnica</label>
                        <asp:DropDownList ID="ddlAtividade" runat="server" CssClass="select"></asp:DropDownList>
                    </div>
                    <div class="field">
                        <label>Valor da obra (R$)</label>
                        <asp:TextBox ID="txtValorObra" runat="server" CssClass="input" placeholder="0,00" />
                    </div>
                    <div class="field">
                        <label class="required">Data de início</label>
                        <asp:TextBox ID="txtDataInicio" runat="server" CssClass="input" TextMode="Date" />
                    </div>
                    <div class="field">
                        <label>Previsão de término</label>
                        <asp:TextBox ID="txtPrevisaoTermino" runat="server" CssClass="input" TextMode="Date" />
                    </div>
                    <div class="field span-2">
                        <label class="required">Local da obra (endereço)</label>
                        <asp:TextBox ID="txtEnderecoObra" runat="server" CssClass="input" placeholder="Rua, número, bairro, cidade - UF" />
                    </div>
                    <div class="field">
                        <label>Área a construir (m²)</label>
                        <asp:TextBox ID="areaConstruir" runat="server" CssClass="input" placeholder="0,00" ClientIDMode="Static" onkeyup="calcularAreaTotal()" />
                    </div>
                    <div class="field">
                        <label>Área a ampliar (m²)</label>
                        <asp:TextBox ID="areaAmpliar" runat="server" CssClass="input" placeholder="0,00" ClientIDMode="Static" onkeyup="calcularAreaTotal()" />
                    </div>
                    <div class="field">
                        <label>Área a regularizar (m²)</label>
                        <asp:TextBox ID="areaRegularizar" runat="server" CssClass="input" placeholder="0,00" ClientIDMode="Static" onkeyup="calcularAreaTotal()" />
                    </div>
                    <div class="field">
                        <label>Área a reformar (m²)</label>
                        <asp:TextBox ID="areaReforma" runat="server" CssClass="input" placeholder="0,00" ClientIDMode="Static" onkeyup="calcularAreaTotal()" />
                    </div>
                    <div class="field">
                        <label>Área total edificada (m²)</label>
                        <asp:TextBox ID="areaTotal" runat="server" CssClass="input" placeholder="0,00" ClientIDMode="Static" ReadOnly="True" />
                    </div>
                    <div class="field span-2">
                        <label>Observações</label>
                        <asp:TextBox ID="txtObservacoes" runat="server" CssClass="textarea" TextMode="MultiLine" Rows="4" />
                    </div>
                </div>
                <div class="field" style="margin-top:14px">
                    <label>Documentos da obra (ART/RRT, projeto aprovado, alvará... - PDF, imagens, Word ou Excel até 10 MB)</label>
                    <div class="form-grid">
                    <div class="field">
                        <label>Tipo do documento</label>
                        <asp:DropDownList ID="ddlTipoDocumento" runat="server" CssClass="select"><asp:ListItem Value="ART/RRT">ART/RRT</asp:ListItem><asp:ListItem Value="Projeto aprovado">Projeto aprovado</asp:ListItem><asp:ListItem Value="Alvará">Alvará</asp:ListItem><asp:ListItem Value="Habite-se">Habite-se</asp:ListItem><asp:ListItem Value="Outro">Outro</asp:ListItem></asp:DropDownList>
                    </div>
                    <div class="field">
                        <label>Nome / descrição do documento</label>
                        <asp:TextBox ID="txtNomeDocumento" runat="server" CssClass="input" placeholder="Se vazio, usa o nome do arquivo" />
                    </div>
                    </div>
                    <asp:FileUpload ID="fuDocumentos" runat="server" AllowMultiple="True" CssClass="input" />
                    <asp:Repeater ID="rptDocumentosForm" runat="server" OnItemCommand="rptDocumentos_ItemCommand">
                        <HeaderTemplate><div class="anexo-lista"></HeaderTemplate>
                        <ItemTemplate>
                            <div class="anexo-item">
                                <span><strong><%# Server.HtmlEncode(Convert.ToString(Eval("TipoDocumento"))) %></strong> - <%# Server.HtmlEncode(Convert.ToString(Eval("NomeDocumento"))) %> <span class="muted"><%# Tamanho(Eval("TamanhoBytes")) %></span></span>
                                <span>
                                    <asp:LinkButton runat="server" CommandName="Baixar" CommandArgument='<%# Eval("DocumentoId") %>' CssClass="link-action" CausesValidation="false">Baixar</asp:LinkButton>
                                    <asp:LinkButton runat="server" CommandName="Remover" CommandArgument='<%# Eval("DocumentoId") %>' CssClass="link-action" CausesValidation="false" OnClientClick="return confirm('Remover este documento?');">Remover</asp:LinkButton>
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
                    <div class="detail-item span-2"><small>Obra</small><strong><asp:Label ID="vNome" runat="server" /></strong></div>
                    <div class="detail-item"><small>Nº da caderneta</small><strong><asp:Label ID="vCaderneta" runat="server" /></strong></div>
                    <div class="detail-item"><small>Status</small><strong><asp:Label ID="vStatus" runat="server" /></strong></div>
                    <div class="detail-item"><small>Proprietário</small><strong><asp:Label ID="vProprietario" runat="server" /></strong></div>
                    <div class="detail-item"><small>Responsável técnico</small><strong><asp:Label ID="vResponsavel" runat="server" /></strong></div>
                    <div class="detail-item"><small>Nº da RT</small><strong><asp:Label ID="vRT" runat="server" /></strong></div>
                    <div class="detail-item"><small>Empresa / construtor</small><strong><asp:Label ID="vEmpresa" runat="server" /></strong></div>
                    <div class="detail-item"><small>Tipo de edificação</small><strong><asp:Label ID="vTipo" runat="server" /></strong></div>
                    <div class="detail-item"><small>Atividade técnica</small><strong><asp:Label ID="vAtividade" runat="server" /></strong></div>
                    <div class="detail-item"><small>Valor da obra</small><strong><asp:Label ID="vValor" runat="server" /></strong></div>
                    <div class="detail-item"><small>Início</small><strong><asp:Label ID="vInicio" runat="server" /></strong></div>
                    <div class="detail-item"><small>Previsão de término</small><strong><asp:Label ID="vTermino" runat="server" /></strong></div>
                    <div class="detail-item span-2"><small>Local da obra</small><strong><asp:Label ID="vEndereco" runat="server" /></strong></div>
                    <div class="detail-item"><small>Área a construir</small><strong><asp:Label ID="vAreaConstruir" runat="server" /></strong></div>
                    <div class="detail-item"><small>Área a ampliar</small><strong><asp:Label ID="vAreaAmpliar" runat="server" /></strong></div>
                    <div class="detail-item"><small>Área a regularizar</small><strong><asp:Label ID="vAreaRegularizar" runat="server" /></strong></div>
                    <div class="detail-item"><small>Área a reformar</small><strong><asp:Label ID="vAreaReforma" runat="server" /></strong></div>
                    <div class="detail-item"><small>Área total</small><strong><asp:Label ID="vAreaTotal" runat="server" /></strong></div>
                    <div class="detail-item"><small>Última atualização</small><strong><asp:Label ID="vAtualizacao" runat="server" /></strong></div>
                    <div class="detail-item span-2"><small>Observações</small><strong><asp:Label ID="vObservacoes" runat="server" /></strong></div>
                </div>
                <asp:Repeater ID="rptDocumentosView" runat="server" OnItemCommand="rptDocumentos_ItemCommand">
                    <HeaderTemplate><div class="field" style="margin-top:14px"><label>Documentos da obra</label><div class="anexo-lista"></HeaderTemplate>
                    <ItemTemplate>
                        <div class="anexo-item">
                            <span><strong><%# Server.HtmlEncode(Convert.ToString(Eval("TipoDocumento"))) %></strong> - <%# Server.HtmlEncode(Convert.ToString(Eval("NomeDocumento"))) %> <span class="muted"><%# Tamanho(Eval("TamanhoBytes")) %></span></span>
                            <asp:LinkButton runat="server" CommandName="Baixar" CommandArgument='<%# Eval("DocumentoId") %>' CssClass="link-action" CausesValidation="false">Baixar</asp:LinkButton>
                        </div>
                    </ItemTemplate>
                    <FooterTemplate></div></div></FooterTemplate>
                </asp:Repeater>
            </div>
            <div class="modal-footer">
                <asp:Button ID="btnFecharView2" runat="server" Text="Fechar" CssClass="btn" OnClick="btnFecharView_Click" CausesValidation="false" />
            </div>
        </div>
    </asp:Panel>

    <asp:Panel ID="pnlCapa" runat="server" CssClass="modal-backdrop">
        <div class="modal">
            <div class="modal-header">
                <h2 class="modal-title">Capa e primeira página da caderneta</h2>
                <asp:LinkButton ID="btnFecharCapa" runat="server" CssClass="close" OnClick="btnFecharCapa_Click" CausesValidation="false">&times;</asp:LinkButton>
            </div>
            <div class="modal-body">
                <asp:Label ID="lblAvisoCapa" runat="server" CssClass="alert alert-error" Visible="false" style="display:block" />
                <div class="ficha-bloco">
                    <h3>Capa - Caderneta de Obra <span class="ficha-num"><asp:Label ID="cNumero" runat="server" /></span></h3>
                    <div class="detail-grid">
                    <div class="detail-item span-2"><small>Nome do profissional</small><strong><asp:Label ID="cProfissional" runat="server" /></strong></div>
                    <div class="detail-item"><small>Título do profissional</small><strong><asp:Label ID="cTitulo" runat="server" /></strong></div>
                    <div class="detail-item"><small>RT nº</small><strong><asp:Label ID="cRT" runat="server" /></strong></div>
                    <div class="detail-item"><small>Proprietário</small><strong><asp:Label ID="cProprietario" runat="server" /></strong></div>
                    <div class="detail-item"><small>Local da obra</small><strong><asp:Label ID="cLocal" runat="server" /></strong></div>
                    </div>
                </div>
                <div class="ficha-bloco">
                    <h3>Primeira página (recibo) - dados técnicos</h3>
                    <div class="detail-grid">
                    <div class="detail-item"><small>Nº de registro</small><strong><asp:Label ID="cRegistro" runat="server" /></strong></div>
                    <div class="detail-item"><small>CPF do profissional</small><strong><asp:Label ID="cCpfProf" runat="server" /></strong></div>
                    <div class="detail-item"><small>Empresa / construtor</small><strong><asp:Label ID="cEmpresa" runat="server" /></strong></div>
                    <div class="detail-item"><small>CPF/CNPJ do proprietário</small><strong><asp:Label ID="cDocProp" runat="server" /></strong></div>
                    <div class="detail-item"><small>Telefone do proprietário</small><strong><asp:Label ID="cTelefone" runat="server" /></strong></div>
                    <div class="detail-item"><small>Valor da obra</small><strong><asp:Label ID="cValor" runat="server" /></strong></div>
                    <div class="detail-item"><small>Área a construir</small><strong><asp:Label ID="cAreaConstruir" runat="server" /></strong></div>
                    <div class="detail-item"><small>Área a ampliar</small><strong><asp:Label ID="cAreaAmpliar" runat="server" /></strong></div>
                    <div class="detail-item"><small>Área a regularizar</small><strong><asp:Label ID="cAreaRegularizar" runat="server" /></strong></div>
                    <div class="detail-item"><small>Área a reformar</small><strong><asp:Label ID="cAreaReforma" runat="server" /></strong></div>
                    <div class="detail-item"><small>Área total edificada</small><strong><asp:Label ID="cAreaTotal" runat="server" /></strong></div>
                    <div class="detail-item"><small>Tipo de edificação</small><strong><asp:Label ID="cTipo" runat="server" /></strong></div>
                    <div class="detail-item"><small>Atividade técnica</small><strong><asp:Label ID="cAtividade" runat="server" /></strong></div>
                    </div>
                </div>
                <uc:Assinaturas ID="ucAssinaturas" runat="server" />
            </div>
            <div class="modal-footer">
                <asp:Button ID="btnImprimirView" runat="server" Text="Imprimir" CssClass="btn" OnClientClick="window.print(); return false;" UseSubmitBehavior="false" />
                <asp:Button ID="btnFecharCapa2" runat="server" Text="Fechar" CssClass="btn" OnClick="btnFecharCapa_Click" CausesValidation="false" />
            </div>
        </div>
    </asp:Panel>
</asp:Content>
