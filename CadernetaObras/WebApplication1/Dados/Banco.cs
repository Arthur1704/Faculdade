using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1.Dados
{
    // Classe central de acesso ao SQL Server (ADO.NET).
    // Todas as consultas usam parâmetros (@nome) para evitar SQL Injection.
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

        // Cria um parâmetro. Texto vazio ou null vira NULL no banco.
        public static SqlParameter P(string nome, object valor)
        {
            if (valor == null) return new SqlParameter(nome, DBNull.Value);
            string texto = valor as string;
            if (texto != null && texto.Trim() == "") return new SqlParameter(nome, DBNull.Value);
            return new SqlParameter(nome, valor);
        }

        // SELECT que devolve várias linhas
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

        // INSERT / UPDATE / DELETE
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

        // Igual ao Executar, mas com tempo limite maior (usado no backup do banco)
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

        // Nome do banco configurado na string de conexão
        public static string NomeDoBanco()
        {
            SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder(StringConexao);
            return sb.InitialCatalog;
        }

        // SELECT que devolve um único valor (COUNT, SCOPE_IDENTITY...)
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

        // Versões que usam uma conexão/transação já aberta (para gravar várias tabelas juntas)
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
