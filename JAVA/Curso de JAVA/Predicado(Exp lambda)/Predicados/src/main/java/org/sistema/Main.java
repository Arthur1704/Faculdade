package org.sistema;

import java.util.ArrayList;
import java.util.List;

//TIP To <b>Run</b> code, press <shortcut actionId="Run"/> or
// click the <icon src="AllIcons.Actions.Execute"/> icon in the gutter.
public class Main {
    public static void main(String[] args) {

        List<Integer> lista = new ArrayList<>();
        lista.add(12);
        lista.add(33);
        lista.add(10);

        lista.removeIf(num -> num % 2 == 1);

        for (Integer num : lista){
            System.out.println("Num: " + num);
        }
    }
}