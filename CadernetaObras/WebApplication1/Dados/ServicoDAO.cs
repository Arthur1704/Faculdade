using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebApplication1.Modelos;
using WebApplication1.Utilitarios;

namespace WebApplication1.Dados
{
    public static class ServicoDAO
    {
        public static DataTable Listar(string pesquisa, string status, string ordem)
        {
            string sql = @"SELECT s.ServicoId, s.Nome, u.Sigla AS Unidade, s.Descricao, s.Status
                           FROM Servicos s
                           LEFT JOIN UnidadesMedida u ON u.UnidadeMedidaId = s.UnidadeMedidaId
                           WHERE 1 = 1";
            List<SqlParameter> ps = new List<SqlParameter>();
            if (!string.IsNullOrWhiteSpace(pesquisa))
            {
                sql += " AND (s.Nome LIKE @p OR s.Descricao LIKE @p OR s.Referencia LIKE @p)";
                ps.Add(Banco.P("@p", "%" + pesquisa.Trim() + "%"));
            }
            if (!string.IsNullOrEmpty(status))
            {
                sql += " AND s.Status = @status";
                ps.Add(Banco.P("@status", status));
            }
            sql += Texto.Ordenar(ordem, "s.Nome", "s.CriadoEm");
            return Banco.Consultar(sql, ps.ToArray());
        }

        public static Servico Obter(int id)
        {
            string sql = @"SELECT s.*, u.Sigla AS UnidadeSigla
                           FROM Servicos s
                           LEFT JOIN UnidadesMedida u ON u.UnidadeMedidaId = s.UnidadeMedidaId
                           WHERE s.ServicoId = @id";
            DataTable dt = Banco.Consultar(sql, Banco.P("@id", id));
            if (dt.Rows.Count == 0) return null;
            DataRow r = dt.Rows[0];
            Servico s = new Servico();
            s.Id = (int)r["ServicoId"];
            s.Nome = Texto.Valor(r["Nome"]);
            s.UnidadeMedidaId = Texto.Inteiro(r["UnidadeMedidaId"]);
            s.Unidade = Texto.Valor(r["UnidadeSigla"]);
            s.Referencia = Texto.Valor(r["Referencia"]);
            s.Descricao = Texto.Valor(r["Descricao"]);
            s.Status = Texto.Valor(r["Status"]);
            s.AtualizadoEm = Texto.Data(r["AtualizadoEm"]) ?? Texto.Data(r["CriadoEm"]);
            return s;
        }

        public static void Salvar(Servico s)
        {
            string sql;
            if (s.Id == 0)
                sql = "INSERT INTO Servicos (Nome, UnidadeMedidaId, Referencia, Descricao, Status) VALUES (@nome, @unid, @ref, @desc, @status)";
            else
                sql = @"UPDATE Servicos SET Nome = @nome, UnidadeMedidaId = @unid, Referencia = @ref, Descricao = @desc,
                        Status = @status, AtualizadoEm = SYSDATETIME() WHERE ServicoId = @id";
            Banco.Executar(sql, Banco.P("@id", s.Id), Banco.P("@nome", s.Nome), Banco.P("@unid", s.UnidadeMedidaId),
                Banco.P("@ref", s.Referencia), Banco.P("@desc", s.Descricao), Banco.P("@status", s.Status));
        }

        public static void Excluir(int id)
        {
            Banco.Executar("DELETE FROM Servicos WHERE ServicoId = @id", Banco.P("@id", id));
        }
    }
}
