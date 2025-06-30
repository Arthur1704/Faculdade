package com.utilitarios;

public class Produto {
    private String nome;
    private Double preco;

    public Produto(){
    }

    public Produto(String nome, Double preco){
        this.nome = nome;
        this.preco = preco;
    }

    public void setNome(String nome){
        this.nome = nome;
    }

    public String getNome(){
        return nome;
    }

    public void setPreco(Double preco){
        this.preco = preco;
    }

    public Double getPreco(){
        return preco;
    }

    public String tagPreco(){
        return nome + " $ " + String.format("%.2f", preco);
    }
}
