<%@ Page Title="Usuários" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="usuarios.aspx.cs" Inherits="WebApplication1.usuarios" %>
<asp:Content ID="Title" ContentPlaceHolderID="TitleContent" runat="server">Usuários</asp:Content>
<asp:Content ID="Breadcrumb" ContentPlaceHolderID="BreadcrumbContent" runat="server">Usuários</asp:Content>
<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-header">
        <div>
            <div class="eyebrow">Administração</div>
            <h1 class="page-title">Usuários</h1>
            <p class="page-description">Administre os usuários do sistema, seus perfis e status.</p>
        </div>
        <div class="actions">
            <asp:Button ID="btnNovo" runat="server" Text="+ Novo usuário" CssClass="btn btn-primary" OnClick="btnNovo_Click" CausesValidation="false" />
        </div>
    </div>

    <div class="filter-card">
        <div class="filter-grid">
            <div class="field wide"><label>Pesquisar</label>
                <asp:TextBox ID="txtPesquisa" runat="server" CssClass="input" placeholder="Nome, usuário, e-mail ou CPF" />
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

    <asp:Panel ID="pnlSolicitacoes" runat="server" Visible="false" CssClass="table-card" style="margin-bottom:16px">
        <div class="table-toolbar"><strong>Solicitações de cadastro pendentes</strong></div>
        <div class="table-wrap">
            <asp:GridView ID="gvSolicitacoes" runat="server" AutoGenerateColumns="False" CssClass="data-table" GridLines="None"
                DataKeyNames="SolicitacaoCadastroId" OnRowCommand="gvSolicitacoes_RowCommand">
                <Columns>
                <asp:BoundField DataField="Nome" HeaderText="Nome" />
                <asp:BoundField DataField="Email" HeaderText="E-mail" />
                <asp:BoundField DataField="Telefone" HeaderText="Telefone" />
                <asp:BoundField DataField="Mensagem" HeaderText="Mensagem" />
                <asp:TemplateField HeaderText="Solicitado em"><ItemTemplate><%# FormatarData(Eval("SolicitadoEm")) %></ItemTemplate></asp:TemplateField>
                <asp:TemplateField HeaderText="Ações" ItemStyle-CssClass="actions-cell"><ItemTemplate>
                        <asp:LinkButton runat="server" CommandName="Criar" CommandArgument='<%# Eval("SolicitacaoCadastroId") %>' CssClass="link-action" CausesValidation="false">Criar usuário</asp:LinkButton>
                        <asp:LinkButton runat="server" CommandName="Rejeitar" CommandArgument='<%# Eval("SolicitacaoCadastroId") %>' CssClass="link-action" CausesValidation="false" OnClientClick="return confirm('Rejeitar esta solicitação?');">Rejeitar</asp:LinkButton>
                </ItemTemplate></asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </asp:Panel>
    <div class="table-card">
        <div class="table-toolbar"><strong>Registros cadastrados</strong><asp:Label ID="lblTotal" runat="server" CssClass="muted" /></div>
        <div class="table-wrap">
            <asp:GridView ID="gvDados" runat="server" AutoGenerateColumns="False" CssClass="data-table" GridLines="None"
                DataKeyNames="UsuarioId" AllowPaging="True" PageSize="10" UseAccessibleHeader="True" ShowHeaderWhenEmpty="True"
                OnPageIndexChanging="gvDados_PageIndexChanging" OnRowCommand="gvDados_RowCommand">
                <PagerStyle CssClass="grid-pager" />
                <EmptyDataRowStyle CssClass="empty-row" />
                <EmptyDataTemplate>Nenhum registro encontrado.</EmptyDataTemplate>
                <Columns>
                <asp:BoundField DataField="Nome" HeaderText="Nome" />
                <asp:BoundField DataField="Usuario" HeaderText="Usuário" />
                <asp:BoundField DataField="Perfil" HeaderText="Perfil" />
                <asp:TemplateField HeaderText="Status"><ItemTemplate><span class="status <%# ClasseStatus(Eval("Status")) %>"><%# Eval("Status") %></span></ItemTemplate></asp:TemplateField>
                <asp:TemplateField HeaderText="Ações" ItemStyle-CssClass="actions-cell"><ItemTemplate>
                        <asp:LinkButton runat="server" CommandName="Ver" CommandArgument='<%# Eval("UsuarioId") %>' CssClass="link-action" CausesValidation="false">Ver</asp:LinkButton>
                        <asp:LinkButton runat="server" CommandName="Editar" CommandArgument='<%# Eval("UsuarioId") %>' CssClass="link-action" CausesValidation="false">Editar</asp:LinkButton>
                        <asp:LinkButton runat="server" CommandName="Alternar" CommandArgument='<%# Eval("UsuarioId") %>' CssClass="link-action" CausesValidation="false" OnClientClick="return confirm('Alterar o status deste usuário?');">Ativar/Inativar</asp:LinkButton>
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
                        <label class="required">Nome completo</label>
                        <asp:TextBox ID="txtNome" runat="server" CssClass="input" />
                    </div>
                    <div class="field">
                        <label class="required">Usuário (login)</label>
                        <asp:TextBox ID="txtUsuario" runat="server" CssClass="input" />
                    </div>
                    <div class="field">
                        <label>Matrícula</label>
                        <asp:TextBox ID="txtMatricula" runat="server" CssClass="input" />
                    </div>
                    <div class="field">
                        <label class="required">CPF</label>
                        <asp:TextBox ID="txtCpf" runat="server" CssClass="input" placeholder="000.000.000-00" />
                    </div>
                    <div class="field">
                        <label class="required">E-mail</label>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="input" />
                    </div>
                    <div class="field">
                        <label>Telefone</label>
                        <asp:TextBox ID="txtTelefone" runat="server" CssClass="input" />
                    </div>
                    <div class="field">
                        <label class="required">Perfil</label>
                        <asp:DropDownList ID="ddlPerfil" runat="server" CssClass="select"></asp:DropDownList>
                    </div>
                    <div class="field">
                        <label>Status</label>
                        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="select"><asp:ListItem Value="Ativo">Ativo</asp:ListItem><asp:ListItem Value="Inativo">Inativo</asp:ListItem></asp:DropDownList>
                    </div>
                    <div class="field">
                        <label>Senha</label>
                        <asp:TextBox ID="txtSenha" runat="server" CssClass="input" TextMode="Password" autocomplete="new-password" />
                    </div>
                    <div class="field">
                        <label>Confirmar senha</label>
                        <asp:TextBox ID="txtConfirmaSenha" runat="server" CssClass="input" TextMode="Password" autocomplete="new-password" />
                    </div>
                    <div class="field span-2"><asp:Label ID="lblDicaSenha" runat="server" CssClass="muted" /></div>
                </div>
                <asp:HiddenField ID="hfSolicitacaoId" runat="server" />
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
                    <div class="detail-item span-2"><small>Nome</small><strong><asp:Label ID="vNome" runat="server" /></strong></div>
                    <div class="detail-item"><small>Usuário</small><strong><asp:Label ID="vUsuario" runat="server" /></strong></div>
                    <div class="detail-item"><small>Matrícula</small><strong><asp:Label ID="vMatricula" runat="server" /></strong></div>
                    <div class="detail-item"><small>CPF</small><strong><asp:Label ID="vCpf" runat="server" /></strong></div>
                    <div class="detail-item"><small>E-mail</small><strong><asp:Label ID="vEmail" runat="server" /></strong></div>
                    <div class="detail-item"><small>Telefone</small><strong><asp:Label ID="vTelefone" runat="server" /></strong></div>
                    <div class="detail-item"><small>Perfil</small><strong><asp:Label ID="vPerfil" runat="server" /></strong></div>
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
