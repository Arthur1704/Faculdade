package boardgame;

public class Board {

    private int rows;
    private int columns;
    private Piece[][] pieces;

    public Board(int rows, int columns) {
        if(rows < 1 || columns < 1){
            throw new BoardException("Error creating board: there must be at least 1 row and 1 column");
        }
        this.rows = rows;
        this.columns = columns;
        pieces = new Piece[rows][columns];
    }

    public int getRows() {
        return rows;
    }

    public int getColumns() {
        return columns;
    }

    public Piece piece(int row, int colunm) {
        if(!positionExists(row, colunm)){
            throw new BoardException("Position not on the board");
        }
        return pieces[row][colunm];
    }
    
    public Piece piece (Position position){
        if(!positionExists(position)){
            throw new BoardException("Position not on the board");
        }
        return pieces[position.getRow()][position.getColunm()];
    }

    public void placePiece(Piece piece, Position position){
        if(thereAPiece(position)){
            throw new BoardException("There already a piece on position " + position);
        }
        pieces[position.getRow()][position.getColunm()] = piece;
        piece.position = position;
    }

    private boolean positionExists(int row, int collum){
        return row >= 0 && row < rows && collum >= 0 && collum < columns;
    }

    public boolean positionExists(Position position){
        return positionExists(position.getRow(), position.getColunm());
    }

    public boolean thereAPiece(Position position){
        if(!positionExists(position)){
            throw new BoardException("Position not on the board");
        }
        return piece(position) != null;
    }
}
