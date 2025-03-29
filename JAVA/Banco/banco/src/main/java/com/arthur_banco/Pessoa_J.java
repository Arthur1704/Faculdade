package com.arthur_banco;

public class Pessoa_J extends Pessoa{

    String cnpj;
    String nome_fantasia;
    String ramo_atividade;


    protected Pessoa_J(){

    }

    protected Pessoa_J(String nome, String endereco, String numero, String cnpj, String nomeF, String ramo){

        this.nome = nome;
        this.endereco = endereco;
        this.num_contato = numero;
        this.cnpj = cnpj;
        this.nome_fantasia = nomeF;
        this.ramo_atividade = ramo;

    }
}
