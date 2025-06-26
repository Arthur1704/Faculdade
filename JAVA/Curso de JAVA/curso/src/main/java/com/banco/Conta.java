package com.banco;

public class Conta {
    private int numero;
    private String nome_titular;
    private double saldo;

    public Conta(int numero, String nome_titular, double deposito){
        this.numero = numero;
        this.nome_titular = nome_titular;
        deposito(deposito);
    }

    public Conta(int numero, String nome_titular){
        this.numero = numero;
        this.nome_titular = nome_titular;
    }

    public int get_numero(){
        return numero;
    }

    public void set_nomeTitular(String nome_atualizado){
        this.nome_titular = nome_atualizado;
    }

    public String get_nomeTitular(){
        return nome_titular;
    }
    
    public double get_saldo(){
        return saldo;
    }

    public void deposito(double valor){
        saldo += valor;
    }

    public void saque(double valor){
        if (saldo != 0){
            saldo -= valor + 5;
        }
        else{
            System.out.println("Saldo insuficiente para saque !!");
        }
    }

    public String toString(){
        return "Conta : "
                + numero
                + ", Nome: "
                + nome_titular
                + ", Saldo: $ "
                + String.format("%. 2f", saldo);
    }


}
