using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebApplication1.Modelos;
using WebApplication1.Utilitarios;

namespace WebApplication1.Dados
{
    public static class ProfissionalDAO
    {
        public static DataTable Listar(string pesquisa, string status, string ordem)
        {
            string sql = @"SELECT p.ProfissionalId, p.Nome, t.Descricao AS TipoProfissional,
                                  LTRIM(RTRIM(ISNULL(r.Sigla, '') + ' ' + ISNULL(p.NumeroRegistro, ''))) AS Registro,
                                  p.Status
                           FROM Profissionais p
                           INNER JOIN TiposProfissional t ON t.TipoProfissionalId = p.TipoProfissionalId
                           LEFT JOIN TiposRegistroProfissional r ON r.TipoRegistroId = p.TipoRegistroId
                           WHERE 1 = 1";
            List<SqlParameter> ps = new List<SqlParameter>();

            if (!string.IsNullOrWhiteSpace(pesquisa))
            {
                sql += " AND (p.Nome LIKE @p OR p.NumeroRegistro LIKE @p OR t.Descricao LIKE @p";
                ps.Add(Banco.P("@p", "%" + pesquisa.Trim() + "%"));
                string digitos = Texto.SoDigitos(pesquisa);
                if (digitos != "")
                {
                    sql += " OR p.Cpf LIKE @d";
                    ps.Add(Banco.P("@d", "%" + digitos + "%"));
                }
                sql += ")";
            }
            if (!string.IsNullOrEmpty(status))
            {
                sql += " AND p.Status = @status";
                ps.Add(Banco.P("@status", status));
            }
            sql += Texto.Ordenar(ordem, "p.Nome", "p.CriadoEm");
            return Banco.Consultar(sql, ps.ToArray());
        }

        public static Profissional Obter(int id)
        {
            string sql = @"SELECT p.*, t.Descricao AS TipoProfissionalNome, r.Sigla AS TipoRegistroSigla
                           FROM Profissionais p
                           INNER JOIN TiposProfissional t ON t.TipoProfissionalId = p.TipoProfissionalId
                           LEFT JOIN TiposRegistroProfissional r ON r.TipoRegistroId = p.TipoRegistroId
                           WHERE p.ProfissionalId = @id";
            DataTable dt = Banco.Consultar(sql, Banco.P("@id", id));
            if (dt.Rows.Count == 0) return null;
            DataRow r2 = dt.Rows[0];

            Profissional p = new Profissional();
            p.Id = (int)r2["ProfissionalId"];
            p.Nome = Texto.Valor(r2["Nome"]);
            p.Cpf = Texto.Valor(r2["Cpf"]);
            p.TipoProfissionalId = (int)r2["TipoProfissionalId"];
            p.TipoProfissional = Texto.Valor(r2["TipoProfissionalNome"]);
            p.TipoRegistroId = Texto.Inteiro(r2["TipoRegistroId"]);
            p.TipoRegistro = Texto.Valor(r2["TipoRegistroSigla"]);
            p.NumeroRegistro = Texto.Valor(r2["NumeroRegistro"]);
            p.Email = Texto.Valor(r2["Email"]);
            p.Telefone = Texto.Valor(r2["Telefone"]);
            p.Celular = Texto.Valor(r2["Celular"]);
            p.Status = Texto.Valor(r2["Status"]);
            p.Observacoes = Texto.Valor(r2["Observacoes"]);
            p.AtualizadoEm = Texto.Data(r2["AtualizadoEm"]) ?? Texto.Data(r2["CriadoEm"]);
            return p;
        }

        public static void Salvar(Profissional p)
        {
            string sql;
            if (p.Id == 0)
            {
                sql = @"INSERT INTO Profissionais
                        (Nome, Cpf, TipoProfissionalId, TipoRegistroId, NumeroRegistro, Email, Telefone, Celular, Status, Observacoes)
                        VALUES (@nome, @cpf, @tipo, @tipoReg, @numReg, @email, @tel, @cel, @status, @obs)";
            }
            else
            {
                sql = @"UPDATE Profissionais SET
                        Nome = @nome, Cpf = @cpf, TipoProfissionalId = @tipo, TipoRegistroId = @tipoReg,
                        NumeroRegistro = @numReg, Email = @email, Telefone = @tel, Celular = @cel,
                        Status = @status, Observacoes = @obs, AtualizadoEm = SYSDATETIME()
                        WHERE ProfissionalId = @id";
            }
            Banco.Executar(sql,
                Banco.P("@id", p.Id), Banco.P("@nome", p.Nome), Banco.P("@cpf", p.Cpf),
                Banco.P("@tipo", p.TipoProfissionalId), Banco.P("@tipoReg", p.TipoRegistroId),
                Banco.P("@numReg", p.NumeroRegistro), Banco.P("@email", p.Email), Banco.P("@tel", p.Telefone),
                Banco.P("@cel", p.Celular), Banco.P("@status", p.Status), Banco.P("@obs", p.Observacoes));
        }

        public static void Excluir(int id)
        {
            Banco.Executar("DELETE FROM Profissionais WHERE ProfissionalId = @id", Banco.P("@id", id));
        }
    }
}
