<?php

    class Book{
        
        private $urlPhoto;
        private $price;

        public Book($urlPhoto, $price){
            $this->urlPhoto = $urlPhoto;
            $this->price = $price;
        }

        public function getUrl(){
            return $urlPhoto;
        }

        public function getPrice(){
            
        }
    }

?>