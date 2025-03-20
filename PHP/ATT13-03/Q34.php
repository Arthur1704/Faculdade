<?php

if (isset($_FILES['arquivo'])){
        $tipo = $_FILES['arquivo']['type'];

        $permitidos = ['image/jpg', 'image/png'];

        if (in_array($tipo, $permitidos)){
            echo "<script>alert('Arquivo enviado com sucesso!!')</script>";
        }
        else{
            echo "<script>alert('Não foi enviado!!')</script>";
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
        <form action="index.php" method="POST" enctype="multipart/form-data">
            <lable>Artuivo:<br> 
                <input type="file" name="arquivo">
            </label>
            <br>
            <input type="submit" name="submit">
        </form>
    </body>
</html>