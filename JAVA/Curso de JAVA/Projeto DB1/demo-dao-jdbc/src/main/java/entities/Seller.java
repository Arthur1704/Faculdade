package entities;

import java.io.Serializable;
import java.util.Date;
import java.util.Objects;

public class Seller implements Serializable {

    private int id;
    private String name;
    private String email;
    private Date bhithDate;
    private Double baseSalary;
    private Department department;

    public Seller() {
    }

    public Seller(int id, String name, String email, Date bhithDate, Double baseSalary, Department department) {
        this.id = id;
        this.name = name;
        this.bhithDate = bhithDate;
        this.email = email;
        this.baseSalary = baseSalary;
        this.department = department;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public Date getBhithDate() {
        return bhithDate;
    }

    public void setBhithDate(Date bhithDate) {
        this.bhithDate = bhithDate;
    }

    public Double getBaseSalary() {
        return baseSalary;
    }

    public void setBaseSalary(Double baseSalary) {
        this.baseSalary = baseSalary;
    }

    public Department getDepartment() {
        return department;
    }

    public void setDepartment(Department department) {
        this.department = department;
    }

    @Override
    public boolean equals(Object o) {
        if (!(o instanceof Seller seller)) return false;
        return id == seller.id;
    }

    @Override
    public int hashCode() {
        return Objects.hashCode(id);
    }

    @Override
    public String toString() {
        return "Seller{" +
                "id=" + id +
                ", name='" + name + '\'' +
                ", email='" + email + '\'' +
                ", bhithDate=" + bhithDate +
                ", baseSalary=" + baseSalary +
                ", department=" + department +
                '}';
    }
}
