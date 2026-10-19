using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebApplication1.Modelos;
using WebApplication1.Utilitarios;

namespace WebApplication1.Dados
{
    public static class TermoConclusaoDAO
    {
        public static DataTable Listar(string pesquisa, string status, int? ano)
        {
            string sql = @"SELECT t.TermoConclusaoId, t.Numero, o.Nome AS Obra, p.NomeRazaoSocial AS Proprietario,
                                  t.DataConclusao, t.Status
                           FROM TermosConclusao t
                           INNER JOIN Obras o ON o.ObraId = t.ObraId
                           INNER JOIN Proprietarios p ON p.ProprietarioId = t.ProprietarioId
                           WHERE 1 = 1";
            List<SqlParameter> ps = new List<SqlParameter>();
            if (!string.IsNullOrWhiteSpace(pesquisa))
            {
                sql += " AND (t.Numero LIKE @p OR o.Nome LIKE @p OR p.NomeRazaoSocial LIKE @p OR t.DocumentoReferencia LIKE @p)";
                ps.Add(Banco.P("@p", "%" + pesquisa.Trim() + "%"));
            }
            if (!string.IsNullOrEmpty(status))
            {
                sql += " AND t.Status = @status";
                ps.Add(Banco.P("@status", status));
            }
            if (ano.HasValue)
            {
                sql += " AND YEAR(t.DataConclusao) = @ano";
                ps.Add(Banco.P("@ano", ano.Value));
            }
            sql += " ORDER BY t.DataConclusao DESC, t.TermoConclusaoId DESC";
            return Banco.Consultar(sql, ps.ToArray());
        }

        public static TermoConclusao Obter(int id)
        {
            string sql = @"SELECT t.*, o.Nome AS ObraNome, p.NomeRazaoSocial AS ProprietarioNome, u.Nome AS UsuarioNome
                           FROM TermosConclusao t
                           INNER JOIN Obras o ON o.ObraId = t.ObraId
                           INNER JOIN Proprietarios p ON p.ProprietarioId = t.ProprietarioId
                           INNER JOIN Usuarios u ON u.UsuarioId = t.UsuarioId
                           WHERE t.TermoConclusaoId = @id";
            DataTable dt = Banco.Consultar(sql, Banco.P("@id", id));
            if (dt.Rows.Count == 0) return null;
            DataRow x = dt.Rows[0];

            TermoConclusao t = new TermoConclusao();
            t.Id = (int)x["TermoConclusaoId"];
            t.Numero = Texto.Valor(x["Numero"]);
            t.ObraId = (int)x["ObraId"];
            t.Obra = Texto.Valor(x["ObraNome"]);
            t.ProprietarioId = (int)x["ProprietarioId"];
            t.Proprietario = Texto.Valor(x["ProprietarioNome"]);
            t.UsuarioId = (int)x["UsuarioId"];
            t.Usuario = Texto.Valor(x["UsuarioNome"]);
            t.DataConclusao = (System.DateTime)x["DataConclusao"];
            t.Status = Texto.Valor(x["Status"]);
            t.DocumentoReferencia = Texto.Valor(x["DocumentoReferencia"]);
            t.Declaracao = Texto.Valor(x["DeclaracaoConclusao"]);
            t.ObservacoesFinais = Texto.Valor(x["ObservacoesFinais"]);
            t.PdfFinal = Texto.Valor(x["PdfFinal"]);
            return t;
        }

        // Na edição o usuário que criou o termo continua sendo o mesmo. Devolve o ID do termo.
        public static int Salvar(TermoConclusao t)
        {
            string sql;
            if (t.Id == 0)
            {
                sql = @"INSERT INTO TermosConclusao (ObraId, ProprietarioId, UsuarioId, DataConclusao, Status, DocumentoReferencia, DeclaracaoConclusao, ObservacoesFinais)
                        VALUES (@obra, @prop, @usuario, @data, @status, @doc, @decl, @obs);
                        SELECT CAST(SCOPE_IDENTITY() AS INT);";
            }
            else
            {
                sql = @"UPDATE TermosConclusao SET ObraId = @obra, ProprietarioId = @prop, DataConclusao = @data, Status = @status,
                        DocumentoReferencia = @doc, DeclaracaoConclusao = @decl, ObservacoesFinais = @obs,
                        AtualizadoEm = SYSDATETIME()
                        WHERE TermoConclusaoId = @id;
                        SELECT @id;";
            }
            object id = Banco.Escalar(sql,
                Banco.P("@id", t.Id), Banco.P("@obra", t.ObraId), Banco.P("@prop", t.ProprietarioId),
                Banco.P("@usuario", t.UsuarioId), Banco.P("@data", t.DataConclusao), Banco.P("@status", t.Status),
                Banco.P("@doc", t.DocumentoReferencia), Banco.P("@decl", t.Declaracao), Banco.P("@obs", t.ObservacoesFinais));
            return Convert.ToInt32(id);
        }

        // Guarda o caminho do último PDF gerado (capa + termo)
        public static void AtualizarPdf(int termoId, string caminho)
        {
            Banco.Executar("UPDATE TermosConclusao SET PdfFinal = @pdf WHERE TermoConclusaoId = @id",
                Banco.P("@id", termoId), Banco.P("@pdf", caminho));
        }
    }
}
