using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebApplication1.Modelos;
using WebApplication1.Utilitarios;

namespace WebApplication1.Dados
{
    public static class ReciboDAO
    {
        public static DataTable Listar(string pesquisa, string status, string periodo)
        {
            string sql = @"SELECT r.ReciboId, r.Numero, o.Nome AS Obra, p.NomeRazaoSocial AS Proprietario,
                                  r.DataEmissao, r.Valor, r.Status
                           FROM Recibos r
                           INNER JOIN Obras o ON o.ObraId = r.ObraId
                           INNER JOIN Proprietarios p ON p.ProprietarioId = r.ProprietarioId
                           WHERE 1 = 1";
            List<SqlParameter> ps = new List<SqlParameter>();
            if (!string.IsNullOrWhiteSpace(pesquisa))
            {
                sql += " AND (r.Numero LIKE @p OR o.Nome LIKE @p OR p.NomeRazaoSocial LIKE @p OR r.ReferenteA LIKE @p)";
                ps.Add(Banco.P("@p", "%" + pesquisa.Trim() + "%"));
            }
            if (!string.IsNullOrEmpty(status))
            {
                sql += " AND r.Status = @status";
                ps.Add(Banco.P("@status", status));
            }
            if (periodo == "mes")
                sql += " AND r.DataEmissao >= DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1)";
            else if (periodo == "90")
                sql += " AND r.DataEmissao >= DATEADD(DAY, -90, CAST(GETDATE() AS DATE))";

            sql += " ORDER BY r.DataEmissao DESC, r.ReciboId DESC";
            return Banco.Consultar(sql, ps.ToArray());
        }

        public static Recibo Obter(int id)
        {
            string sql = @"SELECT r.*, o.Nome AS ObraNome, p.NomeRazaoSocial AS ProprietarioNome, f.Descricao AS FormaNome
                           FROM Recibos r
                           INNER JOIN Obras o ON o.ObraId = r.ObraId
                           INNER JOIN Proprietarios p ON p.ProprietarioId = r.ProprietarioId
                           LEFT JOIN FormasPagamento f ON f.FormaPagamentoId = r.FormaPagamentoId
                           WHERE r.ReciboId = @id";
            DataTable dt = Banco.Consultar(sql, Banco.P("@id", id));
            if (dt.Rows.Count == 0) return null;
            DataRow x = dt.Rows[0];

            Recibo r = new Recibo();
            r.Id = (int)x["ReciboId"];
            r.Numero = Texto.Valor(x["Numero"]);
            r.ObraId = (int)x["ObraId"];
            r.Obra = Texto.Valor(x["ObraNome"]);
            r.ProprietarioId = (int)x["ProprietarioId"];
            r.Proprietario = Texto.Valor(x["ProprietarioNome"]);
            r.DataEmissao = (System.DateTime)x["DataEmissao"];
            r.Valor = (decimal)x["Valor"];
            r.FormaPagamentoId = Texto.Inteiro(x["FormaPagamentoId"]);
            r.FormaPagamento = Texto.Valor(x["FormaNome"]);
            r.Status = Texto.Valor(x["Status"]);
            r.ReferenteA = Texto.Valor(x["ReferenteA"]);
            r.Observacoes = Texto.Valor(x["Observacoes"]);
            return r;
        }

        public static void Salvar(Recibo r)
        {
            string sql;
            if (r.Id == 0)
            {
                sql = @"INSERT INTO Recibos (ObraId, ProprietarioId, DataEmissao, Valor, FormaPagamentoId, Status, ReferenteA, Observacoes)
                        VALUES (@obra, @prop, @data, @valor, @forma, @status, @ref, @obs)";
            }
            else
            {
                sql = @"UPDATE Recibos SET ObraId = @obra, ProprietarioId = @prop, DataEmissao = @data, Valor = @valor,
                        FormaPagamentoId = @forma, Status = @status, ReferenteA = @ref, Observacoes = @obs,
                        AtualizadoEm = SYSDATETIME()
                        WHERE ReciboId = @id";
            }
            Banco.Executar(sql,
                Banco.P("@id", r.Id), Banco.P("@obra", r.ObraId), Banco.P("@prop", r.ProprietarioId),
                Banco.P("@data", r.DataEmissao), Banco.P("@valor", r.Valor), Banco.P("@forma", r.FormaPagamentoId),
                Banco.P("@status", r.Status), Banco.P("@ref", r.ReferenteA), Banco.P("@obs", r.Observacoes));
        }
    }
}
