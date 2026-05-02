using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;

namespace AppPedidos
{
    public partial class Produtos : System.Web.UI.Page
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
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Produto", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvProdutos.DataSource = dt;
                gvProdutos.DataBind();
            }
        }

        protected void btnNovo_Click(object sender, EventArgs e) { Response.Redirect("ProdutoForm.aspx"); }
        protected void btnCidades_Click(object sender, EventArgs e) { Response.Redirect("Cidades.aspx"); }
        protected void btnClientes_Click(object sender, EventArgs e) { Response.Redirect("Clientes.aspx"); }
        protected void btnPedidos_Click(object sender, EventArgs e) { Response.Redirect("Pedidos.aspx"); }

        protected void gvProdutos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvProdutos.EditIndex = e.NewEditIndex;
            CarregarGrid();
        }

        protected void gvProdutos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvProdutos.EditIndex = -1;
            CarregarGrid();
        }

        protected void gvProdutos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(gvProdutos.DataKeys[e.RowIndex].Value);
            string nome = ((TextBox)gvProdutos.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
            string preco = ((TextBox)gvProdutos.Rows[e.RowIndex].Cells[2].Controls[0]).Text;
            using (SqlConnection con = new SqlConnection(cn))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Produto SET nome=@nome, preco=@preco WHERE id_produto=@id", con);
                cmd.Parameters.AddWithValue("@nome", nome);
                cmd.Parameters.AddWithValue("@preco", Convert.ToDecimal(preco));
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            gvProdutos.EditIndex = -1;
            CarregarGrid();
        }

        protected void gvProdutos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvProdutos.DataKeys[e.RowIndex].Value);
            using (SqlConnection con = new SqlConnection(cn))
            {
                con.Open();
                SqlCommand chk = new SqlCommand("SELECT COUNT(*) FROM Pedido WHERE id_produto=@id", con);
                chk.Parameters.AddWithValue("@id", id);
                int qtd = (int)chk.ExecuteScalar();
                if (qtd > 0)
                {
                    lblMsg.Text = "Não é possível excluir: produto vinculado a pedidos.";
                    return;
                }
                SqlCommand cmd = new SqlCommand("DELETE FROM Produto WHERE id_produto=@id", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            CarregarGrid();
        }
    }
}