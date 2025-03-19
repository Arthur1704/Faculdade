<?php
//30.Construa um formulário de login com usuário e senha. Se os dados forem "admin" e "1234", exiba "Login bem-sucedido".

    if (isset($_POST['submit'])){
        $login = $_POST['login'];
        $senha = $_POST['senha'];

        if ($login == "admin" && $senha == "1234"){

            echo "Login bem-sucedido.";

        }else{

            echo "Login não deu certo.";

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