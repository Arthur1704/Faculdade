<?php

    include 'conection.php';

    class CrudBook{

        private $db;

        public function __construct() {
            $con = new Conection(); 
            $con->conection_DB();
            $this->db = $con->getConn();
        }

        public function insert($b){

            $sql = "INSERT INTO book (price, urlimge) VALUES (:price, :urlimage)";

            $state = $this->db->prepare($sql);
            
            $state->bindValue(":price", $b->getPrice());
            $state->bindValue(":urlimge", $b->getUrl());            

            $state->execute();
        }
    }

?>