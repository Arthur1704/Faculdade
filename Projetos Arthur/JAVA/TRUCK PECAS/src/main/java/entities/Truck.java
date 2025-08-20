package entities;

import java.io.Serializable;

public class Truck implements Serializable {

    private Integer id;
    private String model;
    private String plate;
    private String descriptionProblem;
    private String responsible;

    public Truck() {

    }

    public Truck(String model, String plate, String descriptionProblem, String responsible) {
        this.model = model;
        this.plate = plate;
        this.descriptionProblem = descriptionProblem;
        this.responsible = responsible;
    }

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public String getModel() {
        return model;
    }

    public void setModel(String model) {
        this.model = model;
    }

    public String getPlate() {
        return plate;
    }

    public void setPlate(String plate) {
        this.plate = plate;
    }

    public String getDescriptionProblem() {
        return descriptionProblem;
    }

    public void setDescriptionProblem(String descriptionProblem) {
        this.descriptionProblem = descriptionProblem;
    }

    public String getResponsible() {
        return responsible;
    }

    public void setResponsible(String responsible) {
        this.responsible = responsible;
    }

    @Override
    public String toString() {
        return "Truck" +
                "id=" + id + "\n" +
                ", model='" + model + '\n' +
                ", plate='" + plate + '\n' +
                ", descriptionProblem='" + descriptionProblem + '\n' +
                ", responsible='" + responsible + '\n';
    }
}
