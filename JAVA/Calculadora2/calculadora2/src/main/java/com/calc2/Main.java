package com.calc2;

import java.util.Scanner;


public class Main {
    public static Scanner guardar = new Scanner(System.in);
    

    public static void lerProduto(){

        System.out.print("Nome do Produto: ");
        String nomeP = guardar.nextLine();
        guardar.nextLine();
        System.out.print("Quantidade do Produto: ");
        int quant = guardar.nextInt();
        System.out.print("Valor do Produto: ");
        double valor = guardar.nextDouble();

        Produto produto = new Produto(nomeP, quant, valor);

    }

    public static void verProduto(){

        System.out.print("Nome do produto que deseja ver as informações: ");
        String nome = guardar.nextLine();
        guardar.nextLine();
        
        Produto produto = new Produto();
        int quant = produto.Buscar_quantP(nome);
        double valor = produto.Buscar_valorP(nome);

        System.out.println("O produto " + nome + " tem " + quant + " unidades e custa " + valor + "R$ a unidade");
    }

    public static void main(String[] args) {

        Loja loja = new Loja();
        
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
                    
                    break;
                case 4:
                    
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

