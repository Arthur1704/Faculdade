/* Cria o primeiro usuário para conseguir entrar no sistema.
   Login: admin    Senha: 123
   TROQUE A SENHA depois do primeiro acesso (tela Usuários > Editar) e ajuste o CPF. */
USE CadernetaObras;
GO

IF NOT EXISTS (SELECT 1 FROM dbo.Usuarios WHERE Usuario = 'admin')
BEGIN
    INSERT INTO dbo.Usuarios (Nome, Usuario, Cpf, PerfilId, SenhaHash, Status)
    SELECT N'Administrador', 'admin', '52998224725', PerfilId, '100000.bNSlILWai5u0Z3PpR+QlfQ==.PqIMDTpTqxMeHB3KJutNf+Acufzxx5g3VT9L00RUcQo=', 'Ativo'
    FROM dbo.Perfis
    WHERE Nome = N'Administrador';
END
GO
