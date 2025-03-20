<?php

if (isset($_POST['arquivo'])){

        echo "<script>alert('Arquivo enviado com sucesso!!')</script>";

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
            <lable>Artuivo:<br> 
                <input type="file" name="arquivo">
            </label>
            <br>
            <input type="submit" name="submit">
        </form>
    </body>
</html>