using System;
using System.Collections.Generic;
using System.IO;
using System.Web;

namespace WebApplication1.Utilitarios
{
    public static class Arquivos
    {
        public const int TamanhoMaximo = 10 * 1024 * 1024;
        public static readonly string[] Extensoes = { ".pdf", ".jpg", ".jpeg", ".png", ".doc", ".docx", ".xls", ".xlsx" };

        public static List<HttpPostedFile> Enviados(HttpRequest request, string uniqueId)
        {
            List<HttpPostedFile> lista = new List<HttpPostedFile>();
            for (int i = 0; i < request.Files.Count; i++)
            {
                if (request.Files.AllKeys[i] == uniqueId && request.Files[i].ContentLength > 0)
                    lista.Add(request.Files[i]);
            }
            return lista;
        }

        public static string Validar(List<HttpPostedFile> arquivos)
        {
            foreach (HttpPostedFile f in arquivos)
            {
                string nome = Path.GetFileName(f.FileName);
                string extensao = Path.GetExtension(nome).ToLower();
                if (Array.IndexOf(Extensoes, extensao) < 0)
                    return "Tipo de arquivo não permitido: " + nome + " (aceitos: PDF, JPG, PNG, Word e Excel).";
                if (f.ContentLength > TamanhoMaximo)
                    return "O arquivo " + nome + " passa de 10 MB.";
                if (!ConteudoConfere(f, extensao))
                    return "O conteúdo do arquivo " + nome + " não corresponde ao tipo " + extensao + ".";
            }
            return "";
        }

        private static bool ConteudoConfere(HttpPostedFile f, string extensao)
        {
            byte[] cab = new byte[8];
            int lidos = f.InputStream.Read(cab, 0, cab.Length);
            f.InputStream.Position = 0;
            if (lidos < 4) return false;

            switch (extensao)
            {
                case ".pdf": return cab[0] == 0x25 && cab[1] == 0x50 && cab[2] == 0x44 && cab[3] == 0x46;
                case ".jpg":
                case ".jpeg": return cab[0] == 0xFF && cab[1] == 0xD8;
                case ".png": return cab[0] == 0x89 && cab[1] == 0x50 && cab[2] == 0x4E && cab[3] == 0x47;
                case ".docx":
                case ".xlsx": return cab[0] == 0x50 && cab[1] == 0x4B;
                case ".doc":
                case ".xls": return cab[0] == 0xD0 && cab[1] == 0xCF && cab[2] == 0x11 && cab[3] == 0xE0;
                default: return false;
            }
        }

        public static string Salvar(HttpPostedFile arquivo, string pastaRelativa)
        {
            string pastaFisica = HttpContext.Current.Server.MapPath(pastaRelativa);
            Directory.CreateDirectory(pastaFisica);
            string extensao = Path.GetExtension(Path.GetFileName(arquivo.FileName)).ToLower();
            string nomeGravado = Guid.NewGuid().ToString("N") + extensao;
            arquivo.SaveAs(Path.Combine(pastaFisica, nomeGravado));
            return pastaRelativa + "/" + nomeGravado;
        }

        public static void Apagar(string caminhoRelativo)
        {
            if (string.IsNullOrEmpty(caminhoRelativo)) return;
            string caminho = HttpContext.Current.Server.MapPath(caminhoRelativo);
            if (File.Exists(caminho)) File.Delete(caminho);
        }

        public static void ApagarPasta(string pastaRelativa)
        {
            string pasta = HttpContext.Current.Server.MapPath(pastaRelativa);
            if (Directory.Exists(pasta)) Directory.Delete(pasta, true);
        }

        public static bool Baixar(string caminhoRelativo, string nomeOriginal, string contentType)
        {
            HttpContext ctx = HttpContext.Current;
            string caminho = ctx.Server.MapPath(caminhoRelativo);
            if (!File.Exists(caminho)) return false;

            ctx.Response.Clear();
            ctx.Response.ContentType = string.IsNullOrEmpty(contentType) ? "application/octet-stream" : contentType;
            ctx.Response.AddHeader("Content-Disposition", "attachment; filename=\"" + Uri.EscapeDataString(nomeOriginal) + "\"");
            ctx.Response.TransmitFile(caminho);
            ctx.Response.Flush();
            ctx.Response.SuppressContent = true;
            ctx.ApplicationInstance.CompleteRequest();
            return true;
        }
    }
}
