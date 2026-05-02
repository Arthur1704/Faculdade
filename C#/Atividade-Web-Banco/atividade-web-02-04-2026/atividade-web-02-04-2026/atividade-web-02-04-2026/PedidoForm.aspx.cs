using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace AppPedidos
{
    public partial class PedidoForm : System.Web.UI.Page
    {
        string cn = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (SqlConnection con = new SqlConnection(cn))
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Cliente", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    ddlCliente.DataSource = dt;
                    ddlCliente.DataBind();

                    SqlDataAdapter da2 = new SqlDataAdapter("SELECT * FROM Produto", con);
                    DataTable dt2 = new DataTable();
                    da2.Fill(dt2);
                    ddlProduto.DataSource = dt2;
                    ddlProduto.DataBind();
                }
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(cn))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Pedido (id_cliente, id_produto, quantidade, data_pedido) VALUES (@ic, @ip, @qtd, @data)", con);
                cmd.Parameters.AddWithValue("@ic", ddlCliente.SelectedValue);
                cmd.Parameters.AddWithValue("@ip", ddlProduto.SelectedValue);
                cmd.Parameters.AddWithValue("@qtd", Convert.ToInt32(txtQtd.Text));
                cmd.Parameters.AddWithValue("@data", Convert.ToDateTime(txtData.Text));
                cmd.ExecuteNonQuery();
            }
            Response.Redirect("Pedidos.aspx");
        }

        protected void btnVoltar_Click(object sender, EventArgs e) { Response.Redirect("Pedidos.aspx"); }
    }
}