package dao.impl;

import dao.DepartmentDao;
import entities.Department;
import utilities.conectionDB.DB;
import utilities.conectionDB.DBExeption;

import java.sql.*;
import java.util.List;

public class DepartmentDaoJDBC implements DepartmentDao {

    Connection conn;

    public DepartmentDaoJDBC(Connection conn){this.conn = conn;}

    @Override
    public void insert(Department dep) {
        PreparedStatement ps = null;

        try{
            ps = conn.prepareStatement(
                    "INSERT INTO department "
                        + "(Name) VALUES (?)",
                        Statement.RETURN_GENERATED_KEYS
            );

            ps.setString(1, dep.getName());
            int rows = ps.executeUpdate();

            if(rows != 0){
                ResultSet rs = ps.getGeneratedKeys();
                if (rs.next()){
                    dep.setId(rs.getInt(1));
                }
                DB.closeResultSet(rs);
            }
            else{
                throw new DBExeption("Error insert department");
            }
        }
        catch (SQLException e){
            throw new DBExeption(e.getMessage());
        }
        finally {
            DB.closeStatment(ps);
        }
    }

    @Override
    public void update(Department dep) {
        PreparedStatement ps = null;
        try{
            ps = conn.prepareStatement(
                    "UPDATE department "
                    + "SET Name = ? "
                    + "WHERE id = ?");

            ps.setString(1, dep.getName());
            ps.setInt(2, dep.getId());

            ps.executeUpdate();

        }
        catch (SQLException e){
            throw new DBExeption(e.getMessage());
        }
        finally {
            DB.closeStatment(ps);
        }
    }

    @Override
    public void deleteById(Integer id) {
        
    }

    @Override
    public Department findById(Integer id) {
        return null;
    }

    @Override
    public List<Department> findAll() {
        return List.of();
    }
}
