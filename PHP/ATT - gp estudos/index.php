<!DOCTYPE html>
<html lang="pt-BR">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Formulário de Linguagens</title>
    <link rel="stylesheet" href="css.css">
</head>
<body>

    <div id="caixa"> 
    <?php

    $pasta = "./Teorias_codigos";
    $arquivos = scandir($pasta);

    foreach($arquivos as $arquivo){
        if ($arquivo !== '.' && $arquivo !== '..') {
            $caminhoCompleto = $pasta . '/' . $arquivo;
            if (file_exists($caminhoCompleto)) {
                $linhas = file($caminhoCompleto);
                echo "<strong>Conteúdo de $arquivo:</strong><br>";
                foreach ($linhas as $linha){
                    echo $linha . "<br>";
                }
                echo "<br>";
                echo "<button onclick=\"window.location.href='editar.php?arquivo=$arquivo'\">Editar</button>";
                echo "<button onclick=\"window.location.href='deletar.php?arquivo=$arquivo'\">Deletar</button>";
                echo "<br><br>";
            } else {
                echo "Arquivo não encontrado: $caminhoCompleto<br>";
            }
        }
    }
    ?>

    <button type="button" onclick="window.location.href='form_add_conteudo.php'">Adicionar Conteúdo</button>
    </div>
</body>
</html>