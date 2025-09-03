package connection;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;
import java.sql.Statement;

public class ConnectionDB {

    private String url = "jdbc:mysql://localhost:3306/faibank";
    private String user = "root";
    private String pass = "";

    public ConnectionDB(){
    }
    private static Connection conn = null;

    public void connect(){
        if (conn == null){
            try{
                conn = DriverManager.getConnection(this.url,this.user,this.pass);
                System.out.println("Conectado");
            }
            catch (SQLException e){
                System.out.print("Error to connect" + e.getMessage());
            }
        }
    }

    public static Connection getConn(){
        if (conn == null) {
            throw new IllegalStateException("Conexão não foi inicializada. Chame connect() primeiro.");
        }
        return conn;
    }


}
