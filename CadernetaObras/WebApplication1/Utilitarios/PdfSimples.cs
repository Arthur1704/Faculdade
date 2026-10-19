using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace WebApplication1.Utilitarios
{
    // Gerador de PDF bem simples, sem bibliotecas externas.
    // Suporta: texto (Helvetica normal e negrito), linhas, retângulos e imagens JPEG, em páginas A4 paisagem.
    // As posições são em pontos (1 pt = 1/72 polegada) medidas a partir do CANTO SUPERIOR ESQUERDO.
    public class PdfSimples
    {
        public const double Largura = 841.89;   // A4 paisagem
        public const double Altura = 595.28;

        public static readonly double[] Vermelho = { 0.78, 0.1, 0.1 };

        private class Pagina
        {
            public StringBuilder Conteudo = new StringBuilder();
        }

        private class ImagemPdf
        {
            public byte[] Dados;
            public int Largura;
            public int Altura;
            public int Componentes;
        }

        private readonly List<Pagina> paginas = new List<Pagina>();
        private readonly List<ImagemPdf> imagens = new List<ImagemPdf>();

        private static readonly Encoding Win1252 = Encoding.GetEncoding(1252);
        private static readonly Encoding Latin1 = Encoding.GetEncoding(28591);

        // Larguras dos caracteres ASCII 32..126 da fonte Helvetica (unidades de 1/1000 do tamanho da fonte)
        private static readonly int[] LarguraNormal = {
            278, 278, 355, 556, 556, 889, 667, 191, 333, 333, 389, 584, 278, 333, 278, 278,
            556, 556, 556, 556, 556, 556, 556, 556, 556, 556, 278, 278, 584, 584, 584, 556,
            1015, 667, 667, 722, 722, 667, 611, 778, 722, 278, 500, 667, 556, 833, 722, 778,
            667, 778, 722, 667, 611, 722, 667, 944, 667, 667, 611, 278, 278, 278, 469, 556,
            333, 556, 556, 500, 556, 556, 278, 556, 556, 222, 222, 500, 222, 833, 556, 556,
            556, 556, 333, 500, 278, 556, 500, 722, 500, 500, 500, 334, 260, 334, 584 };

        private static readonly int[] LarguraNegrito = {
            278, 333, 474, 556, 556, 889, 722, 238, 333, 333, 389, 584, 278, 333, 278, 278,
            556, 556, 556, 556, 556, 556, 556, 556, 556, 556, 333, 333, 584, 584, 584, 611,
            975, 722, 722, 722, 722, 667, 611, 778, 722, 278, 556, 722, 611, 833, 722, 778,
            667, 778, 722, 667, 611, 722, 667, 944, 667, 667, 611, 333, 278, 333, 584, 556,
            333, 556, 611, 556, 611, 556, 333, 611, 611, 278, 278, 556, 278, 889, 611, 611,
            611, 611, 389, 556, 333, 611, 556, 778, 556, 556, 500, 389, 280, 389, 584 };

        public PdfSimples()
        {
            NovaPagina();
        }

        public void NovaPagina()
        {
            paginas.Add(new Pagina());
        }

        private Pagina Atual
        {
            get { return paginas[paginas.Count - 1]; }
        }

        private static string N(double v)
        {
            return v.ToString("0.##", CultureInfo.InvariantCulture);
        }

        // ---------- Medidas de texto ----------
        public double LarguraTexto(string texto, double tamanho, bool negrito)
        {
            if (string.IsNullOrEmpty(texto)) return 0;
            int[] tabela = negrito ? LarguraNegrito : LarguraNormal;
            double soma = 0;
            foreach (char c in texto)
            {
                char b = c;
                if (b < 32 || b > 126)
                {
                    // letra acentuada: usa a largura da letra sem acento
                    string decomposta = c.ToString().Normalize(NormalizationForm.FormD);
                    b = decomposta.Length > 0 ? decomposta[0] : 'a';
                    if (b < 32 || b > 126) b = 'n';
                }
                soma += tabela[b - 32];
            }
            return soma * tamanho / 1000.0;
        }

        // Quebra o texto em linhas que cabem na largura informada (respeita quebras de linha)
        public List<string> Quebrar(string texto, double larguraMax, double tamanho, bool negrito)
        {
            List<string> linhas = new List<string>();
            if (texto == null) texto = "";
            foreach (string paragrafo in texto.Replace("\r\n", "\n").Replace("\r", "\n").Split('\n'))
            {
                string linha = "";
                foreach (string palavra in paragrafo.Split(' '))
                {
                    string teste = linha == "" ? palavra : linha + " " + palavra;
                    if (LarguraTexto(teste, tamanho, negrito) <= larguraMax || linha == "")
                        linha = teste;
                    else
                    {
                        linhas.Add(linha);
                        linha = palavra;
                    }
                }
                linhas.Add(linha);
            }
            return linhas;
        }

        // ---------- Desenho ----------
        private static string Literal(string texto)
        {
            // converte para os bytes do Windows-1252 e escapa ( ) e \
            string latin = Latin1.GetString(Win1252.GetBytes(texto ?? ""));
            return "(" + latin.Replace("\\", "\\\\").Replace("(", "\\(").Replace(")", "\\)") + ")";
        }

        public void Texto(double x, double y, string texto, double tamanho, bool negrito, double[] cor)
        {
            if (string.IsNullOrEmpty(texto)) return;
            StringBuilder c = Atual.Conteudo;
            double[] rgb = cor ?? new double[] { 0, 0, 0 };
            c.Append("BT ").Append(N(rgb[0])).Append(' ').Append(N(rgb[1])).Append(' ').Append(N(rgb[2])).Append(" rg ");
            c.Append(negrito ? "/F2 " : "/F1 ").Append(N(tamanho)).Append(" Tf ");
            c.Append(N(x)).Append(' ').Append(N(Altura - y)).Append(" Td ").Append(Literal(texto)).Append(" Tj ET\n");
        }

        public void Texto(double x, double y, string texto, double tamanho, bool negrito)
        {
            Texto(x, y, texto, tamanho, negrito, null);
        }

        public void TextoCentralizado(double xCentro, double y, string texto, double tamanho, bool negrito)
        {
            Texto(xCentro - LarguraTexto(texto, tamanho, negrito) / 2, y, texto, tamanho, negrito, null);
        }

        public void TextoDireita(double xDireita, double y, string texto, double tamanho, bool negrito, double[] cor)
        {
            Texto(xDireita - LarguraTexto(texto, tamanho, negrito), y, texto, tamanho, negrito, cor);
        }

        // Texto com várias linhas dentro de uma largura. Devolve o Y logo abaixo do texto.
        public double Paragrafo(double x, double y, double larguraMax, string texto, double tamanho, double espacamento)
        {
            foreach (string linha in Quebrar(texto, larguraMax, tamanho, false))
            {
                Texto(x, y, linha, tamanho, false);
                y += espacamento;
            }
            return y;
        }

        public void Linha(double x1, double y1, double x2, double y2, double espessura)
        {
            Atual.Conteudo.Append("0 0 0 RG ").Append(N(espessura)).Append(" w ")
                .Append(N(x1)).Append(' ').Append(N(Altura - y1)).Append(" m ")
                .Append(N(x2)).Append(' ').Append(N(Altura - y2)).Append(" l S\n");
        }

        public void Retangulo(double x, double y, double largura, double altura, double espessura)
        {
            Atual.Conteudo.Append("0 0 0 RG ").Append(N(espessura)).Append(" w ")
                .Append(N(x)).Append(' ').Append(N(Altura - y - altura)).Append(' ')
                .Append(N(largura)).Append(' ').Append(N(altura)).Append(" re S\n");
        }

        // Desenha um JPEG dentro da caixa, mantendo a proporção e centralizando
        public bool Imagem(byte[] jpeg, double x, double y, double larguraCaixa, double alturaCaixa)
        {
            ImagemPdf img = LerJpeg(jpeg);
            if (img == null) return false;
            imagens.Add(img);
            int indice = imagens.Count;

            double escala = Math.Min(larguraCaixa / img.Largura, alturaCaixa / img.Altura);
            double w = img.Largura * escala, h = img.Altura * escala;
            double px = x + (larguraCaixa - w) / 2;
            double py = Altura - (y + (alturaCaixa - h) / 2) - h;

            Atual.Conteudo.Append("q ").Append(N(w)).Append(" 0 0 ").Append(N(h)).Append(' ')
                .Append(N(px)).Append(' ').Append(N(py)).Append(" cm /Im").Append(indice).Append(" Do Q\n");
            return true;
        }

        // Lê largura, altura e nº de componentes do cabeçalho JPEG
        private static ImagemPdf LerJpeg(byte[] d)
        {
            if (d == null || d.Length < 4 || d[0] != 0xFF || d[1] != 0xD8) return null;
            int i = 2;
            while (i + 9 < d.Length)
            {
                if (d[i] != 0xFF) { i++; continue; }
                int marcador = d[i + 1];
                if (marcador == 0xFF) { i++; continue; }
                bool sof = marcador >= 0xC0 && marcador <= 0xCF && marcador != 0xC4 && marcador != 0xC8 && marcador != 0xCC;
                int tamanho = (d[i + 2] << 8) | d[i + 3];
                if (sof)
                {
                    ImagemPdf img = new ImagemPdf();
                    img.Altura = (d[i + 5] << 8) | d[i + 6];
                    img.Largura = (d[i + 7] << 8) | d[i + 8];
                    img.Componentes = d[i + 9];
                    img.Dados = d;
                    return (img.Largura > 0 && img.Altura > 0) ? img : null;
                }
                i += 2 + tamanho;
            }
            return null;
        }

        // ---------- Montagem do arquivo ----------
        private static void Escrever(MemoryStream ms, string texto)
        {
            byte[] b = Latin1.GetBytes(texto);
            ms.Write(b, 0, b.Length);
        }

        public byte[] Gerar()
        {
            MemoryStream ms = new MemoryStream();
            List<long> posicoes = new List<long>();   // posição de cada objeto (índice 0 = objeto 1)

            Escrever(ms, "%PDF-1.4\n%\u00e2\u00e3\u00cf\u00d3\n");

            int primeiroImagem = 5;
            int primeiroPagina = primeiroImagem + imagens.Count;
            int totalObjetos = primeiroPagina + paginas.Count * 2 - 1;

            // 1: catálogo, 2: lista de páginas, 3 e 4: fontes
            posicoes.Add(ms.Position); Escrever(ms, "1 0 obj\n<< /Type /Catalog /Pages 2 0 R >>\nendobj\n");
            StringBuilder kids = new StringBuilder();
            for (int p = 0; p < paginas.Count; p++) kids.Append(primeiroPagina + p * 2).Append(" 0 R ");
            posicoes.Add(ms.Position); Escrever(ms, "2 0 obj\n<< /Type /Pages /Kids [" + kids + "] /Count " + paginas.Count + " >>\nendobj\n");
            posicoes.Add(ms.Position); Escrever(ms, "3 0 obj\n<< /Type /Font /Subtype /Type1 /BaseFont /Helvetica /Encoding /WinAnsiEncoding >>\nendobj\n");
            posicoes.Add(ms.Position); Escrever(ms, "4 0 obj\n<< /Type /Font /Subtype /Type1 /BaseFont /Helvetica-Bold /Encoding /WinAnsiEncoding >>\nendobj\n");

            // imagens
            for (int i = 0; i < imagens.Count; i++)
            {
                ImagemPdf img = imagens[i];
                string espaco = img.Componentes == 1 ? "/DeviceGray" : (img.Componentes == 4 ? "/DeviceCMYK" : "/DeviceRGB");
                posicoes.Add(ms.Position);
                Escrever(ms, (primeiroImagem + i) + " 0 obj\n<< /Type /XObject /Subtype /Image /Width " + img.Largura + " /Height " + img.Altura +
                    " /ColorSpace " + espaco + " /BitsPerComponent 8 /Filter /DCTDecode /Length " + img.Dados.Length + " >>\nstream\n");
                ms.Write(img.Dados, 0, img.Dados.Length);
                Escrever(ms, "\nendstream\nendobj\n");
            }

            StringBuilder xobjetos = new StringBuilder();
            for (int i = 0; i < imagens.Count; i++) xobjetos.Append("/Im").Append(i + 1).Append(' ').Append(primeiroImagem + i).Append(" 0 R ");

            // páginas
            for (int p = 0; p < paginas.Count; p++)
            {
                int objPagina = primeiroPagina + p * 2;
                int objConteudo = objPagina + 1;
                posicoes.Add(ms.Position);
                Escrever(ms, objPagina + " 0 obj\n<< /Type /Page /Parent 2 0 R /MediaBox [0 0 " + N(Largura) + " " + N(Altura) + "] " +
                    "/Resources << /Font << /F1 3 0 R /F2 4 0 R >> /XObject << " + xobjetos + ">> >> /Contents " + objConteudo + " 0 R >>\nendobj\n");

                byte[] conteudo = Latin1.GetBytes(paginas[p].Conteudo.ToString());
                posicoes.Add(ms.Position);
                Escrever(ms, objConteudo + " 0 obj\n<< /Length " + conteudo.Length + " >>\nstream\n");
                ms.Write(conteudo, 0, conteudo.Length);
                Escrever(ms, "\nendstream\nendobj\n");
            }

            long inicioXref = ms.Position;
            Escrever(ms, "xref\n0 " + (totalObjetos + 1) + "\n0000000000 65535 f \n");
            foreach (long pos in posicoes) Escrever(ms, pos.ToString("0000000000") + " 00000 n \n");
            Escrever(ms, "trailer\n<< /Size " + (totalObjetos + 1) + " /Root 1 0 R >>\nstartxref\n" + inicioXref + "\n%%EOF\n");
            return ms.ToArray();
        }
    }
}
