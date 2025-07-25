<!DOCTYPE html>
<html lang="pt-br">
<head>
  <meta charset="UTF-8">
  <title>Cadastro de Atividades</title>
  <!-- Bootstrap via CDN -->
  <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet">
</head>
<body>

<!-- Navbar -->
<nav class="navbar navbar-expand-lg navbar-dark bg-primary">
    <div class="container-fluid">
        <a class="navbar-brand" href="#">Cadastro de Atividades</a>
        <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav"
            aria-controls="navbarNav" aria-expanded="false" aria-label="Alternar navegação">
            <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarNav">
            <ul class="navbar-nav ms-auto"> <!-- Alinhado à direita -->
                <li class="nav-item">
                    <a class="nav-link" href="cadastrar_entrega.php">Cadastrar Entrega</a>
                </li>
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
    <h2 class="mb-4">Cadastrar de Atividade</h2>
    
    <form action="precessa_att.php" method="POST">
      
      <div class="mb-3">
        <label for="nome_att" class="form-label">Nome</label>
        <input type="text" class="form-control" id="nome_att" name="nome_att" required>
      </div>
      
      <div class="mb-3">
        <label for="data_entrega" class="form-label">Data Entrega</label>
        <input type="date" class="form-control" id="data_entrega" name="data_entrega" required>
      </div>

      <button type="submit" class="btn btn-primary">Salvar Atividade</button>
    </form>
  </div>


  <!-- Bootstrap JS (opcional) -->
  <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
