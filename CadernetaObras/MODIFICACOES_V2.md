# Modificações da versão 2 (correções do relatório de QA / alinhamento ao Manual)

## 1. Banco de dados  (`Banco/01_CriarBanco.sql` atualizado e `Banco/03_Atualizacao_v2.sql` novo)

| Mudança | Detalhe |
|---|---|
| `Obras` – novos campos | `ProfissionalId` (responsável técnico, FK), `NumeroRT`, `Empresa`, `NumeroCaderneta`, `ValorObra` |
| `Obras` – áreas | novas `AreaAmpliar` e `AreaRegularizar`; `AreaTotal` passa a somar as 4 áreas; restrição `CK_Obras_Areas` refeita |
| `RelatosVisita` | `NumeroNaObra` (nº sequencial da visita dentro da obra: 001, 002...), com índice único (obra + número). Relatos antigos são numerados pela migração |
| `RelatoVisitaAnexos` | `Descricao` |
| `TermosConclusao` | `PdfFinal` (caminho do último PDF gerado) |
| Novas tabelas | `ObraDocumentos`, `AssinaturasObra`, `AssinaturasVisita`, `AssinaturasTermo`, `LogBackup`, `TentativasLogin` |
| Dados fixos | Tipos de obra: Residencial, Comercial, Industrial, Outros. Atividades técnicas: + Direção Técnica e Fiscalização. Etapas 6 e 7 com os nomes completos do Manual |
| Perfis | `Responsável Técnico` criado; usuários Engenheiro/Fiscal migrados para ele; Engenheiro/Fiscal removidos se ficarem sem uso. `Visualizador` é mantido se já existia |
| Novo script | `04_Backup_Manual_e_Agendado.sql` |

## 2. Itens do relatório de QA

### Conformidade com o Manual
| # | Item do QA | O que foi feito |
|---|---|---|
| 1 | Gerar PDF único (capa + termo) | **Novo** gerador de PDF próprio (sem biblioteca externa): capa, primeira página (dados técnicos e valor) e termo, com as assinaturas. Ação **PDF** na grid e botão **Gerar PDF** no termo. Cópia gravada em `App_Data/Pdfs` e caminho em `PdfFinal` |
| 2 | Capa / responsável técnico / RT / empresa / valor | Tela **Obras**: responsável técnico (obrigatório), nº da RT, empresa/construtor, nº da caderneta, valor, tipo de edificação, local, data de início. Ação **Capa** abre a capa e a primeira página |
| 3 | Termo preenchido com dados cadastrados | Ao escolher a obra o termo traz proprietário, profissional, registro, empresa, CPF/telefone e local. Proprietário passa a vir sempre da obra. Declaração padrão do Manual (conforme projeto aprovado e normas técnicas) + texto das sanções. Exige obra com responsável técnico. Termo "Concluído" marca a obra como Concluída |
| 4 | Assinaturas digitais | Controle `Assinaturas.ascx` na capa, no relato e no termo: assinatura desenhada na tela (mouse/toque), com gravação de imagem, data, **IP** e hash SHA-256 do documento. Aviso quando o documento é alterado depois de assinado. Só o administrador remove assinatura. Documento assinado não pode ser excluído |
| 5 | Backup | Tela **Backup** (só Administrador): gera `.bak`, lista e baixa os arquivos, histórico em `LogBackup`. Pasta em `PastaBackup` (Web.config) |
| 6 | Perfis do Manual | Dois perfis: Administrador e Responsável Técnico (ver Banco) |
| 7 | Campos obrigatórios do Manual | Obrigatórios agora: CPF/CNPJ do proprietário; CPF e registro (tipo + número) do profissional; e-mail do usuário; local e data de início da obra |
| 8 | Tipos/atividades sem dados | Sementes no banco (ver acima) |
| 9 | Áreas | 4 áreas (construir, ampliar, regularizar, reformar) + total automático (tela e banco) |
| 10 | Interface/numeração da ficha | PDF reproduz os campos e a estrutura das fichas; nº da caderneta em vermelho; relato com "Visita nº" por obra. **Logos (AEA/CREA/CAU/CRT) não incluídos** (faltam os arquivos de imagem) |
| 11 | Imagens da visita e documentos da obra | Anexos do relato com **descrição**; documentos da obra (ART/RRT, projeto aprovado, alvará, habite-se) na tela Obras |
| 13 | Nomes das etapas | Atualizados |
| 14 | Termo x status da obra | Termo "Concluído" atualiza a obra |

### Bugs e riscos
| Item do QA | Correção |
|---|---|
| Relato duplicado ao falhar o anexo | O formulário passa a "edição" logo após gravar (relato e obra) |
| Valor `2.450` virava 2,45 | `2.450` e `1.234.567` agora são lidos como milhar (também no JS). `12.5` continua 12,5 |
| Sessão desatualizada / usuário inativado | A cada tela o sistema confere no banco se o usuário está ativo e atualiza o perfil; inativo é desconectado |
| Ficar sem administrador | Não é possível retirar o próprio perfil de administrador nem inativar a si mesmo |
| Login sem proteção | Bloqueio de 15 min após 5 senhas erradas seguidas (`TentativasLogin`); cookie `HttpOnly` e `SameSite=Lax` |
| Links mortos do login | **Solicitar cadastro** (tela pública; o administrador aprova em Usuários, que abre o formulário já preenchido) e **Esqueci minha senha** (orienta procurar o administrador) |
| Cartão Usuários para não administrador | Oculto |
| Erro técnico exposto | Mensagem simples ao usuário; detalhe em `App_Data/Logs` |
| Duplo clique em Salvar/Assinar | Bloqueado no navegador (4 s) |
| Telefone/CEP/e-mail fracos | Telefone 10 ou 11 dígitos, CEP 8 dígitos, e-mail exige domínio com ponto |
| Anexo aceito só pela extensão | Confere também o conteúdo do arquivo (PDF, JPG, PNG, Office) |

## 3. Arquivos novos
`Assinaturas.ascx(.cs)`, `backup.aspx(.cs)`, `solicitar-cadastro.aspx(.cs)`, `esqueci-senha.aspx`,
`Dados/AssinaturaDAO`, `BackupDAO`, `SolicitacaoCadastroDAO`, `Utilitarios/PdfSimples`, `DocumentosPdf`, `Arquivos`, `Registro`,
modelos `Assinatura`, `CapaObra`, `ObraDocumento`, `SolicitacaoCadastro`, scripts `03` e `04`.

## 4. O que continua como estava (e por quê)
- **Recibos, Serviços e Tipos de obra** seguem no sistema, embora não apareçam no Manual: confirme se ficam.
- **Edição simultânea** (dois usuários no mesmo registro): vale o último a salvar.
- **Arquivo escolhido some** se o formulário der erro de validação: limitação dos navegadores com campos de arquivo.
- **Assinatura digital** aqui é a assinatura desenhada + IP + data + hash. Não é certificado digital ICP-Brasil.
- **Backup agendado** não está embutido no site (ver `Banco/04_Backup_Manual_e_Agendado.sql`).
- Tabelas sem tela: `ObraProfissionais`, `ObraServicos`, `RecuperacaoSenha`.
