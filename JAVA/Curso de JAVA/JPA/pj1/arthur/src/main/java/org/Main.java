package org;

import dominio.Pessoa;

public class Main {
    public static void main(String[] args) {
        Pessoa p1 = new Pessoa(1, "Arthur Vaina", "arthur@gmail.com");
        Pessoa p2 = new Pessoa(2, "Jessica Vaina", "jessica@gmail.com");
        Pessoa p3 = new Pessoa(3, "Eliana Vaina", "eliana@gmail.com");

        System.out.println(p1);
        System.out.println(p2);
        System.out.println(p3);
    }
}