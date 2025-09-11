<?php

    class CrudBook{

        private $db;

        public function __construct() {
            $con = new Conection(); 
            $con->conection_DB();
            $this->db = $con->getConn();
        }

        public function insert($b){

            $sql = "INSERT INTO book (price, urlphoto) VALUES (:price, :urlimage)";

            $state = $this->db->prepare($sql);
            
            $state->bindValue(":price", $b->getPrice());
            $state->bindValue(":urlimage", $b->getUrl());            

            if($state->execute()){
                return true;
            }
            return false;
        }

        public function select(){
            $sql = "SELECT * FROM book";
            $state = $this->db->prepare($sql);
            $state->execute();
            $livros = $state->fetchAll(PDO::FETCH_ASSOC);

            return $livros;
        }

        public function update($b){

            $sql = "UPDATE book SET price = :price, urlphoto = :urlimage WHERE id = :id";

            $state = $this->db->prepare($sql);
            
            $state->bindValue(":price", $b->getPrice());
            $state->bindValue(":urlimage", $b->getUrl());            
            $state->bindValue(":id", $b->getId());            
            if($state->execute()){
                return true;
            }
            return false;
        }

        public function delete($id){

            $sql = "DELETE FROM book WHERE id = :id";

            $state = $this->db->prepare($sql);
                                
            $state->bindValue(":id", $id);            
            if($state->execute()){
                return true;
            }
            return false;
        }
    }

?>