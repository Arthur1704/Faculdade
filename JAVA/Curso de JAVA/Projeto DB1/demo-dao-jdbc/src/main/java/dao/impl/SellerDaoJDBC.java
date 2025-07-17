package dao.impl;

import dao.SellerDao;
import entities.Department;
import entities.Seller;
import utilities.conectionDB.DB;
import utilities.conectionDB.DBExeption;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class SellerDaoJDBC implements SellerDao {

    Connection conn;

    public SellerDaoJDBC(Connection conn){
        this.conn = conn;
    }

    @Override
    public void insert(Seller obj) {

    }

    @Override
    public void update(Seller obj) {

    }

    @Override
    public void deleteById(Integer id) {

    }

    @Override
    public Seller findById(Integer id) {
        PreparedStatement ps = null;
        ResultSet rs = null;

        try{
            ps = conn.prepareStatement(
                    "SELECT seller.*,"
                    + "department.name as DepName "
                    + "FROM seller "
                    + "INNER JOIN department on seller.departmentId = department.Id "
                    + "WHERE seller.id = ?");

            ps.setInt(1, id);
            rs = ps.executeQuery();

            if (rs.next()){
                Department dep = instantiateDepartiment(rs);
                Seller seller = instantiateSeller(rs, dep);
                return seller;
            }
            return null;
        }
        catch(SQLException e){
            throw new DBExeption(e.getMessage());
        }
        finally {
            DB.closeStatment(ps);
            DB.closeResultSet(rs);
        }
    }

    private Seller instantiateSeller(ResultSet rs, Department dep) throws SQLException{
        return new Seller(rs.getInt("Id"), rs.getString("Name"), rs.getDate("BirthDate"), rs.getString("Email"), rs.getDouble("BaseSalary"), dep);
    }

    private Department instantiateDepartiment(ResultSet rs) throws SQLException{
        Department dep = new Department();
        dep.setId(rs.getInt("DepartmentId"));
        dep.setName(rs.getString("DepName"));
        return dep;
    }

    @Override
    public List<Seller> findAll() {
        PreparedStatement ps = null;
        ResultSet rs = null;
        List<Seller> list = new ArrayList<>();
        Map<Integer, Department> map = new HashMap<>();
        try{
            ps = conn.prepareCall(
                    "SELECT seller.*, "
                    + "department.Name as DepName "
                    + "FROM seller INNER JOIN department ON seller.DepartmentId = department.Id "
                    + "ORDER BY Name");

            rs = ps.executeQuery();

            while (rs.next()){
                Department dep = map.get(rs.getInt("DepartmentId"));
                if(dep == null){
                     dep = instantiateDepartiment(rs);
                     map.put(rs.getInt("DepartmentId"), dep);
                }
                Seller seller = instantiateSeller(rs,dep);
                list.add(seller);
            }
            return list;
        }
        catch (SQLException e){
            throw new DBExeption(e.getMessage());
        }
        finally {
            DB.closeResultSet(rs);
            DB.closeStatment(ps);
        }
    }

    @Override
    public List<Seller> findByDepartment(Department department) {
        PreparedStatement st = null;
        ResultSet rs = null;

        try{
            st = conn.prepareStatement(
                    "SELECT seller.*, "
                    + "department.Name as DepName "
                    + "FROM seller INNER JOIN department ON seller.DepartmentId = department.Id "
                    + "WHERE Department.Id = ? "
                    + "ORDER BY Name");

            st.setInt(1, department.getId());
            rs = st.executeQuery();
            List<Seller> list = new ArrayList<>();
            Map<Integer, Department> map = new HashMap<>();

            while(rs.next()){

                Department dep = map.get(department.getId());

                if(dep == null){
                    dep = instantiateDepartiment(rs);
                    map.put(rs.getInt("DepartmentId"), dep);
                }
                Seller seller = instantiateSeller(rs,dep);
                list.add(seller);
            }
            return list;
        }
        catch (SQLException e){
            throw new DBExeption(e.getMessage());
        }
        finally {
            DB.closeResultSet(rs);
            DB.closeStatment(st);
        }
    }
}
