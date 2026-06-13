<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaPrincipal.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WebApplication1.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
    <h2>Demandas Técnicas</h2>
    <table class="table table-striped table-hover table-bordered align-middle">
        <thead class="table-dark">
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
                <td>
                    <span class="badge bg-warning text-dark">
                        Em Análise
                    </span>
                </td>
                <td>Carlos Souza</td>
                <td>
                    <button class="btn btn-primary btn-sm">
                        Detalhes
                    </button>

                    <button class="btn btn-success btn-sm">
                        Editar
                    </button>
                </td>
            </tr>
            <tr>
                <td>2</td>
                <td>Maria Oliveira</td>
                <td>Impressora HP</td>
                <td>Falha na impressão</td>
                <td>09/06/2026</td>
                <td>
                    <span class="badge bg-info">
                        Em Manutenção
                    </span>
                </td>
                <td>Pedro Santos</td>
                <td>
                    <button class="btn btn-primary btn-sm">
                        Detalhes
                    </button>

                    <button class="btn btn-success btn-sm">
                        Editar
                    </button>
                </td>
            </tr>
        </tbody>
    </table>
</div>
</asp:Content>
