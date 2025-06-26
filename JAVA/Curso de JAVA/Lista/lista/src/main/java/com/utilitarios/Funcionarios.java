package com.utilitarios;

public class Funcionarios {
    private int id;
    private String nome;
    private double salario;

    public Funcionarios(int id, String nome, double salario){
        this.id = id;
        this.nome = nome;
        this.salario = salario;
    }

    public int getId() {
        return id;
    }

    public String getNome() {
        return nome;
    }

    public double getSalario() {
        return salario;
    }

    public void aumento_salario(double porcentagem){
        double aumento = this.salario / porcentagem;
        salario += aumento;
    }

    @Override
    public String toString(){
        return "Lista de funcionarios : "
                + id
                + ", "
                + nome
                + ", "
                + salario;
    }

}
