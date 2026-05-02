using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;

namespace AppPedidos
{
    public partial class Pedidos : System.Web.UI.Page
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
                string sql = @"SELECT p.id_pedido, c.nome AS cliente, pr.nome AS produto, 
                               p.quantidade, p.data_pedido 
                               FROM Pedido p 
                               INNER JOIN Cliente c ON p.id_cliente = c.id_cliente 
                               INNER JOIN Produto pr ON p.id_produto = pr.id_produto";
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvPedidos.DataSource = dt;
                gvPedidos.DataBind();
            }
        }

        protected void btnNovo_Click(object sender, EventArgs e) { Response.Redirect("PedidoForm.aspx"); }
        protected void btnCidades_Click(object sender, EventArgs e) { Response.Redirect("Cidades.aspx"); }
        protected void btnClientes_Click(object sender, EventArgs e) { Response.Redirect("Clientes.aspx"); }
        protected void btnProdutos_Click(object sender, EventArgs e) { Response.Redirect("Produtos.aspx"); }

        protected void gvPedidos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvPedidos.EditIndex = e.NewEditIndex;
            CarregarGrid();
        }

        protected void gvPedidos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvPedidos.EditIndex = -1;
            CarregarGrid();
        }

        protected void gvPedidos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(gvPedidos.DataKeys[e.RowIndex].Value);
            string qtd = ((TextBox)gvPedidos.Rows[e.RowIndex].Cells[3].Controls[0]).Text;
            string data = ((TextBox)gvPedidos.Rows[e.RowIndex].Cells[4].Controls[0]).Text;
            using (SqlConnection con = new SqlConnection(cn))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Pedido SET quantidade=@qtd, data_pedido=@data WHERE id_pedido=@id", con);
                cmd.Parameters.AddWithValue("@qtd", Convert.ToInt32(qtd));
                cmd.Parameters.AddWithValue("@data", Convert.ToDateTime(data));
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            gvPedidos.EditIndex = -1;
            CarregarGrid();
        }

        protected void gvPedidos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvPedidos.DataKeys[e.RowIndex].Value);
            using (SqlConnection con = new SqlConnection(cn))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Pedido WHERE id_pedido=@id", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            CarregarGrid();
        }
    }
}