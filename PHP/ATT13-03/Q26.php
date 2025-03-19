<?php

//26. Crie um formulário HTML com um campo de nome e um botão enviar (método GET). Exiba o nome enviado na tela.


    if (isset($_GET['submit'])){
        $nome = $_GET['nome'];

        echo $nome;
    }

?>
<!DOCTYPE html>
<html lang="en">
    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <title>Document</title>
    </head>
    <body>
        <form method="GET" action="index.php">
            <label>Nome:<br>
                <input type="text" name="nome" size="50px">
            </label>
            <br>     
            <input type="submit" name="submit">
        </form>        
    </body>
</html>
