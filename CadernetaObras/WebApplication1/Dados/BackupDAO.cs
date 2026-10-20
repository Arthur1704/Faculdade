using System.Data;

namespace WebApplication1.Dados
{
    public static class BackupDAO
    {
        public static void Executar(string arquivoCompleto)
        {
            string sql = @"DECLARE @comando NVARCHAR(MAX) =
                               N'BACKUP DATABASE ' + QUOTENAME(DB_NAME()) + N' TO DISK = @arq WITH INIT, CHECKSUM';
                           EXEC sp_executesql @comando, N'@arq NVARCHAR(500)', @arq = @arquivo;";
            Banco.ExecutarLongo(sql, 900, Banco.P("@arquivo", arquivoCompleto));
        }

        public static void RegistrarLog(int usuarioId, string arquivo, long? tamanho, bool sucesso, string mensagem)
        {
            Banco.Executar(
                "INSERT INTO LogBackup (UsuarioId, Arquivo, TamanhoBytes, Sucesso, Mensagem) VALUES (@usuario, @arquivo, @tamanho, @sucesso, @msg)",
                Banco.P("@usuario", usuarioId), Banco.P("@arquivo", arquivo), Banco.P("@tamanho", tamanho),
                Banco.P("@sucesso", sucesso), Banco.P("@msg", mensagem));
        }

        public static DataTable ListarLog()
        {
            return Banco.Consultar(
                @"SELECT TOP 20 b.BackupId, b.Arquivo, b.TamanhoBytes, b.Sucesso, b.Mensagem, b.CriadoEm, u.Nome AS Usuario
                  FROM LogBackup b
                  INNER JOIN Usuarios u ON u.UsuarioId = b.UsuarioId
                  ORDER BY b.BackupId DESC");
        }
    }
}
