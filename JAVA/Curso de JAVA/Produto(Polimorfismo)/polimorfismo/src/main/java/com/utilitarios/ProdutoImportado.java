package com.utilitarios;

public class ProdutoImportado extends Produto{
    private Double frete;


    public ProdutoImportado(){
        super();
    }


    public ProdutoImportado(String nome, Double preco, Double frete){
        super(nome, preco);
        this.frete = frete;
    }

    public void setFrete(Double frete){
        this.frete = frete;
    }

    public Double getFrete(){
        return frete;
    }

    public Double totalPrice(){
        return getPreco() + frete;
    }

    @Override
    public String tagPreco(){
        return getNome() + " $ " + String.format("%.2f" , totalPrice()) + " (Custo de Frete: $ " + String.format("%.2f", frete) + " )"; 
    }

    
}
