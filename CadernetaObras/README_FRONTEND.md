# Caderneta de Obras — Front-End Web Forms

Este pacote contém somente a camada visual do projeto ASP.NET Web Forms.

## Análise realizada
O arquivo original continha apenas a tela `login.aspx` e `login.css` como referência visual. Não havia MasterPage, Bootstrap, JavaScript, CSS global ou tela existente de Obra/Recibo para reutilização.

A referência preservada foi: fundo #f2f3f5, cartões brancos, bordas #ddd, cantos de 5–8px, tipografia Arial, textos em cinza/preto e botão principal preto.

## Telas adicionadas
- `inicio.aspx`
- `proprietarios.aspx`
- `profissionais.aspx`
- `usuarios.aspx`
- `obras.aspx`
- `tipos-obra.aspx`
- `servicos.aspx`
- `recibos.aspx`
- `Site.Master`, `css/site.css`, `js/app.js`

## Escopo
Nenhuma tela nova acessa banco, API, WebService ou serviço externo. Os botões de salvar/excluir/emitir e os estados são simulados por JavaScript. Os dados são fictícios e não possuem persistência.

A página `login.aspx` e sua lógica não foram alteradas.
