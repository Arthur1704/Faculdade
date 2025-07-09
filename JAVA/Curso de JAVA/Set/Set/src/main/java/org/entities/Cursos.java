package org.entities;

public class Cursos {

    private String nome;
    private Integer duracao;

    public Cursos() {
    }

    public Cursos(String nome, Integer duracao) {
        this.nome = nome;
        this.duracao = duracao;
    }

    public String getNome() {
        return nome;
    }

    public void setNome(String nome) {
        this.nome = nome;
    }

    public Integer getDuracao() {
        return duracao;
    }

    public void setDuracao(Integer duracao) {
        this.duracao = duracao;
    }

}
