<!-- <!DOCTYPE html>
<html lang="en">
    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <title>Agenda</title>
    </head>
    <body>
                
    </body>
</html> -->

<?php

    include_once 'pessoa.class.php';

    $nome = "Arthur";
    $idade = 18;
    $altura = 1.83;

    $pessoa = new Pessoa();

    $pessoa->setPessoa($nome, $idade, $altura);

?>