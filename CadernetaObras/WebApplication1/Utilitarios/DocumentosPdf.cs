using System;
using System.Collections.Generic;
using System.Globalization;
using WebApplication1.Modelos;

namespace WebApplication1.Utilitarios
{
    // Monta o PDF único do Manual: Capa + Primeira página (dados da obra e valor) + Termo de Conclusão.
    // Os dados vêm do cadastro da obra, do responsável técnico, do proprietário e das assinaturas digitais.
    public static class DocumentosPdf
    {
        private const double Margem = 60;
        private static readonly CultureInfo PtBr = new CultureInfo("pt-BR");
        private static readonly double[] Cinza = { 0.4, 0.4, 0.4 };

        public static string TextoSancoes
        {
            get { return "Temos ainda conhecimento na íntegra das sanções prescritas nas Legislações Federal, Estadual e Municipal vigentes."; }
        }

        public static byte[] GerarCaderneta(CapaObra c, TermoConclusao termo, List<Assinatura> assinaturasObra, List<Assinatura> assinaturasTermo, string cidade)
        {
            PdfSimples pdf = new PdfSimples();
            Capa(pdf, c);
            pdf.NovaPagina();
            PrimeiraPagina(pdf, c, assinaturasObra);
            pdf.NovaPagina();
            Termo(pdf, c, termo, assinaturasTermo, cidade);
            return pdf.Gerar();
        }

        // ---------- Peças de desenho ----------
        private static void Moldura(PdfSimples pdf)
        {
            pdf.Retangulo(26, 26, PdfSimples.Largura - 52, PdfSimples.Altura - 52, 2);
            pdf.Retangulo(32, 32, PdfSimples.Largura - 64, PdfSimples.Altura - 64, 0.6);
        }

        private static string Ajustar(string texto)
        {
            return texto ?? "";
        }

        // Rótulo em negrito + valor sobre uma linha (o valor reduz a fonte se não couber)
        private static void Campo(PdfSimples pdf, double x, double y, double largura, string rotulo, string valor)
        {
            double wRotulo = pdf.LarguraTexto(rotulo, 11, true);
            pdf.Texto(x, y, rotulo, 11, true);
            double xValor = x + wRotulo + 6;
            double disponivel = largura - wRotulo - 8;
            double tamanho = 12;
            valor = Ajustar(valor);
            while (tamanho > 7 && pdf.LarguraTexto(valor, tamanho, false) > disponivel) tamanho -= 0.5;
            pdf.Texto(xValor, y, valor, tamanho, false);
            pdf.Linha(x + wRotulo + 4, y + 4, x + largura, y + 4, 0.6);
        }

        private static void CadernetaNumero(PdfSimples pdf, CapaObra c, double x, double y)
        {
            if (!string.IsNullOrEmpty(c.NumeroCaderneta))
                pdf.TextoDireita(x, y, c.NumeroCaderneta, 20, true, PdfSimples.Vermelho);
        }

        private static byte[] ImagemDaAssinatura(Assinatura a)
        {
            if (a == null || string.IsNullOrEmpty(a.Imagem)) return null;
            int i = a.Imagem.IndexOf(',');
            if (i < 0) return null;
            try { return Convert.FromBase64String(a.Imagem.Substring(i + 1)); }
            catch (FormatException) { return null; }
        }

        private static Assinatura Achar(List<Assinatura> lista, string papel)
        {
            if (lista == null) return null;
            foreach (Assinatura a in lista) if (a.Papel == papel) return a;
            return null;
        }

        // Caixa de assinatura: imagem (se já assinou) sobre a linha, título e dados da assinatura digital
        private static void CaixaAssinatura(PdfSimples pdf, double x, double y, double largura, string titulo, string nome, Assinatura a)
        {
            byte[] jpeg = ImagemDaAssinatura(a);
            if (jpeg != null) pdf.Imagem(jpeg, x + 10, y - 62, largura - 20, 58);
            pdf.Linha(x, y, x + largura, y, 0.8);
            pdf.TextoCentralizado(x + largura / 2, y + 13, titulo, 10, true);
            if (!string.IsNullOrEmpty(nome)) pdf.TextoCentralizado(x + largura / 2, y + 25, nome, 9, false);
            if (a != null)
            {
                string carimbo = "Assinado digitalmente em " + a.Data.ToString("dd/MM/yyyy HH:mm", PtBr) +
                                 (string.IsNullOrEmpty(a.Ip) ? "" : " - IP " + a.Ip);
                pdf.TextoCentralizado(x + largura / 2, y + 36, carimbo, 7, false);
            }
        }

        // ---------- Página 1: capa ----------
        private static void Capa(PdfSimples pdf, CapaObra c)
        {
            double W = PdfSimples.Largura;
            Moldura(pdf);
            CadernetaNumero(pdf, c, W - 56, 70);

            pdf.TextoCentralizado(W / 2, 160, "CADERNETA DE OBRA", 36, true);
            pdf.TextoCentralizado(W / 2, 190, "De acordo com a Lei Municipal nº 1.263 de 08/09/2004 e Decreto nº 2.230 de 20/10/2004.", 12, false);

            double larguraTotal = W - 2 * Margem;
            Campo(pdf, Margem, 270, larguraTotal, "Nome do Profissional:", c.ProfissionalNome);
            Campo(pdf, Margem, 320, larguraTotal - 220, "Título do Profissional:", c.TituloProfissional);
            Campo(pdf, W - Margem - 200, 320, 200, "RT nº:", c.NumeroRT);
            Campo(pdf, Margem, 370, larguraTotal, "Proprietário:", c.ProprietarioNome);
            Campo(pdf, Margem, 420, larguraTotal, "Local da Obra:", c.LocalObra);

            pdf.TextoCentralizado(W / 2, 520, "Obra: " + c.NomeObra, 9, false);
        }

        // ---------- Página 2: primeira página (dados técnicos e valor) ----------
        private static void PrimeiraPagina(PdfSimples pdf, CapaObra c, List<Assinatura> assinaturas)
        {
            double W = PdfSimples.Largura;
            Moldura(pdf);
            pdf.Texto(Margem, 68, c.NumeroCaderneta, 20, true, PdfSimples.Vermelho);
            pdf.TextoCentralizado(W / 2, 75, "RECIBO", 26, true);
            string valor = c.ValorObra.HasValue ? Texto.FormatarMoeda(c.ValorObra.Value) : "R$ ____________";
            pdf.TextoDireita(W - Margem, 70, valor, 16, true, null);
            pdf.TextoCentralizado(W / 2, 92, "Primeira página da Caderneta de Obra - dados técnicos", 9, false);

            double total = W - 2 * Margem;
            double metade = total / 2 - 10;
            double y = 130;
            string registro = (c.TipoRegistro + " " + c.NumeroRegistro).Trim();

            Campo(pdf, Margem, y, total, "Profissional:", c.ProfissionalNome); y += 30;
            Campo(pdf, Margem, y, metade, "Nº de Registro:", registro);
            Campo(pdf, Margem + metade + 20, y, metade, "CPF nº:", Texto.FormatarDocumento(c.ProfissionalCpf)); y += 30;
            Campo(pdf, Margem, y, total, "Empresa:", c.Empresa); y += 30;
            Campo(pdf, Margem, y, metade, "Proprietário:", c.ProprietarioNome);
            Campo(pdf, Margem + metade + 20, y, metade, "CPF/CNPJ:", Texto.FormatarDocumento(c.ProprietarioCpfCnpj)); y += 30;
            Campo(pdf, Margem, y, metade, "Telefone do Proprietário:", Texto.FormatarTelefone(c.ProprietarioTelefone));
            Campo(pdf, Margem + metade + 20, y, metade, "R.T. nº:", c.NumeroRT); y += 30;
            Campo(pdf, Margem, y, total, "Local da Obra:", c.LocalObra); y += 30;

            double terco = total / 3 - 10;
            Campo(pdf, Margem, y, terco, "Área a construir:", Area(c.AreaConstruir));
            Campo(pdf, Margem + terco + 15, y, terco, "Área a ampliar:", Area(c.AreaAmpliar));
            Campo(pdf, Margem + 2 * (terco + 15), y, terco, "Área a regularizar:", Area(c.AreaRegularizar)); y += 30;
            Campo(pdf, Margem, y, terco, "Área a reformar:", Area(c.AreaReforma));
            Campo(pdf, Margem + terco + 15, y, 2 * terco + 15, "Área total edificada:", Area(c.AreaTotal)); y += 30;
            Campo(pdf, Margem, y, metade, "Tipo de edificação:", c.TipoEdificacao);
            Campo(pdf, Margem + metade + 20, y, metade, "Atividade técnica:", c.AtividadeTecnica);

            double larguraCaixa = 280;
            CaixaAssinatura(pdf, Margem + 20, 505, larguraCaixa, "Assinatura do Profissional", c.ProfissionalNome, Achar(assinaturas, "RT"));
            CaixaAssinatura(pdf, W - Margem - 20 - larguraCaixa, 505, larguraCaixa, "Assinatura do Proprietário", c.ProprietarioNome, Achar(assinaturas, "PROPRIETARIO"));
        }

        private static string Area(decimal valor)
        {
            return valor.ToString("0.00", PtBr) + " m²";
        }

        // ---------- Página 3: termo de conclusão ----------
        private static void Termo(PdfSimples pdf, CapaObra c, TermoConclusao t, List<Assinatura> assinaturas, string cidade)
        {
            double W = PdfSimples.Largura;
            Moldura(pdf);
            pdf.Texto(Margem, 68, c.NumeroCaderneta, 20, true, PdfSimples.Vermelho);
            pdf.TextoCentralizado(W / 2, 75, "TERMO DE CONCLUSÃO", 26, true);
            pdf.TextoDireita(W - Margem, 68, "Nº " + t.Numero, 12, true, Cinza);

            double total = W - 2 * Margem;
            double metade = total / 2 - 10;
            double y = 120;
            string registro = (c.TipoRegistro + " " + c.NumeroRegistro).Trim();

            Campo(pdf, Margem, y, metade + 120, "Profissional:", c.ProfissionalNome);
            Campo(pdf, Margem + metade + 140, y, total - metade - 140, "Nº de Registro:", registro); y += 26;
            Campo(pdf, Margem, y, metade + 120, "Empresa:", c.Empresa);
            Campo(pdf, Margem + metade + 140, y, total - metade - 140, "R.T. nº:", c.NumeroRT); y += 26;
            Campo(pdf, Margem, y, metade + 120, "Proprietário:", c.ProprietarioNome);
            Campo(pdf, Margem + metade + 140, y, total - metade - 140, "CPF nº:", Texto.FormatarDocumento(c.ProprietarioCpfCnpj)); y += 26;
            Campo(pdf, Margem, y, total, "Telefone do Proprietário:", Texto.FormatarTelefone(c.ProprietarioTelefone)); y += 26;
            Campo(pdf, Margem, y, total, "Local da Obra:", c.LocalObra); y += 40;

            pdf.TextoCentralizado(W / 2, y, "DECLARAÇÃO", 15, true); y += 24;
            y = pdf.Paragrafo(Margem, y, total, t.Declaracao, 11, 15);
            if (!string.IsNullOrEmpty(t.ObservacoesFinais))
            {
                y += 4;
                y = pdf.Paragrafo(Margem, y, total, "Observações: " + t.ObservacoesFinais, 10, 14);
            }
            y += 6;
            pdf.Paragrafo(Margem, y, total, TextoSancoes, 11, 15);

            string data = t.DataConclusao.ToString("d 'de' MMMM 'de' yyyy", PtBr);
            pdf.TextoDireita(W - Margem, 425, (string.IsNullOrEmpty(cidade) ? "" : cidade + ", ") + data + ".", 11, false, null);

            double larguraCaixa = 280;
            CaixaAssinatura(pdf, Margem + 20, 505, larguraCaixa, "Assinatura do Profissional", c.ProfissionalNome, Achar(assinaturas, "RT"));
            CaixaAssinatura(pdf, W - Margem - 20 - larguraCaixa, 505, larguraCaixa, "Assinatura do Proprietário", c.ProprietarioNome, Achar(assinaturas, "PROPRIETARIO"));
        }
    }
}
