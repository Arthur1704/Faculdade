package entities;

import java.io.Serializable;
import java.sql.Date;

public class Student implements Serializable {

    private Integer ra;
    private String name;
    private String surname;
    private Date dateBirth;
    private String city;


    public Student(){

    }

    public Student(String name, String surname, Date dateBirth, String city) {
        this.name = name;
        this.surname = surname;
        this.dateBirth = dateBirth;
        this.city = city;
    }

    public void setRa(int ra){
        this.ra = ra;
    }

    public Integer getRa() {
        return ra;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getSurname() {
        return surname;
    }

    public void setSurname(String surname) {
        this.surname = surname;
    }

    public Date getDateBirth() {
        return dateBirth;
    }

    public void setDateBirth(Date dateBirth) {
        this.dateBirth = dateBirth;
    }

    public String getCity() {
        return city;
    }

    public void setCity(String city) {
        this.city = city;
    }

    @Override
    public String toString() {
        return "Student: " + '\n' +
                ", ra = " + ra + '\n' +
                ", name = '" + name + '\n' +
                ", surname = '" + surname + '\n' +
                ", dateBirth = " + dateBirth + '\n' +
                ", city = '" + city + '\n';
    }
}
