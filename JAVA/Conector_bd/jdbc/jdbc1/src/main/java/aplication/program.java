package aplication;

import java.sql.Connection;
import db.DB;

public class program {
public static void main(String[] args){

    Connection con = DB.getConnection();
    DB.closeConnection();

    }
}
