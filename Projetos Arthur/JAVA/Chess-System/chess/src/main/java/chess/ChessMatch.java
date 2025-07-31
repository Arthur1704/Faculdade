package chess;

import boardgame.Board;

public class ChessMatch {

    private Board board;

    public ChessMatch(){
        board = new Board(8,8);
    }

    public ChessPiece[][] getPieces(){
        ChessPiece[][] mat =  new ChessPiece[board.getRows()][board.getColumns()];
        for (int cont = 0; cont < board.getRows(); cont++){
            for(int cont2 = 0; cont2 < board.getColumns(); cont2++){
                mat[cont][cont2] = (ChessPiece) board.piece(cont, cont2);
            }
        }
        return mat;
    }
}
