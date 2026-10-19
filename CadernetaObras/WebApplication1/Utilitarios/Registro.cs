using System;
using System.IO;
using System.Web.Hosting;

namespace WebApplication1.Utilitarios
{
    // Grava os erros técnicos em App_Data/Logs (o usuário vê só uma mensagem amigável).
    public static class Registro
    {
        public static void Erro(Exception ex)
        {
            try
            {
                string pasta = HostingEnvironment.MapPath("~/App_Data/Logs");
                Directory.CreateDirectory(pasta);
                string arquivo = Path.Combine(pasta, "erro-" + DateTime.Now.ToString("yyyyMMdd") + ".log");
                File.AppendAllText(arquivo,
                    DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + Environment.NewLine + ex + Environment.NewLine + Environment.NewLine);
            }
            catch
            {
                // se não conseguir gravar o log, segue sem interromper a tela
            }
        }
    }
}
