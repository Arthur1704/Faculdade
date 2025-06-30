package com.programa;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Scanner;

import com.utilitarios.Produto;
import com.utilitarios.ProdutoImportado;
import com.utilitarios.ProdutoUsado;

public class Main {
    public static void main(String[] args) throws ParseException {
        
        Scanner guardar = new Scanner(System.in);
        SimpleDateFormat formato = new SimpleDateFormat("dd/MM/yyyy");

        ArrayList<Produto> lista = new ArrayList<>();

        System.out.print("Entre com o numero de Produtos: ");
        int numero = guardar.nextInt();
        guardar.nextLine();

        for(int cont = 0; cont < numero; cont++){
            System.out.println("Produto #" + (cont+1) + " :");
            System.out.print("Comum, usado, importado (c/u/i): ");
            char tipo = guardar.next().charAt(0);

            if(tipo == 'c'){
                guardar.nextLine();
                System.out.print("Nome: ");    
                String nome = guardar.nextLine();
                System.out.print("Preço: ");
                Double preco = guardar.nextDouble();
                lista.add(new Produto(nome, preco));
            }
            else if(tipo == 'u'){
                guardar.nextLine();
                System.out.print("Nome: ");    
                String nome = guardar.nextLine();
                System.out.print("Preço: ");
                Double preco = guardar.nextDouble();
                guardar.nextLine();
                System.out.print("Data de Fabricação (DD/MM/YYYY): ");
                String data = guardar.nextLine();
                lista.add(new ProdutoUsado(nome, preco, formato.parse(data)));
            }
            else{
                guardar.nextLine();
                System.out.print("Nome: ");    
                String nome = guardar.nextLine();
                System.out.print("Preço: ");
                Double preco = guardar.nextDouble();
                System.out.print("Custo frete: ");
                double frete = guardar.nextDouble();
                lista.add(new ProdutoImportado(nome, preco, frete));
            }
        }

        System.out.println();
        System.out.println("TAGS DE PREÇO");
        for (Produto produto : lista){
            System.out.println(produto.tagPreco());
        }
        guardar.close();
    }
}