<?php

//47. Leia os dados do arquivo CSV e exiba em uma tabela HTML.

    $nome = "DADOS.csv";

    $arquivo = fopen("$nome", "r");

    if ($arquivo){
        $dados = [];
        while (($linha = fgetcsv($arquivo)) != false) {
            $dados[] = $linha;
        }
        fclose($arquivo);
    }
?>

<!DOCTYPE html>
<html lang="en">
    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <title>Document</title>
        <style>

        </style>
    </head>
    <body>
        <table border="1">
            <tr>
                <th>Nome</th>
                <th>Idade</th>
                <th>CPF</th>
            </tr>
            <?php foreach($dados as $dado){
            echo "<tr>
                <td>" . htmlspecialchars($dado[0]) . "</td>
                <td>" . htmlspecialchars($dado[1]) . "</td>
                <td>" . htmlspecialchars($dado[2]) . "</td>
            </tr>";
            }
            ?>
        </table>
    </body>
</html>