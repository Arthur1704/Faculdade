using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Tecnico : System.Web.UI.Page
    {
        string connectionString = "Data Source=PC-VIANA;Initial Catalog=provaWebDB;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            string strSql;
            if (!IsPostBack)
            {
                strSql = "SELECT * FROM tecnicos";

                SqlConnection objConexao = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand(strSql, objConexao);
                DataTable dt = new DataTable();
                objConexao.Open();
                dt.Load(sqlCommand.ExecuteReader());
                rptTecnico.DataSource = dt;
                rptTecnico.DataBind();

            }
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {

            Button btn = (Button)sender;
            string id = btn.CommandArgument;
            string strSql = "DELETE FROM tecnicos WHERE id = @id";

            SqlConnection objConexao = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(strSql, objConexao);

            sqlCommand.Parameters.AddWithValue("@id", id);

            objConexao.Open();
            sqlCommand.ExecuteNonQuery();
            objConexao.Close();

            Response.Redirect("Tecnico.aspx");
        }
    }
}