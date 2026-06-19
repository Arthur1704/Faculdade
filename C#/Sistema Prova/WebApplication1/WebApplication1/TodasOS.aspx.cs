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
    public partial class TodasOS : System.Web.UI.Page
    {
        string connectionString = "Data Source=PC-VIANA;Initial Catalog=provaWebDB;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {


            string strSql = @"SELECT OS.id, C.nome_completo AS nome_cliente, OS.equipamento, 
                             OS.defeito, OS.data_entrada, OS.status, T.nome_completo AS nome_tecnico
                      FROM ORDENS_SERVICO OS
                      INNER JOIN CLIENTES C ON OS.cliente_id = C.id
                      INNER JOIN TECNICOS T ON OS.tecnico_id = T.id";

            SqlConnection con = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand(strSql, con);

            DataTable dt = new DataTable();
            con.Open();
            dt.Load(cmd.ExecuteReader());

            rptTodasDemandas.DataSource = dt;
            rptTodasDemandas.DataBind();

        }
    }
}