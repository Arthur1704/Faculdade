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

        double num1, num2, resultado = 0;
        int operacao;
        char S_N = 'N';

        do{

        System.out.println("1 - SOMA");
        System.out.println("2 - SUBTRAÇÂO");
        System.out.println("3 - MULTIPLICAÇÃO");
        System.out.println("4 - DIVISÃO");
        System.out.println("5 - CALCULAR IMPOSTO");

        System.out.print("\n Entre com a opção desejada: ");
        operacao = guardar.nextInt();
        
        if (S_N == 'N'){
            num1 = set_num();
        }
        else{
            num1 = resultado;
        }
        num2 = set_num();

        
            switch (operacao) {
                case 1:
                    resultado = Calculadora.Soma(num1, num2);
                    System.out.println("O resultado da sua soma foi " + Calculadora.Soma(num1, num2));
                    break;
                case 2:
                    resultado = Calculadora.Subtracao(num1, num2);
                    System.out.println("O resultado da sua subtração foi " + Calculadora.Subtracao(num1, num2));   
                    break;
                case 3:
                    resultado = Calculadora.Multiplicacao(num1, num2);
                    System.out.println("O resultado da sua multiplicação foi " + Calculadora.Multiplicacao(num1, num2)); 
                    break;
                case 4:
                    resultado = Calculadora.Divisao(num1, num2);
                    System.out.println("O resultado da sua divisão foi " + Calculadora.Divisao(num1, num2));
                    break;
                case 5:
                    //System.out.println("O resultado da sua soma foi " + Calculadora.Calcular(num1, num2));    
                    break;
                default:
                    System.out.println("Entre com uma opção correta!!");
                    break;
            }
            System.out.print("Deseja fazer uma operação com este resultado (S ou N) ?");
            S_N = guardar.next().charAt(0);
            S_N = Character.toUpperCase(S_N);
        }while(S_N == 'S');

        guardar.close();




        
    } 
}