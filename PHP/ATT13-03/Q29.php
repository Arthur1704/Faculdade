<?php

//29. Faça um formulário onde o usuário pode escolher sua cor favorita e, ao enviar, o fundo da página muda para essa cor.
    if(isset($_POST["submit"])){ 
        $cor = $_POST["cor"];
    }
?>
<!DOCTYPE html>
<html lang="en">
    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <title>Document</title>
        <style>
            body{ 
                background-color: <?php echo $cor?>;
            }
        </style>
    </head>
    <body>
        <form method="POST" action="index.php">
            <label>Esolha uma cor:<br>
                <input type="color" name="cor" size="20px">
            </label>
            <br>
            <input type="submit" name="submit">
        </form>        
    </body>
</html>
