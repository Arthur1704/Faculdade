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


        public function renderiza_sistema($list){
            echo '
            <head>
                <link rel="stylesheet" href="./VIEW/css.css">
            </head>
            <form method="POST" action="index.php">
            <button name="voltar_crud">Voltar Crud</button>
            <main class="container">';

            foreach($list as $prod){
                echo '
                    <div class="produto" id="' . $prod->getId() . '">

                        <img src="' . $prod->getUrl() . '"><br>
                        <p> Produto: ' . $prod->getId() . '</p><br>
                        <p>R$ ' . number_format($prod->getPrice()) . '</p><br>                                                
                    </div>
                ';
            }
        }

        public function renderiza_crud(){
            echo '
            <head>
                <link rel="stylesheet" href="./VIEW/css.css">
            </head>
            <button name="voltar_crud">Voltar Crud</button>
            <div id="crud">
            <h1>CRUD</h1>
                <form method="POST" action="index.php">
                    <div class="btn_crud">
                        <button name="btn_select" type="submit">Read</button>
                        <button name="btn_update" type="submit">Update</button>
                        <button name="btn_insert" type="submit">Create</button>
                        <button name="btn_delete" type="submit">Delete</button>
                    </div>
                </form>    
            </div>
            ';
        }

        public function form_insert(){
            echo '
                <head>
                    <link rel="stylesheet" href="./VIEW/css.css">
                </head>
                <button name="voltar_crud">Voltar Crud</button>
                <form action="" method="POST">              
                    <label for="preco">Preço:</label><br>
                    <input type="number" step="0.01" name="price" id="preco" required><br><br>

                    <label for="url">URL da Imagem:</label><br>
                    <input type="text" name="url" id="url" required><br><br>

                    <button name="submit_insert" type="submit">Cadastrar</button>
                </form>
            ';
        }

        public function form_update(){
            echo '
                <head>
                    <link rel="stylesheet" href="./VIEW/css.css">                    
                </head>
                
                <form action="index.php" method="POST">
                    <button name="voltar_crud">Voltar Crud</button>
                    <label for="id"> Numero do produto:</label><br>
                    <input type="number" step="0.01" name="id" id="id" required><br><br>

                    <label for="preco">Preço:</label><br>
                    <input type="number" step="0.01" name="price" id="preco" required><br><br>

                    <label for="url">URL da Imagem:</label><br>
                    <input type="text" name="url" id="url" required><br><br>

                    <button name="submit_update" type="submit">Atualizar</button>
                </form>
            ';
        }

        public function form_delete(){
            echo '
                <head>
                    <link rel="stylesheet" href="./VIEW/css.css">                    
                </head>
                
                <form action="index.php" method="POST">
                    <button name="voltar_crud">Voltar Crud</button>
                    <label for="id"> Numero do produto:</label><br>
                    <input type="number" step="0.01" name="id" id="id" required><br><br>
                    <button name="submit_delete" type="submit">Delete</button>
                </form>
            ';
        }
    }

?>
