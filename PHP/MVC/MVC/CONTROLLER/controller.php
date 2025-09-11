<?php
require "./Model/Model.php";
require "./View/View.php";
require "./Model/crudBook.php";
require "./Model/book.php";
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

            if(!$_SESSION['logado']){
                if($modelo->validar_login($user,$senha)){
                    $view->renderiza_crud();
                    $_SESSION['logado'] = true;
                }
                else{
                    $view->renderiza_tela($modelo->get_texto());
                }
            }
            else{
                $view->renderiza_crud();
            }
        }

        public function carregar_prod(){
            $view = new View();
            $crud = new CrudBook();
            $listaDados = $crud->select();
            $lista = [];
            foreach($listaDados as $prod){
                $livro = new Book($prod['id'], $prod['urlphoto'], $prod['price']);
                $lista[] = $livro;
            }
            if($_SESSION['logado'] == true){
                $view->renderiza_sistema($lista);
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
            $view = new View();
            $crud = new CrudBook();
            $book = new Book(null, $url, $price);
            if($crud->insert($book)){
                $view->renderiza_crud();
            }
            else{
                echo "<script>alert('Error ao inserir!!');</script>";
                $view->renderiza_crud();
            }
        }

        public function carregar_update(){
            $view = new View();
            if ($_SESSION['logado']){
                $view->form_update();
            }
            else{
                echo "<script>alert('Você nao tem permissão para esta ação');</script>";
                index();
            }
        }

        public function update($id, $price, $url){
            $view = new View();
            $crud = new CrudBook();
            $book = new Book($id, $url, $price);
            if($crud->update($book)){
                $view->renderiza_crud();
            }
            else{
                echo "<script>alert('Error ao atualizar!!');</script>";
                $view->renderiza_crud();
            }
        }

        public function carregar_delete(){
            $view = new View();
            if ($_SESSION['logado']){
                $view->form_delete();
            }
            else{
                echo "<script>alert('Você nao tem permissão para esta ação');</script>";
                index();
            }
        }

        public function delete($id){
            $view = new View();
            $crud = new CrudBook();
            if($crud->delete($id)){
                $view->renderiza_crud();
            }
            else{
                echo "<script>alert('Error ao Deletar!!');</script>";
                $view->renderiza_crud();
            }
        }

        public function voltar_crud(){
            $view = new View();
            $view->renderiza_crud();
        }
    }


?>