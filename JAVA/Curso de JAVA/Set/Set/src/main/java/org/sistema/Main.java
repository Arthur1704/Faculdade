package org.sistema;

import org.entities.Alunos;
import org.entities.Instrutor;

import java.util.Scanner;


public class Main {
    public static void main(String[] args) {

        Scanner guardar = new Scanner(System.in);
        int num = 3;
        int letra = 65;

        Instrutor instrutor = new Instrutor("Alex");
        for(int cont = 0; cont < num; cont++) {

            System.out.print("How many students for course " + (char)letra + ": ");
            int alunos = guardar.nextInt();
            letra++;

            for (int cont2 = 0; cont2 < alunos; cont2++){
                System.out.print("Numero: ");
                int numero = guardar.nextInt();

                instrutor.adicioanarAlunos(new Alunos(numero));
            }
        }

        System.out.println(instrutor);
        guardar.close();
    }
}