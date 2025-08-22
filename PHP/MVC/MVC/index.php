<?php

   include "./Controller/controller.php";
    
   $controlador =  new Controller();  

   if (isset($_POST["btnLogar"])){
      $controlador->logar($_POST['usuario'], $_POST['senha']);
   }
   else if (isset($_GET["sair"])){
      $controlador->index();
   }
   else{
      $controlador->index();
   }




?>