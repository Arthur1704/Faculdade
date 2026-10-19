/* =====================================================================
   CADERNETA DE OBRAS - Script de criação do banco (SQL Server 2016+)
   Gerado a partir da análise de todas as telas do projeto Web Forms.

   Convenções:
   - Nomes de tabelas no plural, PK = <Entidade>Id (INT IDENTITY).
   - CPF/CNPJ, telefones e CEP são gravados SOMENTE COM DÍGITOS
     (as máscaras ficam na tela).
   - Status com poucos valores fixos = CHECK constraint.
     Listas que o usuário pode querer evoluir = tabela de domínio.
   - Números de documento (REC-00037, RV-00012, TC-00008) são colunas
     calculadas a partir do ID, então nunca ficam duplicadas.
   VERSÃO 2: alinhada ao Manual do Usuário (responsável técnico, RT, empresa, valor,
   4 áreas, numeração por obra, assinaturas digitais, documentos da obra, backup).
   Para bancos já existentes use o script 03_Atualizacao_v2.sql.
   - FKs sem CASCADE nas tabelas principais: a tela "Excluir" deve ser
     bloqueada quando houver vínculo (use Status = 'Inativo' nesses casos).
   ===================================================================== */

SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
GO

IF DB_ID(N'CadernetaObras') IS NULL
    CREATE DATABASE CadernetaObras;
GO

USE CadernetaObras;
GO

/* =====================================================================
   1) TABELAS DE DOMÍNIO (opções dos <select> e checkboxes das telas)
   ===================================================================== */

-- usuarios.aspx: Perfil (Administrador, Engenheiro, Fiscal, Visualizador)
CREATE TABLE dbo.Perfis (
    PerfilId    INT IDENTITY(1,1) NOT NULL,
    Nome        NVARCHAR(50)      NOT NULL,
    Descricao   NVARCHAR(200)     NULL,
    CONSTRAINT PK_Perfis PRIMARY KEY (PerfilId),
    CONSTRAINT UQ_Perfis_Nome UNIQUE (Nome)
);
GO

-- profissionais.aspx: Tipo de profissional
CREATE TABLE dbo.TiposProfissional (
    TipoProfissionalId INT IDENTITY(1,1) NOT NULL,
    Descricao          NVARCHAR(100)     NOT NULL,
    CONSTRAINT PK_TiposProfissional PRIMARY KEY (TipoProfissionalId),
    CONSTRAINT UQ_TiposProfissional_Descricao UNIQUE (Descricao)
);
GO

-- profissionais.aspx: Tipo de registro (CREA, CAU, Outro; CFT aparece nos dados de exemplo)
CREATE TABLE dbo.TiposRegistroProfissional (
    TipoRegistroId INT IDENTITY(1,1) NOT NULL,
    Sigla          NVARCHAR(20)      NOT NULL,
    Descricao      NVARCHAR(100)     NULL,
    CONSTRAINT PK_TiposRegistroProfissional PRIMARY KEY (TipoRegistroId),
    CONSTRAINT UQ_TiposRegistroProfissional_Sigla UNIQUE (Sigla)
);
GO

-- servicos.aspx: Unidade de medida (m², m, un, h, vb)
CREATE TABLE dbo.UnidadesMedida (
    UnidadeMedidaId INT IDENTITY(1,1) NOT NULL,
    Sigla           NVARCHAR(10)      NOT NULL,
    Descricao       NVARCHAR(60)      NULL,
    CONSTRAINT PK_UnidadesMedida PRIMARY KEY (UnidadeMedidaId),
    CONSTRAINT UQ_UnidadesMedida_Sigla UNIQUE (Sigla)
);
GO

-- obras.aspx: Atividade técnica (Projeto, Execução, Reforma, Vistoria)
CREATE TABLE dbo.AtividadesTecnicas (
    AtividadeTecnicaId INT IDENTITY(1,1) NOT NULL,
    Descricao          NVARCHAR(60)      NOT NULL,
    CONSTRAINT PK_AtividadesTecnicas PRIMARY KEY (AtividadeTecnicaId),
    CONSTRAINT UQ_AtividadesTecnicas_Descricao UNIQUE (Descricao)
);
GO

-- recibos.aspx: Forma de pagamento (Pix, Transferência bancária, Boleto, Dinheiro)
CREATE TABLE dbo.FormasPagamento (
    FormaPagamentoId INT IDENTITY(1,1) NOT NULL,
    Descricao        NVARCHAR(60)      NOT NULL,
    CONSTRAINT PK_FormasPagamento PRIMARY KEY (FormaPagamentoId),
    CONSTRAINT UQ_FormasPagamento_Descricao UNIQUE (Descricao)
);
GO

-- relato-visita.aspx: checklist "Etapas verificadas" (9 checkboxes)
CREATE TABLE dbo.EtapasObra (
    EtapaObraId INT IDENTITY(1,1) NOT NULL,
    Descricao   NVARCHAR(100)     NOT NULL,
    Ordem       INT               NOT NULL,
    Ativo       BIT               NOT NULL CONSTRAINT DF_EtapasObra_Ativo DEFAULT (1),
    CONSTRAINT PK_EtapasObra PRIMARY KEY (EtapaObraId),
    CONSTRAINT UQ_EtapasObra_Descricao UNIQUE (Descricao)
);
GO

-- tipos-obra.aspx: cadastro de Tipos de obra (Descrição, Status, Observações)
CREATE TABLE dbo.TiposObra (
    TipoObraId  INT IDENTITY(1,1) NOT NULL,
    Descricao   NVARCHAR(100)     NOT NULL,
    Observacoes NVARCHAR(500)     NULL,
    Status      VARCHAR(10)       NOT NULL CONSTRAINT DF_TiposObra_Status DEFAULT ('Ativo'),
    CriadoEm    DATETIME2(0)      NOT NULL CONSTRAINT DF_TiposObra_CriadoEm DEFAULT (SYSDATETIME()),
    AtualizadoEm DATETIME2(0)     NULL,
    CONSTRAINT PK_TiposObra PRIMARY KEY (TipoObraId),
    CONSTRAINT UQ_TiposObra_Descricao UNIQUE (Descricao),
    CONSTRAINT CK_TiposObra_Status CHECK (Status IN ('Ativo','Inativo'))
);
GO

/* =====================================================================
   2) CADASTROS PRINCIPAIS
   ===================================================================== */

-- usuarios.aspx + login.aspx
CREATE TABLE dbo.Usuarios (
    UsuarioId    INT IDENTITY(1,1) NOT NULL,
    Nome         NVARCHAR(150)     NOT NULL,
    Usuario      VARCHAR(60)       NOT NULL,          -- login (ex.: marina.souza)
    Matricula    VARCHAR(30)       NULL,              -- login.aspx: "Usuário ou matrícula"
    Cpf          VARCHAR(11)       NOT NULL,
    Email        VARCHAR(150)      NULL,
    Telefone     VARCHAR(15)       NULL,
    PerfilId     INT               NOT NULL,
    SenhaHash    VARCHAR(255)      NOT NULL,          -- NUNCA gravar senha em texto puro (use PBKDF2/BCrypt com salt)
    Status       VARCHAR(10)       NOT NULL CONSTRAINT DF_Usuarios_Status DEFAULT ('Ativo'),
    UltimoAcessoEm DATETIME2(0)    NULL,
    CriadoEm     DATETIME2(0)      NOT NULL CONSTRAINT DF_Usuarios_CriadoEm DEFAULT (SYSDATETIME()),
    AtualizadoEm DATETIME2(0)      NULL,
    CONSTRAINT PK_Usuarios PRIMARY KEY (UsuarioId),
    CONSTRAINT UQ_Usuarios_Usuario UNIQUE (Usuario),
    CONSTRAINT UQ_Usuarios_Cpf UNIQUE (Cpf),
    CONSTRAINT FK_Usuarios_Perfis FOREIGN KEY (PerfilId) REFERENCES dbo.Perfis (PerfilId),
    CONSTRAINT CK_Usuarios_Status CHECK (Status IN ('Ativo','Inativo','Pendente'))
);
GO
CREATE UNIQUE INDEX UX_Usuarios_Matricula ON dbo.Usuarios (Matricula) WHERE Matricula IS NOT NULL;
CREATE INDEX IX_Usuarios_Nome ON dbo.Usuarios (Nome);
GO

-- proprietarios.aspx
CREATE TABLE dbo.Proprietarios (
    ProprietarioId INT IDENTITY(1,1) NOT NULL,
    NomeRazaoSocial NVARCHAR(200)    NOT NULL,
    CpfCnpj        VARCHAR(14)       NULL,            -- 11 dígitos = CPF, 14 = CNPJ
    TipoPessoa     AS (CASE WHEN CpfCnpj IS NULL THEN NULL
                            WHEN LEN(CpfCnpj) = 14 THEN 'J' ELSE 'F' END),
    Email          VARCHAR(150)      NULL,
    Telefone       VARCHAR(15)       NULL,
    Celular        VARCHAR(15)       NULL,
    Cep            VARCHAR(8)        NULL,
    Endereco       NVARCHAR(200)     NULL,
    Numero         NVARCHAR(20)      NULL,
    Complemento    NVARCHAR(100)     NULL,
    Bairro         NVARCHAR(100)     NULL,
    Cidade         NVARCHAR(100)     NULL,
    Estado         CHAR(2)           NULL,
    Status         VARCHAR(10)       NOT NULL CONSTRAINT DF_Proprietarios_Status DEFAULT ('Ativo'),
    CriadoEm       DATETIME2(0)      NOT NULL CONSTRAINT DF_Proprietarios_CriadoEm DEFAULT (SYSDATETIME()),
    AtualizadoEm   DATETIME2(0)      NULL,
    CONSTRAINT PK_Proprietarios PRIMARY KEY (ProprietarioId),
    CONSTRAINT CK_Proprietarios_Status CHECK (Status IN ('Ativo','Inativo','Pendente'))
);
GO
CREATE UNIQUE INDEX UX_Proprietarios_CpfCnpj ON dbo.Proprietarios (CpfCnpj) WHERE CpfCnpj IS NOT NULL;
CREATE INDEX IX_Proprietarios_Nome ON dbo.Proprietarios (NomeRazaoSocial);
GO

-- profissionais.aspx
CREATE TABLE dbo.Profissionais (
    ProfissionalId     INT IDENTITY(1,1) NOT NULL,
    Nome               NVARCHAR(150)     NOT NULL,
    Cpf                VARCHAR(11)       NULL,
    TipoProfissionalId INT               NOT NULL,
    TipoRegistroId     INT               NULL,
    NumeroRegistro     NVARCHAR(30)      NULL,        -- ex.: "SP 123456", "A12345-6"
    Email              VARCHAR(150)      NULL,
    Telefone           VARCHAR(15)       NULL,
    Celular            VARCHAR(15)       NULL,
    Status             VARCHAR(10)       NOT NULL CONSTRAINT DF_Profissionais_Status DEFAULT ('Ativo'),
    Observacoes        NVARCHAR(1000)    NULL,
    CriadoEm           DATETIME2(0)      NOT NULL CONSTRAINT DF_Profissionais_CriadoEm DEFAULT (SYSDATETIME()),
    AtualizadoEm       DATETIME2(0)      NULL,
    CONSTRAINT PK_Profissionais PRIMARY KEY (ProfissionalId),
    CONSTRAINT FK_Profissionais_Tipo FOREIGN KEY (TipoProfissionalId) REFERENCES dbo.TiposProfissional (TipoProfissionalId),
    CONSTRAINT FK_Profissionais_TipoRegistro FOREIGN KEY (TipoRegistroId) REFERENCES dbo.TiposRegistroProfissional (TipoRegistroId),
    CONSTRAINT CK_Profissionais_Status CHECK (Status IN ('Ativo','Inativo','Pendente'))
);
GO
CREATE UNIQUE INDEX UX_Profissionais_Cpf ON dbo.Profissionais (Cpf) WHERE Cpf IS NOT NULL;
CREATE UNIQUE INDEX UX_Profissionais_Registro ON dbo.Profissionais (TipoRegistroId, NumeroRegistro)
    WHERE TipoRegistroId IS NOT NULL AND NumeroRegistro IS NOT NULL;
CREATE INDEX IX_Profissionais_Nome ON dbo.Profissionais (Nome);
GO

-- servicos.aspx
CREATE TABLE dbo.Servicos (
    ServicoId       INT IDENTITY(1,1) NOT NULL,
    Nome            NVARCHAR(150)     NOT NULL,
    UnidadeMedidaId INT               NULL,
    Referencia      NVARCHAR(50)      NULL,           -- "Código interno"
    Descricao       NVARCHAR(500)     NULL,
    Status          VARCHAR(10)       NOT NULL CONSTRAINT DF_Servicos_Status DEFAULT ('Ativo'),
    CriadoEm        DATETIME2(0)      NOT NULL CONSTRAINT DF_Servicos_CriadoEm DEFAULT (SYSDATETIME()),
    AtualizadoEm    DATETIME2(0)      NULL,
    CONSTRAINT PK_Servicos PRIMARY KEY (ServicoId),
    CONSTRAINT FK_Servicos_UnidadeMedida FOREIGN KEY (UnidadeMedidaId) REFERENCES dbo.UnidadesMedida (UnidadeMedidaId),
    CONSTRAINT CK_Servicos_Status CHECK (Status IN ('Ativo','Inativo'))
);
GO
CREATE UNIQUE INDEX UX_Servicos_Referencia ON dbo.Servicos (Referencia) WHERE Referencia IS NOT NULL;
CREATE INDEX IX_Servicos_Nome ON dbo.Servicos (Nome);
GO

/* =====================================================================
   3) OBRAS (obras.aspx) E VÍNCULOS
   ===================================================================== */

CREATE TABLE dbo.Obras (
    ObraId             INT IDENTITY(1,1) NOT NULL,
    Nome               NVARCHAR(200)     NOT NULL,
    ProprietarioId     INT               NOT NULL,
    TipoObraId         INT               NOT NULL,   -- tipo de edificação (Residencial, Comercial...)
    AtividadeTecnicaId INT               NULL,
    ProfissionalId     INT               NULL,       -- responsável técnico (a tela exige o preenchimento)
    NumeroRT           NVARCHAR(30)      NULL,       -- RT / ART / RRT nº
    Empresa            NVARCHAR(150)     NULL,       -- empresa ou construtor responsável
    NumeroCaderneta    NVARCHAR(20)      NULL,       -- número impresso na caderneta física (ex.: 12293)
    ValorObra          DECIMAL(15,2)     NULL,       -- R$ da primeira página
    DataInicio         DATE              NULL,
    PrevisaoTermino    DATE              NULL,
    EnderecoObra       NVARCHAR(300)     NULL,        -- campo único: "Rua, número, bairro, cidade - UF"
    Status             VARCHAR(15)       NOT NULL CONSTRAINT DF_Obras_Status DEFAULT ('Planejada'),
    AreaConstruir      DECIMAL(12,2)     NULL,        -- Área a construir (m²)
    AreaAmpliar        DECIMAL(12,2)     NULL,        -- Área a ampliar (m²)
    AreaRegularizar    DECIMAL(12,2)     NULL,        -- Área a regularizar (m²)
    AreaReforma        DECIMAL(12,2)     NULL,        -- Área a reformar (m²)
    AreaTotal          AS (ISNULL(AreaConstruir, 0) + ISNULL(AreaAmpliar, 0) + ISNULL(AreaRegularizar, 0) + ISNULL(AreaReforma, 0)) PERSISTED, -- Área total edificada
    Observacoes        NVARCHAR(1000)    NULL,
    CriadoEm           DATETIME2(0)      NOT NULL CONSTRAINT DF_Obras_CriadoEm DEFAULT (SYSDATETIME()),
    AtualizadoEm       DATETIME2(0)      NULL,
    CONSTRAINT PK_Obras PRIMARY KEY (ObraId),
    CONSTRAINT FK_Obras_Proprietarios FOREIGN KEY (ProprietarioId) REFERENCES dbo.Proprietarios (ProprietarioId),
    CONSTRAINT FK_Obras_TiposObra FOREIGN KEY (TipoObraId) REFERENCES dbo.TiposObra (TipoObraId),
    CONSTRAINT FK_Obras_AtividadesTecnicas FOREIGN KEY (AtividadeTecnicaId) REFERENCES dbo.AtividadesTecnicas (AtividadeTecnicaId),
    CONSTRAINT FK_Obras_Profissionais FOREIGN KEY (ProfissionalId) REFERENCES dbo.Profissionais (ProfissionalId),
    CONSTRAINT CK_Obras_Status CHECK (Status IN ('Planejada','Em andamento','Paralisada','Concluída')),
    CONSTRAINT CK_Obras_Areas CHECK (ISNULL(AreaConstruir,0) >= 0 AND ISNULL(AreaAmpliar,0) >= 0 AND ISNULL(AreaRegularizar,0) >= 0 AND ISNULL(AreaReforma,0) >= 0),
    CONSTRAINT CK_Obras_Datas CHECK (PrevisaoTermino IS NULL OR DataInicio IS NULL OR PrevisaoTermino >= DataInicio)
);
GO
CREATE INDEX IX_Obras_Proprietario ON dbo.Obras (ProprietarioId);
CREATE INDEX IX_Obras_TipoObra     ON dbo.Obras (TipoObraId);
CREATE INDEX IX_Obras_Profissional  ON dbo.Obras (ProfissionalId);
CREATE INDEX IX_Obras_Status       ON dbo.Obras (Status);
CREATE INDEX IX_Obras_Nome         ON dbo.Obras (Nome);
GO

-- inicio.aspx: "Visualizar obras e seus responsáveis" -> profissionais responsáveis por cada obra
CREATE TABLE dbo.ObraProfissionais (
    ObraId         INT           NOT NULL,
    ProfissionalId INT           NOT NULL,
    Funcao         NVARCHAR(80)  NULL,                -- ex.: Responsável técnico, Autor do projeto
    CriadoEm       DATETIME2(0)  NOT NULL CONSTRAINT DF_ObraProfissionais_CriadoEm DEFAULT (SYSDATETIME()),
    CONSTRAINT PK_ObraProfissionais PRIMARY KEY (ObraId, ProfissionalId),
    CONSTRAINT FK_ObraProfissionais_Obras FOREIGN KEY (ObraId) REFERENCES dbo.Obras (ObraId) ON DELETE CASCADE,
    CONSTRAINT FK_ObraProfissionais_Profissionais FOREIGN KEY (ProfissionalId) REFERENCES dbo.Profissionais (ProfissionalId)
);
GO
CREATE INDEX IX_ObraProfissionais_Profissional ON dbo.ObraProfissionais (ProfissionalId);
GO

-- inicio.aspx / servicos.aspx: "catálogo de serviços da obra" -> serviços previstos em cada obra
CREATE TABLE dbo.ObraServicos (
    ObraId      INT            NOT NULL,
    ServicoId   INT            NOT NULL,
    Quantidade  DECIMAL(14,3)  NULL,
    Observacoes NVARCHAR(500)  NULL,
    CriadoEm    DATETIME2(0)   NOT NULL CONSTRAINT DF_ObraServicos_CriadoEm DEFAULT (SYSDATETIME()),
    CONSTRAINT PK_ObraServicos PRIMARY KEY (ObraId, ServicoId),
    CONSTRAINT FK_ObraServicos_Obras FOREIGN KEY (ObraId) REFERENCES dbo.Obras (ObraId) ON DELETE CASCADE,
    CONSTRAINT FK_ObraServicos_Servicos FOREIGN KEY (ServicoId) REFERENCES dbo.Servicos (ServicoId),
    CONSTRAINT CK_ObraServicos_Qtd CHECK (Quantidade IS NULL OR Quantidade >= 0)
);
GO
CREATE INDEX IX_ObraServicos_Servico ON dbo.ObraServicos (ServicoId);
GO

/* =====================================================================
   4) DOCUMENTOS DA OBRA
   ===================================================================== */

-- recibos.aspx  (Nº exibido: REC-00037)
CREATE TABLE dbo.Recibos (
    ReciboId         INT IDENTITY(1,1) NOT NULL,
    Numero           AS ('REC-' + CASE WHEN ReciboId < 100000
                                       THEN RIGHT('00000' + CAST(ReciboId AS VARCHAR(10)), 5)
                                       ELSE CAST(ReciboId AS VARCHAR(10)) END) PERSISTED,
    ObraId           INT               NOT NULL,
    ProprietarioId   INT               NOT NULL,
    DataEmissao      DATE              NOT NULL,
    Valor            DECIMAL(15,2)     NOT NULL,
    FormaPagamentoId INT               NULL,
    Status           VARCHAR(10)       NOT NULL CONSTRAINT DF_Recibos_Status DEFAULT ('Emitido'),
    ReferenteA       NVARCHAR(300)     NULL,          -- "Referente a"
    Observacoes      NVARCHAR(1000)    NULL,
    CriadoEm         DATETIME2(0)      NOT NULL CONSTRAINT DF_Recibos_CriadoEm DEFAULT (SYSDATETIME()),
    AtualizadoEm     DATETIME2(0)      NULL,
    CONSTRAINT PK_Recibos PRIMARY KEY (ReciboId),
    CONSTRAINT FK_Recibos_Obras FOREIGN KEY (ObraId) REFERENCES dbo.Obras (ObraId),
    CONSTRAINT FK_Recibos_Proprietarios FOREIGN KEY (ProprietarioId) REFERENCES dbo.Proprietarios (ProprietarioId),
    CONSTRAINT FK_Recibos_FormasPagamento FOREIGN KEY (FormaPagamentoId) REFERENCES dbo.FormasPagamento (FormaPagamentoId),
    CONSTRAINT CK_Recibos_Status CHECK (Status IN ('Emitido','Aguardando','Cancelado')),
    CONSTRAINT CK_Recibos_Valor CHECK (Valor >= 0)
);
GO
CREATE UNIQUE INDEX UX_Recibos_Numero ON dbo.Recibos (Numero);
CREATE INDEX IX_Recibos_Obra         ON dbo.Recibos (ObraId);
CREATE INDEX IX_Recibos_Proprietario ON dbo.Recibos (ProprietarioId);
CREATE INDEX IX_Recibos_DataEmissao  ON dbo.Recibos (DataEmissao DESC);
CREATE INDEX IX_Recibos_Status       ON dbo.Recibos (Status);
GO

-- relato-visita.aspx  (Nº exibido: RV-00012)
-- A coluna "Resumo" da listagem não tem campo no formulário: use LEFT(Relato, n) na consulta.
CREATE TABLE dbo.RelatosVisita (
    RelatoVisitaId      INT IDENTITY(1,1) NOT NULL,
    Numero              AS ('RV-' + CASE WHEN RelatoVisitaId < 100000
                                         THEN RIGHT('00000' + CAST(RelatoVisitaId AS VARCHAR(10)), 5)
                                         ELSE CAST(RelatoVisitaId AS VARCHAR(10)) END) PERSISTED,
    ObraId              INT               NOT NULL,
    NumeroNaObra        INT               NOT NULL,   -- nº sequencial da visita dentro da obra (003 na ficha)
    UsuarioId           INT               NOT NULL,   -- usuário que registrou o relato
    DataVisita          DATE              NOT NULL,
    Participantes       NVARCHAR(300)     NULL,
    SituacaoProjeto     VARCHAR(30)       NOT NULL,   -- situação da obra em relação ao projeto
    StatusObra          VARCHAR(15)       NOT NULL,   -- status da obra na data da visita
    Relato              NVARCHAR(MAX)     NOT NULL,
    DecisoesOrientacoes NVARCHAR(MAX)     NULL,       -- decisões / orientações / pendências
    Status              VARCHAR(10)       NOT NULL CONSTRAINT DF_RelatosVisita_Status DEFAULT ('Rascunho'),
    CriadoEm            DATETIME2(0)      NOT NULL CONSTRAINT DF_RelatosVisita_CriadoEm DEFAULT (SYSDATETIME()),
    AtualizadoEm        DATETIME2(0)      NULL,
    CONSTRAINT PK_RelatosVisita PRIMARY KEY (RelatoVisitaId),
    CONSTRAINT FK_RelatosVisita_Obras FOREIGN KEY (ObraId) REFERENCES dbo.Obras (ObraId),
    CONSTRAINT FK_RelatosVisita_Usuarios FOREIGN KEY (UsuarioId) REFERENCES dbo.Usuarios (UsuarioId),
    CONSTRAINT CK_RelatosVisita_Situacao CHECK (SituacaoProjeto IN ('De acordo com o projeto','Em desacordo com o projeto')),
    CONSTRAINT CK_RelatosVisita_StatusObra CHECK (StatusObra IN ('Em andamento','Paralisada')),
    CONSTRAINT CK_RelatosVisita_Status CHECK (Status IN ('Rascunho','Concluído'))
);
GO
CREATE UNIQUE INDEX UX_RelatosVisita_Numero ON dbo.RelatosVisita (Numero);
CREATE UNIQUE INDEX UX_RelatosVisita_NumeroObra ON dbo.RelatosVisita (ObraId, NumeroNaObra);
CREATE INDEX IX_RelatosVisita_Obra    ON dbo.RelatosVisita (ObraId, DataVisita DESC);
CREATE INDEX IX_RelatosVisita_Usuario ON dbo.RelatosVisita (UsuarioId);
GO

-- relato-visita.aspx: "Etapas verificadas" (N:N com o checklist)
CREATE TABLE dbo.RelatoVisitaEtapas (
    RelatoVisitaId INT NOT NULL,
    EtapaObraId    INT NOT NULL,
    CONSTRAINT PK_RelatoVisitaEtapas PRIMARY KEY (RelatoVisitaId, EtapaObraId),
    CONSTRAINT FK_RelatoVisitaEtapas_Relato FOREIGN KEY (RelatoVisitaId) REFERENCES dbo.RelatosVisita (RelatoVisitaId) ON DELETE CASCADE,
    CONSTRAINT FK_RelatoVisitaEtapas_Etapa FOREIGN KEY (EtapaObraId) REFERENCES dbo.EtapasObra (EtapaObraId)
);
GO

-- relato-visita.aspx: campo "Anexos" (input file)
CREATE TABLE dbo.RelatoVisitaAnexos (
    AnexoId        INT IDENTITY(1,1) NOT NULL,
    RelatoVisitaId INT               NOT NULL,
    NomeOriginal   NVARCHAR(260)     NOT NULL,
    Descricao      NVARCHAR(255)     NULL,            -- descrição da imagem/documento
    CaminhoArquivo NVARCHAR(500)     NOT NULL,        -- caminho/nome físico no servidor (ou troque por VARBINARY(MAX))
    ContentType    VARCHAR(100)      NULL,
    TamanhoBytes   BIGINT            NULL,
    EnviadoEm      DATETIME2(0)      NOT NULL CONSTRAINT DF_RelatoVisitaAnexos_EnviadoEm DEFAULT (SYSDATETIME()),
    CONSTRAINT PK_RelatoVisitaAnexos PRIMARY KEY (AnexoId),
    CONSTRAINT FK_RelatoVisitaAnexos_Relato FOREIGN KEY (RelatoVisitaId) REFERENCES dbo.RelatosVisita (RelatoVisitaId) ON DELETE CASCADE
);
GO
CREATE INDEX IX_RelatoVisitaAnexos_Relato ON dbo.RelatoVisitaAnexos (RelatoVisitaId);
GO

-- termo-conclusao.aspx  (Nº exibido: TC-00008; filtro "Ano" = YEAR(DataConclusao))
CREATE TABLE dbo.TermosConclusao (
    TermoConclusaoId     INT IDENTITY(1,1) NOT NULL,
    Numero               AS ('TC-' + CASE WHEN TermoConclusaoId < 100000
                                          THEN RIGHT('00000' + CAST(TermoConclusaoId AS VARCHAR(10)), 5)
                                          ELSE CAST(TermoConclusaoId AS VARCHAR(10)) END) PERSISTED,
    ObraId               INT               NOT NULL,
    ProprietarioId       INT               NOT NULL,
    UsuarioId            INT               NOT NULL,  -- usuário que registrou o termo
    DataConclusao        DATE              NOT NULL,
    Status               VARCHAR(25)       NOT NULL CONSTRAINT DF_TermosConclusao_Status DEFAULT ('Rascunho'),
    DocumentoReferencia  NVARCHAR(100)     NULL,      -- ART/RRT, recibo ou protocolo
    DeclaracaoConclusao  NVARCHAR(MAX)     NOT NULL,
    ObservacoesFinais    NVARCHAR(MAX)     NULL,
    PdfFinal             NVARCHAR(255)     NULL,      -- caminho do último PDF gerado (capa + termo)
    CriadoEm             DATETIME2(0)      NOT NULL CONSTRAINT DF_TermosConclusao_CriadoEm DEFAULT (SYSDATETIME()),
    AtualizadoEm         DATETIME2(0)      NULL,
    CONSTRAINT PK_TermosConclusao PRIMARY KEY (TermoConclusaoId),
    CONSTRAINT FK_TermosConclusao_Obras FOREIGN KEY (ObraId) REFERENCES dbo.Obras (ObraId),
    CONSTRAINT FK_TermosConclusao_Proprietarios FOREIGN KEY (ProprietarioId) REFERENCES dbo.Proprietarios (ProprietarioId),
    CONSTRAINT FK_TermosConclusao_Usuarios FOREIGN KEY (UsuarioId) REFERENCES dbo.Usuarios (UsuarioId),
    CONSTRAINT CK_TermosConclusao_Status CHECK (Status IN ('Rascunho','Pronto para assinatura','Concluído'))
);
GO
CREATE UNIQUE INDEX UX_TermosConclusao_Numero ON dbo.TermosConclusao (Numero);
CREATE INDEX IX_TermosConclusao_Obra          ON dbo.TermosConclusao (ObraId);
CREATE INDEX IX_TermosConclusao_Proprietario  ON dbo.TermosConclusao (ProprietarioId);
CREATE INDEX IX_TermosConclusao_Usuario       ON dbo.TermosConclusao (UsuarioId);
CREATE INDEX IX_TermosConclusao_DataConclusao ON dbo.TermosConclusao (DataConclusao DESC);
GO

/* =====================================================================
   4b) DOCUMENTOS DA OBRA, ASSINATURAS DIGITAIS E BACKUP (Manual do Usuário)
   ===================================================================== */

-- Manual: DocumentoObra (ART/RRT, projeto aprovado, alvará...)
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
GO
CREATE INDEX IX_ObraDocumentos_Obra ON dbo.ObraDocumentos (ObraId);
GO

-- Manual: Assinatura_Obra / Assinatura_Visita / Assinatura_Termo_Conclusao
-- Papel: 'RT' (responsável técnico) ou 'PROPRIETARIO'. AssinaturaDigital = imagem desenhada (data URL JPEG).
-- HashDocumento = SHA-256 do conteúdo no momento da assinatura (detecta alteração posterior).
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
GO
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
GO
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
GO

-- Manual: administrador realiza backup (histórico dos backups gerados pela tela Backup)
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
GO

-- Proteção contra tentativas repetidas de login (bloqueio temporário)
CREATE TABLE dbo.TentativasLogin (
    TentativaId INT IDENTITY(1,1) NOT NULL,
    Login       NVARCHAR(100)     NOT NULL,
    Ip          VARCHAR(45)       NULL,
    Sucesso     BIT               NOT NULL,
    DataHora    DATETIME2(0)      NOT NULL CONSTRAINT DF_TentativasLogin_DataHora DEFAULT (SYSDATETIME()),
    CONSTRAINT PK_TentativasLogin PRIMARY KEY (TentativaId)
);
GO
CREATE INDEX IX_TentativasLogin_Login ON dbo.TentativasLogin (Login, DataHora);
GO

/* =====================================================================
   5) LOGIN (login.aspx: "Esqueci minha senha" e "Solicitar cadastro")
   ===================================================================== */

CREATE TABLE dbo.RecuperacaoSenha (
    RecuperacaoSenhaId INT IDENTITY(1,1) NOT NULL,
    UsuarioId          INT               NOT NULL,
    TokenHash          VARCHAR(255)      NOT NULL,    -- grave o HASH do token enviado por e-mail
    SolicitadoEm       DATETIME2(0)      NOT NULL CONSTRAINT DF_RecuperacaoSenha_Solicitado DEFAULT (SYSDATETIME()),
    ExpiraEm           DATETIME2(0)      NOT NULL,
    UtilizadoEm        DATETIME2(0)      NULL,
    CONSTRAINT PK_RecuperacaoSenha PRIMARY KEY (RecuperacaoSenhaId),
    CONSTRAINT FK_RecuperacaoSenha_Usuarios FOREIGN KEY (UsuarioId) REFERENCES dbo.Usuarios (UsuarioId) ON DELETE CASCADE
);
GO
CREATE INDEX IX_RecuperacaoSenha_Usuario ON dbo.RecuperacaoSenha (UsuarioId);
GO

CREATE TABLE dbo.SolicitacoesCadastro (
    SolicitacaoCadastroId INT IDENTITY(1,1) NOT NULL,
    Nome                  NVARCHAR(150)     NOT NULL,
    Cpf                   VARCHAR(11)       NULL,
    Email                 VARCHAR(150)      NOT NULL,
    Telefone              VARCHAR(15)       NULL,
    Mensagem              NVARCHAR(500)     NULL,
    Status                VARCHAR(10)       NOT NULL CONSTRAINT DF_SolicitacoesCadastro_Status DEFAULT ('Pendente'),
    SolicitadoEm          DATETIME2(0)      NOT NULL CONSTRAINT DF_SolicitacoesCadastro_Solicitado DEFAULT (SYSDATETIME()),
    AnalisadoPorUsuarioId INT               NULL,
    AnalisadoEm           DATETIME2(0)      NULL,
    CONSTRAINT PK_SolicitacoesCadastro PRIMARY KEY (SolicitacaoCadastroId),
    CONSTRAINT FK_SolicitacoesCadastro_Usuarios FOREIGN KEY (AnalisadoPorUsuarioId) REFERENCES dbo.Usuarios (UsuarioId),
    CONSTRAINT CK_SolicitacoesCadastro_Status CHECK (Status IN ('Pendente','Aprovada','Rejeitada'))
);
GO

/* =====================================================================
   6) DADOS INICIAIS DE DOMÍNIO (são as opções fixas dos selects/checklists,
      não são dados fictícios das telas)
   ===================================================================== */

INSERT INTO dbo.Perfis (Nome) VALUES
    (N'Administrador'), (N'Responsável Técnico');   -- os dois atores do Manual

INSERT INTO dbo.TiposProfissional (Descricao) VALUES
    (N'Engenheiro Civil'), (N'Arquiteto e Urbanista'), (N'Técnico em Edificações'), (N'Outro');

INSERT INTO dbo.TiposRegistroProfissional (Sigla, Descricao) VALUES
    (N'CREA', N'Conselho Regional de Engenharia e Agronomia'),
    (N'CAU',  N'Conselho de Arquitetura e Urbanismo'),
    (N'CFT',  N'Conselho Federal dos Técnicos Industriais'),
    (N'Outro', NULL);

INSERT INTO dbo.UnidadesMedida (Sigla, Descricao) VALUES
    (N'm²', N'Metro quadrado'), (N'm', N'Metro linear'), (N'un', N'Unidade'),
    (N'h', N'Hora'), (N'vb', N'Verba');

INSERT INTO dbo.AtividadesTecnicas (Descricao) VALUES
    (N'Projeto'), (N'Execução'), (N'Reforma'), (N'Vistoria'), (N'Direção Técnica'), (N'Fiscalização');

INSERT INTO dbo.FormasPagamento (Descricao) VALUES
    (N'Pix'), (N'Transferência bancária'), (N'Boleto'), (N'Dinheiro');

INSERT INTO dbo.EtapasObra (Descricao, Ordem) VALUES
    (N'Serviços preliminares', 1), (N'Fundação', 2), (N'Alvenarias', 3),
    (N'Superestrutura', 4), (N'Cobertura', 5), (N'Esquadrias, instalações elétricas e hidráulicas', 6),
    (N'Revestimento de forro, parede e piso', 7), (N'Pintura', 8), (N'Serviços complementares', 9);

-- Tipos de edificação da ficha física da caderneta (a tela Tipos de obra permite incluir outros)
INSERT INTO dbo.TiposObra (Descricao) VALUES
    (N'Residencial'), (N'Comercial'), (N'Industrial'), (N'Outros');
GO

/* =====================================================================
   7) PRIMEIRO ACESSO (exemplo - NÃO executar com senha em texto puro)
      Gere o hash pela aplicação (PBKDF2/BCrypt) e substitua abaixo.

   INSERT INTO dbo.Usuarios (Nome, Usuario, Cpf, PerfilId, SenhaHash, Status)
   VALUES (N'Administrador', 'admin', '00000000000',
           (SELECT PerfilId FROM dbo.Perfis WHERE Nome = N'Administrador'),
           '<HASH_GERADO_PELA_APLICACAO>', 'Ativo');
   ===================================================================== */
