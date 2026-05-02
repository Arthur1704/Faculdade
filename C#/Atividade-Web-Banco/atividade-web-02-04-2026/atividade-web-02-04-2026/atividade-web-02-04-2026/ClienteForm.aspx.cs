using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace AppPedidos
{
    public partial class ClienteForm : System.Web.UI.Page
    {
        string cn = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (SqlConnection con = new SqlConnection(cn))
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Cidade", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    ddlCidade.DataSource = dt;
                    ddlCidade.DataBind();
                }
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(cn))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Cliente (nome, email, id_cidade) VALUES (@nome, @email, @id_cidade)", con);
                cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@id_cidade", ddlCidade.SelectedValue);
                cmd.ExecuteNonQuery();
            }
            Response.Redirect("Clientes.aspx");
        }

        protected void btnVoltar_Click(object sender, EventArgs e) { Response.Redirect("Clientes.aspx"); }
    }
}