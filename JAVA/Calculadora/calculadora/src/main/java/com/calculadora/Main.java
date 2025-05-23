package com.calculadora;

import java.util.Scanner;


public class Main {
    public static Scanner guardar = new Scanner(System.in);

    public static double set_num(int op){
        double num = 0;
        if (op != 5){
            System.out.print("Entre com um numero: ");
            num = guardar.nextDouble();
        }
        else{
            System.out.print("Entre com o valor da sua compra: ");
            num = guardar.nextDouble();        
        }

        return num;
    }
    public static void main(String[] args) {

        Calculadora calculadora = new Calculadora();
        Tributacao tributacao = new Tributacao();
        double num1 = 0, num2, resultado = 0;
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

        if (operacao != 5){
            if (S_N == 'N'){
                num1 = set_num(operacao);
            }
            else{
                num1 = resultado;
            }
        }
        num2 = set_num(operacao);

        
            switch (operacao) {
                case 1:
                    resultado = calculadora.Soma(num1, num2);
                    System.out.println("O resultado da sua soma foi " + calculadora.Soma(num1, num2));
                    break;
                case 2:
                    resultado = calculadora.Subtracao(num1, num2);
                    System.out.println("O resultado da sua subtração foi " + calculadora.Subtracao(num1, num2));   
                    break;
                case 3:
                    resultado = calculadora.Multiplicacao(num1, num2);
                    System.out.println("O resultado da sua multiplicação foi " + calculadora.Multiplicacao(num1, num2)); 
                    break;
                case 4:
                    resultado = calculadora.Divisao(num1, num2);
                    System.out.println("O resultado da sua divisão foi " + calculadora.Divisao(num1, num2));
                    break;
                case 5:
                    double imposto = tributacao.Imposto(num2);
                    System.out.printf("O valor do seu imposto é R$%.2f e o valor final da sua compra é R$%.2f\n", imposto, imposto + num2);    
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

