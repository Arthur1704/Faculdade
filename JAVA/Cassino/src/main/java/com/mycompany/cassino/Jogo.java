/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package com.mycompany.cassino;

/**
 *
 * @author Thiago
 */
public class Jogo {
    String nome;
    Jogador[] jogadores;
    Modalidade[] modalidades;
    Rodada[] rodadas;
    
    public Jogo(String nome, Jogador[] jogadores, Modalidade[] modalidades, Rodada[] rodadas){
       this.nome = nome;
       this.jogadores = jogadores;
       this.modalidades = modalidades;
       this.rodadas = rodadas;
    }
}
