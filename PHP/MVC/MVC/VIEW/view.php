<?php

    class View{


        public function formulario_login() {
            return '
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
            echo '
                    <h1>
                    '.$texto.'
                    </h1>
                    ';

            echo $this->formulario_login();
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