/* =====================================================================
   BACKUP DO BANCO CADERNETA DE OBRAS
   O sistema tem a tela "Backup" (somente Administrador) que faz isto com um clique.
   Este arquivo mostra o comando manual e como agendar.
   ===================================================================== */

-- 1) Backup manual completo (a pasta precisa existir no computador do SQL Server
--    e a conta de serviço do SQL Server precisa ter permissão de escrita nela)
BACKUP DATABASE CadernetaObras
TO DISK = 'C:\Backups\CadernetaObras\CadernetaObras.bak'
WITH INIT, CHECKSUM;
GO

-- 2) Conferir se o arquivo está íntegro
RESTORE VERIFYONLY FROM DISK = 'C:\Backups\CadernetaObras\CadernetaObras.bak' WITH CHECKSUM;
GO

-- 3) Restaurar (feche as conexões abertas antes)
-- USE master;
-- ALTER DATABASE CadernetaObras SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
-- RESTORE DATABASE CadernetaObras FROM DISK = 'C:\Backups\CadernetaObras\CadernetaObras.bak' WITH REPLACE;
-- ALTER DATABASE CadernetaObras SET MULTI_USER;

/* 4) AGENDAMENTO AUTOMÁTICO
   - SQL Server Standard/Enterprise: crie um Job no SQL Server Agent com o comando do item 1.
   - SQL Server Express (não tem Agent): use o Agendador de Tarefas do Windows chamando um .bat:

       sqlcmd -S .\SQLEXPRESS -E -Q "BACKUP DATABASE CadernetaObras TO DISK='C:\Backups\CadernetaObras\CadernetaObras_%date:~-4%%date:~3,2%%date:~0,2%.bak' WITH INIT, CHECKSUM"

   - Lembre-se também de copiar a pasta App_Data\Uploads e App_Data\Pdfs do site (anexos e PDFs gerados). */
