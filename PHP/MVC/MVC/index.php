<?php

   include "./Controller/controller.php";
    
   $controlador =  new Controller();

   

   if (isset($_POST["btnLogar"])){
      $controlador->logar($_POST['usuario'], $_POST['senha']);
   }
   else if (isset($_GET["sair"])){
      $controlador->index();
   }
   else if (isset($_POST["btn_select"])){
      $controlador->carregar_prod();
   }
   else if (isset($_POST["btn_insert"])){
      $controlador->carregar_insert();
   }
   else if(isset($_POST["submit_insert"])){
      $controlador->insert($_POST['price'], $_POST['url']);
   }
   else if(isset($_POST["btn_update"])){
      $controlador->carregar_update();
   }
   else if(isset($_POST["submit_update"])){
      $controlador->update($_POST['id'],$_POST['price'], $_POST['url']);
   }
   else if(isset($_POST["btn_delete"])){
      $controlador->carregar_delete();
   }
   else if(isset($_POST["submit_delete"])){
      $controlador->delete($_POST['id']);
   }
   else if(isset($_POST["voltar_crud"])){
      $controlador->voltar_crud();
   }
   else{
      $controlador->index();
   }


   


   




?>