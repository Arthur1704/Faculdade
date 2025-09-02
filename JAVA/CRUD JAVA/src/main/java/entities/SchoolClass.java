package entities;

import java.io.Serializable;
import java.util.ArrayList;
import java.util.List;

public class SchoolClass implements Serializable {

    private int id;
    private String description;
    private List<Discipline> discipline = new ArrayList<>();

    public SchoolClass() {

    }

    public SchoolClass(String description) {
        this.description = description;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public List<Discipline> getDiscipline() {
        return discipline;
    }
    
    public void add_discipline(Discipline d){
        this.discipline.add(d);
    }


}
