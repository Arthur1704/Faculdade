/* =====================================================================
   CADERNETA DE OBRAS - ATUALIZAÇÃO DO BANCO PARA A VERSÃO 2
   Use este script em um banco JÁ CRIADO com o 01_CriarBanco.sql da versão 1.
   (Em instalação nova use apenas o 01_CriarBanco.sql, que já está atualizado.)

   - Pode ser executado mais de uma vez: cada passo verifica se já foi aplicado.
   - Não apaga dados. Faça um backup antes (BACKUP DATABASE CadernetaObras ...).
   - O que muda:
       1) Obras: responsável técnico, RT, empresa, nº da caderneta, valor, 4 áreas
       2) RelatosVisita: numeração sequencial por obra (NumeroNaObra)
       3) RelatoVisitaAnexos: descrição; TermosConclusao: caminho do PDF
       4) Novas tabelas: ObraDocumentos, AssinaturasObra/Visita/Termo, LogBackup, TentativasLogin
       5) Dados de domínio: tipos de edificação, atividades técnicas, etapas, perfis
   ===================================================================== */

SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
GO

USE CadernetaObras;
GO

/* ---------- 1) OBRAS ---------- */
IF COL_LENGTH('dbo.Obras', 'ProfissionalId')   IS NULL ALTER TABLE dbo.Obras ADD ProfissionalId INT NULL;
IF COL_LENGTH('dbo.Obras', 'NumeroRT')         IS NULL ALTER TABLE dbo.Obras ADD NumeroRT NVARCHAR(30) NULL;
IF COL_LENGTH('dbo.Obras', 'Empresa')          IS NULL ALTER TABLE dbo.Obras ADD Empresa NVARCHAR(150) NULL;
IF COL_LENGTH('dbo.Obras', 'NumeroCaderneta')  IS NULL ALTER TABLE dbo.Obras ADD NumeroCaderneta NVARCHAR(20) NULL;
IF COL_LENGTH('dbo.Obras', 'ValorObra')        IS NULL ALTER TABLE dbo.Obras ADD ValorObra DECIMAL(15,2) NULL;
IF COL_LENGTH('dbo.Obras', 'AreaAmpliar')      IS NULL ALTER TABLE dbo.Obras ADD AreaAmpliar DECIMAL(12,2) NULL;
IF COL_LENGTH('dbo.Obras', 'AreaRegularizar')  IS NULL ALTER TABLE dbo.Obras ADD AreaRegularizar DECIMAL(12,2) NULL;
GO

IF NOT EXISTS (SELECT 1 FROM sys.foreign_keys WHERE name = 'FK_Obras_Profissionais')
    ALTER TABLE dbo.Obras ADD CONSTRAINT FK_Obras_Profissionais
        FOREIGN KEY (ProfissionalId) REFERENCES dbo.Profissionais (ProfissionalId);
GO

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_Obras_Profissional' AND object_id = OBJECT_ID('dbo.Obras'))
    CREATE INDEX IX_Obras_Profissional ON dbo.Obras (ProfissionalId);
GO

-- A restrição de áreas e a área total passam a considerar as 4 áreas
IF EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CK_Obras_Areas' AND parent_object_id = OBJECT_ID('dbo.Obras'))
    ALTER TABLE dbo.Obras DROP CONSTRAINT CK_Obras_Areas;
GO

IF EXISTS (SELECT 1 FROM sys.computed_columns
           WHERE object_id = OBJECT_ID('dbo.Obras') AND name = 'AreaTotal' AND definition NOT LIKE '%AreaAmpliar%')
    ALTER TABLE dbo.Obras DROP COLUMN AreaTotal;
GO

IF COL_LENGTH('dbo.Obras', 'AreaTotal') IS NULL
    ALTER TABLE dbo.Obras ADD AreaTotal AS
        (ISNULL(AreaConstruir, 0) + ISNULL(AreaAmpliar, 0) + ISNULL(AreaRegularizar, 0) + ISNULL(AreaReforma, 0)) PERSISTED;
GO

IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CK_Obras_Areas' AND parent_object_id = OBJECT_ID('dbo.Obras'))
    ALTER TABLE dbo.Obras ADD CONSTRAINT CK_Obras_Areas
        CHECK (ISNULL(AreaConstruir,0) >= 0 AND ISNULL(AreaAmpliar,0) >= 0
               AND ISNULL(AreaRegularizar,0) >= 0 AND ISNULL(AreaReforma,0) >= 0);
GO

/* ---------- 2) RELATOS DE VISITA: numeração por obra ---------- */
IF COL_LENGTH('dbo.RelatosVisita', 'NumeroNaObra') IS NULL
    ALTER TABLE dbo.RelatosVisita ADD NumeroNaObra INT NULL;
GO

-- Relatos já existentes recebem 1, 2, 3... dentro de cada obra (pela ordem de cadastro)
UPDATE r
SET    NumeroNaObra = ISNULL(m.Maximo, 0) + x.n
FROM   dbo.RelatosVisita r
INNER JOIN (SELECT RelatoVisitaId,
                   ROW_NUMBER() OVER (PARTITION BY ObraId ORDER BY RelatoVisitaId) AS n
            FROM   dbo.RelatosVisita
            WHERE  NumeroNaObra IS NULL) x ON x.RelatoVisitaId = r.RelatoVisitaId
LEFT JOIN (SELECT ObraId, MAX(NumeroNaObra) AS Maximo
           FROM   dbo.RelatosVisita
           GROUP BY ObraId) m ON m.ObraId = r.ObraId;
GO

IF EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('dbo.RelatosVisita') AND name = 'NumeroNaObra' AND is_nullable = 1)
    ALTER TABLE dbo.RelatosVisita ALTER COLUMN NumeroNaObra INT NOT NULL;
GO

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'UX_RelatosVisita_NumeroObra' AND object_id = OBJECT_ID('dbo.RelatosVisita'))
    CREATE UNIQUE INDEX UX_RelatosVisita_NumeroObra ON dbo.RelatosVisita (ObraId, NumeroNaObra);
GO

/* ---------- 3) ANEXOS E TERMOS ---------- */
IF COL_LENGTH('dbo.RelatoVisitaAnexos', 'Descricao') IS NULL
    ALTER TABLE dbo.RelatoVisitaAnexos ADD Descricao NVARCHAR(255) NULL;
GO

IF COL_LENGTH('dbo.TermosConclusao', 'PdfFinal') IS NULL
    ALTER TABLE dbo.TermosConclusao ADD PdfFinal NVARCHAR(255) NULL;
GO

/* ---------- 4) NOVAS TABELAS ---------- */
IF OBJECT_ID(N'dbo.ObraDocumentos', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.ObraDocumentos (
        DocumentoId    INT IDENTITY(1,1) NOT NULL,
        ObraId         INT               NOT NULL,
        NomeDocumento  NVARCHAR(150)     NOT NULL,
        TipoDocumento  NVARCHAR(50)      NULL,
        NomeOriginal   NVARCHAR(260)     NOT NULL,
        CaminhoArquivo NVARCHAR(500)     NOT NULL,
        ContentType    VARCHAR(100)      NULL,
        TamanhoBytes   BIGINT            NULL,
        EnviadoEm      DATETIME2(0)      NOT NULL CONSTRAINT DF_ObraDocumentos_EnviadoEm DEFAULT (SYSDATETIME()),
        CONSTRAINT PK_ObraDocumentos PRIMARY KEY (DocumentoId),
        CONSTRAINT FK_ObraDocumentos_Obras FOREIGN KEY (ObraId) REFERENCES dbo.Obras (ObraId) ON DELETE CASCADE
    );
    CREATE INDEX IX_ObraDocumentos_Obra ON dbo.ObraDocumentos (ObraId);
END
GO

IF OBJECT_ID(N'dbo.AssinaturasObra', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.AssinaturasObra (
        AssinaturaObraId  INT IDENTITY(1,1) NOT NULL,
        ObraId  INT               NOT NULL,
        Papel             VARCHAR(15)       NOT NULL,
        NomeAssinante     NVARCHAR(150)     NOT NULL,
        UsuarioId         INT               NOT NULL,
        AssinaturaDigital VARCHAR(MAX)      NOT NULL,
        HashDocumento     CHAR(64)          NOT NULL,
        IpMaquina         VARCHAR(45)       NULL,
        DataAssinatura    DATETIME2(0)      NOT NULL CONSTRAINT DF_AssinaturasObra_Data DEFAULT (SYSDATETIME()),
        CONSTRAINT PK_AssinaturasObra PRIMARY KEY (AssinaturaObraId),
        CONSTRAINT FK_AssinaturasObra_Doc FOREIGN KEY (ObraId) REFERENCES dbo.Obras (ObraId),
        CONSTRAINT FK_AssinaturasObra_Usuarios FOREIGN KEY (UsuarioId) REFERENCES dbo.Usuarios (UsuarioId),
        CONSTRAINT UQ_AssinaturasObra_Papel UNIQUE (ObraId, Papel),
        CONSTRAINT CK_AssinaturasObra_Papel CHECK (Papel IN ('RT','PROPRIETARIO'))
    );
END
GO
IF OBJECT_ID(N'dbo.AssinaturasVisita', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.AssinaturasVisita (
        AssinaturaVisitaId  INT IDENTITY(1,1) NOT NULL,
        RelatoVisitaId  INT               NOT NULL,
        Papel             VARCHAR(15)       NOT NULL,
        NomeAssinante     NVARCHAR(150)     NOT NULL,
        UsuarioId         INT               NOT NULL,
        AssinaturaDigital VARCHAR(MAX)      NOT NULL,
        HashDocumento     CHAR(64)          NOT NULL,
        IpMaquina         VARCHAR(45)       NULL,
        DataAssinatura    DATETIME2(0)      NOT NULL CONSTRAINT DF_AssinaturasVisita_Data DEFAULT (SYSDATETIME()),
        CONSTRAINT PK_AssinaturasVisita PRIMARY KEY (AssinaturaVisitaId),
        CONSTRAINT FK_AssinaturasVisita_Doc FOREIGN KEY (RelatoVisitaId) REFERENCES dbo.RelatosVisita (RelatoVisitaId),
        CONSTRAINT FK_AssinaturasVisita_Usuarios FOREIGN KEY (UsuarioId) REFERENCES dbo.Usuarios (UsuarioId),
        CONSTRAINT UQ_AssinaturasVisita_Papel UNIQUE (RelatoVisitaId, Papel),
        CONSTRAINT CK_AssinaturasVisita_Papel CHECK (Papel IN ('RT','PROPRIETARIO'))
    );
END
GO
IF OBJECT_ID(N'dbo.AssinaturasTermo', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.AssinaturasTermo (
        AssinaturaTermoId  INT IDENTITY(1,1) NOT NULL,
        TermoConclusaoId  INT               NOT NULL,
        Papel             VARCHAR(15)       NOT NULL,
        NomeAssinante     NVARCHAR(150)     NOT NULL,
        UsuarioId         INT               NOT NULL,
        AssinaturaDigital VARCHAR(MAX)      NOT NULL,
        HashDocumento     CHAR(64)          NOT NULL,
        IpMaquina         VARCHAR(45)       NULL,
        DataAssinatura    DATETIME2(0)      NOT NULL CONSTRAINT DF_AssinaturasTermo_Data DEFAULT (SYSDATETIME()),
        CONSTRAINT PK_AssinaturasTermo PRIMARY KEY (AssinaturaTermoId),
        CONSTRAINT FK_AssinaturasTermo_Doc FOREIGN KEY (TermoConclusaoId) REFERENCES dbo.TermosConclusao (TermoConclusaoId),
        CONSTRAINT FK_AssinaturasTermo_Usuarios FOREIGN KEY (UsuarioId) REFERENCES dbo.Usuarios (UsuarioId),
        CONSTRAINT UQ_AssinaturasTermo_Papel UNIQUE (TermoConclusaoId, Papel),
        CONSTRAINT CK_AssinaturasTermo_Papel CHECK (Papel IN ('RT','PROPRIETARIO'))
    );
END
GO

IF OBJECT_ID(N'dbo.LogBackup', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.LogBackup (
        BackupId     INT IDENTITY(1,1) NOT NULL,
        UsuarioId    INT               NOT NULL,
        Arquivo      NVARCHAR(500)     NOT NULL,
        TamanhoBytes BIGINT            NULL,
        Sucesso      BIT               NOT NULL,
        Mensagem     NVARCHAR(500)     NULL,
        CriadoEm     DATETIME2(0)      NOT NULL CONSTRAINT DF_LogBackup_CriadoEm DEFAULT (SYSDATETIME()),
        CONSTRAINT PK_LogBackup PRIMARY KEY (BackupId),
        CONSTRAINT FK_LogBackup_Usuarios FOREIGN KEY (UsuarioId) REFERENCES dbo.Usuarios (UsuarioId)
    );
END
GO

IF OBJECT_ID(N'dbo.TentativasLogin', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.TentativasLogin (
        TentativaId INT IDENTITY(1,1) NOT NULL,
        Login       NVARCHAR(100)     NOT NULL,
        Ip          VARCHAR(45)       NULL,
        Sucesso     BIT               NOT NULL,
        DataHora    DATETIME2(0)      NOT NULL CONSTRAINT DF_TentativasLogin_DataHora DEFAULT (SYSDATETIME()),
        CONSTRAINT PK_TentativasLogin PRIMARY KEY (TentativaId)
    );
    CREATE INDEX IX_TentativasLogin_Login ON dbo.TentativasLogin (Login, DataHora);
END
GO

/* ---------- 5) DADOS DE DOMÍNIO (opções fixas das fichas da caderneta) ---------- */
INSERT INTO dbo.TiposObra (Descricao)
SELECT v.Descricao
FROM (VALUES (N'Residencial'), (N'Comercial'), (N'Industrial'), (N'Outros')) AS v (Descricao)
WHERE NOT EXISTS (SELECT 1 FROM dbo.TiposObra t WHERE t.Descricao = v.Descricao);
GO

INSERT INTO dbo.AtividadesTecnicas (Descricao)
SELECT v.Descricao
FROM (VALUES (N'Direção Técnica'), (N'Fiscalização')) AS v (Descricao)
WHERE NOT EXISTS (SELECT 1 FROM dbo.AtividadesTecnicas a WHERE a.Descricao = v.Descricao);
GO

UPDATE dbo.EtapasObra SET Descricao = N'Esquadrias, instalações elétricas e hidráulicas'
WHERE Ordem = 6 AND Descricao = N'Esquadrias e instalações';
UPDATE dbo.EtapasObra SET Descricao = N'Revestimento de forro, parede e piso'
WHERE Ordem = 7 AND Descricao = N'Revestimento';
GO

-- Perfis: o Manual prevê dois atores (Administrador e Responsável Técnico).
-- Quem era Engenheiro ou Fiscal passa a Responsável Técnico (mesmas permissões que já tinha).
-- O perfil Visualizador (somente consulta), se existir, é mantido para não dar mais acesso a ninguém.
IF NOT EXISTS (SELECT 1 FROM dbo.Perfis WHERE Nome = N'Responsável Técnico')
    INSERT INTO dbo.Perfis (Nome, Descricao) VALUES (N'Responsável Técnico', N'Registra obras, visitas e termos de conclusão');
GO

UPDATE u
SET    PerfilId = (SELECT PerfilId FROM dbo.Perfis WHERE Nome = N'Responsável Técnico'),
       AtualizadoEm = SYSDATETIME()
FROM   dbo.Usuarios u
INNER JOIN dbo.Perfis p ON p.PerfilId = u.PerfilId
WHERE  p.Nome IN (N'Engenheiro', N'Fiscal');
GO

DELETE p
FROM   dbo.Perfis p
WHERE  p.Nome IN (N'Engenheiro', N'Fiscal')
  AND  NOT EXISTS (SELECT 1 FROM dbo.Usuarios u WHERE u.PerfilId = p.PerfilId);
GO

/* ---------- Conferência ---------- */
SELECT (SELECT COUNT(*) FROM dbo.Obras)            AS Obras,
       (SELECT COUNT(*) FROM dbo.RelatosVisita)    AS Relatos,
       (SELECT COUNT(*) FROM dbo.TiposObra)        AS TiposObra,
       (SELECT COUNT(*) FROM dbo.Perfis)           AS Perfis;
GO
