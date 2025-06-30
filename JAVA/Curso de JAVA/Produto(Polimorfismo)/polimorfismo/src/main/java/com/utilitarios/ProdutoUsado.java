package com.utilitarios;

import java.text.SimpleDateFormat;
import java.util.Date;

public class ProdutoUsado extends Produto{
    private static SimpleDateFormat formato = new SimpleDateFormat("dd/MM/yyyy");
    private Date data;

    public ProdutoUsado(){
        super();
    }
    
    public ProdutoUsado(String nome, Double preco, Date data){
        super(nome, preco);
        this.data = data;
    }

    public void setData(Date data){
        this.data = data;
    }

    public Date getData(){
        return data;
    }

    @Override
    public String tagPreco(){
        return getNome() + " (usado $ ) " + String.format("%.2f", getPreco()) + " (Data de fabicação:" + formato.format(data) + " )";
    }




}
