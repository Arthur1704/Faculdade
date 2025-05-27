<?php
    require_once 'DatabaseMysql.php'; // Sua classe de conexão

    $db = new Database();
    $alunos = $db->consulta("SELECT * FROM alunos ORDER BY nome ASC");

?>

<!DOCTYPE html>
<html lang="pt-BR">
    <head>
        <meta charset="UTF-8">
        <title>Listagem de Alunos</title>
        <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet">
        <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    </head>
    <body>
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

        <div class="container mt-4">
            <div class="d-flex justify-content-between align-items-center mb-3">
                <h2>Alunos Cadastrados</h2>
                <a href="cadastrar_aluno.php" class="btn btn-primary">Cadastrar Aluno</a>
            </div>

            <table class="table table-bordered table-hover">
                <thead class="table-primary">
                    <tr>
                        <th>RA</th>
                        <th>Nome</th>
                        <th>Sobrenome</th>
                        <th>Curso</th>
                        <th>Email</th>
                        <th>Cidade</th>
                        <th>Ano Ingresso</th>
                        <th>Ações</th>
                    </tr>
                </thead>
                <tbody>
                    <?php if (count($alunos) > 0): ?>
                        <?php foreach ($alunos as $aluno): ?>
                            <tr>
                                <td><?= htmlspecialchars($aluno['ra']) ?></td>
                                <td><?= htmlspecialchars($aluno['nome']) ?></td>
                                <td><?= htmlspecialchars($aluno['sobrenome']) ?></td>
                                <td><?= htmlspecialchars($aluno['curso']) ?></td>
                                <td><?= htmlspecialchars($aluno['email']) ?></td>
                                <td><?= htmlspecialchars($aluno['cidade']) ?></td>
                                <td><?= htmlspecialchars($aluno['ano_ingresso']) ?></td>
                                <td>
                                    <a href="editar_aluno.php?id=<?= $aluno['id'] ?>" class="btn btn-sm btn-warning">Editar</a>
                                    <a data-id= "<?= htmlspecialchars($aluno['id'])?>" class="btn btn-sm btn-danger" onclick="return confirm('Tem certeza que deseja excluir este aluno?')">Excluir</a>
                                </td>
                            </tr>
                        <?php endforeach; ?>
                    <?php else: ?>
                        <tr>
                            <td colspan="8" class="text-center">Nenhum aluno encontrado.</td>
                        </tr>
                    <?php endif; ?>
                </tbody>
            </table>
        </div>
    </body>
    <script src="js_alunos.js"></script>
</html>
