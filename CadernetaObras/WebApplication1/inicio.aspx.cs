using System;
using System.Data;
using WebApplication1.Dados;

namespace WebApplication1
{
    public partial class inicio : PaginaBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cardUsuarios.Visible = (PerfilLogado == "Administrador");

            if (IsPostBack) return;

            try
            {
                DataRow t = DashboardDAO.Totais();
                lblObras.Text = Convert.ToInt32(t["TotalObras"]).ToString("00");
                lblObrasAndamento.Text = t["ObrasAndamento"].ToString();
                lblProprietarios.Text = Convert.ToInt32(t["TotalProprietarios"]).ToString("00");
                lblProprietariosAtivos.Text = t["ProprietariosAtivos"].ToString();
                lblProfissionais.Text = Convert.ToInt32(t["TotalProfissionais"]).ToString("00");
                lblProfissionaisAtivos.Text = t["ProfissionaisAtivos"].ToString();
                lblRecibos.Text = Convert.ToInt32(t["TotalRecibos"]).ToString("00");
                lblRecibosAguardando.Text = t["RecibosAguardando"].ToString();
            }
            catch (Exception ex)
            {
                MensagemErro(TextoErroBanco(ex));
            }
        }
    }
}
