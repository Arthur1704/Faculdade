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


        public function renderiza_sistema(){
            echo '
            <head>
                <link rel="stylesheet" href="./VIEW/css.css">
            </head>
            <form>
            <main class="container">
                <div class="produto">
                    <img src="https://rihappy.vtexassets.com/arquivos/ids/399649-800-auto?v=637050968026130000&width=800&height=auto&aspect=true" alt="Produto 1" >                
                    </div>

                    <div class="produto">
                    <img src="https://www.americanas.com.br/_next/image?url=https%3A%2F%2Famericanas.vtexassets.com%2Farquivos%2Fids%2F30578310%2F132450206_1SZ.jpg%3Fv%3D638794243922330000&w=768&q=90" alt="Produto 2">                
                    </div>

                    <div class="produto">
                    <img src="https://imgs.casasbahia.com.br/15057676/1xg.jpg?imwidth=500" alt="Produto 3">                
                    </div>

                    <div class="produto">
                    <img src="https://images.tcdn.com.br/img/img_prod/1170935/harry_potter_vol_5_e_a_ordem_da_fenix_capa_dura_premium_3631_1_d97f30d2b7d7513f18b2d7fde9e24962.jpg" alt="Produto 4">                
                    </div>

                    <div class="produto">
                    <img src="https://images.tcdn.com.br/img/img_prod/1073155/harry_potter_e_o_prisioneiro_de_askaban_capa_dura_17509_1_c974b26fecc2d112c89348aca0afb911.jpg" alt="Produto 5">                
                    </div>

                    <div class="produto">
                    <img src="https://down-br.img.susercontent.com/file/893e9a8ec8997f7141ffa9bdad79c554_tn.webp" alt="Produto 6">                
                </div>
            </main>';
        }

        public function renderiza_crud(){
            echo '
            <head>
                <link rel="stylesheet" href="./VIEW/css.css">
            </head>
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