package com.calc2;

public class Calculadora{

    public double Soma(double num1, double num2){

        return num1 + num2;

    }

    public double Subtracao(double num1, double num2){

        return num1 - num2;

    }

    public double Multiplicacao(double num1, double num2){

        return num1 * num2;

    }

    public double Divisao(double num1, double num2){
        if(num2 != 0){
            return num1 / num2;
        }
        else{
            return 0;
        }
    }
}
