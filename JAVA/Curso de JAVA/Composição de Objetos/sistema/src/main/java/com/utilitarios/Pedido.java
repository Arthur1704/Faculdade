package com.utilitarios;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;

public class Pedido {

    private static SimpleDateFormat format = new SimpleDateFormat("dd/MM/yyyy");
    private Date momento;
    private Status status;
    private Cliente cliente;
    private ArrayList<ItensPedido> itens = new ArrayList<>();

    public Pedido(Date data, Status st, Cliente cliente){
        this.momento = data;
        this.status = st;
        this.cliente = cliente;        
    }

    public Date getMomento() {
    return momento;
    }

    public void setMomento(Date momento) {
        this.momento = momento;
    }

    public Status getStatus() {
        return status;
    }

    public void setStatus(Status status) {
        this.status = status;
    }

    public Cliente getCliente() {
        return cliente;
    }

    public void setCliente(Cliente cliente) {
        this.cliente = cliente;
    }

    public void adicionarIten(ItensPedido item){
        itens.add(item);
    }

    public void removerIten(ItensPedido item){
        itens.remove(item);
    }

    public double total(){
        double soma = 0;
        for (ItensPedido it : itens){
            soma += it.subTotal();
        }
        return soma;
    }

    @Override
    public String toString(){
        StringBuilder buider = new StringBuilder();
        buider.append("Momento do pedido: ");
        buider.append(format.format(momento) + "\n");
        buider.append("Status do pedido: ");
        buider.append(status + "\n");
        buider.append("Cliente: ");
        buider.append(cliente + "\n");
        buider.append("Itens pedido:\n");
        for(ItensPedido it : itens){
            buider.append(it + "\n");
        }
        buider.append("Total preço: ");
        buider.append(String.format("%.2f", total()));
        return buider.toString();
    }
    
}   
