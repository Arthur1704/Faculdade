package operacoes;

import connection.ConnectionDB;
import entities.Discipline;

import java.sql.*;
import java.util.ArrayList;
import java.util.List;

public class CrudDiscipline {

    private Connection conn = ConnectionDB.getConn();

    public void insert(Discipline discipline) {
        PreparedStatement ps = null;
        ResultSet rs = null;
        try {
            ps = conn.prepareStatement(
                    "INSERT INTO dicipline (name, teacher) VALUES (?, ?)",
                    Statement.RETURN_GENERATED_KEYS);

            ps.setString(1, discipline.getName());
            ps.setString(2, discipline.getTeacher());

            ps.executeUpdate();

            rs = ps.getGeneratedKeys();
            if (rs.next()) {
                discipline.setId(rs.getInt(1));
            }
        } catch (SQLException e) {
            System.out.println("Error insert: " + e.getMessage());
        }
    }

    public void update(Discipline discipline) {
        PreparedStatement ps = null;
        try {
            ps = conn.prepareStatement(
                    "UPDATE dicipline SET name = ?, teacher = ? WHERE id = ?");

            ps.setString(1, discipline.getName());
            ps.setString(2, discipline.getTeacher());
            ps.setInt(3, discipline.getId());

            ps.executeUpdate();
        } catch (SQLException e) {
            System.out.println("Error update: " + e.getMessage());
        }
    }

    public void delete(Discipline discipline) {
        PreparedStatement ps = null;
        try {
            ps = conn.prepareStatement(
                    "DELETE FROM dicipline WHERE id = ?");

            ps.setInt(1, discipline.getId());
            ps.executeUpdate();
        } catch (SQLException e) {
            System.out.println("Error delete: " + e.getMessage());
        }
    }

    public Discipline findById(int id) {
        PreparedStatement ps = null;
        ResultSet rs = null;

        try {
            ps = conn.prepareStatement(
                    "SELECT * FROM dicipline WHERE id = ?");

            ps.setInt(1, id);
            rs = ps.executeQuery();
            if (rs.next()) {
                return setDiscipline(rs);
            }
        } catch (SQLException e) {
            System.out.println("Error findById: " + e.getMessage());
        }
        return null;
    }

    public List<Discipline> findAll() {
        PreparedStatement ps = null;
        ResultSet rs = null;
        List<Discipline> list = new ArrayList<>();

        try {
            ps = conn.prepareStatement("SELECT * FROM dicipline");
            rs = ps.executeQuery();

            while (rs.next()) {
                list.add(setDiscipline(rs));
            }
            return list;
        } catch (SQLException e) {
            System.out.println("Error findAll: " + e.getMessage());
        }
        return null;
    }
    
    public Discipline findByName(String name) {
        PreparedStatement ps = null;
        ResultSet rs = null;

        try {
            ps = conn.prepareStatement(
                    "SELECT * FROM dicipline WHERE name = ?");

            ps.setString(1, name);
            rs = ps.executeQuery();
            if (rs.next()) {
                return setDiscipline(rs);
            }
        } catch (SQLException e) {
            System.out.println("Error findByName: " + e.getMessage());
        }
        return null;
    }

    private Discipline setDiscipline(ResultSet rs) throws SQLException {
        Discipline discipline = new Discipline();
        discipline.setId(rs.getInt("id"));
        discipline.setName(rs.getString("name"));
        discipline.setTeacher(rs.getString("teacher"));
        return discipline;
    }
}
