package com.arthur_banco;

import java.util.Scanner;

public class Sistema {
    public static Scanner guardar = new Scanner(System.in);
    public static Agencia[] agencias = new Agencia[100];
    public static Conta[] contasF = new Conta[100];
    public static Conta[] contasJ = new Conta[100];
    public static int contadorA = 0;
    public static int contadorCF = 0;
    public static int contadorCJ = 0;

    private static void criar_conta() {
        System.out.print("Infome o numero da Agencia que deseja criar a conta: ");
        String num_Agencia = guardar.nextLine();
        System.out.print("Numero da conta: ");
        String num_conta = guardar.nextLine();
        System.out.print("Pessoa F ou J: ");
        char F_J = guardar.next().charAt(0);
        guardar.nextLine();
        F_J = Character.toUpperCase(F_J);

        if (F_J == 'F') {
    
            if (contadorCF < contasF.length) {
                System.out.print("Nome da Pessoa: ");
                String nome = guardar.nextLine();
                System.out.print("Endereco: ");
                String endereco = guardar.nextLine();
                System.out.print("Telefone: ");
                String telefone = guardar.nextLine();
                System.out.print("CPF: ");
                String cpf = guardar.nextLine();

                contasF[contadorCF] = new Conta();
                contasF[contadorCF].set_conta_F(nome, endereco, telefone, num_Agencia, num_conta, cpf, contadorCF);
                contadorCF++;
            } else {
                System.out.println("Limite de contas de Pessoa Física atingido.");
            }
        } else {
    
            if (contadorCJ < contasJ.length) {
                System.out.print("Nome: ");
                String nome = guardar.nextLine();
                System.out.print("Endereco: ");
                String endereco = guardar.nextLine();
                System.out.print("Telefone: ");
                String telefone = guardar.nextLine();
                System.out.print("CNPJ: ");
                String cnpj = guardar.nextLine();

                contasJ[contadorCJ] = new Conta();
                contasJ[contadorCJ].set_conta_J(nome, endereco, telefone, num_Agencia, num_conta, cnpj, contadorCJ);
                contadorCJ++; 
            } else {
                System.out.println("Limite de contas de Pessoa Jurídica atingido.");
        }
    }
}

    private static void depositar() {
        System.out.print("Numero da conta, para depositar: ");
        String num_conta = guardar.nextLine();
        System.out.print("Valor desejado: ");
        double valor = guardar.nextDouble();

        for (int cont = 0; cont < contasF.length; cont++) {
            if (contasF[cont] != null && contasF[cont].num_conta.equals(num_conta)) {
                contasF[cont].depositar(valor);
                System.out.println("Depósito realizado com sucesso!");
                return;
            }
        }

        for (int cont = 0; cont < contasJ.length; cont++) {
            if (contasJ[cont] != null && contasJ[cont].num_conta.equals(num_conta)) {
                contasJ[cont].depositar(valor);
                System.out.println("Depósito realizado com sucesso!");
                return;
            }
        }

        System.out.println("Conta não encontrada.");
    }

    private static void transferir() {
        System.out.print("Conta 1: ");
        String conta1 = guardar.nextLine();
        System.out.print("Conta 2: ");
        String conta2 = guardar.nextLine();
        System.out.print("Valor que irá transferir: ");
        double valor = guardar.nextDouble();
        guardar.nextLine();

        for (int cont = 0; cont < contasF.length; cont++) {
            if (contasF[cont] != null && contasF[cont].num_conta.equals(conta1)) {
                if (contasF[cont].sacar(valor)) {
                    for (int cont2 = 0; cont2 < contasF.length; cont2++) {
                        if (contasF[cont2] != null && contasF[cont2].num_conta.equals(conta2)) {
                            contasF[cont2].depositar(valor);
                            System.out.println("Transferência realizada com sucesso!");
                            return;
                        }
                    }

                    for (int cont2 = 0; cont2 < contasJ.length; cont2++) {
                        if (contasJ[cont2] != null && contasJ[cont2].num_conta.equals(conta2)) {
                            contasJ[cont2].depositar(valor);
                            System.out.println("Transferência realizada com sucesso!");
                            return;
                        }
                    }
                }
            }
        }
    }            

    private static void ver_extrato() {
        System.out.print("Numero da conta: ");
        String num_conta = guardar.nextLine();
    
        for (int cont = 0; cont < contasF.length; cont++) {
            if (contasF[cont] != null && contasF[cont].num_conta.equals(num_conta)) {
                System.out.println("O saldo da sua conta é de R$" + contasF[cont].saldo);
                return;
            }
        }
    
        for (int cont = 0; cont < contasJ.length; cont++) {
            if (contasJ[cont] != null && contasJ[cont].num_conta.equals(num_conta)) {
                System.out.println("O saldo da sua conta é de R$" + contasJ[cont].saldo);
                return;
            }
        }
    
        System.out.println("Conta não encontrada.");
    }
    public static void main(String[] args) {
    
        int op;


        do{

            System.out.println("1 - Nova Agencia");
            System.out.println("2 - Nova conta");
            System.out.println("3 - Depostar");
            System.out.println("4 - Transferir");
            System.out.println("0 - Sair\n");

            System.out.print("Entre com a opção desejada: ");
            op = guardar.nextInt();
            guardar.nextLine();

            switch (op) {
                case 1:
                    if (contadorA < 100){
                        System.out.print("Nome banco: ");
                        String nome = guardar.nextLine();
                        System.out.print("Telefone: ");
                        String tele = guardar.nextLine();
                        System.out.print("Sede: ");
                        String sede = guardar.nextLine();
                        System.out.print("Numero da Agencia: ");
                        String numA = guardar.nextLine();

                        agencias[contadorA] = new Agencia(nome, sede, tele, numA);
                        contadorA++;
                    }
                    break;
                
                case 2:
                    criar_conta();
                    break;

                case 3:{
                    depositar();
                    break;
                }
                case 4:{
                    transferir();
                    break;
                }
                case 5:{
                    ver_extrato();
                }
                default:
                    break;
            }

        }while(op != 0);
        guardar.close();
    }
}