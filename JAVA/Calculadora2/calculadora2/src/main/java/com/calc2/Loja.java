package com.calc2;

public class Loja {

    String[] clientes = new String[100];
    String[][] vendas = new String[3][100];
    Tributacao calc = new Tributacao();
    private Produto[] produtos = new Produto[100];   
    int contador = 0;

    public Loja(){

    }

    public Loja(String nomeC){
        for (int cont = 0; cont < clientes.length; cont++){
            if(clientes[cont].equals("")){
                this.clientes[cont] = nomeC;
            }
        }
    }

    public adiciona_Produto(String nome, int quantidade, double valor){

        if(contador < nomeP.length){
            produtos[contador] = new Produto(nome, quantidade, valor);
            contador++;
        }
        else{
            System.out.println("Limite de Produtos atingido");
        }

    }

    private int retornar_Posi(String Matriz[][]){

        for (int cont = 0; cont < 100; cont++){
            if (Matriz[cont][0].equals("")){
                return cont;
            }
        }
        return -1;
    }

    public void set_venda(String nomeC, String nomeP, String valor){
        double valorP;
        int posi = retornar_Posi(vendas);
        if (posi != -1){

            this.vendas[posi][0] = nomeC; 
            this.vendas[posi][1] = nomeP;
            valorP = Double.parseDouble(valor);
            valorP += calc.Imposto_nacional(valorP);
            valor = String.valueOf(valorP);
            this.vendas[posi][2] = valor;

        }
        else{
            System.out.println("Não foi possivel Armazenar essa Venda!!");
        }
    }

    public void ver_Venda(String Cliente){
        for (int cont = 0; cont < 100; cont++){
            if (this.vendas[cont][0].equals(Cliente)){
                System.out.println(vendas[cont][0]);
                System.out.println(vendas[cont][1]);
                System.out.println(vendas[cont][2]);
            }
        }
    }

}
