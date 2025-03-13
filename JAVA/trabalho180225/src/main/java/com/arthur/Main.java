package com.arthur;

import java.util.Scanner;

public class Main {


    public static void main(String[] args) {
        
        Scanner guardar = new Scanner(System.in);

        int[][] matriz = new int[4][4];
        
        
        String cpf, rg, data;

        
        System.out.println("Entre com o seu CPF: ");
        cpf = guardar.nextLine();
    
        String[] partesCPF = cpf.split("\\.");
        String[] partesCPF2 = partesCPF[2].split("\\-");

        
        for (int cont = 0; cont < 2; cont++){
            matriz[0][cont] = Integer.parseInt(partesCPF[cont]);
            matriz[0][cont+2] = Integer.parseInt(partesCPF2[cont]); 
        }
        
        System.out.println("Entre com o seu RG: ");
        rg = guardar.nextLine();

        String[] partesRG = rg.split("\\.");
        String[] partesRG2 = partesRG[2].split("\\-");

        for (int cont = 0; cont < 2; cont++){
            matriz[1][cont] = Integer.parseInt(partesRG[cont]);
            matriz[1][cont+2] = Integer.parseInt(partesRG2[cont]);
        }

        System.out.println("Data nascimento(dd/mm/aaaa): ");
        data = guardar.nextLine();

        String[] partesDATA = data.split("\\/");
        
        String ano;
        ano = partesDATA[2];
        String[] partesANO = new String[2]; 
        partesANO[0]= ano.substring(0,2 );
        partesANO[1]= ano.substring(2,4);

        for (int cont = 0; cont < 2; cont++){
            matriz[2][cont] = Integer.parseInt(partesDATA[cont]);
        }
        for(int cont = 0; cont < 2; cont++){
            matriz[2][cont+2] = Integer.parseInt(partesANO[cont]);
        }

        System.out.println("Nome: ");
        String nome = guardar.nextLine();

        for (int cont = 0; cont < 4; cont++){
            char parte = nome.charAt(cont);
            parte = Character.toUpperCase(parte);
            matriz[3][cont] = parte - 'A' + 1;
        }

        System.out.println("Operação matematica (SOMA, SUBTRACAO: )");
        String operacao = guardar.nextLine();
        operacao = operacao.toUpperCase();

        System.out.println("Direção (VERTICAL, HORIZONTAL)");
        String direcao = guardar.nextLine();
        direcao = direcao.toUpperCase();
        guardar.close();
        

        int[] resultados = new int[4];
        int resultado = 1;
        if (direcao.equals("VERTICAL")){
            if (operacao.equals("SOMA")){
                for (int cont = 0; cont < 4; cont++){

                    resultados[cont] = 0;

                    for (int cont2 = 0; cont2 < 4; cont2++){

                        resultados[cont] +=  matriz[cont2][cont];

                    }

                    resultado *=  resultados[cont];   
                 }
                System.out.println("A sua senha é " + resultado);
            }   
            else if (operacao.equals("SUBTRACAO")){
                for (int cont = 0; cont < 4; cont++){

                    resultados[cont] = matriz[0][cont];

                    for (int cont2 = 0; cont2 < 4; cont2++){

                        resultados[cont] -=  matriz[cont2][cont];

                    }

                    resultado *=  resultados[cont];   
                }
                System.out.println("A sua senha é: "+resultado);
            }
        }

        if (direcao.equals("HORIZONTAL")){
            if (operacao.equals("SOMA")){
                for (int cont = 0; cont < 4; cont++){

                    resultados[cont] = 0;

                    for (int cont2 = 0; cont2 < 4; cont2++){

                        resultados[cont] +=  matriz[cont2][cont];

                    }

                    resultado *=  resultados[cont];   
                }
                System.out.println("A sua senha é: "+resultado);
            }   
            else if (operacao.equals("SUBTRACAO")){
                for (int cont = 0; cont < 4; cont++){

                    resultados[cont] = matriz[0][cont];

                    for (int cont2 = 0; cont2 < 4; cont2++){

                        resultados[cont] -=  matriz[cont2][cont];

                    }

                    resultado *=  resultados[cont];   
                }
                System.out.println("A sua senha é: "+resultado);
            }
        }
    }    
}
