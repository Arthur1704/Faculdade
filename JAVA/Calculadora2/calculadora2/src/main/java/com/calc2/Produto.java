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

    public String getNome() {
        return nomeP;
    }

    public int getQuantidade() {
        return quantP;
    }

    public double getValor() {
        return valorP;
    }
}
