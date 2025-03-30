package com.arthur_banco;

public class Pessoa_F extends Pessoa{

    String cpf;

    protected Pessoa_F(){

    }

    protected Pessoa_F(String nome, String endereco, String telefone, String cpf){

        this.nome = nome;
        this.endereco = endereco;
        this.num_contato = telefone;
        this.cpf = cpf;

    }

}
