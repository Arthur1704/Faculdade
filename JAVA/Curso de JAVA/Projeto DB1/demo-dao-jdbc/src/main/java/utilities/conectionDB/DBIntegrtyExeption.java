package utilities.conectionDB;

public class DBIntegrtyExeption extends RuntimeException{

    public DBIntegrtyExeption(String msg){
        super(msg);
    }
}
