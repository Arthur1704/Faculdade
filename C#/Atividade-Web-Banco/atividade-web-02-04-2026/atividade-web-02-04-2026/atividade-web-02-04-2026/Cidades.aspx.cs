using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;

namespace AppPedidos
{
    public partial class Cidades : System.Web.UI.Page
    {
        string cn = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) CarregarGrid();
        }

        void CarregarGrid()
        {
            using (SqlConnection con = new SqlConnection(cn))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Cidade", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvCidades.DataSource = dt;
                gvCidades.DataBind();
            }
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            Response.Redirect("CidadeForm.aspx");
        }

        protected void btnClientes_Click(object sender, EventArgs e) { Response.Redirect("Clientes.aspx"); }
        protected void btnProdutos_Click(object sender, EventArgs e) { Response.Redirect("Produtos.aspx"); }
        protected void btnPedidos_Click(object sender, EventArgs e) { Response.Redirect("Pedidos.aspx"); }

        protected void gvCidades_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvCidades.EditIndex = e.NewEditIndex;
            CarregarGrid();
        }

        protected void gvCidades_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvCidades.EditIndex = -1;
            CarregarGrid();
        }

        protected void gvCidades_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(gvCidades.DataKeys[e.RowIndex].Value);
            string nome = ((TextBox)gvCidades.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
            using (SqlConnection con = new SqlConnection(cn))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Cidade SET nome=@nome WHERE id_cidade=@id", con);
                cmd.Parameters.AddWithValue("@nome", nome);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            gvCidades.EditIndex = -1;
            CarregarGrid();
        }

        protected void gvCidades_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvCidades.DataKeys[e.RowIndex].Value);
            using (SqlConnection con = new SqlConnection(cn))
            {
                con.Open();
                SqlCommand chk = new SqlCommand("SELECT COUNT(*) FROM Cliente WHERE id_cidade=@id", con);
                chk.Parameters.AddWithValue("@id", id);
                int qtd = (int)chk.ExecuteScalar();
                if (qtd > 0)
                {
                    lblMsg.Text = "Não é possível excluir: cidade vinculada a clientes.";
                    return;
                }
                SqlCommand cmd = new SqlCommand("DELETE FROM Cidade WHERE id_cidade=@id", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            CarregarGrid();
        }
    }
}