package entities;

import java.io.Serializable;

public class Discipline implements Serializable {

    private int id;
    private String name;
    private String teacher;

    public Discipline() {
    }

    public Discipline(String name, String teacher) {
        this.name = name;
        this.teacher = teacher;
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

    public String getTeacher() {
        return teacher;
    }

    public void setTeacher(String teacher) {
        this.teacher = teacher;
    }

    @Override
    public String toString() {
        return "Discipline " + "id = " + id + ", name = " + name + ", teacher = " + teacher;
    }
    
    

}
