using System.Data;
using WebApplication1.Dados;

namespace WebApplication1.Dados
{
    public static class ListaDAO
    {
        public static DataTable Perfis()
        {
            return Banco.Consultar("SELECT PerfilId, Nome FROM Perfis ORDER BY Nome");
        }

        public static DataTable TiposProfissional()
        {
            return Banco.Consultar("SELECT TipoProfissionalId, Descricao FROM TiposProfissional ORDER BY TipoProfissionalId");
        }

        public static DataTable TiposRegistro()
        {
            return Banco.Consultar("SELECT TipoRegistroId, Sigla FROM TiposRegistroProfissional ORDER BY TipoRegistroId");
        }

        public static DataTable UnidadesMedida()
        {
            return Banco.Consultar("SELECT UnidadeMedidaId, Sigla FROM UnidadesMedida ORDER BY UnidadeMedidaId");
        }

        public static DataTable AtividadesTecnicas()
        {
            return Banco.Consultar("SELECT AtividadeTecnicaId, Descricao FROM AtividadesTecnicas ORDER BY AtividadeTecnicaId");
        }

        public static DataTable FormasPagamento()
        {
            return Banco.Consultar("SELECT FormaPagamentoId, Descricao FROM FormasPagamento ORDER BY FormaPagamentoId");
        }

        public static DataTable EtapasObra()
        {
            return Banco.Consultar("SELECT EtapaObraId, Descricao FROM EtapasObra WHERE Ativo = 1 ORDER BY Ordem");
        }

        public static DataTable Proprietarios(bool somenteAtivos, int incluirId)
        {
            string sql = "SELECT ProprietarioId, NomeRazaoSocial FROM Proprietarios";
            if (somenteAtivos) sql += " WHERE Status = 'Ativo' OR ProprietarioId = @incluir";
            sql += " ORDER BY NomeRazaoSocial";
            return Banco.Consultar(sql, Banco.P("@incluir", incluirId));
        }

        public static DataTable TiposObraAtivos(int incluirId)
        {
            return Banco.Consultar(
                "SELECT TipoObraId, Descricao FROM TiposObra WHERE Status = 'Ativo' OR TipoObraId = @incluir ORDER BY Descricao",
                Banco.P("@incluir", incluirId));
        }

        public static DataTable ProfissionaisAtivos(int incluirId)
        {
            return Banco.Consultar(
                "SELECT ProfissionalId, Nome FROM Profissionais WHERE Status = 'Ativo' OR ProfissionalId = @incluir ORDER BY Nome",
                Banco.P("@incluir", incluirId));
        }

        public static DataTable Obras()
        {
            return Banco.Consultar("SELECT ObraId, Nome FROM Obras ORDER BY Nome");
        }

        public static DataTable AnosTermos()
        {
            return Banco.Consultar("SELECT DISTINCT YEAR(DataConclusao) AS Ano FROM TermosConclusao ORDER BY Ano DESC");
        }
    }
}
