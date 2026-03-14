<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fCad1.aspx.cs" Inherits="Locadora.fCad1" %>

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
            <asp:Label ID="lblTitulo" runat="server" Text="Preencha os Campos abaixo"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblNome" runat="server" Text="Nome Completo"></asp:Label>
        </div>
        <asp:TextBox ID="txtNome" runat="server" OnTextChanged="txtNome_TextChanged" AutoPostBack="True"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblData" runat="server" Text="Data Nascimento"></asp:Label>
        <br />
        <asp:TextBox ID="txtData" runat="server"  style="margin-bottom: 0px" AutoPostBack="True"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblCPF" runat="server" Text="CPF"></asp:Label>
        <br />
        <asp:TextBox ID="txtCPF" runat="server" style="margin-bottom: 0px" AutoPostBack="True"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblRG" runat="server" Text="RG"></asp:Label>
        <br />
        <asp:TextBox ID="txtRG" runat="server" style="margin-bottom: 0px" AutoPostBack="True"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblEndereco" runat="server" Text="Endereço"></asp:Label>
        <br />
        <asp:TextBox ID="txtEndereco" runat="server"  style="margin-bottom: 0px" AutoPostBack="True"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblNumero" runat="server" Text="Numero"></asp:Label>
        <br />
        <asp:TextBox ID="txtNumero" runat="server"  style="margin-bottom: 0px" AutoPostBack="True"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblBairro" runat="server" Text="Bairro"></asp:Label>
        <br />
        <asp:TextBox ID="txtBairro" runat="server"  style="margin-bottom: 0px" AutoPostBack="True"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblCidade" runat="server" Text="Cidade"></asp:Label>
        <br />
        <asp:TextBox ID="txtCidade" runat="server" style="margin-bottom: 0px" AutoPostBack="True"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblUF" runat="server" Text="UF"></asp:Label>
        <br />
        <asp:DropDownList ID="ddlUF" runat="server" OnSelectedIndexChanged="ddlUF_SelectedIndexChanged" AutoPostBack="True">
            <asp:ListItem Value=""></asp:ListItem>
            <asp:ListItem Value="AC">AC</asp:ListItem>
            <asp:ListItem Value="AL">AL</asp:ListItem>
            <asp:ListItem Value="AP">AP</asp:ListItem>
            <asp:ListItem Value="AM">AM</asp:ListItem>
            <asp:ListItem Value="BA">BA</asp:ListItem>
            <asp:ListItem Value="CE">CE</asp:ListItem>
            <asp:ListItem Value="DF">DF</asp:ListItem>
            <asp:ListItem Value="ES">ES</asp:ListItem>
            <asp:ListItem Value="GO">GO</asp:ListItem>
            <asp:ListItem Value="MA">MA</asp:ListItem>
            <asp:ListItem Value="MT">MT</asp:ListItem>
            <asp:ListItem Value="MS">MS</asp:ListItem>
            <asp:ListItem Value="MG">MG</asp:ListItem>
            <asp:ListItem Value="PA">PA</asp:ListItem>
            <asp:ListItem Value="PB">PB</asp:ListItem>
            <asp:ListItem Value="PR">PR</asp:ListItem>
            <asp:ListItem Value="PE">PE</asp:ListItem>
            <asp:ListItem Value="PI">PI</asp:ListItem>
            <asp:ListItem Value="RJ">RJ</asp:ListItem>
            <asp:ListItem Value="RN">RN</asp:ListItem>
            <asp:ListItem Value="RS">RS</asp:ListItem>
            <asp:ListItem Value="RO">RO</asp:ListItem>
            <asp:ListItem Value="RR">RR</asp:ListItem>
            <asp:ListItem Value="SC">SC</asp:ListItem>
            <asp:ListItem Value="SP">SP</asp:ListItem>
            <asp:ListItem Value="SE">SE</asp:ListItem>
            <asp:ListItem Value="TO">TO</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        
        <asp:Button ID="btnProx" runat="server" Text="Proxima Pagina" OnClick="btnProx_Click"/>
    </form>
</body>
</html>
