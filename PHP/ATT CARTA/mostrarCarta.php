<!DOCTYPE html>
<html lang="en">
    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <title>Mostrar Carta</title>
        <link rel="stylesheet" href="css.css">
    </head>
    <body>
        <nav>
            <h1>Redigir carta</h1>
            <div id="direcionadores_nav">
                <ul>
                    <li><a href="index.php">Criar uma carta</a></li>
                    <li><a href="CartasCriadas.php">Ver cartas feitas</a></li>
                </ul>
            </div>
        </nav>
        <div id="caixa_principal">
        <?php
            if (isset($_GET['file'])) {
                $file = $_GET['file'];
                $conteudo = file_get_contents($file);
                echo "<p>" . nl2br(htmlspecialchars($conteudo)) . "</p>";
                }
        ?>
        </div>
    </body>
</html>