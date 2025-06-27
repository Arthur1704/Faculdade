package com.utilitarios;

public class ItensPedido {
    private Integer quantidade;
    private Double preco;
    private Produto produto;

    public ItensPedido(int quantidade, double preco, Produto produto){
        this.quantidade = quantidade;   
        this.preco = preco;
        this.produto = produto;
    }

    public void setQuantidade(int num){
        quantidade += num;
    }

    public int getQuantidade(){
        return quantidade;
    }

    public double getPreco(){
        return preco;
    }

    public void setProduto(Produto produto){
        this.produto = produto;
    }

    public Produto getProduto(){
        return produto;
    }

    public double subTotal(){
        return preco * quantidade;
    }

    @Override
    public String toString(){
        return getProduto().getNome()
                + ", $"
                + String.format("%.2f", preco)
                + ", Quantidade: "
                + quantidade
                + ", SubTotal: $"
                + String.format("%.2f", subTotal());
    }


}
