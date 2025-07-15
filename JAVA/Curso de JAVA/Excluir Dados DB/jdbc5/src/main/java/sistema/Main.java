package sistema;

import utilities.conectionDB.DB;
import utilities.conectionDB.DBIntegrtyExeption;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.SQLException;


public class Main {
    public static void main(String[] args) {

        Connection conn = null;
        PreparedStatement st = null;

        try{
            conn = DB.getConnection();

            st = conn.prepareStatement(
                    "DELETE FROM department "
                    + "WHERE Id = ?");

            st.setInt(1, 2);
            int rows = st.executeUpdate();
            System.out.println("Linhas afetadas " + rows);
        }
        catch(SQLException e){
            throw new DBIntegrtyExeption(e.getMessage());
        }
    }
}