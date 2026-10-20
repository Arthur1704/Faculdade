using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Text;
using WebApplication1.Modelos;
using WebApplication1.Utilitarios;

namespace WebApplication1.Dados
{
    // Assinaturas digitais (Manual: Assinatura_Obra, Assinatura_Visita e Assinatura_Termo_Conclusao).
    // tipo: "Obra", "Visita", "Termo" ou "Recibo". Papel: "RT" (responsável técnico) ou "PROPRIETARIO".
    public static class AssinaturaDAO
    {
        // Só aceita os três tipos conhecidos (os nomes de tabela e coluna nunca vêm do usuário)
        private static void Alvo(string tipo, out string tabela, out string chave)
        {
            switch (tipo)
            {
                case "Obra": tabela = "AssinaturasObra"; chave = "ObraId"; break;
                case "Visita": tabela = "AssinaturasVisita"; chave = "RelatoVisitaId"; break;
                case "Termo": tabela = "AssinaturasTermo"; chave = "TermoConclusaoId"; break;
                case "Recibo": tabela = "AssinaturasRecibo"; chave = "ReciboId"; break;
                default: throw new ArgumentException("Tipo de documento inválido: " + tipo);
            }
        }

        public static List<Assinatura> Listar(string tipo, int documentoId)
        {
            string tabela, chave;
            Alvo(tipo, out tabela, out chave);
            DataTable dt = Banco.Consultar(
                "SELECT Papel, NomeAssinante, UsuarioId, AssinaturaDigital, HashDocumento, IpMaquina, DataAssinatura FROM " + tabela +
                " WHERE " + chave + " = @id", Banco.P("@id", documentoId));

            List<Assinatura> lista = new List<Assinatura>();
            foreach (DataRow r in dt.Rows)
            {
                Assinatura a = new Assinatura();
                a.Papel = Texto.Valor(r["Papel"]);
                a.NomeAssinante = Texto.Valor(r["NomeAssinante"]);
                a.UsuarioId = (int)r["UsuarioId"];
                a.Imagem = Texto.Valor(r["AssinaturaDigital"]);
                a.Hash = Texto.Valor(r["HashDocumento"]).Trim();
                a.Ip = Texto.Valor(r["IpMaquina"]);
                a.Data = Convert.ToDateTime(r["DataAssinatura"]);
                lista.Add(a);
            }
            return lista;
        }

        public static bool Existe(string tipo, int documentoId)
        {
            string tabela, chave;
            Alvo(tipo, out tabela, out chave);
            object n = Banco.Escalar("SELECT COUNT(*) FROM " + tabela + " WHERE " + chave + " = @id", Banco.P("@id", documentoId));
            return Convert.ToInt32(n) > 0;
        }

        // Grava (ou substitui) a assinatura de um papel
        public static void Salvar(string tipo, int documentoId, Assinatura a)
        {
            string tabela, chave;
            Alvo(tipo, out tabela, out chave);
            using (SqlConnection con = Banco.NovaConexao())
            {
                con.Open();
                using (SqlTransaction tx = con.BeginTransaction())
                {
                    try
                    {
                        Banco.Executar(con, tx, "DELETE FROM " + tabela + " WHERE " + chave + " = @id AND Papel = @papel",
                            Banco.P("@id", documentoId), Banco.P("@papel", a.Papel));
                        Banco.Executar(con, tx,
                            "INSERT INTO " + tabela + " (" + chave + ", Papel, NomeAssinante, UsuarioId, AssinaturaDigital, HashDocumento, IpMaquina) " +
                            "VALUES (@id, @papel, @nome, @usuario, @imagem, @hash, @ip)",
                            Banco.P("@id", documentoId), Banco.P("@papel", a.Papel), Banco.P("@nome", a.NomeAssinante),
                            Banco.P("@usuario", a.UsuarioId), Banco.P("@imagem", a.Imagem), Banco.P("@hash", a.Hash), Banco.P("@ip", a.Ip));
                        tx.Commit();
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }
        }

        public static void Remover(string tipo, int documentoId, string papel)
        {
            string tabela, chave;
            Alvo(tipo, out tabela, out chave);
            Banco.Executar("DELETE FROM " + tabela + " WHERE " + chave + " = @id AND Papel = @papel",
                Banco.P("@id", documentoId), Banco.P("@papel", papel));
        }

        // Impressão digital (SHA-256) do conteúdo do documento NO MOMENTO ATUAL.
        // Guardada ao assinar; se o documento for alterado depois, o hash deixa de conferir.
        public static string CalcularHash(string tipo, int documentoId)
        {
            StringBuilder sb = new StringBuilder(tipo + "#" + documentoId);
            DataTable dt;
            if (tipo == "Obra")
            {
                dt = Banco.Consultar(@"SELECT Nome, ProprietarioId, TipoObraId, AtividadeTecnicaId, ProfissionalId, NumeroRT, Empresa,
                                              NumeroCaderneta, ValorObra, DataInicio, PrevisaoTermino, EnderecoObra,
                                              AreaConstruir, AreaAmpliar, AreaRegularizar, AreaReforma
                                       FROM Obras WHERE ObraId = @id", Banco.P("@id", documentoId));
            }
            else if (tipo == "Visita")
            {
                dt = Banco.Consultar(@"SELECT ObraId, DataVisita, Participantes, SituacaoProjeto, StatusObra, Relato, DecisoesOrientacoes
                                       FROM RelatosVisita WHERE RelatoVisitaId = @id", Banco.P("@id", documentoId));
                DataTable etapas = Banco.Consultar(
                    "SELECT EtapaObraId FROM RelatoVisitaEtapas WHERE RelatoVisitaId = @id ORDER BY EtapaObraId", Banco.P("@id", documentoId));
                foreach (DataRow e in etapas.Rows) sb.Append("|etapa").Append(e["EtapaObraId"]);
            }
            else if (tipo == "Termo")
            {
                dt = Banco.Consultar(@"SELECT ObraId, ProprietarioId, DataConclusao, DocumentoReferencia, DeclaracaoConclusao, ObservacoesFinais
                                       FROM TermosConclusao WHERE TermoConclusaoId = @id", Banco.P("@id", documentoId));
            }
            else if (tipo == "Recibo")
            {
                // o status (ex.: Cancelado) não entra: mudar o status não invalida a assinatura
                dt = Banco.Consultar(@"SELECT ObraId, ProprietarioId, DataEmissao, Valor, FormaPagamentoId, ReferenteA, Observacoes
                                       FROM Recibos WHERE ReciboId = @id", Banco.P("@id", documentoId));
            }
            else
            {
                throw new ArgumentException("Tipo de documento inválido: " + tipo);
            }

            if (dt.Rows.Count > 0)
            {
                foreach (object valor in dt.Rows[0].ItemArray)
                    sb.Append("|").Append(valor == DBNull.Value ? "" : Convert.ToString(valor, CultureInfo.InvariantCulture));
            }
            return Seguranca.Sha256Hex(sb.ToString());
        }
    }
}
