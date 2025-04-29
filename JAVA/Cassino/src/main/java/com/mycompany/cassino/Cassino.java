/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 */

package com.mycompany.cassino;

/**
 *
 * @author Thiago
 */
public class Cassino {

    public static void main(String[] args) {
        Jogador player1 = new Jogador("Thiago", 1000);
        Jogador player2 = new Jogador("Camile", 2000);
        Jogador player3 = new Jogador("Walther",3000);
        
        Modalidade mod1 = new Modalidade("Vinte e um");
        Modalidade mod2 = new Modalidade("Pôquer");
        Modalidade mod3 = new Modalidade("Roleta");
        
        Rodada round1 = new Rodada(1);
        Rodada round2 = new Rodada(3);
        Rodada round3 = new Rodada(2);
        
        Jogador[] jogadores = {player1, player2, player3};
        Modalidade[] modalidades = {mod1, mod2, mod3};
        Rodada[] rodadas = {round1, round2, round3};
        
        Jogo jogo = new Jogo("Mesa 1", jogadores, modalidades, rodadas);
        
        System.out.println("Jogo: "+jogo.nome);
        System.out.println("Jogadores: ");
        for(Jogador cont: jogo.jogadores){
            System.out.println("-"+cont.nome+ " com "+cont.fichas+" fichas");
        }
        
        System.out.println("Modalidades: ");
        for(Modalidade cont: jogo.modalidades){
            System.out.println("-"+cont.nome);
        }
        
        System.out.println("Rodadas: ");
        for(Rodada cont: jogo.rodadas){
            System.out.println("- Rodada "+cont.numero);
        }
        
        
    }
}
