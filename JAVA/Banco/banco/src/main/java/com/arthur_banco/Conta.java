package com.arthur_banco;

public class Conta {

    Pessoa_F[] pessoa_F = new Pessoa_F[100];
    Pessoa_J[] pessoa_J = new Pessoa_J[100];
    String num_agencia;
    String num_conta;
    double saldo;

    public Conta() {
        
        for (int i = 0; i < 100; i++) {
            pessoa_F[i] = new Pessoa_F(); 
            pessoa_J[i] = new Pessoa_J(); 
        }
    }

    protected void set_conta_F(String nome, String endereco, String telefone, String num_agencia, String num_conta, String cpf, int contadorCF){
        pessoa_F[contadorCF].nome = nome;
        pessoa_F[contadorCF].endereco = endereco;
        pessoa_F[contadorCF].cpf = cpf;
        pessoa_F[contadorCF].num_contato = telefone;
        this.num_conta = num_conta;
        this.num_agencia = num_agencia;
    }

    protected void set_conta_J(String nome, String endereco, String telefone, String num_agencia, String num_conta, String cnpj, int contadorCJ){
        pessoa_J[contadorCJ].nome = nome;
        pessoa_J[contadorCJ].endereco = endereco;
        pessoa_J[contadorCJ].cnpj = cnpj;
        pessoa_J[contadorCJ].num_contato = telefone;
        this.num_conta = num_conta;
        this.num_agencia = num_agencia;
    }

    public void depositar(double valor) {
        this.saldo += valor;
    }

    protected boolean sacar(double retirar) {
        if (retirar <= this.saldo) {
            this.saldo -= retirar;
            return true;
        } else {
            return false;
        }
    }
}