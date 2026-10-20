using System;
using System.Data;
using WebApplication1.Modelos;
using WebApplication1.Utilitarios;

namespace WebApplication1.Dados
{
    public static class SolicitacaoCadastroDAO
    {
        public static bool ExistePendente(string email)
        {
            object n = Banco.Escalar("SELECT COUNT(*) FROM SolicitacoesCadastro WHERE Email = @email AND Status = 'Pendente'", Banco.P("@email", email));
            return Convert.ToInt32(n) > 0;
        }

        public static void Inserir(SolicitacaoCadastro s)
        {
            Banco.Executar(
                "INSERT INTO SolicitacoesCadastro (Nome, Cpf, Email, Telefone, Mensagem) VALUES (@nome, @cpf, @email, @tel, @msg)",
                Banco.P("@nome", s.Nome), Banco.P("@cpf", s.Cpf), Banco.P("@email", s.Email),
                Banco.P("@tel", s.Telefone), Banco.P("@msg", s.Mensagem));
        }

        public static DataTable ListarPendentes()
        {
            return Banco.Consultar(
                @"SELECT SolicitacaoCadastroId, Nome, Cpf, Email, Telefone, Mensagem, SolicitadoEm
                  FROM SolicitacoesCadastro WHERE Status = 'Pendente' ORDER BY SolicitacaoCadastroId");
        }

        public static SolicitacaoCadastro Obter(int id)
        {
            DataTable dt = Banco.Consultar("SELECT * FROM SolicitacoesCadastro WHERE SolicitacaoCadastroId = @id", Banco.P("@id", id));
            if (dt.Rows.Count == 0) return null;
            DataRow r = dt.Rows[0];
            SolicitacaoCadastro s = new SolicitacaoCadastro();
            s.Id = (int)r["SolicitacaoCadastroId"];
            s.Nome = Texto.Valor(r["Nome"]);
            s.Cpf = Texto.Valor(r["Cpf"]);
            s.Email = Texto.Valor(r["Email"]);
            s.Telefone = Texto.Valor(r["Telefone"]);
            s.Mensagem = Texto.Valor(r["Mensagem"]);
            s.Status = Texto.Valor(r["Status"]);
            s.SolicitadoEm = Convert.ToDateTime(r["SolicitadoEm"]);
            return s;
        }

        public static void Analisar(int id, string status, int usuarioId)
        {
            Banco.Executar(
                @"UPDATE SolicitacoesCadastro SET Status = @status, AnalisadoPorUsuarioId = @usuario, AnalisadoEm = SYSDATETIME()
                  WHERE SolicitacaoCadastroId = @id",
                Banco.P("@id", id), Banco.P("@status", status), Banco.P("@usuario", usuarioId));
        }
    }
}
