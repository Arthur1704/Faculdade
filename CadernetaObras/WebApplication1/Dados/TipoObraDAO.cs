using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebApplication1.Modelos;
using WebApplication1.Utilitarios;

namespace WebApplication1.Dados
{
    public static class TipoObraDAO
    {
        public static DataTable Listar(string pesquisa, string status, string ordem)
        {
            string sql = "SELECT TipoObraId, Descricao, Observacoes, Status FROM TiposObra WHERE 1 = 1";
            List<SqlParameter> ps = new List<SqlParameter>();
            if (!string.IsNullOrWhiteSpace(pesquisa))
            {
                sql += " AND (Descricao LIKE @p OR Observacoes LIKE @p)";
                ps.Add(Banco.P("@p", "%" + pesquisa.Trim() + "%"));
            }
            if (!string.IsNullOrEmpty(status))
            {
                sql += " AND Status = @status";
                ps.Add(Banco.P("@status", status));
            }
            sql += Texto.Ordenar(ordem, "Descricao", "CriadoEm");
            return Banco.Consultar(sql, ps.ToArray());
        }

        public static TipoObra Obter(int id)
        {
            DataTable dt = Banco.Consultar("SELECT * FROM TiposObra WHERE TipoObraId = @id", Banco.P("@id", id));
            if (dt.Rows.Count == 0) return null;
            DataRow r = dt.Rows[0];
            TipoObra t = new TipoObra();
            t.Id = (int)r["TipoObraId"];
            t.Descricao = Texto.Valor(r["Descricao"]);
            t.Observacoes = Texto.Valor(r["Observacoes"]);
            t.Status = Texto.Valor(r["Status"]);
            t.AtualizadoEm = Texto.Data(r["AtualizadoEm"]) ?? Texto.Data(r["CriadoEm"]);
            return t;
        }

        public static void Salvar(TipoObra t)
        {
            string sql;
            if (t.Id == 0)
                sql = "INSERT INTO TiposObra (Descricao, Observacoes, Status) VALUES (@desc, @obs, @status)";
            else
                sql = "UPDATE TiposObra SET Descricao = @desc, Observacoes = @obs, Status = @status, AtualizadoEm = SYSDATETIME() WHERE TipoObraId = @id";
            Banco.Executar(sql, Banco.P("@id", t.Id), Banco.P("@desc", t.Descricao),
                Banco.P("@obs", t.Observacoes), Banco.P("@status", t.Status));
        }

        public static void Excluir(int id)
        {
            Banco.Executar("DELETE FROM TiposObra WHERE TipoObraId = @id", Banco.P("@id", id));
        }
    }
}
