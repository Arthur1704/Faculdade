using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;

namespace AppPedidos
{
    public partial class Clientes : System.Web.UI.Page
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
                string sql = "SELECT c.id_cliente, c.nome, c.email, ci.nome AS cidade FROM Cliente c INNER JOIN Cidade ci ON c.id_cidade = ci.id_cidade";
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvClientes.DataSource = dt;
                gvClientes.DataBind();
            }
        }

        protected void btnNovo_Click(object sender, EventArgs e) { Response.Redirect("ClienteForm.aspx"); }
        protected void btnCidades_Click(object sender, EventArgs e) { Response.Redirect("Cidades.aspx"); }
        protected void btnProdutos_Click(object sender, EventArgs e) { Response.Redirect("Produtos.aspx"); }
        protected void btnPedidos_Click(object sender, EventArgs e) { Response.Redirect("Pedidos.aspx"); }

        protected void gvClientes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvClientes.EditIndex = e.NewEditIndex;
            CarregarGrid();
        }

        protected void gvClientes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvClientes.EditIndex = -1;
            CarregarGrid();
        }

        protected void gvClientes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(gvClientes.DataKeys[e.RowIndex].Value);
            string nome = ((TextBox)gvClientes.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
            string email = ((TextBox)gvClientes.Rows[e.RowIndex].Cells[2].Controls[0]).Text;
            using (SqlConnection con = new SqlConnection(cn))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Cliente SET nome=@nome, email=@email WHERE id_cliente=@id", con);
                cmd.Parameters.AddWithValue("@nome", nome);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            gvClientes.EditIndex = -1;
            CarregarGrid();
        }

        protected void gvClientes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvClientes.DataKeys[e.RowIndex].Value);
            using (SqlConnection con = new SqlConnection(cn))
            {
                con.Open();
                SqlCommand chk = new SqlCommand("SELECT COUNT(*) FROM Pedido WHERE id_cliente=@id", con);
                chk.Parameters.AddWithValue("@id", id);
                int qtd = (int)chk.ExecuteScalar();
                if (qtd > 0)
                {
                    lblMsg.Text = "Não é possível excluir: cliente vinculado a pedidos.";
                    return;
                }
                SqlCommand cmd = new SqlCommand("DELETE FROM Cliente WHERE id_cliente=@id", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            CarregarGrid();
        }
    }
}