using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebApplication1.Modelos;
using WebApplication1.Utilitarios;

namespace WebApplication1.Dados
{
    public static class UsuarioDAO
    {
        public static DataTable Listar(string pesquisa, string status, string ordem)
        {
            string sql = @"SELECT u.UsuarioId, u.Nome, u.Usuario, p.Nome AS Perfil, u.Status
                           FROM Usuarios u
                           INNER JOIN Perfis p ON p.PerfilId = u.PerfilId
                           WHERE 1 = 1";
            List<SqlParameter> ps = new List<SqlParameter>();

            if (!string.IsNullOrWhiteSpace(pesquisa))
            {
                sql += " AND (u.Nome LIKE @p OR u.Usuario LIKE @p OR u.Email LIKE @p OR u.Matricula LIKE @p";
                ps.Add(Banco.P("@p", "%" + pesquisa.Trim() + "%"));
                string digitos = Texto.SoDigitos(pesquisa);
                if (digitos != "")
                {
                    sql += " OR u.Cpf LIKE @d";
                    ps.Add(Banco.P("@d", "%" + digitos + "%"));
                }
                sql += ")";
            }
            if (!string.IsNullOrEmpty(status))
            {
                sql += " AND u.Status = @status";
                ps.Add(Banco.P("@status", status));
            }
            sql += Texto.Ordenar(ordem, "u.Nome", "u.CriadoEm");
            return Banco.Consultar(sql, ps.ToArray());
        }

        public static Usuario Obter(int id)
        {
            string sql = @"SELECT u.*, p.Nome AS PerfilNome
                           FROM Usuarios u
                           INNER JOIN Perfis p ON p.PerfilId = u.PerfilId
                           WHERE u.UsuarioId = @id";
            DataTable dt = Banco.Consultar(sql, Banco.P("@id", id));
            if (dt.Rows.Count == 0) return null;
            return Mapear(dt.Rows[0]);
        }

        private static Usuario Mapear(DataRow r)
        {
            Usuario u = new Usuario();
            u.Id = (int)r["UsuarioId"];
            u.Nome = Texto.Valor(r["Nome"]);
            u.Login = Texto.Valor(r["Usuario"]);
            u.Matricula = Texto.Valor(r["Matricula"]);
            u.Cpf = Texto.Valor(r["Cpf"]);
            u.Email = Texto.Valor(r["Email"]);
            u.Telefone = Texto.Valor(r["Telefone"]);
            u.PerfilId = (int)r["PerfilId"];
            u.Perfil = Texto.Valor(r["PerfilNome"]);
            u.Status = Texto.Valor(r["Status"]);
            u.SenhaHash = Texto.Valor(r["SenhaHash"]);
            u.AtualizadoEm = Texto.Data(r["AtualizadoEm"]) ?? Texto.Data(r["CriadoEm"]);
            return u;
        }

        // Se SenhaHash vier vazio na edição, a senha atual é mantida.
        public static void Salvar(Usuario u)
        {
            string sql;
            if (u.Id == 0)
            {
                sql = @"INSERT INTO Usuarios (Nome, Usuario, Matricula, Cpf, Email, Telefone, PerfilId, SenhaHash, Status)
                        VALUES (@nome, @login, @mat, @cpf, @email, @tel, @perfil, @senha, @status)";
            }
            else
            {
                sql = @"UPDATE Usuarios SET Nome = @nome, Usuario = @login, Matricula = @mat, Cpf = @cpf, Email = @email,
                        Telefone = @tel, PerfilId = @perfil, Status = @status, AtualizadoEm = SYSDATETIME()";
                if (!string.IsNullOrEmpty(u.SenhaHash)) sql += ", SenhaHash = @senha";
                sql += " WHERE UsuarioId = @id";
            }
            Banco.Executar(sql,
                Banco.P("@id", u.Id), Banco.P("@nome", u.Nome), Banco.P("@login", u.Login),
                Banco.P("@mat", u.Matricula), Banco.P("@cpf", u.Cpf), Banco.P("@email", u.Email),
                Banco.P("@tel", u.Telefone), Banco.P("@perfil", u.PerfilId), Banco.P("@senha", u.SenhaHash),
                Banco.P("@status", u.Status));
        }

        public static void AlternarStatus(int id)
        {
            Banco.Executar(@"UPDATE Usuarios
                             SET Status = CASE WHEN Status = 'Ativo' THEN 'Inativo' ELSE 'Ativo' END,
                                 AtualizadoEm = SYSDATETIME()
                             WHERE UsuarioId = @id", Banco.P("@id", id));
        }

        // Devolve o usuário se login e senha conferem; senão devolve null.
        public static Usuario Autenticar(string login, string senha)
        {
            string sql = @"SELECT u.*, p.Nome AS PerfilNome
                           FROM Usuarios u
                           INNER JOIN Perfis p ON p.PerfilId = u.PerfilId
                           WHERE u.Usuario = @login OR u.Matricula = @login";
            DataTable dt = Banco.Consultar(sql, Banco.P("@login", login));
            if (dt.Rows.Count == 0) return null;

            Usuario u = Mapear(dt.Rows[0]);
            if (!Seguranca.Verificar(senha, u.SenhaHash)) return null;

            if (u.Status == "Ativo")
                Banco.Executar("UPDATE Usuarios SET UltimoAcessoEm = SYSDATETIME() WHERE UsuarioId = @id", Banco.P("@id", u.Id));
            return u;
        }

        // Quantos administradores ativos existem (impede ficar sem nenhum)
        public static int ContarAdministradoresAtivos()
        {
            object n = Banco.Escalar(@"SELECT COUNT(*) FROM Usuarios u
                                       INNER JOIN Perfis p ON p.PerfilId = u.PerfilId
                                       WHERE p.Nome = 'Administrador' AND u.Status = 'Ativo'");
            return Convert.ToInt32(n);
        }

        // ---------- Proteção contra tentativas repetidas de login ----------
        public static void RegistrarTentativa(string login, string ip, bool sucesso)
        {
            Banco.Executar("INSERT INTO TentativasLogin (Login, Ip, Sucesso) VALUES (@login, @ip, @sucesso)",
                Banco.P("@login", login), Banco.P("@ip", ip), Banco.P("@sucesso", sucesso));
        }

        // Falhas desse login nos últimos X minutos (depois do último acerto)
        public static int FalhasRecentes(string login, int minutos)
        {
            object n = Banco.Escalar(@"SELECT COUNT(*) FROM TentativasLogin
                                       WHERE Login = @login AND Sucesso = 0
                                         AND DataHora >= DATEADD(MINUTE, -@minutos, SYSDATETIME())
                                         AND DataHora > ISNULL((SELECT MAX(DataHora) FROM TentativasLogin WHERE Login = @login AND Sucesso = 1), '19000101')",
                Banco.P("@login", login), Banco.P("@minutos", minutos));
            return Convert.ToInt32(n);
        }
    }
}
