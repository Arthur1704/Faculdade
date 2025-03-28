package com.arthur_banco;

public class Pessoa_F extends Pessoa{

    String cpf;
    String rg;
    String email;
    String emprego;

    private Pessoa_F(){

    }

    private Pessoa_F(String nome, String endereco, int numero, String cpf, String rg, String email, String emprego){

        this.nome = nome;
        this.endereco = endereco;
        this.num_contato = numero;
        this.rg = rg;
        this.cpf = cpf;
        this.email = email;
        this.emprego = emprego; 

    }

}
