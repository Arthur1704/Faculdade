<?php
//31. Crie um sistema de login: se o usuário estiver logado, exiba "Bem-vindo", senão, redirecione para a página de login.

    if (isset($_POST['submit'])){
        $login = $_POST['login'];
        $senha = $_POST['senha'];

        if ($login == "admin" && $senha == "1234"){

            $logado = 1;
            echo "<style>form { display:none; }</style>";
            echo "Bem-Vindo!!";

        }else{

            $logado = 0;
            echo "<script>window.location.href='index.php';</script>";

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
       </form> 
    </body>
</html>