using System;
using System.IO;
using System.Web.Hosting;

namespace WebApplication1.Utilitarios
{
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
            }
        }
    }
}
