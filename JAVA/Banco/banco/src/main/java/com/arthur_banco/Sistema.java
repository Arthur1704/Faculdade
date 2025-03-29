package com.arthur_banco;
import java.util.Scanner;

public class Sistema {
    public static Scanner guardar = new Scanner(System.in);
    public static Agencia agencia[] = new Agencia[100];
    public static Conta contas[] = new Conta[100];
    public static int contadorA = 0;
    public static int contadorC = 0;

    
    private static void criar_C_F(){
        
        System.out.print("Infome o numero da Agencia que deseja criar a conta: ");
        String num_Agencia = guardar.nextLine();
        guardar.nextLine();
        System.out.print("Numero da conta: ");
        String num_conta = guardar.nextLine();
        System.out.print("Pessoa F ou J: ");
        char F_J = guardar.next().charAt(0);
        F_J = Character.toUpperCase(F_J);
        contas[contadorC] = new Conta(num_conta, agencia, num_Agencia, F_J);
        contadorC++;

    }


    private static void depositar(){

        System.out.print("Numero da conta, para depositar: ");
        String num_conta = guardar.nextLine();
        guardar.nextLine();
        System.out.print("Valor desejado: ");
        double valor = guardar.nextDouble();

        for(int cont = 0; cont < contas.length; cont++){

            if(contas[cont].num_conta.equals(num_conta)){
            contas[cont].depositar(valor);
            }
        }
    }

    private static void transferir(){

        System.out.print("Conta 1: ");
        String conta1 = guardar.nextLine();
        guardar.nextLine();
        System.out.print("Conta 2: ");
        String conta2 = guardar.nextLine();

        System.out.println("valor que ira transferir: ");
        double valor = guardar.nextDouble();

        for (int cont = 0; cont < contas.length; cont++){
            if(contas[cont].num_conta.equals(conta1)){
                if(contas[cont].sacar(valor) == true){
                    for(int cont2 = 0; cont < contas.length; cont++){
                        if(contas[cont2].num_conta.equals(conta2)){
                            contas[cont2].depositar(valor);
                            break;
                        }
                    }
                    break;
                }
            }
        }
    }

    private static void ver_extrato(){

        System.out.print("Numero da conta: ");
        String num_conta = guardar.nextLine();

        for(int cont = 0; cont < contas.length; cont++){
            if(contas[cont].num_conta.equals(num_conta)){
                System.out.println("O saldo da sua conta é de R$" + contas[cont].saldo);
            }
        }
    }
    public static void main(String[] args) {
    
        int op;


        do{

            System.out.println("1 - Nova Agencia");
            System.out.println("2 - Nova conta de Pessoa Fisica");
            System.out.println("3 - Ver conta de pessoa Fisica");
            System.out.println("4 - Depostar");
            System.out.println("5 - Transferir");
            System.out.println("0 - Sair\n");

            System.out.print("Entre com a opção desejada: ");
            op = guardar.nextInt();

            switch (op) {
                case 1:
                    if (contadorA < 100){
                        System.out.print("Nome banco: ");
                        String nome = guardar.nextLine();
                        guardar.nextLine();
                        System.out.print("Telefone: ");
                        String tele = guardar.nextLine();
                        System.out.print("Sede: ");
                        String sede = guardar.nextLine();
                        System.out.print("Numero da Agencia: ");
                        String numA = guardar.nextLine();

                        agencia[contadorA] = new Agencia(nome, sede, tele, numA);
                        contadorA++;
                    }
                    break;
                
                case 2:
                    criar_C_F();
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