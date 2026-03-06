<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Universidade.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        #TextArea1 {
            height: 109px;
            width: 239px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <p>
        &nbsp;</p>
    <p>
        <textarea id="TextArea1" name="S1">Termos da Universidade</textarea></p>
        <asp:RadioButtonList ID="rblTermos" runat="server"  AutoPostBack="True" Width="119px" OnSelectedIndexChanged="rblTermos_SelectedIndexChanged">
            <asp:ListItem>Aceitar</asp:ListItem>
            <asp:ListItem>Não Aceitar</asp:ListItem>
        </asp:RadioButtonList>
        <asp:Button ID="btnProx" runat="server" OnClick="Button1_Click" Text="Proxima Pagina" PostBackUrl="~/fCadAluno.aspx"/>
    </form>
</body>
</html>
