package dao;

import dao.impl.SellerDaoJDBC;
import utilities.conectionDB.DB;

public class DaoFactory {

    public static SellerDao createSellerDao(){
        return new SellerDaoJDBC(DB.getConnection());
    }
}
