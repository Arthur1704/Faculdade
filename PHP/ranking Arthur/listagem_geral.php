<?php
require_once 'DatabaseMysql.php';

$db = new Database();
$conn = $db->conecta_BD();

$sql = "SELECT * FROM entrega_de_atividades ORDER BY criado_em DESC";
$stmt = $conn->prepare($sql);
$stmt->execute();
$entregas = $stmt->fetchAll(PDO::FETCH_ASSOC);
?>

<!DOCTYPE html>
<html lang="pt-br">
<head>
  <meta charset="UTF-8">
  <title>Lista de Entregas</title>
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
  <h2 class="mb-4">Entregas Realizadas</h2>

  <?php if (count($entregas) > 0): ?>
    <table class="table table-bordered table-striped">
      <thead class="table-dark">
        <tr>
          <th>ID</th>
          <th>Data de Entrega</th>
          <th>Aluno</th>
          <th>Atividade</th>
          <th>Nota</th>
          <th>Observações</th>
          <th>Criado em</th>
        </tr>
      </thead>
      <tbody>
        <?php foreach ($entregas as $entrega): ?>
          <tr>
            <td><?= htmlspecialchars($entrega['id']) ?></td>
            <td><?= htmlspecialchars($entrega['data_entrega']) ?></td>
            <td><?= htmlspecialchars($entrega['aluno']) ?></td>
            <td><?= htmlspecialchars($entrega['atividade']) ?></td>
            <td><?= htmlspecialchars($entrega['nota']) ?></td>
            <td><?= nl2br(htmlspecialchars($entrega['observacoes'])) ?></td>
            <td><?= htmlspecialchars($entrega['criado_em']) ?></td>
          </tr>
        <?php endforeach; ?>
      </tbody>
    </table>
  <?php else: ?>
    <p class="alert alert-info">Nenhuma entrega cadastrada ainda.</p>
  <?php endif; ?>

  <a href="formulario.html" class="btn btn-primary mt-3">Voltar ao Cadastro</a>
</div>
</body>
</html>
