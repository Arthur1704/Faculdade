<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="solicitar-cadastro.aspx.cs" Inherits="WebApplication1.solicitar_cadastro" ResponseEncoding="UTF-8" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Caderneta de Obras — Solicitar cadastro</title>
    <link rel="stylesheet" href="login.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="cartao-acesso">
            <h1>Solicitar cadastro</h1>
            <p class="subtitulo">Preencha seus dados. O administrador vai analisar o pedido e liberar o seu acesso.</p>

            <asp:Label ID="lblErro" runat="server" CssClass="mensagem-erro" Visible="false" />
            <asp:Label ID="lblOk" runat="server" CssClass="mensagem-ok" Visible="false" />

            <asp:Panel ID="pnlFormulario" runat="server">
                <div class="campo">
                    <asp:Label ID="lblNome" runat="server" AssociatedControlID="txtNome">Nome completo</asp:Label>
                    <asp:TextBox ID="txtNome" runat="server" CssClass="campo-input" MaxLength="150" />
                </div>
                <div class="campo">
                    <asp:Label ID="lblEmail" runat="server" AssociatedControlID="txtEmail">E-mail</asp:Label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="campo-input" MaxLength="150" />
                </div>
                <div class="campo">
                    <asp:Label ID="lblCpf" runat="server" AssociatedControlID="txtCpf">CPF</asp:Label>
                    <asp:TextBox ID="txtCpf" runat="server" CssClass="campo-input" MaxLength="14" />
                </div>
                <div class="campo">
                    <asp:Label ID="lblTelefone" runat="server" AssociatedControlID="txtTelefone">Telefone</asp:Label>
                    <asp:TextBox ID="txtTelefone" runat="server" CssClass="campo-input" MaxLength="15" />
                </div>
                <div class="campo">
                    <asp:Label ID="lblMensagem" runat="server" AssociatedControlID="txtMensagem">Mensagem (opcional)</asp:Label>
                    <asp:TextBox ID="txtMensagem" runat="server" CssClass="campo-input" TextMode="MultiLine" Rows="3" MaxLength="500" />
                </div>
                <asp:Button ID="btnEnviar" runat="server" CssClass="botao-acessar" Text="Enviar solicitação" OnClick="btnEnviar_Click" />
            </asp:Panel>

            <footer class="rodape-acesso">
                <a class="link-secundario" href="login.aspx">Voltar ao acesso</a>
            </footer>
        </div>
    </form>
</body>
</html>
