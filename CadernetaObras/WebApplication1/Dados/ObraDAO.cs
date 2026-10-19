using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebApplication1.Modelos;
using WebApplication1.Utilitarios;

namespace WebApplication1.Dados
{
    public static class ObraDAO
    {
        public static DataTable Listar(string pesquisa, string status, string ordem)
        {
            string sql = @"SELECT o.ObraId, o.Nome AS Obra, p.NomeRazaoSocial AS Proprietario, t.Descricao AS Tipo,
                                  pr.Nome AS Responsavel, o.Status
                           FROM Obras o
                           INNER JOIN Proprietarios p ON p.ProprietarioId = o.ProprietarioId
                           INNER JOIN TiposObra t ON t.TipoObraId = o.TipoObraId
                           LEFT JOIN Profissionais pr ON pr.ProfissionalId = o.ProfissionalId
                           WHERE 1 = 1";
            List<SqlParameter> ps = new List<SqlParameter>();
            if (!string.IsNullOrWhiteSpace(pesquisa))
            {
                sql += @" AND (o.Nome LIKE @p OR p.NomeRazaoSocial LIKE @p OR t.Descricao LIKE @p OR o.EnderecoObra LIKE @p
                               OR pr.Nome LIKE @p OR o.NumeroCaderneta LIKE @p OR o.NumeroRT LIKE @p)";
                ps.Add(Banco.P("@p", "%" + pesquisa.Trim() + "%"));
            }
            if (!string.IsNullOrEmpty(status))
            {
                sql += " AND o.Status = @status";
                ps.Add(Banco.P("@status", status));
            }
            sql += Texto.Ordenar(ordem, "o.Nome", "o.CriadoEm");
            return Banco.Consultar(sql, ps.ToArray());
        }

        public static Obra Obter(int id)
        {
            string sql = @"SELECT o.*, p.NomeRazaoSocial AS ProprietarioNome, t.Descricao AS TipoNome,
                                  a.Descricao AS AtividadeNome, pr.Nome AS ProfissionalNome
                           FROM Obras o
                           INNER JOIN Proprietarios p ON p.ProprietarioId = o.ProprietarioId
                           INNER JOIN TiposObra t ON t.TipoObraId = o.TipoObraId
                           LEFT JOIN AtividadesTecnicas a ON a.AtividadeTecnicaId = o.AtividadeTecnicaId
                           LEFT JOIN Profissionais pr ON pr.ProfissionalId = o.ProfissionalId
                           WHERE o.ObraId = @id";
            DataTable dt = Banco.Consultar(sql, Banco.P("@id", id));
            if (dt.Rows.Count == 0) return null;
            DataRow r = dt.Rows[0];

            Obra o = new Obra();
            o.Id = (int)r["ObraId"];
            o.Nome = Texto.Valor(r["Nome"]);
            o.ProprietarioId = (int)r["ProprietarioId"];
            o.Proprietario = Texto.Valor(r["ProprietarioNome"]);
            o.TipoObraId = (int)r["TipoObraId"];
            o.TipoObra = Texto.Valor(r["TipoNome"]);
            o.AtividadeTecnicaId = Texto.Inteiro(r["AtividadeTecnicaId"]);
            o.AtividadeTecnica = Texto.Valor(r["AtividadeNome"]);
            o.ProfissionalId = Texto.Inteiro(r["ProfissionalId"]);
            o.Profissional = Texto.Valor(r["ProfissionalNome"]);
            o.NumeroRT = Texto.Valor(r["NumeroRT"]);
            o.Empresa = Texto.Valor(r["Empresa"]);
            o.NumeroCaderneta = Texto.Valor(r["NumeroCaderneta"]);
            o.ValorObra = Texto.Decimal(r["ValorObra"]);
            o.DataInicio = Texto.Data(r["DataInicio"]);
            o.PrevisaoTermino = Texto.Data(r["PrevisaoTermino"]);
            o.EnderecoObra = Texto.Valor(r["EnderecoObra"]);
            o.Status = Texto.Valor(r["Status"]);
            o.AreaConstruir = Texto.Decimal(r["AreaConstruir"]);
            o.AreaAmpliar = Texto.Decimal(r["AreaAmpliar"]);
            o.AreaRegularizar = Texto.Decimal(r["AreaRegularizar"]);
            o.AreaReforma = Texto.Decimal(r["AreaReforma"]);
            o.AreaTotal = Texto.Decimal(r["AreaTotal"]) ?? 0;
            o.Observacoes = Texto.Valor(r["Observacoes"]);
            o.AtualizadoEm = Texto.Data(r["AtualizadoEm"]) ?? Texto.Data(r["CriadoEm"]);
            return o;
        }

        // Reúne os dados da obra, do responsável técnico e do proprietário.
        // Usado na capa, no termo de conclusão e no PDF ("aproveita os dados já cadastrados").
        public static CapaObra ObterCapa(int obraId)
        {
            string sql = @"SELECT o.ObraId, o.NumeroCaderneta, o.Nome, o.ProfissionalId, o.NumeroRT, o.Empresa, o.EnderecoObra,
                                  o.AreaConstruir, o.AreaAmpliar, o.AreaRegularizar, o.AreaReforma, o.AreaTotal,
                                  o.ValorObra, o.DataInicio, o.Status,
                                  pr.Nome AS ProfissionalNome, pr.Cpf AS ProfissionalCpf, pr.NumeroRegistro,
                                  tp.Descricao AS TituloProfissional, tr.Sigla AS TipoRegistro,
                                  p.NomeRazaoSocial AS ProprietarioNome, p.CpfCnpj AS ProprietarioCpfCnpj,
                                  ISNULL(p.Celular, p.Telefone) AS ProprietarioTelefone,
                                  t.Descricao AS TipoEdificacao, a.Descricao AS AtividadeTecnica
                           FROM Obras o
                           INNER JOIN Proprietarios p ON p.ProprietarioId = o.ProprietarioId
                           INNER JOIN TiposObra t ON t.TipoObraId = o.TipoObraId
                           LEFT JOIN AtividadesTecnicas a ON a.AtividadeTecnicaId = o.AtividadeTecnicaId
                           LEFT JOIN Profissionais pr ON pr.ProfissionalId = o.ProfissionalId
                           LEFT JOIN TiposProfissional tp ON tp.TipoProfissionalId = pr.TipoProfissionalId
                           LEFT JOIN TiposRegistroProfissional tr ON tr.TipoRegistroId = pr.TipoRegistroId
                           WHERE o.ObraId = @id";
            DataTable dt = Banco.Consultar(sql, Banco.P("@id", obraId));
            if (dt.Rows.Count == 0) return null;
            DataRow r = dt.Rows[0];

            CapaObra c = new CapaObra();
            c.ObraId = (int)r["ObraId"];
            c.NumeroCaderneta = Texto.Valor(r["NumeroCaderneta"]);
            c.NomeObra = Texto.Valor(r["Nome"]);
            c.ProfissionalId = Texto.Inteiro(r["ProfissionalId"]);
            c.ProfissionalNome = Texto.Valor(r["ProfissionalNome"]);
            c.TituloProfissional = Texto.Valor(r["TituloProfissional"]);
            c.TipoRegistro = Texto.Valor(r["TipoRegistro"]);
            c.NumeroRegistro = Texto.Valor(r["NumeroRegistro"]);
            c.ProfissionalCpf = Texto.Valor(r["ProfissionalCpf"]);
            c.NumeroRT = Texto.Valor(r["NumeroRT"]);
            c.Empresa = Texto.Valor(r["Empresa"]);
            c.ProprietarioNome = Texto.Valor(r["ProprietarioNome"]);
            c.ProprietarioCpfCnpj = Texto.Valor(r["ProprietarioCpfCnpj"]);
            c.ProprietarioTelefone = Texto.Valor(r["ProprietarioTelefone"]);
            c.LocalObra = Texto.Valor(r["EnderecoObra"]);
            c.TipoEdificacao = Texto.Valor(r["TipoEdificacao"]);
            c.AtividadeTecnica = Texto.Valor(r["AtividadeTecnica"]);
            c.AreaConstruir = Texto.Decimal(r["AreaConstruir"]) ?? 0;
            c.AreaAmpliar = Texto.Decimal(r["AreaAmpliar"]) ?? 0;
            c.AreaRegularizar = Texto.Decimal(r["AreaRegularizar"]) ?? 0;
            c.AreaReforma = Texto.Decimal(r["AreaReforma"]) ?? 0;
            c.AreaTotal = Texto.Decimal(r["AreaTotal"]) ?? 0;
            c.ValorObra = Texto.Decimal(r["ValorObra"]);
            c.DataInicio = Texto.Data(r["DataInicio"]);
            c.StatusObra = Texto.Valor(r["Status"]);
            return c;
        }

        public static int? ObterProprietarioId(int obraId)
        {
            return Texto.Inteiro(Banco.Escalar("SELECT ProprietarioId FROM Obras WHERE ObraId = @id", Banco.P("@id", obraId)));
        }

        // Grava a obra. Devolve o ID (necessário para gravar os documentos de uma obra nova).
        public static int Salvar(Obra o)
        {
            string sql;
            if (o.Id == 0)
            {
                sql = @"INSERT INTO Obras (Nome, ProprietarioId, TipoObraId, AtividadeTecnicaId, ProfissionalId, NumeroRT, Empresa,
                                           NumeroCaderneta, ValorObra, DataInicio, PrevisaoTermino, EnderecoObra, Status,
                                           AreaConstruir, AreaAmpliar, AreaRegularizar, AreaReforma, Observacoes)
                        VALUES (@nome, @prop, @tipo, @ativ, @prof, @rt, @empresa, @caderneta, @valor, @inicio, @termino, @end, @status,
                                @areaC, @areaA, @areaG, @areaR, @obs);
                        SELECT CAST(SCOPE_IDENTITY() AS INT);";
            }
            else
            {
                sql = @"UPDATE Obras SET Nome = @nome, ProprietarioId = @prop, TipoObraId = @tipo, AtividadeTecnicaId = @ativ,
                        ProfissionalId = @prof, NumeroRT = @rt, Empresa = @empresa, NumeroCaderneta = @caderneta, ValorObra = @valor,
                        DataInicio = @inicio, PrevisaoTermino = @termino, EnderecoObra = @end, Status = @status,
                        AreaConstruir = @areaC, AreaAmpliar = @areaA, AreaRegularizar = @areaG, AreaReforma = @areaR,
                        Observacoes = @obs, AtualizadoEm = SYSDATETIME()
                        WHERE ObraId = @id;
                        SELECT @id;";
            }
            object id = Banco.Escalar(sql,
                Banco.P("@id", o.Id), Banco.P("@nome", o.Nome), Banco.P("@prop", o.ProprietarioId),
                Banco.P("@tipo", o.TipoObraId), Banco.P("@ativ", o.AtividadeTecnicaId), Banco.P("@prof", o.ProfissionalId),
                Banco.P("@rt", o.NumeroRT), Banco.P("@empresa", o.Empresa), Banco.P("@caderneta", o.NumeroCaderneta),
                Banco.P("@valor", o.ValorObra), Banco.P("@inicio", o.DataInicio), Banco.P("@termino", o.PrevisaoTermino),
                Banco.P("@end", o.EnderecoObra), Banco.P("@status", o.Status),
                Banco.P("@areaC", o.AreaConstruir), Banco.P("@areaA", o.AreaAmpliar),
                Banco.P("@areaG", o.AreaRegularizar), Banco.P("@areaR", o.AreaReforma), Banco.P("@obs", o.Observacoes));
            return Convert.ToInt32(id);
        }

        // Usado pelo termo de conclusão: ao concluir o termo, a obra passa a "Concluída"
        public static void AtualizarStatus(int obraId, string status)
        {
            Banco.Executar("UPDATE Obras SET Status = @status, AtualizadoEm = SYSDATETIME() WHERE ObraId = @id",
                Banco.P("@id", obraId), Banco.P("@status", status));
        }

        public static void Excluir(int id)
        {
            Banco.Executar("DELETE FROM Obras WHERE ObraId = @id", Banco.P("@id", id));
        }

        // ---------- Documentos da obra (ART/RRT, projeto aprovado, alvará...) ----------
        public static DataTable ListarDocumentos(int obraId)
        {
            return Banco.Consultar(
                @"SELECT DocumentoId, NomeDocumento, TipoDocumento, NomeOriginal, TamanhoBytes
                  FROM ObraDocumentos WHERE ObraId = @id ORDER BY DocumentoId", Banco.P("@id", obraId));
        }

        public static ObraDocumento ObterDocumento(int documentoId)
        {
            DataTable dt = Banco.Consultar("SELECT * FROM ObraDocumentos WHERE DocumentoId = @id", Banco.P("@id", documentoId));
            if (dt.Rows.Count == 0) return null;
            return MapearDocumento(dt.Rows[0]);
        }

        public static List<ObraDocumento> ObterDocumentosDaObra(int obraId)
        {
            List<ObraDocumento> lista = new List<ObraDocumento>();
            DataTable dt = Banco.Consultar("SELECT * FROM ObraDocumentos WHERE ObraId = @id", Banco.P("@id", obraId));
            foreach (DataRow r in dt.Rows) lista.Add(MapearDocumento(r));
            return lista;
        }

        private static ObraDocumento MapearDocumento(DataRow r)
        {
            ObraDocumento d = new ObraDocumento();
            d.Id = (int)r["DocumentoId"];
            d.ObraId = (int)r["ObraId"];
            d.NomeDocumento = Texto.Valor(r["NomeDocumento"]);
            d.TipoDocumento = Texto.Valor(r["TipoDocumento"]);
            d.NomeOriginal = Texto.Valor(r["NomeOriginal"]);
            d.CaminhoArquivo = Texto.Valor(r["CaminhoArquivo"]);
            d.ContentType = Texto.Valor(r["ContentType"]);
            return d;
        }

        public static void InserirDocumento(ObraDocumento d)
        {
            Banco.Executar(
                @"INSERT INTO ObraDocumentos (ObraId, NomeDocumento, TipoDocumento, NomeOriginal, CaminhoArquivo, ContentType, TamanhoBytes)
                  VALUES (@obra, @nome, @tipo, @original, @caminho, @contentType, @tamanho)",
                Banco.P("@obra", d.ObraId), Banco.P("@nome", d.NomeDocumento), Banco.P("@tipo", d.TipoDocumento),
                Banco.P("@original", d.NomeOriginal), Banco.P("@caminho", d.CaminhoArquivo),
                Banco.P("@contentType", d.ContentType), Banco.P("@tamanho", d.TamanhoBytes));
        }

        public static void ExcluirDocumento(int documentoId)
        {
            Banco.Executar("DELETE FROM ObraDocumentos WHERE DocumentoId = @id", Banco.P("@id", documentoId));
        }
    }
}
