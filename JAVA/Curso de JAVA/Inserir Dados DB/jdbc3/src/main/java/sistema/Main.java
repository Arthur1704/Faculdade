package sistema;

import utilities.conectionDB.DB;
import utilities.conectionDB.DBExeption;

import java.sql.*;
import java.text.ParseException;
import java.text.SimpleDateFormat;

//TIP To <b>Run</b> code, press <shortcut actionId="Run"/> or
// click the <icon src="AllIcons.Actions.Execute"/> icon in the gutter.
public class Main {
    public static void main(String[] args) {

        SimpleDateFormat format = new SimpleDateFormat("dd/MM/yyyy");
        Connection conn = null;

        PreparedStatement ps = null;

        try{
            conn = DB.getConnection();

            ps = conn.prepareStatement(
                    "INSERT INTO seller "
                    + "(Name, Email, BirthDate, BaseSalary, DepartmentId) "
                    + "VALUES "
                    + "(?,?,?,?,?)");

            ps.setString(1, "Arthur Viana");
            ps.setString(2, "arthur@gmail.com");
            ps.setDate(3, new java.sql.Date(format.parse("07/05/2006").getTime()));
            ps.setDouble(4, 1000.00);
            ps.setInt(5,4);

            int rows = ps.executeUpdate();

            if (rows == 1){
                System.out.println("Success");
            }else{
                System.out.println("Failure");
            }
        }
        catch(SQLException e){
            e.printStackTrace();
        }
        catch (ParseException e){
            e.printStackTrace();
        }
        finally {
            DB.closeStatment(ps);
            DB.closeConnection();
        }
    }
}