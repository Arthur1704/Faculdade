<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Assinaturas.ascx.cs" Inherits="WebApplication1.Assinaturas" %>
<%-- Assinatura digital do Responsável Técnico e do Proprietário (desenhada na tela).
     Grava a imagem, o IP, a data e a impressão digital (hash) do documento. --%>
<asp:HiddenField ID="hfImagem" runat="server" />
<asp:Label ID="lblErroAssinatura" runat="server" CssClass="alert alert-error" Visible="false" style="display:block" />
<div class="signature-grid">
    <asp:Repeater ID="rptPapeis" runat="server" OnItemCommand="rptPapeis_ItemCommand">
        <ItemTemplate>
            <div class="signature-box ficha-assinatura">
                <asp:Panel runat="server" Visible='<%# (bool)Eval("Assinado") %>'>
                    <img class="sig-imagem" src='<%# Eval("Imagem") %>' alt="Assinatura" />
                </asp:Panel>
                <asp:Panel runat="server" Visible='<%# (bool)Eval("Assinado") && !(bool)Eval("Valido") %>' CssClass="sig-aviso">
                    Atenção: o documento foi alterado depois desta assinatura. Assine novamente.
                </asp:Panel>
                <asp:Panel runat="server" Visible='<%# (bool)Eval("MostrarPad") %>' CssClass="sig-pad-area">
                    <canvas class="sig-pad" width="360" height="110"></canvas>
                    <div class="sig-botoes">
                        <button type="button" class="btn btn-small" onclick="limparAssinatura(this)">Limpar</button>
                        <asp:Button runat="server" CommandName="Assinar" CommandArgument='<%# Eval("Papel") %>' Text="Assinar"
                            CssClass="btn btn-primary btn-small" OnClientClick="return capturarAssinatura(this);" CausesValidation="false" />
                    </div>
                </asp:Panel>
                <div class="sig-titulo"><%# Eval("Titulo") %></div>
                <div class="sig-nome"><%# Eval("Nome") %></div>
                <asp:Panel runat="server" Visible='<%# (bool)Eval("Assinado") %>' CssClass="sig-info">
                    Assinado digitalmente em <%# Eval("DataTexto") %> - IP <%# Eval("Ip") %>
                    <asp:LinkButton runat="server" CommandName="Remover" CommandArgument='<%# Eval("Papel") %>' CssClass="link-action sig-remover"
                        Visible='<%# (bool)Eval("PodeRemover") %>' CausesValidation="false"
                        OnClientClick="return confirm('Remover esta assinatura?');">Remover</asp:LinkButton>
                </asp:Panel>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
