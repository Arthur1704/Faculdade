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
    public partial class OS : System.Web.UI.Page
    {
        string connectionString = "Data Source=PC-VIANA;Initial Catalog=provaWebDB;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlConnection con = new SqlConnection(connectionString);
                if (Request.QueryString["id"] != null)
                {
                    btnSalvar.Text = "Alterar Demanda";
                }

                string sqlClientes = "SELECT id, nome_completo FROM clientes";
                SqlDataAdapter daClientes = new SqlDataAdapter(sqlClientes, con);
                DataTable dtClientes = new DataTable();
                daClientes.Fill(dtClientes);

                ddlCliente.DataSource = dtClientes;
                ddlCliente.DataTextField = "nome_completo";
                ddlCliente.DataValueField = "id";
                ddlCliente.DataBind();
                ddlCliente.Items.Insert(0, new ListItem("Selecione um Cliente", "0"));
       
                string sqlTecnicos = "SELECT id, nome_completo FROM tecnicos";
                SqlDataAdapter daTecnicos = new SqlDataAdapter(sqlTecnicos, con);
                DataTable dtTecnicos = new DataTable();
                daTecnicos.Fill(dtTecnicos);

                ddlTecnico.DataSource = dtTecnicos;
                ddlTecnico.DataTextField = "nome_completo";
                ddlTecnico.DataValueField = "id";
                ddlTecnico.DataBind();
                ddlTecnico.Items.Insert(0, new ListItem("Selecione um Técnico", "0"));


                if (Request.QueryString["id"] != null)
                {
                    btnSalvar.Text = "Alterar Demanda";
                    string sql = "SELECT cliente_id, tecnico_id, equipamento, modelo_marca, num_serie, defeito, data_entrada, status FROM ORDENS_SERVICO WHERE id = @id";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@id", Request.QueryString["id"]);

                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        ddlCliente.SelectedValue = dr["cliente_id"].ToString();
                        ddlTecnico.SelectedValue = dr["tecnico_id"].ToString();
                        txtEquipamento.Text = dr["equipamento"].ToString();
                        txtModeloMarca.Text = dr["modelo_marca"].ToString();
                        txtNumSerie.Text = dr["num_serie"].ToString();
                        txtDefeito.Text = dr["defeito"].ToString();
                        txtData.Text = Convert.ToDateTime(dr["data_entrada"]).ToString("yyyy-MM-dd");
                        ddlStatus.SelectedValue = dr["status"].ToString();
                    }
                    dr.Close();
                    con.Close();
                }
            }

        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            string sql;

            if (string.IsNullOrEmpty(id))
            {
                sql = @"INSERT INTO ORDENS_SERVICO (cliente_id, tecnico_id, equipamento, modelo_marca, num_serie, defeito, data_entrada, status) 
                VALUES (@cliente_id, @tecnico_id, @equipamento, @modelo_marca, @num_serie, @defeito, @data_entrada, @status)";
            }
            else
            {
                sql = @"UPDATE ORDENS_SERVICO SET cliente_id = @cliente_id, tecnico_id = @tecnico_id, equipamento = @equipamento, 
                modelo_marca = @modelo_marca, num_serie = @num_serie, defeito = @defeito, data_entrada = @data_entrada, status = @status 
                WHERE id = @id";
            }


            SqlConnection objConexao = new SqlConnection(connectionString);

            SqlCommand sqlCommand = new SqlCommand(sql, objConexao);

            sqlCommand.Parameters.AddWithValue("@cliente_id", ddlCliente.SelectedValue);
            sqlCommand.Parameters.AddWithValue("@tecnico_id", ddlTecnico.SelectedValue);

            
            sqlCommand.Parameters.AddWithValue("@equipamento", txtEquipamento.Text);
            sqlCommand.Parameters.AddWithValue("@modelo_marca", txtModeloMarca.Text);
            sqlCommand.Parameters.AddWithValue("@num_serie", txtNumSerie.Text);
            sqlCommand.Parameters.AddWithValue("@defeito", txtDefeito.Text);
            sqlCommand.Parameters.AddWithValue("@data_entrada", txtData.Text);
            sqlCommand.Parameters.AddWithValue("@status", ddlStatus.SelectedItem.Text);
            if (!string.IsNullOrEmpty(id))
            {
                sqlCommand.Parameters.AddWithValue("@id", id);
            }

            objConexao.Open();
            sqlCommand.ExecuteNonQuery();

            Response.Redirect("index.aspx");
        }
    }
}