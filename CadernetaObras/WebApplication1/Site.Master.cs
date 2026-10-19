using System;
using System.Web;

namespace WebApplication1
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // A tela de login não usa esta master; as demais já passaram pela verificação do PaginaBase.
            string nome = Convert.ToString(Session["UsuarioNome"]);
            string perfil = Convert.ToString(Session["UsuarioPerfil"]);

            lblNomeUsuario.Text = HttpUtility.HtmlEncode(nome);
            lblPerfilUsuario.Text = HttpUtility.HtmlEncode(perfil);
            lblIniciais.Text = HttpUtility.HtmlEncode(Iniciais(nome));

            // Só o administrador enxerga o menu de usuários
            menuUsuarios.Visible = (perfil == "Administrador");
            menuBackup.Visible = (perfil == "Administrador");
        }

        // Mostra a faixa de mensagem no topo da página
        public void MostrarMensagem(string texto, bool erro)
        {
            lblMensagem.Text = HttpUtility.HtmlEncode(texto);
            pnlMensagem.CssClass = erro ? "alert alert-error page-alert" : "alert alert-success page-alert";
            pnlMensagem.Visible = true;
        }

        protected void lnkSair_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("login.aspx");
        }

        private string Iniciais(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome)) return "";
            string[] partes = nome.Trim().Split(' ');
            string iniciais = partes[0].Substring(0, 1);
            if (partes.Length > 1) iniciais += partes[partes.Length - 1].Substring(0, 1);
            return iniciais.ToUpper();
        }
    }
}
