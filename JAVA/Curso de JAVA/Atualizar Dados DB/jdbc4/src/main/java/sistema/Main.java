package sistema;

import utilities.conectionDB.DB;

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
                    "UPDATE seller "
                    + "SET BaseSalary = BaseSalary + ? "
                    + "WHERE "
                    + "(DepartmentId = ?)");

            st.setDouble(1, 200.00);
            st.setInt(2, 2);
            int rows = st.executeUpdate();
            System.out.println("Linhas afetadas " + rows);
        }
        catch(SQLException e){
            e.printStackTrace();
        }
    }
}