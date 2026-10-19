# Caderneta de Obras (ASP.NET Web Forms + SQL Server)

Sistema para cadastro de proprietários, profissionais, obras, serviços e documentos da obra
(recibos, relatos de visita e termos de conclusão).

## Como rodar

1. **Banco de dados** (SQL Server / SQL Server Express), no SSMS:
   - **Instalação nova**, nesta ordem:
     1. `Banco/01_CriarBanco.sql` – cria o banco `CadernetaObras`, as tabelas e os dados fixos (perfis, tipos de edificação, atividades, etapas...).
     2. `Banco/02_PrimeiroAdministrador.sql` – cria o usuário **admin** (senha **123**). Troque a senha depois.
   - **Banco já criado com a versão 1**: faça um backup e execute somente `Banco/03_Atualizacao_v2.sql`
     (pode rodar mais de uma vez; não apaga dados).
   - `Banco/04_Backup_Manual_e_Agendado.sql` – comandos de backup/restauração e como agendar.
2. **Web.config**: ajuste `connectionStrings` (seu servidor), `PastaBackup` (pasta dos backups, no computador do SQL Server)
   e `CidadeDocumentos` (cidade que aparece na data do termo).
3. Abra `WebApplication1.sln` no Visual Studio (2019 ou 2022), restaure os pacotes NuGet e execute (F5).
4. Entre com `admin` / `123`.

## Estrutura do projeto (`WebApplication1/`)

| Pasta / arquivo | Para que serve |
|---|---|
| `*.aspx` + `*.aspx.cs` | Telas e o código de cada tela (eventos dos botões, validações) |
| `PaginaBase.cs` | Classe-mãe das telas: exige login, mensagens, abrir/fechar modal, formatações |
| `Site.Master` | Layout (menu, usuário logado, mensagens) |
| `Modelos/` | Classes simples com os dados (Proprietario, Obra, Recibo...) |
| `Dados/` | Acesso ao banco com ADO.NET: `Banco.cs` (conexão e comandos) e um `DAO` por tela |
| `Utilitarios/` | `Texto` (formatação/conversão), `Validacao` (CPF, CNPJ, e-mail), `Seguranca` (hash de senha) |
| `Assinaturas.ascx` | Controle de assinatura digital (obra, relato e termo) |
| `backup.aspx` | Backup do banco (somente Administrador) |
| `Utilitarios/PdfSimples.cs`, `DocumentosPdf.cs` | Gerador do PDF único (capa + primeira página + termo), sem bibliotecas externas |
| `App_Data/Uploads/` | Anexos dos relatos e documentos das obras (o IIS não deixa baixar direto pela URL) |
| `App_Data/Pdfs/`, `App_Data/Logs/` | PDFs gerados e registro de erros técnicos (criadas automaticamente). **O usuário do site precisa de permissão de escrita em `App_Data`** |
| `js/app.js` | Menu do celular, item ativo do menu e soma das áreas na tela de obras |

## Como as telas funcionam

- Cada tela de cadastro tem: filtros, tabela com paginação (`GridView`), formulário e visualização (ambos em janelas "modal").
- Botões da tabela: **Ver**, **Editar**, **Excluir** (em usuários: **Ativar/Inativar**; em recibos e termos: **Imprimir/PDF**).
- Todo acesso ao banco usa parâmetros (`@nome`), evitando SQL Injection.
- Senhas são gravadas com hash PBKDF2 + salt (nunca em texto puro).
- CPF, CNPJ, telefone e CEP são gravados só com números; a máscara é aplicada na exibição.
- Se o registro estiver vinculado a outros (ex.: proprietário com obras), a exclusão é bloqueada pelo banco
  e o sistema avisa para usar o status **Inativo**.

## Perfis

| Perfil | O que pode |
|---|---|
| Administrador | Tudo, inclusive **Usuários** e **Backup** |
| Responsável Técnico | Todas as telas de obra, visitas, termos e assinaturas (sem Usuários/Backup) |
| Visualizador (opcional) | Somente consulta. Não vem no banco novo; só existe se já estava cadastrado |

## Observações

- **PDF único** (Manual 4.2.6): na tela Termo de conclusão, ação **PDF** ou botão **Gerar PDF (capa + termo)**.
  Gera capa, primeira página (dados técnicos e valor) e termo, com as assinaturas digitais já colhidas.
- **Imprimir** (relato, recibo, capa e termo): usa a impressão do navegador.
- **Assinatura digital**: o responsável técnico e o proprietário desenham a assinatura na tela. O sistema grava a imagem,
  a data, o IP e uma impressão digital (SHA-256) do documento; se o documento mudar depois, aparece o aviso para assinar de novo.
- **Manter conectado** no login deixa a sessão de 8 horas em vez de 30 minutos.
- Não têm tela (ainda) e por isso as tabelas não são usadas: `ObraProfissionais`, `ObraServicos` e `RecuperacaoSenha`
  (a redefinição de senha é feita pelo administrador em Usuários > Editar).
- A lista completa do que mudou na versão 2 está em `MODIFICACOES_V2.md`.
- Recibos e termos não têm exclusão: para anular, mude o status (Cancelado / Rascunho).
- Mensagens de erro inesperado mostram o texto técnico (útil no desenvolvimento). Em produção, troque por uma mensagem genérica em `PaginaBase.TextoErroBanco`.
