package com.calc2;

import java.util.Scanner;


public class Main {
    public static Scanner guardar = new Scanner(System.in);
    public static Loja loja = new Loja();

    public static void lerProduto(){

        System.out.print("Nome do Produto: ");
        String nomeP = guardar.nextLine();
        guardar.nextLine();
        System.out.print("Quantidade do Produto: ");
        int quant = guardar.nextInt();
        System.out.print("Valor do Produto: ");
        double valor = guardar.nextDouble();

        
        loja.adiciona_Produto(nomeP, quant, valor);

    }

    public static void verProduto(){

        System.out.print("Nome do produto que deseja ver as informações: ");
        String nomeP = guardar.nextLine();
        guardar.nextLine();

        int quant = loja.Buscar_quantP(nomeP);
        double valor = loja.Buscar_valorP(nomeP);

        System.out.println("\nO produto " + nomeP + " tem " + quant + " unidades e custa " + valor + "R$ a unidade\n\n");
    }

    public static void setar_Venda(){

        System.out.print("Nome do Cliente: ");
        String nomeC = guardar.nextLine();
        guardar.nextLine();
        System.out.print("Nome Produto: ");
        String nomeP = guardar.nextLine();
        System.out.print("Quantidade Vendida: ");
        String quant = guardar.nextLine();
        System.out.print("Valor da venda: ");
        String valor = guardar.nextLine();
        
        loja.set_venda(nomeC, nomeP, valor, quant);
        
    }

    public static void ver_Venda(){
        System.out.print("Nome do Cliente que deseja ver a venda: ");
        String nomeC = guardar.nextLine();
        guardar.nextLine();

        loja.ver_Venda(nomeC);
    }

    public static void main(String[] args) {
        
        int operacao;

        do{

        System.out.println("1 - Adicionar um Produto");
        System.out.println("2 - Ver um produto");
        System.out.println("3 - Adicionar uma venda");
        System.out.println("4 - Ver uma venda feita");
        System.out.println("0 - Sair");

        System.out.print("\n Entre com a opção desejada: ");
        operacao = guardar.nextInt();
        
            switch (operacao) {
                case 1:
                    lerProduto();
                    break;
                case 2:
                    verProduto();
                    break;
                case 3:
                    setar_Venda();
                    break;
                case 4:
                    ver_Venda();
                    break;
                case 0:
                    System.exit(0);
                    break;
                default:
                    System.out.println("Entre com uma opção correta!!");
                    break;
            }
        }while(operacao != 0);

        guardar.close();
    }
}

