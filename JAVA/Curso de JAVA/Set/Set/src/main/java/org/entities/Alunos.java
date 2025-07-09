package org.entities;

import java.util.Objects;

public class Alunos {

    private Integer num;

    public Alunos(Integer num) {
        this.num = num;
    }

    public Integer getNum() {
        return num;
    }

    public void setNum(Integer num) {
        this.num = num;
    }

    @Override
    public boolean equals(Object o) {
        if (o == null || getClass() != o.getClass()) return false;
        Alunos alunos = (Alunos) o;
        return Objects.equals(num, alunos.num);
    }

    @Override
    public int hashCode() {
        return Objects.hashCode(num);
    }
}
