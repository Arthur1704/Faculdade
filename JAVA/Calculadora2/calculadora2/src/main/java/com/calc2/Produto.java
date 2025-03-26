package com.calc2;

public class Produto {

    String[] nomeP = new String[100];
    int[] quantP = new int[100];
    double[] valorP = new double[100];

    public Produto(){

    }

    public Produto(String nome, int quantidade, double valor){

        for (int cont = 0; cont < nomeP.length; cont++){
            if(nomeP[cont].equals("")){
                this.nomeP[cont] = nome;
                this.quantP[cont] = quantidade;
                this.valorP[cont] = valor;
            }
        }

    }
    
    public int Buscar_quantP(String nome){
        
        for(int cont = 0; cont < nomeP.length; cont++){

            if (nomeP[cont].equals(nome)){
                return quantP[cont];
            }

        }
        return 0;
    }

    public double Buscar_valorP(String nome){
        
        for(int cont = 0; cont < nomeP.length; cont++){

            if (nomeP[cont].equals(nome)){
                return valorP[cont];
            }

        }
        return 0;
    }

}
