using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebApplication1.Modelos;
using WebApplication1.Utilitarios;

namespace WebApplication1.Dados
{
    public static class RelatoVisitaDAO
    {
        public static DataTable Listar(string pesquisa, int? obraId, string status)
        {
            string sql = @"SELECT r.RelatoVisitaId, r.Numero, r.NumeroNaObra, o.Nome AS Obra, r.DataVisita, r.Relato, r.Status
                           FROM RelatosVisita r
                           INNER JOIN Obras o ON o.ObraId = r.ObraId
                           WHERE 1 = 1";
            List<SqlParameter> ps = new List<SqlParameter>();
            if (!string.IsNullOrWhiteSpace(pesquisa))
            {
                sql += " AND (r.Numero LIKE @p OR o.Nome LIKE @p OR r.Relato LIKE @p OR r.Participantes LIKE @p)";
                ps.Add(Banco.P("@p", "%" + pesquisa.Trim() + "%"));
            }
            if (obraId.HasValue)
            {
                sql += " AND r.ObraId = @obra";
                ps.Add(Banco.P("@obra", obraId.Value));
            }
            if (!string.IsNullOrEmpty(status))
            {
                sql += " AND r.Status = @status";
                ps.Add(Banco.P("@status", status));
            }
            sql += " ORDER BY r.DataVisita DESC, r.RelatoVisitaId DESC";
            return Banco.Consultar(sql, ps.ToArray());
        }

        public static RelatoVisita Obter(int id)
        {
            string sql = @"SELECT r.*, o.Nome AS ObraNome, p.NomeRazaoSocial AS ProprietarioNome, u.Nome AS UsuarioNome
                           FROM RelatosVisita r
                           INNER JOIN Obras o ON o.ObraId = r.ObraId
                           INNER JOIN Proprietarios p ON p.ProprietarioId = o.ProprietarioId
                           INNER JOIN Usuarios u ON u.UsuarioId = r.UsuarioId
                           WHERE r.RelatoVisitaId = @id";
            DataTable dt = Banco.Consultar(sql, Banco.P("@id", id));
            if (dt.Rows.Count == 0) return null;
            DataRow x = dt.Rows[0];

            RelatoVisita r = new RelatoVisita();
            r.Id = (int)x["RelatoVisitaId"];
            r.Numero = Texto.Valor(x["Numero"]);
            r.NumeroNaObra = (int)x["NumeroNaObra"];
            r.ObraId = (int)x["ObraId"];
            r.Obra = Texto.Valor(x["ObraNome"]);
            r.Proprietario = Texto.Valor(x["ProprietarioNome"]);
            r.UsuarioId = (int)x["UsuarioId"];
            r.Usuario = Texto.Valor(x["UsuarioNome"]);
            r.DataVisita = (System.DateTime)x["DataVisita"];
            r.Participantes = Texto.Valor(x["Participantes"]);
            r.SituacaoProjeto = Texto.Valor(x["SituacaoProjeto"]);
            r.StatusObra = Texto.Valor(x["StatusObra"]);
            r.Relato = Texto.Valor(x["Relato"]);
            r.DecisoesOrientacoes = Texto.Valor(x["DecisoesOrientacoes"]);
            r.Status = Texto.Valor(x["Status"]);

            // etapas marcadas no checklist
            DataTable etapas = Banco.Consultar(
                @"SELECT e.EtapaObraId, e.Descricao
                  FROM RelatoVisitaEtapas v
                  INNER JOIN EtapasObra e ON e.EtapaObraId = v.EtapaObraId
                  WHERE v.RelatoVisitaId = @id ORDER BY e.Ordem", Banco.P("@id", id));
            foreach (DataRow linha in etapas.Rows)
            {
                r.EtapasIds.Add((int)linha["EtapaObraId"]);
                r.EtapasNomes.Add(Texto.Valor(linha["Descricao"]));
            }
            return r;
        }

        // Grava o relato e as etapas na mesma transação: ou grava tudo, ou nada.
        // Devolve o ID do relato (necessário para salvar os anexos).
        public static int Salvar(RelatoVisita r)
        {
            using (SqlConnection con = Banco.NovaConexao())
            {
                con.Open();
                using (SqlTransaction tx = con.BeginTransaction())
                {
                    try
                    {
                        int id = r.Id;
                        if (id == 0)
                        {
                            string sqlInserir = @"INSERT INTO RelatosVisita
                                (ObraId, NumeroNaObra, UsuarioId, DataVisita, Participantes, SituacaoProjeto, StatusObra, Relato, DecisoesOrientacoes, Status)
                                SELECT @obra, ISNULL(MAX(NumeroNaObra), 0) + 1, @usuario, @data, @part, @situacao, @statusObra, @relato, @decisoes, @status
                                FROM RelatosVisita WITH (UPDLOCK, HOLDLOCK)
                                WHERE ObraId = @obra;
                                SELECT CAST(SCOPE_IDENTITY() AS INT);";
                            id = (int)Banco.Escalar(con, tx, sqlInserir,
                                Banco.P("@obra", r.ObraId), Banco.P("@usuario", r.UsuarioId), Banco.P("@data", r.DataVisita),
                                Banco.P("@part", r.Participantes), Banco.P("@situacao", r.SituacaoProjeto),
                                Banco.P("@statusObra", r.StatusObra), Banco.P("@relato", r.Relato),
                                Banco.P("@decisoes", r.DecisoesOrientacoes), Banco.P("@status", r.Status));
                        }
                        else
                        {
                            string sqlAtualizar = @"UPDATE RelatosVisita SET
                                ObraId = @obra, DataVisita = @data, Participantes = @part, SituacaoProjeto = @situacao,
                                StatusObra = @statusObra, Relato = @relato, DecisoesOrientacoes = @decisoes,
                                Status = @status, AtualizadoEm = SYSDATETIME()
                                WHERE RelatoVisitaId = @id";
                            Banco.Executar(con, tx, sqlAtualizar,
                                Banco.P("@id", id), Banco.P("@obra", r.ObraId), Banco.P("@data", r.DataVisita),
                                Banco.P("@part", r.Participantes), Banco.P("@situacao", r.SituacaoProjeto),
                                Banco.P("@statusObra", r.StatusObra), Banco.P("@relato", r.Relato),
                                Banco.P("@decisoes", r.DecisoesOrientacoes), Banco.P("@status", r.Status));
                        }

                        // refaz a lista de etapas marcadas
                        Banco.Executar(con, tx, "DELETE FROM RelatoVisitaEtapas WHERE RelatoVisitaId = @id", Banco.P("@id", id));
                        foreach (int etapaId in r.EtapasIds)
                        {
                            Banco.Executar(con, tx,
                                "INSERT INTO RelatoVisitaEtapas (RelatoVisitaId, EtapaObraId) VALUES (@id, @etapa)",
                                Banco.P("@id", id), Banco.P("@etapa", etapaId));
                        }

                        tx.Commit();
                        return id;
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }
        }

        // As etapas e os registros de anexos são apagados junto (ON DELETE CASCADE).
        // Os arquivos físicos são apagados pela página.
        public static void Excluir(int id)
        {
            Banco.Executar("DELETE FROM RelatosVisita WHERE RelatoVisitaId = @id", Banco.P("@id", id));
        }

        // ---------- Anexos ----------
        public static DataTable ListarAnexos(int relatoId)
        {
            return Banco.Consultar(
                "SELECT AnexoId, NomeOriginal, Descricao, TamanhoBytes FROM RelatoVisitaAnexos WHERE RelatoVisitaId = @id ORDER BY AnexoId",
                Banco.P("@id", relatoId));
        }

        public static Anexo ObterAnexo(int anexoId)
        {
            DataTable dt = Banco.Consultar("SELECT * FROM RelatoVisitaAnexos WHERE AnexoId = @id", Banco.P("@id", anexoId));
            if (dt.Rows.Count == 0) return null;
            DataRow x = dt.Rows[0];
            Anexo a = new Anexo();
            a.Id = (int)x["AnexoId"];
            a.RelatoVisitaId = (int)x["RelatoVisitaId"];
            a.NomeOriginal = Texto.Valor(x["NomeOriginal"]);
            a.Descricao = Texto.Valor(x["Descricao"]);
            a.CaminhoArquivo = Texto.Valor(x["CaminhoArquivo"]);
            a.ContentType = Texto.Valor(x["ContentType"]);
            return a;
        }

        public static List<Anexo> ObterAnexosDoRelato(int relatoId)
        {
            List<Anexo> lista = new List<Anexo>();
            DataTable dt = Banco.Consultar("SELECT AnexoId FROM RelatoVisitaAnexos WHERE RelatoVisitaId = @id", Banco.P("@id", relatoId));
            foreach (DataRow linha in dt.Rows)
                lista.Add(ObterAnexo((int)linha["AnexoId"]));
            return lista;
        }

        public static void InserirAnexo(Anexo a)
        {
            Banco.Executar(
                @"INSERT INTO RelatoVisitaAnexos (RelatoVisitaId, NomeOriginal, Descricao, CaminhoArquivo, ContentType, TamanhoBytes)
                  VALUES (@relato, @nome, @descricao, @caminho, @tipo, @tamanho)",
                Banco.P("@relato", a.RelatoVisitaId), Banco.P("@nome", a.NomeOriginal), Banco.P("@descricao", a.Descricao), Banco.P("@caminho", a.CaminhoArquivo),
                Banco.P("@tipo", a.ContentType), Banco.P("@tamanho", a.TamanhoBytes));
        }

        public static void ExcluirAnexo(int anexoId)
        {
            Banco.Executar("DELETE FROM RelatoVisitaAnexos WHERE AnexoId = @id", Banco.P("@id", anexoId));
        }
    }
}
