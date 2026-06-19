package com.example.prova;

public class Aula {

    private String id;
    private String titulo;
    private String tipo;

    private String dificuldade;

    private String data;
    private String conteudo;

    public Aula(String id, String titulo, String tipo, String dificuldade, String data, String conteudo) {
        this.id = id;
        this.titulo = titulo;
        this.tipo = tipo;
        this.dificuldade = dificuldade;
        this.data = data;
        this.conteudo = conteudo;
    }

    public String getId() {
        return id;
    }

    public String getTitulo() {
        return titulo;
    }

    public String getTipo() {
        return tipo;
    }

    public String getConteudo() {
        return conteudo;
    }

    public String getDificuldade() {
        return dificuldade;
    }

    public String getData() {
        return data;
    }
}
