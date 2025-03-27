package com.calc2;

public class Produto {

    String nomeP;
    int quantP;
    double valorP;
    

    public Produto(){

    }

    public Produto(String nome, int quantidade, double valor){

        this.nomeP = nome;
        this.quantP = quantidade;
        this.valorP = valor;

    }
    
    public int Buscar_quantP(String nome){
        
        for(int cont = 0; cont < contador; cont++){

            if (this.nomeP[cont] != null && this.nomeP[cont].equals(nome)){
                return this.quantP[cont];
            }
        }
        return -1;
    }

    public double Buscar_valorP(String nome){
        
        for(int cont = 0; cont < contador; cont++){

            if (this.nomeP[cont] != null && nomeP[cont].equals(nome) ){
                return valorP[cont];
            }
        }
        return -1.0;
    }

}
