<?php

    include 'conection.php';

    class Model{

        public function __construct(){
            $this->texto = "Login"; 
            $this->nomeusuario = ""; 
        }
     

    function get_texto(){
        return $this->texto;
    }

    function get_nomeusuario(){
        return $this->nomeusuario;
    }


    public function validar_login($usuario, $senha) {
        $db = new Conection();

        $query = "SELECT * FROM usuarios WHERE nome = :nome and senha = :senha";
        $param = ['nome' => $usuario, 'senha' => $senha];

        

        if($usuarios = $db->consulta($query, $param) != null){
            $this->nomeusuario= "Administrador";
            return true;
        }
        return false;
    }
}
?>