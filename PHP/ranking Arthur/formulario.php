<!DOCTYPE html>
<html lang="pt-br">
<head>
  <meta charset="UTF-8">
  <title>Cadastro de Entregas de Atividades</title>
  <!-- Bootstrap via CDN -->
  <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet">
</head>
<body>

<!-- Navbar -->
<nav class="navbar navbar-expand-lg navbar-dark bg-primary">
    <div class="container-fluid">
        <a class="navbar-brand" href="#">Gestão de Atividades</a>
        <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav"
            aria-controls="navbarNav" aria-expanded="false" aria-label="Alternar navegação">
            <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarNav">
            <ul class="navbar-nav ms-auto"> <!-- Alinhado à direita -->
                <li class="nav-item">
                    <a class="nav-link" href="cadastrar_atividade.php">Cadastrar Atividade</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="alunos.php">Cadastrar Aluno</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="formulario.php">Cadastrar Entrega</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="listagem_geral.php">Listagem Geral</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="listagem.php">Ranking</a>
                </li>
            </ul>
        </div>
    </div>
</nav>


  <div class="container mt-5">
    <h2 class="mb-4">Cadastrar Entrega de Atividade</h2>
    
    <form action="processa_entrega.php" method="POST">
      <!-- Data de entrega -->
      <div class="mb-3">
        <label for="data_entrega" class="form-label">Data de Entrega</label>
        <input type="date" class="form-control" id="data_entrega" name="data_entrega" required>
      </div>

      <!-- Aluno -->
      <div class="mb-3">
        <label for="aluno" class="form-label">Aluno</label>
        <select class="form-select" id="aluno" name="aluno" required>
          <?php
            require_once 'DatabaseMysql.php'; // Inclua o arquivo da classe Database

            $db = new Database();

            // Consulta para buscar os nomes dos alunos distintos
            $sql = "SELECT DISTINCT  nome FROM alunos ORDER BY nome";
            $alunos = $db->consulta($sql);
            foreach ($alunos as $linha): ?>
                <option value="<?= htmlspecialchars($linha['nome']) ?>">
                    <?= htmlspecialchars($linha['nome']) ?>
                </option>
            <?php endforeach; ?>
        </select>
      </div>

      <!-- Atividade -->
      <div class="mb-3">
        <label for="atividade" class="form-label">Atividade</label>
        <select class="form-select" id="atividade" name="atividade" required>
          <option value="">Selecione uma atividade</option>
          <option value="1">Trabalho 1</option>
          <option value="2">Projeto Final</option>
          <option value="3">Relatório de Leitura</option>
        </select>
      </div>

      <!-- Nota -->
      <div class="mb-3">
        <label for="nota" class="form-label">Nota</label>
        <input type="number" step="0.1" class="form-control" id="nota" name="nota" min="0" max="10" required>
      </div>

      <!-- Observações -->
      <div class="mb-3">
        <label for="observacoes" class="form-label">Observações</label>
        <textarea class="form-control" id="observacoes" name="observacoes" rows="3"></textarea>
      </div>

      <button type="submit" class="btn btn-primary">Salvar Entrega</button>
    </form>
  </div>
    <a href="listagem.html" class="btn btn-primary">Ver ranking</a>


  <!-- Bootstrap JS (opcional) -->
  <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
