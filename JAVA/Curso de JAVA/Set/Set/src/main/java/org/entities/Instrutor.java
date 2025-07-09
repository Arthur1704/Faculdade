package org.entities;

import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;
import java.util.Set;

public class Instrutor {

    private String nome;
    private List<Cursos> cursos = new ArrayList<>();
    private Set<Alunos> alunos = new HashSet<>();

    public Instrutor() {
    }

    public Instrutor(String nome) {
        this.nome = nome;
    }

    public String getNome() {
        return nome;
    }

    public void setNome(String nome) {
        this.nome = nome;
    }

    public List<Cursos> getCursos() {
        return cursos;
    }

    public void addCurso(Cursos curso){
        this.cursos.add(curso);
    }

    public Set<Alunos> getAlunos(){
        return alunos;
    }

    public void adicioanarAlunos(Alunos aluno){
        this.alunos.add(aluno);
    }

    @Override
    public String toString(){
        return "Total de alunos: " + alunos.size();
    }
}
