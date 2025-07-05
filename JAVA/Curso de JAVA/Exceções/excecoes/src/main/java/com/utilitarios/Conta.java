package com.utilitarios;

import com.utilitarios.exceções.SaqueExeption;

public class Conta {
    private Integer numero;
    private String titular;
    private Double saldo;
    private Double limiteSaque;

    public Conta(){

    }

    public Conta(int numero, String titular, double saldo, double limiteSaque){
        this.numero = numero;
        this.titular = titular;
        this.saldo = saldo;
        this.limiteSaque = limiteSaque;
    }

    public void setNumero(int numero){
        this.numero = numero;
    }

    public int getNumero(){
        return numero;
    }

    public void setTitular(String titular){
        this.titular = titular;
    }

    public String getTitular(){
        return titular;
    }

    public double getSaldo(){
        return saldo;
    }

    public void setLimiteSaque(double limiteSaque){
        this.limiteSaque = limiteSaque;
    }

    public double getLimiteSaque(){
        return limiteSaque;
    }

    public void deposito(double valor){
        saldo += valor;
    }

    public void saque(double valor){
        if (valor > limiteSaque){
            throw new SaqueExeption("O valor exedeu o limite de saque!!");
        }
        else if (valor > saldo){
            throw new SaqueExeption("O valor não pode ser maior que o saldo em conta!!");
        }
        saldo -= valor;
    }

    @Override
    public String toString(){
        return "Saldo atual: $" + String.format("%.2f", saldo);
    }

}
