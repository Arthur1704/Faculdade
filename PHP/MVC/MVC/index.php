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
      
   }
   else{
      $controlador->index();
   }


   


   




?>