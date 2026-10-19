using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebApplication1.Modelos;
using WebApplication1.Utilitarios;

namespace WebApplication1.Dados
{
    public static class ProprietarioDAO
    {
        public static DataTable Listar(string pesquisa, string status, string ordem)
        {
            string sql = "SELECT ProprietarioId, NomeRazaoSocial, CpfCnpj, Email, Status FROM Proprietarios WHERE 1 = 1";
            List<SqlParameter> ps = new List<SqlParameter>();

            if (!string.IsNullOrWhiteSpace(pesquisa))
            {
                sql += " AND (NomeRazaoSocial LIKE @p OR Email LIKE @p";
                ps.Add(Banco.P("@p", "%" + pesquisa.Trim() + "%"));
                string digitos = Texto.SoDigitos(pesquisa);
                if (digitos != "")
                {
                    sql += " OR CpfCnpj LIKE @d";
                    ps.Add(Banco.P("@d", "%" + digitos + "%"));
                }
                sql += ")";
            }
            if (!string.IsNullOrEmpty(status))
            {
                sql += " AND Status = @status";
                ps.Add(Banco.P("@status", status));
            }
            sql += Texto.Ordenar(ordem, "NomeRazaoSocial", "CriadoEm");
            return Banco.Consultar(sql, ps.ToArray());
        }

        public static Proprietario Obter(int id)
        {
            DataTable dt = Banco.Consultar("SELECT * FROM Proprietarios WHERE ProprietarioId = @id", Banco.P("@id", id));
            if (dt.Rows.Count == 0) return null;
            DataRow r = dt.Rows[0];

            Proprietario p = new Proprietario();
            p.Id = (int)r["ProprietarioId"];
            p.NomeRazaoSocial = Texto.Valor(r["NomeRazaoSocial"]);
            p.CpfCnpj = Texto.Valor(r["CpfCnpj"]);
            p.Email = Texto.Valor(r["Email"]);
            p.Telefone = Texto.Valor(r["Telefone"]);
            p.Celular = Texto.Valor(r["Celular"]);
            p.Cep = Texto.Valor(r["Cep"]);
            p.Endereco = Texto.Valor(r["Endereco"]);
            p.Numero = Texto.Valor(r["Numero"]);
            p.Complemento = Texto.Valor(r["Complemento"]);
            p.Bairro = Texto.Valor(r["Bairro"]);
            p.Cidade = Texto.Valor(r["Cidade"]);
            p.Estado = Texto.Valor(r["Estado"]).Trim();
            p.Status = Texto.Valor(r["Status"]);
            p.AtualizadoEm = Texto.Data(r["AtualizadoEm"]) ?? Texto.Data(r["CriadoEm"]);
            return p;
        }

        public static void Salvar(Proprietario p)
        {
            string sql;
            if (p.Id == 0)
            {
                sql = @"INSERT INTO Proprietarios
                        (NomeRazaoSocial, CpfCnpj, Email, Telefone, Celular, Cep, Endereco, Numero, Complemento, Bairro, Cidade, Estado, Status)
                        VALUES (@nome, @doc, @email, @tel, @cel, @cep, @end, @num, @comp, @bairro, @cidade, @uf, @status)";
            }
            else
            {
                sql = @"UPDATE Proprietarios SET
                        NomeRazaoSocial = @nome, CpfCnpj = @doc, Email = @email, Telefone = @tel, Celular = @cel,
                        Cep = @cep, Endereco = @end, Numero = @num, Complemento = @comp, Bairro = @bairro,
                        Cidade = @cidade, Estado = @uf, Status = @status, AtualizadoEm = SYSDATETIME()
                        WHERE ProprietarioId = @id";
            }
            Banco.Executar(sql,
                Banco.P("@id", p.Id), Banco.P("@nome", p.NomeRazaoSocial), Banco.P("@doc", p.CpfCnpj),
                Banco.P("@email", p.Email), Banco.P("@tel", p.Telefone), Banco.P("@cel", p.Celular),
                Banco.P("@cep", p.Cep), Banco.P("@end", p.Endereco), Banco.P("@num", p.Numero),
                Banco.P("@comp", p.Complemento), Banco.P("@bairro", p.Bairro), Banco.P("@cidade", p.Cidade),
                Banco.P("@uf", p.Estado), Banco.P("@status", p.Status));
        }

        public static void Excluir(int id)
        {
            Banco.Executar("DELETE FROM Proprietarios WHERE ProprietarioId = @id", Banco.P("@id", id));
        }
    }
}
