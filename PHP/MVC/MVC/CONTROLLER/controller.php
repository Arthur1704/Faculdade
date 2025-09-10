<?php
require "./Model/Model.php";
require "./View/View.php";
require "./Model/crudBook.php";
session_start();

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
                $view->renderiza_crud();
                $_SESSION['logado'] = true;
            }
            else{
                $view->renderiza_tela($modelo->get_texto());
            }
        }

        public function carregar_prod(){
            $view = new View();
            if($_SESSION['logado'] == true){
                $view->renderiza_sistema();
            }
        }

        public function carregar_insert(){
            $view = new View();
            if ($_SESSION['logado']){
                $view->form_insert();
            }
            else{
                echo "<script>alert('Você nao tem permissão para esta ação');</script>";
                index();
            }
        }

        public function insert($price, $url){
            $crud = new CrudBook();
            $book = new Book($url, $price);
            $crud->insert($book);
        }
    }


?>