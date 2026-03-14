using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Locadora
{
    public partial class fCad2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ddlVideoGame_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblVideoGame.Text = ddlVideoGame.SelectedValue;

            if (ddlVideoGame.SelectedValue == "Sim")
            {
                pnlModelos.Visible = true;
            }
            else
            {
                pnlModelos.Visible = false;
                lblModelos.Text = "";
            }
        }

        protected void btnProximo_Click(object sender, EventArgs e)
        {
            
            if (ddlMusica.SelectedIndex == 0 ||  ddlFilme.SelectedIndex == 0 || ddlVideoGame.SelectedIndex == 0)
            {
                Response.Write("<script>alert('Preencha todos os campos obrigatórios!');</script>");
                return;
            }
            
            lblMusica.Text = ddlMusica.SelectedItem.Text;
            lblFilme.Text = ddlFilme.SelectedItem.Text;
            lblVideoGame.Text = ddlVideoGame.SelectedItem.Text;
         
            if (ddlVideoGame.SelectedItem.Text == "Sim")
            {
                if (ddlModelos.SelectedIndex == 0)
                {
                    Response.Write("<script>alert('Selecione o modelo do videogame!');</script>");
                    return;
                }

                lblModelos.Text = ddlModelos.SelectedItem.Text;
            }

            Response.Redirect("final.aspx");
        }
    }
}