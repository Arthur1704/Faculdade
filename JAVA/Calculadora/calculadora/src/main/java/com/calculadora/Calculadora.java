package com.calculadora;

public class Calculadora{

    public static double Calcular(double num1, double num2, int op){

        switch (op) {
            case 1:
                return  num1 + num2;

            case 2:
                return num1 - num2;

            case 3:
                return num1 * num2;

            case 4:
                return num1 / num2;
            
            default:
                return 0;    
        }
    }
}
