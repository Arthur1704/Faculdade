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
import java.util.List;

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
            DB.closeConnection();
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
        return List.of();
    }
}
