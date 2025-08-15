package boardgame;

public abstract class Piece {
    protected Position position;
    private Board board;
    
    public Piece(Board board) {
        this.board = board;
    }

    protected Board getBoard() {
        return board;
    }

    public abstract boolean[][] possibleMoves();
    public boolean possibleMove(Position position){
        return possibleMoves()[position.getRow()][position.getColunm()];
    }

    public boolean isThereAnyPossibleMovie(){
        boolean[][] mat = possibleMoves();

        for (int cont = 0; cont < mat.length; cont++){
            for (int cont2 = 0; cont2 < mat.length; cont2++) {
                if (mat[cont][cont2]) {
                    return true;
                }
            }
        }
        return false;
    }

    
}
