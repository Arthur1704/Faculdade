package com.arthur_banco;

public class Conta extends Agencia{

    Pessoa_F[] pessoaF = new Pessoa_F[100];
    Pessoa_J[] pessoaJ = new Pessoa_J[100];
    int contadorCJ = 0;
    int contadorPF = 0;
    int contadorCF = 0;
    int contadorPJ = 0;
    String num_conta;
    double saldo = 0;
    String num_agencia_C;

    
    protected Conta(){

    }
    
    protected Conta(String conta, Agencia agencias[], String num_Agencia, char F_J){

        boolean agenciaEncontrada = false;

        for (int cont = 0; cont < agencias.length; cont++) {
            if (agencias[cont] != null && agencias[cont].num_Agencia.equals(num_Agencia)) {
                agenciaEncontrada = true;
                if (F_J == 'F') {
                    this.pessoaF[contadorCF].num_conta = conta;
                    this.num_agencia_C = num_Agencia;
                    this.num_conta = conta;
                    contadorCF++;
                } else {
                    this.num_conta = conta;
                    this.num_agencia_C = num_Agencia;
                    this.num_conta = conta;
                    contadorCJ++;
                }
                break;
            }
        }

        if (!agenciaEncontrada) {
            System.out.println("Agência não encontrada: " + num_Agencia);
        }

    }

    public void set_pessoa_f(){

        System.out.print("Nome da Pessoa: ");
        String nome = guardar.nextLine();
        System.out.print("Endereco: ");
        String endereco = guardar.nextLine();
        System.out.print("Telefone: ");
        String telefone = guardar.nextLine();
        System.out.print("CPF: ");
        String cpf = guardar.nextLine();
        System.out.print("RG: ");
        String rg = guardar.nextLine();
        System.out.print("E-mail: ");
        String email = guardar.nextLine();

        if(contadorPF < 100){
            pessoaF[contadorPF] = new Pessoa_F(nome, endereco, telefone, cpf, rg, email);
            contadorPF++;
        }
    }

    public void set_pessoa_j(){

        System.out.print("Nome da Pessoa: ");
        String nome = guardar.nextLine();
        System.out.print("Endereco: ");
        String endereco = guardar.nextLine();
        System.out.print("Telefone: ");
        String telefone = guardar.nextLine();
        System.out.print("CNPJ: ");
        String cnpj = guardar.nextLine();
        System.out.print("Nome Fantasia: ");
        String nomeF = guardar.nextLine();
        System.out.print("Ramo de atividade: ");
        String ramo = guardar.nextLine();

        if(contadorPF < 100){
            pessoaJ[contadorPJ] = new Pessoa_J(nome, endereco, telefone, cnpj, nomeF, ramo);
            contadorPF++;
        }
        guardar.close(); 
    }


    public void depositar(double valor){

        this.saldo += valor;
        
    }
    
    protected boolean sacar(double retirar){

        if(retirar < this.saldo){
            this.saldo -= retirar;
            return true;
        }
        else{
            return false;
        }  
    }

}
