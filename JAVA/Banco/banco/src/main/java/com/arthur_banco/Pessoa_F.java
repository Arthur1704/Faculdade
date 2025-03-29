package com.arthur_banco;

public class Pessoa_F extends Pessoa{

    String cpf;
    String rg;
    String email;
    String num_conta;

    protected Pessoa_F(){

    }

    protected Pessoa_F(String nome, String endereco, String numero, String cpf, String rg, String email){

        this.nome = nome;
        this.endereco = endereco;
        this.num_contato = numero;
        this.rg = rg;
        this.cpf = cpf;
        this.email = email;

    }

}
