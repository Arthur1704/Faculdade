<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Cartas Criadas</title>
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
        $arquivos = glob('*.txt');
        echo "<ol>";
        foreach ($arquivos as $arquivo) {
            echo "<li><a href='mostrarCarta.php?file=" . urlencode($arquivo) . "'>$arquivo</a></li><br><br>";
        }
        echo "</ol>";
    ?>    
    </div>
    <script src="https://code.jquery.com/jquery-3.7.1.min.js"></script>
    <script>
        $(document).ready(function() {
            $('.botao').click(function() {
                var indice = $(this).attr('id').split('_')[1];
                $('#conteudo_' + indice).toggle();
            });
        });
    </script>
</body>
</html>