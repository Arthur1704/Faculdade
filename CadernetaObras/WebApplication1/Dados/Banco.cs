using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1.Dados
{
    public static class Banco
    {
        private static string StringConexao
        {
            get { return ConfigurationManager.ConnectionStrings["CadernetaObras"].ConnectionString; }
        }

        public static SqlConnection NovaConexao()
        {
            return new SqlConnection(StringConexao);
        }

        public static SqlParameter P(string nome, object valor)
        {
            if (valor == null) return new SqlParameter(nome, DBNull.Value);
            string texto = valor as string;
            if (texto != null && texto.Trim() == "") return new SqlParameter(nome, DBNull.Value);
            return new SqlParameter(nome, valor);
        }

        public static DataTable Consultar(string sql, params SqlParameter[] parametros)
        {
            using (SqlConnection con = NovaConexao())
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                if (parametros != null) cmd.Parameters.AddRange(parametros);
                DataTable tabela = new DataTable();
                SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
                adaptador.Fill(tabela);
                return tabela;
            }
        }

        public static int Executar(string sql, params SqlParameter[] parametros)
        {
            using (SqlConnection con = NovaConexao())
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                if (parametros != null) cmd.Parameters.AddRange(parametros);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public static int ExecutarLongo(string sql, int segundos, params SqlParameter[] parametros)
        {
            using (SqlConnection con = NovaConexao())
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.CommandTimeout = segundos;
                if (parametros != null) cmd.Parameters.AddRange(parametros);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public static string NomeDoBanco()
        {
            SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder(StringConexao);
            return sb.InitialCatalog;
        }

        public static object Escalar(string sql, params SqlParameter[] parametros)
        {
            using (SqlConnection con = NovaConexao())
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                if (parametros != null) cmd.Parameters.AddRange(parametros);
                con.Open();
                return cmd.ExecuteScalar();
            }
        }

        public static int Executar(SqlConnection con, SqlTransaction tx, string sql, params SqlParameter[] parametros)
        {
            using (SqlCommand cmd = new SqlCommand(sql, con, tx))
            {
                if (parametros != null) cmd.Parameters.AddRange(parametros);
                return cmd.ExecuteNonQuery();
            }
        }

        public static object Escalar(SqlConnection con, SqlTransaction tx, string sql, params SqlParameter[] parametros)
        {
            using (SqlCommand cmd = new SqlCommand(sql, con, tx))
            {
                if (parametros != null) cmd.Parameters.AddRange(parametros);
                return cmd.ExecuteScalar();
            }
        }
    }
}
