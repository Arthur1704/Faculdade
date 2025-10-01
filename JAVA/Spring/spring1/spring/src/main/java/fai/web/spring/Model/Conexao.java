package fai.web.spring.Model;

import java.sql.*;
public class Conexao {

    private Connection conn;
    private String url = "jdbc:mysql://localhost:3306/contatosdb";
    private String user =  "root";
    private String senha ="";

    public Conexao( ) throws SQLException {
        this.conn = DriverManager.getConnection(this.url, this.user, this.senha);
    }




    public int executarComando(String sql, Object... params) {
        int linhas = 0;

        try (PreparedStatement stmt = conn.prepareStatement(sql)) {
            for (int i = 0; i < params.length; i++) {
                stmt.setObject(i + 1, params[i]);
            }

            linhas = stmt.executeUpdate();
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return linhas;
    }



    public ResultSet executarQuery(String sql, Object... params) {
        try {
            PreparedStatement stmt = conn.prepareStatement(sql);
            for (int i = 0; i < params.length; i++) {
                stmt.setObject(i + 1, params[i]);
            }
            return stmt.executeQuery();
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return null;
    }

 

    public void fechar() {
        try {
            
                this.conn.close();
           
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }
}
