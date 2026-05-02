using System;
using System.Data.SqlClient;
using System.Configuration;

namespace AppPedidos
{
    public partial class ProdutoForm : System.Web.UI.Page
    {
        string cn = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(cn))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Produto (nome, preco) VALUES (@nome, @preco)", con);
                cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                cmd.Parameters.AddWithValue("@preco", Convert.ToDecimal(txtPreco.Text));
                cmd.ExecuteNonQuery();
            }
            Response.Redirect("Produtos.aspx");
        }

        protected void btnVoltar_Click(object sender, EventArgs e) { Response.Redirect("Produtos.aspx"); }
    }
}