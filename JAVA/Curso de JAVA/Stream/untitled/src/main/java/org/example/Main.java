package org.example;

import org.utilits.Employee;

import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.util.*;
import java.util.stream.Collectors;

public class Main {
    public static void main(String[] args) {

        Scanner guardar = new Scanner(System.in);

        System.out.print("Entre com o caminho do arquivo: ");
        String path = guardar.nextLine();

        System.out.print("Enter salary: ");
        double salary = guardar.nextDouble();

        List<Employee> list = new ArrayList<>();
        Comparator<String> comp = (n1, n2) -> n1.toUpperCase().compareTo(n2.toUpperCase());
        try(BufferedReader br = new BufferedReader(new FileReader(path))){
            String linha = br.readLine();
            while(linha != null){
                String fields[] = linha.split(",");
                list.add(new Employee(fields[0], fields[1], Double.parseDouble(fields[2])));
                linha = br.readLine();
            }

            List<String> emails = list.stream().filter(p -> p.getSalario() < 2000.00).map(p -> p.getEmail()).sorted(comp).collect(Collectors.toList());
            System.out.printf("Email of people whose salary is more than %.2f:\n", salary);
            for(String email : emails){
                System.out.println(email);
            }

            Double soma = list.stream().filter(p -> p.getNome().charAt(0) == 'M').map(p -> p.getSalario()).reduce(0.0, (x,y) -> x + y);

            System.out.printf("Sum of salary of people whose name with 'M': %.2f", soma);
        }
        catch (IOException e){
            System.out.println("Error: " + e.getMessage());
        }
    }
}