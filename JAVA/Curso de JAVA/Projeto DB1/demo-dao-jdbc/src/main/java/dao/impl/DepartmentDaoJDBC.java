package dao.impl;

import dao.DepartmentDao;
import entities.Department;
import utilities.conectionDB.DB;
import utilities.conectionDB.DBExeption;

import java.sql.*;
import java.util.ArrayList;
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
        PreparedStatement ps = null;
        try{
            ps = conn.prepareStatement("DELETE FROM department WHERE id = ?");
            ps.setInt(1,id);

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
    public Department findById(Integer id) {
        PreparedStatement ps = null;
        ResultSet rs = null;

        try{
            ps = conn.prepareStatement(
                    "SELECT department.* FROM department "
                    + "WHERE id = ?");

            ps.setInt(1, id);
            rs = ps.executeQuery();

            if (rs.next()){
                return instantiateDepartiment(rs);
            }
            return null;
        }
        catch (SQLException e){
            throw new DBExeption(e.getMessage());
        }
        finally {
            DB.closeStatment(ps);
            DB.closeResultSet(rs);
        }
    }

    @Override
    public List<Department> findAll() {
        PreparedStatement ps = null;
        ResultSet rs = null;
        List<Department> list = new ArrayList<>();
        try{
            ps = conn.prepareStatement("SELECT department.* FROM department");
            rs = ps.executeQuery();

            while(rs.next()){
                list.add(instantiateDepartiment(rs));
            }
            return list;
        }
        catch (SQLException e){
            throw new DBExeption(e.getMessage());
        }
    }

    private Department instantiateDepartiment(ResultSet rs) throws SQLException{
        Department dep = new Department();
        dep.setId(rs.getInt("Id"));
        dep.setName(rs.getString("Name"));
        return dep;
    }
}
