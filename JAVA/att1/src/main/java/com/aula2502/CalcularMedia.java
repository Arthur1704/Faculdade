package com.aula2502;

import java.util.Scanner;


public class CalcularMedia {
   
    private static Scanner guardar = new Scanner(System.in);

    public static int menu(){

        System.out.println("-----------------------\n");
        System.out.println("| 1 - Entrar com a p1 |\n");
        System.out.println("| 2 - Entrar com a p2 |\n");
        System.out.println("----------------------\n\n");


        System.out.print("Escolha uma opção: ");
        int tipoNota = guardar.nextInt();

        return tipoNota;

    }
    
    public static double lerp1 (int cont){
        
        System.out.printf("Nota da p1 do aluno " + (cont+1) + ":");
        double nota = guardar.nextDouble();
        return nota;
    }

    public static double lerp2 (int cont){
        
        System.out.printf("Nota da p2 do aluno " + (cont+1) + ":");
        double nota = guardar.nextDouble();
        return nota;
    }

    public static double media(double p1, double p2){
        
        double media = (p1 + p2) / 2;
        return media;

    }

    public static int melhor(double p1, double p2){
        if (p1 > p2){
            return 1;
        }
        else if (p2 > p1){
            return 2;
        }
        else{
            return 3;
        }
    }

    public static double mediatotal(double notas[], int quant){
        double soma = 0;
        for (int cont = 0; cont < quant; cont++){
            soma += notas[cont];
        }
        return soma / quant;
    }

    public static void main(String[] args) {

        Scanner guardar = new Scanner(System.in);
        double[] p1 = new double[100];
        double[] p2 = new double[100];
        double[] media = new double[100];
        String S_N;
        int quant=0;

        switch(menu()){
            case 1:
                int cont = 0;
                do{   
                    p1[cont] = lerp1(cont);
                    System.out.print("Deseja continuar armazenando notas da p1 (S ou N): ");
                    S_N = guardar.nextLine();
                    S_N = S_N.toUpperCase();
                    quant++;
                    cont++;
                }while(S_N.equals("S"));

                for (cont = 0; cont < quant; cont++){
                    p2[cont] = lerp2(cont);
                }
                break;
            case 2:
                cont = 0;
                do{
                    p2[cont] = lerp2(cont);
                    System.out.print("Deseja continuar armazenando notas da p2 (S ou N): ");
                    S_N = guardar.nextLine();
                    S_N = S_N.toUpperCase();
                    quant++;
                    cont++;
                }while(S_N.equals("S"));

                for (cont = 0; cont < quant; cont++){
                    p2[cont] = lerp1(cont);
                }
                break;    
        }
        
        guardar.close();

        for (int cont = 0; cont < quant; cont++){
            
            double notap1 = p1[cont];
            double notap2 = p2[cont];

            media[cont] = media(notap1, notap2);

            System.out.printf("\nA média do aluno " + (cont + 1) + " é: " + media[cont]);
            
            switch (melhor(notap1,notap2)) {
                case 1:
                    System.out.printf("\nA melhor Nota do aluno " + (cont + 1) + " é a P1");
                    break;
                case 2:
                    System.out.printf("\nA melhor Nota do aluno " + (cont + 1) + " é a P2");
                    break;
                default:{
                    System.out.printf("\nO aluno " + (cont + 1) + " teve as notas da P1 igual da P2");
                }    
            }
        }
        
        System.out.println("\nA media da sala na P1 foi: " + mediatotal(p1, quant));
        System.out.println("A media da sala na P2 foi: " + mediatotal(p2, quant));
    }
}
