using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class CadTecnico : System.Web.UI.Page
    {

        string connectionString = "Data Source=PC-VIANA;Initial Catalog=provaWebDB;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {            
                if (Request.QueryString["id"] != null)
                {
                    btnSalvarTecnico.Text = "Alterar Técnico";

                    SqlConnection objConexao = new SqlConnection(connectionString);                    
                    string sql = "SELECT nome_completo, especialidade, telefone, email FROM TECNICOS WHERE id = @id";
                    SqlCommand sqlCommand = new SqlCommand(sql, objConexao);
                    sqlCommand.Parameters.AddWithValue("@id", Request.QueryString["id"]);

                    objConexao.Open();
                    SqlDataReader dr = sqlCommand.ExecuteReader();
                    if (dr.Read())
                    {
                        txtNomeTecnico.Text = dr["nome_completo"].ToString();
                        txtEspecialidade.Text = dr["especialidade"].ToString();
                        txtTelefoneTecnico.Text = dr["telefone"].ToString();
                        txtEmailTecnico.Text = dr["email"].ToString();
                    }
                    dr.Close();
                    objConexao.Close();
                }
            }
        }

        protected void btnSalvarTecnico_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            string sql;

            if (string.IsNullOrEmpty(id))
            {
                sql = "INSERT INTO TECNICOS (nome_completo, especialidade, telefone, email) VALUES (@nome_completo, @especialidade, @telefone, @email)";
            }
            else
            {
                sql = "UPDATE TECNICOS SET nome_completo = @nome_completo, especialidade = @especialidade, telefone = @telefone, email = @email WHERE id = @id";
            }

            SqlConnection objConexao = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(sql, objConexao);

            sqlCommand.Parameters.Add(new SqlParameter("@nome_completo", txtNomeTecnico.Text));
            sqlCommand.Parameters.Add(new SqlParameter("@especialidade", txtEspecialidade.Text));
            sqlCommand.Parameters.Add(new SqlParameter("@telefone", txtTelefoneTecnico.Text));
            sqlCommand.Parameters.Add(new SqlParameter("@email", txtEmailTecnico.Text));
            if (!string.IsNullOrEmpty(id))
            {
                sqlCommand.Parameters.AddWithValue("@id", id);
            }

            objConexao.Open();
            sqlCommand.ExecuteNonQuery();
            objConexao.Close();

            Response.Redirect("Tecnico.aspx");
        }
    }
}