package com.compra;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Scanner;

import com.utilitarios.Cliente;
import com.utilitarios.ItensPedido;
import com.utilitarios.Pedido;
import com.utilitarios.Produto;
import com.utilitarios.Status; 
import java.util.Date;

public class Main {
    public static void main(String[] args) throws ParseException {
        SimpleDateFormat format = new SimpleDateFormat("dd/MM/yyyy");
        Scanner guardar = new Scanner(System.in);
        
        System.out.println("Entre com os dados do cliente:");
        System.out.print("Nome: ");
        String nome = guardar.nextLine();
        System.out.print("Email: ");
        String email = guardar.nextLine();
        System.out.print("Data de Anivesario (DD/MM/YYYY): ");
        Date data = format.parse(guardar.next());

        Cliente cliente = new Cliente(nome, email, data);

        System.out.println("Dados do pedido: ");
        System.out.print("Status: ");
        Status st = Status.valueOf(guardar.next());

        Pedido pedido = new Pedido(new Date(), st, cliente);

        System.out.print("Entre com a quantidade de itens: ");
        int num = guardar.nextInt();
        guardar.nextLine();
        for(int cont = 0; cont < num; cont++){
            System.out.println("Entre com as informações do item #" + (cont+1) + " :");
            System.out.print("Nome do produto: ");
            String nomeP = guardar.nextLine();
            System.out.print("Preço do produto: ");
            double preco = guardar.nextDouble();
            System.out.print("Qauntidade: ");
            int quant = guardar.nextInt();

            Produto produto = new Produto(nomeP, preco);

            ItensPedido it = new ItensPedido(quant, preco, produto);

            pedido.adicionarIten(it);
        }

        System.out.println(pedido);

        guardar.close();
    }
}