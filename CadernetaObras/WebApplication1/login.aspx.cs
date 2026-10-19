using System;
using System.Data.SqlClient;
using WebApplication1.Dados;
using WebApplication1.Modelos;

namespace WebApplication1
{
    public partial class login : System.Web.UI.Page
    {
        private const int MaximoFalhas = 5;
        private const int JanelaBloqueioMinutos = 15;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Quem já está logado vai direto para o início
            if (!IsPostBack && Session["UsuarioId"] != null)
            {
                Response.Redirect("inicio.aspx");
            }
            if (!IsPostBack && Request.QueryString["motivo"] == "encerrada")
            {
                MostrarErro("Sua sessão foi encerrada (usuário inativo ou removido). Entre novamente.");
            }
        }

        protected void btnAcessar_Click(object sender, EventArgs e)
        {
            string login = txtUsuario.Text.Trim();
            string senha = txtSenha.Text;

            if (login == "" || senha == "")
            {
                MostrarErro("Informe o usuário e a senha.");
                return;
            }

            if (login.Length > 100)
            {
                MostrarErro("Usuário ou senha inválidos.");
                return;
            }

            Usuario usuario = null;
            try
            {
                // bloqueio temporário depois de várias senhas erradas seguidas
                if (UsuarioDAO.FalhasRecentes(login, JanelaBloqueioMinutos) >= MaximoFalhas)
                {
                    MostrarErro("Muitas tentativas incorretas. Aguarde " + JanelaBloqueioMinutos + " minutos e tente novamente.");
                    return;
                }
                usuario = UsuarioDAO.Autenticar(login, senha);
                UsuarioDAO.RegistrarTentativa(login, Request.UserHostAddress, usuario != null);
            }
            catch (SqlException)
            {
                MostrarErro("Não foi possível conectar ao banco de dados. Verifique a string de conexão no Web.config.");
                return;
            }

            if (usuario == null)
            {
                MostrarErro("Usuário ou senha inválidos.");
                return;
            }
            if (usuario.Status != "Ativo")
            {
                MostrarErro("Este usuário está inativo ou pendente. Procure o administrador.");
                return;
            }

            // Guarda os dados do usuário na sessão
            Session["UsuarioId"] = usuario.Id;
            Session["UsuarioNome"] = usuario.Nome;
            Session["UsuarioPerfil"] = usuario.Perfil;

            // "Manter conectado": sessão mais longa (8 horas) em vez de 30 minutos
            Session.Timeout = chkManterConectado.Checked ? 480 : 30;

            Response.Redirect("inicio.aspx");
        }

        private void MostrarErro(string texto)
        {
            lblErro.Text = texto;
            lblErro.Visible = true;
        }
    }
}
