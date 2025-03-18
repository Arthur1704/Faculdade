package com.calculadora;

import java.util.Scanner;
import com.calculadora.Calculadora;

public class Main {
    public static Scanner guardar = new Scanner(System.in);

    public static double set_num(){
        System.out.print("Entre com um numero: ");
        double num = guardar.nextDouble();
        return num;
    }
    public static void main(String[] args) {

        double num1, num2;
        int operacao;

        System.out.println("1 - SOMA");
        System.out.println("2 - SUBTRAÇÂO");
        System.out.println("3 - MULTIPLICAÇÃO");
        System.out.println("4 - MULTIPLICAÇÃO");
        System.out.println("5 - CALCULAR IMPOSTO");

        System.out.print("\n Entre com a opção desejada: ");
        operacao = guardar.nextInt();

        num1 = set_num();
        num2 = set_num();

        switch (operacao) {
            case 1:
                
                break;
        
            default:
                break;
        }
        System.out.println(Calculadora.Calcular(num1, num2, operacao));

        guardar.close();




        
    } 
}