package com.banco;

import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner guardar = new Scanner(System.in);

        System.out.print("Entre com o numero da conta: ");
        int numero = guardar.nextInt();
        guardar.nextLine();
        System.out.print("Entre com o nome do titular da conta: ");
        String nome = guardar.nextLine();

        System.out.print("Deseja fazer um deposito inicial ?(S ou N)");
        char deposito = guardar.next().charAt(0);
        deposito = Character.toUpperCase(deposito);

        Conta conta;

        if (deposito == 'S'){
            System.out.print("Entre com o valor a ser depositado: ");
            double valor = guardar.nextDouble();
            conta = new Conta(numero, nome, valor);
        }
        else{
            conta = new Conta(numero, nome);
        }

        System.out.println(conta.toString());

        System.out.print("Entre com o valor a ser depositado: ");
        double valor_depositar = guardar.nextDouble();
        conta.deposito(valor_depositar);

        System.out.println("Status da conta atualizado");
        System.out.println(conta.toString());

        System.out.print("Entre com valor a ser sacado: ");
        double valor_sacar = guardar.nextDouble();
        conta.saque(valor_sacar);

        System.out.println(conta.toString());

        guardar.close();
    }
}