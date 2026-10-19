using System;
using System.Globalization;
using System.Linq;
using System.Web;

namespace WebApplication1.Utilitarios
{
    // Funções de texto/número/data usadas em várias telas.
    public static class Texto
    {
        private static readonly CultureInfo PtBr = new CultureInfo("pt-BR");

        // Deixa só os números de um texto ("123.456.789-00" -> "12345678900")
        public static string SoDigitos(string valor)
        {
            if (string.IsNullOrEmpty(valor)) return "";
            return new string(valor.Where(char.IsDigit).ToArray());
        }

        // Converte o valor de uma coluna do banco para texto (DBNull vira "")
        public static string Valor(object o)
        {
            if (o == null || o == DBNull.Value) return "";
            return Convert.ToString(o);
        }

        public static int? Inteiro(object o)
        {
            if (o == null || o == DBNull.Value) return null;
            string s = Convert.ToString(o);
            if (s == "") return null;
            return Convert.ToInt32(s);
        }

        public static DateTime? Data(object o)
        {
            if (o == null || o == DBNull.Value) return null;
            return Convert.ToDateTime(o);
        }

        public static decimal? Decimal(object o)
        {
            if (o == null || o == DBNull.Value) return null;
            return Convert.ToDecimal(o);
        }

        // Escapa HTML e troca quebra de linha por <br/> (usar ao mostrar texto digitado pelo usuário)
        public static string Html(string texto)
        {
            if (texto == null) return "";
            return HttpUtility.HtmlEncode(texto).Replace("\r\n", "<br />").Replace("\n", "<br />");
        }

        public static string Resumo(string texto, int tamanho)
        {
            if (string.IsNullOrEmpty(texto)) return "";
            texto = texto.Replace("\r", " ").Replace("\n", " ");
            if (texto.Length <= tamanho) return texto;
            return texto.Substring(0, tamanho) + "...";
        }

        // ---------- Formatação para exibir ----------
        public static string FormatarDocumento(string d)
        {
            d = SoDigitos(d);
            if (d.Length == 11)
                return d.Substring(0, 3) + "." + d.Substring(3, 3) + "." + d.Substring(6, 3) + "-" + d.Substring(9, 2);
            if (d.Length == 14)
                return d.Substring(0, 2) + "." + d.Substring(2, 3) + "." + d.Substring(5, 3) + "/" + d.Substring(8, 4) + "-" + d.Substring(12, 2);
            return d;
        }

        public static string FormatarTelefone(string t)
        {
            t = SoDigitos(t);
            if (t.Length == 10) return "(" + t.Substring(0, 2) + ") " + t.Substring(2, 4) + "-" + t.Substring(6, 4);
            if (t.Length == 11) return "(" + t.Substring(0, 2) + ") " + t.Substring(2, 5) + "-" + t.Substring(7, 4);
            return t;
        }

        public static string FormatarCep(string c)
        {
            c = SoDigitos(c);
            if (c.Length == 8) return c.Substring(0, 5) + "-" + c.Substring(5, 3);
            return c;
        }

        public static string FormatarData(object o)
        {
            DateTime? d = Data(o);
            return d.HasValue ? d.Value.ToString("dd/MM/yyyy") : "";
        }

        public static string FormatarMoeda(object o)
        {
            decimal? v = Decimal(o);
            return v.HasValue ? v.Value.ToString("C", PtBr) : "";
        }

        public static string FormatarArea(decimal? v)
        {
            return v.HasValue ? v.Value.ToString("0.00", PtBr) : "";
        }

        // ---------- Leitura do que o usuário digitou ----------

        // Aceita "1.234,56", "R$ 1.234,56", "2.450" (= 2450) ou "12.5" (= 12,5)
        public static decimal? ParseDecimal(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto)) return null;
            texto = texto.Replace("R$", "").Replace(" ", "").Trim();
            if (texto.Contains(","))
            {
                // 1.234,56  ->  1234.56
                texto = texto.Replace(".", "").Replace(",", ".");
            }
            else if (System.Text.RegularExpressions.Regex.IsMatch(texto, @"^-?[1-9]\d{0,2}(\.\d{3})+$"))
            {
                // 2.450 ou 1.234.567 (ponto só como separador de milhar)  ->  2450 / 1234567
                texto = texto.Replace(".", "");
            }
            decimal resultado;
            if (decimal.TryParse(texto, NumberStyles.Number, CultureInfo.InvariantCulture, out resultado))
                return resultado;
            return null;
        }

        // O <input type="date"> envia a data no formato yyyy-MM-dd
        public static DateTime? ParseData(string texto)
        {
            DateTime resultado;
            if (DateTime.TryParseExact(texto, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out resultado))
                return resultado;
            return null;
        }

        public static string DataParaCampo(DateTime? d)
        {
            return d.HasValue ? d.Value.ToString("yyyy-MM-dd") : "";
        }

        // Monta o ORDER BY a partir das opções do filtro "Ordenar por".
        // Só aceita valores conhecidos (evita SQL Injection).
        public static string Ordenar(string ordem, string colunaNome, string colunaData)
        {
            if (ordem == "az") return " ORDER BY " + colunaNome + " ASC";
            if (ordem == "za") return " ORDER BY " + colunaNome + " DESC";
            return " ORDER BY " + colunaData + " DESC";
        }
    }
}
