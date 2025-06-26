package com.lista;

import java.util.ArrayList;
import java.util.Scanner;
import com.utilitarios.Funcionarios;

public class Main {
    public static void main(String[] args) {
        ArrayList<Funcionarios> lista = new ArrayList<>();
        Scanner guardar = new Scanner(System.in);
        System.out.print("Entre com o numero de funcionarios que deseja cadastrar: ");
        int num = guardar.nextInt();
        guardar.nextLine();
        for (int cont = 0; cont < num; cont++){
            System.out.println("Funcionario #"+(cont+1));
            System.out.print("ID do funcionario: ");
            int id = guardar.nextInt();
            guardar.nextLine();
            System.out.print("Nome do funcionario: ");
            String nome = guardar.nextLine();
            System.out.print("Salario do funcionario: ");
            double salario = guardar.nextDouble();            
            lista.add(new Funcionarios(id, nome, salario));
        }

        System.out.print("Id do funcionario que deseja aumentar o salario: ");
        int func = guardar.nextInt();
        guardar.nextLine();

        System.out.print("Porcentagem do aumento: ");
        double aumento = guardar.nextDouble();

        for (Funcionarios aux : lista){
            if (aux.getId() == func){
                aux.aumento_salario(aumento);
                break;
            }
        }

        for (Funcionarios funcionarios : lista) {
            System.out.println(funcionarios.toString());
        }
        




        guardar.close();
    }
}