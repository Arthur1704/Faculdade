package operacoes;

import connection.ConnectionDB;
import entities.Student;

import java.sql.*;
import java.util.ArrayList;
import java.util.List;

public class CrudStudent {

    private Connection conn = ConnectionDB.getConn();

    public void insert(Student student){
        PreparedStatement ps = null;
        ResultSet rs = null;
        try{
            ps = conn.prepareStatement(
                    "INSERT INTO student "
                        + "(name, surname, date_birth, city) "
                        + "VALUES (?,?,?,?)",
                        Statement.RETURN_GENERATED_KEYS);

            ps.setString(1, student.getName());
            ps.setString(2, student.getSurname());
            ps.setDate(3, student.getDateBirth());
            ps.setString(4, student.getCity());

            ps.executeUpdate();

            rs = ps.getGeneratedKeys();
            student.setRa(rs.getInt(1));

        }
        catch (SQLException e){
            System.out.println("Error insert: " + e.getMessage());
        }
    }

    public void update(Student student){
        PreparedStatement ps = null;
        try {
            ps = conn.prepareStatement(
                    "UPDATE student "
                        + "SET name = ?, surname = ?, date_birth = ?, city = ? "
                        + "WHERE ra = ?");

            ps.setString(1, student.getName());
            ps.setString(2, student.getSurname());
            ps.setDate(3, student.getDateBirth());
            ps.setString(4, student.getCity());
            ps.setInt(5, student.getRa());

            ps.executeUpdate();
        }
        catch (SQLException e){
            System.out.println("Error update: " + e.getMessage());
        }
    }

    public void delete(Student student){
        PreparedStatement ps = null;
        try {
            ps = conn.prepareStatement(
                    "DELETE FROM student WHERE ra = ?");

            ps.setInt(1, student.getRa());
            ps.executeUpdate();
        }
        catch (SQLException e){
            System.out.println("Error delete: " + e.getMessage());
        }
    }

    public Student findByRa(int ra){
        PreparedStatement ps = null;
        ResultSet rs = null;

        try {
            ps = conn.prepareStatement(
                    "SELECT * FROM student "
                    + "WHERE ra = ?");

            ps.setInt(1, ra);
            rs = ps.executeQuery();
            rs.next();
            return setStudent(rs);
        }
        catch (SQLException e){
            System.out.println("Error findByRa: " + e.getMessage());
        }
        return null;
    }

    public List<Student> findAll(){
        PreparedStatement ps = null;
        ResultSet rs = null;
        List<Student> list = new ArrayList<>();
        try {
            ps = conn.prepareStatement(
                    "SELECT * FROM student");


            rs = ps.executeQuery();
            while(rs.next()){
                list.add(setStudent(rs));
            }
            return list;
        }
        catch (SQLException e){
            System.out.println("Error findAll: " + e.getMessage());
        }
        return null;
    }

    private Student setStudent(ResultSet rs) throws SQLException {
        Student student = new Student();
        student.setRa(rs.getInt("ra"));
        student.setName(rs.getString("name"));
        student.setSurname(rs.getString("surname"));
        student.setDateBirth(rs.getDate("date_birth"));
        student.setCity(rs.getString("city"));

        return student;
    }
}
