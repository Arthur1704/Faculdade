package DB.truck;

import entities.Truck;

import java.sql.*;

public class CrudTruck {

    private Connection conn;

    public Truck insert(Truck truck){
        PreparedStatement ps = null;

        try {
            ps =  conn.prepareStatement(
                    "INSERT INTO truck "
                    + "(model, plate, descriptionProblem, responsible) "
                    + "VALUES (?,?,?,?)",
                    Statement.RETURN_GENERATED_KEYS);

            ps.setString(1, truck.getModel());
            ps.setString(2, truck.getPlate());
            ps.setString(3, truck.getDescriptionProblem());
            ps.setString(4, truck.getResponsible());

            ps.executeUpdate();

            ResultSet rs = null;
            rs = ps.getGeneratedKeys();

            if(rs.next()){
                truck.setId(rs.getInt(1));
            }

            return truck;
        }
        catch (SQLException e){
            System.out.println("Error insert truck: " + e.getMessage());
        }
        return null;
    }
}
