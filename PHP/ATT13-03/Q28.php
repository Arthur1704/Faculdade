<?php

//28. Crie um formulário onde o usuário insere dois números e recebe a soma deles ao clicar no botão.

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
            <label>Numero 1:<br>
                <input type="number" name="num1" size="20px">
            </label>
            <br>
            <label>Numero 2:<br>
                <input type="number" name="num2" size="20px">
            </label>
            <br>     
            <input type="submit" name="submit">
        </form>        

        <?php
            
            if (isset($_POST['submit'])){
                $num1 = $_POST['num1'];
                $num2 = $_POST['num2'];

                echo "A soma dos dois numeros é " . $num1 + $num2;
            }
        ?>
    </body>
</html>
