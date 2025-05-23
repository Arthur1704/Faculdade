package com.testeapi;

import java.util.Scanner;

public class Main {
    public static Scanner guardar = new Scanner(System.in);
    public static void main(String[] args) {
        CalcularMoeda moeda = new CalcularMoeda();
        int moeda1, moeda2;
        double valor;
        char S_N ;

        do{
            System.out.println("\n\nMOEDAS");
            System.out.println("1 - Dolar");
            System.out.println("2 - Euro");
            System.out.println("3 - Real\n\n");

            System.out.print("Sua moeda: ");
            moeda1 = guardar.nextInt();
            System.out.print("\nMoeda que deseja converter: ");
            moeda2 = guardar.nextInt();

            System.out.print("\nValor que deseja converter: ");
            valor = guardar.nextDouble();
            guardar.nextLine();

            switch (moeda1) {
                case 1:
                    switch (moeda2) {
                        case 2:
                            System.out.println("O seu valor em Euro é € " + moeda.dolar_euro(valor));
                            break;
                        case 3:
                            System.out.print("O seu valor em Real é R$ " + moeda.dolar_real(valor));
                            break;
                        default:
                            System.out.println("Valor Invalido!");
                            break;
                    }
                    break;
                case 2:
                    switch (moeda2) {
                        case 1:
                            System.out.println("O seu valor em Dolar é US$ " + moeda.euro_dolar(valor));
                            break;
                        case 3:
                            System.out.println("O seu valor em Real é R$ " + moeda.euro_real(valor));
                            break;
                        default:
                            System.out.println("Valor Invalido!");
                            break;
                    }
                    break;
                case 3:
                    switch (moeda2) {
                        case 1:
                            System.out.println("O seu valor em Dolar é US$ " + moeda.real_dolar(valor));
                            break;
                        case 2:
                            System.out.println("O seu valor em Euro é € " + moeda.real_euro(valor));
                            break;  
                        default:
                            System.out.println("Valor Invalido!");
                            break;
                    }
                    break;
                default:
                    System.out.println("Valor Invalido!");
                    break;
            }

            
            System.out.print("Deseja fazer outra conversão (S - N): ");
            String sim_nao = guardar.nextLine();

            if (!sim_nao.isEmpty()) {
                S_N = sim_nao.charAt(0);
                S_N = Character.toUpperCase(S_N);
            } else {
                S_N = 'N';
            }


        }while (S_N == 'S');
        guardar.close();
    }
}