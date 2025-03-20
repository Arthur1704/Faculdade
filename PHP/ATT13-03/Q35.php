<?php

if (isset($_FILES['arquivo'])){
        $tipo = $_FILES['arquivo']['type'];
        $nome = $_FILES['arquivo']['name'];
        $tmp = $_FILES['arquivo']['tmp_name'];

        $permitidos = ['image/jpg', 'image/png'];
        
        if (in_array($tipo, $permitidos)) {
            $diretorio = "./"; 
    
            if (move_uploaded_file($tmp, $diretorio . $nome)) {
                echo "<script>alert('Arquivo enviado com sucesso!!')</script>";
                echo "<img src='$diretorio$nome' alt='$nome' style='max-width: 300px; max-height: 300px;'>";
            } else {
                echo "<script>alert('Erro ao mover o arquivo.')</script>";
            }
        } else {
            echo "<script>alert('Tipo de arquivo não permitido!')</script>";
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
            <lable>Arquivo:<br> 
                <input type="file" name="arquivo">
            </label>
            <br>
            <input type="submit" name="submit">
        </form>
    </body>
</html>