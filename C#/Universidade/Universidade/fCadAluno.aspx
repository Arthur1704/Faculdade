<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fCadAluno.aspx.cs" Inherits="Universidade.fCadAluno" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        #form1 {
            height: 322px;
            margin-left: 0px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
        <asp:Label ID="LabelNome" runat="server" Text="Nome:"></asp:Label>
            <br />
        </div>
        <asp:TextBox ID="TextBoxNome" runat="server" Height="22px" OnTextChanged="TextBoxNome_TextChanged" AutoPostBack="True"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="LabelRA" runat="server" Text="Ra:"></asp:Label>
        <br />
        <asp:TextBox ID="TextBoxRA" runat="server" Height="22px" OnTextChanged="TextBoxRA_TextChanged" AutoPostBack="True"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="LabelEstado" runat="server" Text="Estado:"></asp:Label>
        <br />
        <asp:DropDownList ID="ddlEstado" runat="server" AutoPostBack="True">
            <asp:ListItem>Selecione</asp:ListItem>
            <asp:ListItem>SP</asp:ListItem>
            <asp:ListItem>RJ</asp:ListItem>
            <asp:ListItem>MG</asp:ListItem>
            <asp:ListItem>SC</asp:ListItem>
        </asp:DropDownList>
        <p>
            <asp:Button ID="btnProx" runat="server" Text="Proxima Pagina" PostBackUrl="~/fCadCursos.aspx"/>
        </p>
    </form>
</body>
</html>
