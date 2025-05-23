package com.testeapi;

public class CalcularMoeda {

    APIdolar dolar = new APIdolar();
    APIeuro euro = new APIeuro();

    private double precoDolar = dolar.valorDolarAgora();
    private double precoEuro = euro.valorEuroAgora();

    public double dolar_real(double valor){
        double resultado = valor * precoDolar;
        return resultado;
    }

    public double euro_real(double valor){
        double resultado = valor * precoEuro;
        return resultado;
    }

    public double real_dolar(double valor){
        double resultado = valor / precoDolar;
        return resultado;
    }

    public double real_euro(double valor){
        double resultado = valor / precoEuro;
        return resultado;
    }

    public double euro_dolar(double valor){
        double resultado = valor * precoDolar;
        return resultado;
    }

    public double dolar_euro(double valor){
        double resultado = valor * precoEuro;
        return resultado;
    }
}
