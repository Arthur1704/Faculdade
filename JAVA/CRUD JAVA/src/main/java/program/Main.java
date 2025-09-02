package program;

import connection.ConnectionDB;
import operacoes.CrudStudent;


public class Main {
    public static void main(String[] args) {
        ConnectionDB conn = new ConnectionDB();
        conn.connect();


        CrudStudent crud = new CrudStudent();
        /*
        crud.insert(new Student("Fabio", "Viana", new java.sql.Date(72, Calendar.OCTOBER, 7), "Lucélia"));
        crud.insert(new Student("Eliana", "Viana", new java.sql.Date(76, Calendar.JULY, 19), "Lucélia"));

        Student student = crud.findByRa(2);
        student.setSurname("Batista Viana");
        crud.update(student);
        System.out.println(crud.findByRa(2));


        Student student = crud.findByRa(1);
        crud.delete(student);

        crud.findAll();
         */
    }
}