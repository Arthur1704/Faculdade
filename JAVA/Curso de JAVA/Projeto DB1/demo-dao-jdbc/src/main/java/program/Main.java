package program;

import dao.DaoFactory;
import dao.SellerDao;
import entities.Department;
import entities.Seller;

import java.util.List;

public class Main {
    public static void main(String[] args) {
        SellerDao sellerDao = DaoFactory.createSellerDao();

        System.out.println("=== TEST 1: FindById ===");
        Seller seller = sellerDao.findById(3);
        System.out.println(seller);

        System.out.println("\n=== TEST 2: FindByDepartment ===");
        Department dep = new Department(2, null);
        List<Seller> list = sellerDao.findByDepartment(dep);

        for (Seller se : list){
            System.out.println(se);
        }

        System.out.println("\n=== TEST 3: FindAll ===");
        List<Seller> listAll = sellerDao.findAll();

        for (Seller seller2 : listAll){
            System.out.println(seller2);
        }
    }
}