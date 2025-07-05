package com.programa;

import java.util.Scanner;

import com.utilitarios.Conta;
import com.utilitarios.exceções.SaqueExeption;

public class Main {
    public static void main(String[] args) {

        Scanner guardar = new Scanner(System.in);

        try{
            System.out.println("Entre os dados da conta");
            System.out.print("Numero: ");
            int numero = guardar.nextInt();
            guardar.nextLine();
            System.out.print("Titular: ");
            String titular = guardar.nextLine();
            System.out.print("Saldo inicial: ");
            Double saldo = guardar.nextDouble();
            System.out.print("Limite de saque: ");
            Double limite = guardar.nextDouble();

            Conta conta = new Conta(numero, titular, saldo, limite);

            System.out.print("\nValor para saque: ");
            Double valor = guardar.nextDouble();

            conta.saque(valor);

            System.out.println(conta);

        }
        catch(SaqueExeption e){
            System.out.println("Mensagem do sistema: " + e.getMessage());
        }
        catch(RuntimeException e){
            System.out.println("Mensagem do Sistema: " + e.getMessage());
        }

        guardar.close();

    }
}