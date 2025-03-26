package com.calc2;

public class Tributacao {
    Calculadora calculadora = new Calculadora();

    public double Imposto_internacional(double valor){
        double imposto = 0;
        double valorCompra = calculadora.Multiplicacao(valor, 5.67);
        if (valorCompra <= 50.00){

            imposto = calculadora.Multiplicacao(valor, 0.20);

        }
        else if (valorCompra > 50.00 && valorCompra <= 3000.00){

            imposto = calculadora.Multiplicacao(valor, 0.60);
            imposto = calculadora.Subtracao(imposto, 20.00);
            
        }

        return imposto;

    }

    public double Imposto_nacional(double valor){
        
        return calculadora.Multiplicacao(valor, 0.23);

    }
}