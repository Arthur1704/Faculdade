using System;
using System.Data.SqlClient;
using System.Configuration;

namespace AppPedidos
{
    public partial class CidadeForm : System.Web.UI.Page
    {
        string cn = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(cn))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Cidade (nome) VALUES (@nome)", con);
                cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                cmd.ExecuteNonQuery();
            }
            Response.Redirect("Cidades.aspx");
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cidades.aspx");
        }
    }
}