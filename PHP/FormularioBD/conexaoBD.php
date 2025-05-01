<?php

try{
    $pdo = new PDO("mysql:host=localhost;dbname=attphp", "root", "");
}
catch(Exception $e){
    echo "Não foi possivel se conectar, erro: " . $e->getMessage();
}

?>