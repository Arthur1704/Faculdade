<?php

    class View{


        public function formulario_login() {
            return '
                
                <head>
                    <link rel="stylesheet" href="./VIEW/css.css">
                </head>
                <form method="POST" action="index.php">
                    <label>Usuário:</label><br>
                    <input type="text" name="usuario" required><br><br>
                    
                    <label>Senha:</label><br>
                    <input type="password" name="senha" required><br><br>
                    
                    <button type="submit" name="btnLogar">Entrar</button>
                </form>
            ';
        }


        public function renderiza_tela($texto){
            echo '  <div id="login">
                    <h1>
                    '.$texto.'
                    </h1>
                    ';

            echo $this->formulario_login();

            echo'</div>';
        }


        public function renderiza_sistema($user){
            echo '
                    <h1> Seja bem vindo(a)
                    '.$user.'
                    </h1>

                    <a href="index.php?sair">SAIR</a>
                    ';

            
        }


    }

?>
<!-- <!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
    
</head>
<body>
    
</body>
</html> -->