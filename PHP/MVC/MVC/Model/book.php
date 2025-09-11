<?php

    class Book{
        
        private $id;
        private $urlPhoto;
        private $price;

        public function __construct($id, $urlPhoto, $price){
            if ($id === null){
                $this->urlPhoto = $urlPhoto;
                $this->price = $price;    
            }
            else{
                $this->id = $id;
                $this->urlPhoto = $urlPhoto;
                $this->price = $price;
            }
        }

        public function setId($id){
            $this->id = $id;
        }

        public function getId(){
            return $this->id;
        }

        public function getUrl(){
            return $this->urlPhoto;
        }

        public function getPrice(){
            return $this->price;
        }
    }

?>