<%@ Page Language="C#" AutoEventWireup="true" ResponseEncoding="UTF-8" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Caderneta de Obras — Esqueci minha senha</title>
    <link rel="stylesheet" href="login.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="cartao-acesso">
            <h1>Esqueci minha senha</h1>
            <p class="subtitulo">A redefinição de senha é feita pelo administrador do sistema.</p>
            <span class="mensagem-ok">
                Procure o administrador e peça a redefinição. Ele altera a senha em
                <strong>Usuários &gt; Editar</strong> e você já pode entrar com a nova senha.
            </span>
            <footer class="rodape-acesso">
                <a class="link-secundario" href="login.aspx">Voltar ao acesso</a>
            </footer>
        </div>
    </form>
</body>
</html>
