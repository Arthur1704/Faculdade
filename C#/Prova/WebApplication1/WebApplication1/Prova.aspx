<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Prova.aspx.cs" Inherits="WebApplication1.Prova" %>

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
        <asp:Label ID="Label1" runat="server" Text="TextBox"></asp:Label>
        <br />
        <asp:TextBox ID="txt1" runat="server" AutoPostBack="true"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="DropDownList" AutoPostBack="true"></asp:Label>
        <br />
        <asp:DropDownList ID="ddl1" runat="server" AutoPostBack="true">
            <asp:ListItem value="1" text="Valor 1"></asp:ListItem>
            <asp:ListItem value="2" text="Valor 2"></asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="CheckBoxList" AutoPostBack="true"></asp:Label>
        <asp:CheckBoxList ID="cxl1" runat="server">
            <asp:ListItem Value="1" Text="Valor 1"></asp:ListItem>
            <asp:ListItem Value="2" Text="Valor 2"></asp:ListItem>
        </asp:CheckBoxList>
        <br />
        <asp:Label ID="Label4" runat="server" Text="RadioButtonList" ></asp:Label>
        <asp:RadioButtonList ID="rbl1" runat="server" AutoPostBack="true">
            <asp:ListItem Value="1" Text="Valor 1"></asp:ListItem>
            <asp:ListItem Value="2" Text="Valor 2"></asp:ListItem>
        </asp:RadioButtonList>
        <br />
        <asp:Button ID="btnEnviar" runat="server" Text="Enviar" OnClick="btnEnviar_Click" />
        <br />
        <br />
        <br />
        <asp:Label ID="LabelTxt" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Label ID="Labelddl" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Label ID="LabelCheck" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Label ID="Labelrbl" runat="server" Text="Label"></asp:Label>
    </form>
</body>
</html>
