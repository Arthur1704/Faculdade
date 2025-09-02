package operacoes;

import connection.ConnectionDB;
import entities.SchoolClass;

import java.sql.*;
import java.util.ArrayList;
import java.util.List;

public class CrudSchoolClass {

    private Connection conn = ConnectionDB.getConn();

    public void insert(SchoolClass schoolClass) {
        PreparedStatement ps = null;
        ResultSet rs = null;
        try {
            ps = conn.prepareStatement(
                    "INSERT INTO school_class (description) VALUES (?)",
                    Statement.RETURN_GENERATED_KEYS);

            ps.setString(1, schoolClass.getDescription());
            ps.executeUpdate();

            rs = ps.getGeneratedKeys();
            if (rs.next()) {
                schoolClass.setId(rs.getInt(1));
            }
        } catch (SQLException e) {
            System.out.println("Error insert: " + e.getMessage());
        }
    }

    public void update(SchoolClass schoolClass) {
        PreparedStatement ps = null;
        try {
            ps = conn.prepareStatement(
                    "UPDATE school_class SET description = ? WHERE id = ?");

            ps.setString(1, schoolClass.getDescription());
            ps.setInt(2, schoolClass.getId());

            ps.executeUpdate();
        } catch (SQLException e) {
            System.out.println("Error update: " + e.getMessage());
        }
    }

    public void delete(SchoolClass schoolClass) {
        PreparedStatement ps = null;
        try {
            ps = conn.prepareStatement(
                    "DELETE FROM school_class WHERE id = ?");

            ps.setInt(1, schoolClass.getId());
            ps.executeUpdate();
        } catch (SQLException e) {
            System.out.println("Error delete: " + e.getMessage());
        }
    }

    public SchoolClass findById(int id) {
        PreparedStatement ps = null;
        ResultSet rs = null;

        try {
            ps = conn.prepareStatement(
                    "SELECT * FROM school_class WHERE id = ?");

            ps.setInt(1, id);
            rs = ps.executeQuery();

            if (rs.next()) {
                return setSchoolClass(rs);
            }
        } catch (SQLException e) {
            System.out.println("Error findById: " + e.getMessage());
        }
        return null;
    }

    public List<SchoolClass> findAll() {
        PreparedStatement ps = null;
        ResultSet rs = null;
        List<SchoolClass> list = new ArrayList<>();

        try {
            ps = conn.prepareStatement("SELECT * FROM school_class");
            rs = ps.executeQuery();

            while (rs.next()) {
                list.add(setSchoolClass(rs));
            }
            return list;
        } catch (SQLException e) {
            System.out.println("Error findAll: " + e.getMessage());
        }
        return null;
    }
    
    public SchoolClass findByDescription(String description){
        PreparedStatement ps = null;
        ResultSet rs = null;

        try {
            ps = conn.prepareStatement(
                    "SELECT * FROM school_class WHERE name = ?");

            ps.setString(1, description);
            rs = ps.executeQuery();

            if (rs.next()) {
                return setSchoolClass(rs);
            }
        } catch (SQLException e) {
            System.out.println("Error findByName: " + e.getMessage());
        }
        return null;
    }

    private SchoolClass setSchoolClass(ResultSet rs) throws SQLException {
        SchoolClass schoolClass = new SchoolClass();
        schoolClass.setId(rs.getInt("id"));
        schoolClass.setDescription(rs.getString("description"));
        return schoolClass;
    }
}
