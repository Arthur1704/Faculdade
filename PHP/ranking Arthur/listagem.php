<?php
require_once 'DatabaseMysql.php';  

$db = new Database();
$conn = $db->conecta_BD();

// Consulta com ranking
$sql = "
    SELECT 
        RANK() OVER (ORDER BY AVG(nota) DESC) AS posicao_ranking,
        aluno,
        ROUND(AVG(nota), 2) AS media_notas
    FROM 
        entrega_de_atividades
    GROUP BY 
        aluno
    ORDER BY 
        media_notas DESC
";



$resultados = $db->consulta($sql);
?>

<!DOCTYPE html>
<html lang="pt-br">
<head>
  <meta charset="UTF-8">
  <title>Lista de Entregas de Atividades</title>
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
                    <a class="nav-link" href="cadastrar_aluno.php">Cadastrar Aluno</a>
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
    <h2 class="mb-4">Ranking de Alunos por Média</h2>

    <table class="table table-bordered table-striped">
      <thead class="table-dark">
        <tr>
          <th>Posição</th>
          <th>Aluno</th>
          <th>Média das Notas</th>
        </tr>
      </thead>
      <tbody>
        <?php if ($resultados && count($resultados) > 0): ?>
          <?php foreach ($resultados as $linha): ?>
            <tr>
              <td><?= htmlspecialchars($linha['posicao_ranking']) ?></td>
              <td><?= htmlspecialchars($linha['aluno']) ?></td>
              <td><?= htmlspecialchars($linha['media_notas']) ?></td>
            </tr>
          <?php endforeach; ?>
        <?php else: ?>
          <tr>
            <td colspan="3" class="text-center">Nenhum dado encontrado.</td>
          </tr>
        <?php endif; ?>
      </tbody>
    </table>

    <a href="formulario.html" class="btn btn-primary">Cadastrar Nova Entrega</a>
  </div>

  <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
