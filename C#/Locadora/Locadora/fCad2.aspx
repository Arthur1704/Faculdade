<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fCad2.aspx.cs" Inherits="Locadora.fCad2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet"/>
    <link href="css1.css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">

    <asp:Label ID="Label1" runat="server" Text="Estilo de Música Preferido"></asp:Label>
    <br />
    <asp:DropDownList ID="ddlMusica" runat="server">
        <asp:ListItem Text="Selecione" Value=""></asp:ListItem>
        <asp:ListItem>Rock</asp:ListItem>
        <asp:ListItem>Pop</asp:ListItem>
        <asp:ListItem>Sertanejo</asp:ListItem>
        <asp:ListItem>Funk</asp:ListItem>
        <asp:ListItem>Rap</asp:ListItem>
        <asp:ListItem>Eletrônica</asp:ListItem>
    </asp:DropDownList>

    <br /><br />

    <asp:Label ID="lblMusica" runat="server" Text="Escolha: "></asp:Label>

    <br /><br />

    <asp:Label ID="Label2" runat="server" Text="Categoria de Filme Preferida"></asp:Label>
    <br />
    <asp:DropDownList ID="ddlFilme" runat="server">
        <asp:ListItem Text="Selecione" Value=""></asp:ListItem>
        <asp:ListItem>Ação</asp:ListItem>
        <asp:ListItem>Comédia</asp:ListItem>
        <asp:ListItem>Drama</asp:ListItem>
        <asp:ListItem>Terror</asp:ListItem>
        <asp:ListItem>Romance</asp:ListItem>
        <asp:ListItem>Ficção Científica</asp:ListItem>
    </asp:DropDownList>

    <br /><br />

    <asp:Label ID="lblFilme" runat="server" Text="Escolha: "></asp:Label>

    <br /><br />

    <asp:Label ID="Label3" runat="server" Text="Possui videogame?"></asp:Label>
    <br />
    <asp:DropDownList ID="ddlVideoGame" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlVideoGame_SelectedIndexChanged">
        <asp:ListItem Text="Selecione" Value=""></asp:ListItem>
        <asp:ListItem>Sim</asp:ListItem>
        <asp:ListItem>Não</asp:ListItem>
    </asp:DropDownList>

    <br /><br />

    <asp:Label ID="lblVideoGame" runat="server" Text="Resposta: "></asp:Label>

    <br /><br />

    <asp:Panel ID="pnlModelos" runat="server" Visible="false">

        <asp:Label ID="Label4" runat="server" Text="Quais modelos?"></asp:Label>
        <br />

        <asp:DropDownList ID="ddlModelos" runat="server">
            <asp:ListItem Text="Selecione" Value=""></asp:ListItem>
            <asp:ListItem>PlayStation</asp:ListItem>
            <asp:ListItem>Xbox</asp:ListItem>
            <asp:ListItem>Nintendo Switch</asp:ListItem>
            <asp:ListItem>PC Gamer</asp:ListItem>
        </asp:DropDownList>

        <br /><br />

        <asp:Label ID="lblModelos" runat="server" Text="Modelo: "></asp:Label>

    </asp:Panel>

    <br /><br />

    <asp:Button ID="btnProximo" runat="server" Text="Próxima Página" OnClick="btnProximo_Click" />
    </form>
</body>
</html>
