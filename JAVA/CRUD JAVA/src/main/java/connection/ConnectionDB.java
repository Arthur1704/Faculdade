package connection;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.Statement;

public class ConnectionDB {

    private String url = "jdbc:mysql://localhost:3307/faibank";
    private String user = "root";
    private String pass = "";

    private static Connection conn = null;

    public void connect(){
        try{
            this.conn = DriverManager.getConnection(this.url,this.user,this.pass);
        }
        catch (Exception e){
            System.out.print("Error to connect");
        }
    }

    public static Connection getConn(){
        return conn;
    }


}
