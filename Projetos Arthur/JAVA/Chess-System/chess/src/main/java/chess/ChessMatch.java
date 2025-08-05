package chess;

import boardgame.Board;
import chess.piece.King;
import chess.piece.Rook;

public class ChessMatch {

    private Board board;

    public ChessMatch(){
        board = new Board(8,8);
        initialSetup();
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

    private void placeNewPiece(char colunm, int row, ChessPiece piece){
        board.placePiece(piece, new ChessPosition(colunm, row).toPosition());
    }

    private void initialSetup(){
        placeNewPiece('c', 1, new Rook(board, Color.WHITE));
        placeNewPiece('c', 2, new Rook(board, Color.WHITE));
        placeNewPiece('d', 2, new Rook(board, Color.WHITE));
        placeNewPiece('e', 2, new Rook(board, Color.WHITE));
        placeNewPiece('e', 1, new Rook(board, Color.WHITE));
        placeNewPiece('d', 1, new King(board, Color.WHITE));

        placeNewPiece('c', 7, new Rook(board, Color.BLACK));
        placeNewPiece('c', 8, new Rook(board, Color.BLACK));
        placeNewPiece('d', 7, new Rook(board, Color.BLACK));
        placeNewPiece('e', 7, new Rook(board, Color.BLACK));
        placeNewPiece('e', 8, new Rook(board, Color.BLACK));
        placeNewPiece('d', 8, new King(board, Color.BLACK));
    }
}
