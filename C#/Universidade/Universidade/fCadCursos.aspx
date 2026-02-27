<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fCadCursos.aspx.cs" Inherits="Universidade.fCadCursos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Label ID="Label1" runat="server" Text="Cursos"></asp:Label>
        <asp:CheckBoxList ID="CheckBoxList1" runat="server">
            <asp:ListItem>Farmacia</asp:ListItem>
            <asp:ListItem>TADS</asp:ListItem>
            <asp:ListItem>Contabilidade</asp:ListItem>
        </asp:CheckBoxList>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Horários"></asp:Label>
        <asp:RadioButtonList ID="RadioButtonList1" runat="server">
            <asp:ListItem>Manhã</asp:ListItem>
            <asp:ListItem>Tarde</asp:ListItem>
            <asp:ListItem>Noite</asp:ListItem>
        </asp:RadioButtonList>
        <asp:Button ID="btnProx" runat="server"  Text="Finalizar" PostBackUrl="fFinal.aspx"/>
    </form>
</body>
</html>
