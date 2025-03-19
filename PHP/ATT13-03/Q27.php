<?php

//Modifique o exercício anterior para utilizar o método POST.


    if (isset($_POST['submit'])){
        $nome = $_POST['nome'];

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
        <form method="POST" action="index.php">
            <label>Nome:<br>
                <input type="text" name="nome" size="50px">
            </label>
            <br>     
            <input type="submit" name="submit">
        </form>        
    </body>
</html>
