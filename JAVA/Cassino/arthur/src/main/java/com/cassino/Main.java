package com.cassino;
import java.util.scanner;
public class Main {
    public static Scanner guardar = new Scanner(System.in);
    public static void main(String[] args) {
    Jogos jogo = new Jogos();
    Jogadores jogador = new Jogadores();
    
    jogador.nome = "Arthur Viana";
    jogador.quant_fichas = 145;

    jogo.set_jogadores(jogador);
    jogo.set_Jogo("Poker", "Cartas");   

    }
}