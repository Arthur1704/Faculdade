<?php

if ($_SERVER['REQUEST_METHOD'] == 'POST'){
        $login = $_POST['login'];
        $senha = $_POST['senha'];

        if ($login == "admin" && $senha == "1234"){

            header("Location: Q32.1.php");

        }else{

            echo "<script>alert('Login não deu certo.')</script>";

        }

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
        <form action="index.php" method="POST">
            <lable>Login:<br> 
                <input type="text" name="login">
            </label>    
            <br>
            <lable>Senha:<br> 
                <input type="password" name="senha">
            </label>
            <br>
            <input type="submit" name="submit">
        </form>
    </body>
</html>