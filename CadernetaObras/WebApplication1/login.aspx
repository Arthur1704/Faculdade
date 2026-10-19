<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WebApplication1.login" ResponseEncoding="UTF-8" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Caderneta de Obras — Acesso</title>
    <link rel="stylesheet" href="login.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="cartao-acesso">
            <h1>Caderneta de Obras</h1>
            <p class="subtitulo">Entre com seu usuário ou matrícula para acessar o diário de obra.</p>

            <asp:Label ID="lblErro" runat="server" CssClass="mensagem-erro" Visible="false" />

            <div class="campo">
                <asp:Label ID="lblUsuario" runat="server" AssociatedControlID="txtUsuario">Usuário ou matrícula</asp:Label>
                <asp:TextBox ID="txtUsuario" runat="server" CssClass="campo-input" placeholder="ex: eng.silva" autocomplete="username" />
            </div>

            <div class="campo">
                <asp:Label ID="lblSenha" runat="server" AssociatedControlID="txtSenha">Senha</asp:Label>
                <asp:TextBox ID="txtSenha" runat="server" CssClass="campo-input" TextMode="Password" placeholder="********" autocomplete="current-password" />
            </div>

            <div class="linha-opcoes">
                <label class="opcao-checkbox">
                    <asp:CheckBox ID="chkManterConectado" runat="server" />
                    <span>Manter conectado</span>
                </label>
                <asp:HyperLink ID="lnkEsqueciSenha" runat="server" CssClass="link-secundario" NavigateUrl="esqueci-senha.aspx">Esqueci minha senha</asp:HyperLink>
            </div>

            <asp:Button ID="btnAcessar" runat="server" CssClass="botao-acessar" Text="Acessar" OnClick="btnAcessar_Click" />

            <footer class="rodape-acesso">
                <span>Sem acesso ainda?</span>
                <asp:HyperLink ID="lnkCadastro" runat="server" CssClass="link-secundario" NavigateUrl="solicitar-cadastro.aspx">Solicitar cadastro</asp:HyperLink>
            </footer>
        </div>
    </form>
</body>
</html>
