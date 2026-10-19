using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI.WebControls;
using WebApplication1.Dados;
using WebApplication1.Utilitarios;

namespace WebApplication1
{
    // Manual: "Administrador - Realizar backup dos dados"
    public partial class backup : PaginaBase
    {
        protected override bool SomenteAdministrador
        {
            get { return true; }
        }

        private string PastaBackup
        {
            get
            {
                string pasta = ConfigurationManager.AppSettings["PastaBackup"];
                return string.IsNullOrWhiteSpace(pasta) ? @"C:\Backups\CadernetaObras" : pasta;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            lblPasta.Text = HttpUtility.HtmlEncode(PastaBackup);
            if (!IsPostBack) Carregar();
        }

        private void Carregar()
        {
            CarregarArquivos();
            try
            {
                gvHistorico.DataSource = BackupDAO.ListarLog();
                gvHistorico.DataBind();
                AjustarGrid(gvHistorico);
            }
            catch (Exception ex)
            {
                MensagemErro(TextoErroBanco(ex));
            }
        }

        // Lista os .bak da pasta (só funciona se a pasta for acessível pelo servidor do site)
        private void CarregarArquivos()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Nome", typeof(string));
            dt.Columns.Add("Tamanho", typeof(long));
            dt.Columns.Add("Data", typeof(DateTime));

            try
            {
                if (Directory.Exists(PastaBackup))
                {
                    foreach (string caminho in Directory.GetFiles(PastaBackup, "*.bak"))
                    {
                        FileInfo f = new FileInfo(caminho);
                        dt.Rows.Add(f.Name, f.Length, f.LastWriteTime);
                    }
                }
            }
            catch (Exception ex)
            {
                Registro.Erro(ex);
            }

            dt.DefaultView.Sort = "Data DESC";
            gvArquivos.DataSource = dt.DefaultView;
            gvArquivos.DataBind();
            AjustarGrid(gvArquivos);
        }

        protected void btnBackup_Click(object sender, EventArgs e)
        {
            string nome = Banco.NomeDoBanco() + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".bak";
            string caminho = Path.Combine(PastaBackup, nome);

            try
            {
                try { Directory.CreateDirectory(PastaBackup); }
                catch (Exception) { /* se o SQL Server for outro computador, a pasta precisa existir lá */ }

                BackupDAO.Executar(caminho);

                long? tamanho = null;
                if (File.Exists(caminho)) tamanho = new FileInfo(caminho).Length;
                BackupDAO.RegistrarLog(UsuarioLogadoId, caminho, tamanho, true, null);
                Mensagem("Backup gerado com sucesso: " + nome);
            }
            catch (Exception ex)
            {
                Registro.Erro(ex);
                try { BackupDAO.RegistrarLog(UsuarioLogadoId, caminho, null, false, Texto.Resumo(ex.Message, 400)); } catch (Exception) { }
                // tela só do administrador: mostra o motivo (ex.: falta de permissão na pasta)
                MensagemErro("Não foi possível gerar o backup: " + ex.Message);
            }
            Carregar();
        }

        protected void gvArquivos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName != "Baixar") return;

            // só aceita o NOME do arquivo (evita acessar outras pastas)
            string nome = Path.GetFileName(Convert.ToString(e.CommandArgument));
            if (!nome.EndsWith(".bak", StringComparison.OrdinalIgnoreCase)) return;

            string caminho = Path.Combine(PastaBackup, nome);
            if (!File.Exists(caminho)) { MensagemErro("Arquivo não encontrado."); return; }

            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment; filename=\"" + Uri.EscapeDataString(nome) + "\"");
            Response.TransmitFile(caminho);
            Response.Flush();
            Response.SuppressContent = true;
            Context.ApplicationInstance.CompleteRequest();
        }
    }
}
