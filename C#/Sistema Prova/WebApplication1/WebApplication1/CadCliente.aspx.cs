using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class CadCliente : System.Web.UI.Page
    {
        string connectionString = "Data Source=PC-VIANA;Initial Catalog=provaWebDB;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { 
                if (Request.QueryString["id"] != null)
                {
                    btnSalvar.Text = "Alterar Cliente";

                    SqlConnection con = new SqlConnection(connectionString);
                    String id = Request.QueryString["id"];

                    string sql = "SELECT nome_completo, documento, telefone, email FROM clientes WHERE id = @id";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@id", id);
                    con.Open();

                    SqlDataReader dr = cmd.ExecuteReader();
                    
                    if (dr.Read())
                    {
                        txtNome.Text = dr["nome_completo"].ToString();
                        txtDocumento.Text = dr["documento"].ToString();
                        txtTelefone.Text = dr["telefone"].ToString();
                        txtEmail.Text = dr["email"].ToString();
                    }                                  
                }
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {

            string id = Request.QueryString["id"];
            String sql;

            if (string.IsNullOrEmpty(id))
            {               
                sql = "INSERT INTO CLIENTES (nome_completo, documento, telefone, email) VALUES (@nome_completo, @documento, @telefone, @email)";
            }
            else
            {               
                sql = "UPDATE CLIENTES SET nome_completo = @nome_completo, documento = @documento, telefone = @telefone, email = @email WHERE id = @id";
            }
            

            SqlConnection objConexao = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(sql, objConexao);

            sqlCommand.Parameters.Add(new SqlParameter("@nome_completo", txtNome.Text));
            sqlCommand.Parameters.Add(new SqlParameter("@documento", txtDocumento.Text));
            sqlCommand.Parameters.Add(new SqlParameter("@telefone", txtTelefone.Text));
            sqlCommand.Parameters.Add(new SqlParameter("@email", txtEmail.Text));
            if (!string.IsNullOrEmpty(id))
            {
                sqlCommand.Parameters.Add(new SqlParameter("@id", id));
            }


            objConexao.Open();
            sqlCommand.ExecuteNonQuery();
            objConexao.Close();

            Response.Redirect("Clientes.aspx");

        }
    }
}