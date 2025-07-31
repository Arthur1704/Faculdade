package application;

import chess.ChessPiece;

public class UI {

    public static void printBoard(ChessPiece[][] pieces){
        for (int cont = 0; cont <pieces.length; cont++){
            System.out.print((8 - cont) + " ");
            for (int cont2 = 0; cont2 < pieces.length; cont2++){
                printPiece(pieces[cont][cont2]);
            }
            System.out.println();
        }
        System.out.println("  a b c d e f g h");
    }

    public static void printPiece(ChessPiece piece){
        if (piece == null){
            System.out.print("-");
        }
        else{
            System.out.print(piece);
        }
        System.out.print(" ");
    }
}
