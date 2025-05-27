<?php
    require_once 'DatabaseMysql.php';

    $db = new Database();
    $id = $_GET['id'];
    $sql =  "SELECT * FROM alunos WHERE id = :id";
    $informacoes = $db->consulta($sql, ['id' => $id]);

    $aluno = $informacoes[0];

?>

<!DOCTYPE html>
<html lang="en">
    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <title>Editar Aluno</title>
        <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet">
    </head>
    <body>

        <nav class="navbar navbar-expand-lg navbar-dark bg-primary">
            <div class="container-fluid">
                <a class="navbar-brand" href="#">Gestão de Atividades</a>
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Alternar navegação">
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
            <h2 class="mb-4">Editar Aluno</h2>
            
            <form action="editar.php" method="POST">

                    <div class="mb-3">
                        <label for="ra_aluno" class="form-label">RA</label>
                        <input type="text" class="form-control" id="ra_aluno" name="ra_aluno" value="<?php echo htmlspecialchars($aluno['ra'])?>" required>
                    </div>

                    <div class="mb-3">
                        <label for="nome_aluno" class="form-label">Aluno</label>
                        <input type="text" class="form-control" id="nome_aluno" name="nome_aluno" value="<?php echo htmlspecialchars($aluno['nome'])?>" required>
                    </div>

                    <div class="mb-3">
                        <label for="sobrenome_aluno" class="form-label">Sobrenome</label>
                        <input type="text" class="form-control" id="sobrenome_aluno" name="sobrenome_aluno" value="<?php echo htmlspecialchars($aluno['sobrenome'])?>" required>
                    </div>                

                    <div class="mb-3">
                        <label for="curso" class="form-label">Curso</label>
                        <input type="text" class="form-control" id="curso" name="curso" value="<?php echo htmlspecialchars($aluno['curso'])?>" required>
                    </div>

                    <div class="mb-3">
                        <label for="email" class="form-label">Email</label>
                        <input type="text" class="form-control" id="email" name="email" value="<?php echo htmlspecialchars($aluno['email'])?>" required>
                    </div>

                    <div class="mb-3">
                        <label for="cidade" class="form-label">Cidade</label>
                        <input type="text" class="form-control" id="cidade" name="cidade" rows="3" value="<?php echo htmlspecialchars($aluno['cidade'])?>"></textarea>
                    </div>
                    <div class="mb-3">
                        <label for="ano" class="form-label">Ano</label>
                        <input type="text" class="form-control" id="ano" name="ano" rows="3" value="<?php echo htmlspecialchars($aluno['ano_ingresso'])?>" ></textarea>
                    </div>

                    <input type="hidden" name="id" id="id" value="<?php echo htmlspecialchars($id)?>">

                    <button type="submit" class="btn btn-primary">Salvar Aluno</button>
            </form>
        </div>
    </body>
</html>