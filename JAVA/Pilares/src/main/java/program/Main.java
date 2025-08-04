package program;

import entities.Client;
import entities.Service;

import java.util.Scanner;

//TIP To <b>Run</b> code, press <shortcut actionId="Run"/> or
// click the <icon src="AllIcons.Actions.Execute"/> icon in the gutter.
public class Main {
    public static void main(String[] args) {

        Scanner guardar = new Scanner(System.in);
        System.out.print("Name client: ");
        String name = guardar.nextLine();
        System.out.print("Phone: ");
        String phone = guardar.nextLine();

        System.out.print("Some service ?(Y or N): ");
        char y_n = guardar.next().charAt(0);

        guardar.nextLine();

        y_n = Character.toUpperCase(y_n);
        Client client;
        if(y_n == 'Y'){
            System.out.print("Description service: ");
            String description = guardar.nextLine();
            System.out.print("Price: ");
            double price = guardar.nextDouble();

            client = new Client(name, phone, new Service(description, price));
        }
        else{
            client = new Client(name, phone);
        }

        System.out.print("New service ?(Y or N): ");
        char newService = guardar.next().charAt(0);


        newService = Character.toUpperCase(newService);
        if (newService == 'Y') {
            do {
                guardar.nextLine();
                System.out.print("Description service: ");
                String description = guardar.nextLine();
                System.out.print("Price: ");
                double price = guardar.nextDouble();
                guardar.nextLine();
                client.newService(new Service(description, price));

                System.out.print("New service ?(Y or N): ");
                newService = guardar.next().charAt(0);

                newService = Character.toUpperCase(newService);
            } while (newService == 'Y');
        }

        System.out.println(client);
    }
}