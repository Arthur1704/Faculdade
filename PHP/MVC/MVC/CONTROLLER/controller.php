<?php
require "./Model/Model.php";
require "./View/View.php";

    class Controller{

        public function index(){
            $modelo = new Model();
            $view = new View();
            $view->renderiza_tela($modelo->get_texto());
        }

        public function logar($user,$senha){
            $modelo = new Model();
            $view = new View();


            if($modelo->validar_login($user,$senha)){
                $view->renderiza_sistema($modelo->get_nomeusuario());
            }
            else{
                $view->renderiza_tela($modelo->get_texto());
            }
        }

        
    }


?>