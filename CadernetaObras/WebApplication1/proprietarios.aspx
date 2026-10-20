<%@ Page Title="Proprietários" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="proprietarios.aspx.cs" Inherits="WebApplication1.proprietarios" %>
<asp:Content ID="Title" ContentPlaceHolderID="TitleContent" runat="server">Proprietários</asp:Content>
<asp:Content ID="Breadcrumb" ContentPlaceHolderID="BreadcrumbContent" runat="server">Proprietários</asp:Content>
<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-header">
        <div>
            <div class="eyebrow">Cadastros</div>
            <h1 class="page-title">Proprietários</h1>
            <p class="page-description">Consulte, cadastre e mantenha os proprietários das obras.</p>
        </div>
        <div class="actions">
            <asp:Button ID="btnNovo" runat="server" Text="+ Novo proprietário" CssClass="btn btn-primary" OnClick="btnNovo_Click" CausesValidation="false" />
        </div>
    </div>

    <div class="filter-card">
        <div class="filter-grid">
            <div class="field wide"><label>Pesquisar</label>
                <asp:TextBox ID="txtPesquisa" runat="server" CssClass="input" placeholder="Nome, CPF/CNPJ ou e-mail" />
            </div>
            <div class="field"><label>Status</label>
                <asp:DropDownList ID="ddlFiltroStatus" runat="server" CssClass="select"><asp:ListItem Value="">Todos</asp:ListItem><asp:ListItem Value="Ativo">Ativo</asp:ListItem><asp:ListItem Value="Inativo">Inativo</asp:ListItem><asp:ListItem Value="Pendente">Pendente</asp:ListItem></asp:DropDownList>
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
                DataKeyNames="ProprietarioId" AllowPaging="True" PageSize="10" UseAccessibleHeader="True" ShowHeaderWhenEmpty="True"
                OnPageIndexChanging="gvDados_PageIndexChanging" OnRowCommand="gvDados_RowCommand">
                <PagerStyle CssClass="grid-pager" />
                <EmptyDataRowStyle CssClass="empty-row" />
                <EmptyDataTemplate>Nenhum registro encontrado.</EmptyDataTemplate>
                <Columns>
                <asp:BoundField DataField="NomeRazaoSocial" HeaderText="Nome / Razão social" />
                <asp:TemplateField HeaderText="CPF/CNPJ"><ItemTemplate><%# FormatarDocumento(Eval("CpfCnpj")) %></ItemTemplate></asp:TemplateField>
                <asp:BoundField DataField="Email" HeaderText="E-mail" />
                <asp:TemplateField HeaderText="Status"><ItemTemplate><span class="status <%# ClasseStatus(Eval("Status")) %>"><%# Eval("Status") %></span></ItemTemplate></asp:TemplateField>
                <asp:TemplateField HeaderText="Ações" ItemStyle-CssClass="actions-cell"><ItemTemplate>
                        <asp:LinkButton runat="server" CommandName="Ver" CommandArgument='<%# Eval("ProprietarioId") %>' CssClass="link-action" CausesValidation="false">Ver</asp:LinkButton>
                        <asp:LinkButton runat="server" CommandName="Editar" CommandArgument='<%# Eval("ProprietarioId") %>' CssClass="link-action" CausesValidation="false">Editar</asp:LinkButton>
                        <asp:LinkButton runat="server" CommandName="Excluir" CommandArgument='<%# Eval("ProprietarioId") %>' CssClass="link-action" CausesValidation="false" OnClientClick="return confirm('Excluir este proprietário?');">Excluir</asp:LinkButton>
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
                        <label class="required">Nome / Razão social</label>
                        <asp:TextBox ID="txtNome" runat="server" CssClass="input" />
                    </div>
                    <div class="field">
                        <label class="required">CPF/CNPJ</label>
                        <asp:TextBox ID="txtCpfCnpj" runat="server" CssClass="input" placeholder="Somente números ou com máscara" />
                    </div>
                    <div class="field">
                        <label>E-mail</label>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="input" />
                    </div>
                    <div class="field">
                        <label>Telefone</label>
                        <asp:TextBox ID="txtTelefone" runat="server" CssClass="input" placeholder="(00) 0000-0000" />
                    </div>
                    <div class="field">
                        <label>Celular</label>
                        <asp:TextBox ID="txtCelular" runat="server" CssClass="input" placeholder="(00) 00000-0000" />
                    </div>
                    <div class="field">
                        <label>CEP</label>
                        <asp:TextBox ID="txtCep" runat="server" CssClass="input" placeholder="00000-000" />
                    </div>
                    <div class="field">
                        <label>Endereço</label>
                        <asp:TextBox ID="txtEndereco" runat="server" CssClass="input" />
                    </div>
                    <div class="field">
                        <label>Número</label>
                        <asp:TextBox ID="txtNumero" runat="server" CssClass="input" />
                    </div>
                    <div class="field">
                        <label>Complemento</label>
                        <asp:TextBox ID="txtComplemento" runat="server" CssClass="input" />
                    </div>
                    <div class="field">
                        <label>Bairro</label>
                        <asp:TextBox ID="txtBairro" runat="server" CssClass="input" />
                    </div>
                    <div class="field">
                        <label>Cidade</label>
                        <asp:TextBox ID="txtCidade" runat="server" CssClass="input" />
                    </div>
                    <div class="field">
                        <label>Estado</label>
                        <asp:DropDownList ID="ddlEstado" runat="server" CssClass="select"><asp:ListItem Value="">Selecione</asp:ListItem><asp:ListItem Value="AC">AC</asp:ListItem><asp:ListItem Value="AL">AL</asp:ListItem><asp:ListItem Value="AP">AP</asp:ListItem><asp:ListItem Value="AM">AM</asp:ListItem><asp:ListItem Value="BA">BA</asp:ListItem><asp:ListItem Value="CE">CE</asp:ListItem><asp:ListItem Value="DF">DF</asp:ListItem><asp:ListItem Value="ES">ES</asp:ListItem><asp:ListItem Value="GO">GO</asp:ListItem><asp:ListItem Value="MA">MA</asp:ListItem><asp:ListItem Value="MT">MT</asp:ListItem><asp:ListItem Value="MS">MS</asp:ListItem><asp:ListItem Value="MG">MG</asp:ListItem><asp:ListItem Value="PA">PA</asp:ListItem><asp:ListItem Value="PB">PB</asp:ListItem><asp:ListItem Value="PR">PR</asp:ListItem><asp:ListItem Value="PE">PE</asp:ListItem><asp:ListItem Value="PI">PI</asp:ListItem><asp:ListItem Value="RJ">RJ</asp:ListItem><asp:ListItem Value="RN">RN</asp:ListItem><asp:ListItem Value="RS">RS</asp:ListItem><asp:ListItem Value="RO">RO</asp:ListItem><asp:ListItem Value="RR">RR</asp:ListItem><asp:ListItem Value="SC">SC</asp:ListItem><asp:ListItem Value="SP">SP</asp:ListItem><asp:ListItem Value="SE">SE</asp:ListItem><asp:ListItem Value="TO">TO</asp:ListItem></asp:DropDownList>
                    </div>
                    <div class="field">
                        <label>Status</label>
                        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="select"><asp:ListItem Value="Ativo">Ativo</asp:ListItem><asp:ListItem Value="Inativo">Inativo</asp:ListItem></asp:DropDownList>
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
                    <div class="detail-item span-2"><small>Nome / Razão social</small><strong><asp:Label ID="vNome" runat="server" /></strong></div>
                    <div class="detail-item"><small>CPF/CNPJ</small><strong><asp:Label ID="vDoc" runat="server" /></strong></div>
                    <div class="detail-item"><small>E-mail</small><strong><asp:Label ID="vEmail" runat="server" /></strong></div>
                    <div class="detail-item"><small>Telefone</small><strong><asp:Label ID="vTelefone" runat="server" /></strong></div>
                    <div class="detail-item"><small>Celular</small><strong><asp:Label ID="vCelular" runat="server" /></strong></div>
                    <div class="detail-item span-2"><small>Endereço</small><strong><asp:Label ID="vEndereco" runat="server" /></strong></div>
                    <div class="detail-item"><small>Cidade / UF</small><strong><asp:Label ID="vCidade" runat="server" /></strong></div>
                    <div class="detail-item"><small>Status</small><strong><asp:Label ID="vStatus" runat="server" /></strong></div>
                    <div class="detail-item"><small>Última atualização</small><strong><asp:Label ID="vAtualizacao" runat="server" /></strong></div>
                </div>
            </div>
            <div class="modal-footer">
                <asp:Button ID="btnFecharView2" runat="server" Text="Fechar" CssClass="btn" OnClick="btnFecharView_Click" CausesValidation="false" />
            </div>
        </div>
    </asp:Panel>
</asp:Content>
