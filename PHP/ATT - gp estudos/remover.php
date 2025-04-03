<?php
if (isset($_GET['arquivo'])) {
    $arquivo = $_GET['arquivo'];
    $pasta = "./Teorias_codigos/";
    $caminhoCompleto = $pasta . $arquivo;

    if (file_exists($caminhoCompleto)) {
        if ($_SERVER['REQUEST_METHOD'] === 'POST') {
            // Deletar o arquivo
            unlink($caminhoCompleto);
            header("Location: index.php"); // Redireciona de volta para a página principal
            exit;
        }
    } else {
        die("Arquivo não encontrado.");
    }
} else {
    die("Nenhum arquivo especificado.");
}
?>

<!DOCTYPE html>
<html lang="pt-BR">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Deletar Arquivo</title>
    <link rel="stylesheet" href="css.css">
</head>
<body>
    <h1>Deletar Arquivo: <?php echo htmlspecialchars($arquivo); ?></h1>
    <p>Tem certeza de que deseja deletar este arquivo?</p>
    <form method="post">
        <button type="submit">Sim, deletar</button>
    </form>
    <button onclick="window.location.href='index.php'">Cancelar</button>
</body>
</html>