<?php
if (isset($_GET['arquivo'])) {
    $arquivo = $_GET['arquivo'];
    $pasta = "./Teorias_codigos/";
    $caminhoCompleto = $pasta . $arquivo;

    if (file_exists($caminhoCompleto)) {
        $conteudo = file_get_contents($caminhoCompleto);
    } else {
        die("Arquivo não encontrado.");
    }
} else {
    die("Nenhum arquivo especificado.");
}

if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    $novoConteudo = $_POST['conteudo'];
    file_put_contents($caminhoCompleto, $novoConteudo);
    header("Location: index.php"); 
    exit;
}
?>

<!DOCTYPE html>
<html lang="pt-BR">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Editar Arquivo</title>
    <link rel="stylesheet" href="css.css">
</head>
<body>
    <h1>Editar Arquivo: <?php echo htmlspecialchars($arquivo); ?></h1>
    <form method="post">
        <textarea name="conteudo" rows="10" cols="50"><?php echo htmlspecialchars($conteudo); ?></textarea><br>
        <button type="submit">Salvar</button>
    </form>
    <button onclick="window.location.href='index.php'">Cancelar</button>
</body>
</html>