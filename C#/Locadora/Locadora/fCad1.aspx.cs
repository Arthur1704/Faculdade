using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Locadora
{
    public partial class fCad1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnProx_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                Response.Write("<script>alert('Entre com um Nome!');</script>");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtData.Text))
            {
                Response.Write("<script>alert('Entre com uma Data de Nascimento!');</script>");
                return;
            }
            if (!int.TryParse(txtCPF.Text, out int CPF))
            {
                Response.Write("<script>alert('Entre com um CPF valido!');</script>");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtRG.Text))
            {
                Response.Write("<script>alert('Entre com um RG!');</script>");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtEndereco.Text))
            {
                Response.Write("<script>alert('Entre com um Endereço!');</script>");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtBairro.Text))
            {
                Response.Write("<script>alert('Entre com um Bairro');</script>");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtCidade.Text))
            {
                Response.Write("<script>alert('Entre com um Cidade');</script>");
                return;
            }
            if (string.IsNullOrWhiteSpace(ddlUF.SelectedValue))          
            {
                Response.Write("<script>alert('Selecione uma UF');</script>");
                return;
            }
            Response.Redirect("fCad2.aspx");
        }

        protected void txtNome_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ddlUF_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            btnProx.Visible = true;
        }
    }
}