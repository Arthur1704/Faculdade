package com.cassino;


public class Jogos {
    
    private String nome;
    private String tipo;
    private Jogadores jogadores[] = new Jogadores[10];
    private Rodadas rodadas[];
    private Modalidades[] modalidades;
    private int cont_jogadores = 0;

    public void setJogo(String nome, String tipo){
        this.nome = nome;
        this.tipo = tipo;
    }

    public String get_nome(){
        return this.nome;
    }

    public String get_tipo(){
        return this.tipo;
    }


    public void set_jogadores(Jogadores jogador){
        if (this.cont_jogadores < jogadores.length){
            this.jogadores[cont_jogadores] = jogador;
            cont_jogadores++;
        }
    }

    public void add_moldal(Modalidades modal){
        for (int cont = 0; cont < this.modalidades.length; cont++){
            if(this.modalidades[cont] == null){
                this.modalidades[cont] = modal;       
            }
        }
    }

    public void add_rodadas(Rodadas rodadas){
        for (int cont = 0; cont < this.rodadas.length; cont++){
            if(this.rodadas[cont] == null){
                this.rodadas[cont] = rodadas;;       
            }
        }
    }

}