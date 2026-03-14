<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="telaInicial.aspx.cs" Inherits="Locadora.telaInicial" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet"/>
    <link href="estilo.css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>       
        <asp:Label ID="lblTitulo" runat="server" Text="LocaDemais"></asp:Label>
        <p>
         <textarea id="TextArea1" name="S1">Termos da LocaDemais</textarea></p>
        <asp:RadioButtonList ID="rblTermos" runat="server"  AutoPostBack="True" Width="119px" OnSelectedIndexChanged="rblTermos_SelectedIndexChanged">
            <asp:ListItem>Aceitar</asp:ListItem>
            <asp:ListItem>Não Aceitar</asp:ListItem>
        </asp:RadioButtonList>
        <asp:Button ID="btnProx" runat="server" OnClick="Button1_Click" Text="Proxima Pagina" PostBackUrl="~/fCad1.aspx"/>
    </form>
</body>
</html>
