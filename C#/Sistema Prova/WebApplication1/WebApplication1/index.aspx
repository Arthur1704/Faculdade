<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaPrincipal.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WebApplication1.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="./index.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container container-demandas">
        <h2>Demandas Técnicas</h2>
        <table class="table tabela-demandas">
            <thead>
                <tr>
                    <th>#</th>
                    <th>Cliente</th>
                    <th>Equipamento</th>
                    <th>Defeito Relatado</th>
                    <th>Data Entrada</th>
                    <th>Status</th>
                    <th>Técnico</th>
                    <th>Ações</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>1</td>
                    <td>João Silva</td>
                    <td>Notebook Dell Inspiron</td>
                    <td>Não liga</td>
                    <td>10/06/2026</td>
                    <td><span class="status-badge status-analise">Em Análise</span></td>
                    <td>Carlos Souza</td>
                    <td>
                        <button class="btn btn-detalhes">Detalhes</button>
                        <button class="btn btn-editar">Editar</button>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</asp:Content>