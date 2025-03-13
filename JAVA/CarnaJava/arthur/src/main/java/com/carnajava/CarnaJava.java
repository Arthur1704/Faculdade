package com.carnajava;

import java.util.Scanner;

public class CarnaJava {
    public static Scanner guardar = new Scanner(System.in);

    public static String samba(String nome){        
        System.out.print("Entre com o Samba enrredo da escola " + nome + ": ");
        String samba = guardar.nextLine();
        return samba;
    }

    public static String tema(String nome){
        System.out.print("Entre com o tema da escola " + nome + ": ");
        String tema = guardar.nextLine();
        return tema;
    }

    public static String caracteristicas(String nome){
        System.out.print("Entre com as caracteristicas da escola " + nome + ": ");
        String cara = guardar.nextLine();
        return cara;
    }

    public static String famoso(String nome){
        System.out.print("Entre com o nome do famoso desfilando da escola " + nome + ": ");
        String famo = guardar.nextLine();
        return famo;
    }

    public static int somaNotas(String nome){
        int nota1, nota2;

        System.out.print("Entre com a nota 1 da escola " + nome + ":");
        nota1 = guardar.nextInt();
        System.out.print("Entre com a nota 2 da escola " + nome + ":");
        nota2 = guardar.nextInt();

        return nota1 + nota2;
    }

    public static void maiorNota(int notas[], int quant, String escolas[][]){
        int maior = 0;
        int testar = notas[0];
        int[] igual = new int[quant];
        int cont2 = 0;
        for (int cont = 1; cont < quant; cont++){
            if (notas[cont] > testar){
                maior = cont;
                testar = notas[cont];
            }else if(notas[cont] == testar){
                igual[cont2] = cont;
                cont2++;
            }
        }
        if (cont2 != 1){
            System.out.println("A escola campeã é a " + escolas[0][maior]);
        }
        else{
            System.out.print("A maiores notas são das escolas");
            for (int cont = 0; cont < igual.length; cont++){
                System.out.print(escolas[0][cont]);
            }
        }
    }


    public static void main(String[] args) {


        System.out.print("Entre com a quantidade de escolas: ");
        int quant = guardar.nextInt();
        

        String[][] info = new String[quant][5];
        int[] notas = new int[quant];
        
        for (int cont = 0; cont < quant; cont++){
            guardar.nextLine();
            System.out.print("Nome da escola: ");
            String nome  = guardar.nextLine();

            info[cont][0] = nome;
            info[cont][1] = samba(nome);
            info[cont][2] = tema(nome);
            info[cont][3] = caracteristicas(nome);
            info[cont][4] = famoso(nome);

            notas[cont] = somaNotas(nome);
        }

        for(int cont = 0; cont < quant; cont++){
            for(int cont2 = 0; cont2 < 5; cont2++){
                System.out.print(info[cont][cont2] + ", ");
            }
            System.out.print("\n");
        }
        maiorNota(notas, quant, info);        
        
        guardar.close();
    }

}
